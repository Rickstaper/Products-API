using Products.Contracts.ModelsContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Contracts
{
    public interface IRepositoryManager
    {
        IFridgeModelRepository FridgeModel { get; }
        IFridgeProductRepository FridgeProduct { get; }
        IFridgeRepository Fridge { get; }
        IProductRepository Product { get; }
        Task SaveAsync();
    }
}
