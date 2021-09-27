using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KuvioSampleProject.Api.Models;
using KuvioSampleProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KuvioSampleProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly IAssignmentRepository assignmentRepository;

        public AssignmentsController(IAssignmentRepository assignmentRepository)
        {
            this.assignmentRepository = assignmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAssignments()
        {
            try
            {
                return Ok(await assignmentRepository.GetAssignments()); // Ok derived from ControllerBase
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriveing data from the database");
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Assignment>> GetAssignment(Guid id)
        {
            try
            {
                var result = await assignmentRepository.GetAssignment(id);
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
        public async Task<ActionResult<Project>> CreateAssignment(Assignment assignment)
        {
            try
            {
                if (assignment == null)
                {
                    return BadRequest();
                }

                var createdAssignment = await assignmentRepository.AddAssignment(assignment);

                return CreatedAtAction(nameof(GetAssignment), new { id = createdAssignment.Id }, createdAssignment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

    }
}
