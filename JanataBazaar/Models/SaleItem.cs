using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanataBazaar.Models
{
    public class SaleItem
    {
        public int ID { get; set; }
        public Sale Sale { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int StockCount { get; set; }

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
        public int ID { get; set; }
        public List<SaleItem> Items { get; set; }
        public Customer Customer { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public decimal TotalAmount { get; set; }

        public Sale() { }
        public Sale(List<SaleItem> _items, Customer _customer, decimal _paidAmount, decimal _totalAmount, decimal _balanceAmount = 0)
        {
            this.Items = _items;
            this.Customer = _customer;
            this.PaidAmount = _paidAmount;
            this.BalanceAmount = _balanceAmount;
            this.TotalAmount = _totalAmount;
        }
    }
}
