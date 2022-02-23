using Products.Contracts.ModelsContracts;
using Products.Data;
using Products.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Products.Repository.ModelsRepository
{
    public class FridgeRepository : RepositoryBase<Fridge>, IFridgeRepository
    {
        public FridgeRepository(ProductsContext productsContext) 
            : base(productsContext)
        {
        }

        public IEnumerable<Fridge> GetAllFridges(Guid fridgeModelId, bool trackChanges) =>
            FindByCondition(fridge => fridge.FridgeModelId.Equals(fridgeModelId), trackChanges)
            .OrderBy(fridge => fridge.Name)
            .ToList();

        public Fridge GetFridge(Guid fridgeModelId, Guid fridgeId, bool trackChanges) =>
            FindByCondition(fridge => fridge.FridgeModelId.Equals(fridgeModelId) && fridge.Id.Equals(fridgeId), trackChanges)
            .SingleOrDefault();
    }
}
