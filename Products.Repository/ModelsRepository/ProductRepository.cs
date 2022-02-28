using Microsoft.EntityFrameworkCore;
using Products.Contracts.ModelsContracts;
using Products.Data;
using Products.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Repository.ModelsRepository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ProductsContext productsContext) 
            : base(productsContext)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(product => product.Name)
            .ToListAsync();

        public async Task<Product> GetProductByIdAsync(Guid productId, bool trackChanges) =>
            await FindByCondition(product => product.Id.Equals(productId), trackChanges)
            .SingleOrDefaultAsync();

        //TODO: fixe method
        public IEnumerable<Product> GetProductsFromFridgeProducts(IEnumerable<Product> products, IEnumerable<FridgeProduct> fridgeProducts) =>
            products.Where(p => fridgeProducts.Any(fp => fp.ProductId == p.Id))
            .ToList();
    }
}