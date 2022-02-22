using Entities;
using Entities.Models;
using Products.Contracts.ModelsContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
