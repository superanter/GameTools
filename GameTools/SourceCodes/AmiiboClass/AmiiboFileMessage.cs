using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using AmiiBomb;
using LibAmiibo;
using TagMo;

namespace AnterStudio.GameTools.AmiiboClass
{
    /// <summary>
    /// 2017-08-01
    /// </summary>
    /// 
    class AmiiboFileMessage
    {
        /// <summary>
        /// Temp临时
        /// </summary>
        public byte[] TempMD5 { get; }
        public byte[] TempSHA1 { get; }
        public byte[] TempHMAC { get; }

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
        /// 标识字符串1-3
        /// </summary>
        public string Ser01to03 { get; }
        /// <summary>
        /// 标识字符串3-4
        /// </summary>
        public string Ser03to04 { get; }
        /// <summary>
        /// 标识字符串5-6
        /// </summary>
        public string Ser05to06 { get; }
        /// <summary>
        /// 标识字符串7-8
        /// </summary>
        public string Ser07to08 { get; }
        /// <summary>
        /// 标识字符串9-12
        /// </summary>
        public string Ser09to12 { get; }
        /// <summary>
        /// 标识字符串13-14
        /// </summary>
        public string Ser13to14 { get; }
        /// <summary>
        /// 标识字符串15-16
        /// </summary>
        public string Ser15to16 { get; }
        /// <summary>
        /// 标识字符串1-3string
        /// </summary>
        public string Ser01to03string { get; }
        /// <summary>
        /// 标识字符串7-8string
        /// </summary>
        public string Ser07to08string { get; }
        /// <summary>
        /// 标识字符串09-12stringA
        /// </summary>
        public string Ser09to12stringA { get; }
        /// <summary>
        /// 标识字符串09-12stringB
        /// </summary>
        public string Ser09to12stringB { get; }
        /// <summary>
        /// 标识字符串13-14string
        /// </summary>
        public string Ser13to14string { get; }

        /// <summary>
        /// 标识字符串GameShortName
        /// </summary>
        public string GameShortName { get; }
        /// <summary>
        /// 标识字符串AmiiboSeries
        /// </summary>
        public string AmiiboSeries { get; }
        /// <summary>
        /// 标识字符串GameType
        /// </summary>
        public string GameType { get; }
        /// <summary>
        /// 标识字符串AmiiboName
        /// </summary>
        public string AmiiboName { get; }
        /// <summary>
        /// 标识字符串Number
        /// </summary>
        public string Number { get; }
        /// <summary>
        /// 标识字符串MainNumber
        /// </summary>
        public string MainNumber { get; }
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
        /// 标识字符串15-16string
        /// </summary>
        public string Ser15to16string { get; }
        /// <summary>
        /// 标识字符串01-04string
        /// </summary>
        public string Ser01to04string { get; }
        /// <summary>
        /// 标识字符串01-04
        /// </summary>
        public string Ser01to04 { get; }
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
        /// CRC532
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

        #endregion

        #region 访问器2

        public class nfc_Message
        {
            public string NFC_ID { set; get; }
            public string Character_ID { set; get; }
            public string GameSeries_ID { set; get; }
            public string Amiibo_Nickname { set; get; }
            public string Amiibo_Mii_Nickname { set; get; }
            public string Amiibo_Write_Counter { set; get; }
            public string Amiibo_AppID { set; get; }
            public string Amiibo_Initialized_AppID { set; get; }
            public string Amiibo_Country { set; get; }
            public int Amiibo_Initialize_UserData { set; get; }
            public string Amiibo_LastModifiedDate { set; get; }
        }

        public nfc_Message Nfc_Message;
        public EditorTP msgTP;
        public EditorSSB msgSSB;

        #endregion

        #region 构造函数
        public AmiiboFileMessage()
        {
            throw new System.NotImplementedException();
        }

        public AmiiboFileMessage(string AmiiboFileFullName)
        {
            Nfc_Message = new nfc_Message();
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

                    this.Nfc_Message.NFC_ID = Amiibo_Class.Get_NFC_ID(this.AmiiboDataNew);
                    this.Nfc_Message.Character_ID = Amiibo_Class.Get_Character_ID(this.AmiiboDataNew);
                    this.Nfc_Message.GameSeries_ID = Amiibo_Class.Get_GameSeries_ID(this.AmiiboDataNew);

                    this.Nfc_Message.Amiibo_Nickname = Amiibo_Class.Get_Amiibo_Nickname(this.AmiiboDataNew);
                    this.Nfc_Message.Amiibo_Mii_Nickname = Amiibo_Class.Get_Amiibo_Mii_Nickname(this.AmiiboDataNew);
                    this.Nfc_Message.Amiibo_Write_Counter = Amiibo_Class.Get_Amiibo_Write_Counter(this.AmiiboDataNew);
                    this.Nfc_Message.Amiibo_AppID = Amiibo_Class.Get_Amiibo_AppID(this.AmiiboDataNew);
                    this.Nfc_Message.Amiibo_Initialized_AppID = Amiibo_Class.Get_Amiibo_Initialized_AppID(this.AmiiboDataNew);
                    this.Nfc_Message.Amiibo_Country = Amiibo_Class.Get_Amiibo_Country(this.AmiiboDataNew);
                    this.Nfc_Message.Amiibo_Initialize_UserData = Amiibo_Class.Get_Amiibo_Initialize_UserData(this.AmiiboDataNew);
                    this.Nfc_Message.Amiibo_LastModifiedDate = Amiibo_Class.Get_Amiibo_LastModifiedDate(this.AmiiboDataNew);

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
            this.Ser01to03 = GetFileString(0x54, 2).Remove(3, 1);
            this.Ser01to04 = GetFileString(0x54, 2);
            this.Ser03to04 = GetFileString(0x55, 1);
            this.Ser05to06 = GetFileString(0x56, 1);
            this.Ser07to08 = GetFileString(0x57, 1);
            this.Ser09to12 = GetFileString(0x58, 2);
            this.Ser13to14 = GetFileString(0x5A, 1);
            this.Ser15to16 = GetFileString(0x5B, 1);

            this.Ser01to03string = this.GetAmiiboName01to03(Ser01to03);
            this.Ser07to08string = this.GetAmiiboName07to08(Ser07to08);
            this.Ser09to12stringA = this.GetAmiiboName09to12A(Ser09to12);
            this.Ser13to14string = this.GetAmiiboName13to14(Ser13to14);
            this.Ser15to16string = this.GetAmiiboName15to16(Ser15to16);
            this.Ser01to04string = this.GetAmiiboName01to04(Ser01to04);
            this.Ser09to12stringB = this.GetAmiiboName09to12B(Ser09to12);

            this.isBegin04 = (GetFileString(0x00, 1) == "04") ? true : false;

            string[] strT = this.GetAmiiboName(this.SerA + this.SerB);
            this.GameShortName = strT[1];
            this.AmiiboSeries = strT[2];
            this.GameType = strT[3];
            this.AmiiboName = strT[4];
            this.Number = strT[5];
            this.MainNumber = strT[6].PadLeft(3, '0');

            FileToCRC32 crc32 = new FileToCRC32();
            this.CRC32 = crc32.ComputeCRC32(this.AmiiboData);
            if(this.Lengh >= 532)                                                   //2017-09-29
            {
                this.CRC532 = crc32.ComputeCRC32(this.AmiiboDataNew, 0, 532);
            }
            this.McasName = this.GetAmiiboNameMCAS(this.CRC32);
            try
            {
                this.NewName = (this.isBegin04 ? "" : "[E]") + "[" + this.GameShortName + "] " + this.Number + "-"
                        + this.AmiiboName + " [" + this.NTAG_ID + "-" + this.CRC532 + "-" + this.Lengh.ToString("000") + "-" + this.CRC32 + "][" + this.msgSSB.LEVEL.ToString() + "].bin";
            }
            catch
            {
                this.NewName = (this.isBegin04 ? "" : "[E]") + "[" + this.GameShortName + "] " + this.Number + "-"
        + this.AmiiboName + " [" + this.NTAG_ID + "-" + this.CRC532 + "-" + this.Lengh.ToString("000") + "-" + this.CRC32 + "][-].bin";
            }
            this.NetPath = "http://amiibo.life/nfc/" + this.SerA + "-" + this.SerB;
            this.PicturePath = "https://raw.githubusercontent.com/N3evin/AmiiboAPI/master/images/icon_" + this.SerA.ToLower() + "-" + this.SerB.ToLower() + ".png";
            //"image": "https://raw.githubusercontent.com/N3evin/AmiiboAPI/master/images/icon_00000000-00340102.png",
        }
        #endregion

        #region 其他方法

