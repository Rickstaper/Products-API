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
    public class FridgeProductRepository : RepositoryBase<FridgeProduct>, IFridgeProductRepository
    {
        public FridgeProductRepository(ProductsContext productsContext) 
            : base(productsContext)
        {
        }

        public void CreateFridgeProduct(Guid fridgeId, FridgeProduct fridgeProduct)
        {
            fridgeProduct.FridgeId = fridgeId;

            Create(fridgeProduct);
        }

        public void DeleteFridgeProduct(FridgeProduct fridgeProduct) => Delete(fridgeProduct);

        public async Task<IEnumerable<FridgeProduct>> GetFridgeProductsWithZeroQuantityAsync(bool trackChanges) =>
            await FindByStoredProcedure("FindFridgeProductsWithZeroQuantity", trackChanges)
            .ToListAsync();

        public async Task<IEnumerable<FridgeProduct>> GetAllFridgeProductsAsync(Guid fridgeModelId, Guid fridgeId, bool trackChanges) =>
            await FindByCondition(fridgeProduct => fridgeProduct.FridgeId.Equals(fridgeId) 
            && fridgeProduct.Fridge.FridgeModelId.Equals(fridgeModelId), trackChanges)
            .ToListAsync();

        public async Task<FridgeProduct> GetFridgeProductAsync(Guid fridgeModelId, Guid fridgeId, Guid fridgeProductId, bool trackChanges) =>
            await FindByCondition(fridgeProduct => fridgeProduct.Fridge.FridgeModelId.Equals(fridgeModelId)
            && fridgeProduct.FridgeId.Equals(fridgeId) 
            && fridgeProduct.Id.Equals(fridgeProductId), trackChanges)
            .SingleOrDefaultAsync();

        public void InitialiseQuantityByDefaultQuantity(ref IEnumerable<FridgeProduct> fridgeProducts, IEnumerable<Product> products)
        {
            foreach(Product product in products)
            {
                fridgeProducts = fridgeProducts.Select(p =>
                {
                    if (p.ProductId.Equals(product.Id))
                    {
                        p.Quantity = product.DefaultQuantity;
                    }

                    return p;
                }).ToList();
            }
        }

        public async Task<IEnumerable<FridgeProduct>> GetByIds(Guid fridgeModelId, Guid fridgeId, IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(fp => ids.Contains(fp.Id) && fp.Fridge.FridgeModelId.Equals(fridgeModelId)
            && fp.FridgeId.Equals(fridgeId), trackChanges)
            .ToListAsync();
    }
}
