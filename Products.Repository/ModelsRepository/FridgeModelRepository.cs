using Microsoft.EntityFrameworkCore;
using Products.Contracts.ModelsContracts;
using Products.Data;
using Products.Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Repository.ModelsRepository
{
    public class FridgeModelRepository : RepositoryBase<FridgeModel>, IFridgeModelRepository
    {
        public FridgeModelRepository(ProductsContext productsContext) 
            : base(productsContext)
        {
        }

        public async Task<FridgeModel> GetFridgeModelAsync(Guid fridgeModelId, bool trackChanges) =>
            await FindByCondition(fridgeModel => fridgeModel.Id.Equals(fridgeModelId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
