using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_to_CSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckBoxChecked();
        }
        private string GetCSV()
        {
            using (SqlConnection cn = new SqlConnection(GetConnectionString()))
            {
                cn.Open();
                string cmd = "Select TimeStampPC,Station,Status,PN,SerialNumber,WS250_DMX,Transit From ProcessData Where SerialNumber = '40437337220610'";
                if (true)
                {

                }
                return CreateCSV(new SqlCommand(cmd, cn).ExecuteReader());
            }
        }
        private string CreateCSV(IDataReader reader) //vytvoří CSV file
        {
            string hlavicka = "";
            string soubor = ""; //umístění
            List<string> radky = new List<string>(); //list pro obsah DB

            if (textBoxVystup.Text.Length != 0) //ověření zadání adresáře pro výstup
            {
                soubor = Convert.ToString(textBoxVystup.Text);
                //C:\\Users\vpivonka\Desktop\VS Projekty\test.csv
                if (reader.Read())
                {
                    string[] sloupce = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        sloupce[i] = reader.GetName(i);
                    }
                    hlavicka = string.Join(";", sloupce);
                    radky.Add(hlavicka);
                }
                while (reader.Read()) //dostane data
                {
                    object[] hodnoty = new object[reader.FieldCount];
                    reader.GetValues(hodnoty);
                    radky.Add(string.Join(";", hodnoty));
                }

            System.IO.File.WriteAllLines(soubor, radky);
            return soubor;
            }
            else
            {
                MessageBox.Show("Select output directory");
                return null;
            }

        }
        private string GetConnectionString()
        {
            string a = Convert.ToString(textBoxNastaveniDB.Text);
            string b = Convert.ToString(textBoxDbName.Text);
            string c = Convert.ToString(textBoxUsername.Text);
            string d = Convert.ToString(textBoxPassw.Text);
            string e = ";";

            if (checkBoxIS.Checked)
            {
                return "Server=" + a + e + "Database=" + b + e + "Integrated Security=true" + e;
            }
            else
            {
                return "Server=" + a + e + "Database=" + b + e + "Integrated Security=false" + e + "User ID=" + b + e + "Password=" + c + e;
            }
        }

        private void checkBoxIS_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIS.Checked)
            {
                textBoxPassw.Enabled = false;
                textBoxUsername.Enabled = false;
            }
            else
            {
                textBoxUsername.Enabled = true;
                textBoxPassw.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetCSV();
        }

        private void buttonFileBrowser_Click(object sender, EventArgs e)
        {
            using (var fDialog = new FolderBrowserDialog())
            {
                if (fDialog.ShowDialog() != DialogResult.OK)

                    return;

                System.IO.FileInfo fInfo = new System.IO.FileInfo(fDialog.SelectedPath);

                string strFilePath = fInfo.DirectoryName;

                MessageBox.Show("Vybraná cesta:" + strFilePath);

                textBoxVystup.Text = Convert.ToString(fInfo);
            }

            /*    using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string[] files = Directory.GetFiles(fbd.SelectedPath);

                        MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    }
                } */
        }
        //Server=192.168.233.20\SQLEXPRESS, 1433
        //Database=463_ValeoRLT
        //jhv
        //2708
        //
        private void CheckBoxChecked()
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "Service running";
                groupBoxSetDB.Enabled = false;
                groupBoxOutput.Enabled = false;
                
            }
            else
            {
                checkBox1.Text = "Service mode";
                groupBoxSetDB.Enabled = true;
                groupBoxOutput.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxChecked();
        }
    }
}
