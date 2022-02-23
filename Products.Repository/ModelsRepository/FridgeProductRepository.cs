using Products.Contracts.ModelsContracts;
using Products.Data;
using Products.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Products.Repository.ModelsRepository
{
    public class FridgeProductRepository : RepositoryBase<FridgeProduct>, IFridgeProductRepository
    {
        public FridgeProductRepository(ProductsContext productsContext) 
            : base(productsContext)
        {
        }

        public IEnumerable<FridgeProduct> GetAllFridgeProducts(Guid fridgeId, bool trackChanges) =>
            FindByCondition(fridgeProduct => fridgeProduct.FridgeId.Equals(fridgeId), trackChanges);

        public FridgeProduct GetFridgeProduct(Guid fridgeId, Guid fridgeProductId, bool trackChanges) =>
            FindByCondition(fridgeProduct => fridgeProduct.FridgeId.Equals(fridgeId) && fridgeProduct.Id.Equals(fridgeProductId), trackChanges)
            .SingleOrDefault();
    }
}
