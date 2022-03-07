//using System.Text;

namespace AnterStudio.GameTools.DsSaveClass
{
    class CardList
    {
        #region 初始化烧录卡列表（1方法）

        public static CardClass[][] GetCardDat()
        {
            int NdsCards = 28 + 1;      //支持的NDS烧录卡的数量，“+1”前面的数字和DS烧录卡最大序号相同
            int GbaCards = 7 + 1;		//支持的GBA烧录卡的数量，“+1”前面的数字和GBA烧录卡最大序号相同
            CardClass[][] CardDat = new CardClass[2][];			//烧录卡信息数据
            CardDat[0] = new CardClass[NdsCards];
            CardDat[1] = new CardClass[GbaCards];

            #region NDS烧录卡列表
            //以下是NDS烧录卡列表
            CardDat[0][0] = new CardClass(0, "Normal", "Normal", "1110110000", 5, 0, ".sav", 0, "通用存档格式，适用于所有的的DS模式标准存档格式的烧录卡。");
            CardDat[0][1] = new CardClass(0, "Acekard+ & Acekard RPG", "AK", "1110110000", 4, 0, ".nds.sav", 0, "slot1接口，使用TF卡和内置(RPG专有)存储，标准存档格式，需选择大小。");
            CardDat[0][2] = new CardClass(0, "Acekard 2", "AK2", "0000010000", 1, 0, ".sav", 0, "slot1接口，使用TF卡存储，标准512K存档格式。 ");
            CardDat[0][3] = new CardClass(0, "CycloDS Evolution", "CyDS", "0000010000", 1, 0, ".sav", 0, "slot1接口，使用TF卡存储，标准512K存档格式。  ");
            CardDat[0][4] = new CardClass(0, "DS FIRE LINK", "DSFLK", "0000100000", 1, 1, ".sav", 0, "DSGBA OEM产品，slot1+2接口，使用内置存储芯片，标准256K存档格式。");
            CardDat[0][5] = new CardClass(0, "DSGBA", "DSGBA", "0000100000", 1, 1, ".sav", 0, "slot1+2接口，使用内置存储芯片，标准256K存档格式。");
            CardDat[0][6] = new CardClass(0, "DSLink", "DSLK", "0000010000", 1, 0, ".sav", 2, "slot1接口，使用内置存储芯片，固定的520K特有存档格式。");
            CardDat[0][7] = new CardClass(0, "DSTT (Top Toy)", "DSTT", "0000010000", 1, 0, ".sav", 0, "slot1接口，使用TF卡存储，标准512K存档格式。");
            CardDat[0][8] = new CardClass(0, "DS-Xtreme 4Gb/16Gb", "DSXr", "0000100000", 1, 1, ".sav", 0, "slot1接口，使用内置存储芯片，标准256K存档格式。");
            CardDat[0][9] = new CardClass(0, "EDGE", "EDGE", "0000010000", 1, 0, ".sav", 0, "slot1接口，使用TF卡存储，标准512K存档格式。 ");
            CardDat[0][10] = new CardClass(0, "EWIN2", "EW2", "0000110000", 2, 1, ".sav", 0, "slot2接口，使用内置存储芯片，标准存档格式，新版本体积512K，旧版本体积为256K。");
            CardDat[0][11] = new CardClass(0, "EZ Flash 4", "EZ4", "0000100000", 1, 1, ".sav", 0, "slot2接口DS和GBA双用烧录卡，使用内置存储芯片，DS模式采用256K标准存档格式。");
            CardDat[0][12] = new CardClass(0, "EZ Flash 5", "EZ5", "1110110000", 4, 0, ".sav", 0, "slot1接口，使用TF卡存储，标准存档格式，需选择大小。");
            CardDat[0][13] = new CardClass(0, "G6 (Lite)", "G6", "0000110000", 1, 0, ".0", 0, "slot2接口DS和GBA双用烧录卡，使用内置存储芯片，DS模式采用256K或512K标准存档格式。");
            CardDat[0][14] = new CardClass(0, "G6 DS Real", "G6DSR", "0000010000", 1, 0, ".sav", 0, "slot1接口，使用内置存储芯片，512K标准存档格式。");
            CardDat[0][15] = new CardClass(0, "M3 (Lite)", "M3", "0000110000", 1, 0, ".dat", 1, "slot2接口DS和GBA双用烧录卡，使用SD或mini SD卡存储，DS模式采用257K或513K特有存档格式。");
            CardDat[0][16] = new CardClass(0, "M3 DS Real", "M3DSR", "0000010000", 1, 0, ".sav", 0, "slot1接口，使用TF卡存储，512K标准存档格式。");
            CardDat[0][17] = new CardClass(0, "M3 DS Simply", "M3DSS", "0000010000", 1, 0, ".sav", 0, "slot1接口，使用TF卡存储，512K标准存档格式。");
            CardDat[0][18] = new CardClass(0, "MK5", "MK5", "0000100000", 1, 1, ".sav", 0, "DSGBA OEM产品，slot1+2接口，使用内置存储芯片，标准256K存档格式。");
            CardDat[0][19] = new CardClass(0, "N-CARD", "NCARD", "0000100000", 1, 1, ".sav", 0, "DSGBA OEM产品，slot1+2接口，使用内置存储芯片，标准256K存档格式。");
            CardDat[0][20] = new CardClass(0, "NinjaDS", "NjaDS", "0000010000", 1, 0, ".sav", 0, "slot1接口，使用内置存储芯片，标准512K存档格式。 ");
            CardDat[0][21] = new CardClass(0, "NinjaPass", "NjaPa", "0000100000", 1, 1, ".sav", 0, "slot1接口，使用内置存储芯片，标准256K存档格式。 ");
            CardDat[0][22] = new CardClass(0, "R4", "R4", "0000010000", 1, 0, ".sav", 0, "slot1接口，使用TF卡存储，标准512K存档格式。 ");
            CardDat[0][23] = new CardClass(0, "Super Card (Lite)", "SC", "0000110000", 1, 1, ".nds.sav", 0, "slot2接口DS和GBA双用烧录卡，使用SD或mini SD卡存储，DS模式采用256K或512K标准存档格式。");
            CardDat[0][24] = new CardClass(0, "Super Card DS (ONE)", "SCDS", "1110110000", 4, 0, ".sav", 0, "slot1接口，使用TF卡存储，标准存档格式。");
            CardDat[0][25] = new CardClass(0, "SUNNY FLASH", "SYFH", "0000100000", 1, 1, ".sav", 0, "DSGBA OEM产品，slot1+2接口，使用内置存储芯片，标准256K存档格式。");
            CardDat[0][26] = new CardClass(0, "(EMU) NO$GBA (Raw)", "NO$GBA", "0000010000", 1, 0, ".sav", 0, "PC用模拟器，使用512K标准存档格式或自有的特有存档格式。");
            CardDat[0][27] = new CardClass(0, "DeSmuME（Normal）", "DSM-N", "1110110000", 5, 0, ".sav", 0, "PC用模拟器，用来导入/导出存档的标准格式存档，需手动选择存档大小。");
            CardDat[0][28] = new CardClass(0, "DeSmuME（Add）(测试)", "DSM-A", "1110110000", 5, 0, ".dsv", 3, "PC用模拟器，自用存档格式，标准存档+122字节附加说明，需手动选择存档大小。（测试）");
            #endregion

            #region GBA烧录卡列表
            //以下是GBA烧录卡列表
            CardDat[1][0] = new CardClass(1, "EZ 3IN1", "3IN1", "0001000000", 1, 0, ".sav", 0, "slot2接口GBA烧录卡，使用内置存储芯片，标准128K存档格式。");
            CardDat[1][1] = new CardClass(1, "Elink (Lite)", "Elink", "1111000000", 3, 0, ".sav", 0, "slot2接口GBA烧录卡，使用内置存储芯片，标准存档格式。");
            CardDat[1][2] = new CardClass(1, "EZ4", "EZ4", "0001000000", 1, 0, ".sav", 0, "slot2接口DS和GBA双用烧录卡，使用内置存储芯片，GBA模式采用128K标准存档格式。");
            CardDat[1][3] = new CardClass(1, "G6 (Lite)", "G6", "0001000000", 1, 0, ".0", 0, "slot2接口DS和GBA双用烧录卡，使用内置存储芯片，GBA模式采用128K标准存档格式。");
            CardDat[1][4] = new CardClass(1, "GBA Expansion Pack", "GBAEP", "0001000000", 1, 0, ".0", 0, "slot2接口GBA烧录卡，使用内置存储芯片，标准128K存档格式。");
            CardDat[1][5] = new CardClass(1, "M3 (Lite)", "M3", "0001001000", 1, 0, ".dat", 1, "slot2接口DS和GBA双用烧录卡，使用SD或mini SD卡存储，GBA模式采用129K或1M特有存档格式。");
            CardDat[1][6] = new CardClass(1, "Super Card (Lite)", "SC", "0001000000", 1, 0, ".nds.sav", 0, "slot2接口DS和GBA双用烧录卡，使用SD或mini SD卡存储，GBA模式采用128K标准存档格式。");
            CardDat[1][7] = new CardClass(1, "Other (All Sizes)", "OTHER", "1111111000", 4, 0, ".sav", 0, "适用于所有的GBA模式标准存档格式的烧录卡。");
            #endregion

            return CardDat;
        }

        #endregion

    }
}
