using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KuvioSampleProject.Models;

namespace KuvioSampleProject.Data
{
    interface IProjectService
    {
        List<Project> GetProjects();

        Project GetProject(Guid id);

        void UpdateProject(Project project);

        void AddProject(Project project);

        void DeleteProject(Guid id);
    }
}
