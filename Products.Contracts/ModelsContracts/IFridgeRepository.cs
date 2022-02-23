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
        IEnumerable<Fridge> GetAllFridges(Guid fridgeModelId, bool trackChanges);
        Fridge GetFridge(Guid fridgeModelId, Guid fridgeId, bool trackChanges);
    }
}
