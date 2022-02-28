using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products.Data.DataTransferObject.AuthenticationDto;
using Products.Data.Models.IdentityModels;

namespace Products_API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly UserManager<User> _userManager;

        public AuthenticationController(IMapper mapper, ILogger<AuthenticationController> logger, UserManager<User> userManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        //[HttpPost]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        //public IActionResult RegirsterUser([FromBody] UserForRegistrationDto userFromBody)
        //{

        //}
    }
}
