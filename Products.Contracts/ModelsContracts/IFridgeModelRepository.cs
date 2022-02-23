using Products.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Contracts.ModelsContracts
{
    public interface IFridgeModelRepository
    {
        FridgeModel GetFridgeModel(Guid fridgeModelId, bool trackChanges);
    }
}
