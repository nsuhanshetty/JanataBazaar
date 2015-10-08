using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Models
{
    public class PurchaseItemIndent
    {
        public virtual int ID { get; set; }
        public virtual Item Item { get; set; }
        public virtual PurchaseIndent PurchaseIndent { get; set; }
        public virtual int InHandStock { get; set; }
        public virtual int AvgConsumption { get; set; }
        public virtual int StockPeriod { get; set; }
        public virtual string Remark { get; set; }

        public PurchaseItemIndent() { }
        public PurchaseItemIndent(Item _item, int _InhandStock)
        {
            this.Item = _item;
            this.InHandStock = _InhandStock;
            this.AvgConsumption = 0;
            this.StockPeriod = 1;
            this.Remark = "";
        }
    }

    public class PurchaseIndent
    {
        public virtual int ID { get; set; }
        public virtual IList<PurchaseItemIndent> IndentItemsList { get; set; }
        public virtual DateTime DateOfIndent { get; set; }
    }
}
