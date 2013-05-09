﻿using System;
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
            userControlCodeGenerationOptions1.getLastAccessedConnectionToTextbox();
            panelListeDisable();
        }


        DbConnection connection;
        AdoTemplate template;
        private IDatabase databaseHelper;

        private IDatabase DatabaseHelper
        {
            get
            {
                CurrentDatabaseEntry.setIDatabaseValues(databaseHelper);
                return databaseHelper;
            }
            set
            {
                databaseHelper = value;
                CurrentDatabaseEntry.setIDatabaseValues(databaseHelper);
            }
        }
        DatabaseEntry entry;
        private DatabaseEntry CurrentDatabaseEntry
        {
            get
            {
                entry = userControlCodeGenerationOptions1.getDatabaseEntry();
                return entry;

            }
        }
        
        
        private void buttonTestConnectionString_Click(object sender, EventArgs e)
        {
            string connectionString = userControlCodeGenerationOptions1.ConnectionString;
            string connectionName =userControlCodeGenerationOptions1.ConnectionName;
            string type = userControlCodeGenerationOptions1.SelectedDatabaseType;

            comboBoxSchemaList.Text = "";

            try
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                if (type == null || type == DatabaseType.SqlServer)
                {
                    testSqlServer(connectionString, connectionName);
                }
                else if (type == DatabaseType.Oracle)
                {
                    testOracle(connectionString, connectionName);

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
                DatabaseHelper = new DatabaseOracle( template);
                    

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
                DatabaseHelper = new DatabaseSqlite(template);
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

            DatabaseHelper = new DatabaseSqlServer(template);

        }


        private void panelListeEnable()
        {
            panelListe.Enabled = true;
        }
        private void panelListeDisable()
        {
            panelListe.Enabled = false;
        }







        private void BilgileriDoldur( )
        {
            userControlCodeGenerationOptions1.databaseNameLabelDoldur(DatabaseHelper);
            comboBoxSchemaListDoldur();
            listBoxTableListDoldur();
            this.comboBoxSchemaList.SelectedValueChanged += new System.EventHandler(this.comboBoxSchemaList_SelectedValueChanged);
        }



        private void listBoxTableListDoldur()
        {
            DataTable dtTableList = DatabaseHelper.getTableListFromSchema(comboBoxSchemaList.Text);
            listBoxTableListesi.DataSource = dtTableList;
        }



        private void comboBoxSchemaListDoldur( )
        {
            DataTable dtSchemaList = DatabaseHelper.getSchemaList();
            if (dtSchemaList.Rows.Count > 0)
            {
                comboBoxSchemaList.DataSource = dtSchemaList;
                comboBoxSchemaList.Text = DatabaseHelper.getDefaultSchema();
            }
        }

        private void comboBoxSchemaList_SelectedValueChanged(object sender, EventArgs e)
        {
            listBoxTableListDoldur();
        }



        private void buttonTumTablolariUret_Click(object sender, EventArgs e)
        {
            DatabaseHelper.CodeGenerateAllTables();
            MessageBox.Show("TÜM TABLOLAR İÇİN KOD ÜRETİLDİ");

        }

        private void buttonGecerliDegerleriKaydet_Click(object sender, EventArgs e)
        {

            DatabaseService.EkleVeyaGuncelle(CurrentDatabaseEntry);

            MessageBox.Show("Değerler Kaydedildi;");

        }


        public List<DatabaseAbbreviations> getSampleAbbreviations()
        {

            List<DatabaseAbbreviations> list = new List<DatabaseAbbreviations>();
            DatabaseAbbreviations abbr = new DatabaseAbbreviations();
            abbr.Abbreviation = "BO_";
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
                DatabaseHelper.CodeGenerateOneTable(
                     tableName
                    , tableSchema
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
                userControlCodeGenerationOptions1.databaseEntryToForm(frm.SelectedDatabaseEntry);
            }
        }

        private void buttonKisaltmalar_Click(object sender, EventArgs e)
        {
            Form frm = new FormAbbreviations(CurrentDatabaseEntry);
            frm.ShowDialog();
        }

        private void buttonNewConnection_Click(object sender, EventArgs e)
        {
            userControlCodeGenerationOptions1.ClearInputControlValues();

        }
    }
}
