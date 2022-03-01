using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products.Contracts.AuthenticationContracts;
using Products.Data.DataTransferObject.AuthenticationDto;
using Products.Data.Models.IdentityModels;
using System.Threading.Tasks;

namespace Products_API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authenticationManager;

        public AuthenticationController(IMapper mapper, ILogger<AuthenticationController> logger, UserManager<User> userManager,
            IAuthenticationManager authenticationManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _authenticationManager = authenticationManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegirsterUser([FromBody] UserForRegistrationDto userFromBody)
        {
            if(userFromBody == null)
            {
                _logger.LogError("UserForRegistrationDto object sent from client is null.");

                return BadRequest("UserForCreationDto object is null.");
            }

            User user = _mapper.Map<User>(userFromBody);

            var result = await _userManager.CreateAsync(user, userFromBody.Password);
            if(!result.Succeeded)
            {
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            await _userManager.AddToRolesAsync(user, userFromBody.Roles);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto userFromBody)
        {
            if(!await _authenticationManager.ValidateUser(userFromBody))
            {
                _logger.LogWarning($"{nameof(Authenticate)} : Authentication failed. Wrong user name or password.");

                return Unauthorized();
            }

            return Ok(new { Token = await _authenticationManager.CreateToken() });
        }
    }
}
