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
            DialogResult dr = MessageBox.Show("Continue to Exit?","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Stop);
            if (DialogResult.Yes == dr)
            {
                this.Close();
            }
        }

        protected virtual void UpdateStatus(string statusText= "Enter Details and Click Save.", int statusValue = 0)
        {
            toolStrip_Label.Text = statusText;
            toolStripProgressBar1.Value = statusValue;

            if (statusValue == 100)
                MessageBox.Show(statusText,"Status",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        protected virtual bool IsNullOrEmpty(object obj)
        {
            return (obj == null || obj.ToString() == "");
        }

        private void Winform_Details_Load(object sender, EventArgs e)
        {

        }
    }
}
