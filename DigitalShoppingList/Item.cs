using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalShoppingList
{
    class Item
    {
        public string ProductName { get; set; }
        public decimal Price{ get; set; }
        public int Quantity { get; set; }
        

        public Item(string productName,decimal price)
        {
            ProductName = productName;
            Price = price;
            Quantity = 1;
        }
        public string GetInfo()
        {
            
            return ProductName + " " + Price + " x " +Quantity;
        }
    }
}
