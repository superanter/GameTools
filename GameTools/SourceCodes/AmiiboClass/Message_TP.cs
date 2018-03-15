using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnterStudio.GameTools.AmiiboClass
{
    //Code From TagMo

    class Message_TP
    {
        private static int OFFSET_APP_DATA = 0xED;

        private static int OFFSET_LEVEL = OFFSET_APP_DATA;
        private static int OFFSET_HEARTS = OFFSET_APP_DATA + 0x01;

        private string[] TpHearts = new string[81]
        {
            "0(Dead!?)","0+¼","0+½","0+¾","1","1+¼","1+½","1+¾","2","2+¼",
            "2+½","2+¾","3","3+¼","3+½","3+¾","4","4+¼","4+½","4+¾",
            "5","5+¼","5+½","5+¾","6","6+¼","6+½","6+¾","7","7+¼",
            "7+½","7+¾","8","8+¼","8+½","8+¾","9","9+¼","9+½","9+¾",
            "10","10+¼","10+½","10+¾","11","11+¼","11+½","11+¾","12","12+¼",
            "12+½","12+¾","13","13+¼","13+½","13+¾","14","14+¼","14+½","14+¾",
            "15","15+¼","15+½","15+¾","16","16+¼","16+½","16+¾","17","17+¼",
            "17+½","17+¾","18","18+¼","18+½","18+¾","19","19+¼","19+½","19+¾",
            "20"
        };

        private string[] TpLevers = new string[41]
{
            "0","1","2","3","4","5 (Run 1 completed)","6","7","8","9",
            "10","11","12","13","14","15","16","17","18","19",
            "20 (Run 2 completed)","21","22","23","24","25","26","27","28","29",
            "30","31","32","33","34","35","36","37","38","39",
            "40 (completed)"
};
        //public int APP_DATA = new int();
        public int LEVEL = new int();
        public int HEARTS = new int();
        public string[] myMessage;
        public bool canEdit;

        public Message_TP()
        {
            throw new System.NotImplementedException();
        }

        public Message_TP(byte[] date, Message_NFC msgNFC)
        {
            if(msgNFC.NFC_ID.Remove(8) == "01030000" && msgNFC.Amiibo_AppID == "1019C800")
            {
                canEdit = true;
                //APP_DATA = (int)date[OFFSET_APP_DATA];
                LEVEL = (int)date[OFFSET_LEVEL];
                HEARTS = (int)date[OFFSET_HEARTS];
                myMessage = GetMessage();
            }
            else
            {
                canEdit = false;
                //APP_DATA = 0;
                LEVEL = 0;
                HEARTS = 0;
                myMessage = new string[0];
            }
        }

        public string[] GetMessage()
        {
            string[] tempMessage = new string[2];
            //tempMessage[0] = "APP_DATA: " + this.APP_DATA + "\n";
            //tempMessage[1] = "LEVEL: " + this.LEVEL + LevelMessage + "\n";
            tempMessage[0] = "LEVEL: " + this.TpLevers[this.LEVEL]+ "\n";
            //tempMessage[2] = "HEARTS: " + (((float)(this.HEARTS * 25)) / 100).ToString() + "\n";
            tempMessage[1] = "HEARTS: " + this.TpHearts[this.HEARTS] + "\n";

            return tempMessage;
        }


    }
}
