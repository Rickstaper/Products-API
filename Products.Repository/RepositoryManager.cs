using Products.Contracts;
using Products.Contracts.ModelsContracts;
using Products.Data;
using Products.Repository.ModelsRepository;

namespace Products.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private ProductsContext _productContext;
        private FridgeModelRepository _fridgeModelRepository;
        private FridgeProductRepository _fridgeProductRepository;
        private FridgeRepository _fridgeRepository;
        private ProductRepository _productRepository;

        public RepositoryManager(ProductsContext productsContext)
        {
            _productContext = productsContext;
        }

        public IFridgeModelRepository FridgeModel
        {
            get
            {
                if (_fridgeModelRepository == null)
                {
                    _fridgeModelRepository = new FridgeModelRepository(_productContext);
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
                    _fridgeProductRepository = new FridgeProductRepository(_productContext);
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
                    _fridgeRepository = new FridgeRepository(_productContext);
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
                    _productRepository = new ProductRepository(_productContext);
                }

                return _productRepository;
            }
        }

        public void Save() => _productContext.SaveChanges();
    }
}
