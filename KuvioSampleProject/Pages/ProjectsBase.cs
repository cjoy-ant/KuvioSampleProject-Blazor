using KuvioSampleProject.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Pages
{
    public class ProjectsBase : ComponentBase
    {
        [Inject]
        public IProjectService ProjectService { get; set; }

        public IEnumerable<KuvioSampleProject.Models.Project> Projects { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Projects = (await ProjectService.GetProjects()).ToList();
        }

    }
}
