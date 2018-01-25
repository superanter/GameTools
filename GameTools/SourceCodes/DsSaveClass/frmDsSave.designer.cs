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
            this.grpFile.Location = new System.Drawing.Point(12, 12);
            this.grpFile.Name = "grpFile";
            this.grpFile.Size = new System.Drawing.Size(504, 148);
            this.grpFile.TabIndex = 0;
            this.grpFile.TabStop = false;
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(63, 85);
            this.txtSavePath.Multiline = true;
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.ReadOnly = true;
            this.txtSavePath.Size = new System.Drawing.Size(428, 54);
            this.txtSavePath.TabIndex = 7;
            // 
            // lblSavePath
            // 
            this.lblSavePath.Location = new System.Drawing.Point(6, 88);
            this.lblSavePath.Name = "lblSavePath";
            this.lblSavePath.Size = new System.Drawing.Size(53, 22);
            this.lblSavePath.TabIndex = 6;
            this.lblSavePath.Text = "存档路径";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(64, 51);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(372, 21);
            this.txtOutput.TabIndex = 5;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(64, 18);
            this.txtInput.Name = "txtInput";
            this.txtInput.ReadOnly = true;
            this.txtInput.Size = new System.Drawing.Size(373, 21);
            this.txtInput.TabIndex = 4;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(5, 54);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(53, 12);
            this.lblOutput.TabIndex = 3;
            this.lblOutput.Text = "目标文件";
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(6, 24);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(41, 12);
            this.lblInput.TabIndex = 2;
            this.lblInput.Text = "源文件";
            // 
            // btnChange
            // 
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChange.Location = new System.Drawing.Point(443, 48);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(48, 24);
            this.btnChange.TabIndex = 1;
            this.btnChange.Text = "转换";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Location = new System.Drawing.Point(443, 18);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(48, 24);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "打开";
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
            this.grpTest.Location = new System.Drawing.Point(12, 166);
            this.grpTest.Name = "grpTest";
            this.grpTest.Size = new System.Drawing.Size(504, 40);
            this.grpTest.TabIndex = 1;
            this.grpTest.TabStop = false;
            // 
            // chkTest
            // 
            this.chkTest.AutoSize = true;
            this.chkTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkTest.Location = new System.Drawing.Point(6, 15);
            this.chkTest.Name = "chkTest";
            this.chkTest.Size = new System.Drawing.Size(45, 16);
            this.chkTest.TabIndex = 8;
            this.chkTest.Text = "测试";
            this.chkTest.UseVisualStyleBackColor = true;
            this.chkTest.CheckedChanged += new System.EventHandler(this.chkTest_CheckedChanged);
            // 
            // lblTestEEPROM
            // 
            this.lblTestEEPROM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTestEEPROM.Location = new System.Drawing.Point(448, 15);
            this.lblTestEEPROM.Name = "lblTestEEPROM";
            this.lblTestEEPROM.Size = new System.Drawing.Size(50, 16);
            this.lblTestEEPROM.TabIndex = 7;
            this.lblTestEEPROM.Text = "EEPROM";
            this.lblTestEEPROM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTest1M
            // 
            this.lblTest1M.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTest1M.Location = new System.Drawing.Point(393, 15);
            this.lblTest1M.Name = "lblTest1M";
            this.lblTest1M.Size = new System.Drawing.Size(50, 16);
            this.lblTest1M.TabIndex = 6;
            this.lblTest1M.Text = "1M";
            this.lblTest1M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTest512K
            // 
            this.lblTest512K.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTest512K.Location = new System.Drawing.Point(338, 15);
            this.lblTest512K.Name = "lblTest512K";
            this.lblTest512K.Size = new System.Drawing.Size(50, 16);
            this.lblTest512K.TabIndex = 5;
            this.lblTest512K.Text = "512K";
            this.lblTest512K.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTest256K
            // 
            this.lblTest256K.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTest256K.Location = new System.Drawing.Point(283, 15);
            this.lblTest256K.Name = "lblTest256K";
            this.lblTest256K.Size = new System.Drawing.Size(50, 16);
            this.lblTest256K.TabIndex = 4;
            this.lblTest256K.Text = "256K";
            this.lblTest256K.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTest128K
            // 
            this.lblTest128K.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTest128K.Location = new System.Drawing.Point(228, 15);
            this.lblTest128K.Name = "lblTest128K";
            this.lblTest128K.Size = new System.Drawing.Size(50, 16);
            this.lblTest128K.TabIndex = 3;
            this.lblTest128K.Text = "128K";
            this.lblTest128K.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTest64K
            // 
            this.lblTest64K.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTest64K.Location = new System.Drawing.Point(173, 15);
            this.lblTest64K.Name = "lblTest64K";
            this.lblTest64K.Size = new System.Drawing.Size(50, 16);
            this.lblTest64K.TabIndex = 2;
            this.lblTest64K.Text = "64K";
            this.lblTest64K.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTest8K
            // 
            this.lblTest8K.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTest8K.Location = new System.Drawing.Point(118, 15);
            this.lblTest8K.Name = "lblTest8K";
            this.lblTest8K.Size = new System.Drawing.Size(50, 16);
            this.lblTest8K.TabIndex = 1;
            this.lblTest8K.Text = "8K";
            this.lblTest8K.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTest512B
            // 
            this.lblTest512B.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTest512B.Location = new System.Drawing.Point(63, 15);
            this.lblTest512B.Name = "lblTest512B";
            this.lblTest512B.Size = new System.Drawing.Size(50, 16);
            this.lblTest512B.TabIndex = 0;
            this.lblTest512B.Text = "512B";
            this.lblTest512B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpChangeMode
            // 
            this.grpChangeMode.Controls.Add(this.cboMode);
            this.grpChangeMode.Location = new System.Drawing.Point(24, 16);
            this.grpChangeMode.Name = "grpChangeMode";
            this.grpChangeMode.Size = new System.Drawing.Size(76, 52);
            this.grpChangeMode.TabIndex = 2;
            this.grpChangeMode.TabStop = false;
            this.grpChangeMode.Text = "转换模式";
            // 
            // cboMode
            // 
            this.cboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboMode.FormattingEnabled = true;
            this.cboMode.Location = new System.Drawing.Point(8, 20);
            this.cboMode.Name = "cboMode";
            this.cboMode.Size = new System.Drawing.Size(61, 20);
            this.cboMode.TabIndex = 0;
            this.cboMode.SelectedIndexChanged += new System.EventHandler(this.cboMode_SelectedIndexChanged);
            // 
            // grpOutput
            // 
            this.grpOutput.Controls.Add(this.cboOutputSize);
            this.grpOutput.Controls.Add(this.cboOutputFormat);
            this.grpOutput.Controls.Add(this.lblOutputSize);
            this.grpOutput.Controls.Add(this.lblOutputFormat);
            this.grpOutput.Location = new System.Drawing.Point(12, 212);
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Size = new System.Drawing.Size(316, 96);
            this.grpOutput.TabIndex = 4;
            this.grpOutput.TabStop = false;
            this.grpOutput.Text = "输出格式";
            // 
            // cboOutputSize
            // 
            this.cboOutputSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutputSize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboOutputSize.FormattingEnabled = true;
            this.cboOutputSize.Location = new System.Drawing.Point(83, 64);
            this.cboOutputSize.Name = "cboOutputSize";
            this.cboOutputSize.Size = new System.Drawing.Size(202, 20);
            this.cboOutputSize.TabIndex = 3;
            // 
            // cboOutputFormat
            // 
            this.cboOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutputFormat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboOutputFormat.FormattingEnabled = true;
            this.cboOutputFormat.Location = new System.Drawing.Point(81, 32);
            this.cboOutputFormat.Name = "cboOutputFormat";
            this.cboOutputFormat.Size = new System.Drawing.Size(204, 20);
            this.cboOutputFormat.TabIndex = 2;
            this.cboOutputFormat.SelectedIndexChanged += new System.EventHandler(this.cboOutputFormat_SelectedIndexChanged);
            // 
            // lblOutputSize
            // 
            this.lblOutputSize.AutoSize = true;
            this.lblOutputSize.Location = new System.Drawing.Point(6, 67);
            this.lblOutputSize.Name = "lblOutputSize";
            this.lblOutputSize.Size = new System.Drawing.Size(53, 12);
            this.lblOutputSize.TabIndex = 1;
            this.lblOutputSize.Text = "输出大小";
            // 
            // lblOutputFormat
            // 
            this.lblOutputFormat.AutoSize = true;
            this.lblOutputFormat.Location = new System.Drawing.Point(6, 35);
            this.lblOutputFormat.Name = "lblOutputFormat";
            this.lblOutputFormat.Size = new System.Drawing.Size(53, 12);
            this.lblOutputFormat.TabIndex = 0;
            this.lblOutputFormat.Text = "输出格式";
            // 
            // grpControl
            // 
            this.grpControl.Controls.Add(this.grpChangeMode);
            this.grpControl.Location = new System.Drawing.Point(7, 408);
            this.grpControl.Name = "grpControl";
            this.grpControl.Size = new System.Drawing.Size(118, 88);
            this.grpControl.TabIndex = 5;
            this.grpControl.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(450, 472);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 24);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "返回";
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
            this.grpM3.Location = new System.Drawing.Point(12, 314);
            this.grpM3.Name = "grpM3";
            this.grpM3.Size = new System.Drawing.Size(316, 88);
            this.grpM3.TabIndex = 6;
            this.grpM3.TabStop = false;
            this.grpM3.Text = "M3 附加选项";
            // 
            // chkM3DatFile
            // 
            this.chkM3DatFile.AutoSize = true;
            this.chkM3DatFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkM3DatFile.Location = new System.Drawing.Point(231, 58);
            this.chkM3DatFile.Name = "chkM3DatFile";
            this.chkM3DatFile.Size = new System.Drawing.Size(69, 16);
            this.chkM3DatFile.TabIndex = 7;
            this.chkM3DatFile.Text = "Dat File";
            this.chkM3DatFile.UseVisualStyleBackColor = true;
            // 
            // txtM3LongName
            // 
            this.txtM3LongName.Location = new System.Drawing.Point(65, 56);
            this.txtM3LongName.Name = "txtM3LongName";
            this.txtM3LongName.ReadOnly = true;
            this.txtM3LongName.Size = new System.Drawing.Size(160, 21);
            this.txtM3LongName.TabIndex = 6;
            // 
            // txtM3ShortName
            // 
            this.txtM3ShortName.Location = new System.Drawing.Point(68, 20);
            this.txtM3ShortName.Name = "txtM3ShortName";
            this.txtM3ShortName.ReadOnly = true;
            this.txtM3ShortName.Size = new System.Drawing.Size(115, 21);
            this.txtM3ShortName.TabIndex = 5;
            // 
            // lblM3LongName
            // 
            this.lblM3LongName.AutoSize = true;
            this.lblM3LongName.Location = new System.Drawing.Point(6, 56);
            this.lblM3LongName.Name = "lblM3LongName";
            this.lblM3LongName.Size = new System.Drawing.Size(53, 12);
            this.lblM3LongName.TabIndex = 4;
            this.lblM3LongName.Text = "长文件名";
            // 
            // lblM3ShortName
            // 
            this.lblM3ShortName.AutoSize = true;
            this.lblM3ShortName.Location = new System.Drawing.Point(6, 26);
            this.lblM3ShortName.Name = "lblM3ShortName";
            this.lblM3ShortName.Size = new System.Drawing.Size(53, 12);
            this.lblM3ShortName.TabIndex = 3;
            this.lblM3ShortName.Text = "短文件名";
            // 
            // btnM3Rom
            // 
            this.btnM3Rom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnM3Rom.Location = new System.Drawing.Point(206, 20);
            this.btnM3Rom.Name = "btnM3Rom";
            this.btnM3Rom.Size = new System.Drawing.Size(96, 24);
            this.btnM3Rom.TabIndex = 2;
            this.btnM3Rom.Text = "对应M3文件";
            this.btnM3Rom.UseVisualStyleBackColor = true;
            this.btnM3Rom.Click += new System.EventHandler(this.btnM3Rom_Click);
            // 
            // grpMessage
            // 
            this.grpMessage.Controls.Add(this.lblMessage);
            this.grpMessage.Location = new System.Drawing.Point(334, 212);
            this.grpMessage.Name = "grpMessage";
            this.grpMessage.Size = new System.Drawing.Size(182, 190);
            this.grpMessage.TabIndex = 7;
            this.grpMessage.TabStop = false;
            // 
            // lblMessage
            // 
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Location = new System.Drawing.Point(3, 17);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(176, 170);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "小蚂蚁工作室ANTer欢迎您使用本软件";
            // 
            // groupChkBox
            // 
            this.groupChkBox.Controls.Add(this.chkPokemon);
            this.groupChkBox.Location = new System.Drawing.Point(146, 428);
            this.groupChkBox.Name = "groupChkBox";
            this.groupChkBox.Size = new System.Drawing.Size(268, 48);
            this.groupChkBox.TabIndex = 8;
            this.groupChkBox.TabStop = false;
            // 
            // chkPokemon
            // 
            this.chkPokemon.AutoSize = true;
            this.chkPokemon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkPokemon.Location = new System.Drawing.Point(16, 20);
            this.chkPokemon.Name = "chkPokemon";
            this.chkPokemon.Size = new System.Drawing.Size(213, 16);
            this.chkPokemon.TabIndex = 0;
            this.chkPokemon.Text = "口袋妖怪强制转换（512K -> 256K）";
            this.chkPokemon.UseVisualStyleBackColor = true;
            this.chkPokemon.CheckedChanged += new System.EventHandler(this.chkPokemon_CheckedChanged);
            // 
            // frmDsSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 508);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupChkBox);
            this.Controls.Add(this.grpMessage);
            this.Controls.Add(this.grpM3);
            this.Controls.Add(this.grpControl);
            this.Controls.Add(this.grpOutput);
            this.Controls.Add(this.grpTest);
            this.Controls.Add(this.grpFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDsSave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DS Save Tools";
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

