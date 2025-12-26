namespace AnterStudio.GameTools
{
    public class SoftVersionClass
    {
        public class SoftVersion
        {
            private string version;
            private string editDate;
            public string Version
            {
                get { return version; }
            }
            public string EditDate
            {
                get { return editDate; }
            }

            internal SoftVersion(string getVersion, string getEditDate)
            {
                version = getVersion;
                editDate = getEditDate;
            }
        }
        public SoftVersion MainVersion = new SoftVersion("v1.0.0", "2017-08-02");
        public SoftVersion DsSaveVersion = new SoftVersion("v2.0.2", "2018-01-26");
        public SoftVersion WiiSaveVersion = new SoftVersion("v1.1.1", "2017-08-02");
        public SoftVersion SwitchSaveVersion = new SoftVersion("v0.0.0", "2017-08-02");
        public SoftVersion DsRomVersion = new SoftVersion("v1.0.0", "2017-08-02");
        public SoftVersion AmiiboVersion = new SoftVersion("v1.1.0", "2025-12-24");
        public SoftVersion OtherToolsVersion = new SoftVersion("v1.0.0", "2017-08-18");
        public SoftVersion MameVersion = new SoftVersion("v1.0.0", "2025-12-25");
        public SoftVersion JoyConVersion = new SoftVersion("v1.0.0", "2022-04-18");
    }
}
