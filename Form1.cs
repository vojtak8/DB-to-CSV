using MySql.Data.MySqlClient;
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
            using (MySqlConnection cn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    cn.Open();                  
                }
                catch (Exception)
                {

                    MessageBox.Show("nepodařilo se navázat spojení");
                    throw;
                }
                string cmd = textBoxSelect.Text;
                //"Select TimeStampPC,Station,Status,PN,SerialNumber,WS250_DMX,Transit From ProcessData Where SerialNumber = '40437337220610'"

                return CreateCSV(new MySqlCommand(cmd, cn).ExecuteReader());
            }
        }
        private string CreateCSV(IDataReader reader) //vytvoří CSV file
        {
            string hlavicka = "";
            string soubor = ""; //umístění
            List<string> radky = new List<string>(); //list pro obsah DB

            if (textBoxVystup.Text.Length != 0 && textBoxName.Text.Length != 0 && textBoxSelect.Text.Length != 0) //ověření zadání adresáře pro výstup a selectu
            {

                if (checkBoxAutoName.Checked)
                {
                    string myString = textBoxSelect.Text;
                    string toBeSearched = "FROM ";
                    int ix = myString.IndexOf(toBeSearched);

                    if (ix != -1)
                    {
                        string nazevSouboru = myString.Substring(ix + toBeSearched.Length);
                        soubor = textBoxVystup.Text + @"\" + nazevSouboru + ".csv";
                    }
                    else
                    {
                        MessageBox.Show("SELECT command has to contain FROM [name of table]");
                    }
                }
                else if (checkBoxAutoName.Checked != true)
                {
                    soubor = textBoxVystup.Text + @"\" + textBoxName.Text + ".csv";
                }
                //C:\\Users\vpivonka\Desktop\VS Projekty\test.csv
                MessageBox.Show(Convert.ToString(soubor));
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

                try
                {
                    File.WriteAllLines(soubor, radky);                   
                    return soubor;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Close the .csv" + "\n" + e.Message);
                    return null;
                }
            
            
            }
            else
            {
                MessageBox.Show("Select output directory or insert file name");
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
            string f = Convert.ToString(textBoxPort.Text);

            if (checkBoxIS.Checked)
            {
                return "Server=" + a + e + "Database=" + b + e + "Integrated Security=true" + e;
            }
            else
            {
                //return "Server=192.168.225.136;Database=MySQL_DB_ForTSx64;Uid=myUsername;Pwd=MySQL4TS;Encrypt=true;";
                //return "Server=" + a + e + "Database=" + b + e + "Integrated Security=false" + e + "User ID=" + c + e + "Password=" + d + e;
                return "Server=" + a + e +/*"Port=" + f + e +*/ "Database=" + b + e + "Uid=" + c + e + "Pwd=" + d + e + "default command timeout=0" + e;
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
            if (checkBoxService.Checked)
            {
                checkBoxService.Text = "Service running";
                groupBoxSetDB.Enabled = false;
                groupBoxOutput.Enabled = false;
                groupBoxPrikaz.Enabled = false;               

            }
            else
            {
                checkBoxService.Text = "Service mode";
                groupBoxSetDB.Enabled = true;
                groupBoxOutput.Enabled = true;
                groupBoxPrikaz.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxChecked();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkBoxService.Checked)
            {
                GetCSV();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxAutoName_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAutoName.Checked )
            {
                textBoxName.Enabled = false;
            }
            else
            {
                textBoxName.Enabled = true;
            }
            
        }
    }
}
