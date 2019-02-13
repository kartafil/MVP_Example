using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Models;

namespace Shop.Services
{
    interface IProdService
    {
        IEnumerable<Product> GetProducts();
        bool AddProduct(Product product);
    }
}
