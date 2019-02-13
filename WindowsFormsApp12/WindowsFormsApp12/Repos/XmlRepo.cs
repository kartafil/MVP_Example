using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Shop.Models;

namespace Shop.Repos
{
    class XmlRepo : IRepo
    {
        private string path = "shop.xml";

        public bool AddProduct(Product product)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));

                    List<Product> products = serializer.Deserialize(fs) as List<Product>;
                    product.Id = products.Count == 0 ? 1 : products.Max(p => p.Id) + 1;
                    products.Add(product);
                    fs.SetLength(0);
                    serializer.Serialize(fs, products);

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            if (!File.Exists(path))
            {
                using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));

                    List<Product> products = new List<Product>();
                    serializer.Serialize(fs, products);
                    return products;
                }
            }
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
                                
                return (IEnumerable<Product>)serializer.Deserialize(fs);
            }
        }
    }
}
