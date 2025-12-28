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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAmiibo));
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
            resources.ApplyResources(this.txtFileName, "txtFileName");
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            // 
            // txtNewFileName
            // 
            this.txtNewFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtNewFileName, "txtNewFileName");
            this.txtNewFileName.Name = "txtNewFileName";
            // 
            // btnOpen
            // 
            resources.ApplyResources(this.btnOpen, "btnOpen");
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnTo540
            // 
            resources.ApplyResources(this.btnTo540, "btnTo540");
            this.btnTo540.Name = "btnTo540";
            this.btnTo540.UseVisualStyleBackColor = true;
            this.btnTo540.Click += new System.EventHandler(this.btnTo540_Click);
            // 
            // btnRename
            // 
            resources.ApplyResources(this.btnRename, "btnRename");
            this.btnRename.Name = "btnRename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // linkURL
            // 
            this.linkURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.linkURL, "linkURL");
            this.linkURL.Name = "linkURL";
            this.linkURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkURL_LinkClicked);
            // 
            // btnBack
            // 
            resources.ApplyResources(this.btnBack, "btnBack");
            this.btnBack.Name = "btnBack";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblURL
            // 
            resources.ApplyResources(this.lblURL, "lblURL");
            this.lblURL.Name = "lblURL";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnRenameAll
            // 
            resources.ApplyResources(this.btnRenameAll, "btnRenameAll");
            this.btnRenameAll.Name = "btnRenameAll";
            this.btnRenameAll.UseVisualStyleBackColor = true;
            this.btnRenameAll.Click += new System.EventHandler(this.btnRenameAll_Click);
            // 
            // btnMcasName
            // 
            resources.ApplyResources(this.btnMcasName, "btnMcasName");
            this.btnMcasName.Name = "btnMcasName";
            this.btnMcasName.UseVisualStyleBackColor = true;
            this.btnMcasName.Click += new System.EventHandler(this.btnMcasName_Click);
            // 
            // btnPicture
            // 
            resources.ApplyResources(this.btnPicture, "btnPicture");
            this.btnPicture.Name = "btnPicture";
            this.btnPicture.UseVisualStyleBackColor = true;
            this.btnPicture.Click += new System.EventHandler(this.btnPicture_Click);
            // 
            // ricOut
            // 
            this.ricOut.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ricOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.ricOut, "ricOut");
            this.ricOut.Name = "ricOut";
            this.ricOut.ReadOnly = true;
            // 
            // lblNewUID
            // 
            resources.ApplyResources(this.lblNewUID, "lblNewUID");
            this.lblNewUID.Name = "lblNewUID";
            // 
            // txtNewUID
            // 
            this.txtNewUID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtNewUID, "txtNewUID");
            this.txtNewUID.Name = "txtNewUID";
            this.txtNewUID.TextChanged += new System.EventHandler(this.txtNewUID_TextChanged);
            // 
            // btnRePack
            // 
            resources.ApplyResources(this.btnRePack, "btnRePack");
            this.btnRePack.Name = "btnRePack";
            this.btnRePack.UseVisualStyleBackColor = true;
            this.btnRePack.Click += new System.EventHandler(this.btnRePack_Click);
            // 
            // btnUnPack
            // 
            resources.ApplyResources(this.btnUnPack, "btnUnPack");
            this.btnUnPack.Name = "btnUnPack";
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
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // grpTP
            // 
            this.grpTP.Controls.Add(this.lblTpLevers);
            this.grpTP.Controls.Add(this.cboTpHearts);
            this.grpTP.Controls.Add(this.cboTpLevers);
            this.grpTP.Controls.Add(this.lblTpHearts);
            resources.ApplyResources(this.grpTP, "grpTP");
            this.grpTP.Name = "grpTP";
            this.grpTP.TabStop = false;
            // 
            // lblTpLevers
            // 
            resources.ApplyResources(this.lblTpLevers, "lblTpLevers");
            this.lblTpLevers.Name = "lblTpLevers";
            // 
            // cboTpHearts
            // 
            this.cboTpHearts.FormattingEnabled = true;
            resources.ApplyResources(this.cboTpHearts, "cboTpHearts");
            this.cboTpHearts.Name = "cboTpHearts";
            this.cboTpHearts.SelectedIndexChanged += new System.EventHandler(this.cboTpHearts_SelectedIndexChanged);
            // 
            // cboTpLevers
            // 
            this.cboTpLevers.FormattingEnabled = true;
            resources.ApplyResources(this.cboTpLevers, "cboTpLevers");
            this.cboTpLevers.Name = "cboTpLevers";
            this.cboTpLevers.SelectedIndexChanged += new System.EventHandler(this.cboTpLevers_SelectedIndexChanged);
            // 
            // lblTpHearts
            // 
            resources.ApplyResources(this.lblTpHearts, "lblTpHearts");
            this.lblTpHearts.Name = "lblTpHearts";
            // 
            // txtNewID
            // 
            this.txtNewID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtNewID, "txtNewID");
            this.txtNewID.Name = "txtNewID";
            this.txtNewID.TextChanged += new System.EventHandler(this.txtNewID_TextChanged);
            // 
            // lblNewID
            // 
            resources.ApplyResources(this.lblNewID, "lblNewID");
            this.lblNewID.Name = "lblNewID";
            // 
            // ricMessage
            // 
            this.ricMessage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ricMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.ricMessage, "ricMessage");
            this.ricMessage.Name = "ricMessage";
            this.ricMessage.ReadOnly = true;
            // 
            // frmAmiibo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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