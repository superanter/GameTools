using System;

namespace Anter.Win32.JL.DSSaveTools
{
	/// <summary>
	/// ClassCard 的摘要说明。
	/// </summary>
	public class CardClass
	{
		public int CardMode;		//烧录卡模式：0为NDS，1为GBA
		public string CardName;		//烧录卡名称
		public string CardSName;	//烧录卡简称
		public string CardSaveType;	//烧录卡支持的存档大小：七位字符串，0为不支持，1为支持
		public int SelectIndex;		//烧录卡所支持的存档大小中默认的项目序号
		public string CardExt;		//烧录卡所支持存档后缀
		public int CardIs;			//特殊烧录卡标识：1为M3,2为DSLink，0为其他烧录卡
		public string CardInfo;		//烧录卡说明

		public CardClass(int CardModeI,string CardNameI,string CardSNameI,string CardSaveTypeI,int SelectIndexI,string CardExtI,int CardIsI,string CardInfoI)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//

			CardMode = CardModeI;
			CardName = CardNameI;
			CardSName = CardSNameI;
			CardSaveType = CardSaveTypeI;
			SelectIndex = SelectIndexI;
			CardExt = CardExtI;
			CardIs = CardIsI;
			CardInfo = CardInfoI;
		}

		#region 烧录卡信息初始化

