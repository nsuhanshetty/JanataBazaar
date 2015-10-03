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

namespace JanataBazaar.Reports
{
    public partial class Report_SCF : Form
    {
        List<ItemPricing> itemList;
        public Report_SCF()
        {
            InitializeComponent();
        }

        public Report_SCF(List<ItemPricing> _itemList)
        {
            InitializeComponent();
            this.itemList = _itemList;
        }

        private void Report_SCF_Load(object sender, EventArgs e)
        {
            Datasets.DataSet_SCF.DataTable_SCFDataTable dt = new Datasets.DataSet_SCF.DataTable_SCFDataTable();
            dt.Rows.Add();
            var index = dt.Rows.Count - 1;

            foreach (var item in itemList)
            {
                dt.Rows[index]["Name"] = item.Item.Name;
                dt.Rows[index]["Brand"] = item.Item.Brand;
                dt.Rows[index]["PackageType"] = item.Package.Name;
                dt.Rows[index]["PackageQuantity"] = item.PackageQuantity;
                dt.Rows[index]["QuantityPerPack"] = item.QuantityPerPack;
                dt.Rows[index]["PurchaseValue"] = item.PurchaseValue;
                dt.Rows[index]["TotalPurchase"] = item.TotalPurchaseValue;
                dt.Rows[index]["Wholesale"] = item.Wholesale;
                dt.Rows[index]["TotalWholesale"] = item.TotalWholesaleValue;
                dt.Rows[index]["Retail"] = item.Retail;
                dt.Rows[index]["TotalResale"] = item.TotalResaleValue;
            }

            this.dataSetSCFBindingSource.DataSource = dt;
            this.reportViewer1.RefreshReport();
        }
    }
}
