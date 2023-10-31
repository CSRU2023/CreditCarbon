using Microsoft.AspNetCore.Mvc;
using CreditCarbonAPI.Repositories.interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using CreditCarbonAPI.Models;

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

        [HttpGet("GetById")]
        public IActionResult GetById(int Id)
        {
            var Result = _userRepository.GetUserById(Id);

            return Ok(Result);
        }

        [HttpPost("Save")]
        public IActionResult Insert(User model)
        {
            var result = _userRepository.SaveUser(model);
            if (!result)
            {
                return BadRequest("Duplicate UserName");
            }
            
            return Ok(true);
            
        }

    }

}