using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products.Contracts;
using Products.Data.DataTransferObject;
using System;
using System.Collections.Generic;

namespace Products_API.Controllers
{
    [Route("api/fridges")]
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
        public IActionResult GetFridges()
        {
            var fridges = _repositoryManager.Fridge.GetAllFridges(false);

            var fridgesDto = _mapper.Map<IEnumerable<FridgeDto>>(fridges);

            return Ok(fridgesDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetFridgeById(Guid id)
        {
            var fridge = _repositoryManager.Fridge.GetFridge(id, false);

            if (fridge == null)
            {
                _logger.LogInformation($"Fridge with id: {id} doesn't exisit in the database");

                return NotFound();
            }

            var fridgeDto = _mapper.Map<FridgeDto>(fridge);

            return Ok(fridgeDto);
        }


    }
}
