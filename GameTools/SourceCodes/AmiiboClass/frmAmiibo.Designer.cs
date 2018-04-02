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
            this.linkURL = new System.Windows.Forms.LinkLabel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblURL = new System.Windows.Forms.Label();
            this.btnList = new System.Windows.Forms.Button();
            this.btnRenameAll = new System.Windows.Forms.Button();
            this.btnMcasName = new System.Windows.Forms.Button();
            this.btnPicture = new System.Windows.Forms.Button();
            this.ricOut = new System.Windows.Forms.RichTextBox();
            this.lblNewUID = new System.Windows.Forms.Label();
            this.txtNewUID = new System.Windows.Forms.TextBox();
            this.btnRePack = new System.Windows.Forms.Button();
            this.btnUnPack = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpTP = new System.Windows.Forms.GroupBox();
            this.lblTpLevers = new System.Windows.Forms.Label();
            this.cboTpHearts = new System.Windows.Forms.ComboBox();
            this.cboTpLevers = new System.Windows.Forms.ComboBox();
            this.lblTpHearts = new System.Windows.Forms.Label();
            this.txtNewID = new System.Windows.Forms.TextBox();
            this.lblNewID = new System.Windows.Forms.Label();
            this.ricMessage = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.grpTP.SuspendLayout();
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
            this.btnOpen.Location = new System.Drawing.Point(397, 74);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnTo540
            // 
            this.btnTo540.Location = new System.Drawing.Point(397, 130);
            this.btnTo540.Name = "btnTo540";
            this.btnTo540.Size = new System.Drawing.Size(75, 23);
            this.btnTo540.TabIndex = 3;
            this.btnTo540.Text = "To540Byte";
            this.btnTo540.UseVisualStyleBackColor = true;
            this.btnTo540.Click += new System.EventHandler(this.btnTo540_Click);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(397, 101);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 23);
            this.btnRename.TabIndex = 4;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // linkURL
            // 
            this.linkURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkURL.Location = new System.Drawing.Point(80, 381);
            this.linkURL.Name = "linkURL";
            this.linkURL.Size = new System.Drawing.Size(270, 23);
            this.linkURL.TabIndex = 6;
            this.linkURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkURL_LinkClicked);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(999, 381);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(78, 23);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblURL
            // 
            this.lblURL.Location = new System.Drawing.Point(12, 381);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(62, 23);
            this.lblURL.TabIndex = 8;
            this.lblURL.Text = "LinkURL:";
            this.lblURL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(397, 188);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(75, 23);
            this.btnList.TabIndex = 9;
            this.btnList.Text = "List";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnRenameAll
            // 
            this.btnRenameAll.Location = new System.Drawing.Point(397, 217);
            this.btnRenameAll.Name = "btnRenameAll";
            this.btnRenameAll.Size = new System.Drawing.Size(75, 23);
            this.btnRenameAll.TabIndex = 10;
            this.btnRenameAll.Text = "RenameAll";
            this.btnRenameAll.UseVisualStyleBackColor = true;
            this.btnRenameAll.Click += new System.EventHandler(this.btnRenameAll_Click);
            // 
            // btnMcasName
            // 
            this.btnMcasName.Location = new System.Drawing.Point(397, 246);
            this.btnMcasName.Name = "btnMcasName";
            this.btnMcasName.Size = new System.Drawing.Size(75, 23);
            this.btnMcasName.TabIndex = 11;
            this.btnMcasName.Text = "MCAS Name";
            this.btnMcasName.UseVisualStyleBackColor = true;
            this.btnMcasName.Click += new System.EventHandler(this.btnMcasName_Click);
            // 
            // btnPicture
            // 
            this.btnPicture.Location = new System.Drawing.Point(397, 159);
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
            this.ricOut.Location = new System.Drawing.Point(737, 12);
            this.ricOut.Name = "ricOut";
            this.ricOut.ReadOnly = true;
            this.ricOut.Size = new System.Drawing.Size(340, 349);
            this.ricOut.TabIndex = 17;
            this.ricOut.Text = "";
            // 
            // lblNewUID
            // 
            this.lblNewUID.Location = new System.Drawing.Point(14, 22);
            this.lblNewUID.Name = "lblNewUID";
            this.lblNewUID.Size = new System.Drawing.Size(63, 23);
            this.lblNewUID.TabIndex = 20;
            this.lblNewUID.Text = "New UID:";
            // 
            // txtNewUID
            // 
            this.txtNewUID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewUID.Location = new System.Drawing.Point(83, 20);
            this.txtNewUID.Name = "txtNewUID";
            this.txtNewUID.Size = new System.Drawing.Size(122, 21);
            this.txtNewUID.TabIndex = 21;
            this.txtNewUID.TextChanged += new System.EventHandler(this.txtNewUID_TextChanged);
            // 
            // btnRePack
            // 
            this.btnRePack.Location = new System.Drawing.Point(139, 190);
            this.btnRePack.Name = "btnRePack";
            this.btnRePack.Size = new System.Drawing.Size(78, 23);
            this.btnRePack.TabIndex = 22;
            this.btnRePack.Text = "RePack";
            this.btnRePack.UseVisualStyleBackColor = true;
            this.btnRePack.Click += new System.EventHandler(this.btnRePack_Click);
            // 
            // btnUnPack
            // 
            this.btnUnPack.Location = new System.Drawing.Point(397, 295);
            this.btnUnPack.Name = "btnUnPack";
            this.btnUnPack.Size = new System.Drawing.Size(75, 23);
            this.btnUnPack.TabIndex = 23;
            this.btnUnPack.Text = "UnPack";
            this.btnUnPack.UseVisualStyleBackColor = true;
            this.btnUnPack.Click += new System.EventHandler(this.btnUnPack_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grpTP);
            this.groupBox1.Controls.Add(this.txtNewID);
            this.groupBox1.Controls.Add(this.lblNewID);
            this.groupBox1.Controls.Add(this.txtNewUID);
            this.groupBox1.Controls.Add(this.lblNewUID);
            this.groupBox1.Controls.Add(this.btnRePack);
            this.groupBox1.Location = new System.Drawing.Point(489, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 228);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RePack";
            // 
            // grpTP
            // 
            this.grpTP.Controls.Add(this.lblTpLevers);
            this.grpTP.Controls.Add(this.cboTpHearts);
            this.grpTP.Controls.Add(this.cboTpLevers);
            this.grpTP.Controls.Add(this.lblTpHearts);
            this.grpTP.Enabled = false;
            this.grpTP.Location = new System.Drawing.Point(9, 91);
            this.grpTP.Name = "grpTP";
            this.grpTP.Size = new System.Drawing.Size(208, 84);
            this.grpTP.TabIndex = 29;
            this.grpTP.TabStop = false;
            this.grpTP.Text = "TP";
            // 
            // lblTpLevers
            // 
            this.lblTpLevers.Location = new System.Drawing.Point(6, 17);
            this.lblTpLevers.Name = "lblTpLevers";
            this.lblTpLevers.Size = new System.Drawing.Size(63, 23);
            this.lblTpLevers.TabIndex = 26;
            this.lblTpLevers.Text = "TP Lever";
            // 
            // cboTpHearts
            // 
            this.cboTpHearts.FormattingEnabled = true;
            this.cboTpHearts.Location = new System.Drawing.Point(75, 54);
            this.cboTpHearts.Name = "cboTpHearts";
            this.cboTpHearts.Size = new System.Drawing.Size(117, 20);
            this.cboTpHearts.TabIndex = 28;
            this.cboTpHearts.SelectedIndexChanged += new System.EventHandler(this.cboTpHearts_SelectedIndexChanged);
            // 
            // cboTpLevers
            // 
            this.cboTpLevers.FormattingEnabled = true;
            this.cboTpLevers.Location = new System.Drawing.Point(75, 15);
            this.cboTpLevers.Name = "cboTpLevers";
            this.cboTpLevers.Size = new System.Drawing.Size(117, 20);
            this.cboTpLevers.TabIndex = 25;
            this.cboTpLevers.SelectedIndexChanged += new System.EventHandler(this.cboTpLevers_SelectedIndexChanged);
            // 
            // lblTpHearts
            // 
            this.lblTpHearts.Location = new System.Drawing.Point(4, 55);
            this.lblTpHearts.Name = "lblTpHearts";
            this.lblTpHearts.Size = new System.Drawing.Size(63, 23);
            this.lblTpHearts.TabIndex = 27;
            this.lblTpHearts.Text = "TP Hearts";
            // 
            // txtNewID
            // 
            this.txtNewID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewID.Location = new System.Drawing.Point(83, 58);
            this.txtNewID.Name = "txtNewID";
            this.txtNewID.Size = new System.Drawing.Size(122, 21);
            this.txtNewID.TabIndex = 24;
            this.txtNewID.TextChanged += new System.EventHandler(this.txtNewID_TextChanged);
            // 
            // lblNewID
            // 
            this.lblNewID.Location = new System.Drawing.Point(14, 59);
            this.lblNewID.Name = "lblNewID";
            this.lblNewID.Size = new System.Drawing.Size(63, 23);
            this.lblNewID.TabIndex = 23;
            this.lblNewID.Text = "New ID:";
            this.lblNewID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ricMessage
            // 
            this.ricMessage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ricMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ricMessage.Location = new System.Drawing.Point(12, 74);
            this.ricMessage.Name = "ricMessage";
            this.ricMessage.ReadOnly = true;
            this.ricMessage.Size = new System.Drawing.Size(369, 287);
            this.ricMessage.TabIndex = 25;
            this.ricMessage.Text = "";
            // 
            // frmAmiibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 416);
            this.Controls.Add(this.ricMessage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUnPack);
            this.Controls.Add(this.ricOut);
            this.Controls.Add(this.btnPicture);
            this.Controls.Add(this.btnMcasName);
            this.Controls.Add(this.btnRenameAll);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.lblURL);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.linkURL);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnTo540);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtNewFileName);
            this.Controls.Add(this.txtFileName);
            this.Name = "frmAmiibo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Amiibo Tools v1.0.0";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpTP.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtNewFileName;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnTo540;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.LinkLabel linkURL;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnRenameAll;
        private System.Windows.Forms.Button btnMcasName;
        private System.Windows.Forms.Button btnPicture;
        private System.Windows.Forms.RichTextBox ricOut;
        private System.Windows.Forms.Label lblNewUID;
        private System.Windows.Forms.TextBox txtNewUID;
        private System.Windows.Forms.Button btnRePack;
        private System.Windows.Forms.Button btnUnPack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNewID;
        private System.Windows.Forms.Label lblNewID;
        private System.Windows.Forms.RichTextBox ricMessage;
        private System.Windows.Forms.ComboBox cboTpLevers;
        private System.Windows.Forms.Label lblTpLevers;
        private System.Windows.Forms.ComboBox cboTpHearts;
        private System.Windows.Forms.Label lblTpHearts;
        private System.Windows.Forms.GroupBox grpTP;
    }
}