using System;
using System.IO;
using System.IO.Compression;

namespace AnterStudio.GameTools.DsSaveClass
{
    class InputFileInfo
    {
        #region 变量说明和访问器

        #region 变量说明

        /// <summary>
        /// 源存档完整文件名
        /// </summary>
        private string inputFileName = null;
        /// <summary>
        /// 源存档文件类型
        /// </summary>
        private string inputFileMode = null;		//源存档格式
        /// <summary>
        /// 源存档文件体积
        /// </summary>
        private int inputFileLength = new int();
        /// <summary>
        /// 源存档是否为已知压缩格式的存档
        /// </summary>
        private bool isCompression = false;
        /// <summary>
        /// 源存档中有用的存档数据
        /// </summary>
        private byte[] buffer;
        /// <summary>
        /// 源存档中有用数据的测试代码,8位字符串
        /// </summary>
        private string testCode;
        /// <summary>
        /// 读取源存档时的错误代码，无错误则为null
        /// </summary>
        private string errorCode = null;
        /// <summary>
        /// 源存档中有用数据字符串
        /// </summary>
        private string testString = null;
        /// <summary>
        /// 非压缩存档头部不读取数据体积
        /// </summary>
        private int passSize = new int();
        /// <summary>
        /// 非压缩存档末尾不读取数据体积
        /// </summary>
        private int endSize = new int();
        /// <summary>
        /// 错误前导字符
        /// </summary>
        private string errorBegin = "EI";

        #endregion

        #region 访问器

        /// <summary>
        /// 源存档完整文件名
        /// </summary>
        public string InputFileName
        {
            get
            {
                return inputFileName;
            }
        }
        /// <summary>
        /// 源存档文件类型
        /// </summary>
        public string InputFileMode
        {
            get
            {
                return inputFileMode;
            }
        }
        /// <summary>
        /// 源存档文件体积
        /// </summary>
        public int InputFileLength
        {
            get
            {
                return inputFileLength;
            }
        }
        /// <summary>
        /// 源存档是否为已知压缩格式的存档
        /// </summary>
        public bool IsCompression
        {
            get
            {
                return isCompression;
            }
        }
        /// <summary>
        /// 源存档中有用的存档数据
        /// </summary>
        public byte[] Buffer
        {
            get
            {
                return buffer;
            }
        }
        /// <summary>
        /// 源存档中有用数据的测试代码,8位字符串
        /// </summary>
        public string TestCode
        {
            get
            {
                return testCode;
            }
        }
        /// <summary>
        /// 源存档中有用数据字符串
        /// </summary>
        public string TestString
        {
            get
            {
                return testString;
            }
        }
        /// <summary>
        /// 读取源存档时的错误代码，无错误则为null
        /// </summary>
        public string ErrorCode
        {
            get { return errorCode; }
        }

        /// <summary>
        /// 设置错误字符串
        /// </summary>
        private string SetErrorCode
        {
            set { errorCode = errorBegin + value; }
        }

        #endregion

        #endregion

        #region  构造函数（2）

        /// <summary>
        /// 构造函数
        /// </summary>
        public InputFileInfo()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public InputFileInfo(string strInputfileName)
        {
            if (strInputfileName != null)
            {
                this.inputFileName = strInputfileName;
                this.GetInputFileMode(InputFileName);
                if (this.inputFileMode == "GDS")
                {
                    this.LoadGdsFile(this.inputFileName);
                }
                else if (this.inputFileMode == "Com NO$GBA")
                {
                    this.LoadNoGbaComFile(this.inputFileName);
                }
                else if (this.inputFileMode == "AR DST")
                {
                    this.LoadDstFile(this.inputFileName);
                }
                else
                {
                    this.LoadNormalFile(this.inputFileName);
                }
                this.testCode = this.Test();
                this.testString = this.GetTestText(testCode);
            }
        }

        #endregion

        #region 存档测试（5）

