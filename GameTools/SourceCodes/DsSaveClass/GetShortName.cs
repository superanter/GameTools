using System;
using System.Text;                      //StringBuilder
using System.Runtime.InteropServices;   //DllImport
using System.IO;                        //FileInfo
using System.Diagnostics;               //Process


namespace AnterStudio.GameTools.DsSaveClass
{
    class GetShortName
    {
        #region 短文件名支持类（非托管）

        class NativeMethods			//非托管代码：kernel32.dll
        {
            /// <summary>  
            /// 获取文件的8.3格式短文件名  
            /// </summary>  
            /// <param name="lpszLongPath">指定的要转换的路径</param>  
            /// <param name="lpszShortPath">接收短路径形式的缓冲区</param>  
            /// <param name="cchBuffer">缓冲区的长度</param>  
            /// <returns>如果执行成功，则返回lpszShortPath接收的字符串的长度，不包括空字符；如果lpszShortPath长度太小，则返回lpszShortPath接收短路径字符串需要的长度，包括空字符；如果其他原因导致失败，则返回0</returns>  
            [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
            //private static extern int GetShortPathName([MarshalAs(UnmanagedType.LPTStr)]  string path, [MarshalAs(UnmanagedType.LPTStr)]  StringBuilder shortPath, int shortPathLength);
            internal static extern int GetShortPathName(string lpszLongPath, StringBuilder lpszShortPath, int cchBuffer);

        }

        #endregion

        #region 读取短文件名（3方法）

        private static string ToShortPathName(FileInfo fi)
        {
            StringBuilder shortNameBuffer = new StringBuilder(256);
            int bufferSize = shortNameBuffer.Capacity;
            int result = NativeMethods.GetShortPathName(fi.Name,shortNameBuffer,bufferSize);
            return shortNameBuffer.ToString();
        }

        private static string ToShortPathNameDos(FileInfo fi)
        {
            Process process = new Process();  //创建进程对象
            process.StartInfo.FileName = "cmd.exe";  //要执行的程序名

            process.StartInfo.UseShellExecute = false;  ////不使用系统外壳程序启动进程
            process.StartInfo.CreateNoWindow = true;  //不显示dos程序窗口

            //重新定向标准输入，输入，错误输出
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            process.Start();  //进程开始

            //输入dos命令
            process.StandardInput.WriteLine("cd " + fi.DirectoryName.ToString());
            process.StandardInput.WriteLine("dir /x \"" + fi.Name.ToString() + "\"");
            process.StandardInput.WriteLine("exit");

            string strRst = process.StandardOutput.ReadToEnd(); //获取结果 

            process.WaitForExit();  //等待命令结束
            process.Close();  //进程结束

            string[] stt = strRst.Replace("\r", "").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Split('\n');
            string renString = "";
            for (int i = 0; i < stt.Length; i++)
            {
                try
                {
                    string[] stt2 = stt[i].Split(' ');
                    if (stt2.Length >= 5)
                    {
                        if ((stt2[3].EndsWith(".NDS")) || (stt2[3].EndsWith(".GBA")))
                        {
                            renString = stt2[3];
                            break;
                        }
                    }
                }
                catch { }
            }
            return renString;

        }

        public static string[] M3ShortName(string strM3RomName)
        {
            string[] M3Name = new string[3];
            FileInfo fi = new FileInfo(strM3RomName);
            M3Name[0] = fi.Extension.ToLower();
            M3Name[1] = fi.Name;
            M3Name[2] = ToShortPathName(fi);
            if (M3Name[2] == "")
            {
                M3Name[2] = ToShortPathNameDos(fi);
            }
            return M3Name;
        }

        #endregion
    }
}

/*
DWORD WINAPI GetShortPathName(
  __in          LPCTSTR lpszLongPath, //指定的要转换的路径
  __out         LPTSTR lpszShortPath, //接收短路径形式的缓冲区
  __in          DWORD cchBuffer     //缓冲区的长度
);
可以通过WINAPI的GetLastError()获取出错信息
*/