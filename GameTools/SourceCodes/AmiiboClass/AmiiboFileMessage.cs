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
        public string FullName { set; get; }
        /// <summary>
        /// 文件文件名
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string DirectoryName { set; get; }
        /// <summary>
        /// 文件体积
        /// </summary>
        public long Length { set; get; }
        /// <summary>
        /// 标识字符串1-8
        /// </summary>
        public string SerA { set; get; }
        /// <summary>
        /// 标识字符串9-16
        /// </summary>
        public string SerB { set; get; }
        /// <summary>
        /// NTAG215卡ID
        /// </summary>
        public string NTAG_ID { set; get; }
        /// <summary>
        /// 文件标准文件名
        /// </summary>
        public string NewName { set; get; }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string PicturePath { set; get; }
        /// <summary>
        /// 网络路径
        /// </summary>
        public string NetPath { set; get; }
        /// <summary>
        /// CRC32
        /// </summary>
        public string CRC32 { set; get; }
        /// <summary>
        /// 文件MCAS标准文件名
        /// </summary>
        public string mcasName { set; get; }
        /// <summary>
        /// 是否为04开头
        /// </summary>
        public bool isBegin04 { set; get; }
        /// <summary>
        /// 解密后的CRC32_Decrypted
        /// </summary>
        public string CRC32_Decrypted { set; get; }
        /// <summary>
        /// Amiibo完整数据
        /// </summary>
        public byte[] AmiiboData { set; get; }
        /// <summary>
        /// Amiibo完整数据(解密后)
        /// </summary>
        public byte[] AmiiboDataDecrypted { set; get; }

        public Message_NFC msgNFC;
        public Message_TP msgTP;
        public Message_SSB msgSSB;
        public AmiiboMessage IdMessage;
        public string[] myMessage;
        public byte[] Decrypted;
        //public byte[] Encrypted;
        public AmiiboKeys AmiiKeys;

        #endregion

        #region 构造函数
        public AmiiboFileMessage()
        {
            throw new System.NotImplementedException();
        }

        public AmiiboFileMessage(string AmiiboFileFullName)
        {
            Decrypted = new byte[NtagHelpers.NFC3D_AMIIBO_SIZE];

            this.FullName = AmiiboFileFullName;
            FileInfo fi = new FileInfo(this.FullName);
            this.Name = fi.Name;
            this.DirectoryName = fi.DirectoryName;
            this.Length = fi.Length;

            this.AmiiboData = GetFileData(this.FullName);

            Start();
            //RePack();

            myMessage = this.GetMessage();
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
        /// <param name="ReadLength">读取的字节数</param>
        /// <returns></returns>
        private string GetFileString(int FirstNo, int ReadLength)
        {
            string StrReturn = "";
            if(AmiiboData.Length >= FirstNo + ReadLength)
            {
                for (int i = FirstNo; i < FirstNo + ReadLength; i++)
                {
                    StrReturn += this.AmiiboData[i].ToString("x").ToUpper().PadLeft(2, '0');
                }
            }
            return StrReturn;
        }

        private void Start()
        {
            if (this.Length >= 532)                                          //2018-01-24
            {
                //解密

                if (AmiiboData.Length < NtagHelpers.NFC3D_AMIIBO_SIZE)
                {
                    byte[] AmiiboDataTemp = this.AmiiboData;
                    Array.Resize(ref AmiiboDataTemp, NtagHelpers.NFC3D_AMIIBO_SIZE);
                    this.AmiiboData = AmiiboDataTemp;
                }

                try
                {
                    //AmiiKeys = AmiiboKeys.LoadKeys("KeyTemp.bin");
                    AmiiKeys = AmiiboKeys.LoadKeys(key_retail);
                    AmiiKeys.Unpack(this.AmiiboData, Decrypted);
                    this.AmiiboDataDecrypted = Decrypted;
                    this.msgNFC = new Message_NFC(AmiiboDataDecrypted);

                    msgTP = new Message_TP(AmiiboDataDecrypted, msgNFC);
                    msgSSB = new Message_SSB(AmiiboDataDecrypted, msgNFC);
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
            this.CRC32 = crc32.ComputeCRC32(this.AmiiboData, 0, (int)this.Length);
            if (this.Length >= 532)                                                   //2017-09-29
            {
                this.CRC32_Decrypted = crc32.ComputeCRC32(this.AmiiboDataDecrypted, 0x28, 0x18c);      //2018-01-27 0x28~0x1b3 396
            }

            getMcasName myMcasName = new getMcasName(this.CRC32);
            this.mcasName = myMcasName.Mcas_Name;

            this.NewName = this.isBegin04 ? "" : "[E]";
            this.NewName += "[" + this.IdMessage.GameShortName + "]";
            this.NewName += " " + this.IdMessage.Number + "-" + this.IdMessage.AmiiboName + " ";
            this.NewName += "[" + this.CRC32_Decrypted + "-" + this.NTAG_ID + "-" + this.Length.ToString("000") + "-" + this.CRC32 + "]";
            if (msgSSB.canEdit)
            {
                this.NewName += "(" + this.msgSSB.LEVEL + ")";
            }
            this.NewName += ".bin";

            this.NetPath = "http://amiibo.life/nfc/" + this.SerA + "-" + this.SerB;
            this.PicturePath = "https://raw.githubusercontent.com/N3evin/AmiiboAPI/master/images/icon_" + this.SerA.ToLower() + "-" + this.SerB.ToLower() + ".png";
            //"image": "https://raw.githubusercontent.com/N3evin/AmiiboAPI/master/images/icon_00000000-00340102.png",

        }

        public string[] GetMessage()
        {
            string[] tempMessage = new string[16];

            tempMessage[0] = "Ser: " + this.SerA + "-" + this.SerB + "\n";
            tempMessage[1] = "NTAG 215 ID: " + this.NTAG_ID + "\n";
            tempMessage[2] = "Size: " + this.Length + "Bytes\n";
            //tempMessage[0] = "Main Number: " + myFileMessage.MainNumber + "\n";
            tempMessage[3] = "Amiibo Series: " + this.IdMessage.AmiiboSeries + "\n";
            tempMessage[4] = "Game Short Name: " + this.IdMessage.GameShortName + "\n";
            tempMessage[5] = "Type: " + this.IdMessage.GameType + "\n";
            tempMessage[6] = "Name: " + this.IdMessage.AmiiboName + "\n";
            tempMessage[7] = "Number: " + this.IdMessage.Number + "\n";
            tempMessage[8] = "CRC32: " + this.CRC32 + "\n";
            tempMessage[9] = "01~04: " + this.SerA.Remove(4) + ": " + this.IdMessage.Ser01to03string + " - " + this.IdMessage.Ser01to04string + "\n";
            tempMessage[10] = "05~06:   " + this.SerA.Remove(0, 4).Remove(2) + ": " + this.IdMessage.Ser05to06string + "\n";
            tempMessage[11] = "07~08:   " + this.SerA.Remove(0, 6) + ": " + this.IdMessage.Ser07to08string + "\n";
            tempMessage[12] = "09~12: " + this.SerB.Remove(4) + ": " + this.IdMessage.Ser09to12stringA + " - " + this.IdMessage.Ser09to12stringB + "\n";
            tempMessage[13] = "13~14:   " + this.SerB.Remove(0, 4).Remove(2) + ": " + this.IdMessage.Ser13to14string + "\n";
            tempMessage[14] = "15~16:   " + this.SerB.Remove(0, 6) + ": " + this.IdMessage.Ser15to16string + "\n";
            tempMessage[15] = "MCAS Name:   " + this.mcasName + "\n";
            return tempMessage;
        }

        public byte[] RePack(string getUID)
        {
            byte[] tempDecrypted = Decrypted;
            byte[] Encrypted = new byte[NtagHelpers.NFC3D_AMIIBO_SIZE];

            tempDecrypted[0x1d4] = (byte)Convert.ToInt32(getUID.Substring(0, 2), 16);
            tempDecrypted[0x1d5] = (byte)Convert.ToInt32(getUID.Substring(2, 2), 16);
            tempDecrypted[0x1d6] = (byte)Convert.ToInt32(getUID.Substring(4, 2), 16);
            tempDecrypted[0x1d7] = (byte)(0x88 ^ tempDecrypted[0x1d4] ^ tempDecrypted[0x1d5] ^ tempDecrypted[0x1d6]);
            tempDecrypted[0x1d8] = (byte)Convert.ToInt32(getUID.Substring(6, 2), 16);
            tempDecrypted[0x1d9] = (byte)Convert.ToInt32(getUID.Substring(8, 2), 16);
            tempDecrypted[0x1da] = (byte)Convert.ToInt32(getUID.Substring(10, 2), 16);
            tempDecrypted[0x1db] = (byte)Convert.ToInt32(getUID.Substring(12, 2), 16);
            tempDecrypted[0x000] = (byte)(tempDecrypted[0x1d8] ^ tempDecrypted[0x1d9] ^ tempDecrypted[0x1da] ^ tempDecrypted[0x1db]);

            AmiiKeys.Pack(tempDecrypted, Encrypted);
            return Encrypted;

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
