namespace AnterStudio.GameTools.WiiSaveClass
{
    partial class frmWiiSave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWiiSave));
            this.dialogOpenWiiSave = new System.Windows.Forms.OpenFileDialog();
            this.txtOpenSave = new System.Windows.Forms.TextBox();
            this.btnOpenSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblString = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtString = new System.Windows.Forms.TextBox();
            this.txtLanguage = new System.Windows.Forms.TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.lblWeizhi = new System.Windows.Forms.Label();
            this.txtWeizhi = new System.Windows.Forms.TextBox();
            this.lblTest = new System.Windows.Forms.Label();
            this.txtTest = new System.Windows.Forms.TextBox();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.lblFolder = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtOpenSave
            // 
            resources.ApplyResources(this.txtOpenSave, "txtOpenSave");
            this.txtOpenSave.Name = "txtOpenSave";
            this.txtOpenSave.ReadOnly = true;
            // 
            // btnOpenSave
            // 
            resources.ApplyResources(this.btnOpenSave, "btnOpenSave");
            this.btnOpenSave.Name = "btnOpenSave";
            this.btnOpenSave.UseVisualStyleBackColor = true;
            this.btnOpenSave.Click += new System.EventHandler(this.btnOpenSave_Click);
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // lblString
            // 
            resources.ApplyResources(this.lblString, "lblString");
            this.lblString.Name = "lblString";
            // 
            // lblType
            // 
            resources.ApplyResources(this.lblType, "lblType");
            this.lblType.Name = "lblType";
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.Name = "lblLanguage";
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            // 
            // txtType
            // 
            resources.ApplyResources(this.txtType, "txtType");
            this.txtType.Name = "txtType";
            this.txtType.ReadOnly = true;
            // 
            // txtString
            // 
            resources.ApplyResources(this.txtString, "txtString");
            this.txtString.Name = "txtString";
            this.txtString.ReadOnly = true;
            // 
            // txtLanguage
            // 
            resources.ApplyResources(this.txtLanguage, "txtLanguage");
            this.txtLanguage.Name = "txtLanguage";
            this.txtLanguage.ReadOnly = true;
            // 
            // lblFile
            // 
            resources.ApplyResources(this.lblFile, "lblFile");
            this.lblFile.Name = "lblFile";
            // 
            // lblSize
            // 
            resources.ApplyResources(this.lblSize, "lblSize");
            this.lblSize.Name = "lblSize";
            // 
            // txtSize
            // 
            resources.ApplyResources(this.txtSize, "txtSize");
            this.txtSize.Name = "txtSize";
            this.txtSize.ReadOnly = true;
            // 
            // lblWeizhi
            // 
            resources.ApplyResources(this.lblWeizhi, "lblWeizhi");
            this.lblWeizhi.Name = "lblWeizhi";
            // 
            // txtWeizhi
            // 
            resources.ApplyResources(this.txtWeizhi, "txtWeizhi");
            this.txtWeizhi.Name = "txtWeizhi";
            this.txtWeizhi.ReadOnly = true;
            // 
            // lblTest
            // 
            resources.ApplyResources(this.lblTest, "lblTest");
            this.lblTest.Name = "lblTest";
            // 
            // txtTest
            // 
            resources.ApplyResources(this.txtTest, "txtTest");
            this.txtTest.Name = "txtTest";
            this.txtTest.ReadOnly = true;
            // 
            // txtFolder
            // 
            resources.ApplyResources(this.txtFolder, "txtFolder");
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.ReadOnly = true;
            // 
            // lblFolder
            // 
            resources.ApplyResources(this.lblFolder, "lblFolder");
            this.lblFolder.Name = "lblFolder";
            // 
            // frmWiiSave
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblFolder);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.txtTest);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.txtWeizhi);
            this.Controls.Add(this.lblWeizhi);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.txtLanguage);
            this.Controls.Add(this.txtString);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblString);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOpenSave);
            this.Controls.Add(this.txtOpenSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmWiiSave";
            this.Load += new System.EventHandler(this.frmWiiSave_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dialogOpenWiiSave;
        private System.Windows.Forms.TextBox txtOpenSave;
        private System.Windows.Forms.Button btnOpenSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblString;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtString;
        private System.Windows.Forms.TextBox txtLanguage;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label lblWeizhi;
        private System.Windows.Forms.TextBox txtWeizhi;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.TextBox txtTest;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label lblFolder;
    }
}