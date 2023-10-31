using Microsoft.AspNetCore.Mvc;
using CreditCarbonAPI.Models;
using CreditCarbonAPI.Repositories;
using CreditCarbonAPI.Repositories.interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CreditCarbonAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProjectCarbonController : ControllerBase
    {
        private readonly ILogger<ProjectCarbonController> _logger;
        private IProjectCarbonRepository _projectCarbonRepository;


        public ProjectCarbonController(ILogger<ProjectCarbonController> logger,
            IProjectCarbonRepository projectCarbonRepository)
        {
            _logger = logger;
            _projectCarbonRepository = projectCarbonRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var listProjectCarbon = _projectCarbonRepository.Gets();

            return Ok(listProjectCarbon);
        }

        [HttpGet("technologyTypeCombobox")]
        public IActionResult GetTechnologyTypeCombobox()
        {
            var listTechnologyType = _projectCarbonRepository.GetTechnologyTypeCombobox();

            return Ok(listTechnologyType);
        }

        [HttpGet("GetById")]
        public IActionResult GetProjectCarbonById(int id)
        {
            var result = _projectCarbonRepository.GetProjectCarbonById(id);

            return Ok(result);
        }

        [HttpPost("Insert")]
        public IActionResult Insert(ProjectCarbonById data)
        {
            var result = _projectCarbonRepository.Insert(data);

            return Ok(result);
        }

        

    }

}