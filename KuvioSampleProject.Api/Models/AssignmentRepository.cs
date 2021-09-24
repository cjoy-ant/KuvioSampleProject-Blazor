using KuvioSampleProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Api.Models
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly SqlDbContext sqlDbContext;

        public AssignmentRepository(SqlDbContext sqlDbContext)
        {
            this.sqlDbContext = sqlDbContext;
        }

        public async Task<IEnumerable<Assignment>> GetAssignments()
        {
            return await sqlDbContext.Assignments.ToListAsync();
        }

        public async Task<Assignment> AddAssignment(Assignment assignment)
        {
            var result = await sqlDbContext.Assignments.AddAsync(assignment);
            await sqlDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Assignment> GetAssignment(Guid id)
        {
            return await sqlDbContext.Assignments.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Assignment> UpdateAssignment(Assignment assignment)
        {
            var assignmentToUpdate = await sqlDbContext.Assignments.FirstOrDefaultAsync(e => e.Id == assignment.Id);
            if (assignmentToUpdate != null)
            {
                assignmentToUpdate.Employee = assignment.Employee;
                assignmentToUpdate.Project = assignment.Project;
                assignmentToUpdate.DateModified = DateTime.Now;

                await sqlDbContext.SaveChangesAsync();

                return assignmentToUpdate;
            }
            return null;
        }

        public async void DeleteAssignment(Guid id)
        {
            var assignmentToDelete = await sqlDbContext.Assignments.FirstOrDefaultAsync(e => e.Id == id);
            if (assignmentToDelete != null)
            {
                sqlDbContext.Assignments.Remove(assignmentToDelete);
                await sqlDbContext.SaveChangesAsync();
            }
        }

    }
}
