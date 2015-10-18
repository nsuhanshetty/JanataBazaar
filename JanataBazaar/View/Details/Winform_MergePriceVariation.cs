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

namespace JanataBazaar.View.Details
{
    public partial class Winform_MergePriceVariation : Form
    {
        Item item;
        List<ItemSKU> highSKUList;
        List<ItemSKU> lowerSKUList;

        List<ItemSKU> selHPrice = new List<ItemSKU>();
        List<ItemSKU> selLPrice = new List<ItemSKU>();

        public Winform_MergePriceVariation()
        {
            InitializeComponent();
        }

        public Winform_MergePriceVariation( Item _item)
        {
            InitializeComponent();

            this.item = _item;
            txtName.Text = _item.Name;
            txtUnit.Text = _item.QuantityUnit;
            txtBrand.Text = _item.Brand;

            LoadSKUList();
            LoadDGV();
        }

        private void LoadSKUList()
        {
            highSKUList = new List<ItemSKU>();
            lowerSKUList = new List<ItemSKU>();

            var itemSKUList = Builders.PriceVariationBuilder.GetPriceVariation(this.item.ID);
            if (itemSKUList == null || itemSKUList.Count == 0) return;

            //take the highest and add it in the dgvHighPrice
            var skuHigh = itemSKUList.OrderByDescending(i => i.ResalePrice).FirstOrDefault();
            highSKUList.Add(skuHigh);

            //add the rest into dgvLowerPrice
            itemSKUList.Remove(skuHigh);
            lowerSKUList.AddRange(itemSKUList);
        }

        private void LoadDGV()
        {
            FillDataGrid(true, dgvHigherPrice, highSKUList);
            FillDataGrid(false, dgvLowerPrice, lowerSKUList);
        }

        private void FillDataGrid(bool IsHigh, DataGridView dgv, List<ItemSKU> skuItemList)
        {
            List<String> colNames = new List<string>() { "ID", "colStock", "colWholePrice", "colResalePrice" };
            string colPrefix = IsHigh ? "h" : "l";

            dgv.Rows.Clear();
            foreach (var item in skuItemList)
            {
                int index = skuItemList.IndexOf(item);
                dgv.Rows.Add();

                dgv.Rows[index].Cells[colPrefix + colNames[0]].Value = item.ID;
                dgv.Rows[index].Cells[colPrefix + colNames[1]].Value = item.StockQuantity;
                dgv.Rows[index].Cells[colPrefix + colNames[2]].Value = item.WholesalePrice;
                dgv.Rows[index].Cells[colPrefix + colNames[3]].Value = item.ResalePrice;
            }
            //dgv.Columns["ID"].Visible = false;
        }

