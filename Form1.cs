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
using System.Text.RegularExpressions;
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
            GetSettings();
            CheckBoxChecked();            
        }

        private void GetSettings()
        {
            textBoxNastaveniDB.Text = Properties.sett.Default.NastaveniDB;
            textBoxDbName.Text = Properties.sett.Default.DBName;
            textBoxUsername.Text = Properties.sett.Default.Username;
            textBoxPassw.Text = Properties.sett.Default.Password;
            textBoxVystup.Text = Properties.sett.Default.location;
            textBoxName.Text = Properties.sett.Default.nazevCSV;
            textBoxPort.Text = Properties.sett.Default.port;
            textBoxSelect.Text = Properties.sett.Default.command;
            checkBoxService.Checked = Properties.sett.Default.service;

        }
        private void SaveSettings()
        {
            Properties.sett.Default.NastaveniDB = textBoxNastaveniDB.Text;
            Properties.sett.Default.DBName = textBoxDbName.Text;
            Properties.sett.Default.Username = textBoxUsername.Text;
            Properties.sett.Default.Password = textBoxPassw.Text;
            Properties.sett.Default.location = textBoxVystup.Text;
            Properties.sett.Default.nazevCSV = textBoxName.Text;
            Properties.sett.Default.port = textBoxPort.Text;
            Properties.sett.Default.command = textBoxSelect.Text;
            Properties.sett.Default.service = checkBoxService.Checked;

            Properties.sett.Default.Save();

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
                    cn.Close();
                    
                }
                string cmd = textBoxSelect.Text; //command query
                                                 //"Select TimeStampPC,Station,Status,PN,SerialNumber,WS250_DMX,Transit From ProcessData Where SerialNumber = '40437337220610'"

                return CreateCSV(new MySqlCommand(cmd, cn).ExecuteReader());
            }
        }
        private string CreateCSV(IDataReader reader)
        {
            return CreateCSV(reader, string.Empty);
        }
        private string CreateCSV(IDataReader reader, string extention) //vytvoří CSV file
        {
            string hlavicka = "";
            string soubor = ""; //umístění
            List<string> radky = new List<string>(); //list pro obsah DB

            if (textBoxVystup.Text.Length != 0 && textBoxName.Text.Length != 0 && textBoxSelect.Text.Length != 0) //ověření zadání adresáře pro výstup a selectu
            {

                if (checkBoxAutoName.Checked)
                {
                    string nazevSouboru = SelectCheck(); //vezme název pro csv z sql commandu

                    if (nazevSouboru != null)
                    {
                        soubor = textBoxVystup.Text + @"\" + nazevSouboru + extention + ".csv";      
                    }                                              
                }
                else if (checkBoxAutoName.Checked != true)
                {
                    soubor = textBoxVystup.Text + @"\" + textBoxName.Text + extention + ".csv"; // example of output C:\\Users\vpivonka\Desktop\VS Projekty\test.csv
                }
                if (CheckBoxChecked() == false) 
                {
                MessageBox.Show(Convert.ToString(soubor));
                }

                try
                {
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Chyba v zápisu sloupců a jejich názvů \r\n \r\n {ex.Message}");
                   
                }
                try
                {
                    while (reader.Read()) //dostane data
                    {
                        object[] hodnoty = new object[reader.FieldCount];
                        reader.GetValues(hodnoty);
                        radky.Add(string.Join(";", hodnoty));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Chyba v zápisu řádků do CSV \r\n \r\n {ex.Message}");
                    throw;
                }
                try
                {
                    File.WriteAllLines(soubor, radky);
                    return soubor;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Close the .csv \r\n \r\n {ex.Message}");
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
                return "Provider=MSDASQL.1;Password=MySQL4LV;Persist Security Info=True;User ID=LV_User;Data Source=MySQL_DB_ForLVx64";
            }
            else
            {
                //return "Server=192.168.225.136;Database=MySQL_DB_ForTSx64;Uid=myUsername;Pwd=MySQL4TS;Encrypt=true;";
                //return "Server=" + a + e + "Database=" + b + e + "Integrated Security=false" + e + "User ID=" + c + e + "Password=" + d + e;
                return "Server=" + a + e + "Database=" + b + e + "Uid=" + c + e + "Pwd=" + d + e;
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

        private string SelectCheck()
        {
            string myString = textBoxSelect.Text;
            string toBeSearched = "FROM";
            int ix = myString.IndexOf(toBeSearched);

                    if (ix != -1)
                    {
                        string nazevSouboru = myString.Substring(ix + toBeSearched.Length + 1);
                        var z = nazevSouboru.Split(' ')[0];

                return z;
                    }
                    else
                    {
                       MessageBox.Show("SELECT command has to contain FROM [name of table]");
                       return null;
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

                MessageBox.Show("Vybraná cesta:" + "\n" + strFilePath);

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
        private bool CheckBoxChecked()
        {
            if (checkBoxService.Checked)
            {
                checkBoxService.Text = "Service running";
                checkBoxAutoName.Checked = true;
                groupBoxSetDB.Enabled = false;
                groupBoxOutput.Enabled = false;
                groupBoxPrikaz.Enabled = false;
                buttonStart.Enabled = false;
                return true;

            }
            else
            {
                checkBoxService.Text = "Service mode";
                groupBoxSetDB.Enabled = true;
                groupBoxOutput.Enabled = true;
                groupBoxPrikaz.Enabled = true;
                buttonStart.Enabled = true;
                return false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxChecked();
            
            if (checkBoxService.Checked)
            {
                if (string.IsNullOrEmpty(textBoxVystup.Text))
                {
                    string s = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    textBoxVystup.Text = s;
                    DialogResult dialogResult = MessageBox.Show("Chcete nastavit umístění:" + s, "Nezadané umístění pro csv", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        textBoxVystup.Text = s;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        MessageBox.Show("Vyberte svoje vlastní v nastavení umístění.");
                    }
                }
                try
                {
                    textBoxSelect.Text = "";
                    textBoxSelect.Text = "SELECT * FROM prop_analogwaveform";
                    GetCSV();
                    textBoxSelect.Text = "SELECT * FROM prop_binary";
                    GetCSV();
                    textBoxSelect.Text = "SELECT * FROM prop_digitalwaveform";
                    GetCSV();
                    textBoxSelect.Text = "SELECT * FROM prop_numericlimit";
                    GetCSV();
                    textBoxSelect.Text = "SELECT * FROM prop_result";
                    GetCSV();
                    textBoxSelect.Text = "SELECT * FROM step_result";
                    GetCSV();
                    textBoxSelect.Text = "SELECT * FROM step_seqcall";
                    GetCSV();
                    textBoxSelect.Text = "SELECT * FROM uut_result"; //bude default při otevření aplikace
                    GetCSV();
                    MessageBox.Show("Záloha do .csv proběhla");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Chyba v průběhu služby \r\n \r\n {ex.Message}");
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {         

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

        private void buttonTest_Click(object sender, EventArgs e)
        {
            string s = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            String Z = SelectCheck();
            MessageBox.Show(Z + s);
        }

        private void textBoxDbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void label7_Click(object sender, EventArgs e)
        {
           
        }
        private void Bulk()
        {
            MySqlConnection conn = new MySqlConnection(GetConnectionString());
            for (int i = 0; i < 4; i++)
            {
                try
                {
                    conn.Open();
                    var datum = "1/1/";
                    var stringCommand = $"SELECT * FROM prop_numericlimit WHERE START_DATE_TIME >= CONVERT(datetime,'{datum + (2019 + i).ToString()}',22) AND START_DATE_TIME < CONVERT(datetime,'{datum + (2020 + i).ToString()}',22)";
                    var command = new MySqlCommand(stringCommand, conn);

                    var reader = command.ExecuteReader();

                    CreateCSV(reader, (2019 + i).ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Chyba v zápisu prop_numericlimit \r\n \r\n {ex.Message}");
                }
            }
            for (int i = 0; i < 4; i++)
            {
                try
                {
                    conn.Open();
                    var datum = "1/1/";
                    var stringCommand = $"SELECT * FROM prop_result WHERE START_DATE_TIME >= CONVERT(datetime,'{datum + (2019 + i).ToString()}',22) AND START_DATE_TIME < CONVERT(datetime,'{datum + (2020 + i).ToString()}',22)";
                    var command = new MySqlCommand(stringCommand, conn);

                    var reader = command.ExecuteReader();

                    CreateCSV(reader, (2019 + i).ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Chyba v zápisu prop_result \r\n \r\n {ex.Message}");
                }
            }
            for (int i = 0; i < 4; i++)
            {
                try
                {
                    conn.Open();
                    var datum = "1/1/";
                    var stringCommand = $"SELECT * FROM step_result WHERE START_DATE_TIME >= CONVERT(datetime,'{datum + (2019 + i).ToString()}',22) AND START_DATE_TIME < CONVERT(datetime,'{datum + (2020 + i).ToString()}',22)";
                    var command = new MySqlCommand(stringCommand, conn);

                    var reader = command.ExecuteReader();

                    CreateCSV(reader, (2019 + i).ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Chyba v zápisu step_result \r\n \r\n {ex.Message}");
                }
            }
            for (int i = 0; i < 4; i++)
            {
                try
                {
                    conn.Open();
                    var datum = "1/1/";
                    var stringCommand = $"SELECT * FROM step_seqcall WHERE START_DATE_TIME >= CONVERT(datetime,'{datum + (2019 + i).ToString()}',22) AND START_DATE_TIME < CONVERT(datetime,'{datum + (2020 + i).ToString()}',22)";
                    var command = new MySqlCommand(stringCommand, conn);

                    var reader = command.ExecuteReader();

                    CreateCSV(reader, (2019 + i).ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Chyba v zápisu step_seqcall \r\n \r\n {ex.Message}");
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Bulk();
        }
    }
}
