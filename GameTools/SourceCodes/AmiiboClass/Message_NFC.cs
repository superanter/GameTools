using System;
using System.Collections.Generic;
using System.Text;

namespace AnterStudio.GameTools.AmiiboClass
{
    //Code from AmiiBomb

    class Message_NFC
    {
        public string NFC_ID { get; }
        public string Character_ID { get; }
        public string GameSeries_ID { get; }
        public string Amiibo_Nickname { get; }
        public string Amiibo_Mii_Nickname { get; }
        public string Amiibo_Write_Counter { get; }
        public string Amiibo_AppID { get; }
        public string Amiibo_Initialized_AppID { get; }
        public string Amiibo_Country { get; }
        public int Amiibo_Initialize_UserData { get; }
        public string Amiibo_LastModifiedDate { get; }

        #region 构造函数
        public Message_NFC()
        {
            throw new System.NotImplementedException();
        }

        public Message_NFC(byte[] AmiiboDataNew)
        {
            this.NFC_ID = this.Get_NFC_ID(AmiiboDataNew);
            this.Character_ID = this.Get_Character_ID(AmiiboDataNew);
            this.GameSeries_ID = this.Get_GameSeries_ID(AmiiboDataNew);

            this.Amiibo_Nickname = this.Get_Amiibo_Nickname(AmiiboDataNew);
            this.Amiibo_Mii_Nickname = this.Get_Amiibo_Mii_Nickname(AmiiboDataNew);
            this.Amiibo_Write_Counter = this.Get_Amiibo_Write_Counter(AmiiboDataNew);
            this.Amiibo_AppID = this.Get_Amiibo_AppID(AmiiboDataNew);
            this.Amiibo_Initialized_AppID = this.Get_Amiibo_Initialized_AppID(AmiiboDataNew);
            this.Amiibo_Country = this.Get_Amiibo_Country(AmiiboDataNew);
            this.Amiibo_Initialize_UserData = this.Get_Amiibo_Initialize_UserData(AmiiboDataNew);
            this.Amiibo_LastModifiedDate = this.Get_Amiibo_LastModifiedDate(AmiiboDataNew);

        }
        #endregion

        #region 程序

        private string Get_NFC_ID(byte[] internalTag)
        {
            return String.Format("{0:X2}{1:X2}{2:X2}{3:X2}-{4:X2}{5:X2}{6:X2}{7:X2}",
                    internalTag[0x1DC], internalTag[0x1DD], internalTag[0x1DE], internalTag[0x1DF], internalTag[0x1E0], internalTag[0x1E1], internalTag[0x1E2], internalTag[0x1E3]);
        }

        private string Get_Character_ID(byte[] internalTag)
        {
            return String.Format("{0:X2}{1:X2}", internalTag[0x1E0], internalTag[0x1E1]);
        }

        private string Get_GameSeries_ID(byte[] internalTag)
        {
            return String.Format("{0:X2}{1:X2}{2:X2}", internalTag[0x1DC], internalTag[0x1DD], internalTag[0x1DE]).Substring(0, 3);
        }

        //Need to fix strange size of Nickname and owner of 0xF instead of 0x14!!

        private string Get_Amiibo_Nickname(byte[] internalTag)
        {
            byte[] Amiibo_Nickname_Buffer = new byte[0x14];
            Array.Copy(internalTag, 0x02C + 0x0C, Amiibo_Nickname_Buffer, 0x000, Amiibo_Nickname_Buffer.Length);

            return Encoding.BigEndianUnicode.GetString(Amiibo_Nickname_Buffer);
        }

        private string Get_Amiibo_Mii_Nickname(byte[] internalTag)
        {
            byte[] Amiibo_Mii_Nickname_Buffer = new byte[0x14];
            Array.Copy(internalTag, 0x02C + 0x020 + 0x01A, Amiibo_Mii_Nickname_Buffer, 0x000, Amiibo_Mii_Nickname_Buffer.Length);

            return Encoding.Unicode.GetString(Amiibo_Mii_Nickname_Buffer);
        }

