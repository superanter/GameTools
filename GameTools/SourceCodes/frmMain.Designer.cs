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
            this.lblDsRom = new System.Windows.Forms.Label();
            this.btnDsRom = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnJoyCon = new System.Windows.Forms.Button();
            this.lblOtherTools = new System.Windows.Forms.Label();
            this.btnOther = new System.Windows.Forms.Button();
            this.btnAmiibo = new System.Windows.Forms.Button();
            this.lblAmiibo = new System.Windows.Forms.Label();
            this.lblMame = new System.Windows.Forms.Label();
            this.btnMAME = new System.Windows.Forms.Button();
            this.lblJoyCon = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnWiiSave
            // 
            this.btnWiiSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnWiiSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWiiSave.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWiiSave.ForeColor = System.Drawing.Color.Black;
            this.btnWiiSave.Location = new System.Drawing.Point(201, 35);
            this.btnWiiSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnWiiSave.Name = "btnWiiSave";
            this.btnWiiSave.Size = new System.Drawing.Size(130, 75);
            this.btnWiiSave.TabIndex = 2;
            this.btnWiiSave.Text = "Wii Save";
            this.btnWiiSave.UseVisualStyleBackColor = false;
            this.btnWiiSave.Click += new System.EventHandler(this.btnWiiSave_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(414, 284);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(112, 38);
            this.btnAbout.TabIndex = 9;
            this.btnAbout.Text = "关于";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnDsSave
            // 
            this.btnDsSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDsSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDsSave.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDsSave.ForeColor = System.Drawing.Color.Black;
            this.btnDsSave.Location = new System.Drawing.Point(39, 35);
            this.btnDsSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnDsSave.Name = "btnDsSave";
            this.btnDsSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDsSave.Size = new System.Drawing.Size(130, 75);
            this.btnDsSave.TabIndex = 1;
            this.btnDsSave.Text = "DS Save";
            this.btnDsSave.UseVisualStyleBackColor = false;
            this.btnDsSave.Click += new System.EventHandler(this.btnDsSave_Click);
            // 
            // btnSwitchSave
            // 
            this.btnSwitchSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSwitchSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitchSave.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSwitchSave.ForeColor = System.Drawing.Color.Black;
            this.btnSwitchSave.Location = new System.Drawing.Point(369, 35);
            this.btnSwitchSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSwitchSave.Name = "btnSwitchSave";
            this.btnSwitchSave.Size = new System.Drawing.Size(130, 75);
            this.btnSwitchSave.TabIndex = 3;
            this.btnSwitchSave.Text = "NS Save";
            this.btnSwitchSave.UseVisualStyleBackColor = false;
            this.btnSwitchSave.Click += new System.EventHandler(this.btnSwitchSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(557, 284);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 38);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblDsSave
            // 
            this.lblDsSave.Location = new System.Drawing.Point(39, 114);
            this.lblDsSave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDsSave.Name = "lblDsSave";
            this.lblDsSave.Size = new System.Drawing.Size(130, 18);
            this.lblDsSave.TabIndex = 6;
            this.lblDsSave.Text = "yyyy-mm-dd";
            this.lblDsSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWiiSave
            // 
            this.lblWiiSave.Location = new System.Drawing.Point(201, 114);
            this.lblWiiSave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWiiSave.Name = "lblWiiSave";
            this.lblWiiSave.Size = new System.Drawing.Size(130, 18);
            this.lblWiiSave.TabIndex = 7;
            this.lblWiiSave.Text = "yyyy-mm-dd";
            this.lblWiiSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSwitchSave
            // 
            this.lblSwitchSave.Location = new System.Drawing.Point(369, 114);
            this.lblSwitchSave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSwitchSave.Name = "lblSwitchSave";
            this.lblSwitchSave.Size = new System.Drawing.Size(130, 18);
            this.lblSwitchSave.TabIndex = 8;
            this.lblSwitchSave.Text = "yyyy-mm-dd";
            this.lblSwitchSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDsRom
            // 
            this.lblDsRom.Location = new System.Drawing.Point(539, 114);
            this.lblDsRom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDsRom.Name = "lblDsRom";
            this.lblDsRom.Size = new System.Drawing.Size(130, 18);
            this.lblDsRom.TabIndex = 9;
            this.lblDsRom.Text = "yyyy-mm-dd";
            this.lblDsRom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDsRom
            // 
            this.btnDsRom.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDsRom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDsRom.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDsRom.ForeColor = System.Drawing.Color.Black;
            this.btnDsRom.Location = new System.Drawing.Point(539, 35);
            this.btnDsRom.Margin = new System.Windows.Forms.Padding(4);
            this.btnDsRom.Name = "btnDsRom";
            this.btnDsRom.Size = new System.Drawing.Size(130, 75);
            this.btnDsRom.TabIndex = 4;
            this.btnDsRom.Text = "DS Rom";
            this.btnDsRom.UseVisualStyleBackColor = false;
            this.btnDsRom.Click += new System.EventHandler(this.btnDsRom_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 342);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(711, 31);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(195, 24);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // btnJoyCon
            // 
            this.btnJoyCon.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnJoyCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJoyCon.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJoyCon.ForeColor = System.Drawing.Color.Black;
            this.btnJoyCon.Location = new System.Drawing.Point(369, 165);
            this.btnJoyCon.Margin = new System.Windows.Forms.Padding(4);
            this.btnJoyCon.Name = "btnJoyCon";
            this.btnJoyCon.Size = new System.Drawing.Size(130, 75);
            this.btnJoyCon.TabIndex = 7;
            this.btnJoyCon.Text = "JoyCon";
            this.btnJoyCon.UseVisualStyleBackColor = false;
            this.btnJoyCon.Click += new System.EventHandler(this.btnJoyCon_Click);
            // 
            // lblOtherTools
            // 
            this.lblOtherTools.Location = new System.Drawing.Point(536, 244);
            this.lblOtherTools.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOtherTools.Name = "lblOtherTools";
            this.lblOtherTools.Size = new System.Drawing.Size(130, 18);
            this.lblOtherTools.TabIndex = 12;
            this.lblOtherTools.Text = "yyyy-mm-dd";
            this.lblOtherTools.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOther
            // 
            this.btnOther.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnOther.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOther.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOther.ForeColor = System.Drawing.Color.Black;
            this.btnOther.Location = new System.Drawing.Point(539, 165);
            this.btnOther.Margin = new System.Windows.Forms.Padding(4);
            this.btnOther.Name = "btnOther";
            this.btnOther.Size = new System.Drawing.Size(130, 75);
            this.btnOther.TabIndex = 8;
            this.btnOther.Text = "Other";
            this.btnOther.UseVisualStyleBackColor = false;
            this.btnOther.Click += new System.EventHandler(this.btnOther_Click);
            // 
            // btnAmiibo
            // 
            this.btnAmiibo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAmiibo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAmiibo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAmiibo.ForeColor = System.Drawing.Color.Black;
            this.btnAmiibo.Location = new System.Drawing.Point(201, 165);
            this.btnAmiibo.Margin = new System.Windows.Forms.Padding(4);
            this.btnAmiibo.Name = "btnAmiibo";
            this.btnAmiibo.Size = new System.Drawing.Size(130, 75);
            this.btnAmiibo.TabIndex = 6;
            this.btnAmiibo.Text = "Amiibo";
            this.btnAmiibo.UseVisualStyleBackColor = false;
            this.btnAmiibo.Click += new System.EventHandler(this.btnAmiibo_Click);
            // 
            // lblAmiibo
            // 
            this.lblAmiibo.Location = new System.Drawing.Point(201, 244);
            this.lblAmiibo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAmiibo.Name = "lblAmiibo";
            this.lblAmiibo.Size = new System.Drawing.Size(130, 18);
            this.lblAmiibo.TabIndex = 9;
            this.lblAmiibo.Text = "yyyy-mm-dd";
            this.lblAmiibo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMame
            // 
            this.lblMame.Location = new System.Drawing.Point(39, 244);
            this.lblMame.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMame.Name = "lblMame";
            this.lblMame.Size = new System.Drawing.Size(130, 18);
            this.lblMame.TabIndex = 9;
            this.lblMame.Text = "yyyy-mm-dd";
            this.lblMame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMAME
            // 
            this.btnMAME.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMAME.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMAME.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMAME.ForeColor = System.Drawing.Color.Black;
            this.btnMAME.Location = new System.Drawing.Point(36, 165);
            this.btnMAME.Margin = new System.Windows.Forms.Padding(4);
            this.btnMAME.Name = "btnMAME";
            this.btnMAME.Size = new System.Drawing.Size(130, 75);
            this.btnMAME.TabIndex = 5;
            this.btnMAME.Text = "MAME";
            this.btnMAME.UseVisualStyleBackColor = false;
            this.btnMAME.Click += new System.EventHandler(this.btnMAME_Click);
            // 
            // lblJoyCon
            // 
            this.lblJoyCon.Location = new System.Drawing.Point(369, 244);
            this.lblJoyCon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJoyCon.Name = "lblJoyCon";
            this.lblJoyCon.Size = new System.Drawing.Size(130, 18);
            this.lblJoyCon.TabIndex = 14;
            this.lblJoyCon.Text = "yyyy-mm-dd";
            this.lblJoyCon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 373);
            this.Controls.Add(this.lblJoyCon);
            this.Controls.Add(this.lblOtherTools);
            this.Controls.Add(this.btnJoyCon);
            this.Controls.Add(this.btnOther);
            this.Controls.Add(this.lblMame);
            this.Controls.Add(this.btnMAME);
            this.Controls.Add(this.lblDsRom);
            this.Controls.Add(this.lblAmiibo);
            this.Controls.Add(this.btnAmiibo);
            this.Controls.Add(this.lblSwitchSave);
            this.Controls.Add(this.btnDsRom);
            this.Controls.Add(this.btnDsSave);
            this.Controls.Add(this.btnSwitchSave);
            this.Controls.Add(this.lblWiiSave);
            this.Controls.Add(this.btnWiiSave);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblDsSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anter\'s Game Tools";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.Label lblDsRom;
        private System.Windows.Forms.Button btnDsRom;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnAmiibo;
        private System.Windows.Forms.Label lblAmiibo;
        private System.Windows.Forms.Button btnOther;
        private System.Windows.Forms.Label lblOtherTools;
        private System.Windows.Forms.Button btnJoyCon;
        private System.Windows.Forms.Label lblMame;
        private System.Windows.Forms.Button btnMAME;
        private System.Windows.Forms.Label lblJoyCon;
    }
}

