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
            this.btnExit = new System.Windows.Forms.Button();
            this.lblDsSave = new System.Windows.Forms.Label();
            this.lblWiiSave = new System.Windows.Forms.Label();
            this.lblDsRom = new System.Windows.Forms.Label();
            this.btnDsRom = new System.Windows.Forms.Button();
            this.btnJoyCon = new System.Windows.Forms.Button();
            this.lblOtherTools = new System.Windows.Forms.Label();
            this.btnOther = new System.Windows.Forms.Button();
            this.btnAmiibo = new System.Windows.Forms.Button();
            this.lblAmiibo = new System.Windows.Forms.Label();
            this.lblJoyCon = new System.Windows.Forms.Label();
            this.cboLanguage = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnWiiSave
            // 
            this.btnWiiSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.btnWiiSave, "btnWiiSave");
            this.btnWiiSave.ForeColor = System.Drawing.Color.Black;
            this.btnWiiSave.Name = "btnWiiSave";
            this.btnWiiSave.UseVisualStyleBackColor = false;
            this.btnWiiSave.Click += new System.EventHandler(this.btnWiiSave_Click);
            // 
            // btnAbout
            // 
            resources.ApplyResources(this.btnAbout, "btnAbout");
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnDsSave
            // 
            this.btnDsSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.btnDsSave, "btnDsSave");
            this.btnDsSave.ForeColor = System.Drawing.Color.Black;
            this.btnDsSave.Name = "btnDsSave";
            this.btnDsSave.UseVisualStyleBackColor = false;
            this.btnDsSave.Click += new System.EventHandler(this.btnDsSave_Click);
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblDsSave
            // 
            resources.ApplyResources(this.lblDsSave, "lblDsSave");
            this.lblDsSave.Name = "lblDsSave";
            // 
            // lblWiiSave
            // 
            resources.ApplyResources(this.lblWiiSave, "lblWiiSave");
            this.lblWiiSave.Name = "lblWiiSave";
            // 
            // lblDsRom
            // 
            resources.ApplyResources(this.lblDsRom, "lblDsRom");
            this.lblDsRom.Name = "lblDsRom";
            // 
            // btnDsRom
            // 
            this.btnDsRom.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.btnDsRom, "btnDsRom");
            this.btnDsRom.ForeColor = System.Drawing.Color.Black;
            this.btnDsRom.Name = "btnDsRom";
            this.btnDsRom.UseVisualStyleBackColor = false;
            this.btnDsRom.Click += new System.EventHandler(this.btnDsRom_Click);
            // 
            // btnJoyCon
            // 
            this.btnJoyCon.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.btnJoyCon, "btnJoyCon");
            this.btnJoyCon.ForeColor = System.Drawing.Color.Black;
            this.btnJoyCon.Name = "btnJoyCon";
            this.btnJoyCon.UseVisualStyleBackColor = false;
            this.btnJoyCon.Click += new System.EventHandler(this.btnJoyCon_Click);
            // 
            // lblOtherTools
            // 
            resources.ApplyResources(this.lblOtherTools, "lblOtherTools");
            this.lblOtherTools.Name = "lblOtherTools";
            // 
            // btnOther
            // 
            this.btnOther.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.btnOther, "btnOther");
            this.btnOther.ForeColor = System.Drawing.Color.Black;
            this.btnOther.Name = "btnOther";
            this.btnOther.UseVisualStyleBackColor = false;
            this.btnOther.Click += new System.EventHandler(this.btnOther_Click);
            // 
            // btnAmiibo
            // 
            this.btnAmiibo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.btnAmiibo, "btnAmiibo");
            this.btnAmiibo.ForeColor = System.Drawing.Color.Black;
            this.btnAmiibo.Name = "btnAmiibo";
            this.btnAmiibo.UseVisualStyleBackColor = false;
            this.btnAmiibo.Click += new System.EventHandler(this.btnAmiibo_Click);
            // 
            // lblAmiibo
            // 
            resources.ApplyResources(this.lblAmiibo, "lblAmiibo");
            this.lblAmiibo.Name = "lblAmiibo";
            // 
            // lblJoyCon
            // 
            resources.ApplyResources(this.lblJoyCon, "lblJoyCon");
            this.lblJoyCon.Name = "lblJoyCon";
            // 
            // cboLanguage
            // 
            this.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboLanguage, "cboLanguage");
            this.cboLanguage.FormattingEnabled = true;
            this.cboLanguage.Items.AddRange(new object[] {
            resources.GetString("cboLanguage.Items"),
            resources.GetString("cboLanguage.Items1")});
            this.cboLanguage.Name = "cboLanguage";
            this.cboLanguage.SelectedIndexChanged += new System.EventHandler(this.cboLanguage_SelectedIndexChanged);
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboLanguage);
            this.Controls.Add(this.lblJoyCon);
            this.Controls.Add(this.lblOtherTools);
            this.Controls.Add(this.btnJoyCon);
            this.Controls.Add(this.btnOther);
            this.Controls.Add(this.lblDsRom);
            this.Controls.Add(this.lblAmiibo);
            this.Controls.Add(this.btnAmiibo);
            this.Controls.Add(this.btnDsRom);
            this.Controls.Add(this.btnDsSave);
            this.Controls.Add(this.lblWiiSave);
            this.Controls.Add(this.btnWiiSave);
            this.Controls.Add(this.lblDsSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWiiSave;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnDsSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblDsSave;
        private System.Windows.Forms.Label lblWiiSave;
        private System.Windows.Forms.Label lblDsRom;
        private System.Windows.Forms.Button btnDsRom;
        private System.Windows.Forms.Button btnAmiibo;
        private System.Windows.Forms.Label lblAmiibo;
        private System.Windows.Forms.Button btnOther;
        private System.Windows.Forms.Label lblOtherTools;
        private System.Windows.Forms.Button btnJoyCon;
        private System.Windows.Forms.Label lblJoyCon;
        private System.Windows.Forms.ComboBox cboLanguage;
    }
}

