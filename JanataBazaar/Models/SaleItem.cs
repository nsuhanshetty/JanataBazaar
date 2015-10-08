using JanataBazaar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Models
{
    public class SaleItem
    {
        public virtual int ID { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual Item Item { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal Price { get; set; }
        public virtual decimal TotalPrice { get; set; }
        public virtual int StockCount { get; set; }

        public SaleItem() { }
        public SaleItem(Item _item, decimal _price, int _stockCount, int _quantity = 0, decimal _totalPrice = 0)
        {
            this.Item = _item;
            this.Price = _price;
            this.StockCount = _stockCount;
            this.Quantity = _quantity;
            this.TotalPrice = _totalPrice;
        }
    }

    public class Sale
    {
        public virtual int ID { get; set; }
        public virtual bool IsCredit{ get; set; }
        public virtual IList<SaleItem> Items { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Member Member { get; set; }
        public virtual decimal PaidAmount { get; set; }
        public virtual decimal TransportCharge { get; set; }
        public virtual decimal BalanceAmount { get; set; }
        public virtual decimal TotalAmount { get; set; }
        public virtual DateTime DateOfSale { get; set; }

        public Sale() { }
        public Sale(List<SaleItem> _items,bool _IsCredit, decimal _paidAmount, decimal _totalAmount,DateTime _dateOfSale,
                    Customer _customer = null, Member _member = null,decimal _transportCharge = 0, decimal _balanceAmount = 0)
        {
            this.Items = _items;
            this.IsCredit = _IsCredit;
            this.Customer = _customer;
            this.Customer = _customer;
            this.Member = _member;
            this.TransportCharge = _transportCharge;
            this.PaidAmount = _paidAmount;
            this.BalanceAmount = _balanceAmount;
            this.TotalAmount = _totalAmount;
            this.DateOfSale = _dateOfSale;
        }
    }
}
