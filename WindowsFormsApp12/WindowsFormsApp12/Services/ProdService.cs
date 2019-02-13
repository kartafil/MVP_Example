using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Models;

namespace Shop.Services
{
    class ProdService : IProdService
    {
        private Repos.IRepo repo;

        public ProdService(Repos.IRepo repo)
        {
            this.repo = repo;
        }

        public bool AddProduct(Product product)
        {
            return repo.AddProduct(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return repo.GetProducts();
        }
    }
}
