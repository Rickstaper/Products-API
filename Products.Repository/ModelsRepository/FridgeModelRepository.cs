using Products.Contracts.ModelsContracts;
using Products.Data;
using Products.Data.Models;
using System;
using System.Linq;

namespace Products.Repository.ModelsRepository
{
    public class FridgeModelRepository : RepositoryBase<FridgeModel>, IFridgeModelRepository
    {
        public FridgeModelRepository(ProductsContext productsContext) 
            : base(productsContext)
        {
        }

        public FridgeModel GetFridgeModel(Guid fridgeModelId, bool trackChanges) =>
            FindByCondition(fridgeModel => fridgeModel.Id.Equals(fridgeModelId), trackChanges)
            .SingleOrDefault();
    }
}
