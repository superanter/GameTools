using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AnterStudio.GameTools.JoyConClass
{
    public partial class frmJoyCon : Form
    {
        string FileFullName;

        public frmJoyCon()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            FileFullName = OpenInputFile();

            JoyConFirmwave aa = new JoyConFirmwave(File.ReadAllBytes(FileFullName));

            label1.Text = BitConverter.ToString(aa.MACData).Replace("-", ":");
            label2.Text = BitConverter.ToString(aa.FactorConfiguration.DataG).Replace("-", " ").Remove(2,1).Remove(4,1).Remove(9, 1).Remove(11, 1).Remove(16, 1).Remove(18, 1).Remove(23, 1).Remove(25, 1);
            label3.Text = Encoding.ASCII.GetString(aa.FactorConfiguration.DataA).Replace("\0", " ");
                this.Refresh();

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

    

    }



}
