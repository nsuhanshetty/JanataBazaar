using JanataBazaar.Datasets;
using JanataBazaar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JanataBazaar.View
{
    public partial class Winform_ReportViewer : Form
    {
        List<Sale> salesSummaryList;
        public Winform_ReportViewer(List<Sale> salesSummaryList)
        {
            InitializeComponent();
            this.salesSummaryList = salesSummaryList;
        }

        private void Winform_ReportViewer_Load(object sender, EventArgs e)
        {
            //get datatable from list
            //var list = (from sale in salesSummaryList
            //            select new
            //            {
            //                SI_No = salesSummaryList.IndexOf(sale) + 1,
            //                Bill_No = sale.ID,
            //                sale.TotalAmount,
            //                sale.TotalRebate,
            //                GrossAmount = sale.TotalAmount + sale.TotalRebate,
            //                AgeOfBill = DateTime.Compare(DateTime.Today.Date, sale.DateOfSale.Date)
            //            }).ToList();

            // DataTable dt = ToDataTable(list);

            //var testvar = dt.Rows[0]["AgeOfBill"];.
            //dt = ToDataTable(list);

            dsRebate ds = new dsRebate();
            var dt = new dsRebate.dtRebateDataTable();// ds.Tables["dtRebate"];

            foreach (var sale in salesSummaryList)
            {
                int index = salesSummaryList.IndexOf(sale);
                dt.Rows.Add();

                dt.Rows[index]["SI_No"] = salesSummaryList.IndexOf(sale) + 1;
                dt.Rows[index]["Bill_No"] = sale.ID;
                dt.Rows[index]["TotalAmount"] = sale.TotalAmount;
                dt.Rows[index]["TotalRebate"] = sale.TotalRebate;
                dt.Rows[index]["GrossAmount"] = sale.TotalAmount + sale.TotalRebate;
                dt.Rows[index]["AgeOfBill"] = DateTime.Compare(DateTime.Today.Date, sale.DateOfSale.Date);
            }

            //ds.Tables.Add(dt);
            this.dsRebateBindingSource.DataSource = dt;
            this.reportViewer1.RefreshReport();
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
