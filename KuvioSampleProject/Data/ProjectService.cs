using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Data
{
    public class ProjectService : IProjectService
    {
        private List<Project> projects = new List<Project>
        {
            new Project
            {
                Id = Guid.NewGuid(),
                Title = "Project 1",
                Description = "Description of Project 1",
                Customer = "Mickey Mouse",
                Deadline = new DateTime(2021, 10, 31),
                Complete = false,
                DateModified = new DateTime(2021, 09, 21)
            },
            new Project
            {
                Id = Guid.NewGuid(),
                Title = "Project 2",
                Description = "Description of Project 2",
                Customer = "Donald Duck",
                Deadline = new DateTime(2022, 11, 30),
                Complete = false,
                DateModified = new DateTime(2021, 09, 21)
            }
        };
        public List<Project> GetProjects()
        {
            return projects;
        }
    }
}
