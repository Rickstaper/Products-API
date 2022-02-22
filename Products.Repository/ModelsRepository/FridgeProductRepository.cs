﻿using Products.Contracts.ModelsContracts;
using Products.Data;
using Products.Data.Models;

namespace Products.Repository.ModelsRepository
{
    public class FridgeProductRepository : RepositoryBase<FridgeProduct>, IFridgeProductRepository
    {
        public FridgeProductRepository(ProductsContext productsContext) 
            : base(productsContext)
        {
        }
    }
}
