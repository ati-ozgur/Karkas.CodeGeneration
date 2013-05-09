using Karkas.CodeGeneration.WinApp.UserControls;
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
            this.tabControlDatabase = new System.Windows.Forms.TabControl();
            this.tabPageTableRelated = new System.Windows.Forms.TabPage();
            this.userControlTableRelated1 = new Karkas.CodeGeneration.WinApp.UserControls.UserControlTableRelated();
            this.tabPageViewRelated = new System.Windows.Forms.TabPage();
            this.userControlViewRelated1 = new Karkas.CodeGeneration.WinApp.UserControls.UserControlViewRelated();
            this.tabPageStoredProcedures = new System.Windows.Forms.TabPage();
            this.tabPageSequences = new System.Windows.Forms.TabPage();
            this.buttonGecerliDegerleriKaydet = new System.Windows.Forms.Button();
            this.buttonOtherConnections = new System.Windows.Forms.Button();
            this.buttonKisaltmalar = new System.Windows.Forms.Button();
            this.buttonNewConnection = new System.Windows.Forms.Button();
            this.textBoxDatabaseProviders = new System.Windows.Forms.TextBox();
            this.labelDatabaseProviders = new System.Windows.Forms.Label();
            this.userControlCodeGenerationOptions1 = new Karkas.CodeGeneration.WinApp.UserControls.UserControlCodeGenerationOptions();
            this.panelListe.SuspendLayout();
            this.tabControlDatabase.SuspendLayout();
            this.tabPageTableRelated.SuspendLayout();
            this.tabPageViewRelated.SuspendLayout();
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
            this.panelListe.Controls.Add(this.tabControlDatabase);
            this.panelListe.Location = new System.Drawing.Point(2, 498);
            this.panelListe.Margin = new System.Windows.Forms.Padding(2);
            this.panelListe.Name = "panelListe";
            this.panelListe.Size = new System.Drawing.Size(604, 375);
            this.panelListe.TabIndex = 5;
            // 
            // tabControlDatabase
            // 
            this.tabControlDatabase.Controls.Add(this.tabPageTableRelated);
            this.tabControlDatabase.Controls.Add(this.tabPageViewRelated);
            this.tabControlDatabase.Controls.Add(this.tabPageStoredProcedures);
            this.tabControlDatabase.Controls.Add(this.tabPageSequences);
            this.tabControlDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDatabase.Location = new System.Drawing.Point(0, 0);
            this.tabControlDatabase.Name = "tabControlDatabase";
            this.tabControlDatabase.SelectedIndex = 0;
            this.tabControlDatabase.Size = new System.Drawing.Size(604, 375);
            this.tabControlDatabase.TabIndex = 0;
            // 
            // tabPageTableRelated
            // 
            this.tabPageTableRelated.Controls.Add(this.userControlTableRelated1);
            this.tabPageTableRelated.Location = new System.Drawing.Point(4, 22);
            this.tabPageTableRelated.Name = "tabPageTableRelated";
            this.tabPageTableRelated.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTableRelated.Size = new System.Drawing.Size(596, 349);
            this.tabPageTableRelated.TabIndex = 0;
            this.tabPageTableRelated.Text = "Table";
            this.tabPageTableRelated.UseVisualStyleBackColor = true;
            // 
            // userControlTableRelated1
            // 
            this.userControlTableRelated1.Location = new System.Drawing.Point(7, 7);
            this.userControlTableRelated1.Name = "userControlTableRelated1";
            this.userControlTableRelated1.Size = new System.Drawing.Size(569, 384);
            this.userControlTableRelated1.TabIndex = 0;
            // 
            // tabPageViewRelated
            // 
            this.tabPageViewRelated.Controls.Add(this.userControlViewRelated1);
            this.tabPageViewRelated.Location = new System.Drawing.Point(4, 22);
            this.tabPageViewRelated.Name = "tabPageViewRelated";
            this.tabPageViewRelated.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageViewRelated.Size = new System.Drawing.Size(596, 349);
            this.tabPageViewRelated.TabIndex = 1;
            this.tabPageViewRelated.Text = "View";
            this.tabPageViewRelated.UseVisualStyleBackColor = true;
            // 
            // userControlViewRelated1
            // 
            this.userControlViewRelated1.Location = new System.Drawing.Point(0, 6);
            this.userControlViewRelated1.Name = "userControlViewRelated1";
            this.userControlViewRelated1.Size = new System.Drawing.Size(524, 338);
            this.userControlViewRelated1.TabIndex = 0;
            // 
            // tabPageStoredProcedures
            // 
            this.tabPageStoredProcedures.Location = new System.Drawing.Point(4, 22);
            this.tabPageStoredProcedures.Name = "tabPageStoredProcedures";
            this.tabPageStoredProcedures.Size = new System.Drawing.Size(596, 349);
            this.tabPageStoredProcedures.TabIndex = 2;
            this.tabPageStoredProcedures.Text = "Stored Procedures";
            this.tabPageStoredProcedures.UseVisualStyleBackColor = true;
            // 
            // tabPageSequences
            // 
            this.tabPageSequences.Location = new System.Drawing.Point(4, 22);
            this.tabPageSequences.Name = "tabPageSequences";
            this.tabPageSequences.Size = new System.Drawing.Size(596, 349);
            this.tabPageSequences.TabIndex = 3;
            this.tabPageSequences.Text = "Sequences";
            this.tabPageSequences.UseVisualStyleBackColor = true;
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
            // userControlCodeGenerationOptions1
            // 
            this.userControlCodeGenerationOptions1.Location = new System.Drawing.Point(2, 0);
            this.userControlCodeGenerationOptions1.Name = "userControlCodeGenerationOptions1";
            this.userControlCodeGenerationOptions1.Size = new System.Drawing.Size(719, 493);
            this.userControlCodeGenerationOptions1.TabIndex = 20;
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
            this.Text = "Karkas  CodeGeneration WinApp";
            this.panelListe.ResumeLayout(false);
            this.tabControlDatabase.ResumeLayout(false);
            this.tabPageTableRelated.ResumeLayout(false);
            this.tabPageViewRelated.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTestConnectionString;
        private System.Windows.Forms.Label labelConnectionStatus;
        private System.Windows.Forms.Panel panelListe;
        private System.Windows.Forms.Button buttonGecerliDegerleriKaydet;
        private System.Windows.Forms.Button buttonOtherConnections;
        private System.Windows.Forms.Button buttonKisaltmalar;
        private System.Windows.Forms.Button buttonNewConnection;
        private UserControlCodeGenerationOptions userControlCodeGenerationOptions1;
        private System.Windows.Forms.TextBox textBoxDatabaseProviders;
        private System.Windows.Forms.Label labelDatabaseProviders;
        private System.Windows.Forms.TabControl tabControlDatabase;
        private System.Windows.Forms.TabPage tabPageTableRelated;
        private System.Windows.Forms.TabPage tabPageViewRelated;
        private System.Windows.Forms.TabPage tabPageStoredProcedures;
        private System.Windows.Forms.TabPage tabPageSequences;
        private UserControlTableRelated userControlTableRelated1;
        private UserControlViewRelated userControlViewRelated1;
    }
}

