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
        IEnumerable<FridgeProduct> GetAllFridgeProducts(Guid fridgeId, bool trackChanges);

        FridgeProduct GetFridgeProduct(Guid fridgeId, Guid fridgeProductId, bool trackChanges);
    }
}
