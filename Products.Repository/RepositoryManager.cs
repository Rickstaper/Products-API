using Products.Contracts;
using Products.Contracts.ModelsContracts;
using Products.Data;
using Products.Repository.ModelsRepository;
using System.Threading.Tasks;

namespace Products.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private ProductsContext _productsContext;
        private FridgeModelRepository _fridgeModelRepository;
        private FridgeProductRepository _fridgeProductRepository;
        private FridgeRepository _fridgeRepository;
        private ProductRepository _productRepository;

        public RepositoryManager(ProductsContext productsContext)
        {
            _productsContext = productsContext;
        }

        public IFridgeModelRepository FridgeModel
        {
            get
            {
                if (_fridgeModelRepository == null)
                {
                    _fridgeModelRepository = new FridgeModelRepository(_productsContext);
                }

                return _fridgeModelRepository;
            }
        }
        public IFridgeProductRepository FridgeProduct
        {
            get
            {
                if(_fridgeProductRepository == null)
                {
                    _fridgeProductRepository = new FridgeProductRepository(_productsContext);
                }

                return _fridgeProductRepository;
            }
        }
        public IFridgeRepository Fridge
        {
            get
            {
                if (_fridgeRepository == null)
                {
                    _fridgeRepository = new FridgeRepository(_productsContext);
                }

                return _fridgeRepository;
            }
        }
        public IProductRepository Product
        {
            get
            {
                if(_productRepository == null)
                {
                    _productRepository = new ProductRepository(_productsContext);
                }

                return _productRepository;
            }
        }

        public Task SaveAsync() => _productsContext.SaveChangesAsync();
    }
}
