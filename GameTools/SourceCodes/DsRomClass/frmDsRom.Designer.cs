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
            this.btnBack.Location = new System.Drawing.Point(257, 139);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 25);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "返回";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(171, 139);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 25);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "打开";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(23, 28);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(59, 12);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Rom文件名";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(89, 24);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(243, 21);
            this.txtName.TabIndex = 3;
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(285, 100);
            this.txtSize.Name = "txtSize";
            this.txtSize.ReadOnly = true;
            this.txtSize.Size = new System.Drawing.Size(47, 21);
            this.txtSize.TabIndex = 5;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(224, 103);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(47, 12);
            this.lblSize.TabIndex = 4;
            this.lblSize.Text = "Rom体积";
            // 
            // txtGameName
            // 
            this.txtGameName.Location = new System.Drawing.Point(89, 63);
            this.txtGameName.Name = "txtGameName";
            this.txtGameName.ReadOnly = true;
            this.txtGameName.Size = new System.Drawing.Size(89, 21);
            this.txtGameName.TabIndex = 7;
            // 
            // lblGameName
            // 
            this.lblGameName.AutoSize = true;
            this.lblGameName.Location = new System.Drawing.Point(6, 66);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(77, 12);
            this.lblGameName.TabIndex = 6;
            this.lblGameName.Text = "游戏名称标识";
            // 
            // txtGameText
            // 
            this.txtGameText.Location = new System.Drawing.Point(277, 63);
            this.txtGameText.Name = "txtGameText";
            this.txtGameText.ReadOnly = true;
            this.txtGameText.Size = new System.Drawing.Size(55, 21);
            this.txtGameText.TabIndex = 9;
            // 
            // lblGameText
            // 
            this.lblGameText.AutoSize = true;
            this.lblGameText.Location = new System.Drawing.Point(206, 66);
            this.lblGameText.Name = "lblGameText";
            this.lblGameText.Size = new System.Drawing.Size(65, 12);
            this.lblGameText.TabIndex = 8;
            this.lblGameText.Text = "游戏识别码";
            // 
            // txtGameType
            // 
            this.txtGameType.Location = new System.Drawing.Point(89, 100);
            this.txtGameType.Name = "txtGameType";
            this.txtGameType.ReadOnly = true;
            this.txtGameType.Size = new System.Drawing.Size(47, 21);
            this.txtGameType.TabIndex = 11;
            // 
            // lblGameType
            // 
            this.lblGameType.AutoSize = true;
            this.lblGameType.Location = new System.Drawing.Point(23, 103);
            this.lblGameType.Name = "lblGameType";
            this.lblGameType.Size = new System.Drawing.Size(53, 12);
            this.lblGameType.TabIndex = 10;
            this.lblGameType.Text = "游戏类型";
            // 
            // frmDsRom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 184);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DS Rom Tools";
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