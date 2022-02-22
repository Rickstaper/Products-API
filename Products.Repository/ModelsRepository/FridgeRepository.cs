using Products.Contracts.ModelsContracts;
using Products.Data;
using Products.Data.Models;
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

        public IEnumerable<Fridge> GetAllFridges(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToList();
    }
}
