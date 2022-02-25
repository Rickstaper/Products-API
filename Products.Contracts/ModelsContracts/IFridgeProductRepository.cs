using Products.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Contracts.ModelsContracts
{
    public interface IFridgeProductRepository
    {
        IEnumerable<FridgeProduct> GetAllFridgeProducts(Guid fridgeModelId, Guid fridgeId, bool trackChanges);

        FridgeProduct GetFridgeProduct(Guid fridgeModelId, Guid fridgeId, Guid fridgeProductId, bool trackChanges);

        void CreateFridgeProduct(Guid fridgeId, FridgeProduct fridgeProduct);

        void DeleteFridgeProduct(FridgeProduct fridgeProduct);

        IEnumerable<FridgeProduct> GetFridgeProductsWithZeroQuantity(bool tackChanges);

        void InitialiseQuantityByDefaultQuantity(ref IEnumerable<FridgeProduct> fridgeProducts, IEnumerable<Product> products);
    }
}
