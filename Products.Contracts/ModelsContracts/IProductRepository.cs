using Products.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Contracts.ModelsContracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);

        Product GetProductById(Guid productId, bool trackChanges);

        IEnumerable<Product> GetProductsFromFridgeProducts(IEnumerable<Product> products, IEnumerable<FridgeProduct> fridgeProducts);
    }
}
