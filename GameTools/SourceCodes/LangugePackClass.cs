using System;
using System.Collections.Generic;
using System.Text;
using System.IO;            //FileStream

namespace AnterStudio.GameTools
{
    public class LangugePackClass
    {
        private bool isFromINI = false;

        public bool IsFromINI
        {
            get { return isFromINI; }
        }

        public cMainForm MainForm;
        public cDsRom DsRom;
        public cWiiSave WiiSave;
        public cSwitchSave SwitchSave;
        public cDsSave DsSave;
        public cAmiibo Amiibo;
        public cOtherTools OtherTools;

        public LangugePackClass()
        {
            MainForm = new cMainForm();
            DsRom = new cDsRom();
            WiiSave = new cWiiSave();
            SwitchSave = new cSwitchSave();
            DsSave = new cDsSave();
            Amiibo = new cAmiibo();
            OtherTools = new cOtherTools();
            SetDefault();
            FileInfo fileInfo = new FileInfo("LangugePack.ini");
            if (fileInfo.Exists)
            {
                isFromINI = true;
                GetINI();
            }
            else
            {
                isFromINI = false;
                CreatINI();
                GetINI();
            }
        }

        public class cMainForm
        {
            public form Form = new form();
            public lable Lable = new lable();
            public button Button = new button();

            public class form
            {
                public string Languge { get; set; }
                public string Version { get; set; }
                public string Editer { get; set; }
                public string Title { get; set; }
            }
            public class lable
            {
                public string FileName { get; set; }
                public string GameName { get; set; }
                public string GameText { get; set; }
                public string GameType { get; set; }
                public string FileSize { get; set; }
            }
            public class button
            {
                public string Open { get; set; }
                public string GoBack { get; set; }
            }
        }

        public class cDsRom
        {
            public form Form = new form();
            public lable Lable = new lable();
            public button Button = new button();

            public class form
            {
                public string Title { get; set; }
            }
            public class lable
            {
                public string FileName { get; set; }
                public string GameName { get; set; }
                public string GameText { get; set; }
                public string GameType { get; set; }
                public string FileSize { get; set; }
            }
            public class button
            {
                public string Open { get; set; }
                public string GoBack { get; set; }
            }
        }

        public class cWiiSave
        {
            public form Form = new form();
            public lable Lable = new lable();
            public button Button = new button();

            public class form
            {
                public string Title { get; set; }
            }
            public class lable
            {
                public string FileName { get; set; }
                public string GameName { get; set; }
                public string SaveText { get; set; }
                public string SaveType { get; set; }
                public string SaveSize { get; set; }
                public string SaveLanguge { get; set; }
                public string SaveIndex { get; set; }
                public string SaveTest { get; set; }
                public string SaveFolder { get; set; }

            }
            public class button
            {
                public string Open { get; set; }
                public string GoBack { get; set; }
            }
        }

        public class cSwitchSave
        {
            public form Form = new form();
            public lable Lable = new lable();
            public button Button = new button();

            public class form
            {
                public string Title { get; set; }
            }
            public class lable
            {
            }
            public class button
            {
                public string GoBack { get; set; }
            }
        }

        public class cAmiibo
        {
            public form Form = new form();
            public lable Lable = new lable();
            public button Button = new button();
            public message Message = new message();

            public class form
            {
                public string Title { get; set; }
            }
            public class lable
            {
                public string LinkURL { get; set; }
            }
            public class button
            {
                public string Open { get; set; }
                public string GoBack { get; set; }
                public string To540 { get; set; }
                public string Rename { get; set; }
                public string List { get; set; }
                public string RenameAll { get; set; }

            }
            public class message
            {
                public string OK { get; set; }
                public string Error_Rename { get; set; }
                public string Error_FileError { get; set; }
                public string Error_FileExists { get; set; }
                public string Error_To540 { get; set; }
                public string ListOpen { get; set; }
                public string Error_List { get; set; }

            }
        }

