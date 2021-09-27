using KuvioSampleProject.Api.Models;
using KuvioSampleProject.Models;
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

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Project>> GetProject(Guid id)
        {
            try
            {
                var result = await projectRepository.GetProject(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Project>> CreateProject(Project project)
        {
            try
            {
                if (project == null)
                {
                    return BadRequest();
                }

                var createdProject = await projectRepository.AddProject(project);

                return CreatedAtAction(nameof(GetProject), new { id = createdProject.Id }, createdProject);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error posting data to the database");
            }
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<Project>> UpdateProject(Guid id, Project project)
        {
            try
            {
                if (id != project.Id)
                {
                    return BadRequest("Project ID mismatch");
                }
                var projectToUpdate = await projectRepository.GetProject(id);

                if (projectToUpdate == null)
                {
                    return NotFound($"Project with Id = {id} not found");
                }
                return await projectRepository.UpdateProject(project);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data in the database");
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<Project>> DeleteProject(Guid id)
        {
            try
            {
                var projectToDelete = await projectRepository.DeleteProject(id);

                if (projectToDelete == null)
                {
                    return NotFound($"Project with Id = {id} not found");
                }
                return await projectRepository.DeleteProject(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error removing data in the database");
            }
        }
    }
}
