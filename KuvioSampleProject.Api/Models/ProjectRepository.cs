using KuvioSampleProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Api.Models
{
    public class ProjectRepository:IProjectRepository
    {
        private readonly SqlDbContext sqlDbContext;

        public ProjectRepository(SqlDbContext sqlDbContext)
        {
            this.sqlDbContext = sqlDbContext;
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            return await sqlDbContext.Projects.ToListAsync();
        }

        public async Task<Project> AddProject(Project project)
        {
            var result = await sqlDbContext.Projects.AddAsync(project);
            await sqlDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Project> GetProject(Guid id)
        {
            return await sqlDbContext.Projects.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Project> UpdateProject(Project project)
        {
            var projectToUpdate = await sqlDbContext.Projects.FirstOrDefaultAsync(e => e.Id == project.Id);
            if (projectToUpdate != null)
            {
                projectToUpdate.Title = project.Title;
                projectToUpdate.Description = project.Description;
                projectToUpdate.Customer = project.Customer;
                projectToUpdate.Deadline = project.Deadline;
                projectToUpdate.Complete = project.Complete;
                projectToUpdate.DateModified = DateTime.Now;

                await sqlDbContext.SaveChangesAsync();

                return projectToUpdate;
            }
            return null;
        }

        public async void DeleteProject(Guid id)
        {
            var projectToDelete = await sqlDbContext.Projects.FirstOrDefaultAsync(e => e.Id == id);
            if (projectToDelete != null)
            {
                sqlDbContext.Projects.Remove(projectToDelete);
                await sqlDbContext.SaveChangesAsync();
            }
        }

    }
}
