using System;
using System.Text;          //M3Adding.UnicodeEncoding
using System.IO;            //FileStream

namespace AnterStudio.GameTools.DsSaveClass
{
    class WriteData
    {
        #region 特殊烧录卡的附加处理（4）

        public static string M3Adding(string ShortName, string LongName, FileStream sro, int SelectMode, bool M3Add1M)	//M3附加的1k信息（ROM文件来源）
        {
            string M3SaveMode = "";

            if (SelectMode == 0)
            {
                M3SaveMode = "NDS";
            }
            else if (SelectMode == 1)
            {
                M3SaveMode = "GBA";
            }
            else
            {
                return "ED101";
            }

            try
            {
                int i, LengthMax;

                if (sro.Length == 512 * 1024 || sro.Length == 256 * 1024 || sro.Length == 128 * 1024)   //可简化？
                {
                    LengthMax = (int)sro.Length;
                }
                else
                {
                    LengthMax = 256 * 1024;
                }

                ShortName = ShortName.Remove(ShortName.Length - 4, 4);	//去掉短文件名的后缀，可优化？

                using (StreamWriter sw = new StreamWriter(sro, UnicodeEncoding.GetEncoding("GB2312")))
                {
                    sw.AutoFlush = true;								//自动更新
                    sw.Write("BOOT\x0000" + ShortName.ToUpper());		//1:写入"BOOT & 0x00"以及短文件名
                    for (i = (int)sro.Length; i < LengthMax + 13; i++)	//2:将短文件名凑够8个字节
                    {
                        sro.WriteByte(0x20);
                    }
                    sw.Write(M3SaveMode + "\x0001");					//3:写入"NDS(GBA) & 0x01"
                    for (i = 0; i < 20; i++)							//4:写入空白
                    {
                        sro.WriteByte(0x00);
                    }
                    sw.Write(LongName);									//5:写入长文件名
                    //sw.AutoFlush = false;                               //2017/02/04删除
                    for (i = (int)sro.Length; i < LengthMax + 1024; i++)//6:写入最后的空白部分
                    {
                        sro.WriteByte(0x00);
                    }
                    //sw.Flush();
                    if (M3Add1M)
                    {
                        for (i = 0; i < (1024 - 129) * 1024; i++)		//写入M3 GBA存档的129K至1M附加部分（旧版本存档）
                        {
                            sro.WriteByte(0x00);
                        }
                    }
                    //sw.Flush();                               //2017/02/04删除
                    //sw.Close();                               //2017/02/04删除
                }
                return null;
            }
            catch
            {
                return "ED102";
            }
        }

        public static string M3AddingDAT(string InputDatName, FileStream sro, int SelectMode, bool M3Add1M)	//M3附加的1k信息（DAT文件来源）
        {
            try
            {
                BinaryWriter w1 = new BinaryWriter(sro);
                FileStream sr1 = new FileStream(InputDatName, FileMode.Open, FileAccess.Read);
                BinaryReader r1 = new BinaryReader(sr1);
                int intLength = (int)sr1.Length;

                if (intLength == 257 * 1024)
                {
                    r1.ReadBytes(256 * 1024);
                }
                else if (intLength == 513 * 1024)
                {
                    r1.ReadBytes(512 * 1024);
                }
                else if (intLength == 129 * 1024)
                {
                    r1.ReadBytes(128 * 1024);
                }
                else if (intLength == 1024 * 1024)
                {
                    r1.ReadBytes(128 * 1024);
                }
                else
                {
                    return "ED103";
                }
                w1.Write(r1.ReadBytes(1024));

                if (M3Add1M)
                {
                    for (int i = 0; i < (1024 - 129) * 1024; i++)			//写入M3 GBA存档的129K至1M附加部分（旧版本存档）
                    {
                        sro.WriteByte(0x00);
                    }
                }

                sr1.Close();

                return null;
            }
            catch
            {
                return "ED104";
            }
        }

        public static string DSLinkAdding(InputFileInfo ifiFileMode, FileStream sro)	//DSLink 附加的8k信息
        {
            int x = ifiFileMode.Buffer.Length;
            int lengthMax = 8 * 1024;

            try
            {
                BinaryWriter w = new BinaryWriter(sro);

                if (x > lengthMax)
                {
                    x = lengthMax;
                }
                w.Write(ifiFileMode.Buffer, 0, x);

                for (int i = x; i < lengthMax; i++)
                {
                    sro.WriteByte(0xff);
                }
                w.Close();

                return null;
            }
            catch
            {
                return "ED105";
            }
        }

