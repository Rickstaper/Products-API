using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products.Contracts;
using Products.Data.DataTransferObject;
using Products.Data.Models;
using System;
using System.Collections.Generic;

namespace Products_API.Controllers
{
    [ApiController]
    [Route("api/fridgeModels/{fridgeModelId}/fridges/{fridgeId}/fridgeProducts")]
    public class FridgeProductController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILogger<FridgeProductController> _logger;
        private readonly IMapper _mapper;

        public FridgeProductController(IRepositoryManager repositoryManager, ILogger<FridgeProductController> logger, 
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetFridgeProductsFromFridge(Guid fridgeModelId, Guid fridgeId)
        {
            FridgeModel fridgeModelFromDb = _repositoryManager.FridgeModel.GetFridgeModel(fridgeModelId, false);

            if (fridgeModelFromDb == null)
            {
                _logger.LogInformation($"FridgeModel with id: {fridgeModelId} doesn't exist in the database.");

                return NotFound();
            }

            Fridge fridgeFromDb = _repositoryManager.Fridge.GetFridgeById(fridgeModelId, fridgeId, false);
            if (fridgeFromDb == null)
            {
                _logger.LogInformation($"Fridge with id: {fridgeId} doesn't exist in the database.");

                return NotFound();
            }

            IEnumerable<FridgeProduct> fridgeProductFromDb = _repositoryManager.FridgeProduct.GetAllFridgeProducts(fridgeModelId, fridgeId, false);

            IEnumerable<FridgeProductDto> fridgeProductDto = _mapper.Map<IEnumerable<FridgeProductDto>>(fridgeProductFromDb);

            return Ok(fridgeProductDto);
        }

        [HttpGet("{fridgeProductId}", Name = "FridgeProductById")]
        public IActionResult GetFridgeProductFromFridgeById(Guid fridgeModelId, Guid fridgeId, Guid fridgeProductId)
        {
            FridgeModel fridgeModelFromDb = _repositoryManager.FridgeModel.GetFridgeModel(fridgeModelId, false);

            if (fridgeModelFromDb == null)
            {
                _logger.LogInformation($"FridgeModel with id: {fridgeModelId} doesn't exist in the database.");

                return NotFound();
            }

            Fridge fridgeFromDb = _repositoryManager.Fridge.GetFridgeById(fridgeModelId, fridgeId, false);

            if (fridgeFromDb == null)
            {
                _logger.LogInformation($"Fridge with id: {fridgeId} doesn't exist in the database.");

                return NotFound();
            }

            FridgeProduct fridgeProductFromDb = _repositoryManager.FridgeProduct.GetFridgeProduct(fridgeModelId, 
                fridgeId, fridgeProductId, false);

            if (fridgeProductFromDb == null)
            {
                _logger.LogInformation($"Fridge product with id: {fridgeProductId} doesn't exist in the database.");

                return NotFound();
            }

            FridgeProductDto fridgeProductDto = _mapper.Map<FridgeProductDto>(fridgeProductFromDb);

            return Ok(fridgeProductDto);
        }
        //TODO: add solution about productId
        [HttpPost]
        public IActionResult CreateFridgeProduct(Guid fridgeModelId, Guid fridgeId, 
            [FromBody]FridgeProductForCreationDto fridgeProductFromBody)
        {
            if(fridgeProductFromBody == null)
            {
                _logger.LogError($"FridgeProductForCreationDto object sent from client is null.");

                return BadRequest("FridgeProductForCreationDto object is null.");
            }

            FridgeModel fridgeModelFromDb = _repositoryManager.FridgeModel.GetFridgeModel(fridgeModelId, false);

            if (fridgeModelFromDb == null)
            {
                _logger.LogInformation($"FridgeModel with id: {fridgeModelId} doesn't exist in the database.");

                return NotFound();
            }

            Fridge fridge = _repositoryManager.Fridge.GetFridgeById(fridgeModelId, fridgeId, false);

            if(fridge == null)
            {
                _logger.LogInformation($"Fridge with id: {fridgeId} doesn't exist in the database.");

                return NotFound();
            }

            FridgeProduct fridgeProductEntity = _mapper.Map<FridgeProduct>(fridgeProductFromBody);

            _repositoryManager.FridgeProduct.CreateFridgeProduct(fridgeId, fridgeProductEntity);
            _repositoryManager.Save();

            FridgeProductDto fridgeProductDtoAsResult = _mapper.Map<FridgeProductDto>(fridgeProductEntity);

            return CreatedAtRoute("FridgeProductById", new { fridgeModelId, fridgeId, fridgeProductId = fridgeProductDtoAsResult.Id }, fridgeProductDtoAsResult);
        }

        [HttpDelete("{fridgeProductId}")]
        public IActionResult DeleteFridgeProduct(Guid fridgeModelId, Guid fridgeId, Guid fridgeProductId)
        {
            FridgeModel fridgeModelFromDb = _repositoryManager.FridgeModel.GetFridgeModel(fridgeModelId, false);

            if (fridgeModelFromDb == null)
            {
                _logger.LogInformation($"FridgeModel with id: {fridgeModelId} doesn't exist in the database.");

                return NotFound();
            }

            Fridge fridge = _repositoryManager.Fridge.GetFridgeById(fridgeModelId, fridgeId, false);

            if(fridge == null)
            {
                _logger.LogInformation($"Fridge with id: {fridgeId} doesn't exist in the database.");

                return NotFound();
            }

            FridgeProduct fridgeProduct = _repositoryManager.FridgeProduct.GetFridgeProduct(fridgeModelId, fridgeId, fridgeProductId, false);

            if(fridgeProduct == null)
            {
                _logger.LogInformation($"FridgeProduct with id: {fridgeProductId} doesn't exist in the database.");

                return NotFound();
            }

            _repositoryManager.FridgeProduct.DeleteFridgeProduct(fridgeProduct);
            _repositoryManager.Save();

            return NoContent();
        }

        [HttpPut("{fridgeProductId}")]
        public IActionResult UpdateFridgeProduct(Guid fridgeModelId, Guid fridgeId, Guid fridgeProductId,
            [FromBody]FridgeProductForUpdateDto fridgeProductFromBody)
        {
            if (fridgeProductFromBody == null)
            {
                _logger.LogError($"FridgeProductForUpdateDto object sent from client is null.");

                return BadRequest("FridgeProductForUpdateDto object is null.");
            }

            FridgeModel fridgeModelFromDb = _repositoryManager.FridgeModel.GetFridgeModel(fridgeModelId, false);

            if (fridgeModelFromDb == null)
            {
                _logger.LogInformation($"FridgeModel with id: {fridgeModelId} doesn't exist in the database.");

                return NotFound();
            }

            Fridge fridgeFromDb = _repositoryManager.Fridge.GetFridgeById(fridgeModelId, fridgeId, false);

            if (fridgeFromDb == null)
            {
                _logger.LogInformation($"Fridge with id: {fridgeId} doesn't exist in the database.");

                return NotFound();
            }

            FridgeProduct fridgeProductFromDb = _repositoryManager.FridgeProduct.GetFridgeProduct(fridgeModelId,
                fridgeId, fridgeProductId, true);

            if (fridgeProductFromDb == null)
            {
                _logger.LogInformation($"Fridge product with id: {fridgeProductId} doesn't exist in the database.");

                return NotFound();
            }

            _mapper.Map(fridgeProductFromBody, fridgeProductFromDb);
            _repositoryManager.Save();

            return NoContent();
        }

        [HttpGet("AddDefaultQuantity")]
        public IActionResult AddDefaultQuantityForProductsWithZeroQuantity(Guid fridgeModelId, Guid fridgeId)
        {
            FridgeModel fridgeModelFromDb = _repositoryManager.FridgeModel.GetFridgeModel(fridgeModelId, false);

            if (fridgeModelFromDb == null)
            {
                _logger.LogInformation($"FridgeModel with id: {fridgeModelId} doesn't exist in the database.");

                return NotFound();
            }

            Fridge fridgeFromDb = _repositoryManager.Fridge.GetFridgeById(fridgeModelId, fridgeId, false);
            if (fridgeFromDb == null)
            {
                _logger.LogInformation($"Fridge with id: {fridgeId} doesn't exist in the database.");

                return NotFound();
            }

            IEnumerable<FridgeProduct> fridgeProductsWithZeroQuantity 
                = _repositoryManager.FridgeProduct.GetFridgeProductsWithZeroQuantity(true);

            IEnumerable<Product> productsFromDb = _repositoryManager.Product.GetAllProducts(false);

            IEnumerable<Product> productsFromFridgeProductsWithZeroQuantity
                = _repositoryManager.Product.GetProductsFromFridgeProducts(productsFromDb, fridgeProductsWithZeroQuantity);

            _repositoryManager.FridgeProduct.InitialiseQuantityByDefaultQuantity(ref fridgeProductsWithZeroQuantity,
                productsFromFridgeProductsWithZeroQuantity);

            _repositoryManager.Save();

            return NoContent();
        }

        //TODO: create for collection (the ninetieth page)
    }
}
