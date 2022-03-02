using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products.Contracts;
using Products.Data.DataTransferObject;
using Products.Data.Models;
using Products_API.ModelBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products_API.Controllers
{
    [ApiController]
    [Route("api/fridgeModels/{fridgeModelId}/fridges/{fridgeId}/fridgeProducts"), Authorize(Roles = "Owner")]
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
        public async Task<IActionResult> GetFridgeProductsFromFridgeAsync(Guid fridgeModelId, Guid fridgeId)
        {
            FridgeModel fridgeModelFromDb = await _repositoryManager.FridgeModel.GetFridgeModelAsync(fridgeModelId, false);

            if (fridgeModelFromDb == null)
            {
                _logger.LogInformation($"FridgeModel with id: {fridgeModelId} doesn't exist in the database.");

                return NotFound();
            }

            Fridge fridgeFromDb = await _repositoryManager.Fridge.GetFridgeByIdAsync(fridgeModelId, fridgeId, false);
            if (fridgeFromDb == null)
            {
                _logger.LogInformation($"Fridge with id: {fridgeId} doesn't exist in the database.");

                return NotFound();
            }

            IEnumerable<FridgeProduct> fridgeProductFromDb = await _repositoryManager.FridgeProduct.GetAllFridgeProductsAsync(fridgeModelId, fridgeId, false);

            IEnumerable<FridgeProductDto> fridgeProductDto = _mapper.Map<IEnumerable<FridgeProductDto>>(fridgeProductFromDb);

            return Ok(fridgeProductDto);
        }

        [HttpGet("{fridgeProductId}", Name = "FridgeProductById")]
        public async Task<IActionResult> GetFridgeProductFromFridgeByIdAsync(Guid fridgeModelId, Guid fridgeId, Guid fridgeProductId)
        {
            FridgeModel fridgeModelFromDb = await _repositoryManager.FridgeModel.GetFridgeModelAsync(fridgeModelId, false);

            if (fridgeModelFromDb == null)
            {
                _logger.LogInformation($"FridgeModel with id: {fridgeModelId} doesn't exist in the database.");

                return NotFound();
            }

            Fridge fridgeFromDb = await _repositoryManager.Fridge.GetFridgeByIdAsync(fridgeModelId, fridgeId, false);

            if (fridgeFromDb == null)
            {
                _logger.LogInformation($"Fridge with id: {fridgeId} doesn't exist in the database.");

                return NotFound();
            }

            FridgeProduct fridgeProductFromDb = await _repositoryManager.FridgeProduct.GetFridgeProductAsync(fridgeModelId, 
                fridgeId, fridgeProductId, false);

            if (fridgeProductFromDb == null)
            {
                _logger.LogInformation($"Fridge product with id: {fridgeProductId} doesn't exist in the database.");

                return NotFound();
            }

            FridgeProductDto fridgeProductDto = _mapper.Map<FridgeProductDto>(fridgeProductFromDb);

            return Ok(fridgeProductDto);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateFridgeProductAsync(Guid fridgeModelId, Guid fridgeId, 
            [FromBody]FridgeProductForCreationDto fridgeProductFromBody)
        {
            if(fridgeProductFromBody == null)
            {
                _logger.LogError($"FridgeProductForCreationDto object sent from client is null.");

                return BadRequest("FridgeProductForCreationDto object is null.");
            }

            FridgeModel fridgeModelFromDb = await _repositoryManager.FridgeModel.GetFridgeModelAsync(fridgeModelId, false);

            if (fridgeModelFromDb == null)
            {
                _logger.LogInformation($"FridgeModel with id: {fridgeModelId} doesn't exist in the database.");

                return NotFound();
            }

            Fridge fridge = await _repositoryManager.Fridge.GetFridgeByIdAsync(fridgeModelId, fridgeId, false);

            if(fridge == null)
            {
                _logger.LogInformation($"Fridge with id: {fridgeId} doesn't exist in the database.");

                return NotFound();
            }

            FridgeProduct fridgeProductEntity = _mapper.Map<FridgeProduct>(fridgeProductFromBody);

            _repositoryManager.FridgeProduct.CreateFridgeProduct(fridgeId, fridgeProductEntity);
            await _repositoryManager.SaveAsync();

            FridgeProductDto fridgeProductDtoAsResult = _mapper.Map<FridgeProductDto>(fridgeProductEntity);

            return CreatedAtRoute("FridgeProductById", new { fridgeModelId, fridgeId, fridgeProductId = fridgeProductDtoAsResult.Id },
                fridgeProductDtoAsResult);
        }

        [HttpDelete("{fridgeProductId}")]
        public async Task<IActionResult> DeleteFridgeProductAsync(Guid fridgeModelId, Guid fridgeId, Guid fridgeProductId)
        {
            FridgeModel fridgeModelFromDb = await _repositoryManager.FridgeModel.GetFridgeModelAsync(fridgeModelId, false);

            if (fridgeModelFromDb == null)
            {
                _logger.LogInformation($"FridgeModel with id: {fridgeModelId} doesn't exist in the database.");

                return NotFound();
            }

            Fridge fridge = await _repositoryManager.Fridge.GetFridgeByIdAsync(fridgeModelId, fridgeId, false);

            if(fridge == null)
            {
                _logger.LogInformation($"Fridge with id: {fridgeId} doesn't exist in the database.");

                return NotFound();
            }

            FridgeProduct fridgeProduct = await _repositoryManager.FridgeProduct.GetFridgeProductAsync(fridgeModelId, fridgeId, fridgeProductId, false);

            if(fridgeProduct == null)
            {
                _logger.LogInformation($"FridgeProduct with id: {fridgeProductId} doesn't exist in the database.");

                return NotFound();
            }

            _repositoryManager.FridgeProduct.DeleteFridgeProduct(fridgeProduct);
            await _repositoryManager.SaveAsync();

            return NoContent();
        }

        [HttpPut("{fridgeProductId}")]
        public async Task<IActionResult> UpdateFridgeProductAsync(Guid fridgeModelId, Guid fridgeId, Guid fridgeProductId,
            [FromBody]FridgeProductForUpdateDto fridgeProductFromBody)
        {
            if (fridgeProductFromBody == null)
            {
                _logger.LogError($"FridgeProductForUpdateDto object sent from client is null.");

                return BadRequest("FridgeProductForUpdateDto object is null.");
            }

            FridgeModel fridgeModelFromDb = await _repositoryManager.FridgeModel.GetFridgeModelAsync(fridgeModelId, false);

            if (fridgeModelFromDb == null)
            {
                _logger.LogInformation($"FridgeModel with id: {fridgeModelId} doesn't exist in the database.");

                return NotFound();
            }

            Fridge fridgeFromDb = await _repositoryManager.Fridge.GetFridgeByIdAsync(fridgeModelId, fridgeId, false);

            if (fridgeFromDb == null)
            {
                _logger.LogInformation($"Fridge with id: {fridgeId} doesn't exist in the database.");

                return NotFound();
            }

            FridgeProduct fridgeProductFromDb = await _repositoryManager.FridgeProduct.GetFridgeProductAsync(fridgeModelId,
                fridgeId, fridgeProductId, true);

            if (fridgeProductFromDb == null)
            {
                _logger.LogInformation($"Fridge product with id: {fridgeProductId} doesn't exist in the database.");

                return NotFound();
            }

            _mapper.Map(fridgeProductFromBody, fridgeProductFromDb);
            await _repositoryManager.SaveAsync();

            return NoContent();
        }

        [HttpGet("AddDefaultQuantity")]
        public async Task<IActionResult> AddDefaultQuantityForProductsWithZeroQuantityAsync(Guid fridgeModelId, Guid fridgeId)
        {
            FridgeModel fridgeModelFromDb = await _repositoryManager.FridgeModel.GetFridgeModelAsync(fridgeModelId, false);

            if (fridgeModelFromDb == null)
            {
                _logger.LogInformation($"FridgeModel with id: {fridgeModelId} doesn't exist in the database.");

                return NotFound();
            }

            Fridge fridgeFromDb = await _repositoryManager.Fridge.GetFridgeByIdAsync(fridgeModelId, fridgeId, false);
            if (fridgeFromDb == null)
            {
                _logger.LogInformation($"Fridge with id: {fridgeId} doesn't exist in the database.");

                return NotFound();
            }

            IEnumerable<FridgeProduct> fridgeProductsWithZeroQuantity 
                = await _repositoryManager.FridgeProduct.GetFridgeProductsWithZeroQuantityAsync(true);

            IEnumerable<Product> productsFromDb = await _repositoryManager.Product.GetAllProductsAsync(false);

            IEnumerable<Product> productsFromFridgeProductsWithZeroQuantity
                = _repositoryManager.Product.GetProductsFromFridgeProducts(productsFromDb, fridgeProductsWithZeroQuantity);

            _repositoryManager.FridgeProduct.InitialiseQuantityByDefaultQuantity(ref fridgeProductsWithZeroQuantity,
                productsFromFridgeProductsWithZeroQuantity);

            await _repositoryManager.SaveAsync();

            return NoContent();
        }

        [HttpGet("collection/{ids}", Name = "FridgeProductsCollection")]
        public async Task<IActionResult> GetFridgeProductCollectionAsync([ModelBinder(BinderType = typeof(ArrayModelBinder))] Guid fridgeModelId, Guid fridgeId, IEnumerable<Guid> ids)
        {
            FridgeModel fridgeModelFromDb = await _repositoryManager.FridgeModel.GetFridgeModelAsync(fridgeModelId, false);

            if (fridgeModelFromDb == null)
            {
                _logger.LogInformation($"FridgeModel with id: {fridgeModelId} doesn't exist in the database.");

                return NotFound();
            }

            Fridge fridgeFromDb = await _repositoryManager.Fridge.GetFridgeByIdAsync(fridgeModelId, fridgeId, false);
            if (fridgeFromDb == null)
            {
                _logger.LogInformation($"Fridge with id: {fridgeId} doesn't exist in the database.");

                return NotFound();
            }

            if(ids == null)
            {
                _logger.LogError("Parameter ids is null.");

                return BadRequest("Parameter ids is null.");
            }

            IEnumerable<FridgeProduct> fridgeProductsFromDb = await _repositoryManager.FridgeProduct.GetByIds(fridgeModelId, fridgeId, ids, false); 

            if(ids.Count() != fridgeProductsFromDb.Count())
            {
                _logger.LogError("Some ids are not valid in a collection");

                return NotFound();
            }

            IEnumerable<FridgeProductDto> fridgeProductsToReturn = _mapper.Map<IEnumerable<FridgeProductDto>>(fridgeProductsFromDb);

            return Ok(fridgeProductsToReturn);
         }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateFridgeProductsCollectionAsync(Guid fridgeModelId, Guid fridgeId,
            [FromBody] IEnumerable<FridgeProductForCreationDto> fridgeProductsFromBody)
        {
            if (fridgeProductsFromBody == null)
            {
                _logger.LogError($"FridgeProductForCreationDto object sent from client is null.");

                return BadRequest("FridgeProductForCreationDto object is null.");
            }

            FridgeModel fridgeModelFromDb = await _repositoryManager.FridgeModel.GetFridgeModelAsync(fridgeModelId, false);

            if (fridgeModelFromDb == null)
            {
                _logger.LogInformation($"FridgeModel with id: {fridgeModelId} doesn't exist in the database.");

                return NotFound();
            }

            Fridge fridge = await _repositoryManager.Fridge.GetFridgeByIdAsync(fridgeModelId, fridgeId, false);

            if (fridge == null)
            {
                _logger.LogInformation($"Fridge with id: {fridgeId} doesn't exist in the database.");

                return NotFound();
            }

            IEnumerable<FridgeProduct> fridgeProductsEntity = _mapper.Map<IEnumerable<FridgeProduct>>(fridgeProductsFromBody);

            foreach(FridgeProduct fridgeProduct in fridgeProductsEntity)
            {
                _repositoryManager.FridgeProduct.CreateFridgeProduct(fridgeId, fridgeProduct);
            }

            await _repositoryManager.SaveAsync();

            IEnumerable<FridgeProductDto> fridgeProductsToReturn = _mapper.Map<IEnumerable<FridgeProductDto>>(fridgeProductsEntity);

            string ids = string.Join(",", fridgeProductsToReturn.Select(fpd => fpd.Id));

            return CreatedAtRoute("FridgeProductsCollection", new { fridgeModelId, fridgeId, ids }, fridgeProductsToReturn);
        }
    }
}
