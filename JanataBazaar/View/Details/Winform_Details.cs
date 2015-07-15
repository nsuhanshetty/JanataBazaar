using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JanataBazaar.View.Details;

namespace JanataBazaar.View.Details
{
    public partial class Winform_Details : Form
    {
        public Winform_Details()
        {
            InitializeComponent();
        }

        protected virtual void SaveToolStrip_Click(object sender, EventArgs e)
        {
        }

        protected virtual void CancelToolStrip_Click(object sender, EventArgs e)
        {
        }

        protected virtual void UpdateStatus(string statusText, int statusValue = 0)
        {
            toolStrip_Label.Text = statusText;
            toolStripProgressBar1.Value = statusValue;
        }
    }
}
