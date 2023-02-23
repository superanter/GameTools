//using System.Text;
using System;

namespace AnterStudio.GameTools.JoyConClass
{
    class FactorConfigurationClass
    {
        #region 访问器
        /// <summary>
        /// Firmware数据（512KB）
        /// </summary>
        public byte[] Data { get; set; }

        /// <summary>
        /// Firmware数据（512KB）
        /// </summary>
        public byte[] DataA { get; }

        /// <summary>
        /// Firmware数据（512KB）
        /// </summary>
        public byte[] DataB{ get; }

        /// <summary>
        /// Firmware数据（512KB）
        /// </summary>
        public byte[] DataC { get; }

        /// <summary>
        /// Firmware数据（512KB）
        /// </summary>
        public byte[] DataD { get; }

        /// <summary>
        /// Firmware数据（512KB）
        /// </summary>
        public byte[] DataE { get; }

        /// <summary>
        /// Firmware数据（512KB）
        /// </summary>
        public byte[] DataF { get;}

        /// <summary>
        /// Firmware数据（512KB）
        /// </summary>
        public byte[] DataG { get; }

        /// <summary>
        /// Firmware数据（512KB）
        /// </summary>
        public byte[] DataH { get; }

        /// <summary>
        /// Firmware数据（512KB）
        /// </summary>
        public byte[] DataI { get; }

        #endregion

        #region 构造函数

        public FactorConfigurationClass()
        {
            throw new System.NotImplementedException();
        }

        public FactorConfigurationClass(byte[] Input)
        { 
            this.Data = Input;
            this.DataA = new byte[0x10];
            this.DataB = new byte[0x01];
            this.DataC = new byte[0x01];
            this.DataD = new byte[0x18];
            this.DataE = new byte[0x12];
            this.DataF = new byte[0x01];
            this.DataG = new byte[0x0D];
            this.DataH = new byte[0x18];
            this.DataI = new byte[0x12];
            Buffer.BlockCopy(this.Data, 0x00, this.DataA, 0x0, 0x10);
            Buffer.BlockCopy(this.Data, 0x12, this.DataB, 0x0, 0x01);
            Buffer.BlockCopy(this.Data, 0x1B, this.DataC, 0x0, 0x01);
            Buffer.BlockCopy(this.Data, 0x20, this.DataD, 0x0, 0x18);
            Buffer.BlockCopy(this.Data, 0x3D, this.DataE, 0x0, 0x12);
            Buffer.BlockCopy(this.Data, 0x4F, this.DataF, 0x0, 0x01);
            Buffer.BlockCopy(this.Data, 0x50, this.DataG, 0x0, 0x0D);
            Buffer.BlockCopy(this.Data, 0x80, this.DataH, 0x0, 0x18);
            Buffer.BlockCopy(this.Data, 0x98, this.DataI, 0x0, 0x12);

        }
        #endregion
    }

    class UserCalibrationClass { }

    class JoyConFirmwave
    {
        #region 访问器
        /// <summary>
        /// Firmware数据（512KB）
        /// </summary>
        public byte[] Data { get; set; }
        /// <summary>
        /// Magic Number Data
        /// </summary>
        public byte[] MagicNumberData { get;}
        /// <summary>
        /// MAC Data
        /// </summary>
        public byte[] MACData { get; }
        /// <summary>
        /// Factory Firmeware Data
        /// </summary>
        public byte[] FactoryFirmewareData { get; }
        /// <summary>
        /// OTA Magic Data
        /// </summary>
        public byte[] OtaMagicData { get; }
        /// <summary>
        /// OTA Firewave Data
        /// </summary>
        public byte[] OtaFirmwareData { get; }
        /// <summary>
        /// Faactor Configuration Data
        /// </summary>
        public byte[] FactorConfigurationData { get; }
        /// <summary>
        /// User Calibration Data
        /// </summary>
        public byte[] UserCalibrationData { get; }

        /// <summary>
        /// User Calibration Data
        /// </summary>
       public FactorConfigurationClass FactorConfiguration { get; }
        /// <summary>
        /// User Calibration Data
        /// </summary>
        //public class UserCalibrationClass {}


        #endregion

        #region 构造函数

        public JoyConFirmwave()
        {
            throw new System.NotImplementedException();
        }

        public JoyConFirmwave(byte[] Input)
        {
            this.Data = Input;
            this.MagicNumberData = new byte[0x14];
            this.MACData = new byte[0x06];
            this.FactoryFirmewareData = new byte[0x04];
            this.OtaMagicData = new byte[08];
            this.OtaFirmwareData = new byte[0x04];
            this.FactorConfigurationData = new byte[0x1000];
            this.UserCalibrationData = new byte[0x1000];

            Buffer.BlockCopy(this.Data, 0x0, this.MagicNumberData, 0x0, 0x14);
            Buffer.BlockCopy(this.Data, 0x15, this.MACData, 0, 0x06);
            Buffer.BlockCopy(this.Data, 0x3b3, this.FactoryFirmewareData,0x0,0x04);
            Buffer.BlockCopy(this.Data, 0x1ff4, this.OtaMagicData, 0x0, 0x08);
            Buffer.BlockCopy(this.Data, 0x1ffc, this.OtaFirmwareData, 0x0, 0x04);
            Buffer.BlockCopy(this.Data, 0x6000, this.FactorConfigurationData, 0x0,0x1000);
            Buffer.BlockCopy(this.Data, 0x8000, this.UserCalibrationData, 0x0, 0x1000);

            FactorConfiguration = new FactorConfigurationClass(FactorConfigurationData);

            //throw new System.NotImplementedException();
        }

        #endregion

    }
}