        private void btnMergeRight_Click(object sender, EventArgs e)
        {
            //check if atleast one chkbox is selected  in LowerPrice
            if (selLPrice.Count < 1)
            {
                MessageBox.Show("Atleast one Item must be selected in the higher prices to be merged OR transferred to the lower price grid.", "Select Items", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //check selected chk is only one in dgvHigherPrice
            else if (selHPrice.Count > 1)
            {
                MessageBox.Show("Only one desired Item to be merged with must be selected in the lower prices. ", "Select Items", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (selHPrice.Count == 0)
            {
                foreach (var _row in selLPrice)
                {
                    //int index = _row.Index;
                    highSKUList.Add(_row);
                    lowerSKUList.Remove(_row);
                    //selLPrice.Remove(_row);
                }
                selLPrice.Clear();
                LoadDGV();
            }
            else if (selHPrice.Count == 1)
            {
                //builders..UpdateSKUQuantity(toSKU, fromSKUList)
                //foreach chk add into list of sku "listToMerge"
                //foreach sku in list add sum quantity as toBeMergedquantity
                //add the "toBeMergedquantity" to desired sku
                //delete sku in listToMerge sku's

                var row = selHPrice[0];
                DialogResult dr = MessageBox.Show("Continue merging selected items from higher Price grid  with item of resale value " + row.ResalePrice.ToString() + " in the lower prices? ", "Merge Items", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.No)
                    return;

                var mergeWithSKUItem = row;
                List<ItemSKU> tobeMergedSKUItemList = new List<ItemSKU>();

                foreach (var _row in selLPrice)
                {
                    tobeMergedSKUItemList.Add(_row);
                }
                
                bool success = UpdateSKUQuantity(mergeWithSKUItem, tobeMergedSKUItemList);

                if (success)
                {
                    LoadSKUList();
                    LoadDGV();
                    selLPrice.Clear();
                }
            }
        }

        private void btnMergerLeft_Click(object sender, EventArgs e)
        {
            //check if atleast one chkbox is selected  in LowerPrice
            if (selHPrice.Count < 1)
            {
                MessageBox.Show("Atleast one Item must be selected in the higher prices to be merged OR transferred with the lower price grid.", "Select Items", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //check selected chk is only one in dgvHigherPrice
            else if (selLPrice.Count > 1)
            {
                MessageBox.Show("Only one desired Item to be merged with must be selected in the higher prices. ", "Select Items", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (selLPrice.Count == 0)
            {
                foreach (var _row in selHPrice)
                {
                    //int index = _row.Index;
                    lowerSKUList.Add(_row);
                    highSKUList.Remove(_row);
                    //selLPrice.Remove(_row);
                }
                selHPrice.Clear();
                LoadDGV();
            }
            else if (selLPrice.Count == 1)
            {
                //builders..UpdateSKUQuantity(toSKU, fromSKUList)
                //foreach chk add into list of sku "listToMerge"
                //foreach sku in list add sum quantity as toBeMergedquantity
                //add the "toBeMergedquantity" to desired sku
                //delete sku in listToMerge sku's

                var row = selLPrice[0];
                DialogResult dr = MessageBox.Show("Continue merging selected items from lower Price grid  with item of resale value " + row.ResalePrice.ToString() + " in the higher prices? ", "Merge Items", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.No)
                    return;

                var mergeWithSKUItem = row;
                List<ItemSKU> tobeMergedSKUItemList = new List<ItemSKU>();

                foreach (var _row in selHPrice)
                {
                    tobeMergedSKUItemList.Add(_row);
                }
                selLPrice.Clear();

                bool success = UpdateSKUQuantity(mergeWithSKUItem, tobeMergedSKUItemList);
                if (success)
                {
                    LoadSKUList();
                    LoadDGV();
                    selHPrice.Clear();
                }
            }
        }

        private bool UpdateSKUQuantity(ItemSKU toSKU, List<ItemSKU> fromSKUList)
        {
            foreach (var item in fromSKUList)
            {
                toSKU.StockQuantity += item.StockQuantity;
            }

            bool success = Savers.ItemSKUSavers.UpdateSKUList(toSKU, fromSKUList);
            if (success)
                return true;
            return false;
        }

        private void dgvLowerPrice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            var dgv = (DataGridView)sender;
            string colPrefix = dgv.Name == "dgvLowerPrice" ? "l" : "h";
            var selectedRow = (DataGridViewCheckBoxCell)dgv.Rows[e.RowIndex].Cells[colPrefix + "colSelect"];

            //selectedRow.Value = (selectedRow.Value != null && (CheckState)selectedRow.Value == CheckState.Checked) ? CheckState.Unchecked : CheckState.Checked;

            if ((selectedRow.Value != null && (CheckState)selectedRow.Value == CheckState.Checked))
            {
                selectedRow.Value = CheckState.Unchecked;
                if (colPrefix == "h")
                {
                    int ID = int.Parse(dgvHigherPrice.Rows[e.RowIndex].Cells[colPrefix + "ID"].Value.ToString());
                    ItemSKU itemSKU = highSKUList.Where(x => x.ID == ID).SingleOrDefault();
                    selHPrice.Remove(itemSKU);
                }
                else
                {
                    int ID = int.Parse(dgvLowerPrice.Rows[e.RowIndex].Cells[colPrefix + "ID"].Value.ToString());
                    ItemSKU itemSKU = lowerSKUList.Where(x => x.ID == ID).SingleOrDefault();
                    selLPrice.Remove(itemSKU);
                }
            }
            else
            {
                selectedRow.Value = CheckState.Checked;
                if (colPrefix == "h")
                {
                    int ID = int.Parse(dgvHigherPrice.Rows[e.RowIndex].Cells[colPrefix + "ID"].Value.ToString());
                    ItemSKU itemSKU = highSKUList.Where(x => x.ID == ID).SingleOrDefault();
                    selHPrice.Add(itemSKU);
                }
                else
                {
                    int ID = int.Parse(dgvLowerPrice.Rows[e.RowIndex].Cells[colPrefix + "ID"].Value.ToString());
                    ItemSKU itemSKU = lowerSKUList.Where(x => x.ID == ID).SingleOrDefault();
                    selLPrice.Add(itemSKU);
                }
            }

        }
    }
}
