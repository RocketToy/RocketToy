namespace RocketToy1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PosX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PosY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PosZ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VelX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VelY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VelZ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.PosXVal = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.PosYVal = new System.Windows.Forms.NumericUpDown();
            this.PosZVal = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.VelXVal = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.VelYVal = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.VelZVal = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listViewContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.markTypeAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goAwayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editThresholdsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.positionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.velocityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.yToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.zToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PosXVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosYVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosZVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VelXVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VelYVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VelZVal)).BeginInit();
            this.listViewContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Type,
            this.PosX,
            this.PosY,
            this.PosZ,
            this.VelX,
            this.VelY,
            this.VelZ});
            this.listView1.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 98);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(678, 289);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 190;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 100;
            // 
            // PosX
            // 
            this.PosX.Text = "Position X";
            // 
            // PosY
            // 
            this.PosY.Text = "PositionY";
            // 
            // PosZ
            // 
            this.PosZ.Text = "Position Z";
            // 
            // VelX
            // 
            this.VelX.Text = "Velocity X";
            // 
            // VelY
            // 
            this.VelY.Text = "Velocity Y";
            // 
            // VelZ
            // 
            this.VelZ.Text = "Velocity Z";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI Light", 8.25F);
            this.linkLabel1.LinkColor = System.Drawing.Color.DodgerBlue;
            this.linkLabel1.Location = new System.Drawing.Point(629, 449);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(65, 13);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Fully Refresh";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Position X";
            // 
            // PosXVal
            // 
            this.PosXVal.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PosXVal.Location = new System.Drawing.Point(12, 414);
            this.PosXVal.Name = "PosXVal";
            this.PosXVal.Size = new System.Drawing.Size(108, 29);
            this.PosXVal.TabIndex = 4;
            this.PosXVal.ValueChanged += new System.EventHandler(this.PosXVal_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(122, 390);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Position Y";
            // 
            // PosYVal
            // 
            this.PosYVal.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PosYVal.Location = new System.Drawing.Point(126, 414);
            this.PosYVal.Name = "PosYVal";
            this.PosYVal.Size = new System.Drawing.Size(108, 29);
            this.PosYVal.TabIndex = 6;
            this.PosYVal.ValueChanged += new System.EventHandler(this.PosYVal_ValueChanged);
            // 
            // PosZVal
            // 
            this.PosZVal.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PosZVal.Location = new System.Drawing.Point(240, 414);
            this.PosZVal.Name = "PosZVal";
            this.PosZVal.Size = new System.Drawing.Size(108, 29);
            this.PosZVal.TabIndex = 7;
            this.PosZVal.ValueChanged += new System.EventHandler(this.PosZVal_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(236, 390);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Position Z";
            // 
            // VelXVal
            // 
            this.VelXVal.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VelXVal.Location = new System.Drawing.Point(354, 414);
            this.VelXVal.Name = "VelXVal";
            this.VelXVal.Size = new System.Drawing.Size(108, 29);
            this.VelXVal.TabIndex = 9;
            this.VelXVal.ValueChanged += new System.EventHandler(this.VelXVal_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(350, 390);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "Velocity X";
            // 
            // VelYVal
            // 
            this.VelYVal.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VelYVal.Location = new System.Drawing.Point(468, 414);
            this.VelYVal.Name = "VelYVal";
            this.VelYVal.Size = new System.Drawing.Size(108, 29);
            this.VelYVal.TabIndex = 11;
            this.VelYVal.ValueChanged += new System.EventHandler(this.VelYVal_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(464, 390);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 21);
            this.label6.TabIndex = 12;
            this.label6.Text = "Velocity Y";
            // 
            // VelZVal
            // 
            this.VelZVal.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VelZVal.Location = new System.Drawing.Point(582, 414);
            this.VelZVal.Name = "VelZVal";
            this.VelZVal.Size = new System.Drawing.Size(108, 29);
            this.VelZVal.TabIndex = 13;
            this.VelZVal.ValueChanged += new System.EventHandler(this.VelZVal_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(578, 390);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 21);
            this.label7.TabIndex = 14;
            this.label7.Text = "Velocity Z";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(12, 449);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(128, 17);
            this.checkBox1.TabIndex = 40;
            this.checkBox1.Text = "Hide Unknown Entities";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // listViewContext
            // 
            this.listViewContext.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.markTypeAsToolStripMenuItem,
            this.goAwayToolStripMenuItem,
            this.editThresholdsToolStripMenuItem});
            this.listViewContext.Name = "listViewContext";
            this.listViewContext.Size = new System.Drawing.Size(151, 70);
            // 
            // markTypeAsToolStripMenuItem
            // 
            this.markTypeAsToolStripMenuItem.Name = "markTypeAsToolStripMenuItem";
            this.markTypeAsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.markTypeAsToolStripMenuItem.Text = "Mark Type as...";
            this.markTypeAsToolStripMenuItem.Click += new System.EventHandler(this.markTypeAsToolStripMenuItem_Click);
            // 
            // goAwayToolStripMenuItem
            // 
            this.goAwayToolStripMenuItem.Name = "goAwayToolStripMenuItem";
            this.goAwayToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.goAwayToolStripMenuItem.Text = "Go Away";
            this.goAwayToolStripMenuItem.Click += new System.EventHandler(this.goAwayToolStripMenuItem_Click);
            // 
            // editThresholdsToolStripMenuItem
            // 
            this.editThresholdsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.positionToolStripMenuItem,
            this.velocityToolStripMenuItem});
            this.editThresholdsToolStripMenuItem.Name = "editThresholdsToolStripMenuItem";
            this.editThresholdsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.editThresholdsToolStripMenuItem.Text = "Edit Thresholds";
            // 
            // positionToolStripMenuItem
            // 
            this.positionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem,
            this.yToolStripMenuItem,
            this.zToolStripMenuItem});
            this.positionToolStripMenuItem.Name = "positionToolStripMenuItem";
            this.positionToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.positionToolStripMenuItem.Text = "Position";
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(81, 22);
            this.xToolStripMenuItem.Text = "X";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.xToolStripMenuItem_Click);
            // 
            // yToolStripMenuItem
            // 
            this.yToolStripMenuItem.Name = "yToolStripMenuItem";
            this.yToolStripMenuItem.Size = new System.Drawing.Size(81, 22);
            this.yToolStripMenuItem.Text = "Y";
            this.yToolStripMenuItem.Click += new System.EventHandler(this.yToolStripMenuItem_Click);
            // 
            // zToolStripMenuItem
            // 
            this.zToolStripMenuItem.Name = "zToolStripMenuItem";
            this.zToolStripMenuItem.Size = new System.Drawing.Size(81, 22);
            this.zToolStripMenuItem.Text = "Z";
            this.zToolStripMenuItem.Click += new System.EventHandler(this.zToolStripMenuItem_Click);
            // 
            // velocityToolStripMenuItem
            // 
            this.velocityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem1,
            this.yToolStripMenuItem1,
            this.zToolStripMenuItem1});
            this.velocityToolStripMenuItem.Name = "velocityToolStripMenuItem";
            this.velocityToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.velocityToolStripMenuItem.Text = "Velocity";
            // 
            // xToolStripMenuItem1
            // 
            this.xToolStripMenuItem1.Name = "xToolStripMenuItem1";
            this.xToolStripMenuItem1.Size = new System.Drawing.Size(81, 22);
            this.xToolStripMenuItem1.Text = "X";
            this.xToolStripMenuItem1.Click += new System.EventHandler(this.xToolStripMenuItem1_Click);
            // 
            // yToolStripMenuItem1
            // 
            this.yToolStripMenuItem1.Name = "yToolStripMenuItem1";
            this.yToolStripMenuItem1.Size = new System.Drawing.Size(81, 22);
            this.yToolStripMenuItem1.Text = "Y";
            this.yToolStripMenuItem1.Click += new System.EventHandler(this.yToolStripMenuItem1_Click);
            // 
            // zToolStripMenuItem1
            // 
            this.zToolStripMenuItem1.Name = "zToolStripMenuItem1";
            this.zToolStripMenuItem1.Size = new System.Drawing.Size(81, 22);
            this.zToolStripMenuItem1.Text = "Z";
            this.zToolStripMenuItem1.Click += new System.EventHandler(this.zToolStripMenuItem1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(173, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(364, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(701, 472);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.VelZVal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.VelYVal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.VelXVal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PosZVal);
            this.Controls.Add(this.PosYVal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PosXVal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RocketToy 1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.PosXVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosYVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosZVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VelXVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VelYVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VelZVal)).EndInit();
            this.listViewContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader PosX;
        private System.Windows.Forms.ColumnHeader PosY;
        private System.Windows.Forms.ColumnHeader PosZ;
        private System.Windows.Forms.ColumnHeader VelX;
        private System.Windows.Forms.ColumnHeader VelY;
        private System.Windows.Forms.ColumnHeader VelZ;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown PosXVal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown PosYVal;
        private System.Windows.Forms.NumericUpDown PosZVal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown VelXVal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown VelYVal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown VelZVal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ContextMenuStrip listViewContext;
        private System.Windows.Forms.ToolStripMenuItem markTypeAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goAwayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editThresholdsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem positionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem velocityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem yToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem zToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