        public class cDsSave
        {
            public form Form = new form();
            public lable Lable = new lable();
            public button Button = new button();
            public checkBox CheckBox = new checkBox();
            public groupBox GroupBox = new groupBox();
            public message Message = new message();
            public error Error = new error();

            public class form
            {
                public string Title { get; set; }
            }
            public class lable
            {
                public string InputFile { get; set; }
                public string M3LongName { get; set; }
                public string M3ShortName { get; set; }
                public string OutputFile { get; set; }
                public string OutputFormat { get; set; }
                public string OutputSize { get; set; }
            }
            public class button
            {
                public string Change { get; set; }
                public string GoBack { get; set; }
                public string Open { get; set; }
                public string M3Rom { get; set; }
            }
            public class checkBox
            {
                public string M3Dat { get; set; }
                public string Pokemon { get; set; }
                public string Test { get; set; }
                public string ChangeMode { get; set; }
            }
            public class groupBox
            {
                public string ChangeMode { get; set; }
                public string M3 { get; set; }
                public string Output { get; set; }

            }
            public class message
            {
                public string ChangeOk { get; set; }
                public string SaveFile { get; set; }
                public string UsedSize { get; set; }
                public string Pokemon { get; set; }
                public string CardInfo { get; set; }
                public string InputFormat { get; set; }
                public string OutputFormat { get; set; }
                public string InputSize { get; set; }
                public string OutputSize { get; set; }
                public string DateSize { get; set; }
            }
            public class error
            {
                public string MM001 { get; set; }
                public string MM002 { get; set; }
                public string MM003 { get; set; }
                public string EI001 { get; set; }
                public string EI101 { get; set; }
                public string EI102 { get; set; }
                public string EI201 { get; set; }
                public string EI202 { get; set; }
                public string EI203 { get; set; }
                public string EI204 { get; set; }
                public string ED001 { get; set; }
                public string ED002 { get; set; }
                public string ED101 { get; set; }
                public string ED102 { get; set; }
                public string ED103 { get; set; }
                public string ED104 { get; set; }
                public string ED105 { get; set; }
                public string ED201 { get; set; }
                public string ED202 { get; set; }
                public string ED203 { get; set; }
                public string ED106 { get; set; }

            }

        }

        public class cOtherTools
        {
            public form Form = new form();
            public button Button = new button();

            public class form
            {
                public string Title { get; set; }
            }
            public class button
            {
                public string GoBack { get; set; }
            }
        }

