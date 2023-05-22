
namespace DB_to_CSV
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelIP = new System.Windows.Forms.Label();
            this.textBoxNastaveniDB = new System.Windows.Forms.TextBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassw = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxIS = new System.Windows.Forms.CheckBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonFileBrowser = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxVystup = new System.Windows.Forms.TextBox();
            this.groupBoxSetDB = new System.Windows.Forms.GroupBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxService = new System.Windows.Forms.CheckBox();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxAutoName = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBoxPrikaz = new System.Windows.Forms.GroupBox();
            this.textBoxSelect = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonPrikazy = new System.Windows.Forms.Button();
            this.checkBoxPrikazy = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxPrikazy = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBoxTruncate = new System.Windows.Forms.CheckBox();
            this.groupBoxSetDB.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
            this.groupBoxPrikaz.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(21, 40);
            this.labelIP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(94, 16);
            this.labelIP.TabIndex = 0;
            this.labelIP.Text = "Nastavení DB:";
            // 
            // textBoxNastaveniDB
            // 
            this.textBoxNastaveniDB.Location = new System.Drawing.Point(187, 40);
            this.textBoxNastaveniDB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxNastaveniDB.Name = "textBoxNastaveniDB";
            this.textBoxNastaveniDB.Size = new System.Drawing.Size(225, 22);
            this.textBoxNastaveniDB.TabIndex = 1;
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(21, 180);
            this.labelUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(74, 16);
            this.labelUserName.TabIndex = 2;
            this.labelUserName.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 233);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Heslo:";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsername.Location = new System.Drawing.Point(187, 180);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(118, 23);
            this.textBoxUsername.TabIndex = 4;
            // 
            // textBoxPassw
            // 
            this.textBoxPassw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassw.Location = new System.Drawing.Point(187, 233);
            this.textBoxPassw.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPassw.Name = "textBoxPassw";
            this.textBoxPassw.PasswordChar = '*';
            this.textBoxPassw.Size = new System.Drawing.Size(118, 23);
            this.textBoxPassw.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "DB-Name";
            // 
            // textBoxDbName
            // 
            this.textBoxDbName.Location = new System.Drawing.Point(187, 83);
            this.textBoxDbName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxDbName.Name = "textBoxDbName";
            this.textBoxDbName.Size = new System.Drawing.Size(225, 22);
            this.textBoxDbName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Integrated security:";
            // 
            // checkBoxIS
            // 
            this.checkBoxIS.AutoSize = true;
            this.checkBoxIS.Location = new System.Drawing.Point(187, 133);
            this.checkBoxIS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxIS.Name = "checkBoxIS";
            this.checkBoxIS.Size = new System.Drawing.Size(51, 20);
            this.checkBoxIS.TabIndex = 9;
            this.checkBoxIS.Text = "Ano";
            this.checkBoxIS.UseVisualStyleBackColor = true;
            this.checkBoxIS.CheckedChanged += new System.EventHandler(this.checkBoxIS_CheckedChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(904, 582);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(107, 46);
            this.buttonStart.TabIndex = 10;
            this.buttonStart.Text = "BackUp";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonFileBrowser
            // 
            this.buttonFileBrowser.Location = new System.Drawing.Point(133, 77);
            this.buttonFileBrowser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFileBrowser.Name = "buttonFileBrowser";
            this.buttonFileBrowser.Size = new System.Drawing.Size(95, 36);
            this.buttonFileBrowser.TabIndex = 11;
            this.buttonFileBrowser.Text = "Change";
            this.buttonFileBrowser.UseVisualStyleBackColor = true;
            this.buttonFileBrowser.Click += new System.EventHandler(this.buttonFileBrowser_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 42);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Umístění csv:";
            // 
            // textBoxVystup
            // 
            this.textBoxVystup.Enabled = false;
            this.textBoxVystup.Location = new System.Drawing.Point(133, 38);
            this.textBoxVystup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxVystup.Name = "textBoxVystup";
            this.textBoxVystup.Size = new System.Drawing.Size(179, 22);
            this.textBoxVystup.TabIndex = 13;
            // 
            // groupBoxSetDB
            // 
            this.groupBoxSetDB.Controls.Add(this.textBoxPort);
            this.groupBoxSetDB.Controls.Add(this.label6);
            this.groupBoxSetDB.Controls.Add(this.checkBoxIS);
            this.groupBoxSetDB.Controls.Add(this.label3);
            this.groupBoxSetDB.Controls.Add(this.textBoxDbName);
            this.groupBoxSetDB.Controls.Add(this.label1);
            this.groupBoxSetDB.Controls.Add(this.textBoxPassw);
            this.groupBoxSetDB.Controls.Add(this.textBoxUsername);
            this.groupBoxSetDB.Controls.Add(this.label2);
            this.groupBoxSetDB.Controls.Add(this.labelUserName);
            this.groupBoxSetDB.Controls.Add(this.textBoxNastaveniDB);
            this.groupBoxSetDB.Controls.Add(this.labelIP);
            this.groupBoxSetDB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxSetDB.Location = new System.Drawing.Point(23, 23);
            this.groupBoxSetDB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxSetDB.Name = "groupBoxSetDB";
            this.groupBoxSetDB.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxSetDB.Size = new System.Drawing.Size(533, 332);
            this.groupBoxSetDB.TabIndex = 14;
            this.groupBoxSetDB.TabStop = false;
            this.groupBoxSetDB.Text = " DB Settings";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPort.Location = new System.Drawing.Point(187, 282);
            this.textBoxPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(118, 23);
            this.textBoxPort.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 282);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Port";
            // 
            // checkBoxService
            // 
            this.checkBoxService.AutoSize = true;
            this.checkBoxService.Location = new System.Drawing.Point(751, 596);
            this.checkBoxService.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxService.Name = "checkBoxService";
            this.checkBoxService.Size = new System.Drawing.Size(114, 20);
            this.checkBoxService.TabIndex = 15;
            this.checkBoxService.Text = "Running mode";
            this.checkBoxService.UseVisualStyleBackColor = true;
            this.checkBoxService.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Controls.Add(this.label7);
            this.groupBoxOutput.Controls.Add(this.checkBoxAutoName);
            this.groupBoxOutput.Controls.Add(this.label5);
            this.groupBoxOutput.Controls.Add(this.textBoxName);
            this.groupBoxOutput.Controls.Add(this.textBoxVystup);
            this.groupBoxOutput.Controls.Add(this.label4);
            this.groupBoxOutput.Controls.Add(this.buttonFileBrowser);
            this.groupBoxOutput.Location = new System.Drawing.Point(591, 32);
            this.groupBoxOutput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxOutput.Size = new System.Drawing.Size(421, 235);
            this.groupBoxOutput.TabIndex = 16;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "Output settings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(344, 151);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = ".csv";
            // 
            // checkBoxAutoName
            // 
            this.checkBoxAutoName.AutoSize = true;
            this.checkBoxAutoName.Location = new System.Drawing.Point(133, 186);
            this.checkBoxAutoName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxAutoName.Name = "checkBoxAutoName";
            this.checkBoxAutoName.Size = new System.Drawing.Size(196, 20);
            this.checkBoxAutoName.TabIndex = 16;
            this.checkBoxAutoName.Text = "autoName dle názvu tabulky";
            this.checkBoxAutoName.UseVisualStyleBackColor = true;
            this.checkBoxAutoName.CheckedChanged += new System.EventHandler(this.checkBoxAutoName_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 149);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Název csv:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(133, 147);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(143, 22);
            this.textBoxName.TabIndex = 14;
            // 
            // groupBoxPrikaz
            // 
            this.groupBoxPrikaz.Controls.Add(this.textBoxSelect);
            this.groupBoxPrikaz.Location = new System.Drawing.Point(28, 422);
            this.groupBoxPrikaz.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxPrikaz.Name = "groupBoxPrikaz";
            this.groupBoxPrikaz.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxPrikaz.Size = new System.Drawing.Size(1007, 136);
            this.groupBoxPrikaz.TabIndex = 17;
            this.groupBoxPrikaz.TabStop = false;
            this.groupBoxPrikaz.Text = "Command";
            // 
            // textBoxSelect
            // 
            this.textBoxSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSelect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxSelect.Location = new System.Drawing.Point(39, 32);
            this.textBoxSelect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxSelect.Multiline = true;
            this.textBoxSelect.Name = "textBoxSelect";
            this.textBoxSelect.Size = new System.Drawing.Size(952, 75);
            this.textBoxSelect.TabIndex = 12;
            this.textBoxSelect.Click += new System.EventHandler(this.textBoxSelect_Click);
            // 
            // buttonPrikazy
            // 
            this.buttonPrikazy.Location = new System.Drawing.Point(939, 288);
            this.buttonPrikazy.Name = "buttonPrikazy";
            this.buttonPrikazy.Size = new System.Drawing.Size(91, 32);
            this.buttonPrikazy.TabIndex = 18;
            this.buttonPrikazy.Text = "Change";
            this.buttonPrikazy.UseVisualStyleBackColor = true;
            this.buttonPrikazy.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // checkBoxPrikazy
            // 
            this.checkBoxPrikazy.AutoSize = true;
            this.checkBoxPrikazy.Location = new System.Drawing.Point(731, 333);
            this.checkBoxPrikazy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxPrikazy.Name = "checkBoxPrikazy";
            this.checkBoxPrikazy.Size = new System.Drawing.Size(169, 20);
            this.checkBoxPrikazy.TabIndex = 19;
            this.checkBoxPrikazy.Text = "Auto příkazy ze souboru";
            this.checkBoxPrikazy.UseVisualStyleBackColor = true;
            this.checkBoxPrikazy.CheckedChanged += new System.EventHandler(this.checkBoxPrikazy_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(587, 292);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Příkazy v souboru";
            // 
            // textBoxPrikazy
            // 
            this.textBoxPrikazy.Location = new System.Drawing.Point(724, 292);
            this.textBoxPrikazy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPrikazy.Name = "textBoxPrikazy";
            this.textBoxPrikazy.ReadOnly = true;
            this.textBoxPrikazy.Size = new System.Drawing.Size(139, 22);
            this.textBoxPrikazy.TabIndex = 21;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Cornsilk;
            this.progressBar1.Location = new System.Drawing.Point(433, 586);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(217, 42);
            this.progressBar1.TabIndex = 22;
            this.progressBar1.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(303, 596);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "Průběh zálohy:";
            this.label9.Visible = false;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // checkBoxTruncate
            // 
            this.checkBoxTruncate.AutoSize = true;
            this.checkBoxTruncate.Location = new System.Drawing.Point(731, 368);
            this.checkBoxTruncate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxTruncate.Name = "checkBoxTruncate";
            this.checkBoxTruncate.Size = new System.Drawing.Size(231, 20);
            this.checkBoxTruncate.TabIndex = 24;
            this.checkBoxTruncate.Text = "Smazání tabulky po vytvoření CSV";
            this.checkBoxTruncate.UseVisualStyleBackColor = true;
            this.checkBoxTruncate.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1066, 645);
            this.Controls.Add(this.checkBoxTruncate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBoxPrikazy);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.checkBoxPrikazy);
            this.Controls.Add(this.buttonPrikazy);
            this.Controls.Add(this.groupBoxPrikaz);
            this.Controls.Add(this.groupBoxOutput);
            this.Controls.Add(this.checkBoxService);
            this.Controls.Add(this.groupBoxSetDB);
            this.Controls.Add(this.buttonStart);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = " MySQL DB to CSV backup v1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxSetDB.ResumeLayout(false);
            this.groupBoxSetDB.PerformLayout();
            this.groupBoxOutput.ResumeLayout(false);
            this.groupBoxOutput.PerformLayout();
            this.groupBoxPrikaz.ResumeLayout(false);
            this.groupBoxPrikaz.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.TextBox textBoxNastaveniDB;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxIS;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonFileBrowser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxVystup;
        private System.Windows.Forms.GroupBox groupBoxSetDB;
        private System.Windows.Forms.CheckBox checkBoxService;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private System.Windows.Forms.GroupBox groupBoxPrikaz;
        private System.Windows.Forms.TextBox textBoxSelect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxAutoName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonPrikazy;
        private System.Windows.Forms.CheckBox checkBoxPrikazy;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxPrikazy;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxTruncate;
    }
}

