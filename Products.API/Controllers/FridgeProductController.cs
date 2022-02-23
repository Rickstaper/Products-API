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
            Fridge fridgeFromDb = _repositoryManager.Fridge.GetFridge(fridgeModelId, fridgeId, false);
            if (fridgeFromDb == null)
            {
                _logger.LogInformation($"Fridge with id: {fridgeId} doesn't exist in the database.");

                return NotFound();
            }

            IEnumerable<FridgeProduct> fridgeProductFromDb = _repositoryManager.FridgeProduct.GetAllFridgeProducts(fridgeModelId, fridgeId, false);

            IEnumerable<FridgeProductDto> fridgeProductDto = _mapper.Map<IEnumerable<FridgeProductDto>>(fridgeProductFromDb);

            return Ok(fridgeProductDto);
        }

        [HttpGet("{fridgeProductId}")]
        public IActionResult GetFridgeProductFromFridgeById(Guid fridgeModelId, Guid fridgeId, Guid fridgeProductId)
        {
            Fridge fridgeFromDb = _repositoryManager.Fridge.GetFridge(fridgeModelId, fridgeId, false);

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
    }
}
