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
    public partial class UserControlViewRelated : UserControl
    {
        public UserControlViewRelated()
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

        public void listBoxViewListDoldur()
        {
            DataTable dtViewList = ParentMainForm.DatabaseHelper.getViewListFromSchema(comboBoxSchemaList.Text);
            listBoxViewListesi.DataSource = dtViewList;
        }

        private void comboBoxSchemaList_SelectedValueChanged(object sender, EventArgs e)
        {
            listBoxViewListDoldur();
        }


    }
}
