using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;                        //FileInfo 2017-07-31

namespace AnterStudio.GameTools.AmiiboClass
{
    public partial class frmAmiibo : Form
    {
        private LangugePackClass.cAmiibo MyLanguge;
        private SoftVersionClass.SoftVersion MyVersion;
        private AmiiboFileMessage myFileMessage;


        public frmAmiibo()
        {
            InitializeComponent();
        }

        public frmAmiibo(LangugePackClass.cAmiibo LangugePack, SoftVersionClass.SoftVersion VersionPack)
        {
            InitializeComponent();
            MyLanguge = LangugePack;
            MyVersion = VersionPack;
            SetLanguge();
        }
        #region 控件(8个Button，1个LinkLable）

        #region 按键（8）

        /// <summary>
        /// 打开文件按键 2017-08-01
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            btnTo540.Enabled = false;
            string myString = OpenInputFile();

            if (myString != "")
            {
                myFileMessage = new AmiiboFileMessage(myString);
                ShowFileMessage();
                ShowFileMessage2();
                ShowBytes(myFileMessage.AmiiboDataNew);
                if (myFileMessage.Lengh != 540)
                {
                    btnTo540.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 文件改名按键 2017-08-01
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRename_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text != "" && txtNewFileName.Text != "")
            {
                string oldStr = myFileMessage.FullName;
                string newStr = newStr = myFileMessage.DirectoryName + "\\" + txtNewFileName.Text;

                string MessageTemp = MyRename(oldStr, newStr,true);

                if (MessageTemp == "")
                {
                    MessageBox.Show(MyLanguge.Message.OK);
                    this.txtFileName.Text = txtNewFileName.Text;
                    btnTo540.Enabled = false;
                    myFileMessage = new AmiiboFileMessage(newStr);
                    ShowFileMessage();
                }
                else
                {
                    MessageBox.Show(MessageTemp);
                }
            }
        }

