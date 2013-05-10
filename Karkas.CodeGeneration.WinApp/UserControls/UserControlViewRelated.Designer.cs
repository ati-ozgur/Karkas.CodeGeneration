namespace Karkas.CodeGeneration.WinApp.UserControls
{
    partial class UserControlViewRelated
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSeciliViewlariUret = new System.Windows.Forms.Button();
            this.buttonTumViewlariUret = new System.Windows.Forms.Button();
            this.listBoxViewListesi = new System.Windows.Forms.ListBox();
            this.labelViewListesi = new System.Windows.Forms.Label();
            this.labelSchemaList = new System.Windows.Forms.Label();
            this.comboBoxSchemaList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonSeciliViewlariUret
            // 
            this.buttonSeciliViewlariUret.Location = new System.Drawing.Point(383, 109);
            this.buttonSeciliViewlariUret.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSeciliViewlariUret.Name = "buttonSeciliViewlariUret";
            this.buttonSeciliViewlariUret.Size = new System.Drawing.Size(121, 31);
            this.buttonSeciliViewlariUret.TabIndex = 17;
            this.buttonSeciliViewlariUret.Text = "Seçili View Üret";
            this.buttonSeciliViewlariUret.UseVisualStyleBackColor = true;
            this.buttonSeciliViewlariUret.Click += new System.EventHandler(this.buttonSeciliViewlariUret_Click);
            // 
            // buttonTumViewlariUret
            // 
            this.buttonTumViewlariUret.Location = new System.Drawing.Point(383, 65);
            this.buttonTumViewlariUret.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTumViewlariUret.Name = "buttonTumViewlariUret";
            this.buttonTumViewlariUret.Size = new System.Drawing.Size(121, 23);
            this.buttonTumViewlariUret.TabIndex = 16;
            this.buttonTumViewlariUret.Text = "Tüm Viewları Üret";
            this.buttonTumViewlariUret.UseVisualStyleBackColor = true;
            // 
            // listBoxViewListesi
            // 
            this.listBoxViewListesi.DisplayMember = "FULL_VIEW_NAME";
            this.listBoxViewListesi.FormattingEnabled = true;
            this.listBoxViewListesi.Location = new System.Drawing.Point(151, 65);
            this.listBoxViewListesi.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxViewListesi.Name = "listBoxViewListesi";
            this.listBoxViewListesi.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxViewListesi.Size = new System.Drawing.Size(204, 251);
            this.listBoxViewListesi.TabIndex = 15;
            // 
            // labelViewListesi
            // 
            this.labelViewListesi.AutoSize = true;
            this.labelViewListesi.Location = new System.Drawing.Point(21, 63);
            this.labelViewListesi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelViewListesi.Name = "labelViewListesi";
            this.labelViewListesi.Size = new System.Drawing.Size(62, 13);
            this.labelViewListesi.TabIndex = 14;
            this.labelViewListesi.Text = "View Listesi";
            // 
            // labelSchemaList
            // 
            this.labelSchemaList.AutoSize = true;
            this.labelSchemaList.Location = new System.Drawing.Point(21, 23);
            this.labelSchemaList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSchemaList.Name = "labelSchemaList";
            this.labelSchemaList.Size = new System.Drawing.Size(78, 13);
            this.labelSchemaList.TabIndex = 13;
            this.labelSchemaList.Text = "Schema Listesi";
            // 
            // comboBoxSchemaList
            // 
            this.comboBoxSchemaList.DisplayMember = "TABLE_SCHEMA";
            this.comboBoxSchemaList.FormattingEnabled = true;
            this.comboBoxSchemaList.Location = new System.Drawing.Point(154, 25);
            this.comboBoxSchemaList.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSchemaList.Name = "comboBoxSchemaList";
            this.comboBoxSchemaList.Size = new System.Drawing.Size(182, 21);
            this.comboBoxSchemaList.TabIndex = 12;
            this.comboBoxSchemaList.SelectedValueChanged += new System.EventHandler(this.comboBoxSchemaList_SelectedValueChanged);
            // 
            // UserControlViewRelated
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSeciliViewlariUret);
            this.Controls.Add(this.buttonTumViewlariUret);
            this.Controls.Add(this.listBoxViewListesi);
            this.Controls.Add(this.labelViewListesi);
            this.Controls.Add(this.labelSchemaList);
            this.Controls.Add(this.comboBoxSchemaList);
            this.Name = "UserControlViewRelated";
            this.Size = new System.Drawing.Size(524, 338);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSeciliViewlariUret;
        private System.Windows.Forms.Button buttonTumViewlariUret;
        private System.Windows.Forms.ListBox listBoxViewListesi;
        private System.Windows.Forms.Label labelViewListesi;
        private System.Windows.Forms.Label labelSchemaList;
        private System.Windows.Forms.ComboBox comboBoxSchemaList;
    }
}
