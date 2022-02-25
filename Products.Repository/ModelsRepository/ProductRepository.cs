using Products.Contracts.ModelsContracts;
using Products.Data;
using Products.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Products.Repository.ModelsRepository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ProductsContext productsContext) 
            : base(productsContext)
        {
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(product => product.Name)
            .ToList();

        public Product GetProductById(Guid productId, bool trackChanges) =>
            FindByCondition(product => product.Id.Equals(productId), trackChanges)
            .SingleOrDefault();

        public IEnumerable<Product> GetProductsFromFridgeProducts(IEnumerable<Product> products, 
            IEnumerable<FridgeProduct> fridgeProducts) =>
            products.Where(p => fridgeProducts.Any(fp => fp.ProductId == p.Id))
            .ToList();
    }
}