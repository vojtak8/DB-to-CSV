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
using Newtonsoft.Json;

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
            textBoxPrikazy.Text = Properties.sett.Default.jsoncesta;
            checkBoxPrikazy.Checked = Properties.sett.Default.autoCMD;

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
            Properties.sett.Default.jsoncesta = textBoxPrikazy.Text;
            Properties.sett.Default.autoCMD = checkBoxPrikazy.Checked;

            Properties.sett.Default.Save();

        }
        private string GetCSV()
        {
            if (textBoxDbName.TextLength != 0 && //ověří zadání údajů, heslo a jméno jsou kontrolovány poté
                textBoxNastaveniDB.TextLength != 0 &&
                textBoxPort.TextLength != 0 )
            {
                using (MySqlConnection cn = new MySqlConnection(GetConnectionString()))
                {
                    try
                    {
                        cn.Open();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("nepodařilo se navázat spojení, zkontroluj údaje");
                        cn.Close();                        

                    }
                    string cmd = textBoxSelect.Text; //command query
                                                     //"Select TimeStampPC,Station,Status,PN,SerialNumber,WS250_DMX,Transit From ProcessData Where SerialNumber = '40437337220610'"

                    return CreateCSV(new MySqlCommand(cmd, cn).ExecuteReader());
                }
            }
            else
            {
                MessageBox.Show("Vyplňte všechny údaje potřebné k připojení");
                return null;
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
                    string nazevSouboru = SelectCheck(); //vezme název pro csv z sql commandu

                    if (nazevSouboru != null)
                    {
                        soubor = textBoxVystup.Text + @"\" + nazevSouboru + ".csv";
                    }
                }
                else if (checkBoxAutoName.Checked != true)
                {
                    soubor = textBoxVystup.Text + @"\" + textBoxName.Text + ".csv"; // example of output C:\\Users\vpivonka\Desktop\VS Projekty\test.csv
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
                return "Server=" + a + e + "Port=" + f + e + "Database=" + b + e + "Persist Security Info = True;" ;
            }
            else
            {
                //return "Server=192.168.225.136;Database=MySQL_DB_ForTSx64;Uid=myUsername;Pwd=MySQL4TS;Encrypt=true;";
                //return "Server=" + a + e + "Database=" + b + e + "Integrated Security=false" + e + "User ID=" + c + e + "Password=" + d + e;
                return "Server=" + a + e + "Port=" + f + e +"Database=" + b + e + "Uid=" + c + e + "Pwd=" + d + e;
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
            if (checkBoxPrikazy.Checked && checkBoxAutoName.Checked)
            {
                foreachJson();
            }
            else if (textBoxName.Text.Length != 0 && checkBoxAutoName.Checked == false)
            {
                GetCSV();
            }
            else if (textBoxName.Text.Length == 0 && checkBoxAutoName.Checked == false)
            {
                MessageBox.Show("Vyplňte název csv souboru nebo zapnete autoName");
            }
            else if (checkBoxAutoName.Checked == true && textBoxName.TextLength == 0)
            {
                GetCSV();
            }
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
                if (checkBoxPrikazy.Checked)
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
                    else if (textBoxPrikazy.Text.Length != 0)
                    {
                        checkBoxAutoName.Checked = true;
                        foreachJson();
                    }
                }
                else
                {
                    MessageBox.Show("Nejdřív zvolte .json soubor s příkazy, abyste mohli zapnout running mode");
                    checkBoxService.Checked = false;
                    CheckBoxChecked();
                }
            }
        }
        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
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
            if (checkBoxAutoName.Checked)
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


        private void button1_Click_1(object sender, EventArgs e)
        {
            string password = "valeo";
            using (var form = new Form())
            {
                var label = new Label() { Text = "Zadejte heslo k editaci zdrojového souboru:", Left = 10, Top = 20, Width = 200 };
                var textBox = new TextBox() { Left = 10, Top = 50, Width = 200 };
                var buttonOk = new Button() { Text = "OK", Left = 10, Width = 100, Top = 80, DialogResult = DialogResult.OK };
                var buttonCancel = new Button() { Text = "Cancel", Left = 110, Width = 100, Top = 80, DialogResult = DialogResult.Cancel };

                form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
                form.AcceptButton = buttonOk;
                form.CancelButton = buttonCancel;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MinimizeBox = false;
                form.MaximizeBox = false;

                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (textBox.Text == password)
                    {
                        // uzivatel zadal spravne heslo, takze se provede akce tlacitka                       
                        string _jsonFilePath;
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Filter = "JSON files (*.json)|*.json";
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            _jsonFilePath = openFileDialog.FileName;
                            textBoxPrikazy.Text = Convert.ToString(_jsonFilePath);

                        }
                        else
                        {
                            _jsonFilePath = null;
                            checkBoxPrikazy.Checked = false;
                            MessageBox.Show("Musíte vybrat .json soubor!");
                        }
                    }
                    else
                    {
                        // uzivatel zadal spatne heslo, takze se zobrazi chybova hlaska
                        MessageBox.Show("Špatné heslo!");
                    }
                }
            }
        }
    

        private void checkBoxPrikazy_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPrikazy.Checked)
            {
                if (textBoxPrikazy.TextLength != 0)
                {
                    textBoxSelect.Enabled = false;
                    textBoxPrikazy.Enabled = false;
                    buttonPrikazy.Enabled = false;
                }
            }
            else
            {
                textBoxSelect.Enabled = true;
                textBoxPrikazy.Enabled = true;
                buttonPrikazy.Enabled = true;
            }
        }

        private void foreachJson()
        {
            string jsonFilePath = textBoxPrikazy.Text;
            string jsonText = File.ReadAllText(jsonFilePath);
            var commands = JsonConvert.DeserializeObject<List<string>>(jsonText);
            try
            {
                if (checkBoxService.Checked)
                {

                    foreach (var command in commands)
                    {
                        try
                        {
                            textBoxSelect.Text = command;
                            GetCSV();
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Chyba v čtení json souboru či příkazu \r\n \r\n {ex.Message}");
            }
        }


        private void textBoxSelect_Click(object sender, EventArgs e)
        {
            string password = "valeo";
            if (textBoxSelect.Text != "") // pokud je textbox neprázdný
            {
                using (var form = new Form())
                {
                    var label = new Label() { Text = "Zadejte heslo pro editaci:", Left = 10, Top = 20, Width = 200 };
                    var textBox = new TextBox() { Left = 10, Top = 50, Width = 200 };
                    var buttonOk = new Button() { Text = "OK", Left = 10, Width = 100, Top = 80, DialogResult = DialogResult.OK };
                    var buttonCancel = new Button() { Text = "Cancel", Left = 110, Width = 100, Top = 80, DialogResult = DialogResult.Cancel };

                    form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
                    form.AcceptButton = buttonOk;
                    form.CancelButton = buttonCancel;
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.FormBorderStyle = FormBorderStyle.FixedDialog;
                    form.MinimizeBox = false;
                    form.MaximizeBox = false;

                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        if (textBox.Text == password)
                        {
                            textBoxSelect.ReadOnly = false;
                            // uzivatel zadal spravne heslo, takze muze editovat textbox
                        }
                        else
                        {
                            textBoxSelect.ReadOnly = true;
                            MessageBox.Show("Špatné heslo, textbox je zamčen!");
                        }
                    }
                    else
                    {
                        textBoxSelect.ReadOnly = true;
                    }
                }
            }
            else
            {
                textBoxSelect.ReadOnly = false;
            }
        }
    }
    }
