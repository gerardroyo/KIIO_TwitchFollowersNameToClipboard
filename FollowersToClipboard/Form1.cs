using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FollowersToClipboard
{
    public partial class Form1 : Form
    {
        string filePath;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader reader = new StreamReader(File.OpenRead(@"" + filePath + ""));
                string names = "";

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        string[] values = line.Split(',');
                        if (values.Length >= 4)
                        {
                            if (values[0] != "userName")
                            {
                                names = names + values[0] + "  ";
                            }
                            else
                            {
                                //Do nothing
                            }

                        }
                    }
                }

                Clipboard.SetText(names);
                MessageBox.Show("Copiado correctamente al portapapeles");
            } catch(ArgumentException ea)
            {
                MessageBox.Show("No se pudo copiar correctamente al portapapeles");
            }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "csv",
                Filter = "csv files (*.csv)|*.csv",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbFilePath.Text = openFileDialog1.FileName;
                filePath = openFileDialog1.FileName;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

    

}
