using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products.Contracts;
using Products.Data.DataTransferObject;
using Products.Data.Models;
using System;

namespace Products_API.Controllers
{
    [ApiController]
    [Route("api/fridgeModels")]
    public class FridgeModelController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILogger<FridgeModelController> _logger;
        private readonly IMapper _mapper;

        public FridgeModelController(IRepositoryManager repositoryManager, ILogger<FridgeModelController> logger,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{fridgeModelId}")]
        public IActionResult GetFridgeModelById(Guid fridgeModelId)
        {
            FridgeModel fridgeModelFromDb = _repositoryManager.FridgeModel.GetFridgeModel(fridgeModelId, false);

            if(fridgeModelFromDb == null)
            {
                _logger.LogInformation($"Fridge model with id: {fridgeModelId} doesn't exist in the database.");

                return NotFound();
            }

            FridgeModelDto fridgeModelDto = _mapper.Map<FridgeModelDto>(fridgeModelFromDb);

            return Ok(fridgeModelDto);
        }
    }
}
