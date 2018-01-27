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

        public int APP_DATA = new int();
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
                APP_DATA = (int)date[OFFSET_APP_DATA];
                LEVEL = (int)date[OFFSET_LEVEL];
                HEARTS = (int)date[OFFSET_HEARTS];
                myMessage = GetMessage();
            }
            else
            {
                canEdit = false;
                APP_DATA = 0;
                LEVEL = 0;
                HEARTS = 0;
                myMessage = new string[0];
            }
        }

        public string[] GetMessage()
        {
            string LevelMessage = "";
            if (this.LEVEL == 5)
            {
                LevelMessage = " (Run 1 completed)";
            }
            else if (this.LEVEL == 20)
            {
                LevelMessage = " (Run 2 completed)";
            }
            else if (this.LEVEL == 40)
            {
                LevelMessage = " (completed)";
            }
            string[] tempMessage = new string[3];
            tempMessage[0] = "APP_DATA: " + this.APP_DATA + "\n";
            tempMessage[1] = "LEVEL: " + this.LEVEL + LevelMessage + "\n";
            tempMessage[2] = "HEARTS: " + (((float)(this.HEARTS * 25)) / 100).ToString() + "\n";



            return tempMessage;
        }
    }
}
