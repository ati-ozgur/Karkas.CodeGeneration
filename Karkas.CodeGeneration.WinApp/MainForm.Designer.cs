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
            this.labelConnectionString = new System.Windows.Forms.Label();
            this.textBoxConnectionString = new System.Windows.Forms.TextBox();
            this.buttonTestConnectionString = new System.Windows.Forms.Button();
            this.labelConnectionStatus = new System.Windows.Forms.Label();
            this.panelListe = new System.Windows.Forms.Panel();
            this.checkBoxDboSemasiniAtla = new System.Windows.Forms.CheckBox();
            this.buttonSeciliTablolariUret = new System.Windows.Forms.Button();
            this.buttonTumTablolariUret = new System.Windows.Forms.Button();
            this.listBoxTableListesi = new System.Windows.Forms.ListBox();
            this.labelTabloListesi = new System.Windows.Forms.Label();
            this.labelSchemaList = new System.Windows.Forms.Label();
            this.comboBoxSchemaList = new System.Windows.Forms.ComboBox();
            this.checkBoxIgnoreSystemTables = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCodeGenerationDizini = new System.Windows.Forms.TextBox();
            this.buttonFolderDialog = new System.Windows.Forms.Button();
            this.labelProjectNamespace = new System.Windows.Forms.Label();
            this.textBoxProjectNamespace = new System.Windows.Forms.TextBox();
            this.labelConnectionName = new System.Windows.Forms.Label();
            this.labelDatabaseNameSonuc = new System.Windows.Forms.Label();
            this.buttonGecerliDegerleriKaydet = new System.Windows.Forms.Button();
            this.textBoxConnectionName = new System.Windows.Forms.TextBox();
            this.buttonOtherConnections = new System.Windows.Forms.Button();
            this.comboBoxDatabaseType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonKisaltmalar = new System.Windows.Forms.Button();
            this.buttonNewConnection = new System.Windows.Forms.Button();
            this.checkBoxUseSchemaNameInFolders = new System.Windows.Forms.CheckBox();
            this.textBoxDatabaseNameLogical = new System.Windows.Forms.TextBox();
            this.labelDatabaseNameLogical = new System.Windows.Forms.Label();
            this.textBoxDatabaseNamePhysical = new System.Windows.Forms.TextBox();
            this.labelDatabaseNamePhysical = new System.Windows.Forms.Label();
            this.checkBoxUseSchemaNameInSql = new System.Windows.Forms.CheckBox();
            this.checkBoxViewCodeGenerate = new System.Windows.Forms.CheckBox();
            this.checkBoxStoredProcedureCodeGenerate = new System.Windows.Forms.CheckBox();
            this.textBoxIgnoredSchemaList = new System.Windows.Forms.TextBox();
            this.labelIgnoredSchemaList = new System.Windows.Forms.Label();
            this.textBoxAbbrevationsAsString = new System.Windows.Forms.TextBox();
            this.labelAbbrevationsAsString = new System.Windows.Forms.Label();
            this.labelDbProviderName = new System.Windows.Forms.Label();
            this.textBoxDbProviderName = new System.Windows.Forms.TextBox();
            this.panelListe.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelConnectionString
            // 
            this.labelConnectionString.AutoSize = true;
            this.labelConnectionString.Location = new System.Drawing.Point(11, 116);
            this.labelConnectionString.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConnectionString.Name = "labelConnectionString";
            this.labelConnectionString.Size = new System.Drawing.Size(91, 13);
            this.labelConnectionString.TabIndex = 0;
            this.labelConnectionString.Text = "Connection String";
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Location = new System.Drawing.Point(149, 116);
            this.textBoxConnectionString.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(469, 20);
            this.textBoxConnectionString.TabIndex = 2;
            // 
            // buttonTestConnectionString
            // 
            this.buttonTestConnectionString.Location = new System.Drawing.Point(778, 210);
            this.buttonTestConnectionString.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTestConnectionString.Name = "buttonTestConnectionString";
            this.buttonTestConnectionString.Size = new System.Drawing.Size(107, 58);
            this.buttonTestConnectionString.TabIndex = 3;
            this.buttonTestConnectionString.Text = "test";
            this.buttonTestConnectionString.UseVisualStyleBackColor = true;
            this.buttonTestConnectionString.Click += new System.EventHandler(this.buttonTestConnectionString_Click);
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.AutoSize = true;
            this.labelConnectionStatus.Location = new System.Drawing.Point(11, 414);
            this.labelConnectionStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(102, 13);
            this.labelConnectionStatus.TabIndex = 4;
            this.labelConnectionStatus.Text = "Bağlantı Denenmedi";
            // 
            // panelListe
            // 
            this.panelListe.Controls.Add(this.checkBoxDboSemasiniAtla);
            this.panelListe.Controls.Add(this.buttonSeciliTablolariUret);
            this.panelListe.Controls.Add(this.buttonTumTablolariUret);
            this.panelListe.Controls.Add(this.listBoxTableListesi);
            this.panelListe.Controls.Add(this.labelTabloListesi);
            this.panelListe.Controls.Add(this.labelSchemaList);
            this.panelListe.Controls.Add(this.comboBoxSchemaList);
            this.panelListe.Location = new System.Drawing.Point(2, 472);
            this.panelListe.Margin = new System.Windows.Forms.Padding(2);
            this.panelListe.Name = "panelListe";
            this.panelListe.Size = new System.Drawing.Size(693, 346);
            this.panelListe.TabIndex = 5;
            // 
            // checkBoxDboSemasiniAtla
            // 
            this.checkBoxDboSemasiniAtla.AutoSize = true;
            this.checkBoxDboSemasiniAtla.Checked = true;
            this.checkBoxDboSemasiniAtla.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDboSemasiniAtla.Location = new System.Drawing.Point(560, 116);
            this.checkBoxDboSemasiniAtla.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxDboSemasiniAtla.Name = "checkBoxDboSemasiniAtla";
            this.checkBoxDboSemasiniAtla.Size = new System.Drawing.Size(108, 17);
            this.checkBoxDboSemasiniAtla.TabIndex = 6;
            this.checkBoxDboSemasiniAtla.Text = "dbo şemasını Atla";
            this.checkBoxDboSemasiniAtla.UseVisualStyleBackColor = true;
            // 
            // buttonSeciliTablolariUret
            // 
            this.buttonSeciliTablolariUret.Location = new System.Drawing.Point(227, 313);
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
            this.buttonTumTablolariUret.Location = new System.Drawing.Point(560, 186);
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
            // checkBoxIgnoreSystemTables
            // 
            this.checkBoxIgnoreSystemTables.AutoSize = true;
            this.checkBoxIgnoreSystemTables.Checked = true;
            this.checkBoxIgnoreSystemTables.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIgnoreSystemTables.Location = new System.Drawing.Point(484, 235);
            this.checkBoxIgnoreSystemTables.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxIgnoreSystemTables.Name = "checkBoxIgnoreSystemTables";
            this.checkBoxIgnoreSystemTables.Size = new System.Drawing.Size(113, 17);
            this.checkBoxIgnoreSystemTables.TabIndex = 7;
            this.checkBoxIgnoreSystemTables.Text = "sys Tablolarını Atla";
            this.checkBoxIgnoreSystemTables.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 204);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Code Generation Dizini";
            // 
            // textBoxCodeGenerationDizini
            // 
            this.textBoxCodeGenerationDizini.Location = new System.Drawing.Point(149, 204);
            this.textBoxCodeGenerationDizini.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCodeGenerationDizini.Name = "textBoxCodeGenerationDizini";
            this.textBoxCodeGenerationDizini.Size = new System.Drawing.Size(468, 20);
            this.textBoxCodeGenerationDizini.TabIndex = 7;
            // 
            // buttonFolderDialog
            // 
            this.buttonFolderDialog.Location = new System.Drawing.Point(638, 201);
            this.buttonFolderDialog.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFolderDialog.Name = "buttonFolderDialog";
            this.buttonFolderDialog.Size = new System.Drawing.Size(38, 24);
            this.buttonFolderDialog.TabIndex = 8;
            this.buttonFolderDialog.Text = "...";
            this.buttonFolderDialog.UseVisualStyleBackColor = true;
            this.buttonFolderDialog.Click += new System.EventHandler(this.buttonFolderDialog_Click);
            // 
            // labelProjectNamespace
            // 
            this.labelProjectNamespace.AutoSize = true;
            this.labelProjectNamespace.Location = new System.Drawing.Point(11, 176);
            this.labelProjectNamespace.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProjectNamespace.Name = "labelProjectNamespace";
            this.labelProjectNamespace.Size = new System.Drawing.Size(100, 13);
            this.labelProjectNamespace.TabIndex = 9;
            this.labelProjectNamespace.Text = "Project Namespace";
            // 
            // textBoxProjectNamespace
            // 
            this.textBoxProjectNamespace.Location = new System.Drawing.Point(149, 176);
            this.textBoxProjectNamespace.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxProjectNamespace.Name = "textBoxProjectNamespace";
            this.textBoxProjectNamespace.Size = new System.Drawing.Size(466, 20);
            this.textBoxProjectNamespace.TabIndex = 10;
            // 
            // labelConnectionName
            // 
            this.labelConnectionName.AutoSize = true;
            this.labelConnectionName.Location = new System.Drawing.Point(11, 9);
            this.labelConnectionName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConnectionName.Name = "labelConnectionName";
            this.labelConnectionName.Size = new System.Drawing.Size(92, 13);
            this.labelConnectionName.TabIndex = 11;
            this.labelConnectionName.Text = "Connection Name";
            // 
            // labelDatabaseNameSonuc
            // 
            this.labelDatabaseNameSonuc.AutoSize = true;
            this.labelDatabaseNameSonuc.Location = new System.Drawing.Point(148, 229);
            this.labelDatabaseNameSonuc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDatabaseNameSonuc.Name = "labelDatabaseNameSonuc";
            this.labelDatabaseNameSonuc.Size = new System.Drawing.Size(0, 13);
            this.labelDatabaseNameSonuc.TabIndex = 12;
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
            // textBoxConnectionName
            // 
            this.textBoxConnectionName.Location = new System.Drawing.Point(149, 9);
            this.textBoxConnectionName.Name = "textBoxConnectionName";
            this.textBoxConnectionName.Size = new System.Drawing.Size(127, 20);
            this.textBoxConnectionName.TabIndex = 14;
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
            // comboBoxDatabaseType
            // 
            this.comboBoxDatabaseType.FormattingEnabled = true;
            this.comboBoxDatabaseType.Location = new System.Drawing.Point(148, 37);
            this.comboBoxDatabaseType.Name = "comboBoxDatabaseType";
            this.comboBoxDatabaseType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDatabaseType.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Veritabanı Tipi";
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
            // checkBoxUseSchemaNameInFolders
            // 
            this.checkBoxUseSchemaNameInFolders.AutoSize = true;
            this.checkBoxUseSchemaNameInFolders.Checked = true;
            this.checkBoxUseSchemaNameInFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseSchemaNameInFolders.Location = new System.Drawing.Point(355, 263);
            this.checkBoxUseSchemaNameInFolders.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxUseSchemaNameInFolders.Name = "checkBoxUseSchemaNameInFolders";
            this.checkBoxUseSchemaNameInFolders.Size = new System.Drawing.Size(105, 30);
            this.checkBoxUseSchemaNameInFolders.TabIndex = 20;
            this.checkBoxUseSchemaNameInFolders.Text = "Dizinlerde Şema \r\nİsmini Kullan";
            this.checkBoxUseSchemaNameInFolders.UseVisualStyleBackColor = true;
            // 
            // textBoxDatabaseNameLogical
            // 
            this.textBoxDatabaseNameLogical.Location = new System.Drawing.Point(149, 141);
            this.textBoxDatabaseNameLogical.Name = "textBoxDatabaseNameLogical";
            this.textBoxDatabaseNameLogical.Size = new System.Drawing.Size(127, 20);
            this.textBoxDatabaseNameLogical.TabIndex = 22;
            // 
            // labelDatabaseNameLogical
            // 
            this.labelDatabaseNameLogical.AutoSize = true;
            this.labelDatabaseNameLogical.Location = new System.Drawing.Point(11, 141);
            this.labelDatabaseNameLogical.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDatabaseNameLogical.Name = "labelDatabaseNameLogical";
            this.labelDatabaseNameLogical.Size = new System.Drawing.Size(121, 13);
            this.labelDatabaseNameLogical.TabIndex = 21;
            this.labelDatabaseNameLogical.Text = "Database Name Logical";
            // 
            // textBoxDatabaseNamePhysical
            // 
            this.textBoxDatabaseNamePhysical.Enabled = false;
            this.textBoxDatabaseNamePhysical.Location = new System.Drawing.Point(438, 146);
            this.textBoxDatabaseNamePhysical.Name = "textBoxDatabaseNamePhysical";
            this.textBoxDatabaseNamePhysical.Size = new System.Drawing.Size(127, 20);
            this.textBoxDatabaseNamePhysical.TabIndex = 24;
            // 
            // labelDatabaseNamePhysical
            // 
            this.labelDatabaseNamePhysical.AutoSize = true;
            this.labelDatabaseNamePhysical.Location = new System.Drawing.Point(300, 146);
            this.labelDatabaseNamePhysical.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDatabaseNamePhysical.Name = "labelDatabaseNamePhysical";
            this.labelDatabaseNamePhysical.Size = new System.Drawing.Size(126, 13);
            this.labelDatabaseNamePhysical.TabIndex = 23;
            this.labelDatabaseNamePhysical.Text = "Database Name Physical";
            // 
            // checkBoxUseSchemaNameInSql
            // 
            this.checkBoxUseSchemaNameInSql.AutoSize = true;
            this.checkBoxUseSchemaNameInSql.Checked = true;
            this.checkBoxUseSchemaNameInSql.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseSchemaNameInSql.Location = new System.Drawing.Point(355, 229);
            this.checkBoxUseSchemaNameInSql.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxUseSchemaNameInSql.Name = "checkBoxUseSchemaNameInSql";
            this.checkBoxUseSchemaNameInSql.Size = new System.Drawing.Size(110, 30);
            this.checkBoxUseSchemaNameInSql.TabIndex = 8;
            this.checkBoxUseSchemaNameInSql.Text = "Sorgularda Şema \r\nİsmini Kullan";
            this.checkBoxUseSchemaNameInSql.UseVisualStyleBackColor = true;
            // 
            // checkBoxViewCodeGenerate
            // 
            this.checkBoxViewCodeGenerate.AutoSize = true;
            this.checkBoxViewCodeGenerate.Checked = true;
            this.checkBoxViewCodeGenerate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxViewCodeGenerate.Location = new System.Drawing.Point(153, 235);
            this.checkBoxViewCodeGenerate.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxViewCodeGenerate.Name = "checkBoxViewCodeGenerate";
            this.checkBoxViewCodeGenerate.Size = new System.Drawing.Size(124, 17);
            this.checkBoxViewCodeGenerate.TabIndex = 25;
            this.checkBoxViewCodeGenerate.Text = "View Code Generate";
            this.checkBoxViewCodeGenerate.UseVisualStyleBackColor = true;
            // 
            // checkBoxStoredProcedureCodeGenerate
            // 
            this.checkBoxStoredProcedureCodeGenerate.AutoSize = true;
            this.checkBoxStoredProcedureCodeGenerate.Checked = true;
            this.checkBoxStoredProcedureCodeGenerate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStoredProcedureCodeGenerate.Location = new System.Drawing.Point(153, 275);
            this.checkBoxStoredProcedureCodeGenerate.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxStoredProcedureCodeGenerate.Name = "checkBoxStoredProcedureCodeGenerate";
            this.checkBoxStoredProcedureCodeGenerate.Size = new System.Drawing.Size(184, 17);
            this.checkBoxStoredProcedureCodeGenerate.TabIndex = 26;
            this.checkBoxStoredProcedureCodeGenerate.Text = "Stored Procedure Code Generate";
            this.checkBoxStoredProcedureCodeGenerate.UseVisualStyleBackColor = true;
            // 
            // textBoxIgnoredSchemaList
            // 
            this.textBoxIgnoredSchemaList.Location = new System.Drawing.Point(148, 335);
            this.textBoxIgnoredSchemaList.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxIgnoredSchemaList.Name = "textBoxIgnoredSchemaList";
            this.textBoxIgnoredSchemaList.Size = new System.Drawing.Size(469, 20);
            this.textBoxIgnoredSchemaList.TabIndex = 28;
            // 
            // labelIgnoredSchemaList
            // 
            this.labelIgnoredSchemaList.AutoSize = true;
            this.labelIgnoredSchemaList.Location = new System.Drawing.Point(10, 335);
            this.labelIgnoredSchemaList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIgnoredSchemaList.Name = "labelIgnoredSchemaList";
            this.labelIgnoredSchemaList.Size = new System.Drawing.Size(104, 13);
            this.labelIgnoredSchemaList.TabIndex = 27;
            this.labelIgnoredSchemaList.Text = "Ignored Schema List";
            // 
            // textBoxAbbrevationsAsString
            // 
            this.textBoxAbbrevationsAsString.Location = new System.Drawing.Point(147, 371);
            this.textBoxAbbrevationsAsString.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAbbrevationsAsString.Name = "textBoxAbbrevationsAsString";
            this.textBoxAbbrevationsAsString.Size = new System.Drawing.Size(469, 20);
            this.textBoxAbbrevationsAsString.TabIndex = 30;
            // 
            // labelAbbrevationsAsString
            // 
            this.labelAbbrevationsAsString.AutoSize = true;
            this.labelAbbrevationsAsString.Location = new System.Drawing.Point(9, 371);
            this.labelAbbrevationsAsString.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAbbrevationsAsString.Name = "labelAbbrevationsAsString";
            this.labelAbbrevationsAsString.Size = new System.Drawing.Size(57, 13);
            this.labelAbbrevationsAsString.TabIndex = 29;
            this.labelAbbrevationsAsString.Text = "Kısaltmalar";
            // 
            // labelDbProviderName
            // 
            this.labelDbProviderName.AutoSize = true;
            this.labelDbProviderName.Location = new System.Drawing.Point(9, 73);
            this.labelDbProviderName.Name = "labelDbProviderName";
            this.labelDbProviderName.Size = new System.Drawing.Size(88, 13);
            this.labelDbProviderName.TabIndex = 32;
            this.labelDbProviderName.Text = "DbProviderName";
            // 
            // textBoxDbProviderName
            // 
            this.textBoxDbProviderName.Location = new System.Drawing.Point(149, 70);
            this.textBoxDbProviderName.Name = "textBoxDbProviderName";
            this.textBoxDbProviderName.Size = new System.Drawing.Size(127, 20);
            this.textBoxDbProviderName.TabIndex = 33;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 815);
            this.Controls.Add(this.textBoxDbProviderName);
            this.Controls.Add(this.labelDbProviderName);
            this.Controls.Add(this.textBoxAbbrevationsAsString);
            this.Controls.Add(this.labelAbbrevationsAsString);
            this.Controls.Add(this.textBoxIgnoredSchemaList);
            this.Controls.Add(this.labelIgnoredSchemaList);
            this.Controls.Add(this.checkBoxIgnoreSystemTables);
            this.Controls.Add(this.checkBoxStoredProcedureCodeGenerate);
            this.Controls.Add(this.checkBoxViewCodeGenerate);
            this.Controls.Add(this.textBoxDatabaseNamePhysical);
            this.Controls.Add(this.labelDatabaseNamePhysical);
            this.Controls.Add(this.textBoxDatabaseNameLogical);
            this.Controls.Add(this.labelDatabaseNameLogical);
            this.Controls.Add(this.checkBoxUseSchemaNameInFolders);
            this.Controls.Add(this.checkBoxUseSchemaNameInSql);
            this.Controls.Add(this.buttonNewConnection);
            this.Controls.Add(this.buttonKisaltmalar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDatabaseType);
            this.Controls.Add(this.buttonOtherConnections);
            this.Controls.Add(this.textBoxConnectionName);
            this.Controls.Add(this.buttonGecerliDegerleriKaydet);
            this.Controls.Add(this.labelDatabaseNameSonuc);
            this.Controls.Add(this.labelConnectionName);
            this.Controls.Add(this.textBoxProjectNamespace);
            this.Controls.Add(this.labelProjectNamespace);
            this.Controls.Add(this.buttonFolderDialog);
            this.Controls.Add(this.textBoxCodeGenerationDizini);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelListe);
            this.Controls.Add(this.labelConnectionStatus);
            this.Controls.Add(this.buttonTestConnectionString);
            this.Controls.Add(this.textBoxConnectionString);
            this.Controls.Add(this.labelConnectionString);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panelListe.ResumeLayout(false);
            this.panelListe.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelConnectionString;
        private System.Windows.Forms.TextBox textBoxConnectionString;
        private System.Windows.Forms.Button buttonTestConnectionString;
        private System.Windows.Forms.Label labelConnectionStatus;
        private System.Windows.Forms.Panel panelListe;
        private System.Windows.Forms.Label labelSchemaList;
        private System.Windows.Forms.ComboBox comboBoxSchemaList;
        private System.Windows.Forms.Label labelTabloListesi;
        private System.Windows.Forms.ListBox listBoxTableListesi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCodeGenerationDizini;
        private System.Windows.Forms.Button buttonFolderDialog;
        private System.Windows.Forms.Button buttonSeciliTablolariUret;
        private System.Windows.Forms.Button buttonTumTablolariUret;
        private System.Windows.Forms.Label labelProjectNamespace;
        private System.Windows.Forms.TextBox textBoxProjectNamespace;
        private System.Windows.Forms.Label labelConnectionName;
        private System.Windows.Forms.Label labelDatabaseNameSonuc;
        private System.Windows.Forms.Button buttonGecerliDegerleriKaydet;
        private System.Windows.Forms.CheckBox checkBoxIgnoreSystemTables;
        private System.Windows.Forms.CheckBox checkBoxDboSemasiniAtla;
        private System.Windows.Forms.TextBox textBoxConnectionName;
        private System.Windows.Forms.Button buttonOtherConnections;
        private System.Windows.Forms.ComboBox comboBoxDatabaseType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonKisaltmalar;
        private System.Windows.Forms.Button buttonNewConnection;
        private System.Windows.Forms.CheckBox checkBoxUseSchemaNameInFolders;
        private System.Windows.Forms.TextBox textBoxDatabaseNameLogical;
        private System.Windows.Forms.Label labelDatabaseNameLogical;
        private System.Windows.Forms.TextBox textBoxDatabaseNamePhysical;
        private System.Windows.Forms.Label labelDatabaseNamePhysical;
        private System.Windows.Forms.CheckBox checkBoxUseSchemaNameInSql;
        private System.Windows.Forms.CheckBox checkBoxViewCodeGenerate;
        private System.Windows.Forms.CheckBox checkBoxStoredProcedureCodeGenerate;
        private System.Windows.Forms.TextBox textBoxIgnoredSchemaList;
        private System.Windows.Forms.Label labelIgnoredSchemaList;
        private System.Windows.Forms.TextBox textBoxAbbrevationsAsString;
        private System.Windows.Forms.Label labelAbbrevationsAsString;
        private System.Windows.Forms.Label labelDbProviderName;
        private System.Windows.Forms.TextBox textBoxDbProviderName;
    }
}

