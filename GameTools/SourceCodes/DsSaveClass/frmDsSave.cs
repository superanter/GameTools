using System;
using System.Drawing;
using System.IO;                        //FileInfo 2017-01-23
using System.Windows.Forms;

namespace AnterStudio.GameTools.DsSaveClass
{
    public partial class frmDsSave : Form
    {
        CardClass[][] CardTypeInfo = CardList.GetCardDat();     // 烧录卡信息数据
        int[] UsedSize = new int[10];                           // 存档大小信息
        private LangugePackClass.cDsSave MyLanguge;
        private SoftVersionClass.SoftVersion MyVersion;
        #region 构造函数（1方法）

        public frmDsSave()
        {
            InitializeComponent();
            StartMain();            // 启动主窗口时，初始化项目
        }

        public frmDsSave(LangugePackClass.cDsSave LangugePack, SoftVersionClass.SoftVersion VersionPack)         //2017-08-02
        {
            InitializeComponent();
            this.MyLanguge = LangugePack;
            this.MyVersion = VersionPack;
            StartMain();            // 启动主窗口时，初始化项目
        }

        #endregion

        #region 初始化（2方法）

        private void StartMain()        //初始化语言、模式和类型选择列表
        {
            // 模式选择列表
            cboMode.Items.AddRange(new object[] { "NDS", "GBA" });
            cboMode.SelectedIndex = 0;

            // 类型选择列表
            ChangeMode();

            SetLanguge();       //2017-02-08
        }

        private void SetLanguge()                                   //2017-02-08
        {
            this.Text = MyLanguge.Form.Title + " " + MyVersion.Version;
            btnOpen.Text = MyLanguge.Button.Open;
            btnChange.Text = MyLanguge.Button.Change;
            btnExit.Text = MyLanguge.Button.GoBack;
            btnM3Rom.Text = MyLanguge.Button.M3Rom;
            grpOutput.Text = MyLanguge.GroupBox.Output;
            grpM3.Text = MyLanguge.GroupBox.M3;
            grpChangeMode.Text = MyLanguge.GroupBox.ChangeMode;
            lblInput.Text = MyLanguge.Lable.InputFile;
            lblOutput.Text = MyLanguge.Lable.OutputFile;
            lblOutputFormat.Text = MyLanguge.Lable.OutputFormat;
            lblOutputSize.Text = MyLanguge.Lable.OutputSize;
            lblM3ShortName.Text = MyLanguge.Lable.M3ShortName;
            lblM3LongName.Text = MyLanguge.Lable.M3LongName;
            chkTest.Text = MyLanguge.CheckBox.Test;
            chkPokemon.Text = MyLanguge.CheckBox.Pokemon;
            chkM3DatFile.Text = MyLanguge.CheckBox.M3Dat;
        }

        #endregion

        #region 控件（11方法）

        #region 控件.按钮（4）

        private void btnOpen_Click(object sender, EventArgs e)              //2017-01-23
        {
            // 文件名处理
            string[] myString = OpenInputFile();
            txtInput.Text = myString[0];
            txtSavePath.Text = myString[1] + "\\";
            ClearMessage();

            // 用测试程序测试源文件类型
            if (txtInput.Text != "" && chkTest.Checked)
            {
                MainTest();
            }
        }

        private void btnChange_Click(object sender, EventArgs e)            //2017-01-26
        {
            // 查看主界面输入的信息是否完整，如完整，则开始转换，如不完整，分情况提示信息：
            ClearMessage();
            if (!chkTest.Checked)
            {
                ShowTestMap("00000000");
            }
            if (txtInput.Text == "")
            {
                ShowErrorMessage("MM001");     // 未指定源文件时，显示“请选择源存档文件”
            }
            else if (SelectedCardType.CardIs == 1 && txtM3ShortName.Text == "" && chkM3DatFile.Checked == false)    //2017-02-07
            {
                ShowErrorMessage("MM002");     // 输出文件为M3格式，但未指定ROM文件时，显示“请选择M3存档对应的ROM”
            }
            else if (SelectedCardType.CardIs == 1 && txtM3LongName.Text == "" && chkM3DatFile.Checked == true)    //2017-02-07
            {
                ShowErrorMessage("MM002");     // 输出文件为M3格式，但未指定dat文件时，显示“请选择M3存档对应的ROM”
            }
            else if (File.Exists((txtSavePath.Text + txtOutput.Text)))                          //2017-01-06
            {
                DialogResult result = ShowMessageBox(txtOutput.Text);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    StartChange();
                }
            }
            else
            {
                StartChange();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnM3Rom_Click(object sender, EventArgs e)
        {
            string strM3RomName = OpenROMFile();
            if (strM3RomName != "")
            {
                string[] M3Name = GetShortName.M3ShortName(strM3RomName);

                txtM3LongName.Text = M3Name[1];
                txtM3ShortName.Text = M3Name[2];

                if (M3Name[0] == ".dat")
                {
                    chkM3DatFile.Enabled = false;
                    chkM3DatFile.Checked = true;
                }
                else if (M3Name[0] == ".nds" || M3Name[0] == ".gba")
                {
                    chkM3DatFile.Enabled = false;
                    chkM3DatFile.Checked = false;
                }
                else
                {
                    chkM3DatFile.Enabled = true;
                }
            }
        }

        #endregion

        #region   控件.列表框（3）

        private void cboMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeMode();

            if (txtInput.Text != "" && chkTest.Checked)
            {
                MainTest();
            }
        }

