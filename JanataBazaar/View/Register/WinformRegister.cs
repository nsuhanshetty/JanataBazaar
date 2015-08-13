﻿using System.Windows.Forms;

namespace JanataBazaar.View.Register
{
    public partial class WinformRegister : Form
    {
        public WinformRegister()
        {
            InitializeComponent();
        }

        protected virtual void UpdateStatus(string statusText = "Click On Item to Edit.", int statusValue = 0)
        {
            toolStrip_Label.Text = statusText;
            toolStripProgressBar1.Value = statusValue;
        }

        protected virtual void NewVendToolStrip_Click(object sender, System.EventArgs e)
        {

        }

        protected virtual void dgvRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        protected virtual void dgvRegister_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
