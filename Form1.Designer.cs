
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
            this.checkBoxAutoName = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBoxPrikaz = new System.Windows.Forms.GroupBox();
            this.textBoxSelect = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBoxSetDB.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
            this.groupBoxPrikaz.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(22, 41);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(110, 20);
            this.labelIP.TabIndex = 0;
            this.labelIP.Text = "Nastavení DB:";
            // 
            // textBoxNastaveniDB
            // 
            this.textBoxNastaveniDB.Location = new System.Drawing.Point(193, 41);
            this.textBoxNastaveniDB.Name = "textBoxNastaveniDB";
            this.textBoxNastaveniDB.Size = new System.Drawing.Size(335, 26);
            this.textBoxNastaveniDB.TabIndex = 1;
            this.textBoxNastaveniDB.Text = "192.168.225.136";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(22, 193);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(87, 20);
            this.labelUserName.TabIndex = 2;
            this.labelUserName.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Heslo:";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsername.Location = new System.Drawing.Point(193, 193);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(175, 30);
            this.textBoxUsername.TabIndex = 4;
            this.textBoxUsername.Text = "LV_User";
            // 
            // textBoxPassw
            // 
            this.textBoxPassw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassw.Location = new System.Drawing.Point(193, 250);
            this.textBoxPassw.Name = "textBoxPassw";
            this.textBoxPassw.Size = new System.Drawing.Size(175, 30);
            this.textBoxPassw.TabIndex = 5;
            this.textBoxPassw.Text = "MySQL4LV";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "DB-Name";
            // 
            // textBoxDbName
            // 
            this.textBoxDbName.Location = new System.Drawing.Point(193, 89);
            this.textBoxDbName.Name = "textBoxDbName";
            this.textBoxDbName.Size = new System.Drawing.Size(335, 26);
            this.textBoxDbName.TabIndex = 7;
            this.textBoxDbName.Text = "valeo_prod_db";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Integrated security:";
            // 
            // checkBoxIS
            // 
            this.checkBoxIS.AutoSize = true;
            this.checkBoxIS.Location = new System.Drawing.Point(193, 142);
            this.checkBoxIS.Name = "checkBoxIS";
            this.checkBoxIS.Size = new System.Drawing.Size(64, 24);
            this.checkBoxIS.TabIndex = 9;
            this.checkBoxIS.Text = "Ano";
            this.checkBoxIS.UseVisualStyleBackColor = true;
            this.checkBoxIS.CheckedChanged += new System.EventHandler(this.checkBoxIS_CheckedChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(980, 562);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(112, 50);
            this.buttonStart.TabIndex = 10;
            this.buttonStart.Text = "BackUp";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonFileBrowser
            // 
            this.buttonFileBrowser.Location = new System.Drawing.Point(138, 82);
            this.buttonFileBrowser.Name = "buttonFileBrowser";
            this.buttonFileBrowser.Size = new System.Drawing.Size(97, 39);
            this.buttonFileBrowser.TabIndex = 11;
            this.buttonFileBrowser.Text = "Change";
            this.buttonFileBrowser.UseVisualStyleBackColor = true;
            this.buttonFileBrowser.Click += new System.EventHandler(this.buttonFileBrowser_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Umístění csv:";
            // 
            // textBoxVystup
            // 
            this.textBoxVystup.Enabled = false;
            this.textBoxVystup.Location = new System.Drawing.Point(138, 40);
            this.textBoxVystup.Name = "textBoxVystup";
            this.textBoxVystup.Size = new System.Drawing.Size(267, 26);
            this.textBoxVystup.TabIndex = 13;
            this.textBoxVystup.Text = "C:\\Users\\NIAdminFCEOL\\Desktop\\CSV";
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
            this.groupBoxSetDB.Location = new System.Drawing.Point(24, 25);
            this.groupBoxSetDB.Name = "groupBoxSetDB";
            this.groupBoxSetDB.Size = new System.Drawing.Size(555, 337);
            this.groupBoxSetDB.TabIndex = 14;
            this.groupBoxSetDB.TabStop = false;
            this.groupBoxSetDB.Text = " DB Settings";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPort.Location = new System.Drawing.Point(193, 301);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(175, 30);
            this.textBoxPort.TabIndex = 11;
            this.textBoxPort.Text = "3306";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Port";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // checkBoxService
            // 
            this.checkBoxService.AutoSize = true;
            this.checkBoxService.Location = new System.Drawing.Point(820, 579);
            this.checkBoxService.Name = "checkBoxService";
            this.checkBoxService.Size = new System.Drawing.Size(113, 24);
            this.checkBoxService.TabIndex = 15;
            this.checkBoxService.Text = "checkBox1";
            this.checkBoxService.UseVisualStyleBackColor = true;
            this.checkBoxService.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Controls.Add(this.checkBoxAutoName);
            this.groupBoxOutput.Controls.Add(this.label5);
            this.groupBoxOutput.Controls.Add(this.textBoxName);
            this.groupBoxOutput.Controls.Add(this.textBoxVystup);
            this.groupBoxOutput.Controls.Add(this.label4);
            this.groupBoxOutput.Controls.Add(this.buttonFileBrowser);
            this.groupBoxOutput.Location = new System.Drawing.Point(617, 36);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(438, 251);
            this.groupBoxOutput.TabIndex = 16;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "Output settings";
            // 
            // checkBoxAutoName
            // 
            this.checkBoxAutoName.AutoSize = true;
            this.checkBoxAutoName.Location = new System.Drawing.Point(138, 199);
            this.checkBoxAutoName.Name = "checkBoxAutoName";
            this.checkBoxAutoName.Size = new System.Drawing.Size(234, 24);
            this.checkBoxAutoName.TabIndex = 16;
            this.checkBoxAutoName.Text = "autoName dle názvu tabulky";
            this.checkBoxAutoName.UseVisualStyleBackColor = true;
            this.checkBoxAutoName.CheckedChanged += new System.EventHandler(this.checkBoxAutoName_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Název csv:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(138, 157);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(212, 26);
            this.textBoxName.TabIndex = 14;
            this.textBoxName.Text = "abc";
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // groupBoxPrikaz
            // 
            this.groupBoxPrikaz.Controls.Add(this.textBoxSelect);
            this.groupBoxPrikaz.Location = new System.Drawing.Point(24, 397);
            this.groupBoxPrikaz.Name = "groupBoxPrikaz";
            this.groupBoxPrikaz.Size = new System.Drawing.Size(1048, 146);
            this.groupBoxPrikaz.TabIndex = 17;
            this.groupBoxPrikaz.TabStop = false;
            this.groupBoxPrikaz.Text = "Command";
            // 
            // textBoxSelect
            // 
            this.textBoxSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSelect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxSelect.Location = new System.Drawing.Point(32, 41);
            this.textBoxSelect.Multiline = true;
            this.textBoxSelect.Name = "textBoxSelect";
            this.textBoxSelect.Size = new System.Drawing.Size(989, 79);
            this.textBoxSelect.TabIndex = 12;
            this.textBoxSelect.Text = "SELECT * FROM uut_result\r\n";
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1227, 640);
            this.Controls.Add(this.groupBoxPrikaz);
            this.Controls.Add(this.groupBoxOutput);
            this.Controls.Add(this.checkBoxService);
            this.Controls.Add(this.groupBoxSetDB);
            this.Controls.Add(this.buttonStart);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}

