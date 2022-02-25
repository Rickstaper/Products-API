using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products.Contracts;
using Products.Data.DataTransferObject;
using Products.Data.Models;
using Products_API.Utils;
using System;
using System.Collections.Generic;

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
        public IActionResult GetAllProducts()
        {
            IEnumerable<Product> productsFromDb = _repositoryManager.Product.GetAllProducts(false);

            IEnumerable<ProductDto> productDto = _mapper.Map<IEnumerable<ProductDto>>(productsFromDb);

            return Ok(productDto);
        }

        [HttpPost("{productId}/uploadImage")]
        public IActionResult UploadImage(Guid productId)
        {
            byte[] imageByteArray = FileUtility.GetImageByteArray("Kinder.jpg");

            Product productFromDb = _repositoryManager.Product.GetProductById(productId, true);

            if(productFromDb == null)
            {
                _logger.LogInformation($"ProductFromDb with id: {productId} doesn't exist in the database");

                return NotFound();
            }

            productFromDb.Image = imageByteArray;

            _repositoryManager.Save();

            return NoContent();
        }
    }
}
