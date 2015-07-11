using System;
using System.Windows.Forms;

namespace JanataBazaar.Views.Details
{
#if DEBUG

    public partial class WinForm_Abstract : Form
    {
#else
        public abstract partial class Winform_DetailsFormat: Form
        {
#endif

        public WinForm_Abstract()
        {
            InitializeComponent();
        }

        private void Winform_DetailsFormat_Load(object sender, EventArgs e)
        {
        }

        protected virtual void SaveToolStrip_Click(object sender, EventArgs e)
        {
        }

        protected virtual void CancelToolStrip_Click(object sender, EventArgs e)
        {
        }

        protected virtual void UpdateStatus(string statusText, int statusValue=0)
        {
            toolStrip_Label.Text = statusText;
            toolStripProgressBar1.Value = statusValue;
        }
    }
}