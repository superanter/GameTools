namespace AnterStudio.GameTools.AmiiboClass
{
    partial class frmAmiibo
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
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtNewFileName = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnTo540 = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.linkURL = new System.Windows.Forms.LinkLabel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblURL = new System.Windows.Forms.Label();
            this.btnList = new System.Windows.Forms.Button();
            this.btnRenameAll = new System.Windows.Forms.Button();
            this.btnMcasName = new System.Windows.Forms.Button();
            this.btnPicture = new System.Windows.Forms.Button();
            this.ricOut = new System.Windows.Forms.RichTextBox();
            this.lblSsbTp = new System.Windows.Forms.Label();
            this.lblMessage2 = new System.Windows.Forms.Label();
            this.lblNewUID = new System.Windows.Forms.Label();
            this.txtNewUID = new System.Windows.Forms.TextBox();
            this.btnRePack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFileName
            // 
            this.txtFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFileName.Location = new System.Drawing.Point(12, 12);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(460, 21);
            this.txtFileName.TabIndex = 0;
            // 
            // txtNewFileName
            // 
            this.txtNewFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewFileName.Location = new System.Drawing.Point(12, 39);
            this.txtNewFileName.Name = "txtNewFileName";
            this.txtNewFileName.Size = new System.Drawing.Size(460, 21);
            this.txtNewFileName.TabIndex = 1;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(492, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnTo540
            // 
            this.btnTo540.Location = new System.Drawing.Point(492, 68);
            this.btnTo540.Name = "btnTo540";
            this.btnTo540.Size = new System.Drawing.Size(75, 23);
            this.btnTo540.TabIndex = 3;
            this.btnTo540.Text = "To540Byte";
            this.btnTo540.UseVisualStyleBackColor = true;
            this.btnTo540.Click += new System.EventHandler(this.btnTo540_Click);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(492, 39);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 23);
            this.btnRename.TabIndex = 4;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMessage.Location = new System.Drawing.Point(12, 68);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(460, 213);
            this.lblMessage.TabIndex = 5;
            // 
            // linkURL
            // 
            this.linkURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkURL.Location = new System.Drawing.Point(80, 294);
            this.linkURL.Name = "linkURL";
            this.linkURL.Size = new System.Drawing.Size(270, 23);
            this.linkURL.TabIndex = 6;
            this.linkURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkURL_LinkClicked);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(492, 290);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(78, 23);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblURL
            // 
            this.lblURL.Location = new System.Drawing.Point(12, 294);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(62, 23);
            this.lblURL.TabIndex = 8;
            this.lblURL.Text = "LinkURL:";
            this.lblURL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(492, 182);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(75, 23);
            this.btnList.TabIndex = 9;
            this.btnList.Text = "List";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnRenameAll
            // 
            this.btnRenameAll.Location = new System.Drawing.Point(492, 211);
            this.btnRenameAll.Name = "btnRenameAll";
            this.btnRenameAll.Size = new System.Drawing.Size(75, 23);
            this.btnRenameAll.TabIndex = 10;
            this.btnRenameAll.Text = "RenameAll";
            this.btnRenameAll.UseVisualStyleBackColor = true;
            this.btnRenameAll.Click += new System.EventHandler(this.btnRenameAll_Click);
            // 
            // btnMcasName
            // 
            this.btnMcasName.Location = new System.Drawing.Point(492, 240);
            this.btnMcasName.Name = "btnMcasName";
            this.btnMcasName.Size = new System.Drawing.Size(75, 23);
            this.btnMcasName.TabIndex = 11;
            this.btnMcasName.Text = "MCAS Name";
            this.btnMcasName.UseVisualStyleBackColor = true;
            this.btnMcasName.Click += new System.EventHandler(this.btnMcasName_Click);
            // 
            // btnPicture
            // 
            this.btnPicture.Location = new System.Drawing.Point(492, 124);
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.Size = new System.Drawing.Size(75, 23);
            this.btnPicture.TabIndex = 15;
            this.btnPicture.Text = "Picture";
            this.btnPicture.UseVisualStyleBackColor = true;
            this.btnPicture.Click += new System.EventHandler(this.btnPicture_Click);
            // 
            // ricOut
            // 
            this.ricOut.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ricOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ricOut.Location = new System.Drawing.Point(595, 12);
            this.ricOut.Name = "ricOut";
            this.ricOut.ReadOnly = true;
            this.ricOut.Size = new System.Drawing.Size(340, 515);
            this.ricOut.TabIndex = 17;
            this.ricOut.Text = "";
            // 
            // lblSsbTp
            // 
            this.lblSsbTp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSsbTp.Location = new System.Drawing.Point(315, 331);
            this.lblSsbTp.Name = "lblSsbTp";
            this.lblSsbTp.Size = new System.Drawing.Size(274, 156);
            this.lblSsbTp.TabIndex = 18;
            // 
            // lblMessage2
            // 
            this.lblMessage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMessage2.Location = new System.Drawing.Point(12, 331);
            this.lblMessage2.Name = "lblMessage2";
            this.lblMessage2.Size = new System.Drawing.Size(297, 196);
            this.lblMessage2.TabIndex = 19;
            // 
            // lblNewUID
            // 
            this.lblNewUID.Location = new System.Drawing.Point(315, 504);
            this.lblNewUID.Name = "lblNewUID";
            this.lblNewUID.Size = new System.Drawing.Size(49, 23);
            this.lblNewUID.TabIndex = 20;
            this.lblNewUID.Text = "NewUID:";
            this.lblNewUID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNewUID
            // 
            this.txtNewUID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewUID.Location = new System.Drawing.Point(365, 503);
            this.txtNewUID.Name = "txtNewUID";
            this.txtNewUID.Size = new System.Drawing.Size(107, 21);
            this.txtNewUID.TabIndex = 21;
            this.txtNewUID.TextChanged += new System.EventHandler(this.txtNewUID_TextChanged);
            // 
            // btnRePack
            // 
            this.btnRePack.Location = new System.Drawing.Point(492, 501);
            this.btnRePack.Name = "btnRePack";
            this.btnRePack.Size = new System.Drawing.Size(78, 23);
            this.btnRePack.TabIndex = 22;
            this.btnRePack.Text = "RePack";
            this.btnRePack.UseVisualStyleBackColor = true;
            this.btnRePack.Click += new System.EventHandler(this.btnRePack_Click);
            // 
            // frmAmiibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 536);
            this.Controls.Add(this.btnRePack);
            this.Controls.Add(this.txtNewUID);
            this.Controls.Add(this.lblNewUID);
            this.Controls.Add(this.lblMessage2);
            this.Controls.Add(this.lblSsbTp);
            this.Controls.Add(this.ricOut);
            this.Controls.Add(this.btnPicture);
            this.Controls.Add(this.btnMcasName);
            this.Controls.Add(this.btnRenameAll);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.lblURL);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.linkURL);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnTo540);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtNewFileName);
            this.Controls.Add(this.txtFileName);
            this.Name = "frmAmiibo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Amiibo Tools v1.0.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtNewFileName;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnTo540;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.LinkLabel linkURL;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnRenameAll;
        private System.Windows.Forms.Button btnMcasName;
        private System.Windows.Forms.Button btnPicture;
        private System.Windows.Forms.RichTextBox ricOut;
        private System.Windows.Forms.Label lblSsbTp;
        private System.Windows.Forms.Label lblMessage2;
        private System.Windows.Forms.Label lblNewUID;
        private System.Windows.Forms.TextBox txtNewUID;
        private System.Windows.Forms.Button btnRePack;
    }
}