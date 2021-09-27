using KuvioSampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Api.Models
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetProjects();
        Task<Project> GetProject(Guid id);
        Task<Project> AddProject(Project project);
        Task<Project> UpdateProject(Project project);
        Task<Project> DeleteProject(Guid id);

    }
}
