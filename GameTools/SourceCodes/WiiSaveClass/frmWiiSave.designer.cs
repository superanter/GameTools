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
            this.txtOpenSave.Location = new System.Drawing.Point(80, 16);
            this.txtOpenSave.Name = "txtOpenSave";
            this.txtOpenSave.ReadOnly = true;
            this.txtOpenSave.Size = new System.Drawing.Size(382, 21);
            this.txtOpenSave.TabIndex = 0;
            // 
            // btnOpenSave
            // 
            this.btnOpenSave.Location = new System.Drawing.Point(353, 144);
            this.btnOpenSave.Name = "btnOpenSave";
            this.btnOpenSave.Size = new System.Drawing.Size(54, 23);
            this.btnOpenSave.TabIndex = 1;
            this.btnOpenSave.Text = "打开";
            this.btnOpenSave.UseVisualStyleBackColor = true;
            this.btnOpenSave.Click += new System.EventHandler(this.btnOpenSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(413, 144);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(49, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "返回";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(8, 51);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 12);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "游戏名称";
            // 
            // lblString
            // 
            this.lblString.AutoSize = true;
            this.lblString.Location = new System.Drawing.Point(8, 83);
            this.lblString.Name = "lblString";
            this.lblString.Size = new System.Drawing.Size(65, 12);
            this.lblString.TabIndex = 4;
            this.lblString.Text = "标志字符串";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(152, 83);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(29, 12);
            this.lblType.TabIndex = 5;
            this.lblType.Text = "类型";
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(373, 51);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(29, 12);
            this.lblLanguage.TabIndex = 6;
            this.lblLanguage.Text = "版本";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(80, 45);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(274, 21);
            this.txtName.TabIndex = 7;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(184, 80);
            this.txtType.Name = "txtType";
            this.txtType.ReadOnly = true;
            this.txtType.Size = new System.Drawing.Size(162, 21);
            this.txtType.TabIndex = 8;
            // 
            // txtString
            // 
            this.txtString.Location = new System.Drawing.Point(88, 80);
            this.txtString.Name = "txtString";
            this.txtString.ReadOnly = true;
            this.txtString.Size = new System.Drawing.Size(58, 21);
            this.txtString.TabIndex = 9;
            // 
            // txtLanguage
            // 
            this.txtLanguage.Location = new System.Drawing.Point(408, 48);
            this.txtLanguage.Name = "txtLanguage";
            this.txtLanguage.ReadOnly = true;
            this.txtLanguage.Size = new System.Drawing.Size(54, 21);
            this.txtLanguage.TabIndex = 10;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(8, 19);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(53, 12);
            this.lblFile.TabIndex = 11;
            this.lblFile.Text = "存档文件";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(352, 83);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(53, 12);
            this.lblSize.TabIndex = 12;
            this.lblSize.Text = "存档格数";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(416, 80);
            this.txtSize.Name = "txtSize";
            this.txtSize.ReadOnly = true;
            this.txtSize.Size = new System.Drawing.Size(46, 21);
            this.txtSize.TabIndex = 13;
            // 
            // lblWeizhi
            // 
            this.lblWeizhi.AutoSize = true;
            this.lblWeizhi.Location = new System.Drawing.Point(8, 115);
            this.lblWeizhi.Name = "lblWeizhi";
            this.lblWeizhi.Size = new System.Drawing.Size(101, 12);
            this.lblWeizhi.TabIndex = 14;
            this.lblWeizhi.Text = "标识字符串偏移量";
            // 
            // txtWeizhi
            // 
            this.txtWeizhi.Location = new System.Drawing.Point(128, 112);
            this.txtWeizhi.Name = "txtWeizhi";
            this.txtWeizhi.ReadOnly = true;
            this.txtWeizhi.Size = new System.Drawing.Size(100, 21);
            this.txtWeizhi.TabIndex = 15;
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(249, 115);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(89, 12);
            this.lblTest.TabIndex = 16;
            this.lblTest.Text = "是否为标准存档";
            // 
            // txtTest
            // 
            this.txtTest.Location = new System.Drawing.Point(344, 112);
            this.txtTest.Name = "txtTest";
            this.txtTest.ReadOnly = true;
            this.txtTest.Size = new System.Drawing.Size(118, 21);
            this.txtTest.TabIndex = 17;
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(96, 144);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.ReadOnly = true;
            this.txtFolder.Size = new System.Drawing.Size(250, 21);
            this.txtFolder.TabIndex = 18;
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(8, 149);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(65, 12);
            this.lblFolder.TabIndex = 19;
            this.lblFolder.Text = "存档全路径";
            // 
            // frmWiiSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 178);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWiiSave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WII存档信息提取(V1.1)";
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