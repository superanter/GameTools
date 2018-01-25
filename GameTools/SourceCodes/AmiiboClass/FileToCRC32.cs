using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

//CRC32校验码计算方法 2017-08-23更新。
namespace AnterStudio.GameTools.AmiiboClass
{
    /// <summary>
    /// CRC32校验码计算方法  2017-08-23修改
    /// </summary>
    class FileToCRC32
    {
        uint[] Crc32Table = new uint[256];

        /// <summary> 
        /// 类初始化，初始化CRC32Table。 
        /// </summary> 
        public FileToCRC32()
        {
            //产生CRC32Table
            uint Crc;
            for (int i = 0; i < 256; i++)
            {
                Crc = (uint)i;
                for (int j = 8; j > 0; j--)
                {
                    if ((Crc & 1) == 1)
                        Crc = (Crc >> 1) ^ 0xEDB88320;
                    else
                        Crc >>= 1;
                }
                Crc32Table[i] = Crc;
            }
        }

        /// <summary>
        /// 计算指定字节数组的CRC32值。
        /// </summary>
        /// <param name="buffer">要计算其CRC32代码的输入。</param>
        /// <returns>计算所得的CRC32代码。</returns>
        public String ComputeCRC32(byte[] buffer)
        {
            //判断数组是否为空
            const string FOO = "-";
            if (!buffer.IsFixedSize)
            {
                return FOO;
            }
            uint crc = 0xFFFFFFFF;

            //校验
            foreach (byte b in buffer)
            {
                crc = ((crc >> 8) & 0x00FFFFFF) ^ Crc32Table[(crc ^ b) & 0xFF];
            }
            crc = crc ^ 0xFFFFFFFF;
            return String.Format("{0:X8}", crc);
        }

        /// <summary>
        /// 计算指定字节数组的指定区域的CRC32值。
        /// </summary>
        /// <param name="buffer">要计算其CRC32代码的输入。</param>
        /// <param name="offset">字节数组中的偏移量，从该位置开始使用数据。</param>
        /// <param name="count">数组中用作数据的字节数。</param>
        /// <returns>计算所得的CRC32代码。</returns>
        public String ComputeCRC32(byte[] buffer, int offset, int count)
        {
            //判断数组是否为空
            const string FOO = "-";
            if (!buffer.IsFixedSize)
            {
                return FOO;
            }

            uint crc = 0xFFFFFFFF;

            //按长度校验
            byte[] binTest = new byte[count];
            if (buffer.Length >= count + offset)
            {
                for (int i = 0; i < count; i++)
                {
                    binTest[i] = buffer[i + offset];
                }
            }
            else
            {
                return FOO;
            }

            foreach (byte b in binTest)
            {
                crc = ((crc >> 8) & 0x00FFFFFF) ^ Crc32Table[(crc ^ b) & 0xFF];
            }

            crc = crc ^ 0xFFFFFFFF;
            return String.Format("{0:X8}", crc);
        }




        /*

        Exception	Condition
        ArgumentException	
        count 是一个无效值。
        - 或 -
        buffer 长度无效。
        ArgumentNullException	
        buffer 为 null。
        ArgumentOutOfRangeException	
        offset 超出范围。 此参数需要非负数。
        ObjectDisposedException	
        对象已释放。
        */
    }
}
