namespace AnterStudio.GameTools.DsRomClass
{
    partial class frmDsRom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDsRom));
            this.btnBack = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.openFileDialogDsRom = new System.Windows.Forms.OpenFileDialog();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.txtGameName = new System.Windows.Forms.TextBox();
            this.lblGameName = new System.Windows.Forms.Label();
            this.txtGameText = new System.Windows.Forms.TextBox();
            this.lblGameText = new System.Windows.Forms.Label();
            this.txtGameType = new System.Windows.Forms.TextBox();
            this.lblGameType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            resources.ApplyResources(this.btnBack, "btnBack");
            this.btnBack.Name = "btnBack";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnOpen
            // 
            resources.ApplyResources(this.btnOpen, "btnOpen");
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            // 
            // txtSize
            // 
            resources.ApplyResources(this.txtSize, "txtSize");
            this.txtSize.Name = "txtSize";
            this.txtSize.ReadOnly = true;
            // 
            // lblSize
            // 
            resources.ApplyResources(this.lblSize, "lblSize");
            this.lblSize.Name = "lblSize";
            // 
            // txtGameName
            // 
            resources.ApplyResources(this.txtGameName, "txtGameName");
            this.txtGameName.Name = "txtGameName";
            this.txtGameName.ReadOnly = true;
            // 
            // lblGameName
            // 
            resources.ApplyResources(this.lblGameName, "lblGameName");
            this.lblGameName.Name = "lblGameName";
            // 
            // txtGameText
            // 
            resources.ApplyResources(this.txtGameText, "txtGameText");
            this.txtGameText.Name = "txtGameText";
            this.txtGameText.ReadOnly = true;
            // 
            // lblGameText
            // 
            resources.ApplyResources(this.lblGameText, "lblGameText");
            this.lblGameText.Name = "lblGameText";
            // 
            // txtGameType
            // 
            resources.ApplyResources(this.txtGameType, "txtGameType");
            this.txtGameType.Name = "txtGameType";
            this.txtGameType.ReadOnly = true;
            // 
            // lblGameType
            // 
            resources.ApplyResources(this.lblGameType, "lblGameType");
            this.lblGameType.Name = "lblGameType";
            // 
            // frmDsRom
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtGameType);
            this.Controls.Add(this.lblGameType);
            this.Controls.Add(this.txtGameText);
            this.Controls.Add(this.lblGameText);
            this.Controls.Add(this.txtGameName);
            this.Controls.Add(this.lblGameName);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmDsRom";
            this.Load += new System.EventHandler(this.frmDsRom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.OpenFileDialog openFileDialogDsRom;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox txtGameName;
        private System.Windows.Forms.Label lblGameName;
        private System.Windows.Forms.TextBox txtGameText;
        private System.Windows.Forms.Label lblGameText;
        private System.Windows.Forms.TextBox txtGameType;
        private System.Windows.Forms.Label lblGameType;
    }
}