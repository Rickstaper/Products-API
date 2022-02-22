using Products.Contracts.ModelsContracts;
using Products.Data;
using Products.Data.Models;

namespace Products.Repository.ModelsRepository
{
    public class FridgeModelRepository : RepositoryBase<FridgeModel>, IFridgeModelRepository
    {
        public FridgeModelRepository(ProductsContext productsContext) 
            : base(productsContext)
        {
        }
    }
}