        private void SetDefault()
        {
            //MainForm
            MainForm.Form.Languge = "简体中文";
            MainForm.Form.Version = "V1.0.0";
            MainForm.Form.Editer = "Anter";
            MainForm.Form.Title = "Anter's Game Tools";

            //DsRom
            DsRom.Form.Title = "DS ROM Tools";
            DsRom.Lable.FileName = "Rom名称";
            DsRom.Lable.GameName = "游戏名称标识";
            DsRom.Lable.GameText = "游戏识别码";
            DsRom.Lable.GameType = "游戏类型";
            DsRom.Lable.FileSize = "Rom体积";
            DsRom.Button.Open = "打开";
            DsRom.Button.GoBack = "返回";

            //WiiSave
            WiiSave.Form.Title = "Wii存档信息提取";
            WiiSave.Lable.FileName = "存档文件";
            WiiSave.Lable.GameName = "游戏名称";
            WiiSave.Lable.SaveFolder = "存档全路径";
            WiiSave.Lable.SaveIndex = "标识字符串偏移量";
            WiiSave.Lable.SaveLanguge = "版本";
            WiiSave.Lable.SaveSize = "存档格数";
            WiiSave.Lable.SaveTest = "是否为标准存档";
            WiiSave.Lable.SaveText = "标识字符串";
            WiiSave.Lable.SaveType = "类型";
            WiiSave.Button.Open = "打开";
            WiiSave.Button.GoBack = "返回";

            //SwitchSave
            SwitchSave.Form.Title = "Switch Save Tools";
            SwitchSave.Button.GoBack = "(返回)";

            //DsSave
            DsSave.Form.Title = "DS Save Tools";
            DsSave.Lable.InputFile = "源文件";
            DsSave.Lable.M3LongName = "长文件名";
            DsSave.Lable.M3ShortName = "短文件名";
            DsSave.Lable.OutputFile = "目标文件";
            DsSave.Lable.OutputFormat = "输出格式";
            DsSave.Lable.OutputSize = "输出大小";
            DsSave.Button.Change = "转换";
            DsSave.Button.GoBack = "返回";
            DsSave.Button.Open = "打开";
            DsSave.Button.M3Rom = "对应M3文件";
            DsSave.CheckBox.M3Dat = "Dat文件";
            DsSave.CheckBox.Pokemon = "口袋妖怪强制转换（512K -> 256K）";
            DsSave.CheckBox.Test = "测试";
            DsSave.GroupBox.ChangeMode = "转换模式";
            DsSave.GroupBox.M3 = "M3附加选项";
            DsSave.GroupBox.Output = "输出格式选择";

            DsSave.Message.ChangeOk = "转换完成！";
            DsSave.Message.SaveFile = "使用存档：";
            DsSave.Message.UsedSize = "有用数据可能大小：";
            DsSave.Message.Pokemon = "口袋妖怪强制转换：";
            DsSave.Message.CardInfo = "烧录卡说明：";
            DsSave.Message.InputFormat = "源存档格式：";
            DsSave.Message.OutputFormat = "转换后格式：";
            DsSave.Message.InputSize = "源存档大小：";
            DsSave.Message.OutputSize = "转换后大小：";
            DsSave.Message.DateSize = "转换前大小：";

            DsSave.Error.MM001 = "请选择源存档文件";
            DsSave.Error.MM002 = "请选择M3存档对应的ROM";
            DsSave.Error.MM003 = "本功能仅限于将体积为512K的口袋妖怪珍珠/钻石存档\n转换成256K的存档，其它类型的转换请不要选择此功能。";
            DsSave.Error.EI001 = "源存档信息提取错误";
            DsSave.Error.EI101 = "Sps格式存档文件读取错误";
            DsSave.Error.EI102 = "DSLink格式存档文件读取错误";
            DsSave.Error.EI201 = "源存档读取错误";
            DsSave.Error.EI202 = "Gds格式存档文件读取错误";
            DsSave.Error.EI203 = "No$Gba格式存档文件读取错误";
            DsSave.Error.EI204 = "Dst格式存档文件读取错误错误";
            DsSave.Error.ED001 = "正常转换时写入失败！";
            DsSave.Error.ED002 = "无法识别源存档格式，\n虽然可以转换，但转换后的存档可能无法使用。";
            DsSave.Error.ED101 = "M3附加数据写入，存档模式未知（内部错误）";
            DsSave.Error.ED102 = "M3附加数据写入，写入失败";
            DsSave.Error.ED103 = "M3附加数据写入（DAT），指定的dat存档格式未知";
            DsSave.Error.ED104 = "M3附加数据写入（DAT），写入失败";
            DsSave.Error.ED105 = "DSLink附加数据写入错误";
            DsSave.Error.ED201 = "口袋妖怪强制转换时写入失败！";
            DsSave.Error.ED202 = "口袋妖怪强制转换无法识别源存档格式。";
            DsSave.Error.ED203 = "口袋妖怪强制转换源存档体积小于512K。";
            DsSave.Error.ED106 = "DeSmuME附加数据写入错误";

            //Amiibo
            Amiibo.Form.Title = "Amiibo Tools";
            Amiibo.Lable.LinkURL = "LinkURL:";
            Amiibo.Button.GoBack = "返回";
            Amiibo.Button.Open = "打开文件";
            Amiibo.Button.To540 = "转为540B";
            Amiibo.Button.Rename = "文件改名";
            Amiibo.Message.OK = "操作完成";
            Amiibo.Message.Error_FileError = "文件错误";
            Amiibo.Message.Error_FileExists = "文件已存在";
            Amiibo.Message.Error_Rename = "重命名失败";
            Amiibo.Message.Error_To540 = "转换失败";
            Amiibo.Button.List = "提取列表";
            Amiibo.Button.RenameAll = "批量重命名";
            Amiibo.Message.ListOpen = "请选取Amiibo bin文件所在目录";
            Amiibo.Message.Error_List = "提取列表失败";

            //OtherTools
            OtherTools.Form.Title = "Other Game Tools";
            OtherTools.Button.GoBack = "返回";

        }

