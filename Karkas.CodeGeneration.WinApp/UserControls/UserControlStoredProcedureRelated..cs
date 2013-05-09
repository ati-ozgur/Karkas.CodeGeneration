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
    public partial class UserControlStoredProcedureRelated : UserControl
    {
        public UserControlStoredProcedureRelated()
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


        internal void listBoxStoredProcedureListDoldur()
        {
            DataTable dtStoredProcedureList = ParentMainForm.DatabaseHelper.getStoredProcedureListFromSchema(comboBoxSchemaList.Text);
            listBoxStoredProcedureListesi.DataSource = dtStoredProcedureList;

        }
    }
}
