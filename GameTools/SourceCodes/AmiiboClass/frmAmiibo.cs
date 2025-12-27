using System;
using System.IO;                        //FileInfo 2017-07-31
using System.Text;
using System.Windows.Forms;

namespace AnterStudio.GameTools.AmiiboClass
{
    public partial class frmAmiibo : Form
    {
        private LangugePackClass.cAmiibo MyLanguge;
        private SoftVersionClass.SoftVersion MyVersion;
        private AmiiboFileMessage myFileMessage;
        string FileFullName;


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
            btnRePack.Enabled = false;
        }

        #region 控件(10个Button，1个LinkLable，2个TextBox，2个ComboBox）

        #region 按键（10）

        /// <summary>
        /// 打开文件按键 2017-08-01
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            btnTo540.Enabled = false;
            string myString = OpenInputFile();
            FileFullName = myString;

            if (myString != "")
            {
                myFileMessage = new AmiiboFileMessage(myString);
                ShowFileMessage();
                ShowBytes(myFileMessage.AmiiboDataDecrypted);
                if (myFileMessage.Length != 540)
                {
                    btnTo540.Enabled = true;
                }
                txtNewUID.Text = myFileMessage.NTAG_ID;
                txtNewID.Text = myFileMessage.SerA + myFileMessage.SerB;
                btnRePack.Enabled = false;
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

                string MessageTemp = MyRename(oldStr, newStr, true);

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

        /// <summary>
        /// 重新打包加密到新的文件 2018-03-29
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRePack_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text != "")
            {
                byte[] temp;
                if (myFileMessage.msgTP.canEdit)
                {
                    temp = myFileMessage.RePack(txtNewUID.Text, txtNewID.Text, cboTpLevers.SelectedIndex, cboTpHearts.SelectedIndex);
                }
                else
                {
                    temp = myFileMessage.RePack(txtNewUID.Text, txtNewID.Text, -1, -1);
                }
                FileStream sro = new FileStream(this.FileFullName.Substring(0, this.FileFullName.Length - 4) + "-[" + DateTime.Now.ToString("yyyyMMddHHmmss") + "].bin", FileMode.Create);
                BinaryWriter w = new BinaryWriter(sro);
                w.Write(temp);
                sro.Close();
                MessageBox.Show("OK");
            }
        }

        /// <summary>
        /// 将解密后的数据存储到到新的文件 2018-01-30
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnPack_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text != "")
            {
                FileStream sro = new FileStream(this.FileFullName.Substring(0, this.FileFullName.Length - 4) + "[Decrypted].bin", FileMode.Create);
                BinaryWriter w = new BinaryWriter(sro);
                w.Write(myFileMessage.AmiiboDataDecrypted);
                sro.Close();
                MessageBox.Show("OK");
            }

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

        #region TextBox（2）

        private void txtNewUID_TextChanged(object sender, EventArgs e)
        {
            if (txtFileName.Text != "")
            {
                if (txtNewUID.TextLength == 14)
                {
                    btnRePack.Enabled = true;
                }
                else
                {
                    btnRePack.Enabled = false;
                }
            }

        }

        private void txtNewID_TextChanged(object sender, EventArgs e)
        {
            if (txtFileName.Text != "")
            {
                if (txtNewID.TextLength == 16)
                {
                    btnRePack.Enabled = true;
                }
                else
                {
                    btnRePack.Enabled = false;
                }
            }
        }
        #endregion

        #region ComboBOx（2）

        private void cboTpLevers_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRePack.Enabled = true;
        }

        private void cboTpHearts_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRePack.Enabled = true;
        }

        #endregion

        #endregion

        #region  其他方法 (3)

        /// <summary>
        /// 在界面上显示文件内信息 2018-03-29
        /// </summary>
        /// <param name="FileFullName"></param>
        private void ShowFileMessage()
        {
            txtFileName.Text = myFileMessage.Name;
            txtNewFileName.Text = myFileMessage.NewName;
            linkURL.Text = myFileMessage.NetPath;
            linkURL.Visible = true;
            linkURL.LinkVisited = true;

            ricMessage.Text = "";
            cboTpLevers.Text = "";
            cboTpLevers.Items.Clear();
            cboTpLevers.Refresh();
            cboTpHearts.Text = "";
            cboTpHearts.Items.Clear();
            cboTpHearts.Refresh();
            grpTP.Enabled = false;

            for (int i = 0; i < myFileMessage.myMessage.Length; i++)
            {
                ricMessage.Text += myFileMessage.myMessage[i];
            }
            ricMessage.Text += "-------------------------------------\n";
            for (int i = 0; i < myFileMessage.msgNFC.myMessage.Length; i++)
            {
                ricMessage.Text += myFileMessage.msgNFC.myMessage[i];
            }

            if (myFileMessage.msgTP.canEdit)
            {
                grpTP.Enabled = true;
                cboTpLevers.Items.AddRange(myFileMessage.msgTP.TpLevers);
                cboTpLevers.SelectedIndex = myFileMessage.msgTP.LEVEL;
                cboTpHearts.Items.AddRange(myFileMessage.msgTP.TpHearts);
                cboTpHearts.SelectedIndex = myFileMessage.msgTP.HEARTS;
            }
            else if (myFileMessage.msgSSB.canEdit)
            {
                ricMessage.Text += "-------------------------------------\n";
                ricMessage.Text += "Super Smash Bros:\n";
                for (int i = 0; i < myFileMessage.msgSSB.myMessage.Length; i++)
                {
                    ricMessage.Text += "  " + myFileMessage.msgSSB.myMessage[i];
                }
            }

        }

        /// <summary>
        /// 输出十六进制内容 2022-04-15
        /// </summary>
        /// <param name="myBytes"></param>
        private void ShowBytes(byte[] myBytes)
        {
            string strBytesOut = "";
            strBytesOut += "    00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F\r\n";
            strBytesOut += "    -----------------------------------------------\r\n";
            for (int i = 0; i < myBytes.Length / 0x10; i++)
            {
                strBytesOut += String.Format("{0:X2}", i) + ": ";
                strBytesOut += BitConverter.ToString(myBytes, i * 0x10, 0x10).Replace("-", " ") + "\r\n"; ;
            }
            strBytesOut += String.Format("{0:X2}", myBytes.Length / 0x10) + ": ";
            strBytesOut += BitConverter.ToString(myBytes, myBytes.Length / 0x10 * 0x10, myBytes.Length % 0x10).Replace("-", " ");

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
        private string MyRename(string oldStr, string newStr, bool isTest)
        {
            try
            {
                if (!File.Exists(newStr))
                {
                    AmiiboFileMessage myFileMessageTemp = new AmiiboFileMessage(oldStr);

                    if (isTest)          //2017-09-29
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
                        string temp = MyRename(myFileMessageTemp.FullName, newStr, true);
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
                        string newStr = myFileMessageTemp.DirectoryName + "\\" + myFileMessageTemp.mcasName;
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

    }
}
