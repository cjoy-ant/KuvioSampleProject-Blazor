using KuvioSampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace KuvioSampleProject.Services
{
    public class ProjectService : IProjectService
    {
        private readonly HttpClient httpClient;
        public ProjectService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Project>> GetProjects()
        {
            return await httpClient.GetFromJsonAsync<Project[]>("api/projects");
        }

    }
}
