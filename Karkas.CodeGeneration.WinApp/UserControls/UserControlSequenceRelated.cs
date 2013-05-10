using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Karkas.CodeGeneration.WinApp.UserControls
{
    public partial class UserControlSequenceRelated : UserControl
    {
        public UserControlSequenceRelated()
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



        public void comboBoxSchemaListDoldur(DataTable dtSchemaList)
        {
            if (dtSchemaList.Rows.Count > 0)
            {
                comboBoxSchemaList.DataSource = dtSchemaList;
                comboBoxSchemaList.Text = ParentMainForm.DatabaseHelper.getDefaultSchema();
            }
        }



        internal void listBoxSequenceListDoldur()
        {
            DataTable dtSequenceList = ParentMainForm.DatabaseHelper.getSequenceListFromSchema(comboBoxSchemaList.Text);
            listBoxSequenceListesi.DataSource = dtSequenceList;

        }

        private void comboBoxSchemaList_SelectedValueChanged(object sender, EventArgs e)
        {
            listBoxSequenceListDoldur();
        }

        private void buttonSeciliSequenceUret_Click(object sender, EventArgs e)
        {
            foreach (var item in listBoxSequenceListesi.SelectedItems)
            {
                DataRowView view = (DataRowView)item;
                string schemaName = view["SEQ_SCHEMA_NAME"].ToString();
                string sequenceName = view["SEQUENCE_NAME"].ToString();
                ParentMainForm.DatabaseHelper.CodeGenerateOneSequence(
                     sequenceName
                    , schemaName
                    );

            }

            MessageBox.Show("SEÇİLEN SEQUENCES İÇİN KOD ÜRETİLDİ");
        }

        private void buttonTumSequencesUret_Click(object sender, EventArgs e)
        {
            try
            {

                String hatalar = ParentMainForm.DatabaseHelper.CodeGenerateAllSequences();
                string message = "TÜM SEQUENCES İÇİN KOD ÜRETİLDİ";
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
    }
}
