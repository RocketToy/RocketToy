using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RocketToy1
{
    public partial class Form1 : Form
    {
        Process rl;
        Entity selectedEntity = null;
        List<Entity> loadedEntities;
        Thread operationThread;
        static readonly byte[] EntitySignature = new byte[] { 0x6B, 0x0B, 0x5E, 0x5D };
        public Form1()
        {
            try
            {
                rl = Process.GetProcessesByName("RocketLeague")[0];
            } catch
            {
                DialogBuilder.BuildAndShowDialog(
                    "Rocket League is not open",
                    "Error",
                    new List<DialogBuilder.DControl>(),
                    new List<DialogBuilder.DClosingButtonOption>()
                    {
                        new DialogBuilder.DClosingButtonOption(0, "Close", true, 100)
                    },
                    400,
                    7
                );
                Environment.Exit(-1);
            }
            InitializeComponent();
            changeInputs(false);
            foreach (NumericUpDown nud in this.Controls.OfType<NumericUpDown>())
            {
                nud.Maximum = decimal.MaxValue;
                nud.Minimum = decimal.MinValue;
                nud.DecimalPlaces = 3;
            }
        }

        private void getEntities()
        {
            List<Entity> entities = new List<Entity>();
            MemoryEditor memEditor = new MemoryEditor(rl);
            foreach (int address in memEditor.GetAddressesOf(EntitySignature))
            {
                entities.Add(new Entity(EntitySignature, address, rl));
            }
            loadedEntities = entities;
        }

        private void updateEntityList(List<Entity> Entities, bool HideUnknowns)
        {
            int index = -1;
            try
            {
                index = listView1.SelectedIndices[0];
            } catch { }
            listView1.SuspendLayout();
            listView1.Items.Clear();
            foreach (Entity e in Entities)
            {
                string type = "Unknown";
                if (e.PositionY > 0.2 && e.PositionY < 0.5)
                {
                    type = "Car";
                }
                if (e.PositionY > 1.85 && e.PositionY < 2)
                {
                    type = "Ball";
                }
                if (e.PositionX.ToString("n2") == "81.92" || e.PositionX.ToString("n2") == "-81.92" || e.PositionZ.ToString("n1") == "102.4" || e.PositionZ.ToString("n1") == "-102.4")
                {
                    type = "Wall Collision";
                }
                if (e.PositionY.ToString("n2") == "40.96")
                {
                    type = "Ceiling Collision";
                }
                if (e.CustomType != "")
                {
                    type = e.CustomType;
                }
                if (type != "Unknown" || !HideUnknowns)
                {
                    ListViewItem item = new ListViewItem(new string[] { BitConverter.ToString(e.FullSignature), type, e.PositionX.ToString("n3").TrimEnd('0').TrimEnd('.'), e.PositionY.ToString("n3").TrimEnd('0').TrimEnd('.'), e.PositionZ.ToString("n3").TrimEnd('0').TrimEnd('.'), e.VelocityX.ToString("n3").TrimEnd('0').TrimEnd('.'), e.VelocityY.ToString("n3").TrimEnd('0').TrimEnd('.'), e.VelocityZ.ToString("n3").TrimEnd('0').TrimEnd('.') });
                    item.Tag = e;
                    listView1.Items.Add(item);
                }
            }
            if (index != -1)
            {
                try
                {
                    listView1.Items[index].Selected = true;
                } catch { }
            }
            listView1.ResumeLayout();
        }

        private void refreshEntityList(bool refreshType = false)
        {
            foreach (ListViewItem lvi in listView1.Items)
            {
                Entity en = (Entity)lvi.Tag;
                if (en.FullSignature == null)
                {
                    listView1.Items.Remove(lvi);
                    continue;
                }
                if (refreshType && en.CustomType != "")
                {
                    lvi.SubItems[1].Text = en.CustomType;
                }
                if (lvi.SubItems[2].Text != en.PositionX.ToString("n3").TrimEnd('0').TrimEnd('.') || lvi.SubItems[3].Text != en.PositionY.ToString("n3").TrimEnd('0').TrimEnd('.') || lvi.SubItems[4].Text != en.PositionZ.ToString("n3").TrimEnd('0').TrimEnd('.') || lvi.SubItems[5].Text != en.VelocityX.ToString("n3").TrimEnd('0').TrimEnd('.') || lvi.SubItems[6].Text != en.VelocityY.ToString("n3").TrimEnd('0').TrimEnd('.') || lvi.SubItems[7].Text != en.VelocityZ.ToString("n3").TrimEnd('0').TrimEnd('.'))
                {
                    lvi.SubItems[2].Text = en.PositionX.ToString("n3").TrimEnd('0').TrimEnd('.');
                    lvi.SubItems[3].Text = en.PositionY.ToString("n3").TrimEnd('0').TrimEnd('.');
                    lvi.SubItems[4].Text = en.PositionZ.ToString("n3").TrimEnd('0').TrimEnd('.');
                    lvi.SubItems[5].Text = en.VelocityX.ToString("n3").TrimEnd('0').TrimEnd('.');
                    lvi.SubItems[6].Text = en.VelocityY.ToString("n3").TrimEnd('0').TrimEnd('.');
                    lvi.SubItems[7].Text = en.VelocityZ.ToString("n3").TrimEnd('0').TrimEnd('.');
                    if (selectedEntity == en)
                    {
                        listView1_SelectedIndexChanged(null, null);
                    }
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Refresh();
            listView1.DoubleBuffering(true);
            getEntities();
            updateEntityList(loadedEntities, checkBox1.Checked);
            operationThread = new Thread(operationLoop);
            operationThread.Start();
        }

        public void operationLoop()
        {
            while (true)
            {
                Invoke(new Action(() =>
                {
                    refreshEntityList();
                }));
                foreach (Entity e in loadedEntities.ToList())
                {
                    if (e.Settings.PosXThresh.GreaterThanEnabled && e.PositionX < e.Settings.PosXThresh.GreaterThanThreshold)
                    {
                        e.PositionX = e.Settings.PosXThresh.GreaterThanThreshold;
                        if (e.Settings.PosXThresh.SimulateCollision)
                        {
                            e.VelocityX = 0 - e.VelocityX / 2;
                        } else
                        {
                            e.VelocityX = 0;
                        }
                    }
                    if (e.Settings.PosXThresh.LessThanEnabled && e.PositionX > e.Settings.PosXThresh.LessThanThreshold)
                    {
                        e.PositionX = e.Settings.PosXThresh.LessThanThreshold;
                        if (e.Settings.PosXThresh.SimulateCollision)
                        {
                            e.VelocityX = 0 - e.VelocityX / 2;
                        }
                        else
                        {
                            e.VelocityX = 0;
                        }
                    }
                    if (e.Settings.PosYThresh.GreaterThanEnabled && e.PositionY < e.Settings.PosYThresh.GreaterThanThreshold)
                    {
                        e.PositionY = e.Settings.PosYThresh.GreaterThanThreshold;
                        if (e.Settings.PosYThresh.SimulateCollision)
                        {
                            e.VelocityY = 0 - e.VelocityY / 2;
                        }
                        else
                        {
                            e.VelocityY = 0;
                        }
                    }
                    if (e.Settings.PosYThresh.LessThanEnabled && e.PositionY > e.Settings.PosYThresh.LessThanThreshold)
                    {
                        e.PositionY = e.Settings.PosYThresh.LessThanThreshold;
                        if (e.Settings.PosYThresh.SimulateCollision)
                        {
                            e.VelocityY = 0 - e.VelocityY / 2;
                        }
                        else
                        {
                            e.VelocityY = 0;
                        }
                    }
                    if (e.Settings.PosZThresh.GreaterThanEnabled && e.PositionZ < e.Settings.PosZThresh.GreaterThanThreshold)
                    {
                        e.PositionZ = e.Settings.PosZThresh.GreaterThanThreshold;
                        if (e.Settings.PosZThresh.SimulateCollision)
                        {
                            e.VelocityZ = 0 - e.VelocityZ / 2;
                        }
                        else
                        {
                            e.VelocityZ = 0;
                        }
                    }
                    if (e.Settings.PosZThresh.LessThanEnabled && e.PositionZ > e.Settings.PosZThresh.LessThanThreshold)
                    {
                        e.PositionZ = e.Settings.PosZThresh.LessThanThreshold;
                        if (e.Settings.PosZThresh.SimulateCollision)
                        {
                            e.VelocityZ = 0 - e.VelocityZ / 2;
                        }
                        else
                        {
                            e.VelocityZ = 0;
                        }
                    }
                    if (e.Settings.VelXThresh.GreaterThanEnabled && e.VelocityX < e.Settings.VelXThresh.GreaterThanThreshold)
                    {
                        e.VelocityX = e.Settings.VelXThresh.GreaterThanThreshold;
                    }
                    if (e.Settings.VelXThresh.LessThanEnabled && e.VelocityX > e.Settings.VelXThresh.LessThanThreshold)
                    {
                        e.VelocityX = e.Settings.VelXThresh.LessThanThreshold;
                    }
                    if (e.Settings.VelYThresh.GreaterThanEnabled && e.VelocityY < e.Settings.VelYThresh.GreaterThanThreshold)
                    {
                        e.VelocityY = e.Settings.VelYThresh.GreaterThanThreshold;
                    }
                    if (e.Settings.VelYThresh.LessThanEnabled && e.VelocityY > e.Settings.VelYThresh.LessThanThreshold)
                    {
                        e.VelocityY = e.Settings.VelYThresh.LessThanThreshold;
                    }
                    if (e.Settings.VelZThresh.GreaterThanEnabled && e.VelocityZ < e.Settings.VelZThresh.GreaterThanThreshold)
                    {
                        e.VelocityZ = e.Settings.VelZThresh.GreaterThanThreshold;
                    }
                    if (e.Settings.VelZThresh.LessThanEnabled && e.VelocityZ > e.Settings.VelZThresh.LessThanThreshold)
                    {
                        e.VelocityZ = e.Settings.VelZThresh.LessThanThreshold;
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            getEntities();
            updateEntityList(loadedEntities, checkBox1.Checked);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                changeInputs(false);
                return;
            }
            selectedEntity = (Entity)listView1.SelectedItems[0].Tag;
            changeInputs(true);
            try
            {
                PosXVal.Value = Convert.ToDecimal((double)selectedEntity.PositionX);
            } catch
            {
                
                PosXVal.Enabled = false;
            }
            try
            {
                PosYVal.Value = Convert.ToDecimal((double)selectedEntity.PositionY);
            } catch
            {
                PosYVal.Enabled = false;
            }
            try
            {
                PosZVal.Value = Convert.ToDecimal((double)selectedEntity.PositionZ);
            } catch
            {
                PosZVal.Enabled = false;
            }
            try
            {
                VelXVal.Value = Convert.ToDecimal((double)selectedEntity.VelocityX);
            } catch
            {
                VelXVal.Enabled = false;
            }
            try
            {
                VelYVal.Value = Convert.ToDecimal((double)selectedEntity.VelocityY);
            } catch
            {
                VelYVal.Enabled = false;
            }
            try
            {
                VelZVal.Value = Convert.ToDecimal((double)selectedEntity.VelocityZ);
            } catch
            {
                VelZVal.Enabled = false;
            }
        }

        private void changeInputs(bool enabled)
        {
            PosXVal.Enabled = enabled;
            PosYVal.Enabled = enabled;
            PosZVal.Enabled = enabled;
            VelXVal.Enabled = enabled;
            VelYVal.Enabled = enabled;
            VelZVal.Enabled = enabled;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            updateEntityList(loadedEntities, checkBox1.Checked);
        }

        private void PosXVal_ValueChanged(object sender, EventArgs e)
        {
            selectedEntity.PositionX = (float)PosXVal.Value;
        }

        private void PosYVal_ValueChanged(object sender, EventArgs e)
        {
            selectedEntity.PositionY = (float)PosYVal.Value;
        }

        private void PosZVal_ValueChanged(object sender, EventArgs e)
        {
            selectedEntity.PositionZ = (float)PosZVal.Value;
        }

        private void VelXVal_ValueChanged(object sender, EventArgs e)
        {
            selectedEntity.VelocityX = (float)VelXVal.Value;
        }

        private void VelYVal_ValueChanged(object sender, EventArgs e)
        {
            selectedEntity.VelocityY = (float)VelYVal.Value;
        }

        private void VelZVal_ValueChanged(object sender, EventArgs e)
        {
            selectedEntity.VelocityZ = (float)VelZVal.Value;
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem lvi = listView1.GetItemAt(e.X, e.Y);
                if (lvi != null)
                {
                    listViewContext.Show((Control)sender, e.X, e.Y);
                }
            }
        }

        private void markTypeAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogBuilder.DResult result = DialogBuilder.BuildAndShowDialog(
                "Mark Type",
                new List<DialogBuilder.DControl>()
                {
                    new DialogBuilder.DControl(
                        "Enter type name:",
                        new TextBox()
                    )
                },
                new List<DialogBuilder.DClosingButtonOption>()
                {
                    new DialogBuilder.DClosingButtonOption(0, "Set", true, 100),
                    new DialogBuilder.DClosingButtonOption(1, "Cancel", false, 100)
                },
                400,
                7
            );
            if (result.ClosingButtonOptionIDPressed == 1 || result.ClosingButtonOptionIDPressed == -1)
            {
                return;
            }
            selectedEntity.CustomType = result.ResultingControls[0].Text;
            refreshEntityList(true);
        }

        private void goAwayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedEntity.PositionX = 10000;
            selectedEntity.PositionY = 10000;
            selectedEntity.PositionZ = 10000;
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showThreshDialog(selectedEntity.Settings.PosXThresh, false);
        }

        private void yToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showThreshDialog(selectedEntity.Settings.PosYThresh, false);
        }

        private void zToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showThreshDialog(selectedEntity.Settings.PosZThresh, false);
        }

        private void xToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showThreshDialog(selectedEntity.Settings.VelXThresh, true);
        }

        private void yToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showThreshDialog(selectedEntity.Settings.VelYThresh, true);
        }

        private void zToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showThreshDialog(selectedEntity.Settings.VelZThresh, true);
        }

        private void showThreshDialog(Threshold ExistingThresh, bool Velocity)
        {
            NumericUpDown GEV = new NumericUpDown();
            GEV.Enabled = ExistingThresh.GreaterThanEnabled;
            GEV.Maximum = decimal.MaxValue;
            GEV.Minimum = decimal.MinValue;
            GEV.DecimalPlaces = 3;
            GEV.Value = Convert.ToDecimal((double)ExistingThresh.GreaterThanThreshold);
            CheckBox GEC = new CheckBox();
            GEC.Text = "Property Must be >=";
            GEC.Checked = ExistingThresh.GreaterThanEnabled;
            GEC.CheckedChanged += (object sender1, EventArgs e1) => { GEV.Enabled = GEC.Checked; };
            NumericUpDown LEV = new NumericUpDown();
            LEV.Enabled = ExistingThresh.LessThanEnabled;
            LEV.Maximum = decimal.MaxValue;
            LEV.Minimum = decimal.MinValue;
            LEV.DecimalPlaces = 3;
            LEV.Value = Convert.ToDecimal((double)ExistingThresh.LessThanThreshold);
            CheckBox LEC = new CheckBox();
            LEC.Text = "Property Must be <=";
            LEC.Checked = ExistingThresh.LessThanEnabled;
            LEC.CheckedChanged += (object sender1, EventArgs e1) => { LEV.Enabled = LEC.Checked; };
            CheckBox SC = new CheckBox();
            SC.Text = "Simulate Collision";
            SC.Checked = ExistingThresh.SimulateCollision;
            SC.Enabled = !Velocity;
            DialogBuilder.DResult result = DialogBuilder.BuildAndShowDialog(
                "Set Threshold",
                "Set Threshold",
                new List<DialogBuilder.DControl>()
                {
                    new DialogBuilder.DControl("", GEC, false, false, false),
                    new DialogBuilder.DControl("", GEV, false, false, false),
                    new DialogBuilder.DControl("", LEC, false, false, false),
                    new DialogBuilder.DControl("", LEV, false, false, false),
                    new DialogBuilder.DControl("", SC, false, false, false)
                },
                new List<DialogBuilder.DClosingButtonOption>()
                {
                    new DialogBuilder.DClosingButtonOption(0, "Set", true, 100),
                    new DialogBuilder.DClosingButtonOption(1, "Cancel", false, 100)
                },
                221,
                7
            );
            if (result.ClosingButtonOptionIDPressed == 0)
            {
                ExistingThresh.GreaterThanEnabled = GEC.Checked;
                ExistingThresh.GreaterThanThreshold = (float)GEV.Value;
                ExistingThresh.LessThanEnabled = LEC.Checked;
                ExistingThresh.LessThanThreshold = (float)LEV.Value;
                ExistingThresh.SimulateCollision = SC.Checked;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            operationThread.Abort();
            e.Cancel = false;
        }
    }
    public static class ControlExtensions
    {
        public static void DoubleBuffering(this Control control, bool enable)
        {
            var method = typeof(Control).GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.NonPublic);
            method.Invoke(control, new object[] { ControlStyles.OptimizedDoubleBuffer, enable });
        }
    }
}
