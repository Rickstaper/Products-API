using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products.Contracts;
using Products.Data.DataTransferObject;
using Products.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products_API.Controllers
{
    [Route("api/fridgeModels/{fridgeModelId}/fridges")]
    [ApiController]
    public class FridgeController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILogger<FridgeController> _logger;
        private readonly IMapper _mapper;

        public FridgeController(IRepositoryManager repositoryManager, ILogger<FridgeController> logger,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFridges(Guid fridgeModelId)
        {
            FridgeModel fridgeModelFromDb = await _repositoryManager.FridgeModel.GetFridgeModelAsync(fridgeModelId, false);

            if (fridgeModelFromDb == null)
            {
                _logger.LogInformation($"FridgeModelFromDb with id: {fridgeModelId} doesn't exist in the database.");

                return NotFound();
            }

            IEnumerable<Fridge> fridgesFromDb = await _repositoryManager.Fridge.GetAllFridgesAsync(fridgeModelId, false);

            var fridgesDto = _mapper.Map<IEnumerable<FridgeDto>>(fridgesFromDb);

            return Ok(fridgesDto);
        }

        [HttpGet("{fridgeId}")]
        public async Task<IActionResult> GetFridgeById(Guid fridgeModelId, Guid fridgeId)
        {
            FridgeModel fridgeModelFromDb = await _repositoryManager.FridgeModel.GetFridgeModelAsync(fridgeModelId, false);

            if (fridgeModelFromDb == null)
            {
                _logger.LogInformation($"FridgeModelFromDb with id: {fridgeId} doesn't exist in the database.");

                return NotFound();
            }

            Fridge fridgeFromDb = await _repositoryManager.Fridge.GetFridgeByIdAsync(fridgeModelId, fridgeId, false);

            if (fridgeFromDb == null)
            {
                _logger.LogInformation($"Fridge with id: {fridgeId} doesn't exisit in the database");

                return NotFound();
            }

            var fridgeDto = _mapper.Map<FridgeDto>(fridgeFromDb);

            return Ok(fridgeDto);
        }

        [HttpPut("{fridgeId}")]
        public async Task<IActionResult> UpdateFridge(Guid fridgeModelId, Guid fridgeId,
            [FromBody]FridgeForUpdateDto fridgeFromBody)
        {
            if(fridgeFromBody == null)
            {
                _logger.LogError("FridgeForUpdateDto object sent from client is null.");

                return BadRequest("FridgeForUpdateDto object is null.");
            }

            FridgeModel fridgeModelFromDb = await _repositoryManager.FridgeModel.GetFridgeModelAsync(fridgeModelId, false);

            if(fridgeModelFromDb == null)
            {
                _logger.LogInformation($"FridgeModelFromDb with id: {fridgeModelId} doesn't exist in the database.");

                return NotFound();
            }

            Fridge fridgeFromDb = await _repositoryManager.Fridge.GetFridgeByIdAsync(fridgeModelId, fridgeId, true);

            if (fridgeFromDb == null)
            {
                _logger.LogInformation($"Fridge with id: {fridgeId} doesn't exisit in the database");

                return NotFound();
            }

            _mapper.Map(fridgeFromBody, fridgeFromDb);
            await _repositoryManager.SaveAsync();

            return NoContent();
        }


        //TODO: realise post method for create also fridge products
        //TODO: realise cascade delete
    }
}
