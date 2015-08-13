using System;
using System.Windows.Forms;

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

        protected virtual void UpdateStatus(string statusText= "Enter Details and Click Save.", int statusValue = 0)
        {
            toolStrip_Label.Text = statusText;
            toolStripProgressBar1.Value = statusValue;
        }

        protected virtual bool IsNullOrEmpty(object obj)
        {
            return (obj == null || obj.ToString() == "");
        }
    }
}
