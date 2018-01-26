using System;
using System.IO;
using LibAmiibo;

namespace AnterStudio.GameTools.AmiiboClass
{
    /// <summary>
    /// 2017-08-01
    /// </summary>
    /// 
    class AmiiboFileMessage
    {
        #region 访问器

        /// <summary>
        /// 文件完整文件名
        /// </summary>
        public string FullName { get; }
        /// <summary>
        /// 文件文件名
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string DirectoryName { get; }
        /// <summary>
        /// 文件体积
        /// </summary>
        public long Lengh { get; }
        /// <summary>
        /// 标识字符串1-8
        /// </summary>
        public string SerA { get; }
        /// <summary>
        /// 标识字符串9-16
        /// </summary>
        public string SerB { get; }
        /// <summary>
        /// NTAG215卡ID
        /// </summary>
        public string NTAG_ID { get; }
        /// <summary>
        /// 标识字符串AmiiboSeries
        /// </summary>
        public string AmiiboSeries { get; }
        /// <summary>
        /// 文件标准文件名
        /// </summary>
        public string NewName { get; }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string PicturePath { get; }
        /// <summary>
        /// 网络路径
        /// </summary>
        public string NetPath { get; }
        /// <summary>
        /// CRC32
        /// </summary>
        public string CRC32 { get; }
        /// <summary>
        /// 文件MCAS标准文件名
        /// </summary>
        public string McasName { get; }
        /// <summary>
        /// 是否为04开头
        /// </summary>
        public bool isBegin04 { get; }
        /// <summary>
        /// 解密后的CRC532
        /// </summary>
        public string CRC532 { get; }
        /// <summary>
        /// Amiibo完整数据
        /// </summary>
        public byte[] AmiiboData { get; }
        /// <summary>
        /// Amiibo完整数据(解密后)
        /// </summary>
        public byte[] AmiiboDataNew { get; }

        public nfc_Message Nfc_Message;
        public EditorTP msgTP;
        public EditorSSB msgSSB;
        public AmiiboMessage IdMessage;

        #endregion

        #region 构造函数
        public AmiiboFileMessage()
        {
            throw new System.NotImplementedException();
        }

        public AmiiboFileMessage(string AmiiboFileFullName)
        {
            this.FullName = AmiiboFileFullName;
            FileInfo fi = new FileInfo(this.FullName);
            this.Name = fi.Name;
            this.DirectoryName = fi.DirectoryName;
            this.Lengh = fi.Length;

            this.AmiiboData = GetFileData(this.FullName);

            if (this.Lengh >= 532)                                          //2018-01-24
            {
                //解密
                AmiiboKeys AmiiKeys;
                if (AmiiboData.Length < NtagHelpers.NFC3D_AMIIBO_SIZE)
                {
                    byte[] AmiiboDataTemp = this.AmiiboData;
                    Array.Resize(ref AmiiboDataTemp, NtagHelpers.NFC3D_AMIIBO_SIZE);
                    this.AmiiboData = AmiiboDataTemp;
                }
                byte[] Decrypted = new byte[NtagHelpers.NFC3D_AMIIBO_SIZE];
                //byte[] Encrypted = new byte[NtagHelpers.NFC3D_AMIIBO_SIZE];

                try
                {
                    //AmiiKeys = AmiiboKeys.LoadKeys("KeyTemp.bin");
                    AmiiKeys = AmiiboKeys.LoadKeys(key_retail);
                    AmiiKeys.Unpack(this.AmiiboData, Decrypted);
                    this.AmiiboDataNew = Decrypted;
                    this.Nfc_Message = new nfc_Message(AmiiboDataNew);

                    msgTP = new EditorTP(AmiiboDataNew);
                    msgSSB = new EditorSSB(AmiiboDataNew);
                }
                catch
                {
                }
            }
            this.NTAG_ID = GetFileString(0x00, 3) + GetFileString(0x04, 4);
            this.SerA = GetFileString(0x54, 4);
            this.SerB = GetFileString(0x58, 4);

            this.isBegin04 = (GetFileString(0x00, 1) == "04") ? true : false;

            IdMessage = new AmiiboMessage(this.SerA + this.SerB);            //2018-01-25

            FileToCRC32 crc32 = new FileToCRC32();
            this.CRC32 = crc32.ComputeCRC32(this.AmiiboData,0, (int)this.Lengh);
            if(this.Lengh >= 532)                                                   //2017-09-29
            {
                this.CRC532 = crc32.ComputeCRC32(this.AmiiboDataNew, 0x2c, 0x188);      //2018-01-26 0x2c~0x1b3 392
            }

            getMcasName myMcasName = new getMcasName(this.CRC32);
            this.McasName = myMcasName.Mcas_Name;

            string strSsbLevel = "-";
            try
            {
                strSsbLevel = msgSSB.LEVEL.ToString();
            }
            catch
            { }

            this.NewName = (this.isBegin04 ? "" : "[E]") + "[" + this.IdMessage.GameShortName + "] " + this.IdMessage.Number + "-"
                    + this.IdMessage.AmiiboName + " [" + this.CRC532 + "-" + this.NTAG_ID + "-" + this.Lengh.ToString("000") + "-" 
                    + this.CRC32 + "][" + strSsbLevel + "].bin";

            this.NetPath = "http://amiibo.life/nfc/" + this.SerA + "-" + this.SerB;
            this.PicturePath = "https://raw.githubusercontent.com/N3evin/AmiiboAPI/master/images/icon_" + this.SerA.ToLower() + "-" + this.SerB.ToLower() + ".png";
            //"image": "https://raw.githubusercontent.com/N3evin/AmiiboAPI/master/images/icon_00000000-00340102.png",
        }
        #endregion

