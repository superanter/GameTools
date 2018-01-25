using System;
//using System.Text;

namespace AnterStudio.GameTools.DsSaveClass
{
    class MainFormInfo
    {
        #region 访问器

        public int Mode { get; set; }
        public int Size { get; set; }
        public string InputName { get; set; }
        public string OutputName { get; set; }
        public string M3LongName { get; set; }
        public string M3ShortName { get; set; }
        public string M3FileName { get; set; }
        public int CardIs { get; set; }
        public bool M3DatChecked { get; set; }
        public bool PokemonChecked { get; set; }

        #endregion

        public MainFormInfo()
        {
            Mode = 0;
            Size = 0;
            InputName = null;
            OutputName = null;
            M3LongName = null;
            M3ShortName = null;
            M3FileName = null;
            CardIs = 0;
            M3DatChecked = false;
            PokemonChecked = false;
        }

        public MainFormInfo(int mode,int size,
            string inputName,string outputName, string m3LongName,string m3ShortName,string m3FileName,
            int cardIs,bool m3DatChecked,bool pokemonChecked)
        {
            this.Mode = mode;
            this.Size = size;
            this.InputName = inputName;
            this.OutputName = outputName;
            this.M3LongName = m3LongName;
            this.M3ShortName = m3ShortName;
            this.M3FileName = m3FileName;
            this.CardIs = cardIs;
            this.M3DatChecked = m3DatChecked;
            this.PokemonChecked = pokemonChecked;
        }
    }
}