        /// <summary>
        /// 改为540按键 2017-08-01
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTo540_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text != "")
            {
                if (File.Exists(myFileMessage.FullName))
                {
                    if (myFileMessage.Name == txtFileName.Text)
                    {
                        try
                        {
                            ChangeSize(myFileMessage.FullName);
                            MessageBox.Show(MyLanguge.Message.OK);
                        }
                        catch
                        {
                            MessageBox.Show(MyLanguge.Message.Error_To540);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 返回按键 2017-08-02
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 产生列表按钮 2017-08-08
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnList_Click(object sender, EventArgs e)
        {
            GetList();
        }

        /// <summary>
        /// 批量重命名按钮 2017-08-08
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRenameAll_Click(object sender, EventArgs e)
        {
            AllRename();
        }

        /// <summary>
        /// 按照MCAS的文件CRC32校验，并按照MCAS命名规则命名  2017-08-13
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMcasName_Click(object sender, EventArgs e)
        {
            AllMCAS();
        }

        /// <summary>
        /// 打开浏览器，显示图片  2017-08-16
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPicture_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(myFileMessage.PicturePath);
            }
            catch { }
        }

        #endregion

        #region LinkLable（1）

        /// <summary>
        /// 转到浏览器 2017-08-01
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(myFileMessage.NetPath);
        }

        #endregion

        #endregion

        #region  其他方法 (3)

        /// <summary>
        /// 在信息输出框上显示信息 2017-08-08
        /// </summary>
        /// <param name="strOutput"></param>
        private void ShowMessage(string strOutput)
        {
            if(strOutput == "")
            {
                lblMessage.Text = "";
            }
            else if (strOutput == "_RESET")
            {
                txtFileName.Text = myFileMessage.Name;
                txtNewFileName.Text = myFileMessage.NewName;
                linkURL.Text = myFileMessage.NetPath;
                linkURL.Visible = true;
                linkURL.LinkVisited = true;
            }
            else
            {
                lblMessage.Text += strOutput;
            }
        }

        /// <summary>
        /// 在界面上显示文件内信息 2017-08-03
        /// </summary>
        /// <param name="FileFullName"></param>
        private void ShowFileMessage()
        {
            ShowMessage("_RESET");

            ShowMessage("");

            string strSerAB = myFileMessage.SerA + myFileMessage.SerB;

            ShowMessage("Ser: " + myFileMessage.SerA + "-" + myFileMessage.SerB + "\n");
            ShowMessage("NTAG 215 ID: " + myFileMessage.NTAG_ID + "\n");
            ShowMessage("Size: " + myFileMessage.Lengh + "Bytes\n");
            //ShowMessage("Main Number: " + myFileMessage.MainNumber + "\n");
            ShowMessage("Amiibo Series: " + myFileMessage.AmiiboSeries + "\n");
            ShowMessage("Game Short Name: " + myFileMessage.IdMessage.GameShortName + "\n");
            ShowMessage("Type: " + myFileMessage.IdMessage.GameType + "\n");
            ShowMessage("Name: " + myFileMessage.IdMessage.AmiiboName + "\n");
            ShowMessage("Number: " + myFileMessage.IdMessage.Number + "\n");
            ShowMessage("CRC32: " + myFileMessage.CRC32 + "\n");
            ShowMessage("01~04: " + strSerAB.Remove(4) + ": " + myFileMessage.IdMessage.Ser01to03string + " - " +myFileMessage.IdMessage.Ser01to04string + "\n");
            ShowMessage("05~06:   " + strSerAB.Remove(0, 4).Remove(2) + ": " + myFileMessage.IdMessage.Ser05to06string + "\n");
            ShowMessage("07~08:   " + strSerAB.Remove(0, 6).Remove(2) + ": " + myFileMessage.IdMessage.Ser07to08string + "\n");
            ShowMessage("09~12: " + strSerAB.Remove(0, 8).Remove(4) + ": " + myFileMessage.IdMessage.Ser09to12stringA + " - " + myFileMessage.IdMessage.Ser09to12stringB + "\n");
            ShowMessage("13~14:   " + strSerAB.Remove(0, 12).Remove(2) + ": " + myFileMessage.IdMessage.Ser13to14string + "\n");
            ShowMessage("15~16:   " + strSerAB.Remove(0, 14) + ": " + myFileMessage.IdMessage.Ser15to16string + "\n");
            ShowMessage("MCAS Name:   " + myFileMessage.McasName + "\n");
        }

        /// <summary>
        /// 输出十六进制内容 2017-08-28
        /// </summary>
        /// <param name="myBytes"></param>
        private void ShowBytes(byte[] myBytes)
        {
            string strBytesOut = "";
            strBytesOut += "    00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F\r\n";
            strBytesOut += "    -----------------------------------------------\r\n";
            for (int i = 0; i < myBytes.Length; i++)
            {
                if (i % 16 == 0)
                {
                    strBytesOut += String.Format("{0:X2}", i / 16) + ": ";
                }
                strBytesOut += String.Format("{0:X2}", myBytes[i]);
                if (i % 16 != 15)
                {
                    strBytesOut += " ";
                }
                else
                {
                    strBytesOut += "\r\n";
                }

            }
            strBytesOut += "\r\n    -----------------------------------------------\r\n";
            strBytesOut += "    00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F\r\n";
            this.ricOut.Text = strBytesOut;
        }

        /// <summary>
        /// 变更界面语言要素 2017-08-02
        /// </summary>
        private void SetLanguge()
        {
            this.Text = MyLanguge.Form.Title + " " + MyVersion.Version;
            this.btnBack.Text = MyLanguge.Button.GoBack;
            this.btnOpen.Text = MyLanguge.Button.Open;
            this.btnTo540.Text = MyLanguge.Button.To540;
            this.btnRename.Text = MyLanguge.Button.Rename;
            this.lblURL.Text = MyLanguge.Lable.LinkURL;
            this.btnList.Text = MyLanguge.Button.List;
            this.btnRenameAll.Text = MyLanguge.Button.RenameAll;
        }

        /// <summary>
        /// 在界面上显示文件内信息2 2017-08-03
        /// </summary>
        /// <param name="FileFullName"></param>
        private void ShowFileMessage2()
        {
            lblMessage2.Text = "";
            lblMessage2.Text += "NFC_ID: " + myFileMessage.Nfc_Message.NFC_ID.ToString() + "\n";
            lblMessage2.Text += "Character_ID: " + myFileMessage.Nfc_Message.Character_ID.ToString() + "\n";
            lblMessage2.Text += "GameSeries_ID: " + myFileMessage.Nfc_Message.GameSeries_ID.ToString() + "\n";
            lblMessage2.Text += "\n";
            lblMessage2.Text += "Amiibo_Nickname: " + myFileMessage.Nfc_Message.Amiibo_Nickname.ToString() + "\n";
            lblMessage2.Text += "\n";
            lblMessage2.Text += "Amiibo_Mii_Nickname: " + myFileMessage.Nfc_Message.Amiibo_Mii_Nickname.ToString() + "\n";
            lblMessage2.Text += "\n";
            lblMessage2.Text += "Amiibo_Write_Counter: " + myFileMessage.Nfc_Message.Amiibo_Write_Counter.ToString() + "\n";
            lblMessage2.Text += "Amiibo_AppID: " + myFileMessage.Nfc_Message.Amiibo_AppID.ToString() + "\n";
            lblMessage2.Text += "Amiibo_Initialized_AppID: " + myFileMessage.Nfc_Message.Amiibo_Initialized_AppID.ToString() + "\n";
            lblMessage2.Text += "Amiibo_Country: " + myFileMessage.Nfc_Message.Amiibo_Country.ToString() + "\n";
            lblMessage2.Text += "Amiibo_Initialize_UserData: " + myFileMessage.Nfc_Message.Amiibo_Initialize_UserData.ToString() + "\n";
            lblMessage2.Text += "Amiibo_LastModifiedDate: " + myFileMessage.Nfc_Message.Amiibo_LastModifiedDate.ToString() + "\n";

            lblSsbTp.Text = "";
            lblSsbTp.Text += "TP_APP_DATA: " + myFileMessage.msgTP.APP_DATA + "\n";
            lblSsbTp.Text += "TP_LEVEL: " + myFileMessage.msgTP.LEVEL + "\n";
            lblSsbTp.Text += "TP_HEARTS: " + (((float)(myFileMessage.msgTP.HEARTS * 25)) / 100).ToString() + "\n";
            lblSsbTp.Text += "\n";
            lblSsbTp.Text += "SSB_APP_DATA: " + myFileMessage.msgSSB.APP_DATA + "\n";
            lblSsbTp.Text += "APPEARANCE: " + myFileMessage.msgSSB.APPEARANCE + "\n";
            lblSsbTp.Text += "SSB_LEVEL: " + myFileMessage.msgSSB.LEVEL + "\n";
            lblSsbTp.Text += "SPECIAL_NEUTRAL: " + myFileMessage.msgSSB.SPECIAL_NEUTRAL + "\n";
            lblSsbTp.Text += "SPECIAL_SIDE_TO_SIDE: " + myFileMessage.msgSSB.SPECIAL_SIDE_TO_SIDE + "\n";
            lblSsbTp.Text += "SPECIAL_UP: " + myFileMessage.msgSSB.SPECIAL_UP + "\n";
            lblSsbTp.Text += "SPECIAL_DOWN: " + myFileMessage.msgSSB.SPECIAL_DOWN + "\n";
            lblSsbTp.Text += "STATS_ATTACK: " + myFileMessage.msgSSB.STATS_ATTACK + "\n";
            lblSsbTp.Text += "STATS_DEFENSE: " + myFileMessage.msgSSB.STATS_DEFENSE + "\n";
            lblSsbTp.Text += "STATS_SPEED: " + myFileMessage.msgSSB.STATS_SPEED + "\n";
            lblSsbTp.Text += "BONUS_EFFECT1: " + myFileMessage.msgSSB.BONUS_EFFECT1 + "\n";
            lblSsbTp.Text += "BONUS_EFFECT2: " + myFileMessage.msgSSB.BONUS_EFFECT2 + "\n";
            lblSsbTp.Text += "BONUS_EFFECT3: " + myFileMessage.msgSSB.BONUS_EFFECT3 + "\n";
        }

        #endregion

        #region 按键指定方法 (6)

        /// <summary>
        /// 打开bin文件 2017-08-01
        /// </summary>
        /// <returns></returns>
        private string OpenInputFile()
        {
            string OpenFilter = "";

            OpenFilter += "Amiibo bin Files|*.bin|";
            OpenFilter += "All Files(*.*)|*.*";
            try
            {
                OpenFileDialog dialogOpenFile = new OpenFileDialog();
                dialogOpenFile.Filter = OpenFilter;
                if (dialogOpenFile.ShowDialog() == DialogResult.OK)
                {
                    return dialogOpenFile.FileName;
                }
            }
            catch { }
            return "";
        }

        /// <summary>
        /// 单个文件改名 2017-09-29
        /// </summary>
        /// <param name="oldStr"></param>
        /// <param name="newStr"></param>
        ///  <param name="isTest">是否校验</param>
        private string MyRename(string oldStr ,string newStr,bool isTest)
        {
            try
            {
                if (!File.Exists(newStr))
                {
                    AmiiboFileMessage myFileMessageTemp = new AmiiboFileMessage(oldStr);

                    if(isTest)          //2017-09-29
                    {
                        if (myFileMessageTemp.IdMessage.GameShortName != "")
                        {
                            FileInfo fi = new FileInfo(oldStr);
                            fi.MoveTo(newStr);
                        }
                        else
                        {
                            return (MyLanguge.Message.Error_FileError);
                        }
                    }
                    else
                    {
                        FileInfo fi = new FileInfo(oldStr);
                        fi.MoveTo(newStr);
                    }
                }
                else
                {
                    return (MyLanguge.Message.Error_FileExists);
                }
            }
            catch
            {
                return (MyLanguge.Message.Error_Rename);
            }
            return ("");
        }

        /// <summary>
        /// 将文件转为540字节 2017-08-01
        /// </summary>
        /// <param name="FileFullName"></param>
        private void ChangeSize(string FileFullName)
        {
            string FileNewFullName = "";
            if (FileFullName.EndsWith(".bin"))
            {
                FileNewFullName = FileFullName.Remove(FileFullName.Length - 4, 4) + "(540).bin";
            }
            else
            {
                FileNewFullName = FileFullName + "(540).bin";
            }
            FileStream sri = new FileStream(FileFullName, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(sri);
            FileStream sro = new FileStream(FileNewFullName, FileMode.Create);
            BinaryWriter w = new BinaryWriter(sro);

            byte[] bInputBuffer = new byte[sri.Length];

            for (int i = 0; i < bInputBuffer.Length; i++)
            {
                bInputBuffer[i] = (byte)sri.ReadByte();
            }

            if (bInputBuffer.Length > 540)
            {
                for (int i = 0; i < 540; i++)
                {
                    w.Write(bInputBuffer[i]);
                }
            }
            else if (bInputBuffer.Length < 540)
            {
                for (int i = 0; i < bInputBuffer.Length; i++)
                {
                    w.Write(bInputBuffer[i]);
                }
                for (int i = 0; i < 540 - bInputBuffer.Length; i++)
                {
                    sro.WriteByte(0);
                }
            }
            sri.Close();
            sro.Close();
        }

        /// <summary>
        /// 产生列表 2017-08-08
        /// </summary>
        private void GetList()
        {
            //string[] myFileList = new String[2000];



            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = MyLanguge.Button.List + ":" + MyLanguge.Message.ListOpen;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] myFileList = Directory.GetFiles(dialog.SelectedPath, "*.bin", SearchOption.AllDirectories);

                    string strOutFullName = dialog.SelectedPath.ToString() + "\\" + "list.csv";
                    string[] temp = new string[myFileList.Length];

                    for (int i = 0; i < myFileList.Length; i++)
                    {
                        myFileMessage = new AmiiboFileMessage(myFileList[i]);
                        temp[i] = myFileMessage.DirectoryName + "," + myFileMessage.Name + "," + myFileMessage.SerA + "-" + myFileMessage.SerB + ",Head:" + myFileMessage.NTAG_ID + ",CRC32:" + myFileMessage.CRC32;
                    }
                    File.WriteAllLines(strOutFullName, temp, Encoding.UTF8);
                    MessageBox.Show(MyLanguge.Message.OK);
                }
                catch
                {
                    MessageBox.Show(MyLanguge.Message.Error_List);
                }

            }
        }

        /// <summary>
        /// 对某个文件夹下的所有bin文件按照规则重命名 2017-08-08
        /// </summary>
        private void AllRename()
        {
            //string[] myFileList = new String[2000];
            int RenameOK = 0;
            int RenameError = 0;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = MyLanguge.Button.RenameAll + ":" + MyLanguge.Message.ListOpen;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] myFileList = Directory.GetFiles(dialog.SelectedPath, "*.bin", SearchOption.AllDirectories);

                    for (int i = 0; i < myFileList.Length; i++)
                    {
                        AmiiboFileMessage myFileMessageTemp = new AmiiboFileMessage(myFileList[i]);
                        string newStr = myFileMessageTemp.DirectoryName + "\\" + myFileMessageTemp.NewName;
                       string temp = MyRename(myFileMessageTemp.FullName, newStr,true);
                        if (temp == "")
                        {
                            RenameOK++;
                        }
                        else
                        {
                            RenameError++;
                        }
                    }
                    MessageBox.Show(MyLanguge.Message.OK + "  OK:" + RenameOK.ToString() + "  Error:" + RenameError.ToString());
                }
                catch
                {
                    MessageBox.Show(MyLanguge.Message.Error_Rename);
                }
            }
        }

        /// <summary>
        /// 对某个文件夹下的所有bin文件按照MCAS规则重命名 2017-08-13
        /// </summary>
        private void AllMCAS()
        {
            int RenameOK = 0;
            int RenameError = 0;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "MCAS" + ":" + MyLanguge.Message.ListOpen;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] myFileList = Directory.GetFiles(dialog.SelectedPath, "*.bin", SearchOption.AllDirectories);

                    for (int i = 0; i < myFileList.Length; i++)
                    {
                        AmiiboFileMessage myFileMessageTemp = new AmiiboFileMessage(myFileList[i]);
                        string newStr = myFileMessageTemp.DirectoryName + "\\" + myFileMessageTemp.McasName;
                        string temp = MyRename(myFileMessageTemp.FullName, newStr, false);
                        if (temp == "")
                        {
                            RenameOK++;
                        }
                        else
                        {
                            RenameError++;
                        }
                    }
                    MessageBox.Show(MyLanguge.Message.OK + "  OK:" + RenameOK.ToString() + "  Error:" + RenameError.ToString());
                }
                catch
                {
                    MessageBox.Show(MyLanguge.Message.Error_Rename);
                }
            }
        }
        #endregion

        private string ToHexString(byte[] bytes) // 0xae00cf => "AE00CF "
        {
            string hexString = string.Empty;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    strB.Append(bytes[i].ToString("X2"));
                }
                hexString = strB.ToString();
            }
            return hexString;
        }
    }
}
/*
                string url = string.Format(myFileMessage.PicturePath, 5, 123456);
                System.Net.WebRequest webreq = System.Net.WebRequest.Create(url);
                System.Net.WebResponse webres = webreq.GetResponse();
                using (System.IO.Stream stream = webres.GetResponseStream())
                {
                    picBox.Image = Image.FromStream(stream);
                }
*/
