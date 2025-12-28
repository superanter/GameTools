using System;
using System.IO;
using System.Windows.Forms;


namespace AnterStudio.GameTools.DsRomClass
{
    public partial class frmDsRom : Form
    {
        private SoftVersionClass.SoftVersion MyVersion;

        #region 构造函数（2方法）

        public frmDsRom()         //2017-01-23
        {
            InitializeComponent();
        }

        public frmDsRom(string language, SoftVersionClass.SoftVersion VersionPack)         //2017-08-02
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);
            InitializeComponent();
            MyVersion = VersionPack;

        }

        #endregion

        #region 控件（3方法）

        private void btnBack_Click(object sender, EventArgs e)      //2017-01-23
        {
            Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)      //2017-01-25
        {
            string strFileName = OpenDsRomFile();
            if (strFileName != "")
            {
                FileInfo RomInfo = new FileInfo(strFileName);
                txtName.Text = RomInfo.Name.ToString();
                txtSize.Text = ((RomInfo.Length) / 1024 / 1024).ToString() + "MB";
                string[] strGameInfo = GetRomMessage(strFileName);
                txtGameName.Text = strGameInfo[1];
                txtGameText.Text = strGameInfo[2];
                txtGameType.Text = strGameInfo[0];
            }
        }

        #endregion

        #region  其它方法（3方法）

        private string OpenDsRomFile()		//打开源Rom文件          2017-02-04
        {
            string OpenFilter = "";
            OpenFilter += "DS & GBA Rom Files|*.nds;*.gba";
            OpenFilter += "|DS Rom Files(*.nds)|*.nds";
            OpenFilter += "|GBA Rom Files(*.gba)|*.gba";
            openFileDialogDsRom.Filter = OpenFilter;
            try
            {
                if (openFileDialogDsRom.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialogDsRom.FileName;
                }
            }
            catch { }
            return "";
        }

        private string[] GetRomMessage(string strRomFileName)       //2017-01-25
        {
            string[] RomInfo = new string[3];
            try
            {
                FileInfo myInfo = new FileInfo(strRomFileName);
                FileStream sri = new FileStream(strRomFileName, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(sri);
                if (myInfo.Extension.ToLower() == ".gba")
                {
                    r.ReadBytes(160);
                    RomInfo[0] = "GBA";
                }
                else if (myInfo.Extension.ToLower() == ".nds")
                {
                    RomInfo[0] = "NDS";
                }
                else
                {
                    RomInfo[0] = "UnKnown";
                }

                RomInfo[1] = new string(r.ReadChars(12));
                RomInfo[2] = new string(r.ReadChars(6));
            }
            catch
            {
            }

            return RomInfo;
        }

        #endregion

        private void frmDsRom_Load(object sender, EventArgs e)
        {
            this.Text += " " + MyVersion.Version;
        }
    }
}
