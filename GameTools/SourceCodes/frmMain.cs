using System;
using System.Windows.Forms;

namespace AnterStudio.GameTools
{
    public partial class frmMain : Form
    {
        private LangugePackClass MyLangugePack;
        private SoftVersionClass MyVersionPack;

        #region  构造函数（1方法）

        public frmMain()
        {
            InitializeComponent();
        }
        #endregion

        #region  控件（8方法）

        #region  控件.主窗口（1方法）

        private void MainForm_Load(object sender, EventArgs e)
        {
            VersionLoad();
            LangugeLoad();
        }

        #endregion

        #region  控件.按钮（10方法）

        private void btnWiiSave_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            WiiSaveClass.frmWiiSave WiiForm = new WiiSaveClass.frmWiiSave(MyLangugePack.WiiSave, MyVersionPack.WiiSaveVersion);
            if (WiiForm.ShowDialog(this) == DialogResult.OK)
            {
                //We would apply changes here since the user accepted them
            }
            WiiForm.Dispose();
            this.Visible = true;
        }

        private void btnDsSave_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            DsSaveClass.frmDsSave DsForm = new DsSaveClass.frmDsSave(MyLangugePack.DsSave, MyVersionPack.DsSaveVersion);
            if (DsForm.ShowDialog(this) == DialogResult.OK)
            {
                //We would apply changes here since the user accepted them
            }
            DsForm.Dispose();
            this.Visible = true;
        }

        private void btnSwitchSave_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            SwitchSaveClass.frmSwitchSave SwitchSaveForm = new SwitchSaveClass.frmSwitchSave(MyLangugePack.SwitchSave, MyVersionPack.SwitchSaveVersion);
            if (SwitchSaveForm.ShowDialog(this) == DialogResult.OK)
            {
                //We would apply changes here since the user accepted them
            }
            SwitchSaveForm.Dispose();
            this.Visible = true;
        }

        private void btnDsRom_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            DsRomClass.frmDsRom DsRomForm = new DsRomClass.frmDsRom(MyLangugePack.DsRom, MyVersionPack.DsRomVersion);
            if (DsRomForm.ShowDialog(this) == DialogResult.OK)
            {
                //We would apply changes here since the user accepted them
            }
            DsRomForm.Dispose();
            this.Visible = true;
        }
        private void btnMAME_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            MameClass.frmMame MameForm = new MameClass.frmMame(MyLangugePack.Mame,MyVersionPack.MameVersion);
            if (MameForm.ShowDialog(this) == DialogResult.OK)
            {
                //We would apply changes here since the user accepted them
            }
            MameForm.Dispose();
            this.Visible = true;
        }

        private void btnAmiibo_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            AmiiboClass.frmAmiibo AmiiboForm = new AmiiboClass.frmAmiibo(MyLangugePack.Amiibo, MyVersionPack.AmiiboVersion);
            if (AmiiboForm.ShowDialog(this) == DialogResult.OK)
            {
                //We would apply changes here since the user accepted them
            }
            AmiiboForm.Dispose();
            this.Visible = true;
        }
        private void btnOther_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            OtherToolsClass.frmOtherTools OtherForm = new OtherToolsClass.frmOtherTools(MyLangugePack.OtherTools, MyVersionPack.OtherToolsVersion);
            if (OtherForm.ShowDialog(this) == DialogResult.OK)
            {
                //We would apply changes here since the user accepted them
            }
            OtherForm.Dispose();
            this.Visible = true;
        }

        private void btnJoyCon_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            JoyConClass.frmJoyCon JoyConForm = new JoyConClass.frmJoyCon(MyLangugePack.JoyCon, MyVersionPack.JoyConVersion);
            if (JoyConForm.ShowDialog(this) == DialogResult.OK)
            {
                //We would apply changes here since the user accepted them
            }
            JoyConForm.Dispose();
            this.Visible = true;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            frmAboutBox AbtForm = new frmAboutBox();
            if (AbtForm.ShowDialog(this) == DialogResult.OK)
            {
                //We would apply changes here since the user accepted them
            }
            AbtForm.Dispose();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }





        #endregion

        #endregion

        #region 版本和语言初始化 (2)

        private void VersionLoad()
        {
            MyVersionPack = new SoftVersionClass();

            lblDsSave.Text = MyVersionPack.DsSaveVersion.EditDate;
            lblWiiSave.Text = MyVersionPack.WiiSaveVersion.EditDate;
            lblSwitchSave.Text = MyVersionPack.SwitchSaveVersion.EditDate;
            lblDsRom.Text = MyVersionPack.DsRomVersion.EditDate;

            lblAmiibo.Text = MyVersionPack.AmiiboVersion.EditDate;
            lblOtherTools.Text = MyVersionPack.OtherToolsVersion.EditDate;
            lblMame.Text = MyVersionPack.MameVersion.EditDate;
            lblJoyCon.Text = MyVersionPack.JoyConVersion.EditDate;
        }

        private void LangugeLoad()
        {
            MyLangugePack = new LangugePackClass();
            LangugePackClass.cMainForm MyMainForm = MyLangugePack.MainForm;
            if (MyLangugePack.IsFromINI)
            {
                toolStripStatusLabel1.Text = MyMainForm.Form.Languge + " " + MyMainForm.Form.Version + " by " + MyMainForm.Form.Editer;
                this.Text = MyLangugePack.MainForm.Form.Title + " " + MyVersionPack.MainVersion.Version;
            }
            else
            {
                toolStripStatusLabel1.Text = "";
            }
        }

        #endregion
    }
}
