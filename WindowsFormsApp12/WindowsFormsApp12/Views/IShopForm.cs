using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Views
{
    interface IShopView: IView
    {
        event EventHandler<EventArgs> OnLoadProducts;
        event EventHandler<EventArgs> OnNewProduct;
        void SetProducts(IEnumerable<Shop.Models.Product> products);
        void AddProduct(Shop.Models.Product product);
    }
}
