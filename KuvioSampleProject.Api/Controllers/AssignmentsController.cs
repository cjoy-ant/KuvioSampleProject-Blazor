using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KuvioSampleProject.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KuvioSampleProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly IAssignmentRepository assignmentsRepository;

        public AssignmentsController(IAssignmentRepository assignmentsRepository)
        {
            this.assignmentsRepository = assignmentsRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAssignments()
        {
            try
            {
                return Ok(await assignmentsRepository.GetAssignments()); // Ok derived from ControllerBase
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriveing data from the database");
            }
        }
    }
}
