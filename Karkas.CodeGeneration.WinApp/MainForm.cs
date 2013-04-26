using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Karkas.Core.DataUtil;
using Karkas.CodeGeneration.SqlServer;
using System.Reflection;
using System.Data.Common;
using System.Runtime.Remoting;
using Karkas.CodeGenerationHelper;
using Karkas.CodeGeneration.Oracle;
using Karkas.CodeGenerationHelper.Interfaces;
using Karkas.CodeGeneration.WinApp.PersistenceService;
using Karkas.CodeGeneration.SqliteSupport.TypeLibrary.Main;
using Karkas.CodeGeneration.Sqlite;
using Karkas.CodeGeneration.Helper;
using Karkas.CodeGeneration.Oracle.Implementations;
using Karkas.CodeGeneration.Sqlite.Implementations;
using Karkas.CodeGeneration.SqlServer.Implementations;

namespace Karkas.CodeGeneration.WinApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            comboBoxDatabaseType.DataSource = DatabaseType.DatabaseTypeList;

            panelListeDisable();

            getLastAccessedConnectionToTextbox();
            


        }

        private DatabaseEntry currentDatabaseEntry = null;

        private void getLastAccessedConnectionToTextbox()
        {
            DatabaseEntry entry = DatabaseService.getLastAccessedDatabaseEntry();

            if (entry != null)
            {
                databaseEntryToForm(entry);
            }
        }

        private void databaseEntryToForm(DatabaseEntry entry)
        {
            currentDatabaseEntry = entry;

            if (!string.IsNullOrWhiteSpace(entry.ConnectionString))
            {
                textBoxConnectionString.Text = entry.ConnectionString;
            }
            if (!string.IsNullOrWhiteSpace(entry.CodeGenerationDirectory))
            {
                textBoxCodeGenerationDizini.Text = entry.CodeGenerationDirectory;
            }
            if (!string.IsNullOrWhiteSpace(entry.CodeGenerationNamespace))
            {
                textBoxProjectNamespace.Text = entry.CodeGenerationNamespace;
            }
            textBoxDatabaseName.Text = entry.ConnectionName;
            comboBoxDatabaseType.SelectedItem = entry.ConnectionDatabaseType;
        }


        DbConnection connection;
        AdoTemplate template;
        private void buttonTestConnectionString_Click(object sender, EventArgs e)
        {
            string connectionString = textBoxConnectionString.Text;



            try
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                String type = comboBoxDatabaseType.SelectedItem.ToString();
                if (type == null || type == DatabaseType.SqlServer)
                {
                    testSqlServer(connectionString,textBoxDatabaseName.Text);
                }
                else if (type == DatabaseType.Oracle)
                {
                    testOracle(connectionString,textBoxDatabaseName.Text);

                }
                else if (type == DatabaseType.Sqlite)
                {
                    testSqlite(connectionString);

                }

                labelConnectionStatus.Text = "Bağlantı Başarılı";
                BilgileriDoldur();


                panelListe.Enabled = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                labelConnectionStatus.ForeColor = Color.Red;
                labelConnectionStatus.Text = "!!!!Bağlantı BAŞARISIZ!!!!";
            }

        }

        private void testOracle(string connectionString,string databaseName)
        {
            Assembly oracleAssembly = Assembly.LoadWithPartialName("System.Data.OracleClient");
            Object objReflection = Activator.CreateInstance(oracleAssembly.FullName, "System.Data.OracleClient.OracleConnection");

            if (objReflection != null && objReflection is ObjectHandle)
            {
                ObjectHandle handle = (ObjectHandle)objReflection;

                Object objConnection = handle.Unwrap();
                connection = (DbConnection)objConnection;
                connection.ConnectionString = connectionString;
                connection.Open();
                connection.Close();
                template = new AdoTemplate();
                template.Connection = connection;
                template.DbProviderName = "System.Data.OracleClient";
                databaseHelper = new DatabaseOracle(template,connectionString, databaseName,textBoxProjectNamespace.Text,textBoxCodeGenerationDizini.Text);


            }
        }

        private void testSqlite(string connectionString)
        {
            Assembly assembly = Assembly.LoadWithPartialName("System.Data.SQLite");
            Object objReflection = Activator.CreateInstance(assembly.FullName, "System.Data.SQLite.SQLiteConnection");

            if (objReflection != null && objReflection is ObjectHandle)
            {
                ObjectHandle handle = (ObjectHandle)objReflection;

                Object objConnection = handle.Unwrap();
                connection = (DbConnection)objConnection;
                connection.ConnectionString = connectionString;
                connection.Open();
                connection.Close();
                template = new AdoTemplate();
                template.Connection = connection;
                template.DbProviderName = "System.Data.SQLite";
                databaseHelper = new DatabaseSqlite(template, connectionString, "main", textBoxProjectNamespace.Text, textBoxCodeGenerationDizini.Text);
                    


            }
        }


        private void testSqlServer(string connectionString,string databaseName)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            connection.Close();
            template = new AdoTemplate();
            template.Connection = connection;
            template.DbProviderName = "System.Data.SqlClient";

            databaseHelper = new DatabaseSqlServer(template, connectionString, databaseName, textBoxProjectNamespace.Text, textBoxCodeGenerationDizini.Text);
            
        }


        private void panelListeEnable()
        {
            panelListe.Enabled = true;
        }
        private void panelListeDisable()
        {
            panelListe.Enabled = false;
        }





        private IDatabase databaseHelper;


        private void BilgileriDoldur( )
        {
            databaseNameLabelDoldur();
            comboBoxSchemaListDoldur();
            listBoxTableListDoldur();
            this.comboBoxSchemaList.SelectedValueChanged += new System.EventHandler(this.comboBoxSchemaList_SelectedValueChanged);
        }

        private void databaseNameLabelDoldur()
        {
            labelDatabaseNameSonuc.Text = databaseHelper.getDatabaseName();
        }


        private void listBoxTableListDoldur()
        {
            DataTable dtTableList = databaseHelper.getTableListFromSchema( comboBoxSchemaList.Text);
            listBoxTableListesi.DataSource = dtTableList;
        }



        private void comboBoxSchemaListDoldur( )
        {
            DataTable dtSchemaList = databaseHelper.getSchemaList();
            if (dtSchemaList.Rows.Count > 0)
            {
                comboBoxSchemaList.DataSource = dtSchemaList;
                comboBoxSchemaList.Text = databaseHelper.getDefaultSchema();
            }
        }

        private void comboBoxSchemaList_SelectedValueChanged(object sender, EventArgs e)
        {
            listBoxTableListDoldur();
        }

        private void buttonFolderDialog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = false;
            folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;

            DialogResult dialogResult = folderBrowserDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                textBoxCodeGenerationDizini.Text = folderBrowserDialog.SelectedPath;
            }

        }

        private void buttonTumTablolariUret_Click(object sender, EventArgs e)
        {
            databaseHelper.CodeGenerateAllTables( 
             textBoxCodeGenerationDizini.Text
            ,checkBoxDboSemasiniAtla.Checked
            ,checkBoxSysTablolariniAtla.Checked
            , checkBoxUseSchemaNameInSql.Checked
            , checkBoxDizinlerseSemaIsmi.Checked
            , null
            );
            MessageBox.Show("TÜM TABLOLAR İÇİN KOD ÜRETİLDİ");

        }

        private void buttonGecerliDegerleriKaydet_Click(object sender, EventArgs e)
        {
            currentDatabaseEntry = new DatabaseEntry();

            currentDatabaseEntry.CodeGenerationDirectory = textBoxCodeGenerationDizini.Text;
            currentDatabaseEntry.ConnectionName = textBoxDatabaseName.Text;
            currentDatabaseEntry.CodeGenerationNamespace = textBoxProjectNamespace.Text;
            currentDatabaseEntry.ConnectionString  = textBoxConnectionString.Text;
            currentDatabaseEntry.ConnectionDatabaseType = comboBoxDatabaseType.SelectedValue.ToString();
            currentDatabaseEntry.setTimeValues();



            DatabaseService.EkleVeyaGuncelle(currentDatabaseEntry);

            MessageBox.Show("Değerler Kaydedildi;");

        }


        public List<DatabaseAbbreviations> getSampleAbbreviations()
        {

            List<DatabaseAbbreviations> list = new List<DatabaseAbbreviations>();
            DatabaseAbbreviations abbr = new DatabaseAbbreviations();
            abbr.Abbravetion = "BO_";
            abbr.FullNameReplacement = "";
            list.Add(abbr);
            return list;
        }


        private void buttonSeciliTablolariUret_Click(object sender, EventArgs e)
        {
            foreach (var item in listBoxTableListesi.SelectedItems)
            {
                DataRowView view = (DataRowView)item;
                string tableSchema = view["TABLE_SCHEMA"].ToString();
                string tableName = view["TABLE_NAME"].ToString();
                databaseHelper.CodeGenerateOneTable(
                     tableName
                    , tableSchema
                    , textBoxCodeGenerationDizini.Text
                    , checkBoxUseSchemaNameInSql.Checked
                    , checkBoxDizinlerseSemaIsmi.Checked
                    , getSampleAbbreviations()
                    );

            }

            MessageBox.Show("SEÇİLEN TABLOLAR İÇİN KOD ÜRETİLDİ");

        }

        private void buttonOtherConnections_Click(object sender, EventArgs e)
        {
            FormConnectionList frm = new FormConnectionList();
            frm.ShowDialog();

            if (frm.SelectedDatabaseEntry != null)
            {
                frm.SelectedDatabaseEntry.LastAccessTime = DateTime.UtcNow.ToShortDateString();

                DatabaseService.Guncelle(frm.SelectedDatabaseEntry);

                databaseEntryToForm(frm.SelectedDatabaseEntry);
            }
        }

        private void buttonKisaltmalar_Click(object sender, EventArgs e)
        {
            Form frm = new FormAbbreviations(currentDatabaseEntry);
            frm.ShowDialog();
        }

        private void buttonNewConnection_Click(object sender, EventArgs e)
        {
            currentDatabaseEntry = new DatabaseEntry();
            textBoxCodeGenerationDizini.Text = "";
            textBoxDatabaseName.Text = "";
            textBoxProjectNamespace.Text = "";
            textBoxConnectionString.Text = "";

        }
    }
}
