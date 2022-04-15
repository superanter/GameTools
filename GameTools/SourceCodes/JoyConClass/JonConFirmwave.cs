//using System.Text;

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
            this.DataG = new byte[0x0d];
            for (int i = 0; i < 0x10; i++)
                this.DataA[i] = this.Data[i];
            for (int i = 0; i < 0x0d; i++)
                this.DataG[i] = this.Data[0x50 + i];

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

            for (int i = 0; i < 0x14; i++)
                this.MagicNumberData[i] = Data[0x00 + i];

            for (int i = 0; i < 0x06; i++)
                this.MACData[i] = Data[0x15 + 0x05 - i];

            for (int i = 0; i < 0x04; i++)
                this.FactoryFirmewareData[i] = Data[0x3b3 + i];

            for (int i = 0; i < 0x08; i++)
                this.OtaMagicData[i] = Data[0x1ff4 + i];

            for (int i = 0; i < 0x04; i++)
                this.OtaFirmwareData[i] = Data[0x1ffc + i];

            for (int i = 0; i < 0x1000; i++)
                this.FactorConfigurationData[i] = Data[0x6000 + i];

            for (int i = 0; i < 0x1000; i++)
                this.UserCalibrationData[i] = Data[0x8000 + i];


            FactorConfiguration = new FactorConfigurationClass(FactorConfigurationData);

            //throw new System.NotImplementedException();
        }

        #endregion

    }
}
