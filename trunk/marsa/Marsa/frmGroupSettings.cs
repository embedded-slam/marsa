using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Marsa
{
    public partial class frmGroupSettings : Form
    {
        #region Private Members
        private DataSet dataSet;
        BindingSource   bindingSource;
        DataTable       groupsTable;
        #endregion

        #region Properties
        public DataTable GroupsTable
        {
            get { return this.groupsTable; }
            set { this.groupsTable = value; }
        }  
        #endregion
        public frmGroupSettings(DataTable groupsTable)
        {
            InitializeComponent();
            this.groupsTable = groupsTable.Copy();
            this.bindingSource = new BindingSource();
            this.bindingSource.DataSource = this.groupsTable;
            this.dgvGroups.DataSource = bindingSource;
            this.dgvGroups.Refresh();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
#if false
            string settingsPath = Application.StartupPath;
            DataSet ds = new DataSet();
            ds.Tables.Add("Groups");
            ds.Tables["Groups"].Columns.Add("Name");
            ds.Tables["Groups"].Columns.Add("Description");
            ds.Tables["Groups"].Rows.Add("Transmission", "Holds all the counters related to transmission");
            ds.Tables["Groups"].Rows.Add("Reception", "Holds all the counters related to reception");
            ds.Tables["Groups"].Columns["Name"].Unique = true;
            ds.Tables["Groups"].Columns["Name"].AllowDBNull = false;
            MessageBox.Show(settingsPath + "\\configs.groups.xml");
            ds.WriteXml("configs.xml");
#endif
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}