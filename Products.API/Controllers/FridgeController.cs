using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products.Contracts;
using System;

namespace Products_API.Controllers
{
    [Route("api/fridges")]
    [ApiController]
    public class FridgeController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILogger<FridgeController> _logger;

        public FridgeController(IRepositoryManager repositoryManager, ILogger<FridgeController> logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetFridges()
        {
            try
            {
                var fridges = _repositoryManager.Fridge.GetAllFridges(false);

                return Ok(fridges);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetFridges)} action {ex}");
                return StatusCode(500, "Internel server error");
            }
        }
    }
}
