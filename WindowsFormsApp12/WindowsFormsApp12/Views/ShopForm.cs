using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shop.Models;

namespace Shop.Views
{
    public partial class ShopForm : Form, IShopView
    {
        private BindingList<Product> productsBL;

        public ShopForm()
        {
            InitializeComponent();

            Init();
        }

        public event EventHandler<EventArgs> OnLoadProducts;
        public event EventHandler<EventArgs> OnNewProduct;

        public void AddProduct(Product product)
        {
            productsBL.Add(product);
        }

        public void SetProducts(IEnumerable<Product> products)
        {
            productsBL.Clear();
            foreach (var item in products)
            {
                productsBL.Add(item);
            }
        }

        private void Init()
        {
            productsBL = new BindingList<Product>();
            listBoxProds.DataSource = productsBL;
            listBoxProds.DisplayMember = "Title";
        }

        private void ShopForm_Load(object sender, EventArgs e)
        {
            OnLoadProducts?.Invoke(this, new EventArgs());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OnNewProduct?.Invoke(this, new EventArgs());
        }

        public bool ShowView()
        {
            return ShowDialog() == DialogResult.OK;
        }
    }
}
