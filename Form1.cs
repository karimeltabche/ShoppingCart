/*=========================
FileName: FinalProject
FileType: Visual C#
Author: Karim El-Tabche
Created On: 6/14/2016 4:21:09 PM
Last Modified On: 6/18/2016 11:27:05 PM
Description: This is a Shopping Cart program
             that uses XML and LINQ to store 
             and display products. It allows
             you to search for a specific 
             item in database and add it
             to cart and also remove items
             from cart. After done adding 
             items, you can calculate 
             your total and checkout.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;

namespace FinalProject
{
    public partial class frmShoppingCart : Form
    {

        XmlDocument xdoc = new XmlDocument(); //Create new xml document called xdoc
        string[] product = new string[2];// create an array for product name and price
        string selected;//assign selected item to a variable called selected

        Product prod = new Product();// Create an object of product 



        public frmShoppingCart()
        {
            InitializeComponent();
        }

        private void frmShoppingCart_Load(object sender, EventArgs e)
        {
            xdoc.Load("database\\Products.xml");//Load the xml document
            
            XmlNodeList list = xdoc.GetElementsByTagName("name");//Get the products name

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Search through the database for keyword typed in the search textbox
            //And displays results in the listbox

            var product = new[] {"","" };
            lstSearch.Items.Clear();//Clears items in list 
            xdoc.Load("database\\Products.xml");

            XmlNodeList productPrice = xdoc.GetElementsByTagName("price");

            string search = txtSearch.Text;

            for (int i = 0; i < productPrice.Count; i++)
            {
                product[0] = xdoc.GetElementsByTagName("name")[i].InnerText; // Assign 
                product[1] = xdoc.GetElementsByTagName("price")[i].InnerText;

                if (product[0].ToLower().Contains(search))//Checks if items are found in database
                {
                    lstSearch.Items.Add(product[0] + "              $" + product[1]);//Display items in listbox
                }
                
             }
            if (lstSearch.Items.Count < 1)
                {
                     MessageBox.Show("Sorry, Item not found");//If item is not found display a message
                }
              
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Adds every item selected to the cart listbox

            
            selected = lstSearch.SelectedItem.ToString(); 

            lstCart.Items.Add(selected);//Adds items to the cart listbox

            prod.Price= double.Parse(selected.Substring(selected.LastIndexOf("$")+1)); //Grabs the price from each item and store it in a variable
            prod.Total += prod.Price; // Adds price to total every time an item is added

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //Calculates the total and displays it in the total label

            lblDisplayTotal.Text = "";
            lblDisplayTotal.Text = prod.Total.ToString("C2");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
                //Remove selected item from the cart listbox and if none is selected 
                //a message will display 


                if (lstCart.SelectedIndex == -1 )
                {
                    MessageBox.Show("Please choose an item from the cart to remove");
                }
                else
                {
                selected = lstCart.SelectedItem.ToString();
                prod.Price = double.Parse(selected.Substring(selected.LastIndexOf("$") + 1));
                prod.Total -= prod.Price;
                lstCart.Items.RemoveAt(lstCart.SelectedIndex);//Removes item from cart listbox
                }

        }
    }
}