        private void GetINI()
        {
            string[] strLine =  File.ReadAllLines("LangugePack.ini", Encoding.Unicode);
            string[][] strLanguge = new string[strLine.Length][];
            for (int i = 0; i < strLine.Length; i++)
            {
                strLanguge[i] = strLine[i].Split('=');
            }
            foreach (string[] str in strLanguge)
            {
                #region switch
                switch (str[0])
                {
                    case "MainForm.Form.Version": MainForm.Form.Version = str[1]; break;
                    case "MainForm.Form.Languge": MainForm.Form.Languge = str[1]; break;
                    case "MainForm.Form.Editer": MainForm.Form.Editer = str[1]; break;
                    case "MainForm.Form.Title": MainForm.Form.Title = str[1]; break;
                    case "DsRom.Form.Title": DsRom.Form.Title = str[1]; break;
                    case "DsRom.Lable.FileName": DsRom.Lable.FileName = str[1]; break;
                    case "DsRom.Lable.GameName": DsRom.Lable.GameName = str[1]; break;
                    case "DsRom.Lable.GameText": DsRom.Lable.GameText = str[1]; break;
                    case "DsRom.Lable.GameType": DsRom.Lable.GameType = str[1]; break;
                    case "DsRom.Lable.FileSize": DsRom.Lable.FileSize = str[1]; break;
                    case "DsRom.Button.Open": DsRom.Button.Open = str[1]; break;
                    case "DsRom.Button.GoBack": DsRom.Button.GoBack = str[1]; break;
                    case "WiiSave.Form.Title": WiiSave.Form.Title = str[1]; break;
                    case "WiiSave.Lable.FileName": WiiSave.Lable.FileName = str[1]; break;
                    case "WiiSave.Lable.GameName": WiiSave.Lable.GameName = str[1]; break;
                    case "WiiSave.Lable.SaveFolder": WiiSave.Lable.SaveFolder = str[1]; break;
                    case "WiiSave.Lable.SaveIndex": WiiSave.Lable.SaveIndex = str[1]; break;
                    case "WiiSave.Lable.SaveLanguge": WiiSave.Lable.SaveLanguge = str[1]; break;
                    case "WiiSave.Lable.SaveSize": WiiSave.Lable.SaveSize = str[1]; break;
                    case "WiiSave.Lable.SaveTest": WiiSave.Lable.SaveTest = str[1]; break;
                    case "WiiSave.Lable.SaveText": WiiSave.Lable.SaveText = str[1]; break;
                    case "WiiSave.Lable.SaveType": WiiSave.Lable.SaveType = str[1]; break;
                    case "WiiSave.Button.Open": WiiSave.Button.Open = str[1]; break;
                    case "WiiSave.Button.GoBack": WiiSave.Button.GoBack = str[1]; break;
                    case "SwitchSave.Form.Title": SwitchSave.Form.Title = str[1]; break;
                    case "SwitchSave.Button.GoBack": SwitchSave.Button.GoBack = str[1]; break;
                    case "DsSave.Form.Title": DsSave.Form.Title = str[1]; break;
                    case "DsSave.Lable.InputFile": DsSave.Lable.InputFile = str[1]; break;
                    case "DsSave.Lable.M3LongName": DsSave.Lable.M3LongName = str[1]; break;
                    case "DsSave.Lable.M3ShortName": DsSave.Lable.M3ShortName = str[1]; break;
                    case "DsSave.Lable.OutputFile": DsSave.Lable.OutputFile = str[1]; break;
                    case "DsSave.Lable.OutputFormat": DsSave.Lable.OutputFormat = str[1]; break;
                    case "DsSave.Lable.OutputSize": DsSave.Lable.OutputSize = str[1]; break;
                    case "DsSave.Button.Change": DsSave.Button.Change = str[1]; break;
                    case "DsSave.Button.GoBack": DsSave.Button.GoBack = str[1]; break;
                    case "DsSave.Button.Open": DsSave.Button.Open = str[1]; break;
                    case "DsSave.Button.M3Rom": DsSave.Button.M3Rom = str[1]; break;
                    case "DsSave.CheckBox.M3Dat": DsSave.CheckBox.M3Dat = str[1]; break;
                    case "DsSave.CheckBox.Pokemon": DsSave.CheckBox.Pokemon = str[1]; break;
                    case "DsSave.CheckBox.Test": DsSave.CheckBox.Test = str[1]; break;
                    case "DsSave.GroupBox.ChangeMode": DsSave.GroupBox.ChangeMode = str[1]; break;
                    case "DsSave.GroupBox.M3": DsSave.GroupBox.M3 = str[1]; break;
                    case "DsSave.GroupBox.Output": DsSave.GroupBox.Output = str[1]; break;
                    case "DsSave.Message.ChangeOk": DsSave.Message.ChangeOk = str[1]; break;
                    case "DsSave.Message.SaveFile": DsSave.Message.SaveFile = str[1]; break;
                    case "DsSave.Message.UsedSize": DsSave.Message.UsedSize = str[1]; break;
                    case "DsSave.Message.Pokemon": DsSave.Message.Pokemon = str[1]; break;
                    case "DsSave.Message.CardInfo": DsSave.Message.CardInfo = str[1]; break;
                    case "DsSave.Message.InputFormat": DsSave.Message.InputFormat = str[1]; break;
                    case "DsSave.Message.OutputFormat": DsSave.Message.OutputFormat = str[1]; break;
                    case "DsSave.Message.InputSize": DsSave.Message.InputSize = str[1]; break;
                    case "DsSave.Message.OutputSize": DsSave.Message.OutputSize = str[1]; break;
                    case "DsSave.Message.DateSize": DsSave.Message.DateSize = str[1]; break;
                    case "DsSave.Error.MM001": DsSave.Error.MM001 = str[1]; break;
                    case "DsSave.Error.MM002": DsSave.Error.MM002 = str[1]; break;
                    case "DsSave.Error.MM003": DsSave.Error.MM003 = str[1]; break;
                    case "DsSave.Error.EI001": DsSave.Error.EI001 = str[1]; break;
                    case "DsSave.Error.EI101": DsSave.Error.EI101 = str[1]; break;
                    case "DsSave.Error.EI102": DsSave.Error.EI102 = str[1]; break;
                    case "DsSave.Error.EI201": DsSave.Error.EI201 = str[1]; break;
                    case "DsSave.Error.EI202": DsSave.Error.EI202 = str[1]; break;
                    case "DsSave.Error.EI203": DsSave.Error.EI203 = str[1]; break;
                    case "DsSave.Error.EI204": DsSave.Error.EI204 = str[1]; break;
                    case "DsSave.Error.ED001": DsSave.Error.ED001 = str[1]; break;
                    case "DsSave.Error.ED002": DsSave.Error.ED002 = str[1]; break;
                    case "DsSave.Error.ED101": DsSave.Error.ED101 = str[1]; break;
                    case "DsSave.Error.ED102": DsSave.Error.ED102 = str[1]; break;
                    case "DsSave.Error.ED103": DsSave.Error.ED103 = str[1]; break;
                    case "DsSave.Error.ED104": DsSave.Error.ED104 = str[1]; break;
                    case "DsSave.Error.ED105": DsSave.Error.ED105 = str[1]; break;
                    case "DsSave.Error.ED201": DsSave.Error.ED201 = str[1]; break;
                    case "DsSave.Error.ED202": DsSave.Error.ED202 = str[1]; break;
                    case "DsSave.Error.ED203": DsSave.Error.ED203 = str[1]; break;
                    case "DsSave.Error.ED106": DsSave.Error.ED106 = str[1]; break;
                    case "Amiibo.Form.Title": Amiibo.Form.Title = str[1]; break;
                    case "Amiibo.Lable.LinkURL": Amiibo.Lable.LinkURL = str[1]; break;
                    case "Amiibo.Button.GoBack": Amiibo.Button.GoBack = str[1]; break;
                    case "Amiibo.Button.Open": Amiibo.Button.Open = str[1]; break;
                    case "Amiibo.Button.To540": Amiibo.Button.To540 = str[1]; break;
                    case "Amiibo.Message.OK": Amiibo.Message.OK = str[1]; break;
                    case "Amiibo.Button.Rename": Amiibo.Button.Rename = str[1]; break;
                    case "Amiibo.Message.Error_FileError": Amiibo.Message.Error_FileError = str[1]; break;
                    case "Amiibo.Message.Error_FileExists": Amiibo.Message.Error_FileExists = str[1]; break;
                    case "Amiibo.Message.Error_Rename": Amiibo.Message.Error_Rename = str[1]; break;
                    case "Amiibo.Message.Error_To540": Amiibo.Message.Error_To540 = str[1]; break;
                    case "Amiibo.Button.List": Amiibo.Button.List = str[1]; break;
                    case "Amiibo.Button.RenameAll": Amiibo.Button.RenameAll = str[1]; break;
                    case "Amiibo.Message.ListOpen": Amiibo.Message.ListOpen = str[1]; break;
                    case "Amiibo.Message.Error_List": Amiibo.Message.Error_List = str[1]; break;
                }
                #endregion
            }
        }

