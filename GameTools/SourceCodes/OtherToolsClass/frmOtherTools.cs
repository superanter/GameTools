using System;
using System.Windows.Forms;

namespace AnterStudio.GameTools.OtherToolsClass
{
    public partial class frmOtherTools : Form
    {
        private LangugePackClass.cOtherTools MyLanguge;
        private SoftVersionClass.SoftVersion MyVersion;

        public frmOtherTools()
        {
            InitializeComponent();
        }

        public frmOtherTools(LangugePackClass.cOtherTools LangugePack, SoftVersionClass.SoftVersion VersionPack)
        {
            InitializeComponent();
            MyLanguge = LangugePack;
            MyVersion = VersionPack;
            SetLanguge();
        }

        private void SetLanguge()
        {
            this.Text = MyLanguge.Form.Title + " " + MyVersion.Version;
            btnBack.Text = MyLanguge.Button.GoBack;
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
    }
}
