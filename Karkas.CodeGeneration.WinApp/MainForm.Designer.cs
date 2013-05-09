namespace Karkas.CodeGeneration.WinApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonTestConnectionString = new System.Windows.Forms.Button();
            this.labelConnectionStatus = new System.Windows.Forms.Label();
            this.panelListe = new System.Windows.Forms.Panel();
            this.buttonSeciliTablolariUret = new System.Windows.Forms.Button();
            this.buttonTumTablolariUret = new System.Windows.Forms.Button();
            this.listBoxTableListesi = new System.Windows.Forms.ListBox();
            this.labelTabloListesi = new System.Windows.Forms.Label();
            this.labelSchemaList = new System.Windows.Forms.Label();
            this.comboBoxSchemaList = new System.Windows.Forms.ComboBox();
            this.buttonGecerliDegerleriKaydet = new System.Windows.Forms.Button();
            this.buttonOtherConnections = new System.Windows.Forms.Button();
            this.buttonKisaltmalar = new System.Windows.Forms.Button();
            this.buttonNewConnection = new System.Windows.Forms.Button();
            this.userControlCodeGenerationOptions1 = new Karkas.CodeGeneration.WinApp.UserControlCodeGenerationOptions();
            this.textBoxDatabaseProviders = new System.Windows.Forms.TextBox();
            this.labelDatabaseProviders = new System.Windows.Forms.Label();
            this.panelListe.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonTestConnectionString
            // 
            this.buttonTestConnectionString.Location = new System.Drawing.Point(775, 251);
            this.buttonTestConnectionString.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTestConnectionString.Name = "buttonTestConnectionString";
            this.buttonTestConnectionString.Size = new System.Drawing.Size(149, 58);
            this.buttonTestConnectionString.TabIndex = 3;
            this.buttonTestConnectionString.Text = "test";
            this.buttonTestConnectionString.UseVisualStyleBackColor = true;
            this.buttonTestConnectionString.Click += new System.EventHandler(this.buttonTestConnectionString_Click);
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.AutoSize = true;
            this.labelConnectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelConnectionStatus.Location = new System.Drawing.Point(774, 207);
            this.labelConnectionStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(153, 20);
            this.labelConnectionStatus.TabIndex = 4;
            this.labelConnectionStatus.Text = "Bağlantı Denenmedi";
            // 
            // panelListe
            // 
            this.panelListe.Controls.Add(this.buttonSeciliTablolariUret);
            this.panelListe.Controls.Add(this.buttonTumTablolariUret);
            this.panelListe.Controls.Add(this.listBoxTableListesi);
            this.panelListe.Controls.Add(this.labelTabloListesi);
            this.panelListe.Controls.Add(this.labelSchemaList);
            this.panelListe.Controls.Add(this.comboBoxSchemaList);
            this.panelListe.Location = new System.Drawing.Point(2, 498);
            this.panelListe.Margin = new System.Windows.Forms.Padding(2);
            this.panelListe.Name = "panelListe";
            this.panelListe.Size = new System.Drawing.Size(591, 320);
            this.panelListe.TabIndex = 5;
            // 
            // buttonSeciliTablolariUret
            // 
            this.buttonSeciliTablolariUret.Location = new System.Drawing.Point(377, 99);
            this.buttonSeciliTablolariUret.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSeciliTablolariUret.Name = "buttonSeciliTablolariUret";
            this.buttonSeciliTablolariUret.Size = new System.Drawing.Size(121, 31);
            this.buttonSeciliTablolariUret.TabIndex = 5;
            this.buttonSeciliTablolariUret.Text = "Seçili Tablolari Üret";
            this.buttonSeciliTablolariUret.UseVisualStyleBackColor = true;
            this.buttonSeciliTablolariUret.Click += new System.EventHandler(this.buttonSeciliTablolariUret_Click);
            // 
            // buttonTumTablolariUret
            // 
            this.buttonTumTablolariUret.Location = new System.Drawing.Point(377, 55);
            this.buttonTumTablolariUret.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTumTablolariUret.Name = "buttonTumTablolariUret";
            this.buttonTumTablolariUret.Size = new System.Drawing.Size(121, 23);
            this.buttonTumTablolariUret.TabIndex = 4;
            this.buttonTumTablolariUret.Text = "Tüm Tabloları Üret";
            this.buttonTumTablolariUret.UseVisualStyleBackColor = true;
            this.buttonTumTablolariUret.Click += new System.EventHandler(this.buttonTumTablolariUret_Click);
            // 
            // listBoxTableListesi
            // 
            this.listBoxTableListesi.DisplayMember = "FULL_TABLE_NAME";
            this.listBoxTableListesi.FormattingEnabled = true;
            this.listBoxTableListesi.Location = new System.Drawing.Point(145, 55);
            this.listBoxTableListesi.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxTableListesi.Name = "listBoxTableListesi";
            this.listBoxTableListesi.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxTableListesi.Size = new System.Drawing.Size(204, 251);
            this.listBoxTableListesi.TabIndex = 3;
            // 
            // labelTabloListesi
            // 
            this.labelTabloListesi.AutoSize = true;
            this.labelTabloListesi.Location = new System.Drawing.Point(15, 53);
            this.labelTabloListesi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTabloListesi.Name = "labelTabloListesi";
            this.labelTabloListesi.Size = new System.Drawing.Size(66, 13);
            this.labelTabloListesi.TabIndex = 2;
            this.labelTabloListesi.Text = "Tablo Listesi";
            // 
            // labelSchemaList
            // 
            this.labelSchemaList.AutoSize = true;
            this.labelSchemaList.Location = new System.Drawing.Point(15, 13);
            this.labelSchemaList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSchemaList.Name = "labelSchemaList";
            this.labelSchemaList.Size = new System.Drawing.Size(78, 13);
            this.labelSchemaList.TabIndex = 1;
            this.labelSchemaList.Text = "Schema Listesi";
            // 
            // comboBoxSchemaList
            // 
            this.comboBoxSchemaList.DisplayMember = "TABLE_SCHEMA";
            this.comboBoxSchemaList.FormattingEnabled = true;
            this.comboBoxSchemaList.Location = new System.Drawing.Point(148, 15);
            this.comboBoxSchemaList.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSchemaList.Name = "comboBoxSchemaList";
            this.comboBoxSchemaList.Size = new System.Drawing.Size(182, 21);
            this.comboBoxSchemaList.TabIndex = 0;
            // 
            // buttonGecerliDegerleriKaydet
            // 
            this.buttonGecerliDegerleriKaydet.Location = new System.Drawing.Point(778, 141);
            this.buttonGecerliDegerleriKaydet.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGecerliDegerleriKaydet.Name = "buttonGecerliDegerleriKaydet";
            this.buttonGecerliDegerleriKaydet.Size = new System.Drawing.Size(146, 55);
            this.buttonGecerliDegerleriKaydet.TabIndex = 13;
            this.buttonGecerliDegerleriKaydet.Text = "Geçerli Değerleri Kaydet";
            this.buttonGecerliDegerleriKaydet.UseVisualStyleBackColor = true;
            this.buttonGecerliDegerleriKaydet.Click += new System.EventHandler(this.buttonGecerliDegerleriKaydet_Click);
            // 
            // buttonOtherConnections
            // 
            this.buttonOtherConnections.Location = new System.Drawing.Point(778, 12);
            this.buttonOtherConnections.Name = "buttonOtherConnections";
            this.buttonOtherConnections.Size = new System.Drawing.Size(146, 23);
            this.buttonOtherConnections.TabIndex = 15;
            this.buttonOtherConnections.Text = "Diğer Bağlantılar";
            this.buttonOtherConnections.UseVisualStyleBackColor = true;
            this.buttonOtherConnections.Click += new System.EventHandler(this.buttonOtherConnections_Click);
            // 
            // buttonKisaltmalar
            // 
            this.buttonKisaltmalar.Location = new System.Drawing.Point(778, 87);
            this.buttonKisaltmalar.Name = "buttonKisaltmalar";
            this.buttonKisaltmalar.Size = new System.Drawing.Size(146, 23);
            this.buttonKisaltmalar.TabIndex = 18;
            this.buttonKisaltmalar.Text = "Kısaltmalar";
            this.buttonKisaltmalar.UseVisualStyleBackColor = true;
            this.buttonKisaltmalar.Click += new System.EventHandler(this.buttonKisaltmalar_Click);
            // 
            // buttonNewConnection
            // 
            this.buttonNewConnection.Location = new System.Drawing.Point(778, 42);
            this.buttonNewConnection.Name = "buttonNewConnection";
            this.buttonNewConnection.Size = new System.Drawing.Size(146, 23);
            this.buttonNewConnection.TabIndex = 19;
            this.buttonNewConnection.Text = "Yeni Bağlantı";
            this.buttonNewConnection.UseVisualStyleBackColor = true;
            this.buttonNewConnection.Click += new System.EventHandler(this.buttonNewConnection_Click);
            // 
            // userControlCodeGenerationOptions1
            // 
            this.userControlCodeGenerationOptions1.Location = new System.Drawing.Point(2, 0);
            this.userControlCodeGenerationOptions1.Name = "userControlCodeGenerationOptions1";
            this.userControlCodeGenerationOptions1.Size = new System.Drawing.Size(719, 493);
            this.userControlCodeGenerationOptions1.TabIndex = 20;
            // 
            // textBoxDatabaseProviders
            // 
            this.textBoxDatabaseProviders.Location = new System.Drawing.Point(611, 522);
            this.textBoxDatabaseProviders.Multiline = true;
            this.textBoxDatabaseProviders.Name = "textBoxDatabaseProviders";
            this.textBoxDatabaseProviders.Size = new System.Drawing.Size(176, 184);
            this.textBoxDatabaseProviders.TabIndex = 21;
            this.textBoxDatabaseProviders.Text = "System.Data.SqlClient\r\nSystem.Data.OracleClient\r\nOracle.DataAccess.Client\r\nSystem" +
    ".Data.SQLite\r\n";
            // 
            // labelDatabaseProviders
            // 
            this.labelDatabaseProviders.AutoSize = true;
            this.labelDatabaseProviders.Location = new System.Drawing.Point(611, 498);
            this.labelDatabaseProviders.Name = "labelDatabaseProviders";
            this.labelDatabaseProviders.Size = new System.Drawing.Size(100, 13);
            this.labelDatabaseProviders.TabIndex = 22;
            this.labelDatabaseProviders.Text = "Database Providers";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 868);
            this.Controls.Add(this.labelDatabaseProviders);
            this.Controls.Add(this.textBoxDatabaseProviders);
            this.Controls.Add(this.userControlCodeGenerationOptions1);
            this.Controls.Add(this.buttonNewConnection);
            this.Controls.Add(this.buttonKisaltmalar);
            this.Controls.Add(this.buttonOtherConnections);
            this.Controls.Add(this.buttonGecerliDegerleriKaydet);
            this.Controls.Add(this.panelListe);
            this.Controls.Add(this.labelConnectionStatus);
            this.Controls.Add(this.buttonTestConnectionString);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panelListe.ResumeLayout(false);
            this.panelListe.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTestConnectionString;
        private System.Windows.Forms.Label labelConnectionStatus;
        private System.Windows.Forms.Panel panelListe;
        private System.Windows.Forms.Label labelSchemaList;
        private System.Windows.Forms.ComboBox comboBoxSchemaList;
        private System.Windows.Forms.Label labelTabloListesi;
        private System.Windows.Forms.ListBox listBoxTableListesi;
        private System.Windows.Forms.Button buttonSeciliTablolariUret;
        private System.Windows.Forms.Button buttonTumTablolariUret;
        private System.Windows.Forms.Button buttonGecerliDegerleriKaydet;
        private System.Windows.Forms.Button buttonOtherConnections;
        private System.Windows.Forms.Button buttonKisaltmalar;
        private System.Windows.Forms.Button buttonNewConnection;
        private UserControlCodeGenerationOptions userControlCodeGenerationOptions1;
        private System.Windows.Forms.TextBox textBoxDatabaseProviders;
        private System.Windows.Forms.Label labelDatabaseProviders;
    }
}

