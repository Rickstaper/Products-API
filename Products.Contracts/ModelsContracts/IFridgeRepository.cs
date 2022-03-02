using Products.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Contracts.ModelsContracts
{
    public interface IFridgeRepository
    {
        Task<IEnumerable<Fridge>> GetAllFridgesAsync(Guid fridgeModelId, bool trackChanges);
        Task<Fridge> GetFridgeByIdAsync(Guid fridgeModelId, Guid fridgeId, bool trackChanges);
    }
}
