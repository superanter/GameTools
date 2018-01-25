using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TagMo
{
    class EditorSSB
    {
        private static int OFFSET_APP_DATA = 0xDC;

        private static int OFFSET_APPEARANCE = OFFSET_APP_DATA + 0x08;

        private static int OFFSET_SPECIAL_NEUTRAL = OFFSET_APP_DATA + 0x09;
        private static int OFFSET_SPECIAL_SIDE_TO_SIDE = OFFSET_APP_DATA + 0x0A;
        private static int OFFSET_SPECIAL_UP = OFFSET_APP_DATA + 0x0B;
        private static int OFFSET_SPECIAL_DOWN = OFFSET_APP_DATA + 0x0C;

        private static int OFFSET_STATS_ATTACK = OFFSET_APP_DATA + 0x10;
        private static int OFFSET_STATS_DEFENSE = OFFSET_APP_DATA + 0x12;
        private static int OFFSET_STATS_SPEED = OFFSET_APP_DATA + 0x14;

        private static int OFFSET_BONUS_EFFECT1 = OFFSET_APP_DATA + 0x0D;
        private static int OFFSET_BONUS_EFFECT2 = OFFSET_APP_DATA + 0x0E;
        private static int OFFSET_BONUS_EFFECT3 = OFFSET_APP_DATA + 0x0F;

        private static int OFFSET_LEVEL = OFFSET_APP_DATA + 0x7C;

        private static int[] LEVEL_THRESHOLDS;
        private static string[] XA;

        public int APP_DATA = new int();

        public int APPEARANCE = new int();

        public int SPECIAL_NEUTRAL = new int();
        public int SPECIAL_SIDE_TO_SIDE = new int();
        public int SPECIAL_UP = new int();
        public int SPECIAL_DOWN = new int();

        public int STATS_ATTACK = new int();
        public int STATS_DEFENSE = new int();
        public int STATS_SPEED = new int();

        public string BONUS_EFFECT1;
        public string BONUS_EFFECT2;
        public string BONUS_EFFECT3;

        public int LEVEL = new int();

        public EditorSSB()
        {
            throw new System.NotImplementedException();
        }

        public EditorSSB(byte[] data)
        {

            LEVEL_THRESHOLDS = new int[]{ 0x00, 0x08, 0x010, 0x01D, 0x02D, 0x048,
            0x05B, 0x075, 0x08D, 0x0AF, 0x0E1, 0x0103, 0x0126, 0x0149, 0x0172, 0x0196, 0x01BE, 0x01F7,
            0x0216, 0x0240, 0x0278, 0x02A4, 0x02D6, 0x030E, 0x034C, 0x037C, 0x03BB, 0x03F4, 0x042A, 0x0440,
            0x048A, 0x04B6,0x04E3, 0x053F, 0x056D, 0x059C, 0x0606, 0x0641, 0x0670, 0x069E, 0x06FC, 0x072E,
            0x075D, 0x07B9, 0x07E7, 0x0844, 0x0875, 0x08D3, 0x0902, 0x093E};

            SetXA();

        APP_DATA = (int)data[OFFSET_APP_DATA];

            APPEARANCE = (int)data[OFFSET_APPEARANCE]+1;

            SPECIAL_NEUTRAL = (int)data[OFFSET_SPECIAL_NEUTRAL] + 1;
            SPECIAL_SIDE_TO_SIDE = (int)data[OFFSET_SPECIAL_SIDE_TO_SIDE] + 1;
            SPECIAL_UP = (int)data[OFFSET_SPECIAL_UP] + 1;
            SPECIAL_DOWN = (int)data[OFFSET_SPECIAL_DOWN] + 1;

            STATS_ATTACK = readStat(data, OFFSET_STATS_ATTACK);
            STATS_DEFENSE = readStat(data, OFFSET_STATS_DEFENSE);
            STATS_SPEED = readStat(data, OFFSET_STATS_SPEED);
            try
            {
                BONUS_EFFECT1 = XA[(int)data[OFFSET_BONUS_EFFECT1]];
            }
            catch
            {
                BONUS_EFFECT1 = "No Effect";
            }
            try
            {
                BONUS_EFFECT2 = XA[(int)data[OFFSET_BONUS_EFFECT2]];
            }
            catch
            {
                BONUS_EFFECT2 = "No Effect";
            }
            try
            {
                BONUS_EFFECT3 = XA[(int)data[OFFSET_BONUS_EFFECT3]];
            }
            catch
            {
                BONUS_EFFECT3 = "No Effect";
            }

            LEVEL = readLevel(data);
        }

        private int readLevel(byte[] data)
        {
            int value = (data[OFFSET_LEVEL] & 0xFF) << 8;
            value |= (data[OFFSET_LEVEL + 1] & 0xFF);

            for (int i = LEVEL_THRESHOLDS.Length - 1; i >= 0; i--)
           {
                if (LEVEL_THRESHOLDS[i] <= value)
                    return i + 1;
            }
            return 1;
        }

        private int readStat(byte[] data, int offset)
        {
            int value = (data[offset] & 0xFF) << 8;
            value |= data[offset + 1] & 0xFF;
            int res = value;
            res += 0; //shift the value to make it positive value as the seek bar doesnt support negative

            if (res < 0)
                res = 0;
            if (res > 401)
                res = 401;

            return res;
        }

        private void SetXA()
        {
            XA = new string[100];
            XA[0] = "Increased running spee";
            XA[1] = "Decreased running spee";
            XA[2] = "Faster sideways air movemen";
            XA[3] = "Slower sideways air movemen";
            XA[4] = "Improved jumping abilit";
            XA[5] = "Weakened jumping abilit";
            XA[6] = "Skatin";
            XA[7] = "Improved ground jump";
            XA[8] = "Weakened ground jump";
            XA[9] = "Improved mid-air jump";
            XA[10] = "Weakened mid-air jump";
            XA[11] = "Floaty jump";
            XA[12] = "Heavy jum";
            XA[13] = "Increased walking spee";
            XA[14] = "Decreased walking spee";
            XA[15] = "Increased edge-grab duratio";
            XA[16] = "Decreased edge-grab duratio";
            XA[17] = "Easier edge-grabbin";
            XA[18] = "More difficult edge-grabbin";
            XA[19] = "Improved braking abilit";
            XA[20] = "Easy perfect shiel";
            XA[21] = "No perfect shiel";
            XA[22] = "Faster Shield Recharg";
            XA[23] = "Slower Shield Recharg";
            XA[24] = "Improved air defens";
            XA[25] = "Weakened air defens";
            XA[26] = "Easier Dodgin";
            XA[27] = "More difficult dodgin";
            XA[28] = "Reduced landing stiffnes";
            XA[29] = "Increased landing stiffnes";
            XA[30] = "Quick smas";
            XA[31] = "Hyper smas";
            XA[32] = "Improved air attack";
            XA[33] = "Weakened air attack";
            XA[34] = "Improved meteor smashe";
            XA[35] = "Improved attack in a crisi";
            XA[36] = "Improved defense in a crisi";
            XA[37] = "Improved speed in a crisi";
            XA[38] = "Powered up in a crisi";
            XA[39] = "Invincible in a crisi";
            XA[40] = "Improved attack at 0 damag";
            XA[41] = "Improved speed at 0 damag";
            XA[42] = "Improved attack/speed at 0";
            XA[43] = "Trade-off for improved attac";
            XA[44] = "Trade-off for improved defens";
            XA[45] = "Trade-off for improved spee";
            XA[46] = "Trade-off for improved abilitie";
            XA[47] = "Improved upward launchin";
            XA[48] = "Health-stealing abilit";
            XA[49] = "Resistant smash charg";
            XA[50] = "Critical hit";
            XA[51] = "Hit downed foes harde";
            XA[52] = "First strike bonu";
            XA[53] = "Countdown bonu";
            XA[54] = "Crash ru";
            XA[55] = "Explosive perfect shiel";
            XA[56] = "Shield restores healt";
            XA[57] = "Shield counte";
            XA[58] = "Quick escap";
            XA[59] = "Improved item throwin";
            XA[60] = "Weakened item throwin";
            XA[61] = "Bonus to battering item";
            XA[62] = "Bonus to thrown item";
            XA[63] = "Bonus to shooting item";
            XA[64] = "High-speed battin";
            XA[65] = "Star rod equippe";
            XA[66] = "Lip&quot;s stick equippe";
            XA[67] = "Nintendo scope equippe";
            XA[68] = "Ray gun equippe";
            XA[69] = "Fire flower equippe";
            XA[70] = "Beam sword equippe";
            XA[71] = "Home-run bat equippe";
            XA[72] = "Bob-omb equippe";
            XA[73] = "Mr. Saturn equippe";
            XA[74] = "Increased healing from foo";
            XA[75] = "Decreased healing from foo";
            XA[76] = "Heal while crouchin";
            XA[77] = "Improved attack after eatin";
            XA[78] = "Improved speed after eatin";
            XA[79] = "Improved defense after eatin";
            XA[80] = "Powered up after eatin";
            XA[81] = "KO healin";
            XA[82] = "Invincible after eatin";
            XA[83] = "Auto-hea";
            XA[84] = "Smash ball gravitatio";
            XA[85] = "Final smash after respawnin";
            XA[86] = "Keep final smash if hur";
            XA[87] = "Smash ball powers you u";
            XA[88] = "Healing smash bal";
            XA[89] = "Double final smas";
            XA[90] = "Lucky sudden deat";
            XA[91] = "Extended respawn invincibilit";
            XA[92] = "No respawn invincibilit";


        }

    }
}
