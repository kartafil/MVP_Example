using Shop.Presenters;
using Shop.Repos;
using Shop.Services;
using Shop.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region IoC
            IoC.Register<IRepo, XmlRepo>();
            IoC.Register<IProdService, ProdService>();
            IoC.Register<IShopView, ShopForm>();
            IoC.Register<IProdView, ProductForm>();
            IoC.Register<ShopPresenter>();
            IoC.Register<ProdPresenter>();
            IoC.Build();
            #endregion

            var presenter = IoC.Resolve<ShopPresenter>();
            Application.Run((Form)presenter.View);
        }
    }
}
