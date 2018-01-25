namespace AnterStudio.GameTools
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnWiiSave = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnDsSave = new System.Windows.Forms.Button();
            this.btnSwitchSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblDsSave = new System.Windows.Forms.Label();
            this.lblWiiSave = new System.Windows.Forms.Label();
            this.lblSwitchSave = new System.Windows.Forms.Label();
            this.grpSave = new System.Windows.Forms.GroupBox();
            this.grpRom = new System.Windows.Forms.GroupBox();
            this.lblDsRom = new System.Windows.Forms.Label();
            this.btnDsRom = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpOther = new System.Windows.Forms.GroupBox();
            this.lblOtherTools = new System.Windows.Forms.Label();
            this.btnOther = new System.Windows.Forms.Button();
            this.btnAmiibo = new System.Windows.Forms.Button();
            this.lblAmiibo = new System.Windows.Forms.Label();
            this.lblMain = new System.Windows.Forms.Label();
            this.grpSave.SuspendLayout();
            this.grpRom.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.grpOther.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnWiiSave
            // 
            this.btnWiiSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWiiSave.ForeColor = System.Drawing.Color.Red;
            this.btnWiiSave.Image = ((System.Drawing.Image)(resources.GetObject("btnWiiSave.Image")));
            this.btnWiiSave.Location = new System.Drawing.Point(127, 20);
            this.btnWiiSave.Name = "btnWiiSave";
            this.btnWiiSave.Size = new System.Drawing.Size(75, 50);
            this.btnWiiSave.TabIndex = 0;
            this.btnWiiSave.Text = "Save";
            this.btnWiiSave.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnWiiSave.UseVisualStyleBackColor = true;
            this.btnWiiSave.Click += new System.EventHandler(this.btnWiiSave_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(194, 382);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 25);
            this.btnAbout.TabIndex = 1;
            this.btnAbout.Text = "关于";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnDsSave
            // 
            this.btnDsSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDsSave.ForeColor = System.Drawing.Color.Red;
            this.btnDsSave.Image = ((System.Drawing.Image)(resources.GetObject("btnDsSave.Image")));
            this.btnDsSave.Location = new System.Drawing.Point(24, 20);
            this.btnDsSave.Name = "btnDsSave";
            this.btnDsSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDsSave.Size = new System.Drawing.Size(75, 50);
            this.btnDsSave.TabIndex = 2;
            this.btnDsSave.Text = "Save";
            this.btnDsSave.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnDsSave.UseVisualStyleBackColor = true;
            this.btnDsSave.Click += new System.EventHandler(this.btnDsSave_Click);
            // 
            // btnSwitchSave
            // 
            this.btnSwitchSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSwitchSave.ForeColor = System.Drawing.Color.Red;
            this.btnSwitchSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSwitchSave.Image")));
            this.btnSwitchSave.Location = new System.Drawing.Point(231, 20);
            this.btnSwitchSave.Name = "btnSwitchSave";
            this.btnSwitchSave.Size = new System.Drawing.Size(75, 50);
            this.btnSwitchSave.TabIndex = 3;
            this.btnSwitchSave.Text = "Save";
            this.btnSwitchSave.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSwitchSave.UseVisualStyleBackColor = true;
            this.btnSwitchSave.Click += new System.EventHandler(this.btnSwitchSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(281, 382);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblDsSave
            // 
            this.lblDsSave.AutoSize = true;
            this.lblDsSave.Location = new System.Drawing.Point(30, 73);
            this.lblDsSave.Name = "lblDsSave";
            this.lblDsSave.Size = new System.Drawing.Size(65, 12);
            this.lblDsSave.TabIndex = 6;
            this.lblDsSave.Text = "2017-02-08";
            // 
            // lblWiiSave
            // 
            this.lblWiiSave.AutoSize = true;
            this.lblWiiSave.Location = new System.Drawing.Point(133, 73);
            this.lblWiiSave.Name = "lblWiiSave";
            this.lblWiiSave.Size = new System.Drawing.Size(65, 12);
            this.lblWiiSave.TabIndex = 7;
            this.lblWiiSave.Text = "2009-04-20";
            // 
            // lblSwitchSave
            // 
            this.lblSwitchSave.AutoSize = true;
            this.lblSwitchSave.Location = new System.Drawing.Point(237, 73);
            this.lblSwitchSave.Name = "lblSwitchSave";
            this.lblSwitchSave.Size = new System.Drawing.Size(65, 12);
            this.lblSwitchSave.TabIndex = 8;
            this.lblSwitchSave.Text = "2017-01-24";
            // 
            // grpSave
            // 
            this.grpSave.Controls.Add(this.btnDsSave);
            this.grpSave.Controls.Add(this.lblSwitchSave);
            this.grpSave.Controls.Add(this.btnWiiSave);
            this.grpSave.Controls.Add(this.lblWiiSave);
            this.grpSave.Controls.Add(this.btnSwitchSave);
            this.grpSave.Controls.Add(this.lblDsSave);
            this.grpSave.Location = new System.Drawing.Point(24, 71);
            this.grpSave.Name = "grpSave";
            this.grpSave.Size = new System.Drawing.Size(326, 95);
            this.grpSave.TabIndex = 9;
            this.grpSave.TabStop = false;
            this.grpSave.Text = "Save File Tools";
            // 
            // grpRom
            // 
            this.grpRom.Controls.Add(this.lblDsRom);
            this.grpRom.Controls.Add(this.btnDsRom);
            this.grpRom.Location = new System.Drawing.Point(26, 172);
            this.grpRom.Name = "grpRom";
            this.grpRom.Size = new System.Drawing.Size(326, 95);
            this.grpRom.TabIndex = 10;
            this.grpRom.TabStop = false;
            this.grpRom.Text = "Rom File Tools";
            // 
            // lblDsRom
            // 
            this.lblDsRom.AutoSize = true;
            this.lblDsRom.Location = new System.Drawing.Point(30, 73);
            this.lblDsRom.Name = "lblDsRom";
            this.lblDsRom.Size = new System.Drawing.Size(65, 12);
            this.lblDsRom.TabIndex = 9;
            this.lblDsRom.Text = "2017-02-06";
            // 
            // btnDsRom
            // 
            this.btnDsRom.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDsRom.ForeColor = System.Drawing.Color.Red;
            this.btnDsRom.Image = ((System.Drawing.Image)(resources.GetObject("btnDsRom.Image")));
            this.btnDsRom.Location = new System.Drawing.Point(24, 20);
            this.btnDsRom.Name = "btnDsRom";
            this.btnDsRom.Size = new System.Drawing.Size(75, 50);
            this.btnDsRom.TabIndex = 9;
            this.btnDsRom.Text = "Rom";
            this.btnDsRom.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnDsRom.UseVisualStyleBackColor = true;
            this.btnDsRom.Click += new System.EventHandler(this.btnDsRom_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(376, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // grpOther
            // 
            this.grpOther.Controls.Add(this.lblOtherTools);
            this.grpOther.Controls.Add(this.btnOther);
            this.grpOther.Controls.Add(this.btnAmiibo);
            this.grpOther.Controls.Add(this.lblAmiibo);
            this.grpOther.Location = new System.Drawing.Point(26, 273);
            this.grpOther.Name = "grpOther";
            this.grpOther.Size = new System.Drawing.Size(326, 95);
            this.grpOther.TabIndex = 11;
            this.grpOther.TabStop = false;
            this.grpOther.Text = "Other File Tools";
            // 
            // lblOtherTools
            // 
            this.lblOtherTools.AutoSize = true;
            this.lblOtherTools.Location = new System.Drawing.Point(235, 73);
            this.lblOtherTools.Name = "lblOtherTools";
            this.lblOtherTools.Size = new System.Drawing.Size(65, 12);
            this.lblOtherTools.TabIndex = 12;
            this.lblOtherTools.Text = "2017-08-18";
            // 
            // btnOther
            // 
            this.btnOther.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOther.ForeColor = System.Drawing.Color.Red;
            this.btnOther.Image = global::AnterStudio.GameTools.Properties.Resources.anter32_01;
            this.btnOther.Location = new System.Drawing.Point(229, 20);
            this.btnOther.Name = "btnOther";
            this.btnOther.Size = new System.Drawing.Size(75, 50);
            this.btnOther.TabIndex = 11;
            this.btnOther.Text = "Other";
            this.btnOther.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnOther.UseVisualStyleBackColor = true;
            this.btnOther.Click += new System.EventHandler(this.btnOther_Click);
            // 
            // btnAmiibo
            // 
            this.btnAmiibo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAmiibo.ForeColor = System.Drawing.Color.Red;
            this.btnAmiibo.Image = ((System.Drawing.Image)(resources.GetObject("btnAmiibo.Image")));
            this.btnAmiibo.Location = new System.Drawing.Point(22, 20);
            this.btnAmiibo.Name = "btnAmiibo";
            this.btnAmiibo.Size = new System.Drawing.Size(75, 50);
            this.btnAmiibo.TabIndex = 10;
            this.btnAmiibo.Text = "Amiibo";
            this.btnAmiibo.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnAmiibo.UseVisualStyleBackColor = true;
            this.btnAmiibo.Click += new System.EventHandler(this.btnAmiibo_Click);
            // 
            // lblAmiibo
            // 
            this.lblAmiibo.AutoSize = true;
            this.lblAmiibo.Location = new System.Drawing.Point(30, 73);
            this.lblAmiibo.Name = "lblAmiibo";
            this.lblAmiibo.Size = new System.Drawing.Size(65, 12);
            this.lblAmiibo.TabIndex = 9;
            this.lblAmiibo.Text = "2017-08-02";
            // 
            // lblMain
            // 
            this.lblMain.Font = new System.Drawing.Font("Castellar", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.Image = ((System.Drawing.Image)(resources.GetObject("lblMain.Image")));
            this.lblMain.Location = new System.Drawing.Point(22, 9);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(330, 60);
            this.lblMain.TabIndex = 4;
            this.lblMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 446);
            this.Controls.Add(this.grpOther);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpRom);
            this.Controls.Add(this.grpSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblMain);
            this.Controls.Add(this.btnAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anter\'s Game Tools";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpSave.ResumeLayout(false);
            this.grpSave.PerformLayout();
            this.grpRom.ResumeLayout(false);
            this.grpRom.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpOther.ResumeLayout(false);
            this.grpOther.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWiiSave;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnDsSave;
        private System.Windows.Forms.Button btnSwitchSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblDsSave;
        private System.Windows.Forms.Label lblWiiSave;
        private System.Windows.Forms.Label lblSwitchSave;
        private System.Windows.Forms.GroupBox grpSave;
        private System.Windows.Forms.GroupBox grpRom;
        private System.Windows.Forms.Label lblDsRom;
        private System.Windows.Forms.Button btnDsRom;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox grpOther;
        private System.Windows.Forms.Button btnAmiibo;
        private System.Windows.Forms.Label lblAmiibo;
        private System.Windows.Forms.Label lblMain;
        private System.Windows.Forms.Button btnOther;
        private System.Windows.Forms.Label lblOtherTools;
    }
}