        private void CreatINI()
        {
            string[] strLanguge = new string[]
            {
                #region StrLanguge
                "MainForm.Form.Languge=简体中文",
                "MainForm.Form.Version=V1.0.0.0",
                "MainForm.Form.Editer=Anter",
                "MainForm.Form.Title=Anter's Game Tools",
                "DsRom.Form.Title=DS ROM Tools",
                "DsRom.Lable.FileName=Rom名称",
                "DsRom.Lable.GameName=游戏名称标识",
                "DsRom.Lable.GameText=游戏识别码",
                "DsRom.Lable.GameType=游戏类型",
                "DsRom.Lable.FileSize=Rom体积",
                "DsRom.Button.Open=打开",
                "DsRom.Button.GoBack=返回",
                "WiiSave.Form.Title=Wii存档信息提取",
                "WiiSave.Lable.FileName=存档文件",
                "WiiSave.Lable.GameName=游戏名称",
                "WiiSave.Lable.SaveFolder=存档全路径",
                "WiiSave.Lable.SaveIndex=标识字符串偏移量",
                "WiiSave.Lable.SaveLanguge=版本",
                "WiiSave.Lable.SaveSize=存档格数",
                "WiiSave.Lable.SaveTest=是否为标准存档",
                "WiiSave.Lable.SaveText=标识字符串",
                "WiiSave.Lable.SaveType=类型",
                "WiiSave.Button.Open=打开",
                "WiiSave.Button.GoBack=返回",
                "SwitchSave.Form.Title=Switch Save Tools",
                "SwitchSave.Button.GoBack=返 回",
                "DsSave.Form.Title=DS Save Tools",
                "DsSave.Lable.InputFile=源文件",
                "DsSave.Lable.M3LongName=长文件名",
                "DsSave.Lable.M3ShortName=短文件名",
                "DsSave.Lable.OutputFile=目标文件",
                "DsSave.Lable.OutputFormat=输出格式",
                "DsSave.Lable.OutputSize=输出大小",
                "DsSave.Button.Change=转换",
                "DsSave.Button.GoBack=返回",
                "DsSave.Button.Open=打开",
                "DsSave.Button.M3Rom=对应M3文件",
                "DsSave.CheckBox.M3Dat=Dat文件",
                "DsSave.CheckBox.Pokemon=口袋妖怪强制转换（512K -> 256K）",
                "DsSave.CheckBox.Test=测试",
                "DsSave.GroupBox.ChangeMode=转换模式",
                "DsSave.GroupBox.M3=M3附加选项",
                "DsSave.GroupBox.Output=输出格式选择",
                "DsSave.Message.ChangeOk=转换完成！",
                "DsSave.Message.SaveFile=使用存档：",
                "DsSave.Message.UsedSize=有用数据可能大小：",
                "DsSave.Message.Pokemon=口袋妖怪强制转换：",
                "DsSave.Message.CardInfo=烧录卡说明：",
                "DsSave.Message.InputFormat=源存档格式：",
                "DsSave.Message.OutputFormat=转换后格式：",
                "DsSave.Message.InputSize=源存档大小：",
                "DsSave.Message.OutputSize=转换后大小：",
                "DsSave.Message.DateSize=转换前大小：",
                "DsSave.Error.MM001=请选择源存档文件",
                "DsSave.Error.MM002=请选择M3存档对应的ROM",
                "DsSave.Error.MM003=本功能仅限于将体积为512K的口袋妖怪珍珠/钻石存档转换成256K的存档，其它类型的转换请不要选择此功能。",
                "DsSave.Error.EI001=源存档信息提取错误",
                "DsSave.Error.EI101=Sps格式存档文件读取错误",
                "DsSave.Error.EI102=DSLink格式存档文件读取错误",
                "DsSave.Error.EI201=源存档读取错误",
                "DsSave.Error.EI202=Gds格式存档文件读取错误",
                "DsSave.Error.EI203=No$Gba格式存档文件读取错误",
                "DsSave.Error.EI204=Dst格式存档文件读取错误错误",
                "DsSave.Error.ED001=正常转换时写入失败！",
                "DsSave.Error.ED002=无法识别源存档格式，虽然可以转换，但转换后的存档可能无法使用。",
                "DsSave.Error.ED101=M3附加数据写入，存档模式未知（内部错误）",
                "DsSave.Error.ED102=M3附加数据写入，写入失败",
                "DsSave.Error.ED103=M3附加数据写入（DAT），指定的dat存档格式未知",
                "DsSave.Error.ED104=M3附加数据写入（DAT），写入失败",
                "DsSave.Error.ED105=DSLink附加数据写入错误",
                "DsSave.Error.ED201=口袋妖怪强制转换时写入失败！",
                "DsSave.Error.ED202=口袋妖怪强制转换无法识别源存档格式。",
                "DsSave.Error.ED203=口袋妖怪强制转换源存档体积小于512K。",
                "DsSave.Error.ED106=DeSmuME附加数据写入错误",
                "Amiibo.Form.Title=Amiibo Tools",
                "Amiibo.Lable.LinkURL=LinkURL:",
                "Amiibo.Button.GoBack= 返回",
                "Amiibo.Button.Open=打开文件",
                "Amiibo.Button.To540=转为540B",
                "Amiibo.Message.OK=操作完成",
                "Amiibo.Button.Rename=文件改名",
                "Amiibo.Message.Error_FileError=文件错误",
                "Amiibo.Message.Error_FileExists=文件已存在",
                "Amiibo.Message.Error_Rename=重命名失败",
                "Amiibo.Message.Error_To540=转换失败",
                "Amiibo.Button.List=提取列表",
                "Amiibo.Button.RenameAll=批量重命名",
                "Amiibo.Message.ListOpen=请选取Amiibo bin文件所在目录",
                "Amiibo.Message.Error_List=提取列表失败",
                "OtherTools.Form.Title=Other Game Tools",
                "OtherTools..Button.GoBack= 返回"


            #endregion
        };
            File.WriteAllLines("LangugePack.ini",strLanguge,Encoding.Unicode);
        }
    }
}
