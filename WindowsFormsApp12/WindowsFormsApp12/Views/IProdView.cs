using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Models;
using Shop.Views;

namespace Shop.Views
{
    interface IProdView: IView
    {
        event EventHandler<ProductEventArgs> OnProductAdd;
    }

    public class ProductEventArgs: EventArgs
    {
        public Product Product { get; set; }
    }
}
