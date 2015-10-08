using JanataBazaar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JanataBazaar.View.Register
{
    public partial class Winform_PurchaseIndentRegistry : WinformRegister
    {
        public Winform_PurchaseIndentRegistry()
        {
            InitializeComponent();
        }

        private void Winform_PurchaseIndentRegistry_Load(object sender, EventArgs e)
        {
            this.toolStrip1.Items.Add(this.SearchToolStrip);
        }

        protected void SearchToolStrip_Click(object sender, System.EventArgs e)
        {
            if (DateTime.Compare(dtpFrom.Value.Date, dtpTo.Value.Date) > 0)
            {
                MessageBox.Show("From Date of search cannot be greater than To Date of search", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<PurchaseIndent> indentList = new List<PurchaseIndent>();
            indentList = Builders.PurchaseIndentBuilder.GetIndentList(dtpFrom.Value.Date, dtpTo.Value.Date);

            if (indentList != null || indentList.Count != 0)
            {
                dgvRegister.DataSource = (from item in indentList
                                          select new { item.ID, item.DateOfIndent }).ToList();

                dgvRegister.Columns["ID"].Visible = false;
            }
            else
            {
                dgvRegister.DataSource = null;
            }
        }

        protected override void dgvRegister_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            int _ID = int.Parse(dgvRegister.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            new Winform_PurchaseIndentForm(_ID).ShowDialog();
        }

        protected override void NewToolStrip_Click(object sender, System.EventArgs e)
        {
            new Winform_PurchaseIndentForm().ShowDialog();
            this.SearchToolStrip_Click(this, new EventArgs());
        }
    }
}
