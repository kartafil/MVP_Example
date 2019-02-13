using Shop.Models;
using Shop.Services;
using Shop.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presenters
{
    class ProdPresenter
    {
        private IProdService service;
        private IProdView view;

        public IView View { get => view; }

        public Product Product { get; set; }

        public ProdPresenter(IProdService service, IProdView view)
        {
            this.service = service;
            this.view = view;

            EventSubscribe();
        }

        private void EventSubscribe()
        {
            view.OnProductAdd += Product_OnProductAdd;
        }

        private void Product_OnProductAdd(object sender, ProductEventArgs e)
        {
            service.AddProduct(e.Product);
            Product = e.Product;
        }
    }
}
