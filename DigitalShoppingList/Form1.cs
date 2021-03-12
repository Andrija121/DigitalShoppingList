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
                totalPrice += i.Price;

            }
            lblTotalProductPrice.Text = totalPrice.ToString();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string productName = tbProductName.Text;
            decimal price = nudPrice.Value;
            Item item = new Item(productName, price);
            items.Add(item);
            RefreshProductList();
            decimal maxValue = item.Price;
            decimal[] NUmberMaxArray = new[] { maxValue};
            
            foreach(var i in NUmberMaxArray)
            {
                if (i > maxValue)
                {
                    maxValue = i;
                }
            }
            lblMaxValue.Text = maxValue.ToString();

            decimal minValue = Int32.MaxValue;
            decimal[] NumberMinArray = new[] { minValue};

            foreach (var i in NumberMinArray)
            {
                if (i < minValue)
                {
                    minValue=i;
                }
            }


            lblMinValue.Text = minValue.ToString();
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            int si = listBox1.SelectedIndex;
            items.RemoveAt(si);
            RefreshProductList();

        }
    }

    

}
           



