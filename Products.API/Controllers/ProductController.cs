using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products.Contracts;
using Products.Data.DataTransferObject;
using Products.Data.Models;
using Products_API.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products_API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;

        public ProductController(IRepositoryManager repositoryManager, ILogger<ProductController> logger,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            IEnumerable<Product> productsFromDb = await _repositoryManager.Product.GetAllProductsAsync(false);

            IEnumerable<ProductDto> productDto = _mapper.Map<IEnumerable<ProductDto>>(productsFromDb);

            return Ok(productDto);
        }

        [HttpPost("{productId}/uploadImage")]
        public async Task<IActionResult> UploadImage(Guid productId)
        {
            byte[] imageByteArray = FileHandler.GetImageByteArray("Kinder.jpg");

            Product productFromDb = await _repositoryManager.Product.GetProductByIdAsync(productId, true);

            if(productFromDb == null)
            {
                _logger.LogInformation($"ProductFromDb with id: {productId} doesn't exist in the database");

                return NotFound();
            }

            productFromDb.Image = imageByteArray;

            await _repositoryManager.SaveAsync();

            return NoContent();
        }
    }
}
