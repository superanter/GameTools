using System;
using System.Windows.Forms;

namespace AnterStudio.GameTools
{
    public partial class frmMain : Form
    {
        private SoftVersionClass MyVersionPack;
        private string language = "zh-CN";

        #region  构造函数（1方法）

        public frmMain()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);

            InitializeComponent();
        }
        #endregion

        #region  控件.其它（2方法）

        private void MainForm_Load(object sender, EventArgs e)
        {
            VersionLoad();
            cboLanguage.SelectedIndex = 0;
        }

        private void cboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            language = cboLanguage.SelectedItem.ToString();
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);
            btnAbout.Text = ApplyResource(this.GetType(), "btnAbout.Text");
            btnExit.Text = ApplyResource(this.GetType(), "btnExit.Text");
        }
        #endregion

        #region  控件.按钮（8方法）
        private void btnWiiSave_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            WiiSaveClass.frmWiiSave WiiForm = new WiiSaveClass.frmWiiSave(language, MyVersionPack.WiiSaveVersion);
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
            DsSaveClass.frmDsSave DsForm = new DsSaveClass.frmDsSave(language, MyVersionPack.DsSaveVersion);
            if (DsForm.ShowDialog(this) == DialogResult.OK)
            {
                //We would apply changes here since the user accepted them
            }
            DsForm.Dispose();
            this.Visible = true;
        }
        private void btnDsRom_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            DsRomClass.frmDsRom DsRomForm = new DsRomClass.frmDsRom(language, MyVersionPack.DsRomVersion);
            if (DsRomForm.ShowDialog(this) == DialogResult.OK)
            {
                //We would apply changes here since the user accepted them
            }
            DsRomForm.Dispose();
            this.Visible = true;
        }
        private void btnAmiibo_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            AmiiboClass.frmAmiibo AmiiboForm = new AmiiboClass.frmAmiibo(language, MyVersionPack.AmiiboVersion);
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
            OtherToolsClass.frmOtherTools OtherForm = new OtherToolsClass.frmOtherTools(language, MyVersionPack.OtherToolsVersion);
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
            JoyConClass.frmJoyCon JoyConForm = new JoyConClass.frmJoyCon(language, MyVersionPack.JoyConVersion);
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

        #region 版本和语言初始化 (2方法)

        private void VersionLoad()
        {
            MyVersionPack = new SoftVersionClass();

            this.Text += " " + MyVersionPack.MainVersion.Version;

            lblDsSave.Text = MyVersionPack.DsSaveVersion.EditDate;
            lblWiiSave.Text = MyVersionPack.WiiSaveVersion.EditDate;
            lblDsRom.Text = MyVersionPack.DsRomVersion.EditDate;

            lblAmiibo.Text = MyVersionPack.AmiiboVersion.EditDate;
            lblOtherTools.Text = MyVersionPack.OtherToolsVersion.EditDate;
            lblJoyCon.Text = MyVersionPack.JoyConVersion.EditDate;
        }

        public static string ApplyResource(Type resourceObject, string Name)
        {
            System.Resources.ResourceManager resoure = new System.Resources.ResourceManager(resourceObject);
            return resoure.GetString(Name);
        }

        #endregion

    }
}
