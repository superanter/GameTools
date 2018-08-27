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

        public string[] TpHearts = new string[81]
        {
            "0(Dead!?)","0+(1/4)","0+(1/2)","0+(3/4)","1","1+(1/4)","1+(1/2)","1+(3/4)","2","2+(1/4)",
            "2+(1/2)","2+(3/4)","3","3+(1/4)","3+(1/2)","3+(3/4)","4","4+(1/4)","4+(1/2)","4+(3/4)",
            "5","5+(1/4)","5+(1/2)","5+(3/4)","6","6+(1/4)","6+(1/2)","6+(3/4)","7","7+(1/4)",
            "7+(1/2)","7+(3/4)","8","8+(1/4)","8+(1/2)","8+(3/4)","9","9+(1/4)","9+(1/2)","9+(3/4)",
            "10","10+(1/4)","10+(1/2)","10+(3/4)","11","11+(1/4)","11+(1/2)","11+(3/4)","12","12+(1/4)",
            "12+(1/2)","12+(3/4)","13","13+(1/4)","13+(1/2)","13+(3/4)","14","14+(1/4)","14+(1/2)","14+(3/4)",
            "15","15+(1/4)","15+(1/2)","15+(3/4)","16","16+(1/4)","16+(1/2)","16+(3/4)","17","17+(1/4)",
            "17+(1/2)","17+(3/4)","18","18+(1/4)","18+(1/2)","18+(3/4)","19","19+(1/4)","19+(1/2)","19+(3/4)",
            "20"
        };

        public string[] TpLevers = new string[41]
        {
            "0","1","2","3","4","5 (Run 1 completed)","6","7","8","9",
            "10","11","12","13","14","15","16","17","18","19",
            "20 (Run 2 completed)","21","22","23","24","25","26","27","28","29",
            "30","31","32","33","34","35","36","37","38","39",
            "40 (completed)"
        };

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
                LEVEL = (int)date[OFFSET_LEVEL];
                HEARTS = (int)date[OFFSET_HEARTS];
                myMessage = GetMessage();
            }
            else
            {
                canEdit = false;
                LEVEL = 0;
                HEARTS = 0;
                myMessage = new string[0];
            }
        }

        public string[] GetMessage()
        {
            string[] tempMessage = new string[2];
            tempMessage[0] = "LEVEL: " + this.TpLevers[this.LEVEL] + "\n";
            tempMessage[1] = "HEARTS: " + this.TpHearts[this.HEARTS] + "\n";
            return tempMessage;
        }


    }
}
