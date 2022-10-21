
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
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonFileBrowser = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxVystup = new System.Windows.Forms.TextBox();
            this.groupBoxSetDB = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.groupBoxSetDB.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
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
            this.textBoxNastaveniDB.Text = "192.168.233.20\\SQLEXPRESS, 1433";
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
            this.textBoxUsername.Text = "jhv";
            // 
            // textBoxPassw
            // 
            this.textBoxPassw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassw.Location = new System.Drawing.Point(193, 250);
            this.textBoxPassw.Name = "textBoxPassw";
            this.textBoxPassw.PasswordChar = '*';
            this.textBoxPassw.Size = new System.Drawing.Size(175, 30);
            this.textBoxPassw.TabIndex = 5;
            this.textBoxPassw.Text = "2708";
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
            this.textBoxDbName.Text = "463_ValeoRLT";
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(426, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 39);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.label4.Location = new System.Drawing.Point(17, 40);
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
            // 
            // groupBoxSetDB
            // 
            this.groupBoxSetDB.Controls.Add(this.checkBoxIS);
            this.groupBoxSetDB.Controls.Add(this.label3);
            this.groupBoxSetDB.Controls.Add(this.textBoxDbName);
            this.groupBoxSetDB.Controls.Add(this.label1);
            this.groupBoxSetDB.Controls.Add(this.button1);
            this.groupBoxSetDB.Controls.Add(this.textBoxPassw);
            this.groupBoxSetDB.Controls.Add(this.textBoxUsername);
            this.groupBoxSetDB.Controls.Add(this.label2);
            this.groupBoxSetDB.Controls.Add(this.labelUserName);
            this.groupBoxSetDB.Controls.Add(this.textBoxNastaveniDB);
            this.groupBoxSetDB.Controls.Add(this.labelIP);
            this.groupBoxSetDB.Location = new System.Drawing.Point(24, 25);
            this.groupBoxSetDB.Name = "groupBoxSetDB";
            this.groupBoxSetDB.Size = new System.Drawing.Size(555, 314);
            this.groupBoxSetDB.TabIndex = 14;
            this.groupBoxSetDB.TabStop = false;
            this.groupBoxSetDB.Text = "Nastavení DB";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(43, 554);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(113, 24);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Controls.Add(this.textBoxVystup);
            this.groupBoxOutput.Controls.Add(this.label4);
            this.groupBoxOutput.Controls.Add(this.buttonFileBrowser);
            this.groupBoxOutput.Location = new System.Drawing.Point(617, 36);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(438, 150);
            this.groupBoxOutput.TabIndex = 16;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "Output settings";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 612);
            this.Controls.Add(this.groupBoxOutput);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBoxSetDB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxSetDB.ResumeLayout(false);
            this.groupBoxSetDB.PerformLayout();
            this.groupBoxOutput.ResumeLayout(false);
            this.groupBoxOutput.PerformLayout();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonFileBrowser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxVystup;
        private System.Windows.Forms.GroupBox groupBoxSetDB;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBoxOutput;
    }
}

