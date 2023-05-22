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
using System.Threading;

namespace DB_to_CSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            GetSettings();
            CheckBoxChecked();
            tableNames.Clear();
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(10));
                if (checkBoxService.Checked && !isForeachRunning)
                {                   
                    await foreachJson();
                }
            }
            catch (Exception)
            {
                checkBoxService.Checked = false;
                throw;
            }
        }

        public static List<string> tableNames = new List<string>();

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
            checkBoxPrikazy.Checked = Properties.sett.Default.autoCMD;
            checkBoxService.Checked = Properties.sett.Default.service;
            textBoxPrikazy.Text = Properties.sett.Default.jsoncesta;
            checkBoxTruncate.Checked = Properties.sett.Default.checkBoxTruncate;



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
            Properties.sett.Default.checkBoxTruncate = checkBoxPrikazy.Checked;

            Properties.sett.Default.Save();

        }
        private string GetCSV()
        {
            if (textBoxDbName.TextLength != 0 && //ověří zadání údajů, heslo a jméno jsou kontrolovány poté kvůli možnosti integrated security
                textBoxNastaveniDB.TextLength != 0 &&
                textBoxPort.TextLength != 0 )
            {
                using (MySqlConnection cn = new MySqlConnection(GetConnectionString()))
                {
                    try
                    {
                        cn.Open();
                    }
                    catch (Exception ex)
                    {                       
                        cn.Close();                        

                    }
                    string cmd = textBoxSelect.Text; //command query
                    
                                                       
                    return CreateCSV(new MySqlCommand(cmd, cn).ExecuteReader());
                }
            }
            else
            {
                MessageBox.Show("Vyplňte všechny údaje potřebné k připojení");
                return null;
            }
        }
        private string CreateCSV(IDataReader reader)
        {
            string header = "";
            string file = "";
            List<string> rows = new List<string>();
            int rowsInFile = 0;          
            string fileName = SelectCheck();
            int rowsInTable = CountRowsInTable(fileName);

            if (textBoxVystup.Text.Length != 0 && textBoxName.Text.Length != 0 && textBoxSelect.Text.Length != 0)
            {
                if (checkBoxAutoName.Checked) // přidávání verzí, když soubor existuje
                {                
                    if (fileName != null)
                    {
                        string path = textBoxVystup.Text;
                        string name = fileName + ".csv";
                        int version = 1;
                        string newName;

                        file = path + @"\" + name;

                        while (File.Exists(file))
                        {
                            newName = path + @"\" + fileName + "_v" + version + ".csv";
                            file = newName;
                            version++;
                        }
                    }
                }
                else if (checkBoxAutoName.Checked != true)
                {
                    file = textBoxVystup.Text + @"\" + textBoxName.Text + ".csv";
                }
                if (CheckBoxChecked() == false)
                {
                    MessageBox.Show(Convert.ToString(file));
                }
                try
                {
                    if (reader.Read())
                    {
                        string[] columns = new string[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            columns[i] = reader.GetName(i);
                        }
                        header = string.Join(";", columns);
                        rows.Add(header);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Chyba v psaní sloupců a jejich názvů \r\n \r\n {ex.Message}");
                }

                try
                {
                    using (var writer = new StreamWriter(file, false, Encoding.UTF8))
                    {
                        writer.WriteLine(header);

                        while (reader.Read())
                        {
                            object[] values = new object[reader.FieldCount];
                            reader.GetValues(values);
                            for (int i = 0; i < values.Length; i++)
                            {
                                if (values[i] != null && values[i] != DBNull.Value)
                                {
                                    string value = values[i].ToString();
                                    value = value.Replace(Environment.NewLine, " ");
                                    value = value.Replace("\r", " "); 
                                    value = value.Replace("\n", " ");
                                    value = value.Replace(";", ":"); //nahrazování středníku za dvojtečku
                                    values[i] = value;
                                }
                            }
                            string row = string.Join(";", values);
                            writer.WriteLine(row);
                            rowsInFile++;
                        }
                    }   
                    
                    CompareRows(rowsInFile, rowsInTable, fileName); //porovnání pro mazání obsahu tabulky po záloze do csv
                                                              
                    return file;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Záloha se nepodařila" + e.ToString());
                    tableNames.Clear();
                    throw;
                }

            }
            else
            {
                MessageBox.Show("Vyberte cílovou destinaci nebo vložte název souboru");
                return null;
            }
        }
        private int CountRowsInTable(string tableName)
        {
            using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(*) FROM {tableName}", connection))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count;
                }
            }
        }
        private void CompareRows(int rowsInFile, int rowsInTable, string tableName)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");            
            string reportFile = "report.txt"; // Zápis do souboru report 
            
            if (rowsInTable == 0 && rowsInFile == 0)
            {
                int rowsInTable1 = rowsInTable;
                string reportBadText = $"Počet řádků v tabulce {tableName} se nerovná. Počet řádků v CSV souboru: " + rowsInFile + " a počet řádků v databázové tabulce: " + rowsInTable1 + ".." + date;
                string reportSuccessText = $"Zálohování tabulky {tableName} proběhlo úspěšně {date}";
                if (rowsInFile != rowsInTable1)
                {
                    if (File.Exists(reportFile))
                    {
                        File.AppendAllText(reportFile, Environment.NewLine + reportBadText);
                       
                    }
                    else
                    {
                        File.WriteAllText(reportFile, reportBadText);
                       
                    }
                }
                else if (rowsInFile == rowsInTable1)
                {
                    if (File.Exists(reportFile))
                    {
                        File.AppendAllText(reportFile, Environment.NewLine + reportSuccessText);
                        File.AppendAllText(reportFile, $"Tabulka {tableName} v SQL je prázdná.");

                    }
                    else
                    {
                        File.WriteAllText(reportFile, reportSuccessText);
                        File.WriteAllText(reportFile, $"Tabulka {tableName} v SQL je prázdná.");

                    }
                }
              
            }
            else
            {
                int rowsInTable1 = rowsInTable - 1;
                string reportBadText = $"Počet řádků v tabulce {tableName} se nerovná. Počet řádků v CSV souboru: " + rowsInFile + " a počet řádků v databázové tabulce: " + rowsInTable1 + ".." + date;
                string reportSuccessText = $"Zálohování tabulky {tableName} proběhlo úspěšně {date}";
                if (rowsInFile != rowsInTable1)
                {
                    if (File.Exists(reportFile))
                    {
                        File.AppendAllText(reportFile, Environment.NewLine + reportBadText);
                       
                    }
                    else
                    {
                        File.WriteAllText(reportFile, reportBadText);
                     
                    }
                }
                else if (rowsInFile == rowsInTable1)
                {
                    
                    tableNames.Add(tableName); // přidání názvu tabulky do listu

                    if (File.Exists(reportFile))
                    {
                        string TruncateText = $"TRUNCATE {tableName} proběhl úspěšně {date}";
                        File.AppendAllText(reportFile, Environment.NewLine + reportSuccessText + "\r\n" + TruncateText);
                        
                    }
                    else
                    {
                        string TruncateText = $"TRUNCATE {tableName} proběhl úspěšně {date}";
                        File.WriteAllText(reportFile, reportSuccessText + "\r\n" + TruncateText);                      
                    }
                }                          
            }
        }

        

        private void ClearTable(string tableName, MySqlConnection connection)
        {                                    
                using (MySqlCommand cmd = new MySqlCommand($"TRUNCATE TABLE {tableName};", connection))
                {
                    cmd.ExecuteNonQuery();
                }
                           
        }
        private string GetConnectionString() //nastavení připojení
        {
            string a = Convert.ToString(textBoxNastaveniDB.Text);
            string b = Convert.ToString(textBoxDbName.Text);
            string c = Convert.ToString(textBoxUsername.Text);
            string d = Convert.ToString(textBoxPassw.Text);
            string e = ";";
            string f = Convert.ToString(textBoxPort.Text);

            if (checkBoxIS.Checked)
            {
                return "Server=" + a + e + "Port=" + f + e + "Database=" + b + e + "Persist Security Info = True;" + "Connection Timeout = 3000;";
            }
            else
            {
                //return "Server=192.168.225.136;Database=MySQL_DB_ForTSx64;Uid=myUsername;Pwd=MySQL4TS;Encrypt=true;";
                //return "Server=" + a + e + "Database=" + b + e + "Integrated Security=false" + e + "User ID=" + c + e + "Password=" + d + e;
                return "Server=" + a + e + "Port=" + f + e +"Database=" + b + e + "Uid=" + c + e + "Pwd=" + d + e + "Connection Timeout = 3000;";
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

        private string SelectCheck()// vyhledá název pro csv soubor, první slovo po FROM
        {
            string myString = textBoxSelect.Text; //
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
                MessageBox.Show("SELECT musí obsahovat FROM název tabulky.");
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
                MessageBox.Show("Vyplňte název csv souboru nebo zapnete autoName.");
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
        }

        private bool CheckBoxChecked()
        {
            if (checkBoxService.Checked)
            {
                checkBoxService.Text = "Service is running";
                checkBoxAutoName.Checked = true;
                groupBoxSetDB.Enabled = false;
                groupBoxOutput.Enabled = false;
                groupBoxPrikaz.Enabled = false;
                buttonStart.Enabled = false;
                buttonPrikazy.Enabled = false;
                checkBoxPrikazy.Enabled = false;
                checkBoxTruncate.Enabled = false;
                textBoxPrikazy.Enabled = false;
                return true;

            }
            else
            {
                checkBoxService.Text = "Service mode";
                groupBoxSetDB.Enabled = true;
                groupBoxOutput.Enabled = true;
                groupBoxPrikaz.Enabled = true;
                buttonStart.Enabled = true;
                buttonPrikazy.Enabled = true;
                checkBoxPrikazy.Enabled = true;
                checkBoxTruncate.Enabled = true;
                textBoxPrikazy.Enabled = true;
                return false;
            }
        }

        public bool isForeachRunning = false;
        private async void checkBox1_CheckedChanged(object sender, EventArgs e)
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
                    else if (textBoxPrikazy.Text.Length != 0 && isForeachRunning == false)
                    {
                            checkBoxAutoName.Checked = true;                           
                            await foreachJson(); // spuštění funkce v novém vláknu                           
                   }
                }
                else
                {
                    MessageBox.Show("Nejdřív zvolte .json soubor s příkazy a označte auto příkazy ze souboru, abyste mohli zapnout running mode");
                    checkBoxService.Checked = false;
                    CheckBoxChecked();
                }
            }
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


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {          
            SaveSettings();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string password = "valeo";
            using (var form = new Form())
            {
                var label = new Label() { Text = "Zadejte heslo k editaci souboru:", Left = 10, Top = 20, Width = 200 };
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

        private async Task foreachJson()
        {
            // checkBoxService.Enabled = false;

            if (isForeachRunning == false)
            {
                label9.Visible = true;
                progressBar1.Visible = true;
                progressBar1.Value = 10;
                progressBar1.Style = ProgressBarStyle.Continuous;
                
                try
                {
                    string jsonFilePath = textBoxPrikazy.Text;
                    if (File.Exists(jsonFilePath))
                    {
                        isForeachRunning = true;
                        string jsonText = File.ReadAllText(jsonFilePath);
                        var commands = JsonConvert.DeserializeObject<List<string>>(jsonText);
                        progressBar1.Step = commands.Count;

                        if (checkBoxService.Checked)
                        {
                            foreach (var command in commands)
                            {
                                if (checkBoxService.Checked == true)
                                {
                                    try
                                    {
                                        textBoxSelect.Text = command;

                                        Task getCSVTask = Task.Run(() => GetCSV());

                                        await getCSVTask;
                                    }

                                    catch (Exception e)
                                    {
                                        MessageBox.Show("Záloha selhala." + e.ToString());
                                        break;
                                    }
                                    finally
                                    {
                                        progressBar1.PerformStep();
                                    }
                                }

                            }
                            if (checkBoxTruncate.Checked == true)
                            {
                                
                                    using (MySqlConnection connection = new MySqlConnection(GetConnectionString()))
                                    {
                                        connection.Open();

                                        foreach (string tableName in tableNames)
                                        {
                                            ClearTable(tableName, connection);
                                        }
                                        connection.Close();
                                    }
                                
                                
                            }
                            progressBar1.Value = progressBar1.Maximum;
                            tableNames.Clear();
                            
                        }

                        ShowAutoClosingMessageBox();
                        Thread.Sleep(20000); // wait for 20 seconds                    
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Soubor .json neexistuje.");
                        isForeachRunning = false;
                        tableNames.Clear();
                        checkBoxService.Checked = false;
                        CheckBoxChecked();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Chyba v čtení json souboru či příkazu \r\n \r\n {ex.Message}");
                    checkBoxService.Checked = false;
                    CheckBoxChecked();
                    label9.Visible = false;
                    progressBar1.Visible = false;

                }
                finally
                {
                    isForeachRunning = false;
                }
            }
            else
            {
                    MessageBox.Show("Funkce již běží.");
                    isForeachRunning = false;
            }
        }
        private void ShowAutoClosingMessageBox()
        {

            System.Threading.Timer timer = null;

            timer = new System.Threading.Timer((o) =>
            {
                if (MessageBox.Show("Záloha vytvořena, Zkontrolujte report.txt.. Aplikace se sama zavře za 20 sekund.", "", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    timer.Dispose();
                }
            },
            null, 0, 20000);
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
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
 }
