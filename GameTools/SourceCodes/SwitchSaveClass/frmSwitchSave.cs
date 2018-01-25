using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AnterStudio.GameTools.SwitchSaveClass
{
    public partial class frmSwitchSave : Form
    {
        private LangugePackClass.cSwitchSave MyLanguge;
        private SoftVersionClass.SoftVersion MyVersion;

        #region    构造函数（1办法）

        public frmSwitchSave()
        {
            InitializeComponent();
        }

        public frmSwitchSave(LangugePackClass.cSwitchSave LangugePack, SoftVersionClass.SoftVersion VersionPack)
        {
            InitializeComponent();
            MyLanguge = LangugePack;
            MyVersion = VersionPack;
        }


        #endregion

        #region    控件

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        private void frmSwitchSave_Load(object sender, EventArgs e)
        {
            SetLanguge();
        }

        private void SetLanguge()
        {
            this.Text = MyLanguge.Form.Title + " " + MyVersion.Version;
            btnBack.Text = MyLanguge.Button.GoBack;
        }
    }
}
