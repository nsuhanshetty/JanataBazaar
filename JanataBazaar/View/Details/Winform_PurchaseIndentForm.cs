using JanataBazaar.Builders;
using JanataBazaar.Models;
using JanataBazaar.View.Details;
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
    public partial class Winform_PurchaseIndentForm : Winform_Details
    {
        //PurchaseIndent PurchaseIndent;
        List<PurchaseItemIndent> purchaseIndentList;
        PurchaseIndent indent;

        public Winform_PurchaseIndentForm()
        {
            InitializeComponent();
        }

        public Winform_PurchaseIndentForm(int _ID)
        {
            InitializeComponent();

            indent = Builders.PurchaseIndentBuilder.GetPurchaseIndent(_ID);
            this.purchaseIndentList = indent.IndentItemsList.ToList();
        }

        private void Winform_PurchaseIndentForm_Load(object sender, EventArgs e)
        {
            if (purchaseIndentList == null)
            {
                purchaseIndentList = new List<PurchaseItemIndent>();
                var itemInReserveList = PurchaseIndentBuilder.GetItemsInReserve();
                foreach (var item in itemInReserveList)
                {
                    purchaseIndentList.Add(new PurchaseItemIndent(item.Item, item.StockQuantity));
                }
                purchaseIndentList = PurchaseIndentBuilder.GetItemAvgConsumption(purchaseIndentList);
            }

            LoadDGV();
            FillDGV();
        }

        private void LoadDGV()
        {
            //todo: also add minimum_ReserveStock
            this.dgvRegister.Columns.Add("colSINo", "SI.No");
            this.dgvRegister.Columns.Add("colParticular", "Particular");
            this.dgvRegister.Columns.Add("colBrand", "Brand");
            this.dgvRegister.Columns.Add("colInHandStock", "Stock In Hand Quantity");
            this.dgvRegister.Columns.Add("colAvgConsume", "Average Monthly Consumption");
            this.dgvRegister.Columns.Add("colPeriod", "Period for which Stock required");
            this.dgvRegister.Columns.Add("colRemark", "Remarks");
        }

        private void FillDGV()
        {
            dgvRegister.Rows.Clear();
            foreach (var item in purchaseIndentList)
            {
                int index = purchaseIndentList.IndexOf(item);
                dgvRegister.Rows.Add();

                dgvRegister.Rows[index].Cells["colSINo"].Value = index + 1;
                dgvRegister.Rows[index].Cells["colParticular"].Value = item.Item.Name;
                dgvRegister.Rows[index].Cells["colBrand"].Value = item.Item.Brand;

                dgvRegister.Rows[index].Cells["colInHandStock"].Value = item.InHandStock;
                dgvRegister.Rows[index].Cells["colAvgConsume"].Value = item.AvgConsumption;
                dgvRegister.Rows[index].Cells["colPeriod"].Value = item.StockPeriod;
                dgvRegister.Rows[index].Cells["colRemark"].Value = item.Remark;
            }
        }

        //private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //get items where stock less their stock(packetquant * itemsperpack)
        //    //if (string.IsNullOrEmpty(cmbSection.Text))
        //    //{
        //    //    dgvRegister.DataSource = "";
        //    //    return;
        //    //}

        //    //display Itemname, Brand, Quantity unit, current stock, Expected Reserve
        //    dgvRegister.DataSource = ReportsBuilder.GetPIFReport();

        //    if (dgvRegister.Rows.Count == 0)
        //        UpdateStatus("No Results Found");
        //    else
        //        UpdateStatus(dgvRegister.Rows.Count + " Results Found");
        //}

        private void dgvRegister_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            new Winform_PurchaseIndentDetails(purchaseIndentList[e.RowIndex]).ShowDialog();
            FillDGV();
        }

        private void UpdatePurchaseIndentList(int index, PurchaseItemIndent indent)
        {
            purchaseIndentList[index] = indent;
            FillDGV();
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            if (purchaseIndentList != null && purchaseIndentList.Count != 0)
            {
                if (indent == null)
                {
                    indent = new PurchaseIndent();
                    indent.DateOfIndent = dtpIndentDate.Value.Date;
                }

                UpdateStatus("Saving", 50);
                indent.IndentItemsList = purchaseIndentList;
                bool success = Savers.PurchaseIndentSavers.SavePurchaseIndent(indent);

                if (success)
                {
                    UpdateStatus("Purchase Indent Saved", 100);
                    this.Close();
                }
                else
                    UpdateStatus("Error saving Purchase Indent", 100);
            }
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
