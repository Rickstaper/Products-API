using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products.Contracts;
using Products.Data.DataTransferObject;
using System;
using System.Collections.Generic;

namespace Products_API.Controllers
{
    [ApiController]
    [Route("api/fridges/{fridgeId}/fridgeProducts")]
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
        public IActionResult GetFridgeProductsFromFridge(Guid fridgeId)
        {
            var fridgeFromDb = _repositoryManager.Fridge.GetFridge(fridgeId, false);
            if (fridgeFromDb == null)
            {
                _logger.LogInformation($"Fridge with id: {fridgeId} doesn't exist in the database.");

                return NotFound();
            }

            var fridgeProductFromDb = _repositoryManager.FridgeProduct.GetAllFridgeProducts(fridgeId, false);

            var fridgeProductDto = _mapper.Map<IEnumerable<FridgeProductDto>>(fridgeProductFromDb);

            return Ok(fridgeProductDto);
        }
    }
}
