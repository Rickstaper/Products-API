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
        Task<IEnumerable<FridgeProduct>> GetAllFridgeProductsAsync(Guid fridgeModelId, Guid fridgeId, bool trackChanges);

        Task<FridgeProduct> GetFridgeProductAsync(Guid fridgeModelId, Guid fridgeId, Guid fridgeProductId, bool trackChanges);

        Task<IEnumerable<FridgeProduct>> GetByIds(Guid fridgeModelId, Guid fridgeId, IEnumerable<Guid> ids, bool trackChanges);

        void CreateFridgeProduct(Guid fridgeId, FridgeProduct fridgeProduct);

        void DeleteFridgeProduct(FridgeProduct fridgeProduct);

        Task<IEnumerable<FridgeProduct>> GetFridgeProductsWithZeroQuantityAsync(bool tackChanges);

        void InitialiseQuantityByDefaultQuantity(ref IEnumerable<FridgeProduct> fridgeProducts, IEnumerable<Product> products);
    }
}