        private void cboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LanguageString = new LanguageClass(cboLanguage.SelectedIndex);
        }

        private void cboOutputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOutput.Text = InputToOutput(txtInput.Text);

            SetSaveSize();

            if (SelectedCardType.Only256 == 1)
            {
                chkPokemon.Enabled = true;
            }
            else
            {
                chkPokemon.Enabled = false;
            }

            ClearMessage();

            ShowMessage(MyLanguge.Message.CardInfo);       //烧录卡说明：
            ShowMessage(SelectedCardType.CardInfo);		//显示烧录卡说明信息

            if (SelectedCardType.CardIs == 1)
            {
                grpM3.Enabled = true;
            }
            else
            {
                grpM3.Enabled = false;
            }
        }

        #endregion

        #region 控件.复选框（2）

        private void chkTest_CheckedChanged(object sender, EventArgs e)
        {
            ///在勾选本复选框后，系统自动对源存档进行测试，除掉本复选框后，清除测试结果
            if (chkTest.Checked && txtInput.Text != "")
            {
                MainTest();
            }
            else
            {
                ShowTestMap("00000000");
            }
        }

        private void chkPokemon_CheckedChanged(object sender, EventArgs e)
        {
            ///口袋妖怪强制转换复选框
            ///
            if (chkPokemon.Checked)
            {
                cboOutputSize.Enabled = false;
                ShowErrorMessage("MM003");     // 口袋妖怪强制转换（512K->256K）;
            }
            else
            {
                cboOutputSize.Enabled = true;
            }
        }

        #endregion

        #region 控件.文本框（1）

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            txtOutput.Text = InputToOutput(txtInput.Text);
        }

        #endregion

        #region 控件.完整控制（1）

        private void myAllControl(bool boolOnOff)
        {
            ///界面控件可访问性控制
            grpFile.Enabled = boolOnOff;
            grpTest.Enabled = boolOnOff;
            grpOutput.Enabled = boolOnOff;
            grpMessage.Enabled = boolOnOff;
            grpControl.Enabled = boolOnOff;
            grpM3.Enabled = boolOnOff;

            if (boolOnOff && SelectedCardType.CardIs == 1)
                grpM3.Enabled = true;
            else
                grpM3.Enabled = false;
        }

        #endregion

        #endregion

        #region 输出信息（8方法）

        private void ClearMessage()
        {
            lblMessage.Text = "";
        }

        private void ShowMessage(string OutputMessage)
        {
            lblMessage.Text += OutputMessage;       // 直接输出信息
        }

        private string SizeMessage(int OutputSize)
        {
            ///获取源存档实际体积
            string PrintSize;

            if (OutputSize < 1024)
            {
                PrintSize = OutputSize.ToString() + " Byte";
            }
            else if (OutputSize < 1024 * 1024)
            {
                OutputSize = OutputSize / 1024;
                PrintSize = OutputSize.ToString() + " KB";
            }
            else
            {
                OutputSize = OutputSize / 1024 / 1024;
                PrintSize = OutputSize.ToString() + " MB";
            }
            return PrintSize;
        }

        private void ShowMainMessage(string[] sReturnStr)
        {
            // 如果目标为M3的GBA格式1M存档，目标存档大小为“1M”，否则为实际值
            int intOutSize = (sReturnStr[5] == "true" ? 1024 * 1024 : Convert.ToInt32(sReturnStr[4]));  // 目标存档大小

            ShowMessage(MyLanguge.Message.InputFormat + sReturnStr[1] + "\n");                               // 源存档格式：
            ShowMessage(MyLanguge.Message.InputSize + SizeMessage(Convert.ToInt32(sReturnStr[2])) + "\n");   // 源存档大小：
            ShowMessage(MyLanguge.Message.DateSize + SizeMessage(Convert.ToInt32(sReturnStr[3])) + "\n");    // 转换前大小：
            ShowMessage(MyLanguge.Message.OutputFormat + SelectedCardType.CardSName + "\n");                 // 转换后格式：
            ShowMessage(MyLanguge.Message.OutputSize + SizeMessage(intOutSize) + " \n");                     // 转换后大小：
            ShowMessage("\n" + MyLanguge.Message.ChangeOk + "\n");                                           // 转换成功！
        }

        private void ShowPokemonMessage(string[] temp)
        {
            ShowMessage(temp[1] + "\n");
            ShowMessage("Input: " + temp[2] + "\n");
            ShowMessage("1: " + temp[3] + " times\n");
            ShowMessage("2: " + temp[4] + " times\n");
            ShowMessage(MyLanguge.Message.Pokemon + temp[5] + "\n"); //使用存档：
            ShowMessage("\n" + MyLanguge.Message.ChangeOk + "\n");         //转换成功！
        }

        private string GetErrorString(string errorCode)     //2017-02-08
        {
            switch (errorCode)
            {
                case "MM001": return MyLanguge.Error.MM001;
                case "MM002": return MyLanguge.Error.MM002;
                case "MM003": return MyLanguge.Error.MM003;
                case "EI001": return MyLanguge.Error.EI001;
                case "EI101": return MyLanguge.Error.EI101;
                case "EI102": return MyLanguge.Error.EI102;
                case "EI201": return MyLanguge.Error.EI201;
                case "EI202": return MyLanguge.Error.EI202;
                case "EI203": return MyLanguge.Error.EI203;
                case "EI204": return MyLanguge.Error.EI204;
                case "ED001": return MyLanguge.Error.ED001;
                case "ED002": return MyLanguge.Error.ED002;
                case "ED101": return MyLanguge.Error.ED101;
                case "ED102": return MyLanguge.Error.ED102;
                case "ED103": return MyLanguge.Error.ED103;
                case "ED104": return MyLanguge.Error.ED104;
                case "ED105": return MyLanguge.Error.ED105;
                case "ED106": return MyLanguge.Error.ED106;
                case "ED201": return MyLanguge.Error.ED201;
                case "ED202": return MyLanguge.Error.ED202;
                case "ED203": return MyLanguge.Error.ED203;
                default: return "Unknown";
            }
        }

        private void ShowErrorMessage(string ErrorCode)     //btnChange_Click MainTest() StartChange()
        {
            if (ErrorCode.Length == 5)
            {
                string tmpError = GetErrorString(ErrorCode);
                if (ErrorCode.StartsWith("E"))          // 输出错误信息
                {
                    MessageBox.Show(ErrorCode + " Error!\n\n" + tmpError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ErrorCode.StartsWith("M"))     // 输出提示信息
                {
                    MessageBox.Show(tmpError, ErrorCode);
                }
            }
            else
            {
                MessageBox.Show("错误：错误代码“" + ErrorCode + "”无法识别", "程序错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DialogResult ShowMessageBox(string txtOutputName)               //显示目标文件重复的提示对话框
        {
            // Initializes the variables to pass to the MessageBox.Show method.

            string message = "目标存档文件“" + txtOutputName + "”已经存在，是否覆盖？";
            string caption = "文件已存在";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            MessageBoxIcon icon = MessageBoxIcon.Exclamation;
            MessageBoxDefaultButton defauleButton = MessageBoxDefaultButton.Button2;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons, icon, defauleButton);

            return result;
        }

        #endregion

        #region 文件输入输出操作（3方法）

        private string[] OpenInputFile()		//打开源存档文件 2017-01-23
        {
            // 打开源存档文件
            string OpenFilter = "";
            OpenFilter += "All Save Files|*.sav;*.bak;*.dat;*.0;*.1;*.2;*.dss;*.dst;*.duc;*.gds;*.sps;*.dsv|";      //2017-01-22
            OpenFilter += "Save Files(*.sav)|*.sav|";
            OpenFilter += "R4 & M3DSS Save BackUp Files(*.bak)|*.bak|";
            OpenFilter += "M3 Save Files(*.dat)|*.dat|";
            OpenFilter += "SC & AK Save Files(*.nds.sav)|*.nds.sav|";
            OpenFilter += "G6 Save Files(*.0;*.1;*.2)|*.0;*.1;*.2|";
            OpenFilter += "Action Replay Max DS(*.dss;*.dst;*.duc)|*.dss;*.dst;*.duc|";
            OpenFilter += "DS-Xploder & Gameshark DS(*.gds)|*.gds|";
            OpenFilter += "Gameshark GBA snapshot(*.sps)|*.sps|";
            OpenFilter += "DeSmuME Battery Saves(*.dsv)|*.dsv|";            //2017-01-22
            OpenFilter += "All Files(*.*)|*.*";

            dialogOpenSaveFile.Filter = OpenFilter;

            string[] strBack = new string[2];                               //2017-01-23

            if (dialogOpenSaveFile.ShowDialog() == DialogResult.OK)         //2017-01-23
            {
                FileInfo myFileInfo = new FileInfo(dialogOpenSaveFile.FileName);
                strBack[0] = myFileInfo.Name;
                strBack[1] = myFileInfo.DirectoryName;
                return (strBack);
            }
            else
            {
                return (strBack);
            }
        }

        public string OpenROMFile()			//打开M3对应的ROM文件
        {
            string OpenFilter = "";

            OpenFilter += "ALL M3 Files(*.nds;*.gba;*.dat)|*.nds;*.gba;*.dat|";
            OpenFilter += "DS ROM Files(*.nds)|*.nds|";
            OpenFilter += "GBA ROM Files(*.gba)|*.gba|";
            OpenFilter += "M3 Save Files(*.dat)|*.dat|";
            OpenFilter += "All Files(*.*)|*.*";

            dialogOpenROM.Filter = OpenFilter;

            if (dialogOpenROM.ShowDialog() == DialogResult.OK)
            {
                return (dialogOpenROM.FileName);
            }
            else
            {
                return ("");
            }
        }

        private string InputToOutput(string tempFileName)		//产生输出的文件名
        {
            if (tempFileName != "")
            {
                int strIndex = tempFileName.LastIndexOf('.');

                if (strIndex >= 0)
                {
                    tempFileName = tempFileName.Substring(0, strIndex);
                }
                return (tempFileName + "." + SelectedCardType.CardSName + SelectedCardType.CardExt);
            }
            else					//源文件为空时，目标文件也要为空
            {
                return ("");
            }
        }

        #endregion

        #region 用户选择（4方法）

        #region 用户选择.类型选择（2）

        private void ChangeMode()      //转换后类型列表
        {
            cboOutputFormat.Items.Clear();

            for (int i = 0; i < CardTypeInfo[cboMode.SelectedIndex].Length; i++)
            {
                cboOutputFormat.Items.Add(CardTypeInfo[cboMode.SelectedIndex][i].CardName);
            }

            cboOutputFormat.Refresh();
            cboOutputFormat.SelectedIndex = 0;
        }

        private void SetSaveSize()		 //转换后存档体积列表，已支持8M存档
        {
            int[] SizeList = new int[10] { (int)( 0.5 * 1024), 8 * 1024, 64 * 1024, 128 * 1024,
                                                  256 * 1024, 512 * 1024, 1024 * 1024, 2 * 1024 * 1024,
                                                  4 * 1024 * 1024, 8 * 1024 * 1024 };
            string[] SizeName = new string[10] { "512 Byte (4K bit) EEPROM", "8K Byte (64K bit) EEPROM", "64K Byte (512K bit) EEPROM",
                                                 "128K Byte (1M bit)", "256K Byte (2M bit) FRAM", "512K Byte (4M bit) FLASH",
                                                 "1M Byte (8M bit) FLASH", "2M Byte (16M bit) FLASH", "4M Byte (32M bit) FLASH",
                                                 "8M Byte (64M bit) FLASH" };
            int UsedIndex = 0;
            string SaveSize = "";

            for (int i = 0; i < 10; i++)
            {
                UsedSize[i] = 0;
            }

            cboOutputSize.Items.Clear();

            SaveSize = SelectedCardType.CardSaveType;

            for (int i = 0; i < 10; i++)
            {
                if (SaveSize[i] == '1')
                {
                    cboOutputSize.Items.Add(SizeName[i]);
                    UsedSize[UsedIndex++] = SizeList[i];
                }
            }

            cboOutputSize.Refresh();
            cboOutputSize.SelectedIndex = SelectedCardType.SelectIndex - 1;
        }

        #endregion

        #region 用户选择.获取用户所做的选择（2）

        private MainFormInfo GetMainInfo()       //2017-01-24
        {
            MainFormInfo mfiTemp = new MainFormInfo
                (
                cboMode.SelectedIndex,
                cboOutputSize.SelectedIndex,
                txtSavePath.Text + txtInput.Text,       //2017-01-24
                txtSavePath.Text + txtOutput.Text,      //2017-01-24
                txtM3LongName.Text,
                txtM3ShortName.Text,
                dialogOpenROM.FileName,
                CardTypeInfo[cboMode.SelectedIndex][cboOutputFormat.SelectedIndex].CardIs,
                chkM3DatFile.Checked,
                chkPokemon.Checked
                );
            return mfiTemp;
        }

        private CardClass SelectedCardType			//获得所选择转换的烧录卡格式
        {
            get
            {
                return CardTypeInfo[cboMode.SelectedIndex][cboOutputFormat.SelectedIndex];
            }
        }

        #endregion

        #endregion

        #region 显示源存档测试结果（2方法）

        private void MainTest()                   //2017-01-24
        {
            InputFileInfo testMode = new InputFileInfo(txtSavePath.Text + txtInput.Text);   //2017-01-24

            if (testMode.ErrorCode == null)
            {
                ShowTestMap(testMode.TestCode);

                string strTest = testMode.TestString;
                if (cboMode.SelectedIndex == 0)
                {
                    strTest = strTest.Replace("128K", "256K").Replace("256K 256K", "256K");
                }
                ClearMessage();
                ShowMessage(MyLanguge.Message.UsedSize + "\n");     //有用数据可能大小：
                ShowMessage(strTest + "\n");
            }
            else
            {
                ShowErrorMessage(testMode.ErrorCode); //读取源存档时出现错误
            }
        }

        private void ShowTestMap(string strFlag)		//以彩色方式输出测试结果
        {
            Color[] FlagColor = new Color[strFlag.Length];      //strFlag.Length = 8
            Color[] FlagColorMode = new Color[4];
            FlagColorMode[0] = System.Drawing.SystemColors.Control;     // 无数据的颜色
            FlagColorMode[1] = System.Drawing.Color.OrangeRed;          // 有用数据的颜色
            FlagColorMode[2] = System.Drawing.Color.Yellow;             // 无法判断是否是有用数据的颜色
            FlagColorMode[3] = System.Drawing.Color.GreenYellow;        // 无用数据的颜色

            for (int i = 0; i < strFlag.Length; i++)
            {
                FlagColor[i] = FlagColorMode[int.Parse(strFlag[i].ToString())];
            }

            lblTest512B.BackColor = FlagColor[0];
            lblTest8K.BackColor = FlagColor[1];
            lblTest64K.BackColor = FlagColor[2];
            lblTest128K.BackColor = FlagColor[3];
            lblTest256K.BackColor = FlagColor[4];
            lblTest512K.BackColor = FlagColor[5];
            lblTest1M.BackColor = FlagColor[6];
            lblTestEEPROM.BackColor = FlagColor[FlagColor.Length - 1];      //FlagColor[7]
        }

        #endregion

        #region  转换程序（1方法）

        private void StartChange()      // 判断源存档格式，选取不同的转换方式
        {
            MainFormInfo mfiMainInfo = GetMainInfo();                               // 获取主界面信息
            InputFileInfo ifiFileMode = new InputFileInfo(mfiMainInfo.InputName);   // 获取源存档信息

            if (ifiFileMode.ErrorCode == null)
            {
                myAllControl(false);
                if (mfiMainInfo.PokemonChecked)
                {
                    ShowMessage(MyLanguge.Message.Pokemon + "\n");    //口袋妖怪强制转换：
                    string[] temp = WriteData.PokemonChange(ifiFileMode, mfiMainInfo.OutputName);
                    if (temp[0] == null)
                    {
                        ShowPokemonMessage(temp);
                    }
                    else
                    {
                        ShowErrorMessage(temp[0]);
                    }
                }
                else
                {
                    string[] temp = WriteData.MainChange(ifiFileMode, mfiMainInfo, UsedSize);
                    if (temp[0] == null)
                    {
                        ShowMainMessage(temp);
                    }
                    else
                    {
                        ShowErrorMessage(temp[0]);
                    }
                }
                myAllControl(true);
            }
            else
            {
                ShowErrorMessage(ifiFileMode.ErrorCode); //读取源存档时出现错误
            }
        }

        #endregion
    }
}