		/*******************************************************************************************************
		public struct CardType			//烧录卡信息
		{
			public int CardMode;		//烧录卡模式：0为NDS，1为GBA
			public string CardName;		//烧录卡名称
			public string CardSName;	//烧录卡简称
			public string CardSaveType;	//烧录卡支持的存档大小：七位字符串，0为不支持，1为支持
			public int SelectIndex;		//烧录卡所支持的存档大小中默认的项目序号
			public string CardExt;		//烧录卡所支持存档后缀
			public int CardIs;			//特殊烧录卡标识：1为M3,2为DSLink，0为其他烧录卡
			public string CardInfo;		//烧录卡说明

			public CardType(int CardModeI,string CardNameI,string CardSNameI,string CardSaveTypeI,int SelectIndexI,string CardExtI,int CardIsI,string CardInfoI)
			{
				CardMode = CardModeI;
				CardName = CardNameI;
				CardSName = CardSNameI;
				CardSaveType = CardSaveTypeI;
				SelectIndex = SelectIndexI;
				CardExt = CardExtI;
				CardIs = CardIsI;
				CardInfo = CardInfoI;
			}

		}

		private void SetCardType()		//对烧录卡进行支持
		{
			/***********************************************************************************************************/
		/*                                                                                                         */
		/*  在本列表增计项目时，需要修改“初始化”->“变量初始化”里面的下面两行：                                 */
		/*    static int NdsCards = 21+1;		//支持的NDS烧录卡的数量，“+1”前面的数字和DS烧录卡最大序号相同    */
		/*	  static int GbaCards = 7+1;		//支持的GBA烧录卡的数量，“+1”前面的数字和GBA烧录卡最大序号相同   */
		/*                                                                                                         */
		/**********************************************************************************************************



			//以下是NDS烧录卡列表
			SetupCardType[0][0] = new CardType(0,"Acekard(+ & RPG)","AK","1110110",4,".nds.sav",0,"slot1接口，使用外置TF卡和内置(RPG专有)存储，标准存档格式，需选择大小。");
			SetupCardType[0][1] = new CardType(0,"CycloDS Evolution","CE","0000010",1,".sav",0,"slot1接口，标准512K存档格式。  ");
			SetupCardType[0][2] = new CardType(0,"DS FIRE LINK","DSFLK","0000100",1,".sav",0,"slot1+2接口，使用内置存储芯片，标准256K存档格式。(DSGBA OEM产品)");
			SetupCardType[0][3] = new CardType(0,"DSGBA","DSGBA","0000100",1,".sav",0,"slot1+2接口，使用内置存储芯片，标准256K存档格式。(DSGBA OEM产品)");
			SetupCardType[0][4] = new CardType(0,"DSLink","DSLK","0000010",1,".sav",2,"slot1接口，使用内置存储芯片，固定的520K特有存档格式。");
			SetupCardType[0][5] = new CardType(0,"DSTT","DSTT","0000010",1,".sav",0,"slot1接口，使用外置TF卡存储，标准512K存档格式。");
			SetupCardType[0][6] = new CardType(0,"EWIN2","EW2","0000110",2,".sav",0,"slot2接口，使用内置存储芯片，标准存档格式，新版本体积512K，旧版本体积为256K。");
			SetupCardType[0][7] = new CardType(0,"EZ4","EZ4","0000100",1,".sav",0,"slot2接口，使用内置存储芯片，256K标准存档格式。");
			SetupCardType[0][8] = new CardType(0,"EZ5","EZ5","1110110",4,".sav",0,"slot1接口，使用外置TF卡存储，标准存档格式，需选择大小。");
			SetupCardType[0][9] = new CardType(0,"G6 (Lite)","G6","0000110",1,".0",0,"slot2接口，使用内置存储芯片，256K或512K标准存档格式。");
			SetupCardType[0][10] = new CardType(0,"G6 DS Real","G6DSR","0000010",1,".sav",0,"slot1接口，使用内置存储芯片，标准512K存档格式。");
			SetupCardType[0][11] = new CardType(0,"M3 (Lite)","M3","0000110",1,".dat",1,"slot2接口，使用外置SD或SD mini卡，257K或513K特有存档格式。");
			SetupCardType[0][12] = new CardType(0,"M3 DS Real","M3DSR","0000010",1,".sav",0,"slot1接口，使用外置TF卡存储，标准512K存档格式。");
			SetupCardType[0][13] = new CardType(0,"M3 DS Simply","M3DSS","0000010",1,".sav",0,"slot1接口，使用外置TF卡存储，标准512K存档格式。");
			SetupCardType[0][14] = new CardType(0,"MK5","MK5","0000100",1,".sav",0,"slot1+2接口，使用内置存储芯片，标准256K存档格式。(DSGBA OEM产品)");
			SetupCardType[0][15] = new CardType(0,"N-CARD","NCARD","0000100",1,".sav",0,"slot1+2接口，使用内置存储芯片，标准256K存档格式。(DSGBA OEM产品)");
			SetupCardType[0][16] = new CardType(0,"R4","R4","0000010",1,".sav",0,"slot1接口，使用外置TF卡存储，标准512K存档格式。 ");
			SetupCardType[0][17] = new CardType(0,"Super Card (Lite)","SC","0000100",1,".nds.sav",0,"slot2接口，使用外置SD或SD mini卡，256K标准存档格式。");
			SetupCardType[0][18] = new CardType(0,"Super Card DS (ONE)","SCDS","1110110",4,".sav",0,"slot1接口，使用外置TF卡存储，标准存档格式，需选择大小。");
			SetupCardType[0][19] = new CardType(0,"SUNNY FLASH","SYFH","0000100",1,".sav",0,"slot1+2接口，使用内置存储芯片，标准256K存档格式。(DSGBA OEM产品)");
			SetupCardType[0][20] = new CardType(0,"(EMU) NO$GBA (Raw)","NO$GBA","0000010",1,".sav",0,"PC用DS模拟器，两种专用的特殊存档格式或512K标准存档格式。（本软件只能转为Raw模式）");
			SetupCardType[0][21] = new CardType(0,"Other (All Sizes)","OTHER","1111111",5,".sav",0,"未知存储卡，仅支持标准存档格式。");


			//以下是GBA烧录卡列表
			SetupCardType[1][0] = new CardType(1,"EZ 3IN1","3IN1","0001000",1,".sav",0,"slot2接口，使用内置存储芯片，标准存档格式。");
			SetupCardType[1][1] = new CardType(1,"Elink (Lite)","Elink","1111000",3,".sav",0,"slot2接口，使用内置存储芯片，标准存档格式。");
			SetupCardType[1][2] = new CardType(1,"EZ4","EZ4","0001000",1,".sav",0,"slot2接口，使用内置存储芯片，标准存档格式。");
			SetupCardType[1][3] = new CardType(1,"G6 (Lite)","G6","0001000",1,".0",0,"slot2接口，使用内置存储芯片，标准存档格式。");
			SetupCardType[1][4] = new CardType(1,"GBA Expansion Pack","GBAEP","0001000",1,".0",0,"slot2接口，使用内置存储芯片，标准存档格式。");
			SetupCardType[1][5] = new CardType(1,"M3 (Lite)","M3","0001001",1,".dat",1,"slot2接口，使用外置SD或SD mini卡，129K特殊存档格式。");
			SetupCardType[1][6] = new CardType(1,"Super Card (Lite)","SC","0001000",1,".nds.sav",0,"slot2接口，使用外置SD或SD mini卡，标准存档格式。");
			SetupCardType[1][7] = new CardType(1,"Other (All Sizes)","OTHER","1111111",4,".sav",0,"未知存储卡，仅支持标准存档格式。");


			
			}
****************************************************************************************************************************/
		#endregion

	}
}