        private string ToHexString(byte[] bytes) // 0xae00cf => "AE00CF "
        {
            string hexString = string.Empty;
            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    strB.Append(bytes[i].ToString("X2"));
                }
                hexString = strB.ToString();
            }
            return hexString;
        }
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

        /// <summary>
        /// MCAS Name 2018-01-24
        /// </summary>
        /// <param name="AmiiboSer"></param>
        /// <returns></returns>
        private string GetAmiiboNameMCAS(string AmiiboSer)
        {
            switch (AmiiboSer)
            {
                case "6F8F134D": return "[AC] XS1 - Rilla.bin";
                case "CB78A418": return "[AC] XS2 - Marty.bin";
                case "369BAF01": return "[AC] XS3 - étoile.bin";
                case "77853474": return "[AC] XS4 - Chai.bin";
                case "402815D3": return "[AC] XS5 - Chelsea.bin";
                case "691B0111": return "[AC] XS6 - Toby.bin";
                case "3FDD5E34": return "[AC] AF1 - Stitches.bin";
                case "E5D93B4C": return "[AC] AF2 - Rosie.bin";
                case "14B6B226": return "[AC] AF3 - Goldie.bin";
                case "F880D6C2": return "[AC] CP1 - Isabelle.bin";
                case "8F34FB80": return "[AC] CP2 - K.K. Slider.bin";
                case "2BDAAB9D": return "[AC] 001 - Isabelle.bin";
                case "C1F36D5A": return "[AC] 002 - Tom Nook.bin";
                case "0D3AB56E": return "[AC] 003 - DJ KK.bin";
                case "F8A35AF7": return "[AC] 004 - Sable.bin";
                case "E94CD68A": return "[AC] 005 - Kappn.bin";
                case "25F7927F": return "[AC] 006 - Resetti.bin";
                case "BF2B400A": return "[AC] 007 - Joan.bin";
                case "4D845F95": return "[AC] 008 - Timmy.bin";
                case "29166DCD": return "[AC] 009 - Digby.bin";
                case "3C5B6BAB": return "[AC] 010 - Pascal.bin";
                case "BC422D48": return "[AC] 011 - Harriet.bin";
                case "FB20F015": return "[AC] 012 - Redd.bin";
                case "063DDDCF": return "[AC] 013 - Saharah.bin";
                case "76306784": return "[AC] 014 - Luna.bin";
                case "040CF16D": return "[AC] 015 - Tortimer.bin";
                case "6C60EC88": return "[AC] 016 - Lyle.bin";
                case "45DFDD83": return "[AC] 017 - Lottie.bin";
                case "8078E351": return "[AC] 018 - Bob.bin";
                case "114463BE": return "[AC] 019 - Fauna.bin";
                case "DE3651C4": return "[AC] 020 - Curt.bin";
                case "A50DE921": return "[AC] 021 - Portia.bin";
                case "70307BE2": return "[AC] 022 - Leonardo.bin";
                case "4180F689": return "[AC] 023 - Cheri.bin";
                case "6D903DE1": return "[AC] 024 - Kyle.bin";
                case "9CA527C4": return "[AC] 025 - Al.bin";
                case "CFA3A338": return "[AC] 026 - Renee.bin";
                case "3DF36839": return "[AC] 027 - Lopez.bin";
                case "DDAF0E03": return "[AC] 028 - Jambette.bin";
                case "C9D5DBE2": return "[AC] 029 - Rasher.bin";
                case "C17F6788": return "[AC] 030 - Tiffany.bin";
                case "4E9563A2": return "[AC] 031 - Sheldon.bin";
                case "28C7BA57": return "[AC] 032 - Bluebear.bin";
                case "A9C2A281": return "[AC] 033 - Bill.bin";
                case "60F5241D": return "[AC] 034 - Kiki.bin";
                case "F2116976": return "[AC] 035 - Deli.bin";
                case "654B3A7D": return "[AC] 036 - Alli.bin";
                case "BA971528": return "[AC] 037 - Kabuki.bin";
                case "100A9796": return "[AC] 038 - Patty.bin";
                case "E3609A47": return "[AC] 039 - Jitters.bin";
                case "D1E13E52": return "[AC] 040 - Gigi.bin";
                case "6A13CF05": return "[AC] 041 - Quillson.bin";
                case "EA467FB2": return "[AC] 042 - Marcie.bin";
                case "092E5FEF": return "[AC] 043 - Puck.bin";
                case "DFF5481C": return "[AC] 044 - Shari.bin";
                case "B22EAC8A": return "[AC] 045 - Octavian.bin";
                case "43A809C7": return "[AC] 046 - Winnie.bin";
                case "9522B1E8": return "[AC] 047 - Knox.bin";
                case "ECAA14B8": return "[AC] 048 - Sterling.bin";
                case "E5D5800D": return "[AC] 049 - Bonbon.bin";
                case "592AA351": return "[AC] 050 - Punchy.bin";
                case "E6B2F5AB": return "[AC] 051 - Opal.bin";
                case "0BA504AD": return "[AC] 052 - Poppy.bin";
                case "2A3CF3CE": return "[AC] 053 - Limberg.bin";
                case "0F6685E3": return "[AC] 054 - Deena.bin";
                case "4F15684D": return "[AC] 055 - Snake.bin";
                case "F66F7142": return "[AC] 056 - Bangle.bin";
                case "8B1A49C4": return "[AC] 057 - Phil.bin";
                case "EFBA6CC1": return "[AC] 058 - Monique.bin";
                case "EC212726": return "[AC] 059 - Nate.bin";
                case "EA6AA827": return "[AC] 060 - Samson.bin";
                case "81FF585A": return "[AC] 061 - Tutu.bin";
                case "26F17513": return "[AC] 062 - T-Bone.bin";
                case "E42B8935": return "[AC] 063 - Mint.bin";
                case "375A0DA7": return "[AC] 064 - Pudge.bin";
                case "6A12847E": return "[AC] 065 - Midge.bin";
                case "CDB2E742": return "[AC] 066 - Gruff.bin";
                case "2FC2FA8C": return "[AC] 067 - Flurry.bin";
                case "3EA39487": return "[AC] 068 - Clyde.bin";
                case "7FD4C079": return "[AC] 069 - Bella.bin";
                case "F41DADDD": return "[AC] 070 - Biff.bin";
                case "56CE1509": return "[AC] 071 - Yuka.bin";
                case "0C604125": return "[AC] 072 - Lionel.bin";
                case "EE9776B0": return "[AC] 073 - Flo.bin";
                case "0D62C76A": return "[AC] 074 - Cobb.bin";
                case "69B74F70": return "[AC] 075 - Amelia.bin";
                case "774E3A75": return "[AC] 076 - Jeramiah.bin";
                case "2030C5BD": return "[AC] 077 - Cherry.bin";
                case "07E1EB77": return "[AC] 078 - Roscoe.bin";
                case "8FE99866": return "[AC] 079 - Truffles.bin";
                case "56AF3BAA": return "[AC] 080 - Eugene.bin";
                case "955B9CA7": return "[AC] 081 - Eunice.bin";
                case "51C141F0": return "[AC] 082 - Goose.bin";
                case "C194C5A5": return "[AC] 083 - Annalisa.bin";
                case "C76A0056": return "[AC] 084 - Benjamin.bin";
                case "8B6683C0": return "[AC] 085 - Pancetti.bin";
                case "7AC5F4E8": return "[AC] 086 - Chief.bin";
                case "F24FC4F4": return "[AC] 087 - Bunnie.bin";
                case "60F5317B": return "[AC] 088 - Clay.bin";
                case "C0707FBA": return "[AC] 089 - Diana.bin";
                case "EAE96050": return "[AC] 090 - Axel.bin";
                case "8570E6A4": return "[AC] 091 - Muffy.bin";
                case "8F734118": return "[AC] 092 - Henry.bin";
                case "82804F04": return "[AC] 093 - Bertha.bin";
                case "6F7CEE61": return "[AC] 094 - Cyrano.bin";
                case "7D374DBD": return "[AC] 095 - Peanut.bin";
                case "67F3A8A4": return "[AC] 096 - Cole.bin";
                case "E0081E7A": return "[AC] 097 - Willow.bin";
                case "8A994CC8": return "[AC] 098 - Roald.bin";
                case "FD526DF0": return "[AC] 099 - Molly.bin";
                case "F7CF4B0D": return "[AC] 100 - Walker.bin";
                case "4B80982C": return "[AC] 101 - K.K. Slider.bin";
                case "F9C28887": return "[AC] 102 - Reese.bin";
                case "7484DC74": return "[AC] 103 - Kicks.bin";
                case "CB9E35C8": return "[AC] 104 - Labelle.bin";
                case "2141951D": return "[AC] 105 - Copper.bin";
                case "AF3155EF": return "[AC] 106 - Booker.bin";
                case "F64EBED2": return "[AC] 107 - Katie.bin";
                case "320D214C": return "[AC] 108 - Tommy.bin";
                case "8449E930": return "[AC] 109 - Porter.bin";
                case "B8FCF38B": return "[AC] 110 - Leila.bin";
                case "CEAAA1FB": return "[AC] 111 - Shrunk.bin";
                case "E50EA243": return "[AC] 112 - Don Resetti.bin";
                case "ECDBEC86": return "[AC] 113 - Isabelle.bin";
                case "BB7C5589": return "[AC] 114 - Blanca.bin";
                case "FB5F91C9": return "[AC] 115 - Nat.bin";
                case "5D139876": return "[AC] 116 - Chip.bin";
                case "3E455EA0": return "[AC] 117 - Jack.bin";
                case "3D5E6239": return "[AC] 118 - Poncho.bin";
                case "E23469B1": return "[AC] 119 - Felicity.bin";
                case "5BFF66B9": return "[AC] 120 - Ozzie.bin";
                case "5D9A25CA": return "[AC] 121 - Tia.bin";
                case "89D00B51": return "[AC] 122 - Lucha.bin";
                case "A9C43291": return "[AC] 123 - Fuchsia.bin";
                case "3BFCFBE8": return "[AC] 124 - Harry.bin";
                case "B2A8088A": return "[AC] 125 - Gwen.bin";
                case "0B339627": return "[AC] 126 - Coach.bin";
                case "3F960A0F": return "[AC] 127 - Kitt.bin";
                case "91739CC4": return "[AC] 128 - Tom.bin";
                case "3A8C1325": return "[AC] 129 - Tipper.bin";
                case "E92BB6D5": return "[AC] 130 - Prince.bin";
                case "D1E97654": return "[AC] 131 - Pate.bin";
                case "D6CFF2BA": return "[AC] 132 - Vladimir.bin";
                case "7591D025": return "[AC] 133 - Savannah.bin";
                case "29BD3EED": return "[AC] 134 - Kidd.bin";
                case "32D3672D": return "[AC] 135 - Phoebe.bin";
                case "5640A9A8": return "[AC] 136 - Egbert.bin";
                case "C52503BD": return "[AC] 137 - Cookie.bin";
                case "1EF71047": return "[AC] 138 - Sly.bin";
                case "96A8EEAE": return "[AC] 139 - Blaire.bin";
                case "DA41A964": return "[AC] 140 - Avery.bin";
                case "15AE4444": return "[AC] 141 - Nana.bin";
                case "49CBBB1F": return "[AC] 142 - Peck.bin";
                case "D44F6C3F": return "[AC] 143 - Olivia.bin";
                case "3BB23A51": return "[AC] 144 - Cesar.bin";
                case "E7A3613C": return "[AC] 145 - Carmen.bin";
                case "E3F89272": return "[AC] 146 - Rodney.bin";
                case "BAC5977E": return "[AC] 147 - Scoot.bin";
                case "F3A08965": return "[AC] 148 - Whitney.bin";
                case "7BA25218": return "[AC] 149 - Broccolo.bin";
                case "76CF0996": return "[AC] 150 - Coco.bin";
                case "0989B5BE": return "[AC] 151 - Groucho.bin";
                case "2175E713": return "[AC] 152 - Wendy.bin";
                case "DA8B00BB": return "[AC] 153 - Alfonso.bin";
                case "4166EC98": return "[AC] 154 - Rhonda.bin";
                case "908A5038": return "[AC] 155 - Butch.bin";
                case "D90DD7C6": return "[AC] 156 - Gabi.bin";
                case "0C109B64": return "[AC] 157 - Moose.bin";
                case "F5092669": return "[AC] 158 - Timbra.bin";
                case "497FACFF": return "[AC] 159 - Zell.bin";
                case "92C0C7EE": return "[AC] 160 - Pekoe.bin";
                case "1561B261": return "[AC] 161 - Teddy.bin";
                case "0366E95F": return "[AC] 162 - Mathilda.bin";
                case "923FB5E4": return "[AC] 163 - Ed.bin";
                case "F9C6B8A5": return "[AC] 164 - Bianca.bin";
                case "5BC334DA": return "[AC] 165 - Filbert.bin";
                case "CACAA9F0": return "[AC] 166 - Kitty.bin";
                case "42F18181": return "[AC] 167 - Beau.bin";
                case "AAB58EA0": return "[AC] 168 - Nan.bin";
                case "3A7FF4D8": return "[AC] 169 - Bud.bin";
                case "481541AC": return "[AC] 170 - Ruby.bin";
                case "80CDF306": return "[AC] 171 - Benedict.bin";
                case "3DB1A335": return "[AC] 172 - Agnes.bin";
                case "438C4D78": return "[AC] 173 - Julian.bin";
                case "DFAECFC1": return "[AC] 174 - Bettina.bin";
                case "D48995AE": return "[AC] 175 - Jay.bin";
                case "3A2D6383": return "[AC] 176 - Sprinkle.bin";
                case "4A143376": return "[AC] 177 - Flip.bin";
                case "A3A9D9ED": return "[AC] 178 - Hugh.bin";
                case "1D29191C": return "[AC] 179 - Hopper.bin";
                case "5A9E42E0": return "[AC] 180 - Pecan.bin";
                case "DD388E30": return "[AC] 181 - Drake.bin";
                case "5650B2F1": return "[AC] 182 - Alice.bin";
                case "3A653B63": return "[AC] 183 - Camofrog.bin";
                case "5DB9AB55": return "[AC] 184 - Anicotti.bin";
                case "2A004FFB": return "[AC] 185 - Chops.bin";
                case "2B5EBA4D": return "[AC] 186 - Charlise.bin";
                case "462376CE": return "[AC] 187 - Vic.bin";
                case "8C207C8F": return "[AC] 188 - Ankha.bin";
                case "DF3AC003": return "[AC] 189 - Drift.bin";
                case "5E91BF1F": return "[AC] 190 - Vesta.bin";
                case "FF370C5F": return "[AC] 191 - Marcel.bin";
                case "FD11EDEA": return "[AC] 192 - Pango.bin";
                case "1871F876": return "[AC] 193 - Keaton.bin";
                case "567D4EB1": return "[AC] 194 - Gladys.bin";
                case "1601E7A1": return "[AC] 195 - Hamphrey.bin";
                case "EAAB2D7D": return "[AC] 196 - Freya.bin";
                case "0600E72F": return "[AC] 197 - Kid Cat.bin";
                case "BFD5F40B": return "[AC] 198 - Agent S.bin";
                case "03713D98": return "[AC] 199 - Big Top.bin";
                case "8D434251": return "[AC] 200 - Rocket.bin";
                case "4BFBA512": return "[AC] 201 - Rover.bin";
                case "5A9DDE29": return "[AC] 202 - Blathers.bin";
                case "FD0E532E": return "[AC] 203 - Tom Nook.bin";
                case "28AD1B7C": return "[AC] 204 - Pelly.bin";
                case "A58C673C": return "[AC] 205 - Phyllis.bin";
                case "599A11B7": return "[AC] 206 - Pete.bin";
                case "43305F0D": return "[AC] 207 - Mabel.bin";
                case "808365F0": return "[AC] 208 - Leif.bin";
                case "AAD6815B": return "[AC] 209 - Wendell.bin";
                case "6E28BE65": return "[AC] 210 - Cyrus.bin";
                case "E13D21E9": return "[AC] 211 - Grams.bin";
                case "B8D38B7A": return "[AC] 212 - Timmy.bin";
                case "CF10F3A4": return "[AC] 213 - Digby.bin";
                case "A6188062": return "[AC] 214 - Don Resetti.bin";
                case "A6DC661C": return "[AC] 215 - Isabelle.bin";
                case "D4C77A78": return "[AC] 216 - Franklin.bin";
                case "394943F5": return "[AC] 217 - Jingle.bin";
                case "820406D3": return "[AC] 218 - Lily.bin";
                case "2C58795D": return "[AC] 219 - Anchovy.bin";
                case "05C0E5B4": return "[AC] 220 - Tabby.bin";
                case "5E4F8281": return "[AC] 221 - Kody.bin";
                case "944CAEB2": return "[AC] 222 - Miranda.bin";
                case "A875847B": return "[AC] 223 - Del.bin";
                case "665E1D25": return "[AC] 224 - Paula.bin";
                case "CD75A5EE": return "[AC] 225 - Ken.bin";
                case "633D2D74": return "[AC] 226 - Mitzi.bin";
                case "84240333": return "[AC] 227 - Rodeo.bin";
                case "9544E3A0": return "[AC] 228 - Bubbles.bin";
                case "50007B2D": return "[AC] 229 - Cousteau.bin";
                case "C9197A94": return "[AC] 230 - Velma.bin";
                case "37492D05": return "[AC] 231 - Elvis.bin";
                case "C531198F": return "[AC] 232 - Canberra.bin";
                case "1D2E649B": return "[AC] 233 - Colton.bin";
                case "9D33C511": return "[AC] 234 - Marina.bin";
                case "8B0E6D83": return "[AC] 235 - Spork-Crackle.bin";
                case "644D2455": return "[AC] 236 - Freckles.bin";
                case "3C302317": return "[AC] 237 - Bam.bin";
                case "BFA7FFA5": return "[AC] 238 - Friga.bin";
                case "42C61E9D": return "[AC] 239 - Ricky.bin";
                case "2BF53028": return "[AC] 240 - Deirdre.bin";
                case "E43524E7": return "[AC] 241 - Hans.bin";
                case "58632846": return "[AC] 242 - Chevre.bin";
                case "02B6F528": return "[AC] 243 - Drago.bin";
                case "C976CD7B": return "[AC] 244 - Tangy.bin";
                case "1D43DE78": return "[AC] 245 - Mac.bin";
                case "45ED9D82": return "[AC] 246 - Eloise.bin";
                case "3F24DFE5": return "[AC] 247 - Wart Jr..bin";
                case "7F68385F": return "[AC] 248 - Hazel.bin";
                case "51B61A42": return "[AC] 249 - Beardo.bin";
                case "185A2FA3": return "[AC] 250 - Ava.bin";
                case "1944C5BA": return "[AC] 251 - Chester.bin";
                case "BD6A5399": return "[AC] 252 - Merry.bin";
                case "995E3CC0": return "[AC] 253 - Genji.bin";
                case "53B9FCDC": return "[AC] 254 - Greta.bin";
                case "0A233710": return "[AC] 255 - Wolfgang.bin";
                case "7A50BFAE": return "[AC] 256 - Diva.bin";
                case "93D2D484": return "[AC] 257 - Klaus.bin";
                case "454117DB": return "[AC] 258 - Daisy.bin";
                case "9C2DEE78": return "[AC] 259 - Stinky.bin";
                case "4CB6CAAC": return "[AC] 260 - Tammi.bin";
                case "8BCEA320": return "[AC] 261 - Tucker.bin";
                case "093A9D8B": return "[AC] 262 - Blanche.bin";
                case "1CAA856E": return "[AC] 263 - Gaston.bin";
                case "4E578C03": return "[AC] 264 - Marshal.bin";
                case "3FC15A49": return "[AC] 265 - Gala.bin";
                case "827F8986": return "[AC] 266 - Joey.bin";
                case "73AB93E7": return "[AC] 267 - Pippy.bin";
                case "8853CFB4": return "[AC] 268 - Buck.bin";
                case "60DC47E8": return "[AC] 269 - Bree.bin";
                case "A35A2CB1": return "[AC] 270 - Rooney.bin";
                case "5D330E9B": return "[AC] 271 - Curlos.bin";
                case "ABAF8E80": return "[AC] 272 - Skye.bin";
                case "9CCF251D": return "[AC] 273 - Moe.bin";
                case "4CE80ACD": return "[AC] 274 - Flora.bin";
                case "2155C640": return "[AC] 275 - Hamlet.bin";
                case "3DF73775": return "[AC] 276 - Astrid.bin";
                case "55A1F902": return "[AC] 277 - Monty.bin";
                case "A63C2DC4": return "[AC] 278 - Dora.bin";
                case "4A3362A1": return "[AC] 279 - Biskit.bin";
                case "E0696B6C": return "[AC] 280 - Victoria.bin";
                case "D52C4740": return "[AC] 281 - Lyman.bin";
                case "60C8E434": return "[AC] 282 - Violet.bin";
                case "A4A9DDD4": return "[AC] 283 - Frank.bin";
                case "8803225A": return "[AC] 284 - Chadder.bin";
                case "243EFA06": return "[AC] 285 - Merengue.bin";
                case "27EC2F2E": return "[AC] 286 - Cube.bin";
                case "B5A8B09F": return "[AC] 287 - Claudia.bin";
                case "4A645395": return "[AC] 288 - Curly.bin";
                case "19D385E5": return "[AC] 289 - Boomer.bin";
                case "FE7BD606": return "[AC] 290 - Caroline.bin";
                case "A68F4844": return "[AC] 291 - Sparro.bin";
                case "6CCCD74B": return "[AC] 292 - Baabara.bin";
                case "9BED1A0D": return "[AC] 293 - Rolf.bin";
                case "8749DEAF": return "[AC] 294 - Maple.bin";
                case "BF3D1764": return "[AC] 295 - Antonio.bin";
                case "F50A95BF": return "[AC] 296 - Soleil.bin";
                case "B341F345": return "[AC] 297 - Apollo.bin";
                case "8A2BB350": return "[AC] 298 - Derwin.bin";
                case "75E715C6": return "[AC] 299 - Francine.bin";
                case "56333EB2": return "[AC] 300 - Chrissy.bin";
                case "4B73733D": return "[AC] 301 - Isabelle.bin";
                case "46774C3F": return "[AC] 302 - Brewster.bin";
                case "3E0CC945": return "[AC] 303 - Katrina.bin";
                case "611FC49F": return "[AC] 304 - Phineas.bin";
                case "384B4C6E": return "[AC] 305 - Celeste.bin";
                case "A857415C": return "[AC] 306 - Tommy.bin";
                case "BF88B2EC": return "[AC] 307 - Gracie.bin";
                case "A4300A17": return "[AC] 308 - Leilani.bin";
                case "82757DFA": return "[AC] 309 - Resetti.bin";
                case "4BB866BB": return "[AC] 310 - Timmy.bin";
                case "1A9F8654": return "[AC] 311 - Lottie.bin";
                case "D2681136": return "[AC] 312 - Shrunk.bin";
                case "C76B45FD": return "[AC] 313 - Pave.bin";
                case "C6AF1481": return "[AC] 314 - Gulliver.bin";
                case "E7F785AA": return "[AC] 315 - Redd.bin";
                case "D9F7C14D": return "[AC] 316 - Zipper.bin";
                case "142AB15E": return "[AC] 317 - Goldie.bin";
                case "9CA9BBFD": return "[AC] 318 - Stitches.bin";
                case "F0B73E0D": return "[AC] 319 - Pinky.bin";
                case "5A7AE736": return "[AC] 320 - Mott.bin";
                case "BF094A14": return "[AC] 321 - Mallary.bin";
                case "0C77CA9C": return "[AC] 322 - Rocco.bin";
                case "041CDDD7": return "[AC] 323 - Katt.bin";
                case "76207C1C": return "[AC] 324 - Graham.bin";
                case "0BB2DBF9": return "[AC] 325 - Peaches.bin";
                case "05CF07EE": return "[AC] 326 - Dizzy.bin";
                case "321B10BC": return "[AC] 327 - Penelope.bin";
                case "ADEEB8C3": return "[AC] 328 - Boone.bin";
                case "1B668B74": return "[AC] 329 - Broffina.bin";
                case "0D3205A3": return "[AC] 330 - Croque.bin";
                case "9C9447EE": return "[AC] 331 - Pashmina.bin";
                case "411F6B6B": return "[AC] 332 - Shep.bin";
                case "C8CCF733": return "[AC] 333 - Lolly.bin";
                case "A9C04E49": return "[AC] 334 - Erik.bin";
                case "93F70135": return "[AC] 335 - Dotty.bin";
                case "8EA7E93E": return "[AC] 336 - Pierce.bin";
                case "4BBF12CD": return "[AC] 337 - Queenie.bin";
                case "74E69F3F": return "[AC] 338 - Fang.bin";
                case "D4AC09D0": return "[AC] 339 - Fritta.bin";
                case "25F4D761": return "[AC] 340 - Tex.bin";
                case "3F50434E": return "[AC] 341 - Melba.bin";
                case "CD934B9C": return "[AC] 342 - Bones.bin";
                case "C394F32B": return "[AC] 343 - Anabelle.bin";
                case "C3E6A632": return "[AC] 344 - Rudy.bin";
                case "070C6CA5": return "[AC] 345 - Naomi.bin";
                case "D12C6094": return "[AC] 346 - Peewee.bin";
                case "E886FD67": return "[AC] 347 - Tammy.bin";
                case "2280BBB6": return "[AC] 348 - Olaf.bin";
                case "E7F9339A": return "[AC] 349 - Lucy.bin";
                case "59DA0722": return "[AC] 350 - Elmer.bin";
                case "5B88E6AA": return "[AC] 351 - Puddles.bin";
                case "8E59EE63": return "[AC] 352 - Rory.bin";
                case "D47EC976": return "[AC] 353 - Elise.bin";
                case "B7491108": return "[AC] 354 - Walt.bin";
                case "C14B4AAF": return "[AC] 355 - Mira.bin";
                case "26E16E09": return "[AC] 356 - Pietro.bin";
                case "06FFD246": return "[AC] 357 - Aurora.bin";
                case "6F072ABC": return "[AC] 358 - Papi.bin";
                case "9C88E9D8": return "[AC] 359 - Apple.bin";
                case "F61C7C19": return "[AC] 360 - Rod.bin";
                case "58C71778": return "[AC] 361 - Purrl.bin";
                case "0EC73066": return "[AC] 362 - Static.bin";
                case "F3D35D1F": return "[AC] 363 - Celia.bin";
                case "9F819FF7": return "[AC] 364 - Zucker.bin";
                case "1ED1FEE9": return "[AC] 365 - Peggy.bin";
                case "FB80C9EC": return "[AC] 366 - Ribbot.bin";
                case "51F1FC16": return "[AC] 367 - Annalise.bin";
                case "B2B81D50": return "[AC] 368 - Chow.bin";
                case "707CC5BD": return "[AC] 369 - Sylvia.bin";
                case "733C5118": return "[AC] 370 - Jacques.bin";
                case "E06D20F1": return "[AC] 371 - Sally.bin";
                case "F180595D": return "[AC] 372 - Doc.bin";
                case "CBEF7919": return "[AC] 373 - Pompom.bin";
                case "FA3589B4": return "[AC] 374 - Tank.bin";
                case "4113E2B2": return "[AC] 375 - Becky.bin";
                case "5C1BE931": return "[AC] 376 - Rizzo.bin";
                case "8F8E6418": return "[AC] 377 - Sydney.bin";
                case "A0C4FED6": return "[AC] 378 - Barold.bin";
                case "765177D0": return "[AC] 379 - Nibbles.bin";
                case "5781B4D0": return "[AC] 380 - Kevin.bin";
                case "A46E55EA": return "[AC] 381 - Gloria.bin";
                case "FBCC3526": return "[AC] 382 - Lobo.bin";
                case "B8BAAD0E": return "[AC] 383 - Hippeux.bin";
                case "63BA41AE": return "[AC] 384 - Margie.bin";
                case "BFA40DC5": return "[AC] 385 - Lucky.bin";
                case "B847E290": return "[AC] 386 - Rosie.bin";
                case "7F0DE24E": return "[AC] 387 - Rowan.bin";
                case "0EBB08D1": return "[AC] 388 - Maelle.bin";
                case "F0C9064C": return "[AC] 389 - Bruce.bin";
                case "F524FE1D": return "[AC] 390 - O'Hare.bin";
                case "08CD257E": return "[AC] 391 - Gayle.bin";
                case "68FA0336": return "[AC] 392 - Cranston.bin";
                case "B312D82F": return "[AC] 393 - Frobert.bin";
                case "54EF5293": return "[AC] 394 - Grizzly.bin";
                case "4A12F8D7": return "[AC] 395 - Cally.bin";
                case "D1086CA4": return "[AC] 396 - Simon.bin";
                case "91C0D7DB": return "[AC] 397 - Iggly.bin";
                case "BD3E467B": return "[AC] 398 - Angus.bin";
                case "09A3640C": return "[AC] 399 - Twiggy.bin";
                case "E206604E": return "[AC] 400 - Robin.bin";
                case "B41F4230": return "[AC] W01 - Vivian.bin";
                case "9BA1E37A": return "[AC] W02 - Hopkins.bin";
                case "32EFBCD0": return "[AC] W03 - June.bin";
                case "BF4CAF55": return "[AC] W04 - Piper.bin";
                case "53A85C94": return "[AC] W05 - Paolo.bin";
                case "3C364714": return "[AC] W06 - Hornsby.bin";
                case "C033C4C6": return "[AC] W07 - Stella.bin";
                case "2D0A6DD2": return "[AC] W08 - Tybalt.bin";
                case "D1B1EF51": return "[AC] W09 - Huck.bin";
                case "102C5BE8": return "[AC] W10 - Sylvana.bin";
                case "ED5BEC15": return "[AC] W11 - Boris.bin";
                case "678A7E01": return "[AC] W12 - Wade.bin";
                case "5E5D4D8A": return "[AC] W13 - Carrie.bin";
                case "106035AA": return "[AC] W14 - Ketchup.bin";
                case "6732AD0F": return "[AC] W15 - Rex.bin";
                case "14BE5BBE": return "[AC] W16 - Stu.bin";
                case "B5464792": return "[AC] W17 - Ursala.bin";
                case "D345507E": return "[AC] W18 - Jacob.bin";
                case "75F54E7E": return "[AC] W19 - Maddie.bin";
                case "FAB675D1": return "[AC] W20 - Billy.bin";
                case "0BCE4B86": return "[AC] W21 - Boyd.bin";
                case "0850FBBA": return "[AC] W22 - Bitty.bin";
                case "297E16DB": return "[AC] W23 - Maggie.bin";
                case "1251182B": return "[AC] W24 - Murphy.bin";
                case "5D42F197": return "[AC] W25 - Plucky.bin";
                case "27F4BC65": return "[AC] W26 - Sandy.bin";
                case "F5946FF7": return "[AC] W27 - Claude.bin";
                case "2210D540": return "[AC] W28 - Raddle.bin";
                case "353D3557": return "[AC] W29 - Julia.bin";
                case "EFCE1F57": return "[AC] W30 - Louie.bin";
                case "B47E5B18": return "[AC] W31 - Bea.bin";
                case "A3141258": return "[AC] W32 - Admiral.bin";
                case "4FE0333F": return "[AC] W33 - Ellie.bin";
                case "76529452": return "[AC] W34 - Boots.bin";
                case "64F191ED": return "[AC] W35 - Weber.bin";
                case "3FE02603": return "[AC] W36 - Candi.bin";
                case "FB93430B": return "[AC] W37 - Leopold.bin";
                case "61CA7481": return "[AC] W38 - Spike.bin";
                case "8C6A43F7": return "[AC] W39 - Cashmere.bin";
                case "A9EB5599": return "[AC] W40 - Tad.bin";
                case "8389C21D": return "[AC] W41 - Norma.bin";
                case "4D0E7766": return "[AC] W42 - Gonzo.bin";
                case "355CEBF9": return "[AC] W43 - Sprocket.bin";
                case "950025A9": return "[AC] W44 - Snooty.bin";
                case "D15A6E0B": return "[AC] W45 - Olive.bin";
                case "8C38C46A": return "[AC] W46 - Dobie.bin";
                case "54E2F31C": return "[AC] W47 - Buzz.bin";
                case "A2DD84DF": return "[AC] W48 - Cleo.bin";
                case "32FA4CB2": return "[AC] W49 - Ike.bin";
                case "2C1D5DA0": return "[AC] W50 - Tasha.bin";
                case "5AF11CBA": return "[AC] 01 - Isabelle.bin";
                case "2EB5757D": return "[AC] 02 - K.K. Slider.bin";
                case "3920A611": return "[AC] 03 - Lottie.bin";
                case "78E8387B": return "[AC] 04 - Reese.bin";
                case "58F2419E": return "[AC] 05 - Cyrrus.bin";
                case "B136CF6F": return "[AC] 06 - Tom Nook.bin";
                case "E07EDAA1": return "[AC] 07 - Mabel.bin";
                case "66CECD15": return "[AC] 08 - Digby.bin";
                case "E0082CA9": return "[AC] 09 - Resetti.bin";
                case "B3868185": return "[AC] 10 - Blathers.bin";
                case "56A7E15D": return "[AC] 11 - Kicks.bin";
                case "5EB2F1B6": return "[AC] 12 - Celeste.bin";
                case "08C2EB4A": return "[AC] 13 - Timmy & Tommy.bin";
                case "546945CE": return "[AC] 14 - Rover.bin";
                case "0BA52436": return "[AC] 15 - Kapp'n.bin";
                case "FA654B77": return "[AC] 16 - Isabelle (Summer Outfit).bin";
                case "49CB9E91": return "[BB] 01 - Qbby.bin";
                case "A4BD2BB2": return "[CR] 01 - Chibi-Robo.bin";
                case "69852D0B": return "[FE] 01 - Alm.bin";
                case "A2085DFA": return "[FE] 02 - Celica.bin";
                case "F8A832FC": return "[Kirby] 01 - Kirby.bin";
                case "2A4DAA8A": return "[Kirby] 02 - Meta Knight.bin";
                case "E53F3A5D": return "[Kirby] 03 - King Dedede.bin";
                case "BE6DE49A": return "[Kirby] 04 - Waddle Dee.bin";
                case "B174F63D": return "[3AM] 01 - Mario Classic Colors.bin";
                case "2AD5DAB4": return "[3AM] 02 - Mario Modern Colors.bin";
                case "D90EDD24": return "[SM] 01 - Mario.bin";
                case "6683898D": return "[SM] 02 - Peach.bin";
                case "460784A6": return "[SM] 03 - Toad.bin";
                case "8AD18F6A": return "[SM] 04 - Luigi.bin";
                case "42634292": return "[SM] 05 - Yoshi.bin";
                case "5A55B678": return "[SM] 06 - Bowser.bin";
                case "85A9E618": return "[SM] 07 - Mario (Gold Edition).bin";
                case "0F4F0DDB": return "[SM] 08 - Mario (Silver Edition).bin";
                case "038C4743": return "[SM] 09 - Wario.bin";
                case "D3AD54A2": return "[SM] 10 - Waluigi.bin";
                case "977EE945": return "[SM] 11 - Daisy.bin";
                case "2B262D80": return "[SM] 12 - Rosalina.bin";
                case "12F03505": return "[SM] 13 - Donkey Kong.bin";
                case "75ABA3AF": return "[SM] 14 - Diddy Kong.bin";
                case "6EBDEA6E": return "[SM] 15 - Boo.bin";
                case "C507DC41": return "[MSS] 01 - Mario (Soccer).bin";
                case "15F33646": return "[MSS] 02 - Mario (Baseball).bin";
                case "27F158F7": return "[MSS] 03 - Mario (Tennis).bin";
                case "470E0943": return "[MSS] 04 - Mario (Golf).bin";
                case "02FE3E97": return "[MSS] 05 - Mario (Horse Racing).bin";
                case "F4541052": return "[MSS] 06 - Luigi (Soccer).bin";
                case "74333C6C": return "[MSS] 07 - Luigi (Baseball).bin";
                case "23112B19": return "[MSS] 08 - Luigi (Tennis).bin";
                case "6316E0CE": return "[MSS] 09 - Luigi (Golf).bin";
                case "0B350D20": return "[MSS] 10 - Luigi (Horse Racing).bin";
                case "BB67C2D7": return "[MSS] 11 - Peach (Soccer).bin";
                case "258AC3DD": return "[MSS] 12 - Peach (Baseball).bin";
                case "95334E7B": return "[MSS] 13 - Peach (Tennis).bin";
                case "94F9EBD2": return "[MSS] 14 - Peach (Golf).bin";
                case "04E5FD57": return "[MSS] 15 - Peach (Horse Racing).bin";
                case "3098FF75": return "[MSS] 16 - Daisy (Soccer).bin";
                case "0843CE24": return "[MSS] 17 - Daisy (Baseball).bin";
                case "801261B0": return "[MSS] 18 - Daisy (Tennis).bin";
                case "2FA61EE2": return "[MSS] 19 - Daisy (Golf).bin";
                case "FEEEC66D": return "[MSS] 20 - Daisy (Horse Racing).bin";
                case "F690EA04": return "[MSS] 21 - Yoshi (Soccer).bin";
                case "03121AAA": return "[MSS] 22 - Yoshi (Baseball).bin";
                case "7BF383E1": return "[MSS] 23 - Yoshi (Tennis).bin";
                case "F8CD1574": return "[MSS] 24 - Yoshi (Golf).bin";
                case "5CEAF19F": return "[MSS] 25 - Yoshi (Horse Racing).bin";
                case "E162F492": return "[MSS] 26 - Wario (Soccer).bin";
                case "B92FF4BE": return "[MSS] 27 - Wario (Baseball).bin";
                case "A66C72DD": return "[MSS] 28 - Wario (Tennis).bin";
                case "71E18704": return "[MSS] 29 - Wario (Golf).bin";
                case "F25D6B69": return "[MSS] 30 - Wario (Horse Racing).bin";
                case "4BB47A8B": return "[MSS] 31 - Waluigi (Soccer).bin";
                case "E3E813AE": return "[MSS] 32 - Waluigi (Baseball).bin";
                case "5C17C0A5": return "[MSS] 33 - Waluigi (Tennis).bin";
                case "0382DAFF": return "[MSS] 34 - Waluigi (Golf).bin";
                case "7784D873": return "[MSS] 35 - Waluigi (Horse Racing).bin";
                case "6A3E6889": return "[MSS] 36 - Donkey Kong (Soccer).bin";
                case "A9E41BAF": return "[MSS] 37 - Donkey Kong (Baseball).bin";
                case "C61EDD45": return "[MSS] 38 - Donkey Kong (Tennis).bin";
                case "86F1C38F": return "[MSS] 39 - Donkey Kong (Golf).bin";
                case "7925347B": return "[MSS] 40 - Donkey Kong (Horse Racing).bin";
                case "88215740": return "[MSS] 41 - Diddy Kong (Soccer).bin";
                case "E06D5765": return "[MSS] 42 - Diddy Kong (Baseball).bin";
                case "3D7BBEC4": return "[MSS] 43 - Diddy Kong (Tennis).bin";
                case "D72E5A5F": return "[MSS] 44 - Diddy Kong (Golf).bin";
                case "4D15F883": return "[MSS] 45 - Diddy Kong (Horse Racing).bin";
                case "D662617B": return "[MSS] 46 - Bowser (Soccer).bin";
                case "6FEF1D0D": return "[MSS] 47 - Bowser (Baseball).bin";
                case "2E96C833": return "[MSS] 48 - Bowser (Tennis).bin";
                case "EC5FA828": return "[MSS] 49 - Bowser (Golf).bin";
                case "12106237": return "[MSS] 50 - Bowser (Horse Racing).bin";
                case "E163DD1A": return "[MSS] 51 - Bowser Jr. (Soccer).bin";
                case "1173E751": return "[MSS] 52 - Bowser Jr. (Baseball).bin";
                case "CC09AB76": return "[MSS] 53 - Bowser Jr.  (Tennis).bin";
                case "8D4322E2": return "[MSS] 54 - Bowser Jr. (Golf).bin";
                case "549A2060": return "[MSS] 55 - Bowser Jr. (Horse Racing).bin";
                case "C76EEB8F": return "[MSS] 56 - Boo (Soccer).bin";
                case "78344431": return "[MSS] 57 - Boo (Baseball).bin";
                case "2A4F83D8": return "[MSS] 58 - Boo (Tennis).bin";
                case "ED076596": return "[MSS] 59 - Boo (Golf).bin";
                case "1BB912E6": return "[MSS] 60 - Boo (Horse Racing).bin";
                case "E367C64D": return "[MSS] 61 - Baby Mario (Soccer).bin";
                case "10B6E82C": return "[MSS] 62 - Baby Mario (Baseball).bin";
                case "F765BC5D": return "[MSS] 63 - Baby Mario (Tennis).bin";
                case "43D5550F": return "[MSS] 64 - Baby Mario (Golf).bin";
                case "40966C5A": return "[MSS] 65 - Baby Mario (Horse Racing).bin";
                case "1F31632F": return "[MSS] 66 - Baby Luigi (Soccer).bin";
                case "6119193C": return "[MSS] 67 - Baby Luigi (Baseball).bin";
                case "F9D53309": return "[MSS] 68 - Baby Luigi (Tennis).bin";
                case "3AEB3DE3": return "[MSS] 69 - Baby Luigi (Golf).bin";
                case "36727BF7": return "[MSS] 70 - Baby Luigi (Horse Racing).bin";
                case "712C06FA": return "[MSS] 71 - Birdo (Soccer).bin";
                case "32E6949F": return "[MSS] 72 - Birdo (Baseball).bin";
                case "662EAA01": return "[MSS] 73 - Birdo (Tennis).bin";
                case "B0AE5D85": return "[MSS] 74 - Birdo (Golf).bin";
                case "167C6F63": return "[MSS] 75 - Birdo (Horse Racing).bin";
                case "BDEBFF54": return "[MSS] 76 - Rosalina (Soccer).bin";
                case "1731377C": return "[MSS] 77 - Rosalina (Baseball).bin";
                case "5B1B8059": return "[MSS] 78 - Rosalina (Tennis).bin";
                case "5A1F5D83": return "[MSS] 79 - Rosalina (Golf).bin";
                case "945FBA84": return "[MSS] 80 - Rosalina (Horse Racing).bin";
                case "36856A9C": return "[MSS] 81 - Metal Mario (Soccer).bin";
                case "DBB7B740": return "[MSS] 82 - Metal Mario (Baseball).bin";
                case "0C7FBDA4": return "[MSS] 83 - Metal Mario (Tennis).bin";
                case "CED54304": return "[MSS] 84 - Metal Mario (Golf).bin";
                case "A1EBB303": return "[MSS] 85 - Metal Mario (Horse Racing).bin";
                case "171F162F": return "[MSS] 86 - Pink Gold Peach (Soccer).bin";
                case "DFE2DEBF": return "[MSS] 87 - Pink Gold Peach (Baseball).bin";
                case "4DA15823": return "[MSS] 88 - Pink Gold Peach (Tennis).bin";
                case "9B4FDE95": return "[MSS] 89 - Pink Gold Peach (Golf).bin";
                case "9346321C": return "[MSS] 90 - Pink Gold Peach (Horse Racing).bin";
                case "E16B616F": return "[MHS] 01 - One-Eyed Rathalos and Rider (Female).bin";
                case "8F39379C": return "[MHS] 02 - One-Eyed Rathalos and Rider (Male).bin";
                case "E6BDA7DC": return "[MHS] 03 - Nabiru.bin";
                case "A6DBFA72": return "[MHS] 04 - Rathian and Cheval.bin";
                case "AF29FF19": return "[MHS] 05 - Barioth and Ayuria.bin";
                case "B22D1D20": return "[MHS] 06 - Qurupeco and Dan.bin";
                case "BEF7940F": return "[PIK] 01 - Pikmin.bin";
                case "87FD4E73": return "[PT] 01 - Shadow Mewtwo.bin";
                case "19A6A164": return "[SN] 01 - Shovel Knight.bin";
                case "42DB98DB": return "[SS] 01 - Hammer Slam Bowser.bin";
                case "0EB9A5B5": return "[SS] 02 - Turbo Charge Donkey Kong.bin";
                case "ACA0A957": return "[SS] 03 - Dark Hammer Slam Bowser.bin";
                case "551FA85F": return "[SS] 04 - Dark Turbo Charge Donkey Kong.bin";
                case "4BD991E8": return "[Splatoon] 01 - Inkling Boy.bin";
                case "A45D565A": return "[Splatoon] 02 - Inkling Girl.bin";
                case "8D7AD4A6": return "[Splatoon] 03 - Inkling Squid.bin";
                case "0567FC5F": return "[Splatoon] 04 - Callie.bin";
                case "E6A721D4": return "[Splatoon] 05 - Marie.bin";
                case "692BEE6D": return "[Splatoon] 06 - Inkling Boy (Purple).bin";
                case "C78C2634": return "[Splatoon] 07 - Inkling Girl (Lime Green).bin";
                case "6802A56C": return "[Splatoon] 08 - Inkling Squid (Orange).bin";
                case "079E8BD4": return "[Splatoon] 09 - Inkling Boy (Neon Green).bin";
                case "57C1235F": return "[Splatoon] 10 - Inkling Girl (Neon Pink).bin";
                case "2869F678": return "[Splatoon] 11 - Squid (Neon Purple).bin";
                case "592B2E39": return "[SSB] 01 - Mario.bin";
                case "B51298C8": return "[SSB] 02 - Peach.bin";
                case "BCF922DF": return "[SSB] 03 - Yoshi.bin";
                case "4E6D0AEB": return "[SSB] 04 - Donkey Kong.bin";
                case "1BA6C153": return "[SSB] 05 - Link.bin";
                case "1BA62BE2": return "[SSB] 06 - Fox.bin";
                case "343EBFF6": return "[SSB] 07 - Samus.bin";
                case "9D921836": return "[SSB] 08 - Wii Fit Trainer.bin";
                case "54D39756": return "[SSB] 09 - Villager.bin";
                case "77E08732": return "[SSB] 10 - Pikachu.bin";
                case "CD2B5879": return "[SSB] 11 - Kirby.bin";
                case "30D44E6F": return "[SSB] 12 - Marth.bin";
                case "AA490BBF": return "[SSB] 13 - Zelda.bin";
                case "B2C91C30": return "[SSB] 14 - Diddy Kong.bin";
                case "0A9C0C36": return "[SSB] 15 - Luigi.bin";
                case "2D52D630": return "[SSB] 16 - Little Mac.bin";
                case "75EE024F": return "[SSB] 17 - Pit.bin";
                case "C8A32E17": return "[SSB] 18 - Captain Falcon.bin";
                case "56539C8D": return "[SSB] 19 - Rosalina.bin";
                case "6069ADF0": return "[SSB] 20 - Bowser.bin";
                case "B7A4DF04": return "[SSB] 21 - Lucario.bin";
                case "A38C7A49": return "[SSB] 22 - Toon Link.bin";
                case "98324D60": return "[SSB] 23 - Sheik.bin";
                case "4D0E8776": return "[SSB] 24 - Ike.bin";
                case "E1F93863": return "[SSB] 25 - Shulk.bin";
                case "A9A243A8": return "[SSB] 26 - Sonic.bin";
                case "4C5DF50B": return "[SSB] 27 - Mega Man.bin";
                case "E9DE4942": return "[SSB] 27S - Mega Man (Gold Edition).bin";
                case "CA2245F6": return "[SSB] 28 - King Dedede.bin";
                case "16CC07E1": return "[SSB] 29 - Meta Knight.bin";
                case "44704476": return "[SSB] 30 - Robin.bin";
                case "7ECD1560": return "[SSB] 31 - Lucina.bin";
                case "64922FAC": return "[SSB] 32 - Pac-Man.bin";
                case "6DDAA1B2": return "[SSB] 33 - Wario.bin";
                case "8886B172": return "[SSB] 34 - Ness.bin";
                case "F3146954": return "[SSB] 35 - Charizard.bin";
                case "CE8490CA": return "[SSB] 36 - Greninja.bin";
                case "BB8AE151": return "[SSB] 37 - Jigglypuff.bin";
                case "5A0C69B4": return "[SSB] 38 - Palutena.bin";
                case "1D5DCE25": return "[SSB] 39 - Dark Pit.bin";
                case "0BE4F8C2": return "[SSB] 40 - Zero Suit Samus.bin";
                case "5ED26D19": return "[SSB] 41 - Ganondorf.bin";
                case "BE3F4570": return "[SSB] 42 - Dr. Mario.bin";
                case "CD170CF9": return "[SSB] 43 - Bowser Jr.bin";
                case "FAF92B25": return "[SSB] 44 - Olimar.bin";
                case "7A025B3A": return "[SSB] 45 - Mr. Game & Watch.bin";
                case "A4457437": return "[SSB] 46 - R.O.B. (NES).bin";
                case "06F7F6F8": return "[SSB] 47 - Duck Hunt.bin";
                case "19894DA9": return "[SSB] 48 - Mii Brawler.bin";
                case "C0F150F1": return "[SSB] 49 - Mii Swordfighter.bin";
                case "EEB90B71": return "[SSB] 50 - Mii Gunner.bin";
                case "C77F6923": return "[SSB] 51 - Mewtwo.bin";
                case "1B39E68B": return "[SSB] 52 - Falco.bin";
                case "D69E0EAE": return "[SSB] 53 - Lucas.bin";
                case "1A165E7F": return "[SSB] 54 - R.O.B. (Famicom).bin";
                case "A4B4EB96": return "[SSB] 55 - Roy.bin";
                case "8BC15C94": return "[SSB] 56 - Ryu.bin";
                case "03BD908D": return "[SSB] 57 - Cloud.bin";
                case "4A44D076": return "[SSB] 58 - Cloud (Player 2).bin";
                case "4D2C4F6F": return "[SSB] 59 - Corrin.bin";
                case "9964D012": return "[SSB] 60 - Corrin (Player 2).bin";
                case "254798FB": return "[SSB] 61 - Bayonetta.bin";
                case "7510BC3F": return "[SSB] 62 - Bayonetta (Player 2).bin";
                case "F9322643": return "[3AZ] 01 - 8-bit Link (The Legend of Zelda).bin";
                case "CAA47A23": return "[3AZ] 02 - Link (Ocarina of Time).bin";
                case "79D23E1D": return "[3AZ] 03 - Toon Link (The Wind Waker).bin";
                case "D0BD0975": return "[3AZ] 04 - Toon Zelda (The Wind Waker).bin";
                case "D7934B56": return "[3AZ] 05 - Link (Majora's Mask).bin";
                case "2DAB9C19": return "[3AZ] 06 - Link (Twilight Princess).bin";
                case "BF8563E5": return "[3AZ] 07 - Link (Skyward Sword).bin";
                case "CBAB6F4B": return "[ZBW] 01 - Bokoblin.bin";
                case "1B0575DB": return "[ZBW] 02 - Guardian.bin";
                case "DA395512": return "[ZBW] 03 - Link (Archer).bin";
                case "8E191C46": return "[ZBW] 04 - Link (Rider).bin";
                case "79A71ADB": return "[ZBW] 05 - Zelda.bin";
                case "BC8AFC9E": return "[ZTP] 01 - Wolf Link.bin";
                case "D9CB27CB": return "[YWW] 01 - Green Yarn Yoshi.bin";
                case "AAFCB0B4": return "[YWW] 02 - Pink Yarn Yoshi.bin";
                case "2AD5A91D": return "[YWW] 03 - Light-Blue Yarn Yoshi.bin";
                case "2DEB5D6E": return "[YWW] 04 - Mega Yarn Yoshi.bin";
                case "53AE4F82": return "[YWW] 05 - Poochy.bin";
                case "EC1263CE": return "[AC] 001 - Isabelle [7-11 DLC Furniture].bin";
                case "6AC6661D": return "[AC] 001 - Isabelle [Battle Between Giants Contest Furniture].bin";
                case "2F3F44F0": return "[AC] 001 - Isabelle [Campus DLC Furniture].bin";
                case "877E0C79": return "[AC] 001 - Isabelle [Monster Hunter DLC Furniture].bin";
                case "B5F642DD": return "[AC] 001 - Isabelle [Sweetest Home Contest Furniture].bin";
                case "57138A8F": return "[AC] 001 - Isabelle [Video Game-Related Items DLC Furniture].bin";
                case "D68A6629": return "[MSS] 01 - Mario (Soccer) [Unlocked Superstar].bin";
                case "C58FBFF0": return "[MSS] 02 - Mario (Baseball) [Unlocked Superstar].bin";
                case "A3B40530": return "[MSS] 03 - Mario (Tennis) [Unlocked Superstar].bin";
                case "180627E8": return "[MSS] 04 - Mario (Golf) [Unlocked Superstar].bin";
                case "BF26A469": return "[MSS] 05 - Mario (Horse Racing) [Unlocked Superstar].bin";
                case "7F26A8ED": return "[MSS] 06 - Luigi (Soccer) [Unlocked Superstar].bin";
                case "22F9ACAF": return "[MSS] 07 - Luigi (Baseball) [Unlocked Superstar].bin";
                case "47E34CF8": return "[MSS] 08 - Luigi (Tennis) [Unlocked Superstar].bin";
                case "EE930592": return "[MSS] 09 - Luigi (Golf) [Unlocked Superstar].bin";
                case "94E805A3": return "[MSS] 10 - Luigi (Horse Racing) [Unlocked Superstar].bin";
                case "331363E0": return "[MSS] 11 - Peach (Soccer) [Unlocked Superstar].bin";
                case "3A55D90A": return "[MSS] 12 - Peach (Baseball) [Unlocked Superstar].bin";
                case "ED7AC146": return "[MSS] 13 - Peach (Tennis) [Unlocked Superstar].bin";
                case "1F2DDB24": return "[MSS] 14 - Peach (Golf) [Unlocked Superstar].bin";
                case "C34E5999": return "[MSS] 15 - Peach (Horse Racing) [Unlocked Superstar].bin";
                case "F4601BBA": return "[MSS] 16 - Daisy (Soccer) [Unlocked Superstar].bin";
                case "9C3EF9B5": return "[MSS] 17 - Daisy (Baseball) [Unlocked Superstar].bin";
                case "881F9E4E": return "[MSS] 18 - Daisy (Tennis) [Unlocked Superstar].bin";
                case "4D1BC292": return "[MSS] 19 - Daisy (Golf) [Unlocked Superstar].bin";
                case "C5D25F55": return "[MSS] 20 - Daisy (Horse Racing) [Unlocked Superstar].bin";
                case "8AF2177A": return "[MSS] 21 - Yoshi (Soccer) [Unlocked Superstar].bin";
                case "A7DDC66E": return "[MSS] 22 - Yoshi (Baseball) [Unlocked Superstar].bin";
                case "D01B09B2": return "[MSS] 23 - Yoshi (Tennis) [Unlocked Superstar].bin";
                case "3C0B8BB4": return "[MSS] 24 - Yoshi (Golf) [Unlocked Superstar].bin";
                case "87C5CBE7": return "[MSS] 25 - Yoshi (Horse Racing) [Unlocked Superstar].bin";
                case "F04309A4": return "[MSS] 26 - Wario (Soccer) [Unlocked Superstar].bin";
                case "E04E18FD": return "[MSS] 27 - Wario (Baseball) [Unlocked Superstar].bin";
                case "BF91CA3D": return "[MSS] 28 - Wario (Tennis) [Unlocked Superstar].bin";
                case "5D551A68": return "[MSS] 29 - Wario (Golf) [Unlocked Superstar].bin";
                case "5014F647": return "[MSS] 30 - Wario (Horse Racing) [Unlocked Superstar].bin";
                case "F15DCADB": return "[MSS] 31 - Waluigi (Soccer) [Unlocked Superstar].bin";
                case "1D87F9F0": return "[MSS] 32 - Waluigi (Baseball) [Unlocked Superstar].bin";
                case "16739325": return "[MSS] 33 - Waluigi (Tennis) [Unlocked Superstar].bin";
                case "4FAADE3F": return "[MSS] 34 - Waluigi (Golf) [Unlocked Superstar].bin";
                case "494960F0": return "[MSS] 35 - Waluigi (Horse Racing) [Unlocked Superstar].bin";
                case "CC78A7D2": return "[MSS] 36 - Donkey Kong (Soccer) [Unlocked Superstar].bin";
                case "1A36116E": return "[MSS] 37 - Donkey Kong (Baseball) [Unlocked Superstar].bin";
                case "4C22CFCA": return "[MSS] 38 - Donkey Kong (Tennis) [Unlocked Superstar].bin";
                case "BCB29474": return "[MSS] 39 - Donkey Kong (Golf) [Unlocked Superstar].bin";
                case "00F440FC": return "[MSS] 40 - Donkey Kong (Horse Racing) [Unlocked Superstar].bin";
                case "BC89E2E5": return "[MSS] 41 - Diddy Kong (Soccer) [Unlocked Superstar].bin";
                case "06C2A165": return "[MSS] 42 - Diddy Kong (Baseball) [Unlocked Superstar].bin";
                case "138CBF3F": return "[MSS] 43 - Diddy Kong (Tennis) [Unlocked Superstar].bin";
                case "9FA69317": return "[MSS] 44 - Diddy Kong (Golf) [Unlocked Superstar].bin";
                case "7CFEF186": return "[MSS] 45 - Diddy Kong (Horse Racing) [Unlocked Superstar].bin";
                case "3891FC59": return "[MSS] 46 - Bowser (Soccer) [Unlocked Superstar].bin";
                case "30D84139": return "[MSS] 47 - Bowser (Baseball) [Unlocked Superstar].bin";
                case "98510EF4": return "[MSS] 48 - Bowser (Tennis) [Unlocked Superstar].bin";
                case "71197807": return "[MSS] 49 - Bowser (Golf) [Unlocked Superstar].bin";
                case "982CF947": return "[MSS] 50 - Bowser (Horse Racing) [Unlocked Superstar].bin";
                case "30D03F6E": return "[MSS] 51 - Bowser Jr. (Soccer) [Unlocked Superstar].bin";
                case "34A4148A": return "[MSS] 52 - Bowser Jr. (Baseball) [Unlocked Superstar].bin";
                case "6C5D276F": return "[MSS] 53 - Bowser Jr.  (Tennis) [Unlocked Superstar].bin";
                case "F50DF9AB": return "[MSS] 54 - Bowser Jr. (Golf) [Unlocked Superstar].bin";
                case "459A7F26": return "[MSS] 55 - Bowser Jr. (Horse Racing) [Unlocked Superstar].bin";
                case "51631CE3": return "[MSS] 56 - Boo (Soccer) [Unlocked Superstar].bin";
                case "A7509C89": return "[MSS] 57 - Boo (Baseball) [Unlocked Superstar].bin";
                case "2910F439": return "[MSS] 58 - Boo (Tennis) [Unlocked Superstar].bin";
                case "320E7E66": return "[MSS] 59 - Boo (Golf) [Unlocked Superstar].bin";
                case "A50EF852": return "[MSS] 60 - Boo (Horse Racing) [Unlocked Superstar].bin";
                case "110A55FA": return "[MSS] 61 - Baby Mario (Soccer) [Unlocked Superstar].bin";
                case "DDF2AD55": return "[MSS] 62 - Baby Mario (Baseball) [Unlocked Superstar].bin";
                case "88AC6427": return "[MSS] 63 - Baby Mario (Tennis) [Unlocked Superstar].bin";
                case "E86D98C5": return "[MSS] 64 - Baby Mario (Golf) [Unlocked Superstar].bin";
                case "3263E885": return "[MSS] 65 - Baby Mario (Horse Racing) [Unlocked Superstar].bin";
                case "7F95C06C": return "[MSS] 66 - Baby Luigi (Soccer) [Unlocked Superstar].bin";
                case "6D380FAE": return "[MSS] 67 - Baby Luigi (Baseball) [Unlocked Superstar].bin";
                case "D4463CB3": return "[MSS] 68 - Baby Luigi (Tennis) [Unlocked Superstar].bin";
                case "DB6AF0EF": return "[MSS] 69 - Baby Luigi (Golf) [Unlocked Superstar].bin";
                case "53DF6E1E": return "[MSS] 70 - Baby Luigi (Horse Racing) [Unlocked Superstar].bin";
                case "1377093B": return "[MSS] 71 - Birdo (Soccer) [Unlocked Superstar].bin";
                case "7795D93E": return "[MSS] 72 - Birdo (Baseball) [Unlocked Superstar].bin";
                case "1ADB2DFD": return "[MSS] 73 - Birdo (Tennis) [Unlocked Superstar].bin";
                case "1BB6276D": return "[MSS] 74 - Birdo (Golf) [Unlocked Superstar].bin";
                case "18A32555": return "[MSS] 75 - Birdo (Horse Racing) [Unlocked Superstar].bin";
                case "1B73F7CA": return "[MSS] 76 - Rosalina (Soccer) [Unlocked Superstar].bin";
                case "A6CF15A2": return "[MSS] 77 - Rosalina (Baseball) [Unlocked Superstar].bin";
                case "B0DE77D8": return "[MSS] 78 - Rosalina (Tennis) [Unlocked Superstar].bin";
                case "2ED63630": return "[MSS] 79 - Rosalina (Golf) [Unlocked Superstar].bin";
                case "A76A1B87": return "[MSS] 80 - Rosalina (Horse Racing) [Unlocked Superstar].bin";
                case "B23B4D22": return "[MSS] 81 - Metal Mario (Soccer) [Unlocked Superstar].bin";
                case "753E6924": return "[MSS] 82 - Metal Mario (Baseball) [Unlocked Superstar].bin";
                case "44DBD65B": return "[MSS] 83 - Metal Mario (Tennis) [Unlocked Superstar].bin";
                case "7CE394A6": return "[MSS] 84 - Metal Mario (Golf) [Unlocked Superstar].bin";
                case "7E6E4655": return "[MSS] 85 - Metal Mario (Horse Racing) [Unlocked Superstar].bin";
                case "C8E5B2CD": return "[MSS] 86 - Pink Gold Peach (Soccer) [Unlocked Superstar].bin";
                case "78EDE1A7": return "[MSS] 87 - Pink Gold Peach (Baseball) [Unlocked Superstar].bin";
                case "3A989D5B": return "[MSS] 88 - Pink Gold Peach (Tennis) [Unlocked Superstar].bin";
                case "8C9B6F82": return "[MSS] 89 - Pink Gold Peach (Golf) [Unlocked Superstar].bin";
                case "DD1F450A": return "[MSS] 90 - Pink Gold Peach (Horse Racing) [Unlocked Superstar].bin";
                case "83CE0E87": return "[SM] 01 - Mario [Loaded with Mario Party 10 Special Data].bin";
                case "FD9F18E6": return "[SM] 02 - Peach [Loaded with Mario Party 10 Special Data].bin";
                case "73C1D16D": return "[SM] 03 - Toad [Loaded with Mario Party 10 Special Data].bin";
                case "7C10F500": return "[SM] 04 - Luigi [Loaded with Mario Party 10 Special Data].bin";
                case "13224713": return "[SM] 05 - Yoshi [Loaded with Mario Party 10 Special Data].bin";
                case "FDACC31D": return "[SM] 06 - Bowser [Loaded with Mario Party 10 Special Data].bin";
                case "596AA38B": return "[SM] 07 - Mario (Gold Edition) [Loaded with Mario Party 10 Special Data].bin";
                case "E19F8EAC": return "[SM] 08 - Mario (Silver Edition) [Loaded with Mario Party 10 Special Data].bin";
                case "BE3CCF00": return "[ZTP] 01 - Wolf Link [Max Hearts].bin";
                case "5C6F54BD": return "[MET] 01 - Samus Aran.bin";
                case "3D2FBB09": return "[MET] 02 - Metroid.bin";
                case "BB3E72BF": return "[SM] 16 - Goomba.bin";
                case "7B8B2708": return "[SM] 17 - Koopa Troopa.bin";
                case "CAB94AC3": return "[FE] 03 - Chrom.bin";
                case "0885316C": return "[FE] 04 - Tiki.bin";
                case "A5002B65": return "[SM] 18 - Mario(Wedding).bin";
                case "02105BE1": return "[SM] 19 - Peach(Wedding).bin";
                case "83E3D414": return "[SM] 20 - Bowser(Wedding).bin";
                case "39866704": return "[ZBW] 06 - Mipha (Zora Champion).bin";
                case "B9D36116": return "[ZBW] 07 - Daruk (Goron Champion).bin";
                case "238C61C6": return "[ZBW] 08 - Revali (Rito Champion).bin";
                case "12256389": return "[ZBW] 09 - Urbosa (Gerudo Champion).bin";
                case "3DD7B13E": return "[SMC] 01 - Super Mario Cereal.bin";
                default: return "";
            }
}

        #region 查表获得游戏信息

        /// <summary>
        /// 完整序列号 2018-01-24
        /// </summary>
        /// <param name="AmiiboSer"></param>
        /// <returns></returns>
        private string[] GetAmiiboName(string AmiiboSer)
        {
            string[][] strAmiiboName = new string[712][];

            #region 构建数组
            strAmiiboName[0] = new string[] { "", "", "", "", "", "", "" };
            strAmiiboName[1] = new string[] { "0000000000000002", "SSB", "Super Smash Bros.", "Wave 1", "Mario", "001", "001" };
            strAmiiboName[2] = new string[] { "0002000000010002", "SSB", "Super Smash Bros.", "Wave 1", "Peach", "002", "002" };
            strAmiiboName[3] = new string[] { "0003000000020002", "SSB", "Super Smash Bros.", "Wave 1", "Yoshi", "003", "003" };
            strAmiiboName[4] = new string[] { "0008000000030002", "SSB", "Super Smash Bros.", "Wave 1", "Donkey Kong", "004", "004" };
            strAmiiboName[5] = new string[] { "0100000000040002", "SSB", "Super Smash Bros.", "Wave 1", "Link", "005", "005" };
            strAmiiboName[6] = new string[] { "0580000000050002", "SSB", "Super Smash Bros.", "Wave 1", "Fox", "006", "006" };
            strAmiiboName[7] = new string[] { "05C0000000060002", "SSB", "Super Smash Bros.", "Wave 1", "Samus", "007", "007" };
            strAmiiboName[8] = new string[] { "0700000000070002", "SSB", "Super Smash Bros.", "Wave 1", "Wii Fit Trainer", "008", "008" };
            strAmiiboName[9] = new string[] { "0180000000080002", "SSB", "Super Smash Bros.", "Wave 1", "Villager", "009", "009" };
            strAmiiboName[10] = new string[] { "1919000000090002", "SSB", "Super Smash Bros.", "Wave 1", "Pikachu", "010", "010" };
            strAmiiboName[11] = new string[] { "1F000000000A0002", "SSB", "Super Smash Bros.", "Wave 1", "Kirby", "011", "011" };
            strAmiiboName[12] = new string[] { "21000000000B0002", "SSB", "Super Smash Bros.", "Wave 1", "Marth", "012", "012" };
            strAmiiboName[13] = new string[] { "01010000000E0002", "SSB", "Super Smash Bros.", "Wave 2", "Zelda", "013", "013" };
            strAmiiboName[14] = new string[] { "00090000000D0002", "SSB", "Super Smash Bros.", "Wave 2", "Diddy Kong", "014", "014" };
            strAmiiboName[15] = new string[] { "00010000000C0002", "SSB", "Super Smash Bros.", "Wave 2", "Luigi", "015", "015" };
            strAmiiboName[16] = new string[] { "06C00000000F0002", "SSB", "Super Smash Bros.", "Wave 2", "Little Mac", "016", "016" };
            strAmiiboName[17] = new string[] { "0740000000100002", "SSB", "Super Smash Bros.", "Wave 2", "Pit", "017", "017" };
            strAmiiboName[18] = new string[] { "0600000000120002", "SSB", "Super Smash Bros.", "Wave 2", "Captain Falcon", "018", "018" };
            strAmiiboName[19] = new string[] { "0004010000130002", "SSB", "Super Smash Bros.", "Wave 3", "Rosalina & Luma", "019", "019" };
            strAmiiboName[20] = new string[] { "0005000000140002", "SSB", "Super Smash Bros.", "Wave 3", "Bowser", "020", "020" };
            strAmiiboName[21] = new string[] { "1AC0000000110002", "SSB", "Super Smash Bros.", "Wave 3", "Lucario", "021", "021" };
            strAmiiboName[22] = new string[] { "0100010000160002", "SSB", "Super Smash Bros.", "Wave 3", "Toon Link", "022", "022" };
            strAmiiboName[23] = new string[] { "0101010000170002", "SSB", "Super Smash Bros.", "Wave 3", "Sheik", "023", "023" };
            strAmiiboName[24] = new string[] { "2101000000180002", "SSB", "Super Smash Bros.", "Wave 3", "Ike", "024", "024" };
            strAmiiboName[25] = new string[] { "22400000002B0002", "SSB", "Super Smash Bros.", "Wave 3", "Shulk", "025", "025" };
            strAmiiboName[26] = new string[] { "3200000000300002", "SSB", "Super Smash Bros.", "Wave 3", "Sonic", "026", "026" };
            strAmiiboName[27] = new string[] { "3480000000310002", "SSB", "Super Smash Bros.", "Wave 3", "Mega Man", "027", "027" };
            strAmiiboName[30] = new string[] { "3480000002580002", "SSB", "Super Smash Bros.", "Special Edition", "Mega Man (Gold Edition)", "027S", "030" };
            strAmiiboName[28] = new string[] { "1F02000000280002", "SSB", "Super Smash Bros.", "Wave 3", "King Dedede", "028", "028" };
            strAmiiboName[29] = new string[] { "1F01000000270002", "SSB", "Super Smash Bros.", "Wave 3", "Meta Knight", "029", "029" };
            strAmiiboName[31] = new string[] { "21030000002A0002", "SSB", "Super Smash Bros.", "Wave 4", "Robin", "030", "031" };
            strAmiiboName[32] = new string[] { "2102000000290002", "SSB", "Super Smash Bros.", "Wave 4", "Lucina", "031", "032" };
            strAmiiboName[33] = new string[] { "00070000001A0002", "SSB", "Super Smash Bros.", "Wave 4", "Wario", "032", "033" };
            strAmiiboName[34] = new string[] { "1906000000240002", "SSB", "Super Smash Bros.", "Wave 4", "Charizard", "033", "034" };
            strAmiiboName[35] = new string[] { "22800000002C0002", "SSB", "Super Smash Bros.", "Wave 4", "Ness", "034", "035" };
            strAmiiboName[36] = new string[] { "3340000000320002", "SSB", "Super Smash Bros.", "Wave 4", "Pac-Man", "035", "036" };
            strAmiiboName[37] = new string[] { "1B92000000250002", "SSB", "Super Smash Bros.", "Wave 4", "Greninja", "036", "037" };
            strAmiiboName[38] = new string[] { "1927000000260002", "SSB", "Super Smash Bros.", "Wave 4", "Jigglypuff", "037", "038" };
            strAmiiboName[39] = new string[] { "07420000001F0002", "SSB", "Super Smash Bros.", "Wave 5", "Palutena", "038", "039" };
            strAmiiboName[40] = new string[] { "0741000000200002", "SSB", "Super Smash Bros.", "Wave 5", "Dark Pit", "039", "040" };
            strAmiiboName[41] = new string[] { "05C00100001D0002", "SSB", "Super Smash Bros.", "Wave 6", "Zero Suit Samus", "040", "041" };
            strAmiiboName[42] = new string[] { "01020100001B0002", "SSB", "Super Smash Bros.", "Wave 6", "Ganondorf", "041", "042" };
            strAmiiboName[43] = new string[] { "0000010000190002", "SSB", "Super Smash Bros.", "Wave 6", "Dr. Mario", "042", "043" };
            strAmiiboName[44] = new string[] { "0006000000150002", "SSB", "Super Smash Bros.", "Wave 6", "Bowser Jr.", "043", "044" };
            strAmiiboName[45] = new string[] { "06400100001E0002", "SSB", "Super Smash Bros.", "Wave 6", "Olimar", "044", "045" };
            strAmiiboName[46] = new string[] { "07800000002D0002", "SSB", "Super Smash Bros.", "Wave 6", "Mr. Game & Watch", "045", "046" };
            strAmiiboName[47] = new string[] { "0781000000330002", "SSB", "Super Smash Bros.", "Wave 6", "R.O.B. (NES)", "046", "047" };
            strAmiiboName[48] = new string[] { "07820000002F0002", "SSB", "Super Smash Bros.", "Wave 6", "Duck Hunt", "047", "048" };
            strAmiiboName[49] = new string[] { "07C0000000210002", "SSB", "Super Smash Bros.", "Wave 7", "Mii Brawler", "048", "049" };
            strAmiiboName[50] = new string[] { "07C0010000220002", "SSB", "Super Smash Bros.", "Wave 7", "Mii Swordfighter", "049", "050" };
            strAmiiboName[51] = new string[] { "07C0020000230002", "SSB", "Super Smash Bros.", "Wave 7", "Mii Gunner", "050", "051" };
            strAmiiboName[52] = new string[] { "19960000023D0002", "SSB", "Super Smash Bros.", "Wave 7", "Mewtwo", "051", "052" };
            strAmiiboName[53] = new string[] { "05810000001C0002", "SSB", "Super Smash Bros.", "Wave 7", "Falco", "052", "053" };
            strAmiiboName[54] = new string[] { "2281000002510002", "SSB", "Super Smash Bros.", "Wave 8", "Lucas", "053", "054" };
            strAmiiboName[55] = new string[] { "07810000002E0002", "SSB", "Super Smash Bros.", "Wave 9", "R.O.B (Famicom)", "054", "055" };
            strAmiiboName[56] = new string[] { "2104000002520002", "SSB", "Super Smash Bros.", "Wave 9", "Roy", "055", "056" };
            strAmiiboName[57] = new string[] { "34C0000002530002", "SSB", "Super Smash Bros.", "Wave 9", "Ryu", "056", "057" };
            strAmiiboName[58] = new string[] { "3600000002590002", "SSB", "Super Smash Bros.", "Wave 10", "Cloud", "057", "058" };
            strAmiiboName[59] = new string[] { "3600010003620002", "SSB", "Super Smash Bros.", "Wave 10", "Cloud (Player 2)", "058", "059" };
            strAmiiboName[60] = new string[] { "21050000025A0002", "SSB", "Super Smash Bros.", "Wave 10", "Corrin", "059", "060" };
            strAmiiboName[61] = new string[] { "2105010003630002", "SSB", "Super Smash Bros.", "Wave 10", "Corrin (Player 2)", "060", "061" };
            strAmiiboName[62] = new string[] { "32400000025B0002", "SSB", "Super Smash Bros.", "Wave 10", "Bayonetta", "061", "062" };
            strAmiiboName[63] = new string[] { "3240010003640002", "SSB", "Super Smash Bros.", "Wave 10", "Bayonetta (Player 2)", "062", "063" };
            strAmiiboName[64] = new string[] { "0000000000340102", "SMB", "Super Mario", "Wave 1", "Mario", "001", "064" };
            strAmiiboName[65] = new string[] { "0002000000360102", "SMB", "Super Mario", "Wave 1", "Peach", "002", "065" };
            strAmiiboName[66] = new string[] { "000A000000380102", "SMB", "Super Mario", "Wave 1", "Toad", "003", "066" };
            strAmiiboName[67] = new string[] { "0001000000350102", "SMB", "Super Mario", "Wave 1", "Luigi", "004", "067" };
            strAmiiboName[68] = new string[] { "0003000000370102", "SMB", "Super Mario", "Wave 1", "Yoshi", "005", "068" };
            strAmiiboName[69] = new string[] { "0005000000390102", "SMB", "Super Mario", "Wave 1", "Bowser", "006", "069" };
            strAmiiboName[70] = new string[] { "00000000003C0102", "SMB", "Super Mario", "Wave 1 Special Editions", "Mario - Gold Edition", "007", "070" };
            strAmiiboName[71] = new string[] { "00000000003D0102", "SMB", "Super Mario", "Wave 1 Special Editions", "Mario - Silver Editon", "008", "071" };
            strAmiiboName[72] = new string[] { "0007000002630102", "SMB", "Super Mario", "Wave 2", "Wario", "009", "072" };
            strAmiiboName[73] = new string[] { "0014000002670102", "SMB", "Super Mario", "Wave 2", "Waluigi", "010", "073" };
            strAmiiboName[74] = new string[] { "0013000002660102", "SMB", "Super Mario", "Wave 2", "Daisy", "011", "074" };
            strAmiiboName[75] = new string[] { "0004000002620102", "SMB", "Super Mario", "Wave 2", "Rosalina", "012", "075" };
            strAmiiboName[76] = new string[] { "0008000002640102", "SMB", "Super Mario", "Wave 2", "Donkey Kong", "013", "076" };
            strAmiiboName[77] = new string[] { "0009000002650102", "SMB", "Super Mario", "Wave 2", "Diddy Kong", "014", "077" };
            strAmiiboName[78] = new string[] { "0017000002680102", "SMB", "Super Mario", "Wave 2", "Boo", "015", "078" };
            strAmiiboName[79] = new string[] { "0000000002380602", "SMB", "Super Mario", "Super Mario Bros. 30th Anniversary", "8-Bit Mario Classic Color", "001", "079" };
            strAmiiboName[80] = new string[] { "0000000002390602", "SMB", "Super Mario", "Super Mario Bros. 30th Anniversary", "8-Bit Mario Modern Color", "002", "080" };
            strAmiiboName[81] = new string[] { "0000000003710102", "SMB", "Super Mario", "Odyseey", "Mario(Wedding)", "018", "081" };
            strAmiiboName[82] = new string[] { "0002000003720102", "SMB", "Super Mario", "Odyseey", "Peac(Wedding)", "019", "082" };
            strAmiiboName[83] = new string[] { "0005000003730102", "SMB", "Super Mario", "Odyseey", "Bowser(Wedding)", "020", "083" };
            strAmiiboName[84] = new string[] { "0023000003680102", "SMB", "Super Mario", "", "Koopa Troopa", "017", "084" };
            strAmiiboName[85] = new string[] { "0015000003670102", "SMB", "Super Mario", "", "Goomba", "016", "085" };
            strAmiiboName[86] = new string[] { "09C0010102690E02", "MSS", "Mario Sports Superstars", "", "Mario - Soccer", "001", "086" };
            strAmiiboName[87] = new string[] { "09C00201026A0E02", "MSS", "Mario Sports Superstars", "", "Mario - Baseball", "002", "087" };
            strAmiiboName[88] = new string[] { "09C00301026B0E02", "MSS", "Mario Sports Superstars", "", "Mario - Tennis", "003", "088" };
            strAmiiboName[89] = new string[] { "09C00401026C0E02", "MSS", "Mario Sports Superstars", "", "Mario - Golf", "004", "089" };
            strAmiiboName[90] = new string[] { "09C00501026D0E02", "MSS", "Mario Sports Superstars", "", "Mario - Horse Racing", "005", "090" };
            strAmiiboName[91] = new string[] { "09C10101026E0E02", "MSS", "Mario Sports Superstars", "", "Luigi - Soccer", "006", "091" };
            strAmiiboName[92] = new string[] { "09C10201026F0E02", "MSS", "Mario Sports Superstars", "", "Luigi - Baseball", "007", "092" };
            strAmiiboName[93] = new string[] { "09C1030102700E02", "MSS", "Mario Sports Superstars", "", "Luigi - Tennis", "008", "093" };
            strAmiiboName[94] = new string[] { "09C1040102710E02", "MSS", "Mario Sports Superstars", "", "Luigi - Golf", "009", "094" };
            strAmiiboName[95] = new string[] { "09C1050102720E02", "MSS", "Mario Sports Superstars", "", "Luigi - Horse Racing", "010", "095" };
            strAmiiboName[96] = new string[] { "09C2010102730E02", "MSS", "Mario Sports Superstars", "", "Peach - Soccer", "011", "096" };
            strAmiiboName[97] = new string[] { "09C2020102740E02", "MSS", "Mario Sports Superstars", "", "Peach - Baseball", "012", "097" };
            strAmiiboName[98] = new string[] { "09C2030102750E02", "MSS", "Mario Sports Superstars", "", "Peach - Tennis", "013", "098" };
            strAmiiboName[99] = new string[] { "09C2040102760E02", "MSS", "Mario Sports Superstars", "", "Peach - Golf", "014", "099" };
            strAmiiboName[100] = new string[] { "09C2050102770E02", "MSS", "Mario Sports Superstars", "", "Peach - Horse Racing", "015", "100" };
            strAmiiboName[101] = new string[] { "09C3010102780E02", "MSS", "Mario Sports Superstars", "", "Daisy - Soccer", "016", "101" };
            strAmiiboName[102] = new string[] { "09C3020102790E02", "MSS", "Mario Sports Superstars", "", "Daisy - Baseball", "017", "102" };
            strAmiiboName[103] = new string[] { "09C30301027A0E02", "MSS", "Mario Sports Superstars", "", "Daisy - Tennis", "018", "103" };
            strAmiiboName[104] = new string[] { "09C30401027B0E02", "MSS", "Mario Sports Superstars", "", "Daisy - Golf", "019", "104" };
            strAmiiboName[105] = new string[] { "09C30501027C0E02", "MSS", "Mario Sports Superstars", "", "Daisy - Horse Racing", "020", "105" };
            strAmiiboName[106] = new string[] { "09C40101027D0E02", "MSS", "Mario Sports Superstars", "", "Yoshi - Soccer", "021", "106" };
            strAmiiboName[107] = new string[] { "09C40201027E0E02", "MSS", "Mario Sports Superstars", "", "Yoshi - Baseball", "022", "107" };
            strAmiiboName[108] = new string[] { "09C40301027F0E02", "MSS", "Mario Sports Superstars", "", "Yoshi - Tennis", "023", "108" };
            strAmiiboName[109] = new string[] { "09C4040102800E02", "MSS", "Mario Sports Superstars", "", "Yoshi - Golf", "024", "109" };
            strAmiiboName[110] = new string[] { "09C4050102810E02", "MSS", "Mario Sports Superstars", "", "Yoshi - Horse Racing", "025", "110" };
            strAmiiboName[111] = new string[] { "09C5010102820E02", "MSS", "Mario Sports Superstars", "", "Wario - Soccer", "026", "111" };
            strAmiiboName[112] = new string[] { "09C5020102830E02", "MSS", "Mario Sports Superstars", "", "Wario - Baseball", "027", "112" };
            strAmiiboName[113] = new string[] { "09C5030102840E02", "MSS", "Mario Sports Superstars", "", "Wario - Tennis", "028", "113" };
            strAmiiboName[114] = new string[] { "09C5040102850E02", "MSS", "Mario Sports Superstars", "", "Wario - Golf", "029", "114" };
            strAmiiboName[115] = new string[] { "09C5050102860E02", "MSS", "Mario Sports Superstars", "", "Wario - Horse Racing", "030", "115" };
            strAmiiboName[116] = new string[] { "09C6010102870E02", "MSS", "Mario Sports Superstars", "", "Waluigi - Soccer", "031", "116" };
            strAmiiboName[117] = new string[] { "09C6020102880E02", "MSS", "Mario Sports Superstars", "", "Waluigi - Baseball", "032", "117" };
            strAmiiboName[118] = new string[] { "09C6030102890E02", "MSS", "Mario Sports Superstars", "", "Waluigi - Tennis", "033", "118" };
            strAmiiboName[119] = new string[] { "09C60401028A0E02", "MSS", "Mario Sports Superstars", "", "Waluigi - Golf", "034", "119" };
            strAmiiboName[120] = new string[] { "09C60501028B0E02", "MSS", "Mario Sports Superstars", "", "Waluigi - Horse Racing", "035", "120" };
            strAmiiboName[121] = new string[] { "09C70101028C0E02", "MSS", "Mario Sports Superstars", "", "Donkey Kong - Soccer", "036", "121" };
            strAmiiboName[122] = new string[] { "09C70201028D0E02", "MSS", "Mario Sports Superstars", "", "Donkey Kong - Baseball", "037", "122" };
            strAmiiboName[123] = new string[] { "09C70301028E0E02", "MSS", "Mario Sports Superstars", "", "Donkey Kong - Tennis", "038", "123" };
            strAmiiboName[124] = new string[] { "09C70401028F0E02", "MSS", "Mario Sports Superstars", "", "Donkey Kong - Golf", "039", "124" };
            strAmiiboName[125] = new string[] { "09C7050102900E02", "MSS", "Mario Sports Superstars", "", "Donkey Kong - Horse Racing", "040", "125" };
            strAmiiboName[126] = new string[] { "09C8010102910E02", "MSS", "Mario Sports Superstars", "", "Diddy Kong - Soccer", "041", "126" };
            strAmiiboName[127] = new string[] { "09C8020102920E02", "MSS", "Mario Sports Superstars", "", "Diddy Kong - Baseball", "042", "127" };
            strAmiiboName[128] = new string[] { "09C8030102930E02", "MSS", "Mario Sports Superstars", "", "Diddy Kong - Tennis", "043", "128" };
            strAmiiboName[129] = new string[] { "09C8040102940E02", "MSS", "Mario Sports Superstars", "", "Diddy Kong - Golf", "044", "129" };
            strAmiiboName[130] = new string[] { "09C8050102950E02", "MSS", "Mario Sports Superstars", "", "Diddy Kong - Horse Racing", "045", "130" };
            strAmiiboName[131] = new string[] { "09C9010102960E02", "MSS", "Mario Sports Superstars", "", "Bowser - Soccer", "046", "131" };
            strAmiiboName[132] = new string[] { "09C9020102970E02", "MSS", "Mario Sports Superstars", "", "Bowser - Baseball", "047", "132" };
            strAmiiboName[133] = new string[] { "09C9030102980E02", "MSS", "Mario Sports Superstars", "", "Bowser - Tennis", "048", "133" };
            strAmiiboName[134] = new string[] { "09C9040102990E02", "MSS", "Mario Sports Superstars", "", "Bowser - Golf", "049", "134" };
            strAmiiboName[135] = new string[] { "09C90501029A0E02", "MSS", "Mario Sports Superstars", "", "Bowser - Horse Racing", "050", "135" };
            strAmiiboName[136] = new string[] { "09CA0101029B0E02", "MSS", "Mario Sports Superstars", "", "Bowser Jr. - Soccer", "051", "136" };
            strAmiiboName[137] = new string[] { "09CA0201029C0E02", "MSS", "Mario Sports Superstars", "", "Bowser Jr. - Baseball", "052", "137" };
            strAmiiboName[138] = new string[] { "09CA0301029D0E02", "MSS", "Mario Sports Superstars", "", "Bowser Jr. - Tennis", "053", "138" };
            strAmiiboName[139] = new string[] { "09CA0401029E0E02", "MSS", "Mario Sports Superstars", "", "Bowser Jr. - Golf", "054", "139" };
            strAmiiboName[140] = new string[] { "09CA0501029F0E02", "MSS", "Mario Sports Superstars", "", "Bowser Jr. - Horse Racing", "055", "140" };
            strAmiiboName[141] = new string[] { "09CB010102A00E02", "MSS", "Mario Sports Superstars", "", "Boo - Soccer", "056", "141" };
            strAmiiboName[142] = new string[] { "09CB020102A10E02", "MSS", "Mario Sports Superstars", "", "Boo - Baseball", "057", "142" };
            strAmiiboName[143] = new string[] { "09CB030102A20E02", "MSS", "Mario Sports Superstars", "", "Boo - Tennis", "058", "143" };
            strAmiiboName[144] = new string[] { "09CB040102A30E02", "MSS", "Mario Sports Superstars", "", "Boo - Golf", "059", "144" };
            strAmiiboName[145] = new string[] { "09CB050102A40E02", "MSS", "Mario Sports Superstars", "", "Boo - Horse Racing", "060", "145" };
            strAmiiboName[146] = new string[] { "09CC010102A50E02", "MSS", "Mario Sports Superstars", "", "Baby Mario - Soccer", "061", "146" };
            strAmiiboName[147] = new string[] { "09CC020102A60E02", "MSS", "Mario Sports Superstars", "", "Baby Mario - Baseball", "062", "147" };
            strAmiiboName[148] = new string[] { "09CC030102A70E02", "MSS", "Mario Sports Superstars", "", "Baby Mario - Tennis", "063", "148" };
            strAmiiboName[149] = new string[] { "09CC040102A80E02", "MSS", "Mario Sports Superstars", "", "Baby Mario - Golf", "064", "149" };
            strAmiiboName[150] = new string[] { "09CC050102A90E02", "MSS", "Mario Sports Superstars", "", "Baby Mario - Horse Racing", "065", "150" };
            strAmiiboName[151] = new string[] { "09CD010102AA0E02", "MSS", "Mario Sports Superstars", "", "Baby Luigi - Soccer", "066", "151" };
            strAmiiboName[152] = new string[] { "09CD020102AB0E02", "MSS", "Mario Sports Superstars", "", "Baby Luigi - Baseball", "067", "152" };
            strAmiiboName[153] = new string[] { "09CD030102AC0E02", "MSS", "Mario Sports Superstars", "", "Baby Luigi - Tennis", "068", "153" };
            strAmiiboName[154] = new string[] { "09CD040102AD0E02", "MSS", "Mario Sports Superstars", "", "Baby Luigi - Golf", "069", "154" };
            strAmiiboName[155] = new string[] { "09CD050102AE0E02", "MSS", "Mario Sports Superstars", "", "Baby Luigi - Horse Racing", "070", "155" };
            strAmiiboName[156] = new string[] { "09CE010102AF0E02", "MSS", "Mario Sports Superstars", "", "Birdo - Soccer", "071", "156" };
            strAmiiboName[157] = new string[] { "09CE020102B00E02", "MSS", "Mario Sports Superstars", "", "Birdo - Baseball", "072", "157" };
            strAmiiboName[158] = new string[] { "09CE030102B10E02", "MSS", "Mario Sports Superstars", "", "Birdo - Tennis", "073", "158" };
            strAmiiboName[159] = new string[] { "09CE040102B20E02", "MSS", "Mario Sports Superstars", "", "Birdo - Golf", "074", "159" };
            strAmiiboName[160] = new string[] { "09CE050102B30E02", "MSS", "Mario Sports Superstars", "", "Birdo - Horse Racing", "075", "160" };
            strAmiiboName[161] = new string[] { "09CF010102B40E02", "MSS", "Mario Sports Superstars", "", "Rosalina - Soccer", "076", "161" };
            strAmiiboName[162] = new string[] { "09CF020102B50E02", "MSS", "Mario Sports Superstars", "", "Rosalina - Baseball", "077", "162" };
            strAmiiboName[163] = new string[] { "09CF030102B60E02", "MSS", "Mario Sports Superstars", "", "Rosalina - Tennis", "078", "163" };
            strAmiiboName[164] = new string[] { "09CF040102B70E02", "MSS", "Mario Sports Superstars", "", "Rosalina - Golf", "079", "164" };
            strAmiiboName[165] = new string[] { "09CF050102B80E02", "MSS", "Mario Sports Superstars", "", "Rosalina - Horse Racing", "080", "165" };
            strAmiiboName[166] = new string[] { "09D0010102B90E02", "MSS", "Mario Sports Superstars", "", "Metal Mario - Soccer", "081", "166" };
            strAmiiboName[167] = new string[] { "09D0020102BA0E02", "MSS", "Mario Sports Superstars", "", "Metal Mario - Baseball", "082", "167" };
            strAmiiboName[168] = new string[] { "09D0030102BB0E02", "MSS", "Mario Sports Superstars", "", "Metal Mario - Tennis", "083", "168" };
            strAmiiboName[169] = new string[] { "09D0040102BC0E02", "MSS", "Mario Sports Superstars", "", "Metal Mario - Golf", "084", "169" };
            strAmiiboName[170] = new string[] { "09D0050102BD0E02", "MSS", "Mario Sports Superstars", "", "Metal Mario - Horse Racing", "085", "170" };
            strAmiiboName[171] = new string[] { "09D1010102BE0E02", "MSS", "Mario Sports Superstars", "", "Pink Gold Peach - Soccer", "086", "171" };
            strAmiiboName[172] = new string[] { "09D1020102BF0E02", "MSS", "Mario Sports Superstars", "", "Pink Gold Peach - Baseball", "087", "172" };
            strAmiiboName[173] = new string[] { "09D1030102C00E02", "MSS", "Mario Sports Superstars", "", "Pink Gold Peach - Tennis", "088", "173" };
            strAmiiboName[174] = new string[] { "09D1040102C10E02", "MSS", "Mario Sports Superstars", "", "Pink Gold Peach - Golf", "089", "174" };
            strAmiiboName[175] = new string[] { "09D1050102C20E02", "MSS", "Mario Sports Superstars", "", "Pink Gold Peach - Horse Racing", "090", "175" };
            strAmiiboName[176] = new string[] { "01030000024F0902", "LOZ", "The Legend of Zelda", "The Legend of Zelda", "Midna & Wolf Link", "001", "176" };
            strAmiiboName[177] = new string[] { "01000000034B0902", "LOZ", "The Legend of Zelda", "The Legend of Zelda 30th Anniversary Series", "Link - Ocarina of Time", "003", "177" };
            strAmiiboName[178] = new string[] { "01000000034F0902", "LOZ", "The Legend of Zelda", "The Legend of Zelda 30th Anniversary Series", "8- Bit Link", "002", "178" };
            strAmiiboName[179] = new string[] { "0100010003500902", "LOZ", "The Legend of Zelda", "The Legend of Zelda 30th Anniversary Series", "Toon Link - The Wind Waker", "004", "179" };
            strAmiiboName[180] = new string[] { "0101000003520902", "LOZ", "The Legend of Zelda", "The Legend of Zelda 30th Anniversary Series", "Toon Zelda - The Wind Waker", "005", "180" };
            strAmiiboName[181] = new string[] { "01000000034C0902", "LOZ", "The Legend of Zelda", "The Legend of Zelda 30th Anniversary Series", "Link - Majora's Mask", "006", "181" };
            strAmiiboName[182] = new string[] { "01000000034D0902", "LOZ", "The Legend of Zelda", "The Legend of Zelda 30th Anniversary Series", "Link - Twilight Princess", "007", "182" };
            strAmiiboName[183] = new string[] { "01000000034E0902", "LOZ", "The Legend of Zelda", "The Legend of Zelda 30th Anniversary Series", "Link - Skyward Sword", "008", "183" };
            strAmiiboName[184] = new string[] { "0100000003530902", "LOZ", "The Legend of Zelda", "The Legend of Zelda Breath of the Wild Series", "Link (Archer)", "011", "184" };
            strAmiiboName[185] = new string[] { "0100000003540902", "LOZ", "The Legend of Zelda", "The Legend of Zelda Breath of the Wild Series", "Link (Rider)", "012", "185" };
            strAmiiboName[186] = new string[] { "0140000003550902", "LOZ", "The Legend of Zelda", "The Legend of Zelda Breath of the Wild Series", "Guardian", "010", "186" };
            strAmiiboName[187] = new string[] { "0101000003560902", "LOZ", "The Legend of Zelda", "The Legend of Zelda Breath of the Wild Series", "Zelda", "013", "187" };
            strAmiiboName[188] = new string[] { "01410000035C0902", "LOZ", "The Legend of Zelda", "The Legend of Zelda Breath of the Wild Series", "Bokoblin", "009", "188" };
            strAmiiboName[189] = new string[] { "01070000035A0902", "LOZ", "The Legend of Zelda", "The Legend of Zelda Breath of the Wild Series", "Mipha", "013", "189" };
            strAmiiboName[190] = new string[] { "0105000003580902", "LOZ", "The Legend of Zelda", "The Legend of Zelda Breath of the Wild Series", "Daruk", "014", "190" };
            strAmiiboName[191] = new string[] { "01080000035B0902", "LOZ", "The Legend of Zelda", "The Legend of Zelda Breath of the Wild Series", "Revali", "015", "191" };
            strAmiiboName[192] = new string[] { "0106000003590902", "LOZ", "The Legend of Zelda", "The Legend of Zelda Breath of the Wild Series", "Urbosa", "016", "192" };
            strAmiiboName[193] = new string[] { "08000100003E0402", "SPL", "Splatoon", "Wave 1", "Inkling Girl", "002", "193" };
            strAmiiboName[194] = new string[] { "08000200003F0402", "SPL", "Splatoon", "Wave 1", "Inkling Boy", "001", "194" };
            strAmiiboName[195] = new string[] { "0800030000400402", "SPL", "Splatoon", "Wave 1", "Inkling Squid", "003", "195" };
            strAmiiboName[196] = new string[] { "08010000025D0402", "SPL", "Splatoon", "Wave 2", "Callie", "004", "196" };
            strAmiiboName[197] = new string[] { "08020000025E0402", "SPL", "Splatoon", "Wave 2", "Marie", "005", "197" };
            strAmiiboName[198] = new string[] { "08000100025F0402", "SPL", "Splatoon", "Wave 2", "Inkling Girl (Lime Green)", "007", "198" };
            strAmiiboName[199] = new string[] { "0800020002600402", "SPL", "Splatoon", "Wave 2", "Inkling Boy (Purple)", "006", "199" };
            strAmiiboName[200] = new string[] { "0800030002610402", "SPL", "Splatoon", "Wave 2", "Inkling Squid (Orange)", "008", "200" };
            strAmiiboName[201] = new string[] { "0800010003690402", "SPL", "Splatoon", "Wave 3", "Inkling Girl (Neon Pink)", "010", "201" };
            strAmiiboName[202] = new string[] { "08000200036A0402", "SPL", "Splatoon", "Wave 3", "Inkling Boy (Neon Green)", "009", "202" };
            strAmiiboName[203] = new string[] { "08000300036B0402", "SPL", "Splatoon", "Wave 3", "Inkling Squid (Neon Purple)", "011", "203" };
            strAmiiboName[204] = new string[] { "0181000100440502", "ACC", "Animal Crossing Cards", "Series 1", "Isabelle", "001", "204" };
            strAmiiboName[205] = new string[] { "0183000100450502", "ACC", "Animal Crossing Cards", "Series 1", "Tom Nook", "002", "205" };
            strAmiiboName[206] = new string[] { "0182010100460502", "ACC", "Animal Crossing Cards", "Series 1", "DJ KK", "003", "206" };
            strAmiiboName[207] = new string[] { "0187000100470502", "ACC", "Animal Crossing Cards", "Series 1", "Sable", "004", "207" };
            strAmiiboName[208] = new string[] { "0196000100480502", "ACC", "Animal Crossing Cards", "Series 1", "Kapp'n", "005", "208" };
            strAmiiboName[209] = new string[] { "018E000100490502", "ACC", "Animal Crossing Cards", "Series 1", "Resetti", "006", "209" };
            strAmiiboName[210] = new string[] { "01A30001004A0502", "ACC", "Animal Crossing Cards", "Series 1", "Joan", "007", "210" };
            strAmiiboName[211] = new string[] { "01850001004B0502", "ACC", "Animal Crossing Cards", "Series 1", "Timmy", "008", "211" };
            strAmiiboName[212] = new string[] { "018C0001004C0502", "ACC", "Animal Crossing Cards", "Series 1", "Digby", "009", "212" };
            strAmiiboName[213] = new string[] { "01A40001004D0502", "ACC", "Animal Crossing Cards", "Series 1", "Pascal", "010", "213" };
            strAmiiboName[214] = new string[] { "01910001004E0502", "ACC", "Animal Crossing Cards", "Series 1", "Harriet", "011", "214" };
            strAmiiboName[215] = new string[] { "01A80001004F0502", "ACC", "Animal Crossing Cards", "Series 1", "Redd", "012", "215" };
            strAmiiboName[216] = new string[] { "01A6000100500502", "ACC", "Animal Crossing Cards", "Series 1", "Sahara", "013", "216" };
            strAmiiboName[217] = new string[] { "01B5000100510502", "ACC", "Animal Crossing Cards", "Series 1", "Luna", "014", "217" };
            strAmiiboName[218] = new string[] { "01B0000100520502", "ACC", "Animal Crossing Cards", "Series 1", "Tortimer", "015", "218" };
            strAmiiboName[219] = new string[] { "01AA000100530502", "ACC", "Animal Crossing Cards", "Series 1", "Lyle", "016", "219" };
            strAmiiboName[220] = new string[] { "01C1000100540502", "ACC", "Animal Crossing Cards", "Series 1", "Lottie", "017", "220" };
            strAmiiboName[221] = new string[] { "025D000100550502", "ACC", "Animal Crossing Cards", "Series 1", "Bob", "018", "221" };
            strAmiiboName[222] = new string[] { "02D6000100560502", "ACC", "Animal Crossing Cards", "Series 1", "Fauna", "019", "222" };
            strAmiiboName[223] = new string[] { "0216000100570502", "ACC", "Animal Crossing Cards", "Series 1", "Curt", "020", "223" };
            strAmiiboName[224] = new string[] { "02EF000100580502", "ACC", "Animal Crossing Cards", "Series 1", "Portia", "021", "224" };
            strAmiiboName[225] = new string[] { "04FE000100590502", "ACC", "Animal Crossing Cards", "Series 1", "Leonardo", "022", "225" };
            strAmiiboName[226] = new string[] { "02870001005A0502", "ACC", "Animal Crossing Cards", "Series 1", "Cheri", "023", "226" };
            strAmiiboName[227] = new string[] { "05150001005B0502", "ACC", "Animal Crossing Cards", "Series 1", "Kyle", "024", "227" };
            strAmiiboName[228] = new string[] { "03710001005C0502", "ACC", "Animal Crossing Cards", "Series 1", "Al", "025", "228" };
            strAmiiboName[229] = new string[] { "04BA0001005D0502", "ACC", "Animal Crossing Cards", "Series 1", "Renée", "026", "229" };
            strAmiiboName[230] = new string[] { "02DB0001005E0502", "ACC", "Animal Crossing Cards", "Series 1", "Lopez", "027", "230" };
            strAmiiboName[231] = new string[] { "03450001005F0502", "ACC", "Animal Crossing Cards", "Series 1", "Jambette", "028", "231" };
            strAmiiboName[232] = new string[] { "047A000100600502", "ACC", "Animal Crossing Cards", "Series 1", "Rasher", "029", "232" };
            strAmiiboName[233] = new string[] { "049B000100610502", "ACC", "Animal Crossing Cards", "Series 1", "Tiffany", "030", "233" };
            strAmiiboName[234] = new string[] { "04ED000100620502", "ACC", "Animal Crossing Cards", "Series 1", "Sheldon", "031", "234" };
            strAmiiboName[235] = new string[] { "027D000100630502", "ACC", "Animal Crossing Cards", "Series 1", "Bluebear", "032", "235" };
            strAmiiboName[236] = new string[] { "0307000100640502", "ACC", "Animal Crossing Cards", "Series 1", "Bill", "033", "236" };
            strAmiiboName[237] = new string[] { "0261000100650502", "ACC", "Animal Crossing Cards", "Series 1", "Kiki", "034", "237" };
            strAmiiboName[238] = new string[] { "0401000100660502", "ACC", "Animal Crossing Cards", "Series 1", "Deli", "035", "238" };
            strAmiiboName[239] = new string[] { "02C4000100670502", "ACC", "Animal Crossing Cards", "Series 1", "Alli", "036", "239" };
            strAmiiboName[240] = new string[] { "0266000100680502", "ACC", "Animal Crossing Cards", "Series 1", "Kabuki", "037", "240" };
            strAmiiboName[241] = new string[] { "02B1000100690502", "ACC", "Animal Crossing Cards", "Series 1", "Patty", "038", "241" };
            strAmiiboName[242] = new string[] { "02310001006A0502", "ACC", "Animal Crossing Cards", "Series 1", "Jitters", "039", "242" };
            strAmiiboName[243] = new string[] { "03480001006B0502", "ACC", "Animal Crossing Cards", "Series 1", "Gigi", "040", "243" };
            strAmiiboName[244] = new string[] { "03180001006C0502", "ACC", "Animal Crossing Cards", "Series 1", "Quillson", "041", "244" };
            strAmiiboName[245] = new string[] { "03DB0001006D0502", "ACC", "Animal Crossing Cards", "Series 1", "Marcie", "042", "245" };
            strAmiiboName[246] = new string[] { "04650001006E0502", "ACC", "Animal Crossing Cards", "Series 1", "Puck", "043", "246" };
            strAmiiboName[247] = new string[] { "04000001006F0502", "ACC", "Animal Crossing Cards", "Series 1", "Shari", "044", "247" };
            strAmiiboName[248] = new string[] { "0429000100700502", "ACC", "Animal Crossing Cards", "Series 1", "Octavian", "045", "248" };
            strAmiiboName[249] = new string[] { "03A9000100710502", "ACC", "Animal Crossing Cards", "Series 1", "Winnie", "046", "249" };
            strAmiiboName[250] = new string[] { "02A4000100720502", "ACC", "Animal Crossing Cards", "Series 1", "Knox", "047", "250" };
            strAmiiboName[251] = new string[] { "0452000100730502", "ACC", "Animal Crossing Cards", "Series 1", "Sterling", "048", "251" };
            strAmiiboName[252] = new string[] { "04A5000100740502", "ACC", "Animal Crossing Cards", "Series 1", "Bonbon", "049", "252" };
            strAmiiboName[253] = new string[] { "0263000100750502", "ACC", "Animal Crossing Cards", "Series 1", "Punchy", "050", "253" };
            strAmiiboName[254] = new string[] { "0323000100760502", "ACC", "Animal Crossing Cards", "Series 1", "Opal", "051", "254" };
            strAmiiboName[255] = new string[] { "04EC000100770502", "ACC", "Animal Crossing Cards", "Series 1", "Poppy", "052", "255" };
            strAmiiboName[256] = new string[] { "040D000100780502", "ACC", "Animal Crossing Cards", "Series 1", "Limberg", "053", "256" };
            strAmiiboName[257] = new string[] { "030B000100790502", "ACC", "Animal Crossing Cards", "Series 1", "Deena", "054", "257" };
            strAmiiboName[258] = new string[] { "04970001007A0502", "ACC", "Animal Crossing Cards", "Series 1", "Snake", "055", "258" };
            strAmiiboName[259] = new string[] { "04FD0001007B0502", "ACC", "Animal Crossing Cards", "Series 1", "Bangle", "056", "259" };
            strAmiiboName[260] = new string[] { "043D0001007C0502", "ACC", "Animal Crossing Cards", "Series 1", "Phil", "057", "260" };
            strAmiiboName[261] = new string[] { "02680001007D0502", "ACC", "Animal Crossing Cards", "Series 1", "Monique", "058", "261" };
            strAmiiboName[262] = new string[] { "02190001007E0502", "ACC", "Animal Crossing Cards", "Series 1", "Nate", "059", "262" };
            strAmiiboName[263] = new string[] { "04100001007F0502", "ACC", "Animal Crossing Cards", "Series 1", "Samson", "060", "263" };
            strAmiiboName[264] = new string[] { "021B000100800502", "ACC", "Animal Crossing Cards", "Series 1", "Tutu", "061", "264" };
            strAmiiboName[265] = new string[] { "024F000100810502", "ACC", "Animal Crossing Cards", "Series 1", "T-Bone", "062", "265" };
            strAmiiboName[266] = new string[] { "04E6000100820502", "ACC", "Animal Crossing Cards", "Series 1", "Mint", "063", "266" };
            strAmiiboName[267] = new string[] { "0280000100830502", "ACC", "Animal Crossing Cards", "Series 1", "Pudge", "064", "267" };
            strAmiiboName[268] = new string[] { "0235000100840502", "ACC", "Animal Crossing Cards", "Series 1", "Midge", "065", "268" };
            strAmiiboName[269] = new string[] { "035A000100850502", "ACC", "Animal Crossing Cards", "Series 1", "Gruff", "066", "269" };
            strAmiiboName[270] = new string[] { "0384000100860502", "ACC", "Animal Crossing Cards", "Series 1", "Flurry", "067", "270" };
            strAmiiboName[271] = new string[] { "03AE000100870502", "ACC", "Animal Crossing Cards", "Series 1", "Clyde", "068", "271" };
            strAmiiboName[272] = new string[] { "040E000100880502", "ACC", "Animal Crossing Cards", "Series 1", "Bella", "069", "272" };
            strAmiiboName[273] = new string[] { "0394000100890502", "ACC", "Animal Crossing Cards", "Series 1", "Biff", "070", "273" };
            strAmiiboName[274] = new string[] { "03BC0001008A0502", "ACC", "Animal Crossing Cards", "Series 1", "Yuka", "071", "274" };
            strAmiiboName[275] = new string[] { "03EE0001008B0502", "ACC", "Animal Crossing Cards", "Series 1", "Lionel", "072", "275" };
            strAmiiboName[276] = new string[] { "046C0001008C0502", "ACC", "Animal Crossing Cards", "Series 1", "Flo", "073", "276" };
            strAmiiboName[277] = new string[] { "04800001008D0502", "ACC", "Animal Crossing Cards", "Series 1", "Cobb", "074", "277" };
            strAmiiboName[278] = new string[] { "044C0001008E0502", "ACC", "Animal Crossing Cards", "Series 1", "Amelia", "075", "278" };
            strAmiiboName[279] = new string[] { "033F0001008F0502", "ACC", "Animal Crossing Cards", "Series 1", "Jeremiah", "076", "279" };
            strAmiiboName[280] = new string[] { "02FB000100900502", "ACC", "Animal Crossing Cards", "Series 1", "Cherry", "077", "280" };
            strAmiiboName[281] = new string[] { "03A8000100910502", "ACC", "Animal Crossing Cards", "Series 1", "Rosco", "078", "281" };
            strAmiiboName[282] = new string[] { "0479000100920502", "ACC", "Animal Crossing Cards", "Series 1", "Truffles", "079", "282" };
            strAmiiboName[283] = new string[] { "03C6000100930502", "ACC", "Animal Crossing Cards", "Series 1", "Eugene", "080", "283" };
            strAmiiboName[284] = new string[] { "04C7000100940502", "ACC", "Animal Crossing Cards", "Series 1", "Eunice", "081", "284" };
            strAmiiboName[285] = new string[] { "0299000100950502", "ACC", "Animal Crossing Cards", "Series 1", "Goose", "082", "285" };
            strAmiiboName[286] = new string[] { "0208000100960502", "ACC", "Animal Crossing Cards", "Series 1", "Annalisa", "083", "286" };
            strAmiiboName[287] = new string[] { "02FA000100970502", "ACC", "Animal Crossing Cards", "Series 1", "Benjamin", "084", "287" };
            strAmiiboName[288] = new string[] { "0488000100980502", "ACC", "Animal Crossing Cards", "Series 1", "Pancetti", "085", "288" };
            strAmiiboName[289] = new string[] { "050B000100990502", "ACC", "Animal Crossing Cards", "Series 1", "Chief", "086", "289" };
            strAmiiboName[290] = new string[] { "04940001009A0502", "ACC", "Animal Crossing Cards", "Series 1", "Bunnie", "087", "290" };
            strAmiiboName[291] = new string[] { "03830001009B0502", "ACC", "Animal Crossing Cards", "Series 1", "Clay", "088", "291" };
            strAmiiboName[292] = new string[] { "02DE0001009C0502", "ACC", "Animal Crossing Cards", "Series 1", "Diana", "089", "292" };
            strAmiiboName[293] = new string[] { "03290001009D0502", "ACC", "Animal Crossing Cards", "Series 1", "Axel", "090", "293" };
            strAmiiboName[294] = new string[] { "04D10001009E0502", "ACC", "Animal Crossing Cards", "Series 1", "Muffy", "091", "294" };
            strAmiiboName[295] = new string[] { "034B0001009F0502", "ACC", "Animal Crossing Cards", "Series 1", "Henry", "092", "295" };
            strAmiiboName[296] = new string[] { "0393000100A00502", "ACC", "Animal Crossing Cards", "Series 1", "Bertha", "093", "296" };
            strAmiiboName[297] = new string[] { "0200000100A10502", "ACC", "Animal Crossing Cards", "Series 1", "Cyrano", "094", "297" };
            strAmiiboName[298] = new string[] { "04DD000100A20502", "ACC", "Animal Crossing Cards", "Series 1", "Peanut", "095", "298" };
            strAmiiboName[299] = new string[] { "04A6000100A30502", "ACC", "Animal Crossing Cards", "Series 1", "Cole", "096", "299" };
            strAmiiboName[300] = new string[] { "04CC000100A40502", "ACC", "Animal Crossing Cards", "Series 1", "Willow", "097", "300" };
            strAmiiboName[301] = new string[] { "0460000100A50502", "ACC", "Animal Crossing Cards", "Series 1", "Roald", "098", "301" };
            strAmiiboName[302] = new string[] { "0317000100A60502", "ACC", "Animal Crossing Cards", "Series 1", "Molly", "099", "302" };
            strAmiiboName[303] = new string[] { "02F0000100A70502", "ACC", "Animal Crossing Cards", "Series 1", "Walker", "100", "303" };
            strAmiiboName[304] = new string[] { "0182000100A80502", "ACC", "Animal Crossing Cards", "Series 2", "K.K. Slider", "101", "304" };
            strAmiiboName[305] = new string[] { "018A000100A90502", "ACC", "Animal Crossing Cards", "Series 2", "Reese", "102", "305" };
            strAmiiboName[306] = new string[] { "0194000100AA0502", "ACC", "Animal Crossing Cards", "Series 2", "Kicks", "103", "306" };
            strAmiiboName[307] = new string[] { "0189000100AB0502", "ACC", "Animal Crossing Cards", "Series 2", "Labelle", "104", "307" };
            strAmiiboName[308] = new string[] { "019D000100AC0502", "ACC", "Animal Crossing Cards", "Series 2", "Copper", "105", "308" };
            strAmiiboName[309] = new string[] { "019E000100AD0502", "ACC", "Animal Crossing Cards", "Series 2", "Booker", "106", "309" };
            strAmiiboName[310] = new string[] { "01B6000100AE0502", "ACC", "Animal Crossing Cards", "Series 2", "Katie", "107", "310" };
            strAmiiboName[311] = new string[] { "0186010100AF0502", "ACC", "Animal Crossing Cards", "Series 2", "Tommy", "108", "311" };
            strAmiiboName[312] = new string[] { "0195000100B00502", "ACC", "Animal Crossing Cards", "Series 2", "Porter", "109", "312" };
            strAmiiboName[313] = new string[] { "0198000100B10502", "ACC", "Animal Crossing Cards", "Series 2", "Lelia", "110", "313" };
            strAmiiboName[314] = new string[] { "01B1000100B20502", "ACC", "Animal Crossing Cards", "Series 2", "Dr. Shrunk", "111", "314" };
            strAmiiboName[315] = new string[] { "018F000100B30502", "ACC", "Animal Crossing Cards", "Series 2", "Don Resetti", "112", "315" };
            strAmiiboName[316] = new string[] { "0181010100B40502", "ACC", "Animal Crossing Cards", "Series 2", "Isabelle (Aut)", "113", "316" };
            strAmiiboName[317] = new string[] { "01B3000100B50502", "ACC", "Animal Crossing Cards", "Series 2", "Blanca", "114", "317" };
            strAmiiboName[318] = new string[] { "019B000100B60502", "ACC", "Animal Crossing Cards", "Series 2", "Nat", "115", "318" };
            strAmiiboName[319] = new string[] { "019A000100B70502", "ACC", "Animal Crossing Cards", "Series 2", "Chip", "116", "319" };
            strAmiiboName[320] = new string[] { "01AD000100B80502", "ACC", "Animal Crossing Cards", "Series 2", "Jack", "117", "320" };
            strAmiiboName[321] = new string[] { "027F000100B90502", "ACC", "Animal Crossing Cards", "Series 2", "Poncho", "118", "321" };
            strAmiiboName[322] = new string[] { "026E000100BA0502", "ACC", "Animal Crossing Cards", "Series 2", "Felicity", "119", "322" };
            strAmiiboName[323] = new string[] { "03C1000100BB0502", "ACC", "Animal Crossing Cards", "Series 2", "Ozzie", "120", "323" };
            strAmiiboName[324] = new string[] { "032D000100BC0502", "ACC", "Animal Crossing Cards", "Series 2", "Tia", "121", "324" };
            strAmiiboName[325] = new string[] { "023C000100BD0502", "ACC", "Animal Crossing Cards", "Series 2", "Lucha", "122", "325" };
            strAmiiboName[326] = new string[] { "02DC000100BE0502", "ACC", "Animal Crossing Cards", "Series 2", "Fuchsia", "123", "326" };
            strAmiiboName[327] = new string[] { "0398000100BF0502", "ACC", "Animal Crossing Cards", "Series 2", "Harry", "124", "327" };
            strAmiiboName[328] = new string[] { "0464000100C00502", "ACC", "Animal Crossing Cards", "Series 2", "Gwen", "125", "328" };
            strAmiiboName[329] = new string[] { "0251000100C10502", "ACC", "Animal Crossing Cards", "Series 2", "Coach", "126", "329" };
            strAmiiboName[330] = new string[] { "03D1000100C20502", "ACC", "Animal Crossing Cards", "Series 2", "Kitt", "127", "330" };
            strAmiiboName[331] = new string[] { "026C000100C30502", "ACC", "Animal Crossing Cards", "Series 2", "Tom", "128", "331" };
            strAmiiboName[332] = new string[] { "02B2000100C40502", "ACC", "Animal Crossing Cards", "Series 2", "Tipper", "129", "332" };
            strAmiiboName[333] = new string[] { "0344000100C50502", "ACC", "Animal Crossing Cards", "Series 2", "Prince", "130", "333" };
            strAmiiboName[334] = new string[] { "0309000100C60502", "ACC", "Animal Crossing Cards", "Series 2", "Pate", "131", "334" };
            strAmiiboName[335] = new string[] { "0283000100C70502", "ACC", "Animal Crossing Cards", "Series 2", "Vladimir", "132", "335" };
            strAmiiboName[336] = new string[] { "03A6000100C80502", "ACC", "Animal Crossing Cards", "Series 2", "Savannah", "133", "336" };
            strAmiiboName[337] = new string[] { "035D000100C90502", "ACC", "Animal Crossing Cards", "Series 2", "Kidd", "134", "337" };
            strAmiiboName[338] = new string[] { "0440000100CA0502", "ACC", "Animal Crossing Cards", "Series 2", "Phoebe", "135", "338" };
            strAmiiboName[339] = new string[] { "029B000100CB0502", "ACC", "Animal Crossing Cards", "Series 2", "Egbert", "136", "339" };
            strAmiiboName[340] = new string[] { "02F2000100CC0502", "ACC", "Animal Crossing Cards", "Series 2", "Cookie", "137", "340" };
            strAmiiboName[341] = new string[] { "02C9000100CD0502", "ACC", "Animal Crossing Cards", "Series 2", "Sly", "138", "341" };
            strAmiiboName[342] = new string[] { "04DE000100CE0502", "ACC", "Animal Crossing Cards", "Series 2", "Blaire", "139", "342" };
            strAmiiboName[343] = new string[] { "0450000100CF0502", "ACC", "Animal Crossing Cards", "Series 2", "Avery", "140", "343" };
            strAmiiboName[344] = new string[] { "03FA000100D00502", "ACC", "Animal Crossing Cards", "Series 2", "Nana", "141", "344" };
            strAmiiboName[345] = new string[] { "023E000100D10502", "ACC", "Animal Crossing Cards", "Series 2", "Peck", "142", "345" };
            strAmiiboName[346] = new string[] { "0260000100D20502", "ACC", "Animal Crossing Cards", "Series 2", "Olivia", "143", "346" };
            strAmiiboName[347] = new string[] { "0369000100D30502", "ACC", "Animal Crossing Cards", "Series 2", "Cesar", "144", "347" };
            strAmiiboName[348] = new string[] { "04A4000100D40502", "ACC", "Animal Crossing Cards", "Series 2", "Carmen", "145", "348" };
            strAmiiboName[349] = new string[] { "0381000100D50502", "ACC", "Animal Crossing Cards", "Series 2", "Rodney", "146", "349" };
            strAmiiboName[350] = new string[] { "0311000100D60502", "ACC", "Animal Crossing Cards", "Series 2", "Scoot", "147", "350" };
            strAmiiboName[351] = new string[] { "050E000100D70502", "ACC", "Animal Crossing Cards", "Series 2", "Whitney", "148", "351" };
            strAmiiboName[352] = new string[] { "0418000100D80502", "ACC", "Animal Crossing Cards", "Series 2", "Broccolo", "149", "352" };
            strAmiiboName[353] = new string[] { "0496000100D90502", "ACC", "Animal Crossing Cards", "Series 2", "Coco", "150", "353" };
            strAmiiboName[354] = new string[] { "021A000100DA0502", "ACC", "Animal Crossing Cards", "Series 2", "Groucho", "151", "354" };
            strAmiiboName[355] = new string[] { "04CE000100DB0502", "ACC", "Animal Crossing Cards", "Series 2", "Wendy", "152", "355" };
            strAmiiboName[356] = new string[] { "02C3000100DC0502", "ACC", "Animal Crossing Cards", "Series 2", "Alfonso", "153", "356" };
            strAmiiboName[357] = new string[] { "04B3000100DD0502", "ACC", "Animal Crossing Cards", "Series 2", "Rhonda", "154", "357" };
            strAmiiboName[358] = new string[] { "02EB000100DE0502", "ACC", "Animal Crossing Cards", "Series 2", "Butch", "155", "358" };
            strAmiiboName[359] = new string[] { "0499000100DF0502", "ACC", "Animal Crossing Cards", "Series 2", "Gabi", "156", "359" };
            strAmiiboName[360] = new string[] { "041A000100E00502", "ACC", "Animal Crossing Cards", "Series 2", "Moose", "157", "360" };
            strAmiiboName[361] = new string[] { "04CF000100E10502", "ACC", "Animal Crossing Cards", "Series 2", "Timbra", "158", "361" };
            strAmiiboName[362] = new string[] { "02D8000100E20502", "ACC", "Animal Crossing Cards", "Series 2", "Zell", "159", "362" };
            strAmiiboName[363] = new string[] { "028B000100E30502", "ACC", "Animal Crossing Cards", "Series 2", "Pekoe", "160", "363" };
            strAmiiboName[364] = new string[] { "0214000100E40502", "ACC", "Animal Crossing Cards", "Series 2", "Teddy", "161", "364" };
            strAmiiboName[365] = new string[] { "03D2000100E50502", "ACC", "Animal Crossing Cards", "Series 2", "Mathilda", "162", "365" };
            strAmiiboName[366] = new string[] { "03AA000100E60502", "ACC", "Animal Crossing Cards", "Series 2", "Ed", "163", "366" };
            strAmiiboName[367] = new string[] { "0500000100E70502", "ACC", "Animal Crossing Cards", "Series 2", "Bianca", "164", "367" };
            strAmiiboName[368] = new string[] { "04DF000100E80502", "ACC", "Animal Crossing Cards", "Series 2", "Filbert", "165", "368" };
            strAmiiboName[369] = new string[] { "026B000100E90502", "ACC", "Animal Crossing Cards", "Series 2", "Kitty", "166", "369" };
            strAmiiboName[370] = new string[] { "02DD000100EA0502", "ACC", "Animal Crossing Cards", "Series 2", "Beau", "167", "370" };
            strAmiiboName[371] = new string[] { "0357000100EB0502", "ACC", "Animal Crossing Cards", "Series 2", "Nan", "168", "371" };
            strAmiiboName[372] = new string[] { "03E6000100EC0502", "ACC", "Animal Crossing Cards", "Series 2", "Bud", "169", "372" };
            strAmiiboName[373] = new string[] { "049D000100ED0502", "ACC", "Animal Crossing Cards", "Series 2", "Ruby", "170", "373" };
            strAmiiboName[374] = new string[] { "029A000100EE0502", "ACC", "Animal Crossing Cards", "Series 2", "Benedict", "171", "374" };
            strAmiiboName[375] = new string[] { "0489000100EF0502", "ACC", "Animal Crossing Cards", "Series 2", "Agnes", "172", "375" };
            strAmiiboName[376] = new string[] { "03B1000100F00502", "ACC", "Animal Crossing Cards", "Series 2", "Julian", "173", "376" };
            strAmiiboName[377] = new string[] { "041B000100F10502", "ACC", "Animal Crossing Cards", "Series 2", "Bettina", "174", "377" };
            strAmiiboName[378] = new string[] { "022D000100F20502", "ACC", "Animal Crossing Cards", "Series 2", "Jay", "175", "378" };
            strAmiiboName[379] = new string[] { "046D000100F30502", "ACC", "Animal Crossing Cards", "Series 2", "Sprinkle", "176", "379" };
            strAmiiboName[380] = new string[] { "03FF000100F40502", "ACC", "Animal Crossing Cards", "Series 2", "Flip", "177", "380" };
            strAmiiboName[381] = new string[] { "047B000100F50502", "ACC", "Animal Crossing Cards", "Series 2", "Hugh", "178", "381" };
            strAmiiboName[382] = new string[] { "0462000100F60502", "ACC", "Animal Crossing Cards", "Series 2", "Hopper", "179", "382" };
            strAmiiboName[383] = new string[] { "04E0000100F70502", "ACC", "Animal Crossing Cards", "Series 2", "Pecan", "180", "383" };
            strAmiiboName[384] = new string[] { "0310000100F80502", "ACC", "Animal Crossing Cards", "Series 2", "Drake", "181", "384" };
            strAmiiboName[385] = new string[] { "03BD000100F90502", "ACC", "Animal Crossing Cards", "Series 2", "Alice", "182", "385" };
            strAmiiboName[386] = new string[] { "033B000100FA0502", "ACC", "Animal Crossing Cards", "Series 2", "Camofrog", "183", "386" };
            strAmiiboName[387] = new string[] { "0416000100FB0502", "ACC", "Animal Crossing Cards", "Series 2", "Anicotti", "184", "387" };
            strAmiiboName[388] = new string[] { "0486000100FC0502", "ACC", "Animal Crossing Cards", "Series 2", "Chops", "185", "388" };
            strAmiiboName[389] = new string[] { "0220000100FD0502", "ACC", "Animal Crossing Cards", "Series 2", "Charlise", "186", "389" };
            strAmiiboName[390] = new string[] { "0252000100FE0502", "ACC", "Animal Crossing Cards", "Series 2", "Vic", "187", "390" };
            strAmiiboName[391] = new string[] { "0270000100FF0502", "ACC", "Animal Crossing Cards", "Series 2", "Ankha", "188", "391" };
            strAmiiboName[392] = new string[] { "033C000101000502", "ACC", "Animal Crossing Cards", "Series 2", "Drift", "189", "392" };
            strAmiiboName[393] = new string[] { "04C5000101010502", "ACC", "Animal Crossing Cards", "Series 2", "Vesta", "190", "393" };
            strAmiiboName[394] = new string[] { "02F9000101020502", "ACC", "Animal Crossing Cards", "Series 2", "Marcel", "191", "394" };
            strAmiiboName[395] = new string[] { "0202000101030502", "ACC", "Animal Crossing Cards", "Series 2", "Pango", "192", "395" };
            strAmiiboName[396] = new string[] { "0453000101040502", "ACC", "Animal Crossing Cards", "Series 2", "Keaton", "193", "396" };
            strAmiiboName[397] = new string[] { "0437000101050502", "ACC", "Animal Crossing Cards", "Series 2", "Gladys", "194", "397" };
            strAmiiboName[398] = new string[] { "0385000101060502", "ACC", "Animal Crossing Cards", "Series 2", "Hamphrey", "195", "398" };
            strAmiiboName[399] = new string[] { "0510000101070502", "ACC", "Animal Crossing Cards", "Series 2", "Freya", "196", "399" };
            strAmiiboName[400] = new string[] { "0267000101080502", "ACC", "Animal Crossing Cards", "Series 2", "Kid Cat", "197", "400" };
            strAmiiboName[401] = new string[] { "04E2000101090502", "ACC", "Animal Crossing Cards", "Series 2", "Agent S", "198", "401" };
            strAmiiboName[402] = new string[] { "03250001010A0502", "ACC", "Animal Crossing Cards", "Series 2", "Big Top", "199", "402" };
            strAmiiboName[403] = new string[] { "03720001010B0502", "ACC", "Animal Crossing Cards", "Series 2", "Rocket", "200", "403" };
            strAmiiboName[404] = new string[] { "018D0001010C0502", "ACC", "Animal Crossing Cards", "Series 3", "Rover", "201", "404" };
            strAmiiboName[405] = new string[] { "01920001010D0502", "ACC", "Animal Crossing Cards", "Series 3", "Blathers", "202", "405" };
            strAmiiboName[406] = new string[] { "01830101010E0502", "ACC", "Animal Crossing Cards", "Series 3", "Tom Nook", "203", "406" };
            strAmiiboName[407] = new string[] { "01A00001010F0502", "ACC", "Animal Crossing Cards", "Series 3", "Pelly", "204", "407" };
            strAmiiboName[408] = new string[] { "01A1000101100502", "ACC", "Animal Crossing Cards", "Series 3", "Phyllis", "205", "408" };
            strAmiiboName[409] = new string[] { "019F000101110502", "ACC", "Animal Crossing Cards", "Series 3", "Pete", "206", "409" };
            strAmiiboName[410] = new string[] { "0188000101120502", "ACC", "Animal Crossing Cards", "Series 3", "Mabel", "207", "410" };
            strAmiiboName[411] = new string[] { "01B4000101130502", "ACC", "Animal Crossing Cards", "Series 3", "Leif", "208", "411" };
            strAmiiboName[412] = new string[] { "01A7000101140502", "ACC", "Animal Crossing Cards", "Series 3", "Wendell", "209", "412" };
            strAmiiboName[413] = new string[] { "018B000101150502", "ACC", "Animal Crossing Cards", "Series 3", "Cyrus", "210", "413" };
            strAmiiboName[414] = new string[] { "0199000101160502", "ACC", "Animal Crossing Cards", "Series 3", "Grams", "211", "414" };
            strAmiiboName[415] = new string[] { "0185020101170502", "ACC", "Animal Crossing Cards", "Series 3", "Timmy", "212", "415" };
            strAmiiboName[416] = new string[] { "018C010101180502", "ACC", "Animal Crossing Cards", "Series 3", "Digby", "213", "416" };
            strAmiiboName[417] = new string[] { "018F010101190502", "ACC", "Animal Crossing Cards", "Series 3", "Don Resetti", "214", "417" };
            strAmiiboName[418] = new string[] { "01810201011A0502", "ACC", "Animal Crossing Cards", "Series 3", "Isabelle", "215", "418" };
            strAmiiboName[419] = new string[] { "01AE0001011B0502", "ACC", "Animal Crossing Cards", "Series 3", "Franklin", "216", "419" };
            strAmiiboName[420] = new string[] { "01AF0001011C0502", "ACC", "Animal Crossing Cards", "Series 3", "Jingle", "217", "420" };
            strAmiiboName[421] = new string[] { "03380001011D0502", "ACC", "Animal Crossing Cards", "Series 3", "Lily", "218", "421" };
            strAmiiboName[422] = new string[] { "022F0001011E0502", "ACC", "Animal Crossing Cards", "Series 3", "Anchovy", "219", "422" };
            strAmiiboName[423] = new string[] { "02690001011F0502", "ACC", "Animal Crossing Cards", "Series 3", "Tabby", "220", "423" };
            strAmiiboName[424] = new string[] { "0281000101200502", "ACC", "Animal Crossing Cards", "Series 3", "Kody", "221", "424" };
            strAmiiboName[425] = new string[] { "0313000101210502", "ACC", "Animal Crossing Cards", "Series 3", "Miranda", "222", "425" };
            strAmiiboName[426] = new string[] { "02C7000101220502", "ACC", "Animal Crossing Cards", "Series 3", "Del", "223", "426" };
            strAmiiboName[427] = new string[] { "021E000101230502", "ACC", "Animal Crossing Cards", "Series 3", "Paula", "224", "427" };
            strAmiiboName[428] = new string[] { "02A6000101240502", "ACC", "Animal Crossing Cards", "Series 3", "Ken", "225", "428" };
            strAmiiboName[429] = new string[] { "025E000101250502", "ACC", "Animal Crossing Cards", "Series 3", "Mitzi", "226", "429" };
            strAmiiboName[430] = new string[] { "024B000101260502", "ACC", "Animal Crossing Cards", "Series 3", "Rodeo", "227", "430" };
            strAmiiboName[431] = new string[] { "0392000101270502", "ACC", "Animal Crossing Cards", "Series 3", "Bubbles", "228", "431" };
            strAmiiboName[432] = new string[] { "0342000101280502", "ACC", "Animal Crossing Cards", "Series 3", "Cousteau", "229", "432" };
            strAmiiboName[433] = new string[] { "035C000101290502", "ACC", "Animal Crossing Cards", "Series 3", "Velma", "230", "433" };
            strAmiiboName[434] = new string[] { "03E70001012A0502", "ACC", "Animal Crossing Cards", "Series 3", "Elvis", "231", "434" };
            strAmiiboName[435] = new string[] { "03C40001012B0502", "ACC", "Animal Crossing Cards", "Series 3", "Canberra", "232", "435" };
            strAmiiboName[436] = new string[] { "03AF0001012C0502", "ACC", "Animal Crossing Cards", "Series 3", "Colton", "233", "436" };
            strAmiiboName[437] = new string[] { "042A0001012D0502", "ACC", "Animal Crossing Cards", "Series 3", "Marina", "234", "437" };
            strAmiiboName[438] = new string[] { "047D0001012E0502", "ACC", "Animal Crossing Cards", "Series 3", "Spork-Crackle", "235", "438" };
            strAmiiboName[439] = new string[] { "030E0001012F0502", "ACC", "Animal Crossing Cards", "Series 3", "Freckles", "236", "439" };
            strAmiiboName[440] = new string[] { "02D7000101300502", "ACC", "Animal Crossing Cards", "Series 3", "Bam", "237", "440" };
            strAmiiboName[441] = new string[] { "0463000101310502", "ACC", "Animal Crossing Cards", "Series 3", "Friga", "238", "441" };
            strAmiiboName[442] = new string[] { "04E7000101320502", "ACC", "Animal Crossing Cards", "Series 3", "Ricky", "239", "442" };
            strAmiiboName[443] = new string[] { "02DA000101330502", "ACC", "Animal Crossing Cards", "Series 3", "Deirdre", "240", "443" };
            strAmiiboName[444] = new string[] { "0373000101340502", "ACC", "Animal Crossing Cards", "Series 3", "Hans", "241", "444" };
            strAmiiboName[445] = new string[] { "0356000101350502", "ACC", "Animal Crossing Cards", "Series 3", "Chevre", "242", "445" };
            strAmiiboName[446] = new string[] { "02CB000101360502", "ACC", "Animal Crossing Cards", "Series 3", "Drago", "243", "446" };
            strAmiiboName[447] = new string[] { "0262000101370502", "ACC", "Animal Crossing Cards", "Series 3", "Tangy", "244", "447" };
            strAmiiboName[448] = new string[] { "02F8000101380502", "ACC", "Animal Crossing Cards", "Series 3", "Mac", "245", "448" };
            strAmiiboName[449] = new string[] { "0326000101390502", "ACC", "Animal Crossing Cards", "Series 3", "Eloise", "246", "449" };
            strAmiiboName[450] = new string[] { "033D0001013A0502", "ACC", "Animal Crossing Cards", "Series 3", "Wart Jr.", "247", "450" };
            strAmiiboName[451] = new string[] { "04EF0001013B0502", "ACC", "Animal Crossing Cards", "Series 3", "Hazel", "248", "451" };
            strAmiiboName[452] = new string[] { "02210001013C0502", "ACC", "Animal Crossing Cards", "Series 3", "Beardo", "249", "452" };
            strAmiiboName[453] = new string[] { "029E0001013D0502", "ACC", "Animal Crossing Cards", "Series 3", "Ava", "250", "453" };
            strAmiiboName[454] = new string[] { "028C0001013E0502", "ACC", "Animal Crossing Cards", "Series 3", "Chester", "251", "454" };
            strAmiiboName[455] = new string[] { "026D0001013F0502", "ACC", "Animal Crossing Cards", "Series 3", "Merry", "252", "455" };
            strAmiiboName[456] = new string[] { "049C000101400502", "ACC", "Animal Crossing Cards", "Series 3", "Genji", "253", "456" };
            strAmiiboName[457] = new string[] { "041C000101410502", "ACC", "Animal Crossing Cards", "Series 3", "Greta", "254", "457" };
            strAmiiboName[458] = new string[] { "050D000101420502", "ACC", "Animal Crossing Cards", "Series 3", "Wolfgang", "255", "458" };
            strAmiiboName[459] = new string[] { "034A000101430502", "ACC", "Animal Crossing Cards", "Series 3", "Diva", "256", "459" };
            strAmiiboName[460] = new string[] { "0222000101440502", "ACC", "Animal Crossing Cards", "Series 3", "Klaus", "257", "460" };
            strAmiiboName[461] = new string[] { "02F1000101450502", "ACC", "Animal Crossing Cards", "Series 3", "Daisy", "258", "461" };
            strAmiiboName[462] = new string[] { "026A000101460502", "ACC", "Animal Crossing Cards", "Series 3", "Stinky", "259", "462" };
            strAmiiboName[463] = new string[] { "03FC000101470502", "ACC", "Animal Crossing Cards", "Series 3", "Tammi", "260", "463" };
            strAmiiboName[464] = new string[] { "032C000101480502", "ACC", "Animal Crossing Cards", "Series 3", "Tucker", "261", "464" };
            strAmiiboName[465] = new string[] { "043E000101490502", "ACC", "Animal Crossing Cards", "Series 3", "Blanche", "262", "465" };
            strAmiiboName[466] = new string[] { "04980001014A0502", "ACC", "Animal Crossing Cards", "Series 3", "Gaston", "263", "466" };
            strAmiiboName[467] = new string[] { "04EE0001014B0502", "ACC", "Animal Crossing Cards", "Series 3", "Marshal", "264", "467" };
            strAmiiboName[468] = new string[] { "04850001014C0502", "ACC", "Animal Crossing Cards", "Series 3", "Gala", "265", "468" };
            strAmiiboName[469] = new string[] { "03080001014D0502", "ACC", "Animal Crossing Cards", "Series 3", "Joey", "266", "469" };
            strAmiiboName[470] = new string[] { "049A0001014E0502", "ACC", "Animal Crossing Cards", "Series 3", "Pippy", "267", "470" };
            strAmiiboName[471] = new string[] { "03A40001014F0502", "ACC", "Animal Crossing Cards", "Series 3", "Buck", "268", "471" };
            strAmiiboName[472] = new string[] { "040F000101500502", "ACC", "Animal Crossing Cards", "Series 3", "Bree", "269", "472" };
            strAmiiboName[473] = new string[] { "03DA000101510502", "ACC", "Animal Crossing Cards", "Series 3", "Rooney", "270", "473" };
            strAmiiboName[474] = new string[] { "04CD000101520502", "ACC", "Animal Crossing Cards", "Series 3", "Curlos", "271", "474" };
            strAmiiboName[475] = new string[] { "0514000101530502", "ACC", "Animal Crossing Cards", "Series 3", "Skye", "272", "475" };
            strAmiiboName[476] = new string[] { "0265000101540502", "ACC", "Animal Crossing Cards", "Series 3", "Moe", "273", "476" };
            strAmiiboName[477] = new string[] { "043F000101550502", "ACC", "Animal Crossing Cards", "Series 3", "Flora", "274", "477" };
            strAmiiboName[478] = new string[] { "037E000101560502", "ACC", "Animal Crossing Cards", "Series 3", "Hamlet", "275", "478" };
            strAmiiboName[479] = new string[] { "03D6000101570502", "ACC", "Animal Crossing Cards", "Series 3", "Astrid", "276", "479" };
            strAmiiboName[480] = new string[] { "03FD000101580502", "ACC", "Animal Crossing Cards", "Series 3", "Monty", "277", "480" };
            strAmiiboName[481] = new string[] { "040C000101590502", "ACC", "Animal Crossing Cards", "Series 3", "Dora", "278", "481" };
            strAmiiboName[482] = new string[] { "02ED0001015A0502", "ACC", "Animal Crossing Cards", "Series 3", "Biskit", "279", "482" };
            strAmiiboName[483] = new string[] { "03A50001015B0502", "ACC", "Animal Crossing Cards", "Series 3", "Victoria", "280", "483" };
            strAmiiboName[484] = new string[] { "03C50001015C0502", "ACC", "Animal Crossing Cards", "Series 3", "Lyman", "281", "484" };
            strAmiiboName[485] = new string[] { "03700001015D0502", "ACC", "Animal Crossing Cards", "Series 3", "Violet", "282", "485" };
            strAmiiboName[486] = new string[] { "04510001015E0502", "ACC", "Animal Crossing Cards", "Series 3", "Frank", "283", "486" };
            strAmiiboName[487] = new string[] { "041E0001015F0502", "ACC", "Animal Crossing Cards", "Series 3", "Chadder", "284", "487" };
            strAmiiboName[488] = new string[] { "04B9000101600502", "ACC", "Animal Crossing Cards", "Series 3", "Merengue", "285", "488" };
            strAmiiboName[489] = new string[] { "0461000101610502", "ACC", "Animal Crossing Cards", "Series 3", "Cube", "286", "489" };
            strAmiiboName[490] = new string[] { "04FF000101620502", "ACC", "Animal Crossing Cards", "Series 3", "Claudia", "287", "490" };
            strAmiiboName[491] = new string[] { "0478000101630502", "ACC", "Animal Crossing Cards", "Series 3", "Curly", "288", "491" };
            strAmiiboName[492] = new string[] { "0469000101640502", "ACC", "Animal Crossing Cards", "Series 3", "Boomer", "289", "492" };
            strAmiiboName[493] = new string[] { "04E3000101650502", "ACC", "Animal Crossing Cards", "Series 3", "Caroline", "290", "493" };
            strAmiiboName[494] = new string[] { "023F000101660502", "ACC", "Animal Crossing Cards", "Series 3", "Sparro", "291", "494" };
            strAmiiboName[495] = new string[] { "04C6000101670502", "ACC", "Animal Crossing Cards", "Series 3", "Baabara", "292", "495" };
            strAmiiboName[496] = new string[] { "04FA000101680502", "ACC", "Animal Crossing Cards", "Series 3", "Rolf", "293", "496" };
            strAmiiboName[497] = new string[] { "027E000101690502", "ACC", "Animal Crossing Cards", "Series 3", "Maple", "294", "497" };
            strAmiiboName[498] = new string[] { "02010001016A0502", "ACC", "Animal Crossing Cards", "Series 3", "Antonio", "295", "498" };
            strAmiiboName[499] = new string[] { "03820001016B0502", "ACC", "Animal Crossing Cards", "Series 3", "Soleil", "296", "499" };
            strAmiiboName[500] = new string[] { "044B0001016C0502", "ACC", "Animal Crossing Cards", "Series 3", "Apollo", "297", "500" };
            strAmiiboName[501] = new string[] { "030F0001016D0502", "ACC", "Animal Crossing Cards", "Series 3", "Derwin", "298", "501" };
            strAmiiboName[502] = new string[] { "04A00001016E0502", "ACC", "Animal Crossing Cards", "Series 3", "Francine", "299", "502" };
            strAmiiboName[503] = new string[] { "04A10001016F0502", "ACC", "Animal Crossing Cards", "Series 3", "Chrissy", "300", "503" };
            strAmiiboName[504] = new string[] { "0181030101700502", "ACC", "Animal Crossing Cards", "Series 4", "Isabelle", "301", "504" };
            strAmiiboName[505] = new string[] { "0190000101710502", "ACC", "Animal Crossing Cards", "Series 4", "Brewster", "302", "505" };
            strAmiiboName[506] = new string[] { "01A5000101720502", "ACC", "Animal Crossing Cards", "Series 4", "Katrina", "303", "506" };
            strAmiiboName[507] = new string[] { "019C000101730502", "ACC", "Animal Crossing Cards", "Series 4", "Phineas", "304", "507" };
            strAmiiboName[508] = new string[] { "0193000101740502", "ACC", "Animal Crossing Cards", "Series 4", "Celeste", "305", "508" };
            strAmiiboName[509] = new string[] { "0186030101750502", "ACC", "Animal Crossing Cards", "Series 4", "Tommy", "306", "509" };
            strAmiiboName[510] = new string[] { "01A9000101760502", "ACC", "Animal Crossing Cards", "Series 4", "Gracie", "307", "510" };
            strAmiiboName[511] = new string[] { "0197000101770502", "ACC", "Animal Crossing Cards", "Series 4", "Leilani", "308", "511" };
            strAmiiboName[512] = new string[] { "018E010101780502", "ACC", "Animal Crossing Cards", "Series 4", "Resetti", "309", "512" };
            strAmiiboName[513] = new string[] { "0185040101790502", "ACC", "Animal Crossing Cards", "Series 4", "Timmy", "310", "513" };
            strAmiiboName[514] = new string[] { "01C10101017A0502", "ACC", "Animal Crossing Cards", "Series 4", "Lottie", "311", "514" };
            strAmiiboName[515] = new string[] { "01B10101017B0502", "ACC", "Animal Crossing Cards", "Series 4", "Shrunk", "312", "515" };
            strAmiiboName[516] = new string[] { "01AB0001017C0502", "ACC", "Animal Crossing Cards", "Series 4", "Pave", "313", "516" };
            strAmiiboName[517] = new string[] { "01A20001017D0502", "ACC", "Animal Crossing Cards", "Series 4", "Gulliver", "314", "517" };
            strAmiiboName[518] = new string[] { "01A80101017E0502", "ACC", "Animal Crossing Cards", "Series 4", "Redd", "315", "518" };
            strAmiiboName[519] = new string[] { "01AC0001017F0502", "ACC", "Animal Crossing Cards", "Series 4", "Zipper", "316", "519" };
            strAmiiboName[520] = new string[] { "02EA000101800502", "ACC", "Animal Crossing Cards", "Series 4", "Goldie", "317", "520" };
            strAmiiboName[521] = new string[] { "0282000101810502", "ACC", "Animal Crossing Cards", "Series 4", "Stitches", "318", "521" };
            strAmiiboName[522] = new string[] { "0215000101820502", "ACC", "Animal Crossing Cards", "Series 4", "Pinky", "319", "522" };
            strAmiiboName[523] = new string[] { "03EC000101830502", "ACC", "Animal Crossing Cards", "Series 4", "Mott", "320", "523" };
            strAmiiboName[524] = new string[] { "030D000101840502", "ACC", "Animal Crossing Cards", "Series 4", "Mallary", "321", "524" };
            strAmiiboName[525] = new string[] { "0390000101850502", "ACC", "Animal Crossing Cards", "Series 4", "Rocco", "322", "525" };
            strAmiiboName[526] = new string[] { "0272000101860502", "ACC", "Animal Crossing Cards", "Series 4", "Katt", "323", "526" };
            strAmiiboName[527] = new string[] { "0380000101870502", "ACC", "Animal Crossing Cards", "Series 4", "Graham", "324", "527" };
            strAmiiboName[528] = new string[] { "03AC000101880502", "ACC", "Animal Crossing Cards", "Series 4", "Peaches", "325", "528" };
            strAmiiboName[529] = new string[] { "0324000101890502", "ACC", "Animal Crossing Cards", "Series 4", "Dizzy", "326", "529" };
            strAmiiboName[530] = new string[] { "041D0001018A0502", "ACC", "Animal Crossing Cards", "Series 4", "Penelope", "327", "530" };
            strAmiiboName[531] = new string[] { "036B0001018B0502", "ACC", "Animal Crossing Cards", "Series 4", "Boone", "328", "531" };
            strAmiiboName[532] = new string[] { "02A50001018C0502", "ACC", "Animal Crossing Cards", "Series 4", "Broffina", "329", "532" };
            strAmiiboName[533] = new string[] { "03490001018D0502", "ACC", "Animal Crossing Cards", "Series 4", "Croque", "330", "533" };
            strAmiiboName[534] = new string[] { "035E0001018E0502", "ACC", "Animal Crossing Cards", "Series 4", "Pashmina", "331", "534" };
            strAmiiboName[535] = new string[] { "02FC0001018F0502", "ACC", "Animal Crossing Cards", "Series 4", "Shep", "332", "535" };
            strAmiiboName[536] = new string[] { "026F000101900502", "ACC", "Animal Crossing Cards", "Series 4", "Lolly", "333", "536" };
            strAmiiboName[537] = new string[] { "02DF000101910502", "ACC", "Animal Crossing Cards", "Series 4", "Erik", "334", "537" };
            strAmiiboName[538] = new string[] { "0495000101920502", "ACC", "Animal Crossing Cards", "Series 4", "Dotty", "335", "538" };
            strAmiiboName[539] = new string[] { "044D000101930502", "ACC", "Animal Crossing Cards", "Series 4", "Pierce", "336", "539" };
            strAmiiboName[540] = new string[] { "0436000101940502", "ACC", "Animal Crossing Cards", "Series 4", "Queenie", "337", "540" };
            strAmiiboName[541] = new string[] { "0511000101950502", "ACC", "Animal Crossing Cards", "Series 4", "Fang", "338", "541" };
            strAmiiboName[542] = new string[] { "04D0000101960502", "ACC", "Animal Crossing Cards", "Series 4", "Frita", "339", "542" };
            strAmiiboName[543] = new string[] { "046B000101970502", "ACC", "Animal Crossing Cards", "Series 4", "Tex", "340", "543" };
            strAmiiboName[544] = new string[] { "03BE000101980502", "ACC", "Animal Crossing Cards", "Series 4", "Melba", "341", "544" };
            strAmiiboName[545] = new string[] { "02EE000101990502", "ACC", "Animal Crossing Cards", "Series 4", "Bones", "342", "545" };
            strAmiiboName[546] = new string[] { "02030001019A0502", "ACC", "Animal Crossing Cards", "Series 4", "Anabelle", "343", "546" };
            strAmiiboName[547] = new string[] { "02710001019B0502", "ACC", "Animal Crossing Cards", "Series 4", "Rudy", "344", "547" };
            strAmiiboName[548] = new string[] { "02B80001019C0502", "ACC", "Animal Crossing Cards", "Series 4", "Naomi", "345", "548" };
            strAmiiboName[549] = new string[] { "036A0001019D0502", "ACC", "Animal Crossing Cards", "Series 4", "Peewee", "346", "549" };
            strAmiiboName[550] = new string[] { "028E0001019E0502", "ACC", "Animal Crossing Cards", "Series 4", "Tammy", "347", "550" };
            strAmiiboName[551] = new string[] { "02090001019F0502", "ACC", "Animal Crossing Cards", "Series 4", "Olaf", "348", "551" };
            strAmiiboName[552] = new string[] { "047C000101A00502", "ACC", "Animal Crossing Cards", "Series 4", "Lucy", "349", "552" };
            strAmiiboName[553] = new string[] { "03A7000101A10502", "ACC", "Animal Crossing Cards", "Series 4", "Elmer", "350", "553" };
            strAmiiboName[554] = new string[] { "033E000101A20502", "ACC", "Animal Crossing Cards", "Series 4", "Puddles", "351", "554" };
            strAmiiboName[555] = new string[] { "03ED000101A30502", "ACC", "Animal Crossing Cards", "Series 4", "Rory", "352", "555" };
            strAmiiboName[556] = new string[] { "03FE000101A40502", "ACC", "Animal Crossing Cards", "Series 4", "Elise", "353", "556" };
            strAmiiboName[557] = new string[] { "03D9000101A50502", "ACC", "Animal Crossing Cards", "Series 4", "Walt", "354", "557" };
            strAmiiboName[558] = new string[] { "04A7000101A60502", "ACC", "Animal Crossing Cards", "Series 4", "Mira", "355", "558" };
            strAmiiboName[559] = new string[] { "04D2000101A70502", "ACC", "Animal Crossing Cards", "Series 4", "Pietro", "356", "559" };
            strAmiiboName[560] = new string[] { "045F000101A80502", "ACC", "Animal Crossing Cards", "Series 4", "Aurora", "357", "560" };
            strAmiiboName[561] = new string[] { "03B0000101A90502", "ACC", "Animal Crossing Cards", "Series 4", "Papi", "358", "561" };
            strAmiiboName[562] = new string[] { "037F000101AA0502", "ACC", "Animal Crossing Cards", "Series 4", "Apple", "359", "562" };
            strAmiiboName[563] = new string[] { "0411000101AB0502", "ACC", "Animal Crossing Cards", "Series 4", "Rod", "360", "563" };
            strAmiiboName[564] = new string[] { "0264000101AC0502", "ACC", "Animal Crossing Cards", "Series 4", "Purrl", "361", "564" };
            strAmiiboName[565] = new string[] { "04E5000101AD0502", "ACC", "Animal Crossing Cards", "Series 4", "Static", "362", "565" };
            strAmiiboName[566] = new string[] { "0454000101AE0502", "ACC", "Animal Crossing Cards", "Series 4", "Celia", "363", "566" };
            strAmiiboName[567] = new string[] { "042B000101AF0502", "ACC", "Animal Crossing Cards", "Series 4", "Zucker", "364", "567" };
            strAmiiboName[568] = new string[] { "0483000101B00502", "ACC", "Animal Crossing Cards", "Series 4", "Peggy", "365", "568" };
            strAmiiboName[569] = new string[] { "0339000101B10502", "ACC", "Animal Crossing Cards", "Series 4", "Ribbot", "366", "569" };
            strAmiiboName[570] = new string[] { "03AD000101B20502", "ACC", "Animal Crossing Cards", "Series 4", "Annalise", "367", "570" };
            strAmiiboName[571] = new string[] { "0217000101B30502", "ACC", "Animal Crossing Cards", "Series 4", "Chow", "368", "571" };
            strAmiiboName[572] = new string[] { "03D7000101B40502", "ACC", "Animal Crossing Cards", "Series 4", "Sylvia", "369", "572" };
            strAmiiboName[573] = new string[] { "023D000101B50502", "ACC", "Animal Crossing Cards", "Series 4", "Jacques", "370", "573" };
            strAmiiboName[574] = new string[] { "04E4000101B60502", "ACC", "Animal Crossing Cards", "Series 4", "Sally", "371", "574" };
            strAmiiboName[575] = new string[] { "049E000101B70502", "ACC", "Animal Crossing Cards", "Series 4", "Doc", "372", "575" };
            strAmiiboName[576] = new string[] { "030C000101B80502", "ACC", "Animal Crossing Cards", "Series 4", "Pompom", "373", "576" };
            strAmiiboName[577] = new string[] { "04B2000101B90502", "ACC", "Animal Crossing Cards", "Series 4", "Tank", "374", "577" };
            strAmiiboName[578] = new string[] { "02A2000101BA0502", "ACC", "Animal Crossing Cards", "Series 4", "Becky", "375", "578" };
            strAmiiboName[579] = new string[] { "0415000101BB0502", "ACC", "Animal Crossing Cards", "Series 4", "Rizzo", "376", "579" };
            strAmiiboName[580] = new string[] { "03BF000101BC0502", "ACC", "Animal Crossing Cards", "Series 4", "Sydney", "377", "580" };
            strAmiiboName[581] = new string[] { "028D000101BD0502", "ACC", "Animal Crossing Cards", "Series 4", "Barold", "378", "581" };
            strAmiiboName[582] = new string[] { "04E1000101BE0502", "ACC", "Animal Crossing Cards", "Series 4", "Nibbles", "379", "582" };
            strAmiiboName[583] = new string[] { "0487000101BF0502", "ACC", "Animal Crossing Cards", "Series 4", "Kevin", "380", "583" };
            strAmiiboName[584] = new string[] { "0316000101C00502", "ACC", "Animal Crossing Cards", "Series 4", "Gloria", "381", "584" };
            strAmiiboName[585] = new string[] { "050C000101C10502", "ACC", "Animal Crossing Cards", "Series 4", "Lobo", "382", "585" };
            strAmiiboName[586] = new string[] { "0399000101C20502", "ACC", "Animal Crossing Cards", "Series 4", "Hippeux", "383", "586" };
            strAmiiboName[587] = new string[] { "0327000101C30502", "ACC", "Animal Crossing Cards", "Series 4", "Margie", "384", "587" };
            strAmiiboName[588] = new string[] { "02EC000101C40502", "ACC", "Animal Crossing Cards", "Series 4", "Lucky", "385", "588" };
            strAmiiboName[589] = new string[] { "025F000101C50502", "ACC", "Animal Crossing Cards", "Series 4", "Rosie", "386", "589" };
            strAmiiboName[590] = new string[] { "04FB000101C60502", "ACC", "Animal Crossing Cards", "Series 4", "Rowan", "387", "590" };
            strAmiiboName[591] = new string[] { "030A000101C70502", "ACC", "Animal Crossing Cards", "Series 4", "Maelle", "388", "591" };
            strAmiiboName[592] = new string[] { "02D9000101C80502", "ACC", "Animal Crossing Cards", "Series 4", "Bruce", "389", "592" };
            strAmiiboName[593] = new string[] { "04A3000101C90502", "ACC", "Animal Crossing Cards", "Series 4", "OHare", "390", "593" };
            strAmiiboName[594] = new string[] { "02CA000101CA0502", "ACC", "Animal Crossing Cards", "Series 4", "Gayle", "391", "594" };
            strAmiiboName[595] = new string[] { "043C000101CB0502", "ACC", "Animal Crossing Cards", "Series 4", "Cranston", "392", "595" };
            strAmiiboName[596] = new string[] { "033A000101CC0502", "ACC", "Animal Crossing Cards", "Series 4", "Frobert", "393", "596" };
            strAmiiboName[597] = new string[] { "021D000101CD0502", "ACC", "Animal Crossing Cards", "Series 4", "Grizzly", "394", "597" };
            strAmiiboName[598] = new string[] { "04E8000101CE0502", "ACC", "Animal Crossing Cards", "Series 4", "Cally", "395", "598" };
            strAmiiboName[599] = new string[] { "03FB000101CF0502", "ACC", "Animal Crossing Cards", "Series 4", "Simon", "396", "599" };
            strAmiiboName[600] = new string[] { "046A000101D00502", "ACC", "Animal Crossing Cards", "Series 4", "Iggly", "397", "600" };
            strAmiiboName[601] = new string[] { "024A000101D10502", "ACC", "Animal Crossing Cards", "Series 4", "Angus", "398", "601" };
            strAmiiboName[602] = new string[] { "0230000101D20502", "ACC", "Animal Crossing Cards", "Series 4", "Twiggy", "399", "602" };
            strAmiiboName[603] = new string[] { "022E000101D30502", "ACC", "Animal Crossing Cards", "Series 4", "Robin", "400", "603" };
            strAmiiboName[604] = new string[] { "0181000101D40502", "ACC", "Animal Crossing Cards", "Character Parfait", "Isabelle", "401", "604" };
            strAmiiboName[605] = new string[] { "0182000101D80502", "ACC", "Animal Crossing Cards", "Character Parfait", "K. K. Slider", "405", "605" };
            strAmiiboName[606] = new string[] { "02EA000101D50502", "ACC", "Animal Crossing Cards", "Amiibo Festival", "Goldie", "402", "606" };
            strAmiiboName[607] = new string[] { "0282000101D60502", "ACC", "Animal Crossing Cards", "Amiibo Festival", "Stitches", "403", "607" };
            strAmiiboName[608] = new string[] { "025F000101D70502", "ACC", "Animal Crossing Cards", "Amiibo Festival", "Rosie", "404", "608" };
            strAmiiboName[609] = new string[] { "0374010103190502", "ACC", "Animal Crossing Cards", "Animal Crossing x Sanrio Series", "Rilla", "406", "609" };
            strAmiiboName[610] = new string[] { "028F0101031A0502", "ACC", "Animal Crossing Cards", "Animal Crossing x Sanrio Series", "Marty", "407", "610" };
            strAmiiboName[611] = new string[] { "04D30101031B0502", "ACC", "Animal Crossing Cards", "Animal Crossing x Sanrio Series", "Étoile", "408", "611" };
            strAmiiboName[612] = new string[] { "032E0101031C0502", "ACC", "Animal Crossing Cards", "Animal Crossing x Sanrio Series", "Chai", "409", "612" };
            strAmiiboName[613] = new string[] { "02E00101031D0502", "ACC", "Animal Crossing Cards", "Animal Crossing x Sanrio Series", "Chelsea", "410", "613" };
            strAmiiboName[614] = new string[] { "04A80101031E0502", "ACC", "Animal Crossing Cards", "Animal Crossing x Sanrio Series", "Toby", "411", "614" };
            strAmiiboName[615] = new string[] { "0513000102E70502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Vivian", "412", "615" };
            strAmiiboName[616] = new string[] { "04A2000102E80502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Hopkins", "413", "616" };
            strAmiiboName[617] = new string[] { "028A000102E90502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "June", "414", "617" };
            strAmiiboName[618] = new string[] { "0232000102EA0502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Piper", "415", "618" };
            strAmiiboName[619] = new string[] { "0328000102EB0502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Paolo", "416", "619" };
            strAmiiboName[620] = new string[] { "04B6000102EC0502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Hornsby", "417", "620" };
            strAmiiboName[621] = new string[] { "04C8000102ED0502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Stella", "418", "621" };
            strAmiiboName[622] = new string[] { "04FC000102EE0502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Tybalt", "419", "622" };
            strAmiiboName[623] = new string[] { "0343000102EF0502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Huck", "420", "623" };
            strAmiiboName[624] = new string[] { "04EB000102F00502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Sylvana", "421", "624" };
            strAmiiboName[625] = new string[] { "0481000102F10502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Boris", "422", "625" };
            strAmiiboName[626] = new string[] { "0468000102F20502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Wade", "423", "626" };
            strAmiiboName[627] = new string[] { "03D3000102F30502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Carrie", "424", "627" };
            strAmiiboName[628] = new string[] { "0314000102F40502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Ketchup", "425", "628" };
            strAmiiboName[629] = new string[] { "03E8000102F50502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Rex", "426", "629" };
            strAmiiboName[630] = new string[] { "024D000102F60502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Stu", "427", "630" };
            strAmiiboName[631] = new string[] { "021C000102F70502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Ursala", "428", "631" };
            strAmiiboName[632] = new string[] { "0238000102F80502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Jacob", "429", "632" };
            strAmiiboName[633] = new string[] { "02F3000102F90502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Maddie", "430", "633" };
            strAmiiboName[634] = new string[] { "0358000102FA0502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Billy", "431", "634" };
            strAmiiboName[635] = new string[] { "036E000102FB0502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Boyd", "432", "635" };
            strAmiiboName[636] = new string[] { "0395000102FC0502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Bitty", "433", "636" };
            strAmiiboName[637] = new string[] { "0482000102FD0502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Maggie", "434", "637" };
            strAmiiboName[638] = new string[] { "0284000102FE0502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Murphy", "435", "638" };
            strAmiiboName[639] = new string[] { "02A3000102FF0502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Plucky", "436", "639" };
            strAmiiboName[640] = new string[] { "0438000103000502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Sandy", "437", "640" };
            strAmiiboName[641] = new string[] { "049F000103010502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Claude", "438", "641" };
            strAmiiboName[642] = new string[] { "0347000103020502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Raddle", "439", "642" };
            strAmiiboName[643] = new string[] { "043B000103030502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Julia", "440", "643" };
            strAmiiboName[644] = new string[] { "036D000103040502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Louie", "441", "644" };
            strAmiiboName[645] = new string[] { "02F4000103050502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Bea", "442", "645" };
            strAmiiboName[646] = new string[] { "0233000103060502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Admiral", "443", "646" };
            strAmiiboName[647] = new string[] { "032A000103070502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Ellie", "444", "647" };
            strAmiiboName[648] = new string[] { "02C5000103080502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Boots", "445", "648" };
            strAmiiboName[649] = new string[] { "0312000103090502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Weber", "446", "649" };
            strAmiiboName[650] = new string[] { "04140001030A0502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Candi", "447", "650" };
            strAmiiboName[651] = new string[] { "03EA0001030B0502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Leopold", "448", "651" };
            strAmiiboName[652] = new string[] { "04B40001030C0502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Spike", "449", "652" };
            strAmiiboName[653] = new string[] { "04C90001030D0502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Cashmere", "450", "653" };
            strAmiiboName[654] = new string[] { "03410001030E0502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Tad", "451", "654" };
            strAmiiboName[655] = new string[] { "02B70001030F0502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Norma", "452", "655" };
            strAmiiboName[656] = new string[] { "03C0000103100502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Gonzo", "453", "656" };
            strAmiiboName[657] = new string[] { "0439000103110502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Sprocket", "454", "657" };
            strAmiiboName[658] = new string[] { "0206000103120502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Snooty", "455", "658" };
            strAmiiboName[659] = new string[] { "0286000103130502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Olive", "456", "659" };
            strAmiiboName[660] = new string[] { "050F000103140502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Dobie", "457", "660" };
            strAmiiboName[661] = new string[] { "044E000103150502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Buzz", "458", "661" };
            strAmiiboName[662] = new string[] { "03AB000103160502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Cleo", "459", "662" };
            strAmiiboName[663] = new string[] { "021F000103170502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Ike", "460", "663" };
            strAmiiboName[664] = new string[] { "04EA000103180502", "ACC", "Animal Crossing Cards", "Welcome Amiibo Series", "Tasha", "461", "664" };
            strAmiiboName[665] = new string[] { "01810100023F0502", "ACF", "Animal Crossing Figures", "Wave 1", "Isabelle", "001", "665" };
            strAmiiboName[666] = new string[] { "0182000002400502", "ACF", "Animal Crossing Figures", "Wave 1", "K. K. Slider", "002", "666" };
            strAmiiboName[667] = new string[] { "01C1000002440502", "ACF", "Animal Crossing Figures", "Wave 1", "Lottie", "003", "667" };
            strAmiiboName[668] = new string[] { "018A000002450502", "ACF", "Animal Crossing Figures", "Wave 1", "Reese", "004", "668" };
            strAmiiboName[669] = new string[] { "018B000002460502", "ACF", "Animal Crossing Figures", "Wave 1", "Cyrus", "005", "669" };
            strAmiiboName[670] = new string[] { "0183000002420502", "ACF", "Animal Crossing Figures", "Wave 1", "Tom Nook", "006", "670" };
            strAmiiboName[671] = new string[] { "0188000002410502", "ACF", "Animal Crossing Figures", "Wave 1", "Mabel", "007", "671" };
            strAmiiboName[672] = new string[] { "018C000002430502", "ACF", "Animal Crossing Figures", "Wave 1", "Digby", "008", "672" };
            strAmiiboName[673] = new string[] { "018E000002490502", "ACF", "Animal Crossing Figures", "Wave 2", "Resetti", "009", "673" };
            strAmiiboName[674] = new string[] { "0192000002470502", "ACF", "Animal Crossing Figures", "Wave 2", "Blathers", "010", "674" };
            strAmiiboName[675] = new string[] { "01940000024A0502", "ACF", "Animal Crossing Figures", "Wave 2", "Kicks", "011", "675" };
            strAmiiboName[676] = new string[] { "0193000002480502", "ACF", "Animal Crossing Figures", "Wave 2", "Celeste", "012", "676" };
            strAmiiboName[677] = new string[] { "01840000024D0502", "ACF", "Animal Crossing Figures", "Wave 3", "Timmy & Tommy", "013", "677" };
            strAmiiboName[678] = new string[] { "018D0000024C0502", "ACF", "Animal Crossing Figures", "Wave 3", "Rover", "014", "678" };
            strAmiiboName[679] = new string[] { "01960000024E0502", "ACF", "Animal Crossing Figures", "Wave 3", "Kapp'n", "015", "679" };
            strAmiiboName[680] = new string[] { "01810000024B0502", "ACF", "Animal Crossing Figures", "Wave 4", "Isabelle - Summer Outfit", "016", "680" };
            strAmiiboName[681] = new string[] { "3500010002E10F02", "MHS", "Monster Hunter Stories", "", "One-Eyed Rathalos and Rider (Male)", "001", "681" };
            strAmiiboName[682] = new string[] { "3500020002E20F02", "MHS", "Monster Hunter Stories", "", "One-Eyed Rathalos and Rider (Female)", "002", "682" };
            strAmiiboName[683] = new string[] { "3501000002E30F02", "MHS", "Monster Hunter Stories", "", "Nabiru", "003", "683" };
            strAmiiboName[684] = new string[] { "3502010002E40F02", "MHS", "Monster Hunter Stories", "", "Rathian and Cheval", "004", "684" };
            strAmiiboName[685] = new string[] { "3503010002E50F02", "MHS", "Monster Hunter Stories", "", "Barioth and Ayuria", "005", "685" };
            strAmiiboName[686] = new string[] { "3504010002E60F02", "MHS", "Monster Hunter Stories", "", "Qurupeco and Dan", "006", "686" };
            strAmiiboName[687] = new string[] { "0003010200410302", "YWW", "Yoshi's Woolly World", "", "Green Yarn Yoshi", "001", "687" };
            strAmiiboName[688] = new string[] { "0003010200420302", "YWW", "Yoshi's Woolly World", "", "Pink Yarn Yoshi", "002", "688" };
            strAmiiboName[689] = new string[] { "0003010200430302", "YWW", "Yoshi's Woolly World", "", "Light Blue Yarn Yoshi", "003", "689" };
            strAmiiboName[690] = new string[] { "00030102023E0302", "YWW", "Yoshi's Woolly World", "", "Mega Yarn Yoshi", "004", "690" };
            strAmiiboName[691] = new string[] { "00800102035D0302", "YWW", "Yoshi's Woolly World", "", "Poochy", "005", "691" };
            strAmiiboName[692] = new string[] { "0005FF00023A0702", "SKL", "Skylanders SuperChargers", "", "Hammer Slam Bowser", "001", "692" };
            strAmiiboName[693] = new string[] { "0008FF00023B0702", "SKL", "Skylanders SuperChargers", "", "Turbo Charge Donkey Kong", "002", "693" };
            strAmiiboName[694] = new string[] { "0005FF00023A0702", "SKL", "Skylanders SuperChargers", "", "Dark Hammer Slam Bowser", "003", "694" };
            strAmiiboName[695] = new string[] { "0008FF00023B0702", "SKL", "Skylanders SuperChargers", "", "Dark Turbo Charge Donkey Kong", "004", "695" };
            strAmiiboName[696] = new string[] { "1F00000002540C02", "KIR", "Kirby", "", "Kirby", "001", "696" };
            strAmiiboName[697] = new string[] { "1F01000002550C02", "KIR", "Kirby", "", "Meta Knight", "002", "697" };
            strAmiiboName[698] = new string[] { "1F02000002560C02", "KIR", "Kirby", "", "King Dedede", "003", "698" };
            strAmiiboName[699] = new string[] { "1F03000002570C02", "KIR", "Kirby", "", "Waddle Dee", "004", "699" };
            strAmiiboName[700] = new string[] { "2106000003601202", "FIE", "Fire Emblem", "", "Alm", "001", "700" };
            strAmiiboName[701] = new string[] { "2107000003611202", "FIE", "Fire Emblem", "", "Celica", "002", "701" };
            strAmiiboName[702] = new string[] { "21080000036F1202", "FIE", "Fire Emblem", "", "Chrom", "003", "702" };
            strAmiiboName[703] = new string[] { "2109000003701202", "FIE", "Fire Emblem", "", "Tiki", "004", "703" };
            strAmiiboName[704] = new string[] { "35C0000002500A02", "SHK", "Shovel Knight", "", "Shovel Knight", "001", "704" };
            strAmiiboName[705] = new string[] { "22C00000003A0202", "CHI", "Chibi Robo", "", "Chibi Robo", "001", "705" };
            strAmiiboName[706] = new string[] { "1D000001025C0D02", "POK", "Pokkén Tournament", "", "Shadow Mewtwo", "001", "706" };
            strAmiiboName[707] = new string[] { "1F400000035E1002", "BOB", "BoxBoy!", "", "Qbby", "001", "707" };
            strAmiiboName[708] = new string[] { "06420000035F1102", "PIK", "Pikmin", "", "Pikmin", "001", "708" };
            strAmiiboName[709] = new string[] { "05C1000003661302", "MSR", "Metroid: Samus Returns", "", "Metroid", "002", "709" };
            strAmiiboName[710] = new string[] { "05C0000003651302", "MSR", "Metroid: Samus Returns", "", "Samus Aran", "001", "710" };
            strAmiiboName[711] = new string[] { "3740000103741402", "SMC", "Super Mario Cereal", "", "Super Mario Cereal", "001", "711" };
            /*
[ZBW] 06 - Mipha(Zora Champion).bin?(Revali)	1	1	01070000-035A0902
[ZBW] 07 - Daruk(Goron Champion).bin?(Mipha)	1	1	01050000-03580902	CRC32:
[ZBW] 08 - Revali(Rito Champion).bin?(Urbosa)	1	1	01080000-035B0902 CRC32:
[ZBW] 09 - Urbosa(Gerudo Champion).bin?(Daruk)	1	1	01060000-03590902	CRC32:
*/
            #endregion

            for (int i = 1; i < strAmiiboName.Length; i++)
            {
                if (AmiiboSer == strAmiiboName[i][0])
                {
                    return strAmiiboName[i];
                }
            }
            return strAmiiboName[0];

        }

        /// <summary>
        /// 01to03 2018-01-24
        /// </summary>
        /// <param name="AmiiboSer"></param>
        /// <returns></returns>
        private string GetAmiiboName01to03(string AmiiboSer)
        {
            switch (AmiiboSer)
            {
                case "000": return "Mario";
                case "001": return "Mario";
                case "002": return "Mario";
                case "008": return "Yoshi's Woolly World";
                case "010": return "The Legend of Zelda";
                case "014": return "Breath of the Wild";
                case "018": return "Animal Crossing";
                case "019": return "Animal Crossing";
                case "01A": return "Animal Crossing";
                case "01B": return "Animal Crossing";
                case "01C": return "Animal Crossing";
                case "01D": return "Animal Crossing";
                case "01E": return "Animal Crossing";
                case "01F": return "Animal Crossing";
                case "020": return "Animal Crossing";
                case "021": return "Animal Crossing";
                case "022": return "Animal Crossing";
                case "023": return "Animal Crossing";
                case "024": return "Animal Crossing";
                case "025": return "Animal Crossing";
                case "026": return "Animal Crossing";
                case "027": return "Animal Crossing";
                case "028": return "Animal Crossing";
                case "029": return "Animal Crossing";
                case "02A": return "Animal Crossing";
                case "02B": return "Animal Crossing";
                case "02C": return "Animal Crossing";
                case "02D": return "Animal Crossing";
                case "02E": return "Animal Crossing";
                case "02F": return "Animal Crossing";
                case "030": return "Animal Crossing";
                case "031": return "Animal Crossing";
                case "032": return "Animal Crossing";
                case "033": return "Animal Crossing";
                case "034": return "Animal Crossing";
                case "035": return "Animal Crossing";
                case "036": return "Animal Crossing";
                case "037": return "Animal Crossing";
                case "038": return "Animal Crossing";
                case "039": return "Animal Crossing";
                case "03A": return "Animal Crossing";
                case "03B": return "Animal Crossing";
                case "03C": return "Animal Crossing";
                case "03D": return "Animal Crossing";
                case "03E": return "Animal Crossing";
                case "03F": return "Animal Crossing";
                case "040": return "Animal Crossing";
                case "041": return "Animal Crossing";
                case "042": return "Animal Crossing";
                case "043": return "Animal Crossing";
                case "044": return "Animal Crossing";
                case "045": return "Animal Crossing";
                case "046": return "Animal Crossing";
                case "047": return "Animal Crossing";
                case "048": return "Animal Crossing";
                case "049": return "Animal Crossing";
                case "04A": return "Animal Crossing";
                case "04B": return "Animal Crossing";
                case "04C": return "Animal Crossing";
                case "04D": return "Animal Crossing";
                case "04E": return "Animal Crossing";
                case "04F": return "Animal Crossing";
                case "050": return "Animal Crossing";
                case "051": return "Animal Crossing";
                case "058": return "Star Fox";
                case "05C": return "Metroid";
                case "060": return "F-Zero";
                case "064": return "Pikmin";
                case "06C": return "Punch Out";
                case "070": return "Wii Fit";
                case "074": return "Kid Icarus";
                case "078": return "Classic Nintendo";
                case "07C": return "Mii";
                case "080": return "Splatoon";
                case "09C": return "Mario Sports Superstars";
                case "09D": return "Mario Sports Superstars";
                case "190": return "Pokemon";
                case "191": return "Pokemon";
                case "192": return "Pokemon";
                case "193": return "Pokemon";
                case "194": return "Pokemon";
                case "195": return "Pokemon";
                case "196": return "Pokemon";
                case "197": return "Pokemon";
                case "198": return "Pokemon";
                case "199": return "Pokemon";
                case "19A": return "Pokemon";
                case "19B": return "Pokemon";
                case "19C": return "Pokemon";
                case "19D": return "Pokemon";
                case "19E": return "Pokemon";
                case "19F": return "Pokemon";
                case "1A0": return "Pokemon";
                case "1A1": return "Pokemon";
                case "1A2": return "Pokemon";
                case "1A3": return "Pokemon";
                case "1A4": return "Pokemon";
                case "1A5": return "Pokemon";
                case "1A6": return "Pokemon";
                case "1A7": return "Pokemon";
                case "1A8": return "Pokemon";
                case "1A9": return "Pokemon";
                case "1AA": return "Pokemon";
                case "1AB": return "Pokemon";
                case "1AC": return "Pokemon";
                case "1AD": return "Pokemon";
                case "1AE": return "Pokemon";
                case "1AF": return "Pokemon";
                case "1B0": return "Pokemon";
                case "1B1": return "Pokemon";
                case "1B2": return "Pokemon";
                case "1B3": return "Pokemon";
                case "1B4": return "Pokemon";
                case "1B5": return "Pokemon";
                case "1B6": return "Pokemon";
                case "1B7": return "Pokemon";
                case "1B8": return "Pokemon";
                case "1B9": return "Pokemon";
                case "1BA": return "Pokemon";
                case "1BB": return "Pokemon";
                case "1BC": return "Pokemon";
                case "1BD": return "Pokemon";
                case "1D0": return "Pokken";
                case "1F0": return "Kirby";
                case "1F4": return "BoxBoy!";
                case "210": return "Fire Emblem";
                case "224": return "Xenoblade";
                case "228": return "Earthbound";
                case "22C": return "Chibi Robo";
                case "320": return "Sonic";
                case "324": return "Bayonetta";
                case "348": return "Megaman";
                case "34C": return "Street fighter";
                case "350": return "Monster Hunter";
                case "35C": return "Shovel Knight";
                case "360": return "Final Fantasy";
                case "374": return "Super Mario Cereal";
                default: return "";
            }
        }

        /// <summary>
        /// 07to08 2017-08-01
        /// </summary>
        /// <param name="AmiiboSer"></param>
        /// <returns></returns>
        private string GetAmiiboName07to08(string AmiiboSer)
        {
            switch (AmiiboSer)
            {
                case "00": return "Figures";
                case "01": return "Cards";
                case "02": return "Yarn";
                default: return "";
            }
        }

        /// <summary>
        /// 09to12A 2018-01-24
        /// </summary>
        /// <param name="AmiiboSer"></param>
        /// <returns></returns>
        private string GetAmiiboName09to12A(string AmiiboSer)
        {
            switch (AmiiboSer)
            {
                case "0000": return "Super Smash Bros.";
                case "0001": return "Super Smash Bros.";
                case "0002": return "Super Smash Bros.";
                case "0003": return "Super Smash Bros.";
                case "0004": return "Super Smash Bros.";
                case "0005": return "Super Smash Bros.";
                case "0006": return "Super Smash Bros.";
                case "0007": return "Super Smash Bros.";
                case "0008": return "Super Smash Bros.";
                case "0009": return "Super Smash Bros.";
                case "000A": return "Super Smash Bros.";
                case "000B": return "Super Smash Bros.";
                case "000C": return "Super Smash Bros.";
                case "000D": return "Super Smash Bros.";
                case "000E": return "Super Smash Bros.";
                case "000F": return "Super Smash Bros.";
                case "0010": return "Super Smash Bros.";
                case "0011": return "Super Smash Bros.";
                case "0012": return "Super Smash Bros.";
                case "0013": return "Super Smash Bros.";
                case "0014": return "Super Smash Bros.";
                case "0015": return "Super Smash Bros.";
                case "0016": return "Super Smash Bros.";
                case "0017": return "Super Smash Bros.";
                case "0018": return "Super Smash Bros.";
                case "0019": return "Super Smash Bros.";
                case "001A": return "Super Smash Bros.";
                case "001B": return "Super Smash Bros.";
                case "001C": return "Super Smash Bros.";
                case "001D": return "Super Smash Bros.";
                case "001E": return "Super Smash Bros.";
                case "001F": return "Super Smash Bros.";
                case "0020": return "Super Smash Bros.";
                case "0021": return "Super Smash Bros.";
                case "0022": return "Super Smash Bros.";
                case "0023": return "Super Smash Bros.";
                case "0024": return "Super Smash Bros.";
                case "0025": return "Super Smash Bros.";
                case "0026": return "Super Smash Bros.";
                case "0027": return "Super Smash Bros.";
                case "0028": return "Super Smash Bros.";
                case "0029": return "Super Smash Bros.";
                case "002A": return "Super Smash Bros.";
                case "002B": return "Super Smash Bros.";
                case "002C": return "Super Smash Bros.";
                case "002D": return "Super Smash Bros.";
                case "002E": return "Super Smash Bros.";
                case "002F": return "Super Smash Bros.";
                case "0030": return "Super Smash Bros.";
                case "0031": return "Super Smash Bros.";
                case "0032": return "Super Smash Bros.";
                case "0033": return "Super Smash Bros.";
                case "0034": return "Super Mario";
                case "0035": return "Super Mario";
                case "0036": return "Super Mario";
                case "0037": return "Super Mario";
                case "0038": return "Super Mario";
                case "0039": return "Super Mario";
                case "003A": return "Chibi Robo";
                case "003C": return "Super Mario";
                case "003D": return "Super Mario";
                case "003E": return "Splatoon";
                case "003F": return "Splatoon";
                case "0040": return "Splatoon";
                case "0041": return "Yoshi's Woolly World";
                case "0042": return "Yoshi's Woolly World";
                case "0043": return "Yoshi's Woolly World";
                case "0044": return "Animal Crossing Cards";
                case "0045": return "Animal Crossing Cards";
                case "0046": return "Animal Crossing Cards";
                case "0047": return "Animal Crossing Cards";
                case "0048": return "Animal Crossing Cards";
                case "0049": return "Animal Crossing Cards";
                case "004A": return "Animal Crossing Cards";
                case "004B": return "Animal Crossing Cards";
                case "004C": return "Animal Crossing Cards";
                case "004D": return "Animal Crossing Cards";
                case "004E": return "Animal Crossing Cards";
                case "004F": return "Animal Crossing Cards";
                case "0050": return "Animal Crossing Cards";
                case "0051": return "Animal Crossing Cards";
                case "0052": return "Animal Crossing Cards";
                case "0053": return "Animal Crossing Cards";
                case "0054": return "Animal Crossing Cards";
                case "0055": return "Animal Crossing Cards";
                case "0056": return "Animal Crossing Cards";
                case "0057": return "Animal Crossing Cards";
                case "0058": return "Animal Crossing Cards";
                case "0059": return "Animal Crossing Cards";
                case "005A": return "Animal Crossing Cards";
                case "005B": return "Animal Crossing Cards";
                case "005C": return "Animal Crossing Cards";
                case "005D": return "Animal Crossing Cards";
                case "005E": return "Animal Crossing Cards";
                case "005F": return "Animal Crossing Cards";
                case "0060": return "Animal Crossing Cards";
                case "0061": return "Animal Crossing Cards";
                case "0062": return "Animal Crossing Cards";
                case "0063": return "Animal Crossing Cards";
                case "0064": return "Animal Crossing Cards";
                case "0065": return "Animal Crossing Cards";
                case "0066": return "Animal Crossing Cards";
                case "0067": return "Animal Crossing Cards";
                case "0068": return "Animal Crossing Cards";
                case "0069": return "Animal Crossing Cards";
                case "006A": return "Animal Crossing Cards";
                case "006B": return "Animal Crossing Cards";
                case "006C": return "Animal Crossing Cards";
                case "006D": return "Animal Crossing Cards";
                case "006E": return "Animal Crossing Cards";
                case "006F": return "Animal Crossing Cards";
                case "0070": return "Animal Crossing Cards";
                case "0071": return "Animal Crossing Cards";
                case "0072": return "Animal Crossing Cards";
                case "0073": return "Animal Crossing Cards";
                case "0074": return "Animal Crossing Cards";
                case "0075": return "Animal Crossing Cards";
                case "0076": return "Animal Crossing Cards";
                case "0077": return "Animal Crossing Cards";
                case "0078": return "Animal Crossing Cards";
                case "0079": return "Animal Crossing Cards";
                case "007A": return "Animal Crossing Cards";
                case "007B": return "Animal Crossing Cards";
                case "007C": return "Animal Crossing Cards";
                case "007D": return "Animal Crossing Cards";
                case "007E": return "Animal Crossing Cards";
                case "007F": return "Animal Crossing Cards";
                case "0080": return "Animal Crossing Cards";
                case "0081": return "Animal Crossing Cards";
                case "0082": return "Animal Crossing Cards";
                case "0083": return "Animal Crossing Cards";
                case "0084": return "Animal Crossing Cards";
                case "0085": return "Animal Crossing Cards";
                case "0086": return "Animal Crossing Cards";
                case "0087": return "Animal Crossing Cards";
                case "0088": return "Animal Crossing Cards";
                case "0089": return "Animal Crossing Cards";
                case "008A": return "Animal Crossing Cards";
                case "008B": return "Animal Crossing Cards";
                case "008C": return "Animal Crossing Cards";
                case "008D": return "Animal Crossing Cards";
                case "008E": return "Animal Crossing Cards";
                case "008F": return "Animal Crossing Cards";
                case "0090": return "Animal Crossing Cards";
                case "0091": return "Animal Crossing Cards";
                case "0092": return "Animal Crossing Cards";
                case "0093": return "Animal Crossing Cards";
                case "0094": return "Animal Crossing Cards";
                case "0095": return "Animal Crossing Cards";
                case "0096": return "Animal Crossing Cards";
                case "0097": return "Animal Crossing Cards";
                case "0098": return "Animal Crossing Cards";
                case "0099": return "Animal Crossing Cards";
                case "009A": return "Animal Crossing Cards";
                case "009B": return "Animal Crossing Cards";
                case "009C": return "Animal Crossing Cards";
                case "009D": return "Animal Crossing Cards";
                case "009E": return "Animal Crossing Cards";
                case "009F": return "Animal Crossing Cards";
                case "00A0": return "Animal Crossing Cards";
                case "00A1": return "Animal Crossing Cards";
                case "00A2": return "Animal Crossing Cards";
                case "00A3": return "Animal Crossing Cards";
                case "00A4": return "Animal Crossing Cards";
                case "00A5": return "Animal Crossing Cards";
                case "00A6": return "Animal Crossing Cards";
                case "00A7": return "Animal Crossing Cards";
                case "00A8": return "Animal Crossing Cards";
                case "00A9": return "Animal Crossing Cards";
                case "00AA": return "Animal Crossing Cards";
                case "00AB": return "Animal Crossing Cards";
                case "00AC": return "Animal Crossing Cards";
                case "00AD": return "Animal Crossing Cards";
                case "00AE": return "Animal Crossing Cards";
                case "00AF": return "Animal Crossing Cards";
                case "00B0": return "Animal Crossing Cards";
                case "00B1": return "Animal Crossing Cards";
                case "00B2": return "Animal Crossing Cards";
                case "00B3": return "Animal Crossing Cards";
                case "00B4": return "Animal Crossing Cards";
                case "00B5": return "Animal Crossing Cards";
                case "00B6": return "Animal Crossing Cards";
                case "00B7": return "Animal Crossing Cards";
                case "00B8": return "Animal Crossing Cards";
                case "00B9": return "Animal Crossing Cards";
                case "00BA": return "Animal Crossing Cards";
                case "00BB": return "Animal Crossing Cards";
                case "00BC": return "Animal Crossing Cards";
                case "00BD": return "Animal Crossing Cards";
                case "00BE": return "Animal Crossing Cards";
                case "00BF": return "Animal Crossing Cards";
                case "00C0": return "Animal Crossing Cards";
                case "00C1": return "Animal Crossing Cards";
                case "00C2": return "Animal Crossing Cards";
                case "00C3": return "Animal Crossing Cards";
                case "00C4": return "Animal Crossing Cards";
                case "00C5": return "Animal Crossing Cards";
                case "00C6": return "Animal Crossing Cards";
                case "00C7": return "Animal Crossing Cards";
                case "00C8": return "Animal Crossing Cards";
                case "00C9": return "Animal Crossing Cards";
                case "00CA": return "Animal Crossing Cards";
                case "00CB": return "Animal Crossing Cards";
                case "00CC": return "Animal Crossing Cards";
                case "00CD": return "Animal Crossing Cards";
                case "00CE": return "Animal Crossing Cards";
                case "00CF": return "Animal Crossing Cards";
                case "00D0": return "Animal Crossing Cards";
                case "00D1": return "Animal Crossing Cards";
                case "00D2": return "Animal Crossing Cards";
                case "00D3": return "Animal Crossing Cards";
                case "00D4": return "Animal Crossing Cards";
                case "00D5": return "Animal Crossing Cards";
                case "00D6": return "Animal Crossing Cards";
                case "00D7": return "Animal Crossing Cards";
                case "00D8": return "Animal Crossing Cards";
                case "00D9": return "Animal Crossing Cards";
                case "00DA": return "Animal Crossing Cards";
                case "00DB": return "Animal Crossing Cards";
                case "00DC": return "Animal Crossing Cards";
                case "00DD": return "Animal Crossing Cards";
                case "00DE": return "Animal Crossing Cards";
                case "00DF": return "Animal Crossing Cards";
                case "00E0": return "Animal Crossing Cards";
                case "00E1": return "Animal Crossing Cards";
                case "00E2": return "Animal Crossing Cards";
                case "00E3": return "Animal Crossing Cards";
                case "00E4": return "Animal Crossing Cards";
                case "00E5": return "Animal Crossing Cards";
                case "00E6": return "Animal Crossing Cards";
                case "00E7": return "Animal Crossing Cards";
                case "00E8": return "Animal Crossing Cards";
                case "00E9": return "Animal Crossing Cards";
                case "00EA": return "Animal Crossing Cards";
                case "00EB": return "Animal Crossing Cards";
                case "00EC": return "Animal Crossing Cards";
                case "00ED": return "Animal Crossing Cards";
                case "00EE": return "Animal Crossing Cards";
                case "00EF": return "Animal Crossing Cards";
                case "00F0": return "Animal Crossing Cards";
                case "00F1": return "Animal Crossing Cards";
                case "00F2": return "Animal Crossing Cards";
                case "00F3": return "Animal Crossing Cards";
                case "00F4": return "Animal Crossing Cards";
                case "00F5": return "Animal Crossing Cards";
                case "00F6": return "Animal Crossing Cards";
                case "00F7": return "Animal Crossing Cards";
                case "00F8": return "Animal Crossing Cards";
                case "00F9": return "Animal Crossing Cards";
                case "00FA": return "Animal Crossing Cards";
                case "00FB": return "Animal Crossing Cards";
                case "00FC": return "Animal Crossing Cards";
                case "00FD": return "Animal Crossing Cards";
                case "00FE": return "Animal Crossing Cards";
                case "00FF": return "Animal Crossing Cards";
                case "0100": return "Animal Crossing Cards";
                case "0101": return "Animal Crossing Cards";
                case "0102": return "Animal Crossing Cards";
                case "0103": return "Animal Crossing Cards";
                case "0104": return "Animal Crossing Cards";
                case "0105": return "Animal Crossing Cards";
                case "0106": return "Animal Crossing Cards";
                case "0107": return "Animal Crossing Cards";
                case "0108": return "Animal Crossing Cards";
                case "0109": return "Animal Crossing Cards";
                case "010A": return "Animal Crossing Cards";
                case "010B": return "Animal Crossing Cards";
                case "010C": return "Animal Crossing Cards";
                case "010D": return "Animal Crossing Cards";
                case "010E": return "Animal Crossing Cards";
                case "010F": return "Animal Crossing Cards";
                case "0110": return "Animal Crossing Cards";
                case "0111": return "Animal Crossing Cards";
                case "0112": return "Animal Crossing Cards";
                case "0113": return "Animal Crossing Cards";
                case "0114": return "Animal Crossing Cards";
                case "0115": return "Animal Crossing Cards";
                case "0116": return "Animal Crossing Cards";
                case "0117": return "Animal Crossing Cards";
                case "0118": return "Animal Crossing Cards";
                case "0119": return "Animal Crossing Cards";
                case "011A": return "Animal Crossing Cards";
                case "011B": return "Animal Crossing Cards";
                case "011C": return "Animal Crossing Cards";
                case "011D": return "Animal Crossing Cards";
                case "011E": return "Animal Crossing Cards";
                case "011F": return "Animal Crossing Cards";
                case "0120": return "Animal Crossing Cards";
                case "0121": return "Animal Crossing Cards";
                case "0122": return "Animal Crossing Cards";
                case "0123": return "Animal Crossing Cards";
                case "0124": return "Animal Crossing Cards";
                case "0125": return "Animal Crossing Cards";
                case "0126": return "Animal Crossing Cards";
                case "0127": return "Animal Crossing Cards";
                case "0128": return "Animal Crossing Cards";
                case "0129": return "Animal Crossing Cards";
                case "012A": return "Animal Crossing Cards";
                case "012B": return "Animal Crossing Cards";
                case "012C": return "Animal Crossing Cards";
                case "012D": return "Animal Crossing Cards";
                case "012E": return "Animal Crossing Cards";
                case "012F": return "Animal Crossing Cards";
                case "0130": return "Animal Crossing Cards";
                case "0131": return "Animal Crossing Cards";
                case "0132": return "Animal Crossing Cards";
                case "0133": return "Animal Crossing Cards";
                case "0134": return "Animal Crossing Cards";
                case "0135": return "Animal Crossing Cards";
                case "0136": return "Animal Crossing Cards";
                case "0137": return "Animal Crossing Cards";
                case "0138": return "Animal Crossing Cards";
                case "0139": return "Animal Crossing Cards";
                case "013A": return "Animal Crossing Cards";
                case "013B": return "Animal Crossing Cards";
                case "013C": return "Animal Crossing Cards";
                case "013D": return "Animal Crossing Cards";
                case "013E": return "Animal Crossing Cards";
                case "013F": return "Animal Crossing Cards";
                case "0140": return "Animal Crossing Cards";
                case "0141": return "Animal Crossing Cards";
                case "0142": return "Animal Crossing Cards";
                case "0143": return "Animal Crossing Cards";
                case "0144": return "Animal Crossing Cards";
                case "0145": return "Animal Crossing Cards";
                case "0146": return "Animal Crossing Cards";
                case "0147": return "Animal Crossing Cards";
                case "0148": return "Animal Crossing Cards";
                case "0149": return "Animal Crossing Cards";
                case "014A": return "Animal Crossing Cards";
                case "014B": return "Animal Crossing Cards";
                case "014C": return "Animal Crossing Cards";
                case "014D": return "Animal Crossing Cards";
                case "014E": return "Animal Crossing Cards";
                case "014F": return "Animal Crossing Cards";
                case "0150": return "Animal Crossing Cards";
                case "0151": return "Animal Crossing Cards";
                case "0152": return "Animal Crossing Cards";
                case "0153": return "Animal Crossing Cards";
                case "0154": return "Animal Crossing Cards";
                case "0155": return "Animal Crossing Cards";
                case "0156": return "Animal Crossing Cards";
                case "0157": return "Animal Crossing Cards";
                case "0158": return "Animal Crossing Cards";
                case "0159": return "Animal Crossing Cards";
                case "015A": return "Animal Crossing Cards";
                case "015B": return "Animal Crossing Cards";
                case "015C": return "Animal Crossing Cards";
                case "015D": return "Animal Crossing Cards";
                case "015E": return "Animal Crossing Cards";
                case "015F": return "Animal Crossing Cards";
                case "0160": return "Animal Crossing Cards";
                case "0161": return "Animal Crossing Cards";
                case "0162": return "Animal Crossing Cards";
                case "0163": return "Animal Crossing Cards";
                case "0164": return "Animal Crossing Cards";
                case "0165": return "Animal Crossing Cards";
                case "0166": return "Animal Crossing Cards";
                case "0167": return "Animal Crossing Cards";
                case "0168": return "Animal Crossing Cards";
                case "0169": return "Animal Crossing Cards";
                case "016A": return "Animal Crossing Cards";
                case "016B": return "Animal Crossing Cards";
                case "016C": return "Animal Crossing Cards";
                case "016D": return "Animal Crossing Cards";
                case "016E": return "Animal Crossing Cards";
                case "016F": return "Animal Crossing Cards";
                case "0170": return "Animal Crossing Cards";
                case "0171": return "Animal Crossing Cards";
                case "0172": return "Animal Crossing Cards";
                case "0173": return "Animal Crossing Cards";
                case "0174": return "Animal Crossing Cards";
                case "0175": return "Animal Crossing Cards";
                case "0176": return "Animal Crossing Cards";
                case "0177": return "Animal Crossing Cards";
                case "0178": return "Animal Crossing Cards";
                case "0179": return "Animal Crossing Cards";
                case "017A": return "Animal Crossing Cards";
                case "017B": return "Animal Crossing Cards";
                case "017C": return "Animal Crossing Cards";
                case "017D": return "Animal Crossing Cards";
                case "017E": return "Animal Crossing Cards";
                case "017F": return "Animal Crossing Cards";
                case "0180": return "Animal Crossing Cards";
                case "0181": return "Animal Crossing Cards";
                case "0182": return "Animal Crossing Cards";
                case "0183": return "Animal Crossing Cards";
                case "0184": return "Animal Crossing Cards";
                case "0185": return "Animal Crossing Cards";
                case "0186": return "Animal Crossing Cards";
                case "0187": return "Animal Crossing Cards";
                case "0188": return "Animal Crossing Cards";
                case "0189": return "Animal Crossing Cards";
                case "018A": return "Animal Crossing Cards";
                case "018B": return "Animal Crossing Cards";
                case "018C": return "Animal Crossing Cards";
                case "018D": return "Animal Crossing Cards";
                case "018E": return "Animal Crossing Cards";
                case "018F": return "Animal Crossing Cards";
                case "0190": return "Animal Crossing Cards";
                case "0191": return "Animal Crossing Cards";
                case "0192": return "Animal Crossing Cards";
                case "0193": return "Animal Crossing Cards";
                case "0194": return "Animal Crossing Cards";
                case "0195": return "Animal Crossing Cards";
                case "0196": return "Animal Crossing Cards";
                case "0197": return "Animal Crossing Cards";
                case "0198": return "Animal Crossing Cards";
                case "0199": return "Animal Crossing Cards";
                case "019A": return "Animal Crossing Cards";
                case "019B": return "Animal Crossing Cards";
                case "019C": return "Animal Crossing Cards";
                case "019D": return "Animal Crossing Cards";
                case "019E": return "Animal Crossing Cards";
                case "019F": return "Animal Crossing Cards";
                case "01A0": return "Animal Crossing Cards";
                case "01A1": return "Animal Crossing Cards";
                case "01A2": return "Animal Crossing Cards";
                case "01A3": return "Animal Crossing Cards";
                case "01A4": return "Animal Crossing Cards";
                case "01A5": return "Animal Crossing Cards";
                case "01A6": return "Animal Crossing Cards";
                case "01A7": return "Animal Crossing Cards";
                case "01A8": return "Animal Crossing Cards";
                case "01A9": return "Animal Crossing Cards";
                case "01AA": return "Animal Crossing Cards";
                case "01AB": return "Animal Crossing Cards";
                case "01AC": return "Animal Crossing Cards";
                case "01AD": return "Animal Crossing Cards";
                case "01AE": return "Animal Crossing Cards";
                case "01AF": return "Animal Crossing Cards";
                case "01B0": return "Animal Crossing Cards";
                case "01B1": return "Animal Crossing Cards";
                case "01B2": return "Animal Crossing Cards";
                case "01B3": return "Animal Crossing Cards";
                case "01B4": return "Animal Crossing Cards";
                case "01B5": return "Animal Crossing Cards";
                case "01B6": return "Animal Crossing Cards";
                case "01B7": return "Animal Crossing Cards";
                case "01B8": return "Animal Crossing Cards";
                case "01B9": return "Animal Crossing Cards";
                case "01BA": return "Animal Crossing Cards";
                case "01BB": return "Animal Crossing Cards";
                case "01BC": return "Animal Crossing Cards";
                case "01BD": return "Animal Crossing Cards";
                case "01BE": return "Animal Crossing Cards";
                case "01BF": return "Animal Crossing Cards";
                case "01C0": return "Animal Crossing Cards";
                case "01C1": return "Animal Crossing Cards";
                case "01C2": return "Animal Crossing Cards";
                case "01C3": return "Animal Crossing Cards";
                case "01C4": return "Animal Crossing Cards";
                case "01C5": return "Animal Crossing Cards";
                case "01C6": return "Animal Crossing Cards";
                case "01C7": return "Animal Crossing Cards";
                case "01C8": return "Animal Crossing Cards";
                case "01C9": return "Animal Crossing Cards";
                case "01CA": return "Animal Crossing Cards";
                case "01CB": return "Animal Crossing Cards";
                case "01CC": return "Animal Crossing Cards";
                case "01CD": return "Animal Crossing Cards";
                case "01CE": return "Animal Crossing Cards";
                case "01CF": return "Animal Crossing Cards";
                case "01D0": return "Animal Crossing Cards";
                case "01D1": return "Animal Crossing Cards";
                case "01D2": return "Animal Crossing Cards";
                case "01D3": return "Animal Crossing Cards";
                case "01D4": return "Animal Crossing Cards";
                case "01D5": return "Animal Crossing Cards";
                case "01D6": return "Animal Crossing Cards";
                case "01D7": return "Animal Crossing Cards";
                case "01D8": return "Animal Crossing Cards";
                case "0238": return "8 - Bit Mario";
                case "0239": return "8 - Bit Mario";
                case "023A": return "Skylanders";
                case "023B": return "Skylanders";
                case "023D": return "Super Smash Bros.";
                case "023E": return "Yoshi's Woolly World";
                case "023F": return "Animal Crossing Figures";
                case "0240": return "Animal Crossing Figures";
                case "0241": return "Animal Crossing Figures";
                case "0242": return "Animal Crossing Figures";
                case "0243": return "Animal Crossing Figures";
                case "0244": return "Animal Crossing Figures";
                case "0245": return "Animal Crossing Figures";
                case "0246": return "Animal Crossing Figures";
                case "0247": return "Animal Crossing Figures";
                case "0248": return "Animal Crossing Figures";
                case "0249": return "Animal Crossing Figures";
                case "024A": return "Animal Crossing Figures";
                case "024B": return "Animal Crossing Figures";
                case "024C": return "Animal Crossing Figures";
                case "024D": return "Animal Crossing Figures";
                case "024E": return "Animal Crossing Figures";
                case "024F": return "The Legend of Zelda";
                case "0250": return "Shovel Knight";
                case "0251": return "Super Smash Bros.";
                case "0252": return "Super Smash Bros.";
                case "0253": return "Super Smash Bros.";
                case "0254": return "Kirby";
                case "0255": return "Kirby";
                case "0256": return "Kirby";
                case "0257": return "Kirby";
                case "0258": return "Super Smash Bros.";
                case "0259": return "Super Smash Bros.";
                case "025A": return "Super Smash Bros.";
                case "025B": return "Super Smash Bros.";
                case "025C": return "Pokken";
                case "025D": return "Splatoon";
                case "025E": return "Splatoon";
                case "025F": return "Splatoon";
                case "0260": return "Splatoon";
                case "0261": return "Splatoon";
                case "0262": return "Super Mario";
                case "0263": return "Super Mario";
                case "0264": return "Super Mario";
                case "0265": return "Super Mario";
                case "0266": return "Super Mario";
                case "0267": return "Super Mario";
                case "0268": return "Super Mario";
                case "0269": return "Mario Sports Superstars";
                case "026A": return "Mario Sports Superstars";
                case "026B": return "Mario Sports Superstars";
                case "026C": return "Mario Sports Superstars";
                case "026D": return "Mario Sports Superstars";
                case "026E": return "Mario Sports Superstars";
                case "026F": return "Mario Sports Superstars";
                case "0270": return "Mario Sports Superstars";
                case "0271": return "Mario Sports Superstars";
                case "0272": return "Mario Sports Superstars";
                case "0273": return "Mario Sports Superstars";
                case "0274": return "Mario Sports Superstars";
                case "0275": return "Mario Sports Superstars";
                case "0276": return "Mario Sports Superstars";
                case "0277": return "Mario Sports Superstars";
                case "0278": return "Mario Sports Superstars";
                case "0279": return "Mario Sports Superstars";
                case "027A": return "Mario Sports Superstars";
                case "027B": return "Mario Sports Superstars";
                case "027C": return "Mario Sports Superstars";
                case "027D": return "Mario Sports Superstars";
                case "027E": return "Mario Sports Superstars";
                case "027F": return "Mario Sports Superstars";
                case "0280": return "Mario Sports Superstars";
                case "0281": return "Mario Sports Superstars";
                case "0282": return "Mario Sports Superstars";
                case "0283": return "Mario Sports Superstars";
                case "0284": return "Mario Sports Superstars";
                case "0285": return "Mario Sports Superstars";
                case "0286": return "Mario Sports Superstars";
                case "0287": return "Mario Sports Superstars";
                case "0288": return "Mario Sports Superstars";
                case "0289": return "Mario Sports Superstars";
                case "028A": return "Mario Sports Superstars";
                case "028B": return "Mario Sports Superstars";
                case "028C": return "Mario Sports Superstars";
                case "028D": return "Mario Sports Superstars";
                case "028E": return "Mario Sports Superstars";
                case "028F": return "Mario Sports Superstars";
                case "0290": return "Mario Sports Superstars";
                case "0291": return "Mario Sports Superstars";
                case "0292": return "Mario Sports Superstars";
                case "0293": return "Mario Sports Superstars";
                case "0294": return "Mario Sports Superstars";
                case "0295": return "Mario Sports Superstars";
                case "0296": return "Mario Sports Superstars";
                case "0297": return "Mario Sports Superstars";
                case "0298": return "Mario Sports Superstars";
                case "0299": return "Mario Sports Superstars";
                case "029A": return "Mario Sports Superstars";
                case "029B": return "Mario Sports Superstars";
                case "029C": return "Mario Sports Superstars";
                case "029D": return "Mario Sports Superstars";
                case "029E": return "Mario Sports Superstars";
                case "029F": return "Mario Sports Superstars";
                case "02A0": return "Mario Sports Superstars";
                case "02A1": return "Mario Sports Superstars";
                case "02A2": return "Mario Sports Superstars";
                case "02A3": return "Mario Sports Superstars";
                case "02A4": return "Mario Sports Superstars";
                case "02A5": return "Mario Sports Superstars";
                case "02A6": return "Mario Sports Superstars";
                case "02A7": return "Mario Sports Superstars";
                case "02A8": return "Mario Sports Superstars";
                case "02A9": return "Mario Sports Superstars";
                case "02AA": return "Mario Sports Superstars";
                case "02AB": return "Mario Sports Superstars";
                case "02AC": return "Mario Sports Superstars";
                case "02AD": return "Mario Sports Superstars";
                case "02AE": return "Mario Sports Superstars";
                case "02AF": return "Mario Sports Superstars";
                case "02B0": return "Mario Sports Superstars";
                case "02B1": return "Mario Sports Superstars";
                case "02B2": return "Mario Sports Superstars";
                case "02B3": return "Mario Sports Superstars";
                case "02B4": return "Mario Sports Superstars";
                case "02B5": return "Mario Sports Superstars";
                case "02B6": return "Mario Sports Superstars";
                case "02B7": return "Mario Sports Superstars";
                case "02B8": return "Mario Sports Superstars";
                case "02B9": return "Mario Sports Superstars";
                case "02BA": return "Mario Sports Superstars";
                case "02BB": return "Mario Sports Superstars";
                case "02BC": return "Mario Sports Superstars";
                case "02BD": return "Mario Sports Superstars";
                case "02BE": return "Mario Sports Superstars";
                case "02BF": return "Mario Sports Superstars";
                case "02C0": return "Mario Sports Superstars";
                case "02C1": return "Mario Sports Superstars";
                case "02C2": return "Mario Sports Superstars";
                case "02E1": return "Monster Hunter Stories";
                case "02E2": return "Monster Hunter Stories";
                case "02E3": return "Monster Hunter Stories";
                case "02E4": return "Monster Hunter Stories";
                case "02E5": return "Monster Hunter Stories";
                case "02E6": return "Monster Hunter Stories";
                case "02E7": return "Animal Crossing Cards";
                case "02E8": return "Animal Crossing Cards";
                case "02E9": return "Animal Crossing Cards";
                case "02EA": return "Animal Crossing Cards";
                case "02EB": return "Animal Crossing Cards";
                case "02EC": return "Animal Crossing Cards";
                case "02ED": return "Animal Crossing Cards";
                case "02EE": return "Animal Crossing Cards";
                case "02EF": return "Animal Crossing Cards";
                case "02F0": return "Animal Crossing Cards";
                case "02F1": return "Animal Crossing Cards";
                case "02F2": return "Animal Crossing Cards";
                case "02F3": return "Animal Crossing Cards";
                case "02F4": return "Animal Crossing Cards";
                case "02F5": return "Animal Crossing Cards";
                case "02F6": return "Animal Crossing Cards";
                case "02F7": return "Animal Crossing Cards";
                case "02F8": return "Animal Crossing Cards";
                case "02F9": return "Animal Crossing Cards";
                case "02FA": return "Animal Crossing Cards";
                case "02FB": return "Animal Crossing Cards";
                case "02FC": return "Animal Crossing Cards";
                case "02FD": return "Animal Crossing Cards";
                case "02FE": return "Animal Crossing Cards";
                case "02FF": return "Animal Crossing Cards";
                case "0300": return "Animal Crossing Cards";
                case "0301": return "Animal Crossing Cards";
                case "0302": return "Animal Crossing Cards";
                case "0303": return "Animal Crossing Cards";
                case "0304": return "Animal Crossing Cards";
                case "0305": return "Animal Crossing Cards";
                case "0306": return "Animal Crossing Cards";
                case "0307": return "Animal Crossing Cards";
                case "0308": return "Animal Crossing Cards";
                case "0309": return "Animal Crossing Cards";
                case "030A": return "Animal Crossing Cards";
                case "030B": return "Animal Crossing Cards";
                case "030C": return "Animal Crossing Cards";
                case "030D": return "Animal Crossing Cards";
                case "030E": return "Animal Crossing Cards";
                case "030F": return "Animal Crossing Cards";
                case "0310": return "Animal Crossing Cards";
                case "0311": return "Animal Crossing Cards";
                case "0312": return "Animal Crossing Cards";
                case "0313": return "Animal Crossing Cards";
                case "0314": return "Animal Crossing Cards";
                case "0315": return "Animal Crossing Cards";
                case "0316": return "Animal Crossing Cards";
                case "0317": return "Animal Crossing Cards";
                case "0318": return "Animal Crossing Cards";
                case "0319": return "Animal Crossing Sanrio";
                case "031A": return "Animal Crossing Sanrio";
                case "031B": return "Animal Crossing Sanrio";
                case "031C": return "Animal Crossing Sanrio";
                case "031D": return "Animal Crossing Sanrio";
                case "031E": return "Animal Crossing Sanrio";
                case "034B": return "The Legend of Zelda";
                case "034C": return "The Legend of Zelda";
                case "034D": return "The Legend of Zelda";
                case "034E": return "The Legend of Zelda";
                case "034F": return "The Legend of Zelda";
                case "0350": return "The Legend of Zelda";
                case "0352": return "The Legend of Zelda";
                case "0353": return "The Legend of Zelda";
                case "0354": return "The Legend of Zelda";
                case "0355": return "The Legend of Zelda";
                case "0356": return "The Legend of Zelda";
                case "0358": return "The Legend of Zelda";
                case "0359": return "The Legend of Zelda";
                case "035A": return "The Legend of Zelda";
                case "035B": return "The Legend of Zelda";
                case "035C": return "The Legend of Zelda";
                case "035D": return "Yoshi's Woolly World";
                case "035E": return "BoxBoy!";
                case "035F": return "Pikmin";
                case "0360": return "Fire Emblem";
                case "0361": return "Fire Emblem";
                case "0362": return "Super Smash Bros.";
                case "0363": return "Super Smash Bros.";
                case "0364": return "Super Smash Bros.";
                case "0365": return "Metroid";
                case "0366": return "Metroid";
                case "0367": return "Super Mario";
                case "0368": return "Super Mario";
                case "0369": return "Splatoon";
                case "036A": return "Splatoon";
                case "036B": return "Splatoon";
                case "036F": return "Fire Emblem";
                case "0370": return "Fire Emblem";
                case "0371": return "Super Mario";
                case "0372": return "Super Mario";
                case "0373": return "Super Mario";
                case "0374": return "Super Mario Cereal";
                default: return "";

            }
        }

        /// <summary>
        /// 13to14 2018-01-24
        /// </summary>
        /// <param name="AmiiboSer"></param>
        /// <returns></returns>
        private string GetAmiiboName13to14(string AmiiboSer)
        {
            switch (AmiiboSer)
            {
                case "00": return "Super Smash Bros.";
                case "01": return "Super Mario";
                case "02": return "Chibi-Robo";
                case "03": return "Yoshi's Woolly World";
                case "04": return "Splatoon";
                case "05": return "Animal Crossing";
                case "06": return "8 - Bit Mario";
                case "07": return "Skylanders";
                case "08": return "???";
                case "09": return "The Legend Of Zelda";
                case "0A": return "Shovel Knight";
                case "0B": return "???";
                case "0C": return "Kirby";
                case "0D": return "Pokken";
                case "0E": return "Mario Sports Superstars";
                case "0F": return "Monster Hunter";
                case "10": return "BoxBoy!";
                case "11": return "Pikmin";
                case "12": return "Fire Emblem";
                case "13": return "Metroid";
                case "14": return "Kellogs";
                default: return "";
            }
        }

        /// <summary>
        /// 15to16 2017-08-01
        /// </summary>
        /// <param name="AmiiboSer"></param>
        /// <returns></returns>
        private string GetAmiiboName15to16(string AmiiboSer)
        {
            switch (AmiiboSer)
            {
                case "02": return "Fixed";
                default: return "";
            }
        }

        /// <summary>
        /// 01to04 2018-01-24
        /// </summary>
        /// <param name="AmiiboSer"></param>
        /// <returns></returns>
        private string GetAmiiboName01to04(string AmiiboSer)
        {
            switch (AmiiboSer)
            {
                case "0000": return "Mario";
                case "0001": return "Luigi";
                case "0002": return "Peach";
                case "0003": return "Yoshi";
                case "0004": return "Rosalina";
                case "0005": return "Bowser";
                case "0006": return "Bowser Jr.";
                case "0007": return "Wario";
                case "0008": return "Donkey Kong";
                case "0009": return "Diddy Kong";
                case "000A": return "Toad";
                case "0013": return "Daisy";
                case "0014": return "Waluigi";
                case "0015": return "Goomba";
                case "0017": return "Boo";
                case "0023": return "Koopa Troopa";
                case "0080": return "Poochy";
                case "0100": return "Link";
                case "0101": return "Zelda";
                case "0102": return "Ganon";
                case "0103": return "Wolf Link";
                case "0105": return "Daruk(Goron Champion)";
                case "0106": return "Urbosa(Gerudo Champion)";
                case "0107": return "Mipha(Zora Champion)";
                case "0108": return "Revali(Rito Champion)";
                case "0140": return "Guardian";
                case "0141": return "Bokoblin";
                case "0180": return "Villager";
                case "0181": return "Isabelle";
                case "0182": return "K.K. Slider";
                case "0183": return "Tom Nook";
                case "0184": return "Timmy & Tommy";
                case "0185": return "Timmy";
                case "0186": return "Tommy";
                case "0187": return "Sable";
                case "0188": return "Mabel";
                case "0189": return "Labelle";
                case "018A": return "Reese";
                case "018B": return "Cyrus";
                case "018C": return "Digby";
                case "018D": return "Rover";
                case "018E": return "Mr. Resetti";
                case "018F": return "Don Resetti";
                case "0190": return "Brewster";
                case "0191": return "Harriet";
                case "0192": return "Blathers";
                case "0193": return "Celeste";
                case "0194": return "Kicks";
                case "0195": return "Porter";
                case "0196": return "Kapp'n";
                case "0197": return "Leilani";
                case "0198": return "Lelia";
                case "0199": return "Grams";
                case "019A": return "Chip";
                case "019B": return "Nat";
                case "019C": return "Phineas";
                case "019D": return "Copper";
                case "019E": return "Booker";
                case "019F": return "Pete";
                case "01A0": return "Pelly";
                case "01A1": return "Phyllis";
                case "01A2": return "Gulliver";
                case "01A3": return "Joan";
                case "01A4": return "Pascal";
                case "01A5": return "Katarina";
                case "01A6": return "Sahara";
                case "01A7": return "Wendell";
                case "01A8": return "Redd";
                case "01A9": return "Gracie";
                case "01AA": return "Lyle";
                case "01AB": return "Pave";
                case "01AC": return "Zipper";
                case "01AD": return "Jack";
                case "01AE": return "Franklin";
                case "01AF": return "Jingle";
                case "01B0": return "Tortimer";
                case "01B1": return "Dr. Shrunk";
                case "01B3": return "Blanca";
                case "01B4": return "Leif";
                case "01B5": return "Luna";
                case "01B6": return "Katie";
                case "01C1": return "Lottie";
                case "0200": return "Cyrano";
                case "0201": return "Antonio";
                case "0202": return "Pango";
                case "0203": return "Anabelle";
                case "0206": return "Snooty";
                case "0208": return "Annalisa";
                case "0209": return "Olaf";
                case "0214": return "Teddy";
                case "0215": return "Pinky";
                case "0216": return "Curt";
                case "0217": return "Chow";
                case "0219": return "Nate";
                case "021A": return "Groucho";
                case "021B": return "Tutu";
                case "021C": return "Ursala";
                case "021D": return "Grizzly";
                case "021E": return "Puala";
                case "021F": return "Ike";
                case "0220": return "Charlise";
                case "0221": return "Beardo";
                case "0222": return "Klaus";
                case "022D": return "Jay";
                case "022E": return "Robin";
                case "022F": return "Anchovy";
                case "0230": return "Twiggy";
                case "0231": return "Jitters";
                case "0232": return "Piper";
                case "0233": return "Admiral";
                case "0235": return "Midge";
                case "0238": return "Jacob";
                case "023C": return "Lucha";
                case "023D": return "Jacques";
                case "023E": return "Peck";
                case "023F": return "Sparro";
                case "024A": return "Angus";
                case "024B": return "Rodeo";
                case "024D": return "Stu";
                case "024F": return "T-Bone";
                case "0251": return "Coach";
                case "0252": return "Vic";
                case "025D": return "Bob";
                case "025E": return "Mitzi";
                case "025F": return "Rosie";
                case "0260": return "Olivia";
                case "0261": return "Kiki";
                case "0262": return "Tangy";
                case "0263": return "Punchy";
                case "0264": return "Purrl";
                case "0265": return "Moe";
                case "0266": return "Kabuki";
                case "0267": return "Kid Cat";
                case "0268": return "Monique";
                case "0269": return "Tabby";
                case "026A": return "Stinky";
                case "026B": return "Kitty";
                case "026C": return "Tom";
                case "026D": return "Merry";
                case "026E": return "Felicity";
                case "026F": return "Lolly";
                case "0270": return "Ankha";
                case "0271": return "Rudy";
                case "0272": return "Katt";
                case "027D": return "Bluebear";
                case "027E": return "Maple";
                case "027F": return "Poncho";
                case "0280": return "Pudge";
                case "0281": return "Kody";
                case "0282": return "Stitches";
                case "0283": return "Vladimir";
                case "0284": return "Murphy";
                case "0286": return "Olive";
                case "0287": return "Cheri";
                case "028A": return "June";
                case "028B": return "Pekoe";
                case "028C": return "Chester";
                case "028D": return "Barold";
                case "028E": return "Tammy";
                case "028F": return "Marty";
                case "0299": return "Goose";
                case "029A": return "Benedict";
                case "029B": return "Egbert";
                case "029E": return "Ava";
                case "02A2": return "Becky";
                case "02A3": return "Plucky";
                case "02A4": return "Knox";
                case "02A5": return "Broffina";
                case "02A6": return "Ken";
                case "02B1": return "Patty";
                case "02B2": return "Tipper";
                case "02B7": return "Norma";
                case "02B8": return "Naomi";
                case "02C3": return "Alfonso";
                case "02C4": return "Alli";
                case "02C5": return "Boots";
                case "02C7": return "Del";
                case "02C9": return "Sly";
                case "02CA": return "Gayle";
                case "02CB": return "Drago";
                case "02D6": return "Fauna";
                case "02D7": return "Bam";
                case "02D8": return "Zell";
                case "02D9": return "Bruce";
                case "02DA": return "Deidre";
                case "02DB": return "Lopez";
                case "02DC": return "Fuchsia";
                case "02DD": return "Beau";
                case "02DE": return "Diana";
                case "02DF": return "Erik";
                case "02E0": return "Chelsea";
                case "02EA": return "Goldie";
                case "02EB": return "Butch";
                case "02EC": return "Lucky";
                case "02ED": return "Biskit";
                case "02EE": return "Bones";
                case "02EF": return "Portia";
                case "02F0": return "Walker";
                case "02F1": return "Daisy";
                case "02F2": return "Cookie";
                case "02F3": return "Maddie";
                case "02F4": return "Bea";
                case "02F8": return "Mac";
                case "02F9": return "Marcel";
                case "02FA": return "Benjamin";
                case "02FB": return "Cherry";
                case "02FC": return "Shep";
                case "0307": return "Bill";
                case "0308": return "Joey";
                case "0309": return "Pate";
                case "030A": return "Maelle";
                case "030B": return "Deena";
                case "030C": return "Pompom";
                case "030D": return "Mallary";
                case "030E": return "Freckles";
                case "030F": return "Derwin";
                case "0310": return "Drake";
                case "0311": return "Scoot";
                case "0312": return "Weber";
                case "0313": return "Miranda";
                case "0314": return "Ketchup";
                case "0316": return "Gloria";
                case "0317": return "Molly";
                case "0318": return "Quillson";
                case "0323": return "Opal";
                case "0324": return "Dizzy";
                case "0325": return "Big Top";
                case "0326": return "Eloise";
                case "0327": return "Margie";
                case "0328": return "Paolo";
                case "0329": return "Axel";
                case "032A": return "Ellie";
                case "032C": return "Tucker";
                case "032D": return "Tia";
                case "032E": return "Chai";
                case "0338": return "Lily";
                case "0339": return "Ribbot";
                case "033A": return "Frobert";
                case "033B": return "Camofrog";
                case "033C": return "Drift";
                case "033D": return "Wart Jr.";
                case "033E": return "Puddies";
                case "033F": return "Jeremiah";
                case "0341": return "Tad";
                case "0342": return "Cousteau";
                case "0343": return "Huck";
                case "0344": return "Prince";
                case "0345": return "Jambette";
                case "0347": return "Raddle";
                case "0348": return "Gigi";
                case "0349": return "Croque";
                case "034A": return "Diva";
                case "034B": return "Henry";
                case "0356": return "Chevre";
                case "0357": return "Nan";
                case "0358": return "Billy";
                case "035A": return "Gruff";
                case "035C": return "Velma";
                case "035D": return "Kidd";
                case "035E": return "Pashmina";
                case "0369": return "Cesar";
                case "036A": return "Peewee";
                case "036B": return "Boone";
                case "036D": return "Louie";
                case "036E": return "Maddie";
                case "0370": return "Violet";
                case "0371": return "Al";
                case "0372": return "Rocket";
                case "0373": return "Hans";
                case "0374": return "Rilla";
                case "037E": return "Hamlet";
                case "037F": return "Apple";
                case "0380": return "Graham";
                case "0381": return "Rodney";
                case "0382": return "Soleil";
                case "0383": return "Clay";
                case "0384": return "Flurry";
                case "0385": return "Hamphrey";
                case "0390": return "Rocco";
                case "0392": return "Bubbles";
                case "0393": return "Bertha";
                case "0394": return "Biff";
                case "0395": return "Bitty";
                case "0398": return "Harry";
                case "0399": return "Hippeux";
                case "03A4": return "Buck";
                case "03A5": return "Victoria";
                case "03A6": return "Savannah";
                case "03A7": return "Elmer";
                case "03A8": return "Rosco";
                case "03A9": return "Winnie";
                case "03AA": return "Ed";
                case "03AB": return "Cleo";
                case "03AC": return "Peaches";
                case "03AD": return "Annalise";
                case "03AE": return "Clyde";
                case "03AF": return "Colton";
                case "03B0": return "Papi";
                case "03B1": return "Julian";
                case "03BC": return "Yuka";
                case "03BD": return "Alice";
                case "03BE": return "Melba";
                case "03BF": return "Sydney";
                case "03C0": return "Gonzo";
                case "03C1": return "Ozzie";
                case "03C4": return "Canberra";
                case "03C5": return "Lyman";
                case "03C6": return "Eugene";
                case "03D1": return "Kitt";
                case "03D2": return "Mathilda";
                case "03D3": return "Carrie";
                case "03D6": return "Astrid";
                case "03D7": return "Sylvia";
                case "03D9": return "Walt";
                case "03DA": return "Rodney";
                case "03DB": return "Marcie";
                case "03E6": return "Bud";
                case "03E7": return "Elvis";
                case "03E8": return "Rex";
                case "03EA": return "Leopold";
                case "03EC": return "Mott";
                case "03ED": return "Rory";
                case "03EE": return "Lionel";
                case "03FA": return "Nana";
                case "03FB": return "Simon";
                case "03FC": return "Tammi";
                case "03FD": return "Monty";
                case "03FE": return "Elise";
                case "03FF": return "Flip";
                case "0400": return "Shari";
                case "0401": return "Deli";
                case "040C": return "Dora";
                case "040D": return "Limberg";
                case "040E": return "Bella";
                case "040F": return "Bree";
                case "0410": return "Samson";
                case "0411": return "Rod";
                case "0414": return "Candi";
                case "0415": return "Rizzo";
                case "0416": return "Anicotti";
                case "0418": return "Broccolo";
                case "041A": return "Moose";
                case "041B": return "Bettina";
                case "041C": return "Greta";
                case "041D": return "Penelope";
                case "041E": return "Chadder";
                case "0429": return "Octavian";
                case "042A": return "Marina";
                case "042B": return "Zucker";
                case "0436": return "Queenie";
                case "0437": return "Gladys";
                case "0438": return "Sandy";
                case "0439": return "Sprocket";
                case "043B": return "Julia";
                case "043C": return "Cranston";
                case "043D": return "Phil";
                case "043E": return "Blanche";
                case "043F": return "Flora";
                case "0440": return "Phoebe";
                case "044B": return "Apollo";
                case "044C": return "Amelia";
                case "044D": return "Pierce";
                case "044E": return "Buzz";
                case "0450": return "Avery";
                case "0451": return "Frank";
                case "0452": return "Sterling";
                case "0453": return "Keaton";
                case "0454": return "Celia";
                case "045F": return "Aurora";
                case "0460": return "Roald";
                case "0461": return "Cube";
                case "0462": return "Hopper";
                case "0463": return "Friga";
                case "0464": return "Gwen";
                case "0465": return "Puck";
                case "0468": return "Wade";
                case "0469": return "Boomer";
                case "046A": return "Iggly";
                case "046B": return "Tex";
                case "046C": return "Flo";
                case "046D": return "Sprinkle";
                case "0478": return "Curly";
                case "0479": return "Truffles";
                case "047A": return "Rasher";
                case "047B": return "Hugh";
                case "047C": return "Lucy";
                case "047D": return "Spork-Crackle";
                case "0480": return "Cobb";
                case "0481": return "Boris";
                case "0482": return "Maggie";
                case "0483": return "Peggy";
                case "0485": return "Gala";
                case "0486": return "Chops";
                case "0487": return "Kevin";
                case "0488": return "Pancetti";
                case "0489": return "Agnes";
                case "0494": return "Bunnie";
                case "0495": return "Dotty";
                case "0496": return "Coco";
                case "0497": return "Snake";
                case "0498": return "Gaston";
                case "0499": return "Gabi";
                case "049A": return "Pippy";
                case "049B": return "Tiffany";
                case "049C": return "Genji";
                case "049D": return "Ruby";
                case "049E": return "Doc";
                case "049F": return "Claude";
                case "04A0": return "Francine";
                case "04A1": return "Chrissy";
                case "04A2": return "Hopkins";
                case "04A3": return "OHare";
                case "04A4": return "Carmen";
                case "04A5": return "Bonbon";
                case "04A6": return "Cole";
                case "04A7": return "Mira";
                case "04A8": return "Toby";
                case "04B2": return "Tank";
                case "04B3": return "Rhonda";
                case "04B4": return "Spike";
                case "04B6": return "Hornsby";
                case "04B9": return "Merengue";
                case "04BA": return "Ren\u00e9e";
                case "04C5": return "Vesta";
                case "04C6": return "Baabara";
                case "04C7": return "Eunice";
                case "04C8": return "Stella";
                case "04C9": return "Cashmere";
                case "04CC": return "Willow";
                case "04CD": return "Curlos";
                case "04CE": return "Wendy";
                case "04CF": return "Timbra";
                case "04D0": return "Frita";
                case "04D1": return "Muffy";
                case "04D2": return "Pietro";
                case "04D3": return "\u00c9toile";
                case "04DD": return "Peanut";
                case "04DE": return "Blaire";
                case "04DF": return "Filbert";
                case "04E0": return "Pecan";
                case "04E1": return "Nibbles";
                case "04E2": return "Agent S";
                case "04E3": return "Caroline";
                case "04E4": return "Sally";
                case "04E5": return "Static";
                case "04E6": return "Mint";
                case "04E7": return "Ricky";
                case "04E8": return "Cally";
                case "04EA": return "Tasha";
                case "04EB": return "Sylvana";
                case "04EC": return "Poppy";
                case "04ED": return "Sheldon";
                case "04EE": return "Marshal";
                case "04EF": return "Hazel";
                case "04FA": return "Rolf";
                case "04FB": return "Rowan";
                case "04FC": return "Tybalt";
                case "04FD": return "Bangle";
                case "04FE": return "Leonardo";
                case "04FF": return "Claudia";
                case "0500": return "Bianca";
                case "050B": return "Chief";
                case "050C": return "Lobo";
                case "050D": return "Wolfgang";
                case "050E": return "Whitney";
                case "050F": return "Dobie";
                case "0510": return "Freya";
                case "0511": return "Fang";
                case "0513": return "Vivian";
                case "0514": return "Skye";
                case "0515": return "Kyle";
                case "0580": return "Fox";
                case "0581": return "Falco";
                case "05C0": return "Samus";
                case "05C1": return "Metroid";
                case "0600": return "Captain Falcon";
                case "0640": return "Olimar";
                case "0642": return "Pikmin";
                case "06C0": return "Little Mac";
                case "0700": return "Wii Fit Trainer";
                case "0740": return "Pit";
                case "0741": return "Dark Pit";
                case "0742": return "Palutena";
                case "0780": return "Mr. G&W";
                case "0781": return "R.O.B.";
                case "0782": return "Duck Hunt";
                case "07C0": return "Mii";
                case "0800": return "Inkling";
                case "0801": return "Callie";
                case "0802": return "Marie";
                case "09C0": return "Mario";
                case "09C1": return "Luigi";
                case "09C2": return "Peach";
                case "09C3": return "Daisy";
                case "09C4": return "Yoshi";
                case "09C5": return "Wario";
                case "09C6": return "Waluigi";
                case "09C7": return "Donkey Kong";
                case "09C8": return "Diddy Kong";
                case "09C9": return "Bowser";
                case "09CA": return "Bowser Jr.";
                case "09CB": return "Boo";
                case "09CC": return "Baby Mario";
                case "09CD": return "Baby Luigi";
                case "09CE": return "Birdo";
                case "09CF": return "Rosalina";
                case "09D0": return "Metal Mario";
                case "09D1": return "Pink Gold Peach";
                case "1906": return "Charizard";
                case "1919": return "Pikachu";
                case "1927": return "Jigglypuff";
                case "1996": return "Mewtwo";
                case "1AC0": return "Lucario";
                case "1B92": return "Greninja";
                case "1D00": return "Shadow Mewtwo";
                case "1F00": return "Kirby";
                case "1F01": return "Meta Knight";
                case "1F02": return "King Dedede";
                case "1F03": return "Waddle Dee";
                case "1F40": return "Qbby";
                case "2100": return "Marth";
                case "2101": return "Ike";
                case "2102": return "Lucina";
                case "2103": return "Robin";
                case "2104": return "Roy";
                case "2105": return "Corrin";
                case "2106": return "Alm";
                case "2107": return "Celica";
                case "2108": return "Chrom";
                case "2109": return "Tiki";
                case "2240": return "Shulk";
                case "2280": return "Ness";
                case "2281": return "Lucas";
                case "22C0": return "Chibi-Robo";
                case "3200": return "Sonic";
                case "3240": return "Bayonetta";
                case "3340": return "PAC-MAN";
                case "3480": return "Mega Man";
                case "34C0": return "Ryu";
                case "3500": return "One-Eyed Rathalos";
                case "3501": return "Nabiru";
                case "3502": return "Rathian";
                case "3503": return "Barioth";
                case "3504": return "Qurupeco";
                case "35C0": return "Shovel Knight";
                case "3600": return "Cloud Strif";
                case "3740": return "Super Mario Cereal";

                default: return "";
            }
        }

        /// <summary>
        /// 09to12B 2018-01-24
        /// </summary>
        /// <param name="AmiiboSer"></param>
        /// <returns></returns>
        private string GetAmiiboName09to12B(string AmiiboSer)
        {
            switch (AmiiboSer)
            {
                case "0000": return "Mario";
                case "0001": return "Peach";
                case "0002": return "Yoshi";
                case "0003": return "Donkey Kong";
                case "0004": return "Link";
                case "0005": return "Fox";
                case "0006": return "Samus";
                case "0007": return "Wii Fit Trainer";
                case "0008": return "Villager";
                case "0009": return "Pikachu";
                case "000A": return "Kirby";
                case "000B": return "Marth";
                case "000C": return "Luigi";
                case "000D": return "Diddy Kong";
                case "000E": return "Zelda";
                case "000F": return "Little Mac";
                case "0010": return "Pit";
                case "0011": return "Lucario";
                case "0012": return "Captain Falcon";
                case "0013": return "Rosalina & Luma";
                case "0014": return "Bowser";
                case "0015": return "Bowser Jr.";
                case "0016": return "Toon Link";
                case "0017": return "Sheik";
                case "0018": return "Ike";
                case "0019": return "Dr. Mario";
                case "001A": return "Wario";
                case "001B": return "Ganondorf";
                case "001C": return "Falco";
                case "001D": return "Zero Suit Samus";
                case "001E": return "Olimar";
                case "001F": return "Palutena";
                case "0020": return "Dark Pit";
                case "0021": return "Mii Brawler";
                case "0022": return "Mii Swordfighter";
                case "0023": return "Mii Gunner";
                case "0024": return "Charizard";
                case "0025": return "Greninja";
                case "0026": return "Jigglypuff";
                case "0027": return "Meta Knight";
                case "0028": return "King Dedede";
                case "0029": return "Lucina";
                case "002A": return "Robin";
                case "002B": return "Shulk";
                case "002C": return "Ness";
                case "002D": return "Mr. Game & Watch";
                case "002E": return "R.O.B (Famicom)";
                case "002F": return "Duck Hunt";
                case "0030": return "Sonic";
                case "0031": return "Mega Man";
                case "0032": return "Pac-Man";
                case "0033": return "R.O.B. (NES)";
                case "0034": return "Mario";
                case "0035": return "Luigi";
                case "0036": return "Peach";
                case "0037": return "Yoshi";
                case "0038": return "Toad";
                case "0039": return "Bowser";
                case "003A": return "Chibi Robo";
                case "003C": return "Mario - Gold Edition";
                case "003D": return "Mario - Silver Editon";
                case "003E": return "Inkling Girl";
                case "003F": return "Inkling Boy";
                case "0040": return "Inkling Squid";
                case "0041": return "Green Yarn Yoshi";
                case "0042": return "Pink Yarn Yoshi";
                case "0043": return "Light Blue Yarn Yoshi";
                case "0044": return "Isabelle";
                case "0045": return "Tom Nook";
                case "0046": return "DJ KK";
                case "0047": return "Sable";
                case "0048": return "Kapp'n";
                case "0049": return "Resetti";
                case "004A": return "Joan";
                case "004B": return "Timmy";
                case "004C": return "Digby";
                case "004D": return "Pascal";
                case "004E": return "Harriet";
                case "004F": return "Redd";
                case "0050": return "Sahara";
                case "0051": return "Luna";
                case "0052": return "Tortimer";
                case "0053": return "Lyle";
                case "0054": return "Lottie";
                case "0055": return "Bob";
                case "0056": return "Fauna";
                case "0057": return "Curt";
                case "0058": return "Portia";
                case "0059": return "Leonardo";
                case "005A": return "Cheri";
                case "005B": return "Kyle";
                case "005C": return "Al";
                case "005D": return "Renée";
                case "005E": return "Lopez";
                case "005F": return "Jambette";
                case "0060": return "Rasher";
                case "0061": return "Tiffany";
                case "0062": return "Sheldon";
                case "0063": return "Bluebear";
                case "0064": return "Bill";
                case "0065": return "Kiki";
                case "0066": return "Deli";
                case "0067": return "Alli";
                case "0068": return "Kabuki";
                case "0069": return "Patty";
                case "006A": return "Jitters";
                case "006B": return "Gigi";
                case "006C": return "Quillson";
                case "006D": return "Marcie";
                case "006E": return "Puck";
                case "006F": return "Shari";
                case "0070": return "Octavian";
                case "0071": return "Winnie";
                case "0072": return "Knox";
                case "0073": return "Sterling";
                case "0074": return "Bonbon";
                case "0075": return "Punchy";
                case "0076": return "Opal";
                case "0077": return "Poppy";
                case "0078": return "Limberg";
                case "0079": return "Deena";
                case "007A": return "Snake";
                case "007B": return "Bangle";
                case "007C": return "Phil";
                case "007D": return "Monique";
                case "007E": return "Nate";
                case "007F": return "Samson";
                case "0080": return "Tutu";
                case "0081": return "T-Bone";
                case "0082": return "Mint";
                case "0083": return "Pudge";
                case "0084": return "Midge";
                case "0085": return "Gruff";
                case "0086": return "Flurry";
                case "0087": return "Clyde";
                case "0088": return "Bella";
                case "0089": return "Biff";
                case "008A": return "Yuka";
                case "008B": return "Lionel";
                case "008C": return "Flo";
                case "008D": return "Cobb";
                case "008E": return "Amelia";
                case "008F": return "Jeremiah";
                case "0090": return "Cherry";
                case "0091": return "Rosco";
                case "0092": return "Truffles";
                case "0093": return "Eugene";
                case "0094": return "Eunice";
                case "0095": return "Goose";
                case "0096": return "Annalisa";
                case "0097": return "Benjamin";
                case "0098": return "Pancetti";
                case "0099": return "Chief";
                case "009A": return "Bunnie";
                case "009B": return "Clay";
                case "009C": return "Diana";
                case "009D": return "Axel";
                case "009E": return "Muffy";
                case "009F": return "Henry";
                case "00A0": return "Bertha";
                case "00A1": return "Cyrano";
                case "00A2": return "Peanut";
                case "00A3": return "Cole";
                case "00A4": return "Willow";
                case "00A5": return "Roald";
                case "00A6": return "Molly";
                case "00A7": return "Walker";
                case "00A8": return "K.K. Slider";
                case "00A9": return "Reese";
                case "00AA": return "Kicks";
                case "00AB": return "Labelle";
                case "00AC": return "Copper";
                case "00AD": return "Booker";
                case "00AE": return "Katie";
                case "00AF": return "Tommy";
                case "00B0": return "Porter";
                case "00B1": return "Lelia";
                case "00B2": return "Dr. Shrunk";
                case "00B3": return "Don Resetti";
                case "00B4": return "Isabelle (Aut)";
                case "00B5": return "Blanca";
                case "00B6": return "Nat";
                case "00B7": return "Chip";
                case "00B8": return "Jack";
                case "00B9": return "Poncho";
                case "00BA": return "Felicity";
                case "00BB": return "Ozzie";
                case "00BC": return "Tia";
                case "00BD": return "Lucha";
                case "00BE": return "Fuchsia";
                case "00BF": return "Harry";
                case "00C0": return "Gwen";
                case "00C1": return "Coach";
                case "00C2": return "Kitt";
                case "00C3": return "Tom";
                case "00C4": return "Tipper";
                case "00C5": return "Prince";
                case "00C6": return "Pate";
                case "00C7": return "Vladimir";
                case "00C8": return "Savannah";
                case "00C9": return "Kidd";
                case "00CA": return "Phoebe";
                case "00CB": return "Egbert";
                case "00CC": return "Cookie";
                case "00CD": return "Sly";
                case "00CE": return "Blaire";
                case "00CF": return "Avery";
                case "00D0": return "Nana";
                case "00D1": return "Peck";
                case "00D2": return "Olivia";
                case "00D3": return "Cesar";
                case "00D4": return "Carmen";
                case "00D5": return "Rodney";
                case "00D6": return "Scoot";
                case "00D7": return "Whitney";
                case "00D8": return "Broccolo";
                case "00D9": return "Coco";
                case "00DA": return "Groucho";
                case "00DB": return "Wendy";
                case "00DC": return "Alfonso";
                case "00DD": return "Rhonda";
                case "00DE": return "Butch";
                case "00DF": return "Gabi";
                case "00E0": return "Moose";
                case "00E1": return "Timbra";
                case "00E2": return "Zell";
                case "00E3": return "Pekoe";
                case "00E4": return "Teddy";
                case "00E5": return "Mathilda";
                case "00E6": return "Ed";
                case "00E7": return "Bianca";
                case "00E8": return "Filbert";
                case "00E9": return "Kitty";
                case "00EA": return "Beau";
                case "00EB": return "Nan";
                case "00EC": return "Bud";
                case "00ED": return "Ruby";
                case "00EE": return "Benedict";
                case "00EF": return "Agnes";
                case "00F0": return "Julian";
                case "00F1": return "Bettina";
                case "00F2": return "Jay";
                case "00F3": return "Sprinkle";
                case "00F4": return "Flip";
                case "00F5": return "Hugh";
                case "00F6": return "Hopper";
                case "00F7": return "Pecan";
                case "00F8": return "Drake";
                case "00F9": return "Alice";
                case "00FA": return "Camofrog";
                case "00FB": return "Anicotti";
                case "00FC": return "Chops";
                case "00FD": return "Charlise";
                case "00FE": return "Vic";
                case "00FF": return "Ankha";
                case "0100": return "Drift";
                case "0101": return "Vesta";
                case "0102": return "Marcel";
                case "0103": return "Pango";
                case "0104": return "Keaton";
                case "0105": return "Gladys";
                case "0106": return "Hamphrey";
                case "0107": return "Freya";
                case "0108": return "Kid Cat";
                case "0109": return "Agent S";
                case "010A": return "Big Top";
                case "010B": return "Rocket";
                case "010C": return "Rover";
                case "010D": return "Blathers";
                case "010E": return "Tom Nook";
                case "010F": return "Pelly";
                case "0110": return "Phyllis";
                case "0111": return "Pete";
                case "0112": return "Mabel";
                case "0113": return "Leif";
                case "0114": return "Wendell";
                case "0115": return "Cyrus";
                case "0116": return "Grams";
                case "0117": return "Timmy";
                case "0118": return "Digby";
                case "0119": return "Don Resetti";
                case "011A": return "Isabelle";
                case "011B": return "Franklin";
                case "011C": return "Jingle";
                case "011D": return "Lily";
                case "011E": return "Anchovy";
                case "011F": return "Tabby";
                case "0120": return "Kody";
                case "0121": return "Miranda";
                case "0122": return "Del";
                case "0123": return "Paula";
                case "0124": return "Ken";
                case "0125": return "Mitzi";
                case "0126": return "Rodeo";
                case "0127": return "Bubbles";
                case "0128": return "Cousteau";
                case "0129": return "Velma";
                case "012A": return "Elvis";
                case "012B": return "Canberra";
                case "012C": return "Colton";
                case "012D": return "Marina";
                case "012E": return "Spork-Crackle";
                case "012F": return "Freckles";
                case "0130": return "Bam";
                case "0131": return "Friga";
                case "0132": return "Ricky";
                case "0133": return "Deirdre";
                case "0134": return "Hans";
                case "0135": return "Chevre";
                case "0136": return "Drago";
                case "0137": return "Tangy";
                case "0138": return "Mac";
                case "0139": return "Eloise";
                case "013A": return "Wart Jr.";
                case "013B": return "Hazel";
                case "013C": return "Beardo";
                case "013D": return "Ava";
                case "013E": return "Chester";
                case "013F": return "Merry";
                case "0140": return "Genji";
                case "0141": return "Greta";
                case "0142": return "Wolfgang";
                case "0143": return "Diva";
                case "0144": return "Klaus";
                case "0145": return "Daisy";
                case "0146": return "Stinky";
                case "0147": return "Tammi";
                case "0148": return "Tucker";
                case "0149": return "Blanche";
                case "014A": return "Gaston";
                case "014B": return "Marshal";
                case "014C": return "Gala";
                case "014D": return "Joey";
                case "014E": return "Pippy";
                case "014F": return "Buck";
                case "0150": return "Bree";
                case "0151": return "Rooney";
                case "0152": return "Curlos";
                case "0153": return "Skye";
                case "0154": return "Moe";
                case "0155": return "Flora";
                case "0156": return "Hamlet";
                case "0157": return "Astrid";
                case "0158": return "Monty";
                case "0159": return "Dora";
                case "015A": return "Biskit";
                case "015B": return "Victoria";
                case "015C": return "Lyman";
                case "015D": return "Violet";
                case "015E": return "Frank";
                case "015F": return "Chadder";
                case "0160": return "Merengue";
                case "0161": return "Cube";
                case "0162": return "Claudia";
                case "0163": return "Curly";
                case "0164": return "Boomer";
                case "0165": return "Caroline";
                case "0166": return "Sparro";
                case "0167": return "Baabara";
                case "0168": return "Rolf";
                case "0169": return "Maple";
                case "016A": return "Antonio";
                case "016B": return "Soleil";
                case "016C": return "Apollo";
                case "016D": return "Derwin";
                case "016E": return "Francine";
                case "016F": return "Chrissy";
                case "0170": return "Isabelle";
                case "0171": return "Brewster";
                case "0172": return "Katrina";
                case "0173": return "Phineas";
                case "0174": return "Celeste";
                case "0175": return "Tommy";
                case "0176": return "Gracie";
                case "0177": return "Leilani";
                case "0178": return "Resetti";
                case "0179": return "Timmy";
                case "017A": return "Lottie";
                case "017B": return "Shrunk";
                case "017C": return "Pave";
                case "017D": return "Gulliver";
                case "017E": return "Redd";
                case "017F": return "Zipper";
                case "0180": return "Goldie";
                case "0181": return "Stitches";
                case "0182": return "Pinky";
                case "0183": return "Mott";
                case "0184": return "Mallary";
                case "0185": return "Rocco";
                case "0186": return "Katt";
                case "0187": return "Graham";
                case "0188": return "Peaches";
                case "0189": return "Dizzy";
                case "018A": return "Penelope";
                case "018B": return "Boone";
                case "018C": return "Broffina";
                case "018D": return "Croque";
                case "018E": return "Pashmina";
                case "018F": return "Shep";
                case "0190": return "Lolly";
                case "0191": return "Erik";
                case "0192": return "Dotty";
                case "0193": return "Pierce";
                case "0194": return "Queenie";
                case "0195": return "Fang";
                case "0196": return "Frita";
                case "0197": return "Tex";
                case "0198": return "Melba";
                case "0199": return "Bones";
                case "019A": return "Anabelle";
                case "019B": return "Rudy";
                case "019C": return "Naomi";
                case "019D": return "Peewee";
                case "019E": return "Tammy";
                case "019F": return "Olaf";
                case "01A0": return "Lucy";
                case "01A1": return "Elmer";
                case "01A2": return "Puddles";
                case "01A3": return "Rory";
                case "01A4": return "Elise";
                case "01A5": return "Walt";
                case "01A6": return "Mira";
                case "01A7": return "Pietro";
                case "01A8": return "Aurora";
                case "01A9": return "Papi";
                case "01AA": return "Apple";
                case "01AB": return "Rod";
                case "01AC": return "Purrl";
                case "01AD": return "Static";
                case "01AE": return "Celia";
                case "01AF": return "Zucker";
                case "01B0": return "Peggy";
                case "01B1": return "Ribbot";
                case "01B2": return "Annalise";
                case "01B3": return "Chow";
                case "01B4": return "Sylvia";
                case "01B5": return "Jacques";
                case "01B6": return "Sally";
                case "01B7": return "Doc";
                case "01B8": return "Pompom";
                case "01B9": return "Tank";
                case "01BA": return "Becky";
                case "01BB": return "Rizzo";
                case "01BC": return "Sydney";
                case "01BD": return "Barold";
                case "01BE": return "Nibbles";
                case "01BF": return "Kevin";
                case "01C0": return "Gloria";
                case "01C1": return "Lobo";
                case "01C2": return "Hippeux";
                case "01C3": return "Margie";
                case "01C4": return "Lucky";
                case "01C5": return "Rosie";
                case "01C6": return "Rowan";
                case "01C7": return "Maelle";
                case "01C8": return "Bruce";
                case "01C9": return "OHare";
                case "01CA": return "Gayle";
                case "01CB": return "Cranston";
                case "01CC": return "Frobert";
                case "01CD": return "Grizzly";
                case "01CE": return "Cally";
                case "01CF": return "Simon";
                case "01D0": return "Iggly";
                case "01D1": return "Angus";
                case "01D2": return "Twiggy";
                case "01D3": return "Robin";
                case "01D4": return "Isabelle";
                case "01D5": return "Goldie";
                case "01D6": return "Stitches";
                case "01D7": return "Rosie";
                case "01D8": return "K. K. Slider";
                case "0238": return "8-Bit Mario Classic Color";
                case "0239": return "8-Bit Mario Modern Color";
                case "023A": return "Hammer Slam Bowser";
                case "023B": return "Turbo Charge Donkey Kong";
                case "023D": return "Mewtwo";
                case "023E": return "Mega Yarn Yoshi";
                case "023F": return "Isabelle";
                case "0240": return "K. K. Slider";
                case "0241": return "Mabel";
                case "0242": return "Tom Nook";
                case "0243": return "Digby";
                case "0244": return "Lottie";
                case "0245": return "Reese";
                case "0246": return "Cyrus";
                case "0247": return "Blathers";
                case "0248": return "Celeste";
                case "0249": return "Resetti";
                case "024A": return "Kicks";
                case "024B": return "Isabelle - Summer Outfit";
                case "024C": return "Rover";
                case "024D": return "Timmy & Tommy";
                case "024E": return "Kapp'n";
                case "024F": return "Midna & Wolf Link";
                case "0250": return "Shovel Knight";
                case "0251": return "Lucas";
                case "0252": return "Roy";
                case "0253": return "Ryu";
                case "0254": return "Kirby";
                case "0255": return "Meta Knight";
                case "0256": return "King Dedede";
                case "0257": return "Waddle Dee";
                case "0258": return "Mega Man (Gold Edition)";
                case "0259": return "Cloud";
                case "025A": return "Corrin";
                case "025B": return "Bayonetta";
                case "025C": return "Shadow Mewtwo";
                case "025D": return "Callie";
                case "025E": return "Marie";
                case "025F": return "Inkling Girl (Lime Green)";
                case "0260": return "Inkling Boy (Purple)";
                case "0261": return "Inkling Squid (Orange)";
                case "0262": return "Rosalina";
                case "0263": return "Wario";
                case "0264": return "Donkey Kong";
                case "0265": return "Diddy Kong";
                case "0266": return "Daisy";
                case "0267": return "Waluigi";
                case "0268": return "Boo";
                case "0269": return "Mario - Soccer";
                case "026A": return "Mario - Baseball";
                case "026B": return "Mario - Tennis";
                case "026C": return "Mario - Golf";
                case "026D": return "Mario - Horse Racing";
                case "026E": return "Luigi - Soccer";
                case "026F": return "Luigi - Baseball";
                case "0270": return "Luigi - Tennis";
                case "0271": return "Luigi - Golf";
                case "0272": return "Luigi - Horse Racing";
                case "0273": return "Peach - Soccer";
                case "0274": return "Peach - Baseball";
                case "0275": return "Peach - Tennis";
                case "0276": return "Peach - Golf";
                case "0277": return "Peach - Horse Racing";
                case "0278": return "Daisy - Soccer";
                case "0279": return "Daisy - Baseball";
                case "027A": return "Daisy - Tennis";
                case "027B": return "Daisy - Golf";
                case "027C": return "Daisy - Horse Racing";
                case "027D": return "Yoshi - Soccer";
                case "027E": return "Yoshi - Baseball";
                case "027F": return "Yoshi - Tennis";
                case "0280": return "Yoshi - Golf";
                case "0281": return "Yoshi - Horse Racing";
                case "0282": return "Wario - Soccer";
                case "0283": return "Wario - Baseball";
                case "0284": return "Wario - Tennis";
                case "0285": return "Wario - Golf";
                case "0286": return "Wario - Horse Racing";
                case "0287": return "Waluigi - Soccer";
                case "0288": return "Waluigi - Baseball";
                case "0289": return "Waluigi - Tennis";
                case "028A": return "Waluigi - Golf";
                case "028B": return "Waluigi - Horse Racing";
                case "028C": return "Donkey Kong - Soccer";
                case "028D": return "Donkey Kong - Baseball";
                case "028E": return "Donkey Kong - Tennis";
                case "028F": return "Donkey Kong - Golf";
                case "0290": return "Donkey Kong - Horse Racing";
                case "0291": return "Diddy Kong - Soccer";
                case "0292": return "Diddy Kong - Baseball";
                case "0293": return "Diddy Kong - Tennis";
                case "0294": return "Diddy Kong - Golf";
                case "0295": return "Diddy Kong - Horse Racing";
                case "0296": return "Bowser - Soccer";
                case "0297": return "Bowser - Baseball";
                case "0298": return "Bowser - Tennis";
                case "0299": return "Bowser - Golf";
                case "029A": return "Bowser - Horse Racing";
                case "029B": return "Bowser Jr. - Soccer";
                case "029C": return "Bowser Jr. - Baseball";
                case "029D": return "Bowser Jr. - Tennis";
                case "029E": return "Bowser Jr. - Golf";
                case "029F": return "Bowser Jr. - Horse Racing";
                case "02A0": return "Boo - Soccer";
                case "02A1": return "Boo - Baseball";
                case "02A2": return "Boo - Tennis";
                case "02A3": return "Boo - Golf";
                case "02A4": return "Boo - Horse Racing";
                case "02A5": return "Baby Mario - Soccer";
                case "02A6": return "Baby Mario - Baseball";
                case "02A7": return "Baby Mario - Tennis";
                case "02A8": return "Baby Mario - Golf";
                case "02A9": return "Baby Mario - Horse Racing";
                case "02AA": return "Baby Luigi - Soccer";
                case "02AB": return "Baby Luigi - Baseball";
                case "02AC": return "Baby Luigi - Tennis";
                case "02AD": return "Baby Luigi - Golf";
                case "02AE": return "Baby Luigi - Horse Racing";
                case "02AF": return "Birdo - Soccer";
                case "02B0": return "Birdo - Baseball";
                case "02B1": return "Birdo - Tennis";
                case "02B2": return "Birdo - Golf";
                case "02B3": return "Birdo - Horse Racing";
                case "02B4": return "Rosalina - Soccer";
                case "02B5": return "Rosalina - Baseball";
                case "02B6": return "Rosalina - Tennis";
                case "02B7": return "Rosalina - Golf";
                case "02B8": return "Rosalina - Horse Racing";
                case "02B9": return "Metal Mario - Soccer";
                case "02BA": return "Metal Mario - Baseball";
                case "02BB": return "Metal Mario - Tennis";
                case "02BC": return "Metal Mario - Golf";
                case "02BD": return "Metal Mario - Horse Racing";
                case "02BE": return "Pink Gold Peach - Soccer";
                case "02BF": return "Pink Gold Peach - Baseball";
                case "02C0": return "Pink Gold Peach - Tennis";
                case "02C1": return "Pink Gold Peach - Golf";
                case "02C2": return "Pink Gold Peach - Horse Racing";
                case "02E1": return "One-Eyed Rathalos and Rider (Male)";
                case "02E2": return "One-Eyed Rathalos and Rider (Female)";
                case "02E3": return "Nabiru";
                case "02E4": return "Rathian and Cheval";
                case "02E5": return "Barioth and Ayuria";
                case "02E6": return "Qurupeco and Dan";
                case "02E7": return "Vivian";
                case "02E8": return "Hopkins";
                case "02E9": return "June";
                case "02EA": return "Piper";
                case "02EB": return "Paolo";
                case "02EC": return "Hornsby";
                case "02ED": return "Stella";
                case "02EE": return "Tybalt";
                case "02EF": return "Huck";
                case "02F0": return "Sylvana";
                case "02F1": return "Boris";
                case "02F2": return "Wade";
                case "02F3": return "Carrie";
                case "02F4": return "Ketchup";
                case "02F5": return "Rex";
                case "02F6": return "Stu";
                case "02F7": return "Ursala";
                case "02F8": return "Jacob";
                case "02F9": return "Maddie";
                case "02FA": return "Billy";
                case "02FB": return "Boyd";
                case "02FC": return "Bitty";
                case "02FD": return "Maggie";
                case "02FE": return "Murphy";
                case "02FF": return "Plucky";
                case "0300": return "Sandy";
                case "0301": return "Claude";
                case "0302": return "Raddle";
                case "0303": return "Julia";
                case "0304": return "Louie";
                case "0305": return "Bea";
                case "0306": return "Admiral";
                case "0307": return "Ellie";
                case "0308": return "Boots";
                case "0309": return "Weber";
                case "030A": return "Candi";
                case "030B": return "Leopold";
                case "030C": return "Spike";
                case "030D": return "Cashmere";
                case "030E": return "Tad";
                case "030F": return "Norma";
                case "0310": return "Gonzo";
                case "0311": return "Sprocket";
                case "0312": return "Snooty";
                case "0313": return "Olive";
                case "0314": return "Dobie";
                case "0315": return "Buzz";
                case "0316": return "Cleo";
                case "0317": return "Ike";
                case "0318": return "Tasha";
                case "0319": return "Rilla";
                case "031A": return "Marty";
                case "031B": return "Étoile";
                case "031C": return "Chai";
                case "031D": return "Chelsea";
                case "031E": return "Toby";
                case "034B": return "Link - Ocarina of Time";
                case "034C": return "Link - Majora's Mask";
                case "034D": return "Link - Twilight Princess";
                case "034E": return "Link - Skyward Sword";
                case "034F": return "8- Bit Link";
                case "0350": return "Toon Link - The Wind Waker";
                case "0352": return "Toon Zelda - The Wind Waker";
                case "0353": return "Link (Archer)";
                case "0354": return "Link (Rider)";
                case "0355": return "Guardian";
                case "0356": return "Zelda";
                case "0358": return "Daruk(Goron Champion)";
                case "0359": return "Urbosa(Gerudo Champion)";
                case "035A": return "Mipha(Zora Champion)";
                case "035B": return "Revali(Rito Champion)";
                case "035C": return "Bokoblin";
                case "035D": return "Poochy";
                case "035E": return "Qbby";
                case "035F": return "Pikmin";
                case "0360": return "Alm";
                case "0361": return "Celica";
                case "0362": return "Cloud (Player 2)";
                case "0363": return "Corrin (Player 2)";
                case "0364": return "Bayonetta (Player 2)";
                case "0365": return "Samus Aran";
                case "0366": return "Metroid";
                case "0367": return "Goomba";
                case "0368": return "Koopa Troopa";
                case "0369": return "Inkling Girl (Neon Pink)";
                case "036A": return "Inkling Boy (Neon Green)";
                case "036B": return "Inkling Squid (Neon Purple)";
                case "036F": return "Chrom";
                case "0370": return "Tiki";
                case "0371": return "Mario(Wedding)";
                case "0372": return "Peach(Wedding)";
                case "0373": return "Bowser(Wedding)";
                case "0374": return "Super Mario Cereal";
                default: return "";
            }
        }

        #endregion

        #endregion

        #region NTAG215

        /*
        NTAG215
        ISO:14443-3
        ID:0x00,0x01,0x02,0x04,0x05,0x06,0x07
        ATQA:
        SAK:
        -------------000--------------
        0x00:UID0
        0x01:UID1
        0x02:UID2
        0x03:BCC0
        0x04:UID3
        0x05:UID4
        0x06:UID5
        0x07:UID6
        0x08:BCC1
        0x09:INT
        0x0A:LOCK0
        0x0B:LOCK1
        0x0C:OTP0
        0x0D:OTP1
        0x0E:OTP2
        0x0F:OTP3
        0x10~0x207:数据（0x1F8=504）
        0x208:LOCK2
        0x209:LOCK3
        0x20A:LOCK4
        0x20B:CHK
        0x20C~0x20E:CFG,MIRROR,AUTHO
        0x20F:
        0x210~0x211:ACCESS
        0x212:--
        0x213:--
        -------------532--------------
        0x214:PWD0
        0x215:PWD1
        0x216:PWD2
        0x217:PWD3
        0x218:PACK0
        0x219:PACK1
        0x21A:--
        0x21B:--
        -------------540--------------

    */

        #endregion

        internal static byte[] key_retail =
{
            #region key_retail.bin数据
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
            #endregion
        };

    }
    }