        /// <summary>
        /// 获取源存档格式
        /// </summary>
        private void GetInputFileMode(string strInputName)      //2017-01-22
        {
            ///	判断源存档格式
            ///		1、NO$GBA格式
            ///			a、"UnCo NO$GBA"	532848byte大小的Uncompressed格式（非压缩格式）
            ///			b、"Com NO$GBA"		Compressed格式（压缩格式）
            ///			c、"UnKnown"		未知格式
            ///		2、Action Replay Max DS模式
            ///			a、"AR DUC/DSS"		AR DUC/DSS模式
            ///			b、"AR DST"		AR DST模式
            ///		3、"GDS"        DS-Xploder & Gameshark for Nintendo DS模式
            ///		4、DSLink模式
            ///			a、"DSLink EEPROM"	EEPROM模式
            ///			b、"DSLink FLASH"	FLASH模式
            ///		5、"M3"			M3格式
            ///		6、"Normal"		标准格式
            ///		7、"DeSmuME(Add)"   DeSmuME的DSV格式
            ///		8、"UnKnown"	未知格式
            ///	

            try
            {
                FileStream sri = new FileStream(strInputName, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(sri);

                int intCopyLengh = (int)sri.Length;			                        //源存档体积
                string txtNoGba1 = "";
                try
                {
                    txtNoGba1 = new string(r.ReadChars(31));		        	    //主识别字符串   2017-01-22
                }
                catch { }


                r.ReadBytes(16 * 2 + 1);
                string txtNoGba2 = new string(r.ReadChars(4));		        	    //NO$GBA专用识别字符串
                int intNoGba = Convert.ToInt16(r.ReadByte());	                    //NO$GBA格式模式区分标记

                if (txtNoGba1 == "NocashGbaBackupMediaSavDataFile" && txtNoGba2 == "SRAM")
                {
                    if (intCopyLengh == 520 * 1024 + 368 && intNoGba == 0)
                    {
                        inputFileMode = "UnCo NO$GBA";
                        passSize = 76;	//0x4c
                    }
                    else if (intNoGba == 1)
                    {
                        inputFileMode = "Com NO$GBA";
                        //comPassSize = 0x50;
                        isCompression = true;
                    }
                    else
                    {
                        inputFileMode = "UnKnown";
                    }
                }
                else if (txtNoGba1.StartsWith("ARDS"))      //AR识别字符串
                {
                    if (intCopyLengh == 1012 || intCopyLengh == 8692 || intCopyLengh == 66036 || intCopyLengh == 262644)
                    {
                        inputFileMode = "AR DUC/DSS";
                        passSize = 500;	//0x1F4
                    }
                    else
                    {
                        inputFileMode = "AR DST";
                        //comPassSize = 0x1f8;
                        isCompression = true;
                    }
                }
                else if (txtNoGba1.StartsWith("DSXS"))      //GDS识别字符串
                {
                    inputFileMode = "GDS";
                    //comPassSize = 0x100;
                    isCompression = true;
                }
                else if (intCopyLengh == 520 * 1024)
                {
                    if (IsEEPROMFile())
                    {
                        inputFileMode = "DSLink EEPROM";
                        passSize = 512 * 1024;
                    }
                    else
                    {
                        inputFileMode = "DSLink FLASH";
                        this.endSize = 8 * 1024;

                    }
                }
                else if ((intCopyLengh == 129 * 1024) || (intCopyLengh == 257 * 1024) || (intCopyLengh == 513 * 1024))
                {
                    inputFileMode = "M3";
                    this.endSize = 1024;
                }
                else if (intCopyLengh == 272 * 1024)
                {
                    inputFileMode = "EzIV";
                    this.endSize = 16 * 1024;
                }
                else if ((intCopyLengh == 0.5 * 1024) || (intCopyLengh == 8 * 1024) || (intCopyLengh == 64 * 1024) || (intCopyLengh == 128 * 1024) || (intCopyLengh == 256 * 1024) || (intCopyLengh == 512 * 1024) || (intCopyLengh == 1024 * 1024))
                {
                    inputFileMode = "Normal";
                }
                //*******2017-1-22对DeSmuME的DSV格式输入支持*******
                else if ((intCopyLengh == 0.5 * 1024 + 122) || (intCopyLengh == 8 * 1024 + 122) || (intCopyLengh == 64 * 1024 + 122) || (intCopyLengh == 128 * 1024 + 122) || (intCopyLengh == 256 * 1024 + 122) || (intCopyLengh == 512 * 1024 + 122) || (intCopyLengh == 1024 * 1024 + 122))
                {
                    inputFileMode = "DeSmuME(Add)";
                }
                else if (IsSpsFile(0x30) == false && IsSpsFile(0x37) == false)
                {
                    inputFileMode = "UnKnown";
                }

                sri.Close();
            }
            catch
            {
                SetErrorCode = "001";
            }
        }

        /// <summary>
        /// 判断源存档是否为sps存档
        /// </summary>
        private bool IsSpsFile(int temp)
        {
            //Gameshark GBA snapshot(*.sps)

            bool flag = false;
            int index = 0;
            int num2 = 0;
            byte[] spsMarker = new byte[9];
            if (temp == -1)
            {
                spsMarker[0] = 0x30;
            }
            else
            {
                spsMarker[0] = (byte)temp;
            }
            spsMarker[1] = 0x1;
            try
            {
                Stream sri = File.OpenRead(this.inputFileName);
                byte[] TempBuffer = new byte[(int)sri.Length];
                sri.Read(TempBuffer, 0, (int)sri.Length);
                sri.Close();

                do
                {
                    if (TempBuffer[num2] == spsMarker[index])
                    {
                        index++;
                    }
                    else
                    {
                        index = 0;
                    }
                    num2++;
                    if (index > 8)
                    {
                        flag = true;
                    }
                }
                while (!flag && (num2 < TempBuffer.Length));
            }
            catch
            {
                SetErrorCode = "101";
            }

            if (flag)
            {
                this.passSize = num2;
                this.inputFileMode = "GsGBAs";
                this.endSize = 4;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 测试源存档
        /// </summary>
        private string Test()
        {
            int[] intFlag = new int[11];
            string SaveTestFlag = "";
            string FlagEEPROM = "0";
            double TestYellow = 15.0 / 16.0;
            int[] intTestSize = new int[11] { 0, (int)(0.5 * 1024), 8 * 1024, 64 * 1024, 128 * 1024, 256 * 1024, 512 * 1024, 1024 * 1024, 2 * 1024 * 1024, 4 * 1024 * 1024, 8 * 1024 * 1024 };
            int TestCont = 7;	//	暂时不能改为10
            int cont = 0;
            byte byteRead;

            try
            {
                if (inputFileLength == 0x82000 && passSize == 0x80000)
                {
                    FlagEEPROM = "1";
                }
                for (int j = 1; j <= TestCont; j++)
                {
                    if (buffer.Length >= intTestSize[j])
                    {
                        for (int i = intTestSize[j - 1] + 1; i <= intTestSize[j]; i++)
                        {
                            byteRead = buffer[cont++];

                            if ((byteRead == 0xff) || (byteRead == 0x00))
                            {
                                intFlag[j]++;
                            }
                        }
                        if (intFlag[j] == intTestSize[j] - intTestSize[j - 1])
                        {
                            SaveTestFlag += "3";
                        }
                        else if (intFlag[j] >= (intTestSize[j] - intTestSize[j - 1]) * TestYellow)
                        {
                            SaveTestFlag += "2";
                        }
                        else
                        {
                            SaveTestFlag += "1";
                        }
                    }
                    else
                    {
                        SaveTestFlag += "0";
                    }
                }
                SaveTestFlag += FlagEEPROM;
                return (SaveTestFlag);
            }
            catch
            {
                return ("00000000");
            }
        }

        /// <summary>
        /// 判断源存档是否为EEPROM存档
        /// </summary>
        private bool IsEEPROMFile()
        {
            byte byteRead;
            bool EEPOM = true;

            try
            {
                FileStream sri = new FileStream(inputFileName, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(sri);
                int intTestSize = (int)sri.Length;

                if (intTestSize == 520 * 1024)
                {
                    for (int i = 0; i < intTestSize; i++)
                    {
                        byteRead = r.ReadByte();

                        if ((byteRead != 0xff) && (byteRead != 0x00))
                        {
                            EEPOM = false;
                            break;
                        }
                    }
                }
                else
                {
                    EEPOM = false;
                }
                //r.Close();            //2017-02-07删除
                sri.Close();
            }
            catch
            {
                SetErrorCode = "102";
                EEPOM = false;
            }
            return EEPOM;
        }

        /// <summary>
        /// 获取存档测试结果文本
        /// </summary>
        private string GetTestText(string strFlag)
        {
            int i = new int();
            int testMin = -1, testMax = 6;
            string strTest = "";
            bool flag = true;
            string[] strTestSize = new string[8] { "0", "512B", "8K", "64K", "128K", "256K", "512K", "1M" };

            for (i = 6; i >= 0; i--)
            {
                if ((strFlag[i] == '3' || strFlag[i] == '0') && flag)
                {
                    testMax = i - 1;
                }
                else if (strFlag[i] == '2')
                {
                    testMin = i;
                    flag = false;
                }
                else if (strFlag[i] == '1')
                {
                    testMin = i;
                    break;
                }
            }

            if (testMax < testMin)
            {
                testMax = testMin;
            }

            for (i = testMin; i <= testMax; i++)
            {
                strTest += strTestSize[i + 1] + " ";
            }
            return (strTest);
        }

        #endregion

        #region 将源存档的有用数据写入buffer（4）

        /// <summary>
        /// 读取非压缩存档
        /// </summary>
        private void LoadNormalFile(string sInputName)		        //不需要预转换的源存档，正常copy数据
        {
            try
            {
                FileStream sri = new FileStream(sInputName, FileMode.Open, FileAccess.Read);
                inputFileLength = (int)sri.Length;
                BinaryReader r = new BinaryReader(sri);
                sri.Position = passSize;    //跳过passSize部分
                buffer = r.ReadBytes(this.inputFileLength - this.passSize - this.endSize);
                sri.Close();
            }
            catch
            {
                SetErrorCode = "201";
            }
        }

        /// <summary>
        /// 读取gds存档
        /// </summary>
        private void LoadGdsFile(string sInputName)                 //源存档为GDS存档的预转换
        {
            try
            {
                //打开转换前的gds格式的存档
                FileStream sInputStream = new FileStream(sInputName, FileMode.Open, FileAccess.Read);
                inputFileLength = (int)sInputStream.Length;

                //对gds格式存档中的游戏数据进行解压缩
                sInputStream.Position = 0x100;  //从0x0100开始为GZip压缩数据
                GZipStream compressionStream = new GZipStream(sInputStream, CompressionMode.Decompress);
                BinaryReader reader = new BinaryReader(compressionStream);

                //向buffer写入数据
                buffer = reader.ReadBytes(0x80000);     //最多512K字节

                //关闭原始存档文件
                reader.Close();
            }
            catch
            {
                SetErrorCode = "202";
            }
        }

        /// <summary>
        /// 读取NO$GBA压缩存档
        /// </summary>
        private void LoadNoGbaComFile(string sInputName)		//源存档为Compressed格式NO$GBA存档的预转换
        {
            buffer = new byte[512 * 1024];

            int cont;
            int MainCont = 0;
            int intByteRead = 0;
            byte tempByteRead;

            try
            {
                FileStream sri = new FileStream(sInputName, FileMode.Open, FileAccess.Read);
                inputFileLength = (int)sri.Length;
                BinaryReader r = new BinaryReader(sri);
                sri.Position = 0x50;
                //r.ReadBytes(0x50);
                do
                {
                    intByteRead = Convert.ToInt16(r.ReadByte());
                    if (intByteRead > 0x80)
                    {
                        tempByteRead = r.ReadByte();
                        cont = intByteRead - 0x80;
                        for (int i = 0; i < cont; i++)		//0x81-0xff
                        {
                            buffer[MainCont++] = tempByteRead;
                        }
                    }
                    else if (intByteRead == 0x80)
                    {
                        tempByteRead = r.ReadByte();
                        cont = Convert.ToInt16(r.ReadByte()) + Convert.ToInt16(r.ReadByte()) * 256;
                        for (int i = 0; i < cont; i++)		//0x80
                        {
                            buffer[MainCont++] = tempByteRead;
                        }
                    }
                    else if (intByteRead < 0x80 && intByteRead != 0x00)
                    {
                        cont = intByteRead;
                        for (int i = 0; i < cont; i++)		//0x01-0x7f
                        {
                            buffer[MainCont++] = r.ReadByte();
                        }
                    }
                    else if (intByteRead == 0x00)		//0x00
                    {
                        break;
                    }
                } while (MainCont < 512 * 1024);
                sri.Close();
            }
            catch
            {
                SetErrorCode = "203";
            }
        }

        /// <summary>
        /// 读取dst存档
        /// </summary>
        private void LoadDstFile(string sInputName)		            //源存档为DST格式AR存档的预转换
        {
            int MainCont = 0;
            byte[] tempBuffer = new byte[512 * 1024];

            try
            {
                FileStream sri = new FileStream(sInputName, FileMode.Open, FileAccess.Read);
                inputFileLength = (int)sri.Length;
                BinaryReader r = new BinaryReader(sri);
                sri.Position = 0x1f8;
                //r.ReadBytes(0x1f8);
                int intNum = Convert.ToInt16(r.ReadByte());			//分段的个数
                r.ReadBytes(0x3);

                ///每8K为一个分段，共intNum段
                for (int i = 0; i < intNum; i++)
                {
                    r.ReadBytes(6);
                    int intTimes = Convert.ToInt16(r.ReadByte()) * 256 + Convert.ToInt16(r.ReadByte());		//当前段需读取的字节数，包含标志位
                    int intByteTemp = Convert.ToInt16(r.ReadByte());		//标志位
                    for (int j = 1; j < intTimes; j++)
                    {
                        byte ByteRead = r.ReadByte();
                        int intByteRead = Convert.ToInt16(ByteRead);
                        if (intByteRead == intByteTemp)
                        {
                            int cont = Convert.ToInt16(r.ReadByte()) + 1;
                            j++;
                            byte tempByteRead = r.ReadByte();
                            j++;
                            for (int k = 0; k < cont; k++)
                            {
                                tempBuffer[MainCont++] = tempByteRead;
                            }
                        }
                        else
                        {
                            tempBuffer[MainCont++] = ByteRead;
                        }
                    }
                }
                sri.Close();

                buffer = new byte[MainCont];
                for (int i = 0; i < MainCont; i++)
                {
                    buffer[i] = tempBuffer[i];
                }
            }
            catch
            {
                SetErrorCode = "204";
            }
        }

        #endregion

    }
}
