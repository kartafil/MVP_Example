using Shop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop.Views
{
    public partial class ProductForm : Form, IProdView
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        public event EventHandler<ProductEventArgs> OnProductAdd;

        public bool ShowView()
        {
            return ShowDialog() == DialogResult.OK;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTitle.Text))
            {
                Product product = new Product()
                {
                    Title = txtTitle.Text,
                    Price = numericUpDown1.Value
                };

                OnProductAdd?.Invoke(this, new ProductEventArgs() { Product = product });

                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
