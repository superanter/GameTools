using System;
using System.IO;
using System.Windows.Forms;

namespace AnterStudio.GameTools.WiiSaveClass
{
    public partial class frmWiiSave : Form
    {
        private LangugePackClass.cWiiSave MyLanguge;
        private SoftVersionClass.SoftVersion MyVersion;

        #region 构造函数（1方法）

        public frmWiiSave()
        {
            InitializeComponent();
        }

        public frmWiiSave(LangugePackClass.cWiiSave LangugePack, SoftVersionClass.SoftVersion VersionPack)
        {
            InitializeComponent();
            MyLanguge = LangugePack;
            MyVersion = VersionPack;
        }

        #endregion

        #region 控件（3方法）

        private void btnOpenSave_Click(object sender, EventArgs e)
        {
            OpenWiiSaveFile();
            ReadTest();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmWiiSave_Load(object sender, EventArgs e)
        {
            SetLanguge();
        }

        #endregion

        #region 其他方法（5方法）

        private void OpenWiiSaveFile()		//打开源存档文件
        {
            string OpenFilter = "";
            OpenFilter += "Wii Save Files(*.bin)|*.bin";
            OpenFilter += "|NGC Save Files(*.gci)|*.gci";
            dialogOpenWiiSave.Filter = OpenFilter;
            if (dialogOpenWiiSave.ShowDialog() == DialogResult.OK)
            {
                txtOpenSave.Text = dialogOpenWiiSave.FileName;
            }
        }

        private void ReadTest()		//寻找标识字符串
        {
            int i = 0;
            int SaveFileLength;
            int iHex = new int();
            string strCode = "";
            bool flag = false;
            char[] charCode = new char[4];
            try
            {
                if (dialogOpenWiiSave.FileName != "")
                {
                    FileStream sri = new FileStream(dialogOpenWiiSave.FileName, FileMode.Open, FileAccess.Read);
                    int intSaveLengh = (int)sri.Length;
                    BinaryReader r = new BinaryReader(sri);
                    r.ReadBytes(0xf120);            //2017-02-15

                    for (i = 0; i < intSaveLengh / 4; i++)
                    {
                        charCode[0] = (char)r.ReadByte();
                        charCode[1] = (char)r.ReadByte();
                        charCode[2] = (char)r.ReadByte();
                        charCode[3] = (char)r.ReadByte();

                        flag = IsMyString(charCode);

                        if (flag)
                        {
                            iHex = i * 4 + 0xf120;          //2017-02-15
                            break;
                        }
                    }

                    for (i = 0; i < 4; i++)
                    {
                        strCode += charCode[i].ToString();
                    }

                    if (flag)
                    {
                        txtString.Text = strCode;
                        txtFolder.Text = "\\private\\wii\\title\\" + strCode + "\\";



                        txtWeizhi.Text = Convert.ToString(iHex, 16) + "h";
                        if (iHex == 61732 || iHex == 0)
                            txtTest.Text = "标准存档";
                        else
                            txtTest.Text = "非标准存档";
                        myMessage(charCode);
                    }
                    else
                    {
                        txtString.Text = "无法识别";
                        ErrorMessage();
                    }

                    if (charCode[0].ToString() == "G")
                        SaveFileLength = intSaveLengh / 1024 / 8 + 1;
                    else
                        SaveFileLength = intSaveLengh / 1024 / 128 + 1;
                    txtSize.Text = SaveFileLength.ToString();
                }
            }
            catch
            {
                txtString.Text = "错误！";
                ErrorMessage();
            }
            finally
            {
            }
        }

        private bool IsMyString(char[] SaveCode)	//判断是否为标识字符串
        {
            for (int i = 0; i < 4; i++)
            {
                if ((int)SaveCode[i] < 48 || ((int)SaveCode[i] > 57 && (int)SaveCode[i] < 65) || (int)SaveCode[i] > 90)
                {
                    return (false);
                }
            }

            if ((SaveCode[0] == 'R' || SaveCode[0] == 'H' || SaveCode[0] == 'E' || SaveCode[0] == 'G' || SaveCode[0] == 'S' || SaveCode[0] == 'U' || SaveCode[0] == 'W') &&
                (SaveCode[3] == 'J' || SaveCode[3] == 'E' || SaveCode[3] == 'U' || SaveCode[3] == 'P' || SaveCode[3] == 'A' || SaveCode[3] == 'H' || SaveCode[3] == 'L' || SaveCode[3] == 'X' || SaveCode[3] == 'W'))
            {
                return (true);
            }

            return (false);
        }

        private void ErrorMessage()		//无法读取标识字符串的提示
        {
            txtType.Text = "未知";
            txtName.Text = "未知游戏";
            txtLanguage.Text = "未知";
        }

        private void myMessage(char[] myCode)		//根据标识字符串提取信息
        {
            switch (myCode[0])
            {
                case 'H': txtType.Text = "Wii频道备份"; break;
                case 'R': txtType.Text = "Wii游戏存档"; break;
                case 'E': txtType.Text = "N64游戏存档"; break;
                case 'G': txtType.Text = "NGC游戏存档"; break;
                case 'S': txtType.Text = "Wii游戏存档"; break;
                case 'U': txtType.Text = "游戏存档"; break;
                case 'W': txtType.Text = "游戏存档"; break;

                default: txtType.Text = "未知"; break;
            }

            switch (myCode[1].ToString() + myCode[2].ToString())
            {
                case "25": txtName.Text = "乐高：哈利波特 1-4年"; break;
                case "26": txtName.Text = "Data East街机经典"; break;
                case "2T": txtName.Text = "太鼓达人Wii：咚咚和二代目"; break;
                case "4Q": txtName.Text = "马里奥足球 激情四射"; break;
                case "8P": txtName.Text = "超级纸片马里奥"; break;
                case "AD": txtName.Text = "WII网络浏览器"; break;
                case "AJ": txtName.Text = "wii投票频道"; break;
                case "AP": txtName.Text = "mii选美频道"; break;
                case "AT": txtName.Text = "WII游戏新闻频道"; break;
                case "AZ": txtName.Text = "超凡蜘蛛侠"; break;
                case "B4": txtName.Text = "生化危机4 Wii编辑版"; break;
                case "BB": txtName.Text = "炸弹人大陆"; break;
                case "BN": txtName.Text = "？"; break;
                case "BU": txtName.Text = "生化危机 安布雷拉历代记"; break;
                case "CB": txtName.Text = "？"; break;
                case "CC": txtName.Text = "料理妈妈烹饪指南"; break;
                case "CD": txtName.Text = "使命召唤3"; break;
                case "DB": txtName.Text = "龙珠Z 电光火石"; break;
                case "DR": txtName.Text = "水精灵大冒险"; break;
                case "ET": txtName.Text = "绿日达人"; break;
                case "F8": txtName.Text = "FIFA 08"; break;
                case "FH": txtName.Text = "？"; break;
                case "FN": txtName.Text = "Wii健身[平衡板]"; break;
                case "FP": txtName.Text = "Wii健身 加强版"; break;
                case "GS": txtName.Text = "遥控直升机Wii 飞行大冒险"; break;
                case "GT": txtName.Text = "GT赛车职业系列赛"; break;
                case "HA": txtName.Text = "玩玩Wii"; break;
                case "IP": txtName.Text = "海贼王 无尽的冒险"; break;
                case "K4": txtName.Text = "结界师 黑芒楼之影"; break;
                case "KD": txtName.Text = "超执刀 二次执刀"; break;
                case "M6": txtName.Text = "我的形体教练2"; break;
                case "M8": txtName.Text = "马力欧聚会8"; break;
                case "MC": txtName.Text = "马里奥赛车Wii"; break;
                case "MG": txtName.Text = "超级马里奥 银河"; break;
                case "ML": txtName.Text = "合金弹头精选集"; break;
                case "MN": txtName.Text = "新超级马里奥兄弟Wii"; break;
                case "NL": txtName.Text = "尼克卡通舞蹈"; break;
                case "OD": txtName.Text = "瓦里奥制造 手舞足蹈"; break;
                case "PB": txtName.Text = "口袋妖怪 战斗革命[WiFi]"; break;
                case "RB": txtName.Text = "雷曼－疯狂兔子"; break;
                case "S5": txtName.Text = "战国无双 刀"; break;
                case "SB": txtName.Text = "？"; break;
                case "SP": txtName.Text = "Wii体育"; break;
                case "SR": txtName.Text = "索尼克与神秘指环"; break;
                case "TR": txtName.Text = "目标!!钓鱼大师"; break;
                case "TZ": txtName.Text = "宝岛Z 巴尔巴罗斯的秘宝"; break;
                case "UP": txtName.Text = "Wii派对"; break;
                case "VB": txtName.Text = "超级战舰"; break;
                case "WS": txtName.Text = "马里奥与索尼克在北京奥运会"; break;
                case "XP": txtName.Text = "实感钓鱼[WiFi]"; break;
                case "YE": txtName.Text = "101合1 聚会游戏大合集"; break;
                case "ZD": txtName.Text = "塞尔达传说 黎明公主"; break;
                case "ZT": txtName.Text = "Wii运动 度假胜地"; break;
                case "zy": txtName.Text = "合金弹头十周年精选"; break;
                case "zz": txtName.Text = "口袋妖怪－战斗革命"; break;

                default: txtName.Text = "未知游戏"; break;
            }

            switch (myCode[3])
            {
                case 'J': txtLanguage.Text = "日版"; break;
                case 'E': txtLanguage.Text = "美版"; break;
                //case 'U':txtLanguage.Text = "美版";break;
                case 'P': txtLanguage.Text = "欧版"; break;
                default: txtLanguage.Text = "未知"; break;
            }
        }

        private void SetLanguge()
        {
            this.Text = MyLanguge.Form.Title + " " + MyVersion.Version;
            lblFile.Text = MyLanguge.Lable.FileName;
            lblFolder.Text = MyLanguge.Lable.SaveFolder;
            lblLanguage.Text = MyLanguge.Lable.SaveLanguge;
            lblName.Text = MyLanguge.Lable.GameName;
            lblSize.Text = MyLanguge.Lable.SaveSize;
            lblString.Text = MyLanguge.Lable.SaveText;
            lblTest.Text = MyLanguge.Lable.SaveTest;
            lblType.Text = MyLanguge.Lable.SaveType;
            lblWeizhi.Text = MyLanguge.Lable.SaveIndex;
            btnOpenSave.Text = MyLanguge.Button.Open;
            btnExit.Text = MyLanguge.Button.GoBack;
        }

        #endregion


    }
}
