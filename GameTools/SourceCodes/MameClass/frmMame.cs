using System;
using System.Windows.Forms;
using System.IO;

namespace AnterStudio.GameTools.MameClass
{
    public partial class frmMame : Form
    {
        int iGames = 0;
        public frmMame()
        {
            InitializeComponent();
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            string myString = OpenInputFile();

            if (myString != "")
            {
                string[] lines = File.ReadAllLines(myString);
                string[] outs1 = new string[lines.Length];
                int j = 0;
            
                for(int i=0; i<lines.Length; i++)
                {
                    lines[i] = lines[i].Replace("\t", "");
                    if(lines[i].Length > 15)
                    {
                        if (lines[i].Substring(0, 8) == "<machine") 
                        {
                            if (lines[i].IndexOf("isdevice=\"yes\"") == -1)
                            {
                                outs1[j++] = "Game\t\"" + lines[i].Split('\"')[1] + "\"";
                                iGames++;
                            }
                            else
                            {
                                outs1[j++] = "Device\t\"" + lines[i].Split('\"')[1] + "\"";
                            }
                        }
                        else if(lines[i].Substring(0, 8) == "<descrip")
                        {
                            outs1[j++] = lines[i].Replace("<description>", "\"").Replace("</description>", "\"");
                        }

                    }
                }

                string[] outs2 = new string[j / 2];
                for (int i=0;i<outs2.Length;i++)
                {
                    outs2[i] = outs1[i * 2] + "\t" + outs1[i * 2 + 1];
                }
                System.IO.File.WriteAllLines(myString + ".txt", outs2);
                MessageBox.Show("OK, "+ iGames + " games, and " + outs2.Length + " lines out.");
                iGames = 0;
            }
        }

        private string OpenInputFile()
        {
            string OpenFilter = "";

            OpenFilter += "XML Files|*.xml|";
            OpenFilter += "All Files(*.*)|*.*";
            try
            {
                OpenFileDialog dialogOpenFile = new OpenFileDialog();
                dialogOpenFile.Filter = OpenFilter;
                if (dialogOpenFile.ShowDialog() == DialogResult.OK)
                {
                    return dialogOpenFile.FileName;
                }
            }
            catch { }
            return "";
        }
    }
}
