using Microsoft.AspNetCore.Mvc;
using CreditCarbonAPI.Repositories.interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CreditCarbonAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserRepository _userRepository;


        public UserController(ILogger<UserController> logger,
            IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var listUsers = _userRepository.Gets();

            return Ok(listUsers);
        }

    }

}