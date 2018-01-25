using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TagMo
{
    class EditorTP
    {
        private static int OFFSET_APP_DATA = 0xED;

        private static int OFFSET_LEVEL = OFFSET_APP_DATA;
        private static int OFFSET_HEARTS = OFFSET_APP_DATA + 0x01;

        public int APP_DATA = new int();
        public int LEVEL = new int();
        public int HEARTS = new int();

        public EditorTP()
        {
            throw new System.NotImplementedException();
        }

        public EditorTP(byte[] date)
        {
            APP_DATA = (int)date[OFFSET_APP_DATA];
            LEVEL = (int)date[OFFSET_LEVEL];
            HEARTS = (int)date[OFFSET_HEARTS];
        }
    }
}
