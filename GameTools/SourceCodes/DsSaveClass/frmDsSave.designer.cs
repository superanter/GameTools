namespace AnterStudio.GameTools.DsSaveClass
{
    partial class frmDsSave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDsSave));
            this.grpFile = new System.Windows.Forms.GroupBox();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.lblSavePath = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblInput = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.grpTest = new System.Windows.Forms.GroupBox();
            this.chkTest = new System.Windows.Forms.CheckBox();
            this.lblTestEEPROM = new System.Windows.Forms.Label();
            this.lblTest1M = new System.Windows.Forms.Label();
            this.lblTest512K = new System.Windows.Forms.Label();
            this.lblTest256K = new System.Windows.Forms.Label();
            this.lblTest128K = new System.Windows.Forms.Label();
            this.lblTest64K = new System.Windows.Forms.Label();
            this.lblTest8K = new System.Windows.Forms.Label();
            this.lblTest512B = new System.Windows.Forms.Label();
            this.grpChangeMode = new System.Windows.Forms.GroupBox();
            this.cboMode = new System.Windows.Forms.ComboBox();
            this.grpOutput = new System.Windows.Forms.GroupBox();
            this.cboOutputSize = new System.Windows.Forms.ComboBox();
            this.cboOutputFormat = new System.Windows.Forms.ComboBox();
            this.lblOutputSize = new System.Windows.Forms.Label();
            this.lblOutputFormat = new System.Windows.Forms.Label();
            this.grpControl = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.grpM3 = new System.Windows.Forms.GroupBox();
            this.chkM3DatFile = new System.Windows.Forms.CheckBox();
            this.txtM3LongName = new System.Windows.Forms.TextBox();
            this.txtM3ShortName = new System.Windows.Forms.TextBox();
            this.lblM3LongName = new System.Windows.Forms.Label();
            this.lblM3ShortName = new System.Windows.Forms.Label();
            this.btnM3Rom = new System.Windows.Forms.Button();
            this.grpMessage = new System.Windows.Forms.GroupBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.groupChkBox = new System.Windows.Forms.GroupBox();
            this.chkPokemon = new System.Windows.Forms.CheckBox();
            this.dialogOpenSaveFile = new System.Windows.Forms.OpenFileDialog();
            this.dialogOpenROM = new System.Windows.Forms.OpenFileDialog();
            this.grpFile.SuspendLayout();
            this.grpTest.SuspendLayout();
            this.grpChangeMode.SuspendLayout();
            this.grpOutput.SuspendLayout();
            this.grpControl.SuspendLayout();
            this.grpM3.SuspendLayout();
            this.grpMessage.SuspendLayout();
            this.groupChkBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFile
            // 
            this.grpFile.Controls.Add(this.txtSavePath);
            this.grpFile.Controls.Add(this.lblSavePath);
            this.grpFile.Controls.Add(this.txtOutput);
            this.grpFile.Controls.Add(this.txtInput);
            this.grpFile.Controls.Add(this.lblOutput);
            this.grpFile.Controls.Add(this.lblInput);
            this.grpFile.Controls.Add(this.btnChange);
            this.grpFile.Controls.Add(this.btnOpen);
            resources.ApplyResources(this.grpFile, "grpFile");
            this.grpFile.Name = "grpFile";
            this.grpFile.TabStop = false;
            // 
            // txtSavePath
            // 
            resources.ApplyResources(this.txtSavePath, "txtSavePath");
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.ReadOnly = true;
            // 
            // lblSavePath
            // 
            resources.ApplyResources(this.lblSavePath, "lblSavePath");
            this.lblSavePath.Name = "lblSavePath";
            // 
            // txtOutput
            // 
            resources.ApplyResources(this.txtOutput, "txtOutput");
            this.txtOutput.Name = "txtOutput";
            // 
            // txtInput
            // 
            resources.ApplyResources(this.txtInput, "txtInput");
            this.txtInput.Name = "txtInput";
            this.txtInput.ReadOnly = true;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // lblOutput
            // 
            resources.ApplyResources(this.lblOutput, "lblOutput");
            this.lblOutput.Name = "lblOutput";
            // 
            // lblInput
            // 
            resources.ApplyResources(this.lblInput, "lblInput");
            this.lblInput.Name = "lblInput";
            // 
            // btnChange
            // 
            resources.ApplyResources(this.btnChange, "btnChange");
            this.btnChange.Name = "btnChange";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnOpen
            // 
            resources.ApplyResources(this.btnOpen, "btnOpen");
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // grpTest
            // 
            this.grpTest.Controls.Add(this.chkTest);
            this.grpTest.Controls.Add(this.lblTestEEPROM);
            this.grpTest.Controls.Add(this.lblTest1M);
            this.grpTest.Controls.Add(this.lblTest512K);
            this.grpTest.Controls.Add(this.lblTest256K);
            this.grpTest.Controls.Add(this.lblTest128K);
            this.grpTest.Controls.Add(this.lblTest64K);
            this.grpTest.Controls.Add(this.lblTest8K);
            this.grpTest.Controls.Add(this.lblTest512B);
            resources.ApplyResources(this.grpTest, "grpTest");
            this.grpTest.Name = "grpTest";
            this.grpTest.TabStop = false;
            // 
            // chkTest
            // 
            resources.ApplyResources(this.chkTest, "chkTest");
            this.chkTest.Name = "chkTest";
            this.chkTest.UseVisualStyleBackColor = true;
            this.chkTest.CheckedChanged += new System.EventHandler(this.chkTest_CheckedChanged);
            // 
            // lblTestEEPROM
            // 
            this.lblTestEEPROM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.lblTestEEPROM, "lblTestEEPROM");
            this.lblTestEEPROM.Name = "lblTestEEPROM";
            // 
            // lblTest1M
            // 
            this.lblTest1M.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.lblTest1M, "lblTest1M");
            this.lblTest1M.Name = "lblTest1M";
            // 
            // lblTest512K
            // 
            this.lblTest512K.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.lblTest512K, "lblTest512K");
            this.lblTest512K.Name = "lblTest512K";
            // 
            // lblTest256K
            // 
            this.lblTest256K.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.lblTest256K, "lblTest256K");
            this.lblTest256K.Name = "lblTest256K";
            // 
            // lblTest128K
            // 
            this.lblTest128K.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.lblTest128K, "lblTest128K");
            this.lblTest128K.Name = "lblTest128K";
            // 
            // lblTest64K
            // 
            this.lblTest64K.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.lblTest64K, "lblTest64K");
            this.lblTest64K.Name = "lblTest64K";
            // 
            // lblTest8K
            // 
            this.lblTest8K.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.lblTest8K, "lblTest8K");
            this.lblTest8K.Name = "lblTest8K";
            // 
            // lblTest512B
            // 
            this.lblTest512B.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.lblTest512B, "lblTest512B");
            this.lblTest512B.Name = "lblTest512B";
            // 
            // grpChangeMode
            // 
            this.grpChangeMode.Controls.Add(this.cboMode);
            resources.ApplyResources(this.grpChangeMode, "grpChangeMode");
            this.grpChangeMode.Name = "grpChangeMode";
            this.grpChangeMode.TabStop = false;
            // 
            // cboMode
            // 
            this.cboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboMode, "cboMode");
            this.cboMode.FormattingEnabled = true;
            this.cboMode.Name = "cboMode";
            this.cboMode.SelectedIndexChanged += new System.EventHandler(this.cboMode_SelectedIndexChanged);
            // 
            // grpOutput
            // 
            this.grpOutput.Controls.Add(this.cboOutputSize);
            this.grpOutput.Controls.Add(this.cboOutputFormat);
            this.grpOutput.Controls.Add(this.lblOutputSize);
            this.grpOutput.Controls.Add(this.lblOutputFormat);
            resources.ApplyResources(this.grpOutput, "grpOutput");
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.TabStop = false;
            // 
            // cboOutputSize
            // 
            this.cboOutputSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboOutputSize, "cboOutputSize");
            this.cboOutputSize.FormattingEnabled = true;
            this.cboOutputSize.Name = "cboOutputSize";
            // 
            // cboOutputFormat
            // 
            this.cboOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboOutputFormat, "cboOutputFormat");
            this.cboOutputFormat.FormattingEnabled = true;
            this.cboOutputFormat.Name = "cboOutputFormat";
            this.cboOutputFormat.SelectedIndexChanged += new System.EventHandler(this.cboOutputFormat_SelectedIndexChanged);
            // 
            // lblOutputSize
            // 
            resources.ApplyResources(this.lblOutputSize, "lblOutputSize");
            this.lblOutputSize.Name = "lblOutputSize";
            // 
            // lblOutputFormat
            // 
            resources.ApplyResources(this.lblOutputFormat, "lblOutputFormat");
            this.lblOutputFormat.Name = "lblOutputFormat";
            // 
            // grpControl
            // 
            this.grpControl.Controls.Add(this.grpChangeMode);
            resources.ApplyResources(this.grpControl, "grpControl");
            this.grpControl.Name = "grpControl";
            this.grpControl.TabStop = false;
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // grpM3
            // 
            this.grpM3.Controls.Add(this.chkM3DatFile);
            this.grpM3.Controls.Add(this.txtM3LongName);
            this.grpM3.Controls.Add(this.txtM3ShortName);
            this.grpM3.Controls.Add(this.lblM3LongName);
            this.grpM3.Controls.Add(this.lblM3ShortName);
            this.grpM3.Controls.Add(this.btnM3Rom);
            resources.ApplyResources(this.grpM3, "grpM3");
            this.grpM3.Name = "grpM3";
            this.grpM3.TabStop = false;
            // 
            // chkM3DatFile
            // 
            resources.ApplyResources(this.chkM3DatFile, "chkM3DatFile");
            this.chkM3DatFile.Name = "chkM3DatFile";
            this.chkM3DatFile.UseVisualStyleBackColor = true;
            // 
            // txtM3LongName
            // 
            resources.ApplyResources(this.txtM3LongName, "txtM3LongName");
            this.txtM3LongName.Name = "txtM3LongName";
            this.txtM3LongName.ReadOnly = true;
            // 
            // txtM3ShortName
            // 
            resources.ApplyResources(this.txtM3ShortName, "txtM3ShortName");
            this.txtM3ShortName.Name = "txtM3ShortName";
            this.txtM3ShortName.ReadOnly = true;
            // 
            // lblM3LongName
            // 
            resources.ApplyResources(this.lblM3LongName, "lblM3LongName");
            this.lblM3LongName.Name = "lblM3LongName";
            // 
            // lblM3ShortName
            // 
            resources.ApplyResources(this.lblM3ShortName, "lblM3ShortName");
            this.lblM3ShortName.Name = "lblM3ShortName";
            // 
            // btnM3Rom
            // 
            resources.ApplyResources(this.btnM3Rom, "btnM3Rom");
            this.btnM3Rom.Name = "btnM3Rom";
            this.btnM3Rom.UseVisualStyleBackColor = true;
            this.btnM3Rom.Click += new System.EventHandler(this.btnM3Rom_Click);
            // 
            // grpMessage
            // 
            this.grpMessage.Controls.Add(this.lblMessage);
            resources.ApplyResources(this.grpMessage, "grpMessage");
            this.grpMessage.Name = "grpMessage";
            this.grpMessage.TabStop = false;
            // 
            // lblMessage
            // 
            resources.ApplyResources(this.lblMessage, "lblMessage");
            this.lblMessage.Name = "lblMessage";
            // 
            // groupChkBox
            // 
            this.groupChkBox.Controls.Add(this.chkPokemon);
            resources.ApplyResources(this.groupChkBox, "groupChkBox");
            this.groupChkBox.Name = "groupChkBox";
            this.groupChkBox.TabStop = false;
            // 
            // chkPokemon
            // 
            resources.ApplyResources(this.chkPokemon, "chkPokemon");
            this.chkPokemon.Name = "chkPokemon";
            this.chkPokemon.UseVisualStyleBackColor = true;
            this.chkPokemon.CheckedChanged += new System.EventHandler(this.chkPokemon_CheckedChanged);
            // 
            // frmDsSave
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupChkBox);
            this.Controls.Add(this.grpMessage);
            this.Controls.Add(this.grpM3);
            this.Controls.Add(this.grpControl);
            this.Controls.Add(this.grpOutput);
            this.Controls.Add(this.grpTest);
            this.Controls.Add(this.grpFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmDsSave";
            this.grpFile.ResumeLayout(false);
            this.grpFile.PerformLayout();
            this.grpTest.ResumeLayout(false);
            this.grpTest.PerformLayout();
            this.grpChangeMode.ResumeLayout(false);
            this.grpOutput.ResumeLayout(false);
            this.grpOutput.PerformLayout();
            this.grpControl.ResumeLayout(false);
            this.grpM3.ResumeLayout(false);
            this.grpM3.PerformLayout();
            this.grpMessage.ResumeLayout(false);
            this.groupChkBox.ResumeLayout(false);
            this.groupChkBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFile;
        private System.Windows.Forms.GroupBox grpTest;
        private System.Windows.Forms.GroupBox grpChangeMode;
        private System.Windows.Forms.GroupBox grpOutput;
        private System.Windows.Forms.GroupBox grpControl;
        private System.Windows.Forms.GroupBox grpM3;
        private System.Windows.Forms.GroupBox grpMessage;
        private System.Windows.Forms.GroupBox groupChkBox;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnM3Rom;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblOutputFormat;
        private System.Windows.Forms.Label lblOutputSize;
        private System.Windows.Forms.Label lblTest512B;
        private System.Windows.Forms.Label lblTestEEPROM;
        private System.Windows.Forms.Label lblTest1M;
        private System.Windows.Forms.Label lblTest512K;
        private System.Windows.Forms.Label lblTest256K;
        private System.Windows.Forms.Label lblTest128K;
        private System.Windows.Forms.Label lblTest64K;
        private System.Windows.Forms.Label lblTest8K;
        private System.Windows.Forms.Label lblM3ShortName;
        private System.Windows.Forms.Label lblM3LongName;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtM3ShortName;
        private System.Windows.Forms.TextBox txtM3LongName;
        private System.Windows.Forms.OpenFileDialog dialogOpenSaveFile;
        private System.Windows.Forms.OpenFileDialog dialogOpenROM;
        private System.Windows.Forms.ComboBox cboMode;
        private System.Windows.Forms.ComboBox cboOutputFormat;
        private System.Windows.Forms.ComboBox cboOutputSize;
        private System.Windows.Forms.CheckBox chkTest;
        private System.Windows.Forms.CheckBox chkM3DatFile;
        private System.Windows.Forms.CheckBox chkPokemon;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Label lblSavePath;
    }
}