        private string Get_Amiibo_Write_Counter(byte[] internalTag)
        {
            byte[] Amiibo_Write_Counter = new byte[0x02];
            Array.Copy(internalTag, 0x02C + 0x088, Amiibo_Write_Counter, 0x000, Amiibo_Write_Counter.Length);
            Array.Reverse(Amiibo_Write_Counter);

            return BitConverter.ToInt16(Amiibo_Write_Counter, 0).ToString();
        }

        private string Get_Amiibo_AppID(byte[] internalTag)
        {
            byte[] Amiibo_AppID = new byte[0x04];
            Array.Copy(internalTag, 0x02C + 0x08A, Amiibo_AppID, 0x000, Amiibo_AppID.Length);

            return BitConverter.ToString(Amiibo_AppID).Replace("-", "");
        }

        private string Get_Amiibo_Initialized_AppID(byte[] internalTag)
        {
            byte[] Amiibo_Initialized_AppID = new byte[0x08];
            Array.Copy(internalTag, 0x02C + 0x080, Amiibo_Initialized_AppID, 0x000, Amiibo_Initialized_AppID.Length);
            string AppID = BitConverter.ToString(Amiibo_Initialized_AppID).Replace("-", "");
            return AppID.Substring(0, 8) + "-" + AppID.Substring(8, 8);
        }

        private string Get_Amiibo_Country(byte[] internalTag)
        {
            byte[] Amiibo_CountryCode = new byte[0x01];
            Array.Copy(internalTag, 0x02C + 0x001, Amiibo_CountryCode, 0x000, Amiibo_CountryCode.Length);

            return Get_Country_Name(Amiibo_CountryCode[0]);
        }

        private int Get_Amiibo_Initialize_UserData(byte[] internalTag)
        {
            byte[] Amiibo_Initialize = new byte[0x01];
            Array.Copy(internalTag, 0x02C, Amiibo_Initialize, 0x000, Amiibo_Initialize.Length);

            return Amiibo_Initialize[0] & 0x30;
        }

        private string Get_Amiibo_LastModifiedDate(byte[] internalTag)
        {
            var Amiibo_Date_Buffer = new byte[0x02];
            Array.Copy(internalTag, 0x02C + 0x006, Amiibo_Date_Buffer, 0x000, Amiibo_Date_Buffer.Length);
            Array.Reverse(Amiibo_Date_Buffer);
            int value = BitConverter.ToUInt16(Amiibo_Date_Buffer, 0);
            DateTime myDT = new DateTime(1900, 1, 1);
            try
            {
                var day = value & 0x1F;
                var month = (value >> 5) & 0x0F;
                var year = (value >> 9) & 0x7F;
                myDT = new DateTime(2000 + year, month, day);
            }
            catch { }

            return myDT.ToShortDateString();
        }

        private string Get_Country_Name(int ID)
        {
            string Name;
            if (Country_Dictionary.TryGetValue(ID, out Name)) return Name;

            return "Unknown ID: " + ID.ToString();
        }

        #endregion

        #region Country_Dictionary

