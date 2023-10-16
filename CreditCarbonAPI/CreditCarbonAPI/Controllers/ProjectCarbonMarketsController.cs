using Microsoft.AspNetCore.Mvc;
using CreditCarbonAPI.Models;
using CreditCarbonAPI.Repositories;
using CreditCarbonAPI.Repositories.interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CreditCarbonAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProjectCarbonMarketsController : ControllerBase
    {
        private readonly ILogger<ProjectCarbonMarketsController> _logger;
        private IProjectCarbonMarketsRepository _projectCarbonMarketsRepository;


        public ProjectCarbonMarketsController(ILogger<ProjectCarbonMarketsController> logger,
            IProjectCarbonMarketsRepository projectCarbonMarketsRepository)
        {
            _logger = logger;
            _projectCarbonMarketsRepository = projectCarbonMarketsRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var listProjectCarbonMarkets = _projectCarbonMarketsRepository.Gets();

            return Ok(listProjectCarbonMarkets);
        }

    }

}