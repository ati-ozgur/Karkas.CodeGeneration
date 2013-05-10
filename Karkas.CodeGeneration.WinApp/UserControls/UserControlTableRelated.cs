﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Karkas.CodeGeneration.WinApp.UserControls
{
    public partial class UserControlTableRelated : UserControl
    {
        public UserControlTableRelated()
        {
            InitializeComponent();
        }


        public MainForm ParentMainForm
        {
            get
            {
                return (MainForm)this.ParentForm;
            }
        }


        private void buttonTumTablolariUret_Click(object sender, EventArgs e)
        {
            try
            {

                String hatalar = ParentMainForm.DatabaseHelper.CodeGenerateAllTables();
                string message = "TÜM TABLOLAR İÇİN KOD ÜRETİLDİ";
                if (!string.IsNullOrEmpty(hatalar))
                {
                    message = message + ", HATALAR " + hatalar;
                }
                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void buttonSeciliTablolariUret_Click(object sender, EventArgs e)
        {
            foreach (var item in listBoxTableListesi.SelectedItems)
            {
                DataRowView view = (DataRowView)item;
                string tableSchema = view["TABLE_SCHEMA"].ToString();
                string tableName = view["TABLE_NAME"].ToString();

                try
                {
                    ParentMainForm.DatabaseHelper.CodeGenerateOneTable(
                 tableName
                , tableSchema
                );

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            MessageBox.Show("SEÇİLEN TABLOLAR İÇİN KOD ÜRETİLDİ");

        }


        public void listBoxTableListDoldur()
        {
            DataTable dtTableList = ParentMainForm.DatabaseHelper.getTableListFromSchema(comboBoxSchemaList.Text);
            listBoxTableListesi.DataSource = dtTableList;
        }



        public void comboBoxSchemaListDoldur(DataTable dtSchemaList)
        {
            if (dtSchemaList.Rows.Count > 0)
            {
                comboBoxSchemaList.DataSource = dtSchemaList;
                comboBoxSchemaList.Text = ParentMainForm.DatabaseHelper.getDefaultSchema();
            }
        }

        private void comboBoxSchemaList_SelectedValueChanged(object sender, EventArgs e)
        {
            listBoxTableListDoldur();
        }






        internal void setComboBoxSchemaListText(string pText)
        {
            comboBoxSchemaList.Text = pText;
        }
    }
}