        #region 其他方法

        /// <summary>
        /// 获取完整的Amiibo数据   2017-08-22
        /// </summary>
        /// <param name="FileFullName"></param>
        /// <returns></returns>
        private byte[] GetFileData(string FileFullName)
        {
            byte[] SerBytes;
            try
            {
                FileStream sri = new FileStream(FileFullName, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(sri);
                SerBytes = r.ReadBytes((int)sri.Length);
                sri.Close();
            }
            catch
            {
                SerBytes = new byte[0];
            }
            return SerBytes;
        }

        /// <summary>
        /// 从AmiiboData中获取字符串   2017-08-22
        /// </summary>
        /// <param name="FirstNo">开始位置，0则为从头读取</param>
        /// <param name="ReadLengh">读取的字节数</param>
        /// <returns></returns>
        private string GetFileString(int FirstNo, int ReadLengh)
        {
            string StrReturn = "";
            if(AmiiboData.Length >= FirstNo + ReadLengh)
            {
                for (int i = FirstNo; i < FirstNo + ReadLengh; i++)
                {
                    StrReturn += this.AmiiboData[i].ToString("x").ToUpper().PadLeft(2, '0');
                }
            }
            return StrReturn;
        }

        #endregion

        #region key_retail.bin数据

        internal static byte[] key_retail =
        {

            0x1D,   0x16,   0x4B,   0x37,   0x5B,   0x72,   0xA5,   0x57,
            0x28,   0xB9,   0x1D,   0x64,   0xB6,   0xA3,   0xC2,   0x05,
            0x75,   0x6E,   0x66,   0x69,   0x78,   0x65,   0x64,   0x20,
            0x69,   0x6E,   0x66,   0x6F,   0x73,   0x00,   0x00,   0x0E,
            0xDB,   0x4B,   0x9E,   0x3F,   0x45,   0x27,   0x8F,   0x39,
            0x7E,   0xFF,   0x9B,   0x4F,   0xB9,   0x93,   0x00,   0x00,
            0x04,   0x49,   0x17,   0xDC,   0x76,   0xB4,   0x96,   0x40,
            0xD6,   0xF8,   0x39,   0x39,   0x96,   0x0F,   0xAE,   0xD4,
            0xEF,   0x39,   0x2F,   0xAA,   0xB2,   0x14,   0x28,   0xAA,
            0x21,   0xFB,   0x54,   0xE5,   0x45,   0x05,   0x47,   0x66,
            0x7F,   0x75,   0x2D,   0x28,   0x73,   0xA2,   0x00,   0x17,
            0xFE,   0xF8,   0x5C,   0x05,   0x75,   0x90,   0x4B,   0x6D,
            0x6C,   0x6F,   0x63,   0x6B,   0x65,   0x64,   0x20,   0x73,
            0x65,   0x63,   0x72,   0x65,   0x74,   0x00,   0x00,   0x10,
            0xFD,   0xC8,   0xA0,   0x76,   0x94,   0xB8,   0x9E,   0x4C,
            0x47,   0xD3,   0x7D,   0xE8,   0xCE,   0x5C,   0x74,   0xC1,
            0x04,   0x49,   0x17,   0xDC,   0x76,   0xB4,   0x96,   0x40,
            0xD6,   0xF8,   0x39,   0x39,   0x96,   0x0F,   0xAE,   0xD4,
            0xEF,   0x39,   0x2F,   0xAA,   0xB2,   0x14,   0x28,   0xAA,
            0x21,   0xFB,   0x54,   0xE5,   0x45,   0x05,   0x47,   0x66

        };

        #endregion
    }
}
