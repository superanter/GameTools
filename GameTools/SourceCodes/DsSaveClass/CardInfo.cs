using System;
//using System.Text;

namespace AnterStudio.GameTools.DsSaveClass
{
    class CardClass
    {
        #region 访问器
        /// <summary>
        /// 烧录卡模式：0为NDS，1为GBA
        /// </summary>
        public int CardMode { get; set; }
        /// <summary>
        /// 烧录卡名称
        /// </summary>
        public string CardName { get; set; }
        /// <summary>
        /// 烧录卡简称
        /// </summary>
        public string CardSName { get; set; }
        /// <summary>
        /// 烧录卡支持的存档大小：七位字符串，0为不支持，1为支持
        /// </summary>
        public string CardSaveType { get; set; }
        /// <summary>
        /// 烧录卡所支持的存档大小中默认的项目序号
        /// </summary>
        public int SelectIndex { get; set; }
        /// <summary>
        /// 烧录卡所支持存档后缀
        /// </summary>
        public string CardExt { get; set; }
        /// <summary>
        /// 特殊烧录卡标识：1为M3,2为DSLink，0为其他烧录卡
        /// </summary>
        public int CardIs { get; set; }
        /// <summary>
        /// 烧录卡说明
        /// </summary>
        public string CardInfo { get; set; }
        /// <summary>
        /// 烧录卡仅支持256K存档格式标识，1为仅支持256K，0为支持其它体积
        /// </summary>
        public int Only256 { get; set; }

        #endregion

        #region 构造函数

        public CardClass()
        {
            throw new System.NotImplementedException();
        }

        public CardClass(int iCardMode, string iCardName, string iCardShortName, string iCardSaveType, int iSelectIndex, int iOnly256, string iCardExt, int iCardIs, string iCardInfo)
        {
            this.CardMode = iCardMode;
            this.CardName = iCardName;
            this.CardSName = iCardShortName;
            this.CardSaveType = iCardSaveType;
            this.SelectIndex = iSelectIndex;
            this.Only256 = iOnly256;
            this.CardExt = iCardExt;
            this.CardIs = iCardIs;
            this.CardInfo = iCardInfo;
            //throw new System.NotImplementedException();
        }

        #endregion

    }
}
