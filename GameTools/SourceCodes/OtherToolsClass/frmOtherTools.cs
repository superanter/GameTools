using System;
using System.IO;
using System.Windows.Forms;

namespace AnterStudio.GameTools.OtherToolsClass
{
    public partial class frmOtherTools : Form
    {
        private SoftVersionClass.SoftVersion MyVersion;

        public frmOtherTools()
        {
            InitializeComponent();
        }

        public frmOtherTools(string language, SoftVersionClass.SoftVersion VersionPack)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);

            InitializeComponent();
            //MyLanguge = LangugePack;
            MyVersion = VersionPack;
            //SetLanguge();
            this.Text += " " + MyVersion.Version;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region StarCraft SN

        /// <summary>
        /// 计算StarCraft的序列号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSCSN_In_TextChanged(object sender, EventArgs e)
        {
            if (txtSCSN_In.Text.Length == 12)
            {
                int x = 3;
                string strInput = txtSCSN_In.Text;

                for (int i = 0; i < 12; i++)
                {
                    x += (2 * x) ^ int.Parse(strInput.Remove(0, i).Remove(1, 12 - i - 1));
                }
                int lastDigit = x % 10;

                txtSCSN_Out.Text = "SN: " + strInput.Remove(4, 8) + "-" + strInput.Remove(0, 4).Remove(5, 3)
                    + "-" + strInput.Remove(0, 9) + lastDigit.ToString();
            }
            else
            {
                txtSCSN_Out.Text = "";
            }

            //e.g. 1234-56789-1234
            //e.g. 1234-56789-0123
        }

        #endregion

        #region MAME

        private string OpenInputFile(string strInput)
        {
            string OpenFilter = "";

            OpenFilter += strInput;
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

        private void btnXml_Click(object sender, EventArgs e)
        {
            int iGames = 0;
            string myString = OpenInputFile("XML Files|*.xml|");

            if (myString != "")
            {
                this.Enabled = false;
                string[] lines = File.ReadAllLines(myString);
                string[] outs1 = new string[lines.Length];
                int j = 0;

                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = lines[i].Replace("\t", "");
                    if (lines[i].Length > 15)
                    {
                        if (lines[i].Substring(0, 8) == "<machine")
                        {
                            if (lines[i].IndexOf("isdevice=\"yes\"") == -1)
                            {
                                outs1[j++] = "Game\t\"" + lines[i].Split('\"')[1] + "\"";
                                iGames++;
                            }
                            else
                            {
                                outs1[j++] = "Device\t\"" + lines[i].Split('\"')[1] + "\"";
                            }
                        }
                        else if (lines[i].Substring(0, 8) == "<descrip")
                        {
                            outs1[j++] = lines[i].Replace("<description>", "\"").Replace("</description>", "\"");
                        }

                    }
                }

                string[] outs2 = new string[j / 2];
                for (int i = 0; i < outs2.Length; i++)
                {
                    outs2[i] = outs1[i * 2] + "\t" + outs1[i * 2 + 1];
                }
                System.IO.File.WriteAllLines(myString + ".txt", outs2);
                MessageBox.Show("OK, " + iGames + " games, and " + outs2.Length + " lines out.");
                iGames = 0;
                this.Enabled = true;
            }
        }

        private void btnPrn_Click(object sender, EventArgs e)
        {
            string myString = OpenInputFile("PRN Files|*.prn|");

            if (myString != "")
            {
                this.Enabled = false;
                FileStream fileStream = new FileStream(myString, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader(fileStream);
                long length = fileStream.Length;
                byte[] bytes = new byte[length];
                binaryReader.Read(bytes, 0, bytes.Length);
                binaryReader.Close();
                fileStream.Close();

                for (int i = 0; i < bytes.Length; i++)
                {
                    if (bytes[i] > 0x80)
                    {
                        bytes[i] = Convert.ToByte(bytes[i] - 0x80);
                    }
                }

                FileStream fileStream2 = new FileStream(myString + ".txt", FileMode.Create);
                BinaryWriter binaryWriter = new BinaryWriter(fileStream2);
                binaryWriter.Write(bytes);
                binaryWriter.Close();
                fileStream2.Close();
                MessageBox.Show("OK");
                this.Enabled = true;
            }
        }

        #endregion
    }
}
