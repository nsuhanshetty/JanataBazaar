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
    public partial class Winform_PurchaseIndentDetails : Winform_Details
    {
        PurchaseItemIndent indent;
        public Winform_PurchaseIndentDetails(PurchaseItemIndent indent)
        {
            InitializeComponent();
            this.indent = indent;

            txtParticular.Text = indent.Item.Name;
            txtAvgConsume.Text = indent.AvgConsumption.ToString();
            txtStockInHand.Text = indent.InHandStock.ToString();
            nudDuration.Value = indent.StockPeriod;
            txtRemarks.Text = indent.Remark;
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            int duration;
            int.TryParse(nudDuration.Value.ToString(),out duration);

            indent.StockPeriod = duration == 0 ? 1 : duration;
            indent.Remark = txtRemarks.Text;
            this.Close();
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