        private static Dictionary<int, string> Country_Dictionary = new Dictionary<int, string>
        {
            //http://wiibrew.org/wiki/Country_Codes

            //Japan:
            { 1,   "Japan" },

            //Americas:
            { 8,   "Anguilla" },
            { 9,   "Antigua and Barbuda" },
            { 10,   "Argentina" },
            { 11,   "Aruba" },
            { 12,   "Bahamas" },
            { 13,   "Barbados" },
            { 14,   "Belize" },
            { 15,   "Bolivia" },
            { 16,   "Brazil" },
            { 17,   "British Virgin Islands" },
            { 18,   "Canada" },
            { 19,   "Cayman Islands" },
            { 20,   "Chile" },
            { 21,   "Colombia" },
            { 22,   "Costa Rica" },
            { 23,   "Dominica" },
            { 24,   "Dominican Republic" },
            { 25,   "Ecuador" },
            { 26,   "El Salvador" },
            { 27,   "French Guiana" },
            { 28,   "Grenada" },
            { 29,   "Guadeloupe" },
            { 30,   "Guatemala" },
            { 31,   "Guyana" },
            { 32,   "Haiti" },
            { 33,   "Honduras" },
            { 34,   "Jamaica" },
            { 35,   "Martinique" },
            { 36,   "Mexico" },
            { 37,   "Monsterrat" },
            { 38,   "Netherlands Antilles" },
            { 39,   "Nicaragua" },
            { 40,   "Panama" },
            { 41,   "Paraguay" },
            { 42,   "Peru" },
            { 43,   "St. Kitts and Nevis" },
            { 44,   "St. Lucia" },
            { 45,   "St. Vincent and the Grenadines" },
            { 46,   "Suriname" },
            { 47,   "Trinidad and Tobago" },
            { 48,   "Turks and Caicos Islands" },
            { 49,   "United States" },
            { 50,   "Uruguay" },
            { 51,   "US Virgin Islands" },
            { 52,   "Venezuela" },

            //Europe:
            { 64,   "Albania" },
            { 65,   "Australia" },
            { 66,   "Austria" },
            { 67,   "Belgium" },
            { 68,   "Bosnia and Herzegovina" },
            { 69,   "Botswana" },
            { 70,   "Bulgaria" },
            { 71,   "Croatia" },
            { 72,   "Cyprus" },
            { 73,   "Czech Republic" },
            { 74,   "Denmark" },
            { 75,   "Estonia" },
            { 76,   "Finland" },
            { 77,   "France" },
            { 78,   "Germany" },
            { 79,   "Greece" },
            { 80,   "Hungary" },
            { 81,   "Iceland" },
            { 82,   "Ireland" },
            { 83,   "Italy" },
            { 84,   "Latvia" },
            { 85,   "Lesotho" },
            { 86,   "Lichtenstein" },
            { 87,   "Lithuania" },
            { 88,   "Luxembourg" },
            { 89,   "F.Y.R of Macedonia" },
            { 90,   "Malta" },
            { 91,   "Montenegro" },
            { 92,   "Mozambique" },
            { 93,   "Namibia" },
            { 94,   "Netherlands" },
            { 95,   "New Zealand" },
            { 96,   "Norway" },
            { 97,   "Poland" },
            { 98,   "Portugal" },
            { 99,   "Romania" },
            { 100,   "Russia" },
            { 101,   "Serbia" },
            { 102,   "Slovakia" },
            { 103,   "Slovenia" },
            { 104,   "South Africa" },
            { 105,   "Spain" },
            { 106,   "Swaziland" },
            { 107,   "Sweden" },
            { 108,   "Switzerland" },
            { 109,   "Turkey" },
            { 110,   "United Kingdom" },
            { 111,   "Zambia" },
            { 112,   "Zimbabwe" },
            { 113,   "Azerbaijan" },
            { 114,   "Mauritania (Islamic Republic of Mauritania)" },
            { 115,   "Mali (Republic of Mali)" },
            { 116,   "Niger (Republic of Niger)" },
            { 117,   "Chad (Republic of Chad)" },
            { 118,   "Sudan (Republic of the Sudan)" },
            { 119,   "Eritrea (State of Eritrea)" },
            { 120,   "Dijibouti (Republic of Djibouti)" },
            { 121,   "Somalia (Somali Republic)" },
            { 128,   "Taiwan" },

            //Southeast Asia:
            { 136,   "South Korea" },
            { 144,   "Hong Kong" },
            { 145,   "Macao" },
            { 152,   "Indonesia" },
            { 153,   "Singapore" },
            { 154,   "Thailand" },
            { 155,   "Philippines" },
            { 156,   "Malaysia" },
            { 160,   "China" },

            //Middle East:
            { 168,   "U.A.E." },
            { 169,   "India" },
            { 170,   "Egypt" },
            { 171,   "Oman" },
            { 172,   "Qatar" },
            { 173,   "Kuwait" },
            { 174,   "Saudi Arabia" },
            { 175,   "Syria" },
            { 176,   "Bahrain" },
            { 177,   "Jordan" }
        };
        #endregion
    }
}