        public static string DeSmuMEAdding(FileStream sro)	//DeSmuME附加的122字节信息
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(sro, UnicodeEncoding.GetEncoding("GB2312")))
                {
                    string txtDeSmuME1 = "|<--Snip above here to create a raw sav by excluding this DeSmuME savedata footer:";
                    string txtDeSmuME2 = "|-DESMUME SAVE-|";

                    sw.AutoFlush = true;								//自动更新
                    sw.Write(txtDeSmuME1);
                    for (int i = 0; i < 24; i++)
                    {
                        sro.WriteByte(0x00);
                    }
                    sw.Write(txtDeSmuME2);
                    //sw.AutoFlush = false;                               //2017/02/04删除
                    //sw.Flush();                                         //2017/02/04删除
                    //sw.Close();                                         //2017/02/04删除
                }
                return null;
            }
            catch
            {
                return "ED106";
            }
        }

        #endregion

        #region 口袋妖怪强制转换程序（1）

        public static string[]  PokemonChange(InputFileInfo ifiFileMode, string OutputName)		//口袋妖怪存档特殊转换
        {
            string[] PokemonString = new string[6];
            try
            {
                int flag = new int();
                if (ifiFileMode.Buffer.Length >= 512 * 1024)
                {
                    //把数据写入新存档，默认存档为时间靠后的存档，时间靠前的也转换，但加“.old”后缀
                    byte[] buffer1 = new byte[256 * 1024];
                    byte[] buffer2 = new byte[256 * 1024];
                    for (int i = 0; i < 256 * 1024; i++)
                    {
                        buffer1[i] = ifiFileMode.Buffer[i];
                        buffer2[i] = ifiFileMode.Buffer[256 * 1024 + i];
                    }
                    //读取存档次数(4字节读取)
                    int[][] iTestTimes = new int[3][];
                    iTestTimes[0] = new int[3];	// 最后确定的存档次数
                    iTestTimes[1] = new int[3];	// 珍珠、钻石的存档次数
                    iTestTimes[2] = new int[3];	// 白金的存档次数
                    iTestTimes[1][1] = buffer1[0xc0f0] + buffer1[0xc0f1] * 256 + buffer1[0xc0f2] * 256 * 256 + buffer1[0xc0f3] * 256 * 256 * 256;
                    iTestTimes[1][2] = buffer2[0xc0f0] + buffer2[0xc0f1] * 256 + buffer2[0xc0f2] * 256 * 256 + buffer2[0xc0f3] * 256 * 256 * 256;
                    iTestTimes[2][1] = buffer1[0xcf1c] + buffer1[0xcf1d] * 256 + buffer1[0xcf1e] * 256 * 256 + buffer1[0xcf1f] * 256 * 256 * 256;
                    iTestTimes[2][2] = buffer2[0xcf1c] + buffer2[0xcf1d] * 256 + buffer2[0xcf1e] * 256 * 256 + buffer2[0xcf1f] * 256 * 256 * 256;

                    if (Math.Abs(iTestTimes[1][1] - iTestTimes[1][2]) == 1)
                    {
                        PokemonString[1] = "Pokemon Platinum";
                        iTestTimes[0][1] = iTestTimes[1][1];
                        iTestTimes[0][2] = iTestTimes[1][2];
                    }
                    else if (Math.Abs(iTestTimes[2][1] - iTestTimes[2][2]) == 1)
                    {
                        PokemonString[1] = "Pokemon Pearl/Diamond";
                        iTestTimes[0][1] = iTestTimes[2][1];
                        iTestTimes[0][2] = iTestTimes[2][2];
                    }

                    flag = iTestTimes[0][1] >= iTestTimes[0][2] ? 1 : 2;
                    if (PokemonString[1] != null)
                    {
                        FileStream sro1 = new FileStream(OutputName, FileMode.Create);
                        BinaryWriter w1 = new BinaryWriter(sro1);
                        FileStream sro2 = new FileStream(OutputName + ".old", FileMode.Create);
                        BinaryWriter w2 = new BinaryWriter(sro2);

                        //按照存档次数判断先后顺序
                        if (flag == 1)
                        {
                            w1.Write(buffer1);
                            w2.Write(buffer2);
                        }
                        else
                        {
                            w2.Write(buffer1);
                            w1.Write(buffer2);
                        }
                        w1.Close();
                        w2.Close();
                    }
                    else
                    {
                        PokemonString[0] = "ED202";
                    }
                    PokemonString[2] = ifiFileMode.InputFileMode;
                    PokemonString[3] = iTestTimes[0][1].ToString();
                    PokemonString[4] = iTestTimes[0][2].ToString();
                    PokemonString[5] = flag.ToString();
                }
                else
                {
                    PokemonString[0] = "ED203";
                }
            }
            catch
            {
                PokemonString[0] = "ED201";
            }
            return PokemonString;
        }

        #endregion

        #region 正常转换（1）

        public static string[] MainChange(InputFileInfo ifiFileMode, MainFormInfo mfiMainInfo, int[] UsedSize)
        {
            //分析源文件，分情况转换
            string[] sReturnStr = new string[6];
            int iOutputLenghAdd = new int();				// 转换后文件附加部分大小
            bool IsM3Gba1MB = false;						// 标记：目标为1M byte大小的M3格式的GBA存档
            int iOutputLengh = UsedSize[mfiMainInfo.Size];	    // 转换后文件大小（无附加部分）
            int InputFileSize = ifiFileMode.Buffer.Length;

            // M3 GBA 1M byte的三个条件：目标大小为1M byte；目标格式为M3；GBA模式。此时，只读取前128K数据
            if ((iOutputLengh == 1024 * 1024) && (mfiMainInfo.CardIs == 1) && (mfiMainInfo.Mode == 1))
            {
                iOutputLengh = 128 * 1024;
                IsM3Gba1MB = true;
            }

            int CopyFileSize = InputFileSize > iOutputLengh ? iOutputLengh : InputFileSize;

            //将源文件数据写入目标文件
            try
            {
                FileStream sro = new FileStream(mfiMainInfo.OutputName, FileMode.Create);
                BinaryWriter w = new BinaryWriter(sro);

                // 写入正常部分
                w.Write(ifiFileMode.Buffer, 0, CopyFileSize);

                // 把目标文件用0xff补全到需要的大小
                for (int i = CopyFileSize; i < iOutputLengh; i++)
                {
                    sro.WriteByte(0xff);
                }

                //	写入M3和DSLINK的附加部分
                if (mfiMainInfo.CardIs == 1)           // 目标存档为M3格式(CardIs=1)时，附加1K
                {
                    iOutputLenghAdd = 1024;

                    if (mfiMainInfo.M3DatChecked)
                    {
                        sReturnStr[0] = WriteData.M3AddingDAT(mfiMainInfo.M3FileName, sro, mfiMainInfo.Mode, IsM3Gba1MB);
                    }
                    else
                    {
                        sReturnStr[0] = WriteData.M3Adding(mfiMainInfo.M3ShortName, mfiMainInfo.M3LongName, sro, mfiMainInfo.Mode, IsM3Gba1MB);
                    }
                }
                else if (mfiMainInfo.CardIs == 2)      // 目标存档为DSLink格式(CardIs=2)时，附加8K
                {
                    iOutputLenghAdd = 8 * 1024;
                    sReturnStr[0] = WriteData.DSLinkAdding(ifiFileMode,sro);
                }
                else if (mfiMainInfo.CardIs == 3)      // 目标存档为DeSmuME模拟器的dsv格式(CardIs=3)时，附加122字节
                {
                    iOutputLenghAdd = 122;
                    sReturnStr[0] = WriteData.DeSmuMEAdding(sro);
                }
                sro.Close();

                int iTemp = iOutputLengh + iOutputLenghAdd;

                sReturnStr[1] = ifiFileMode.InputFileMode;
                sReturnStr[2] = ifiFileMode.InputFileLength.ToString();
                sReturnStr[3] = ifiFileMode.Buffer.Length.ToString();
                sReturnStr[4] = iTemp.ToString();
                sReturnStr[5] = IsM3Gba1MB.ToString();
            }
            catch
            {
                sReturnStr[0] = "ED001";
            }

            if (ifiFileMode.InputFileMode == "UnKnown")
            {
                sReturnStr[0] = "ED002";
            }

            return sReturnStr;
        }

        #endregion
    }
}
