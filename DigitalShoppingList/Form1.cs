using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalShoppingList
{
    public partial class Form1 : Form
    {
        List<Item> items = new List<Item>();
        public Form1()
        {
            InitializeComponent();




        }
        private void RefreshProductList()
        {
            listBox1.Items.Clear();
            decimal totalPrice = 0;
            foreach (var i in items)
            {
                listBox1.Items.Add(i.GetInfo());
                totalPrice += i.Price * i.Quantity;

            }
            lblTotalProductPrice.Text = totalPrice.ToString();
        }
       
        

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            bool productAlreadyExists = false;
            string productName = tbProductName.Text;
            decimal price = nudPrice.Value;
            foreach (var i in items)
            {
                if(i.ProductName==productName)
                {
                    i.Quantity++;
                    productAlreadyExists = true;

                    
                }
                
            }
            if (!productAlreadyExists)
            {
                Item item = new Item(productName, price);
                items.Add(item);
              
            }
            RefreshProductList();
            CalculateMinMaxValues();
        }

        private void CalculateMinMaxValues()
        {
            // banana hleb mleko jaja
            string itemWhereMax = "";
            string itemWhereMin = "";
            decimal maxValue = -1;


            foreach (var i in items)
            {
                if (i.Price > maxValue )
                {
                    maxValue = i.Price;
                    itemWhereMax = i.ProductName;
                }
                else if(i.Price== maxValue && !itemWhereMax.Contains(i.ProductName))
                {
                    itemWhereMax = i.ProductName +", "+ itemWhereMax;
                }
            }
            lblMaxValue.Text = maxValue.ToString() + " - " + itemWhereMax;

            decimal minValue = Int32.MaxValue;


            foreach (var i in items)
            {
                if (i.Price < minValue)
                {
                    minValue = i.Price;
                    itemWhereMin = i.ProductName;
                }
                else if (i.Price == minValue && !itemWhereMin.Contains(i.ProductName))
                {
                    itemWhereMin = i.ProductName + ", " + itemWhereMin;
                }
            }


            lblMinValue.Text = minValue.ToString() + " - "+itemWhereMin;
        }


        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            int si = listBox1.SelectedIndex;
            items.RemoveAt(si);
            RefreshProductList();
            CalculateMinMaxValues();


        }
    }

    

}
           



