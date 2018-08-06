using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RocketToy1
{
    static class DialogBuilder
    {
        private static Form dialog;
        private static DResult result;
        public class DControl
        {
            public string Caption;
            public Control Control;
            public bool PreserveWidth = false;
            public bool PreserveHeight = false;
            public bool ShowCaption = true;
            public DControl(string caption, Control control)
            {
                Caption = caption;
                Control = control;
            }
            public DControl(string caption, Control control, bool preserveWidth, bool preserveHeight)
            {
                Caption = caption;
                Control = control;
                PreserveWidth = preserveWidth;
                PreserveHeight = preserveHeight;
            }
            public DControl(string caption, Control control, bool preserveWidth, bool preserveHeight, bool showCaption)
            {
                Caption = caption;
                Control = control;
                PreserveWidth = preserveWidth;
                PreserveHeight = preserveHeight;
                ShowCaption = showCaption;
            }
        }
        public class DClosingButtonOption
        {
            public int ButtonID;
            public string Text;
            public int Width;
            public bool IsPrimary;
            public DClosingButtonOption(int buttonID, string text, bool isPrimary, int width)
            {
                ButtonID = buttonID;
                Text = text;
                IsPrimary = isPrimary;
                Width = width;
            }
        }
        public class DResult
        {
            public List<Control> ResultingControls = new List<Control>();
            public int ClosingButtonOptionIDPressed;
        }
        private static void ClosingButtonOption_Click(object sender, EventArgs e)
        {
            Button s = (Button)sender;
            int id = (int)s.Tag;
            result.ClosingButtonOptionIDPressed = id;
            dialog.Close();
        }
        public static DResult BuildAndShowDialog(string WindowTitle, List<DControl> Controls, List<DClosingButtonOption> ClosingButtonOptions, int Width, int Margin)
        {
            return realBuildAndShowDialog("", WindowTitle, Controls, ClosingButtonOptions, Width, Margin, false);
        }
        public static DResult BuildAndShowDialog(string DialogCaption, string WindowTitle, List<DControl> Controls, List<DClosingButtonOption> ClosingButtonOptions, int Width, int Margin)
        {
            return realBuildAndShowDialog(DialogCaption, WindowTitle, Controls, ClosingButtonOptions, Width, Margin, true);
        }
        private static DResult realBuildAndShowDialog(string DialogCaption, string WindowTitle, List<DControl> Controls, List<DClosingButtonOption> ClosingButtonOptions, int Width, int Margin, bool UseDialogCaption)
        {
            dialog = new Form()
            {
                Text = WindowTitle,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                ShowIcon = false,
                StartPosition = FormStartPosition.CenterParent,
                ClientSize = new Size(Width, 20),
                MaximizeBox = false,
                MinimizeBox = false
            };
            int startX = Margin;
            int controlWidth = Width - Margin * 2;
            int currentY = Margin;
            if (UseDialogCaption)
            {
                Label dialogCaption = new Label();
                dialogCaption.AutoSize = true;
                dialogCaption.MaximumSize = new Size(controlWidth, 0);
                dialogCaption.Location = new Point(startX - 4, currentY);
                dialogCaption.Font = new Font("Segoe UI Light", 12F);
                dialogCaption.Text = DialogCaption;
                dialog.Controls.Add(dialogCaption);
                currentY = currentY + dialogCaption.Height + Margin;
            }
            result = new DResult();
            result.ClosingButtonOptionIDPressed = -1;
            foreach (DControl c in Controls)
            {
                if (c.ShowCaption)
                {
                    Label controlCaption = new Label();
                    controlCaption.AutoSize = true;
                    controlCaption.MaximumSize = new Size(controlWidth, 0);
                    controlCaption.Location = new Point(startX - 4, currentY);
                    controlCaption.Font = new Font("Segoe UI Light", 12F);
                    controlCaption.Text = c.Caption;
                    dialog.Controls.Add(controlCaption);
                    currentY = currentY + controlCaption.Height + (Margin / 2);
                }
                c.Control.AutoSize = false;
                int oWidth = c.Control.Size.Width;
                int oHeight = c.Control.Size.Height;
                c.Control.Size = new Size(controlWidth, 29);
                if (c.PreserveWidth)
                {
                    c.Control.Size = new Size(oWidth, 29);
                }
                if (c.PreserveHeight)
                {
                    c.Control.Size = new Size(c.Control.Size.Width, oHeight);
                }
                c.Control.Location = new Point(startX, currentY);
                c.Control.Font = new Font("Segoe UI Light", 12F);
                dialog.Controls.Add(c.Control);
                result.ResultingControls.Add(c.Control);
                currentY = currentY + c.Control.Size.Height + Margin;
            }
            int currentX = Width - Margin;
            foreach (DClosingButtonOption c in ClosingButtonOptions)
            {
                Button closingButton = new Button();
                closingButton.FlatStyle = FlatStyle.Flat;
                closingButton.Location = new Point(currentX - c.Width, currentY);
                closingButton.Size = new Size(c.Width, 29);
                closingButton.Font = new Font("Segoe UI Light", 12F);
                closingButton.Text = c.Text;
                closingButton.Tag = c.ButtonID;
                closingButton.Click += ClosingButtonOption_Click;
                if (c.IsPrimary)
                {
                    closingButton.BackColor = Color.DodgerBlue;
                    closingButton.FlatAppearance.BorderSize = 0;
                    closingButton.ForeColor = SystemColors.ControlLightLight;
                }
                else
                {
                    closingButton.BackColor = SystemColors.ControlLightLight;
                    closingButton.FlatAppearance.BorderSize = 1;
                    closingButton.ForeColor = SystemColors.ControlDark;
                }
                dialog.Controls.Add(closingButton);
                currentX = currentX - c.Width - Margin;
            }
            currentY = currentY + 29 + Margin;
            dialog.ClientSize = new Size(Width, currentY);
            dialog.ShowDialog();
            return result;
        }
    }
}
