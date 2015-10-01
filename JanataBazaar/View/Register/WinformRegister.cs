using System.Windows.Forms;

namespace JanataBazaar.View.Register
{
    public partial class WinformRegister : Form
    {
        public WinformRegister()
        {
            InitializeComponent();
        }

        protected virtual void UpdateStatus(string statusText = "Enter Details to Search.", int statusValue = 0)
        {
            toolStrip_Label.Text = statusText;
            toolStripProgressBar1.Value = statusValue;
        }

        protected virtual void NewToolStrip_Click(object sender, System.EventArgs e)
        {

        }

        protected virtual void dgvRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        protected virtual void dgvRegister_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        protected virtual void toolStripButtonPrint_Click(object sender, System.EventArgs e)
        {

        }

        protected virtual void dgvRegister_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
