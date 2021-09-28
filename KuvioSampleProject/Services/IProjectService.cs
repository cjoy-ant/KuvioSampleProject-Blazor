using KuvioSampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetProjects();
    }
}
