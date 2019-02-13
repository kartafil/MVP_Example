using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shop.Services;
using Shop.Views;
using Shop.Presenters;

namespace Shop.Presenters
{
    class ShopPresenter
    {
        private IShopView shopView;
        private IProdService prodService;

        public IView View { get => shopView; }

        public ShopPresenter(IShopView shopView, IProdService prodService)
        {
            this.shopView = shopView;
            this.prodService = prodService;

            EventSubscribe();
        }

        private void EventSubscribe()
        {
            shopView.OnLoadProducts += ShopView_OnLoadProducts;
            shopView.OnNewProduct += ShopView_OnNewProduct;
        }

        private void ShopView_OnLoadProducts(object sender, EventArgs e)
        {
            var prods = prodService.GetProducts();
            shopView.SetProducts(prods);
        }

        private void ShopView_OnNewProduct(object sender, EventArgs e)
        {
            var prodPresenter = IoC.Resolve<ProdPresenter>();

            if (prodPresenter.View.ShowView())
            {
                shopView.AddProduct(prodPresenter.Product);
            }
        }
    }
}
