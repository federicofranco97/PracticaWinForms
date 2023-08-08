using Newtonsoft.Json;
using PracticaWinForms.Business;
using PracticaWinForms.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaWinForms
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            this.CenterToScreen();
            txtProdPrice.KeyPress += TxtProdPrice_KeyPress;            
            this.FormClosed += Dashboard_FormClosed;
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Save the list of products
            var jsonProducts = JsonConvert.SerializeObject(Engine.Products);            
            Engine.SaveProducts(jsonProducts);
            //Save the list of purchases
            var jsonPurchases = JsonConvert.SerializeObject(Engine.Purchases);
            Engine.SavePurchases(jsonPurchases);
            //Save the list of users
            //TO DO
            Application.Exit();
        }

        private void TxtProdPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit or a control key
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Suppress the key press
            }
        }

        Purchase currentPurchase = new Purchase();

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //Initialize the list of products
            lstProducts.Items.Clear();
            lstProducts.Items.AddRange(Engine.Products.ToArray());
            currentPurchase.Date = DateTime.Now;
            currentPurchase.ID = Guid.NewGuid();
            currentPurchase.ProductList = new List<Product>();
            currentPurchase.Total = 0;
            lstProducts.DisplayMember = "Name";
            lstProducts.ValueMember = "ID";
            lstPurchase.DisplayMember = "DisplayValue";
            lstPurchase.ValueMember = "ID";
            lstHistory.Items.Clear();
            lstHistory.Items.AddRange(Engine.Purchases.ToArray());
            lstHistory.DisplayMember = "DisplayValue";
            lstHistory.ValueMember = "ID";            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Get the selected item from the list
            var selectedItem = (Product)lstProducts.SelectedItem;
            AddProduct(selectedItem);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //Get the selected item from the list
            var selectedItem = (Product)lstProducts.SelectedItem;
            RemoveProduct(selectedItem);
        }

        private void AddProduct(Product prod)
        {
            if (prod == null) return;
            lstPurchase.Items.Add(prod);
            currentPurchase.ProductList.Add(prod);
            currentPurchase.Total += prod.Price;
            lblTotal.Text = "Total: " + currentPurchase.Total;
        }
        private void RemoveProduct(Product prod) 
        {
            if (prod == null) return;
            lstPurchase.Items.Remove(prod);
            currentPurchase.ProductList.Remove(prod);
            currentPurchase.Total -= prod.Price;
            lblTotal.Text = "Total: " + currentPurchase.Total;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(currentPurchase.ProductList.Count > 0)
                Engine.Purchases.Add(currentPurchase);
            //Reload the list
            lstHistory.Items.Clear();
            lstHistory.Items.AddRange(Engine.Purchases.ToArray());
        }

        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtProdName.Text) || string.IsNullOrWhiteSpace(txtProdPrice.Text) || numProdStock.Value <= 0)
            {
                MessageBox.Show("Please complete all the values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Engine.AddProduct(txtProdName.Text, Convert.ToInt16(numProdStock.Value), Convert.ToDecimal(txtProdPrice.Text));
            //Reload the list
            lstProducts.Items.Clear();
            lstProducts.Items.AddRange(Engine.Products.ToArray());
            //Clear the values.
            btnClearProduct.PerformClick();
        }

        private void btnClearProduct_Click(object sender, EventArgs e)
        {
            txtProdName.Text = "";
            txtProdPrice.Text = "";
            numProdStock.Value = 0;
        }

        private void lstHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get the selected purchase
            var selectedPurchase = (Purchase)lstHistory.SelectedItem;
            lstHistoryDetail.Items.Clear();
            lstHistoryDetail.Items.AddRange(selectedPurchase.ProductList.ToArray());
            lstHistoryDetail.DisplayMember = "DisplayValue";
            lstHistoryDetail.ValueMember = "ID";
        }
    }
}
