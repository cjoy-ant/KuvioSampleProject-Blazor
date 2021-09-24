using KuvioSampleProject.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectRepository projectRepository;

        public ProjectsController(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetProjects()
        {
            try
            {
                return Ok(await projectRepository.GetProjects()); // Ok derived from ControllerBase
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriveing data from the database");
            }
        }
    }
}
