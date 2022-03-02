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
    public class FridgeRepository : RepositoryBase<Fridge>, IFridgeRepository
    {
        public FridgeRepository(ProductsContext productsContext) 
            : base(productsContext)
        {
        }

        public async Task<IEnumerable<Fridge>> GetAllFridgesAsync(Guid fridgeModelId, bool trackChanges) =>
            await FindByCondition(fridge => fridge.FridgeModelId.Equals(fridgeModelId), trackChanges)
            .OrderBy(fridge => fridge.Name)
            .ToListAsync();

        public async Task<Fridge> GetFridgeByIdAsync(Guid fridgeModelId, Guid fridgeId, bool trackChanges) =>
            await FindByCondition(fridge => fridge.FridgeModelId.Equals(fridgeModelId) && fridge.Id.Equals(fridgeId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
