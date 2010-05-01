using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Marsa
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnContactUs_Click(object sender, EventArgs e)
        {
            Process.Start("mailto:" + "karim.e.morsy@gmail.com; mohamed.g.ebrahim@gmail.com" + "?subject=" + "[Marsa] ...");

        }
    }
}