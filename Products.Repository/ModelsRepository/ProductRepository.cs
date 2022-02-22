using Products.Contracts.ModelsContracts;
using Products.Data;
using Products.Data.Models;
namespace Products.Repository.ModelsRepository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ProductsContext productsContext) 
            : base(productsContext)
        {
        }
    }
}
