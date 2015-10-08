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
    public partial class Winform_PriceVariationRegister : WinformRegister
    {
        public Winform_PriceVariationRegister()
        {
            InitializeComponent();
        }

        private void Winform_PriceVariationRegister_Load(object sender, EventArgs e)
        {
            dgvRegister.Columns.Clear();
            dgvRegister.Rows.Clear();
            dgvStockPriceDetails.DataSource = null;

            dgvRegister.Columns.Add("ID", "ID");
            dgvRegister.Columns.Add("Name", "Name");
            dgvRegister.Columns.Add("Brand", "Brand");
            dgvRegister.Columns.Add("QuantityUnit", "QuantityUnit");

            List<object[]> priceVariationList = Builders.PriceVariationBuilder.GetPriceVariationItems();

            if (priceVariationList != null && priceVariationList.Count != 0)
            {
                foreach (var item in priceVariationList)
                {
                    int index = priceVariationList.IndexOf(item);

                    dgvRegister.Rows.Add();
                    dgvRegister.Rows[index].Cells["ID"].Value = item[0];
                    dgvRegister.Rows[index].Cells["Name"].Value = item[1];
                    dgvRegister.Rows[index].Cells["Brand"].Value = item[2];
                    dgvRegister.Rows[index].Cells["QuantityUnit"].Value = item[3];
                }
            }
        }

        protected override void dgvRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            dgvStockPriceDetails.DataSource = null;
            int _ID = int.Parse(dgvRegister.Rows[e.RowIndex].Cells["ID"].Value.ToString());

            var itemSKUList = Builders.PriceVariationBuilder.GetPriceVariation(_ID);
            if (itemSKUList != null && itemSKUList.Count != 0)
            {
                dgvStockPriceDetails.DataSource = (from itemsku in itemSKUList
                                                   select new { itemsku.ID, itemsku.StockQuantity, itemsku.WholesalePrice, itemsku.ResalePrice }).ToList();
            }
        }

        protected override void dgvRegister_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            //pass the item 
            int _ID = int.Parse(dgvRegister.Rows[e.RowIndex].Cells["ID"].Value.ToString());

            var item = Builders.ItemDetailsBuilder.GetItemInfo(_ID);
            new Winform_MergePriceVariation(item).ShowDialog();
            Winform_PriceVariationRegister_Load(this, new EventArgs());
        }
    }
}
