using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AnterStudio.GameTools.JoyConClass
{
    public partial class frmJoyCon : Form
    {
        private LangugePackClass.cJoyCon MyLanguge;
        private SoftVersionClass.SoftVersion MyVersion;

        string FileFullName;

        public frmJoyCon()
        {
            InitializeComponent();
        }

        public frmJoyCon(LangugePackClass.cJoyCon LangugePack, SoftVersionClass.SoftVersion VersionPack)
        {
            InitializeComponent();
            MyLanguge = LangugePack;
            MyVersion = VersionPack;
        }


        private void btnOpen_Click(object sender, EventArgs e)
        {
            FileFullName = OpenInputFile();

            JoyConFirmwave aa = new JoyConFirmwave(File.ReadAllBytes(FileFullName));

            byte[] MacTemp = new byte[aa.MACData.Length];
            for (int i = 0; i < aa.MACData.Length; i++)
            {
                MacTemp[aa.MACData.Length - 1 - i] = aa.MACData[i];
            }

            label1.Text = BitConverter.ToString(MacTemp).Replace("-", ":");

            label2.Text = Encoding.ASCII.GetString(aa.FactorConfiguration.DataA).Replace("\0", " ");
            label3.Text = BitConverter.ToString(aa.FactorConfiguration.DataB).Replace("-", " ");
            label4.Text = BitConverter.ToString(aa.FactorConfiguration.DataC).Replace("-", " ");
            label5.Text = BitConverter.ToString(aa.FactorConfiguration.DataD).Replace("-", " ");
            label6.Text = BitConverter.ToString(aa.FactorConfiguration.DataE).Replace("-", " ");
            label7.Text = BitConverter.ToString(aa.FactorConfiguration.DataF).Replace("-", " ");
            label8.Text = BitConverter.ToString(aa.FactorConfiguration.DataG).Replace("-", " ").Remove(2, 1).Remove(4, 1).Remove(9, 1).Remove(11, 1).Remove(16, 1).Remove(18, 1).Remove(23, 1).Remove(25, 1);
            label9.Text = BitConverter.ToString(aa.FactorConfiguration.DataH).Replace("-", " "); ;
            label10.Text = BitConverter.ToString(aa.FactorConfiguration.DataI).Replace("-", " "); ;

            //this.Refresh();

        }

        /// <summary>
        /// 打开bin文件 2017-08-01
        /// </summary>
        /// <returns></returns>
        private string OpenInputFile()
        {
            string OpenFilter = "";

            OpenFilter += "JoyCon Fire bin Files|*.bin|";
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

        private void frmJoyCon_Load(object sender, EventArgs e)
        {
            SetLanguge();
        }

        private void SetLanguge()
        {
            this.Text = MyLanguge.Form.Title + " " + MyVersion.Version;
            btnOpen.Text = MyLanguge.Button.Read;
        }
    }



}
