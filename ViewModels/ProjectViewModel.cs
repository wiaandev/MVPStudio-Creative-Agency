using MVPStudio_Creative_Agency.Services;
using MVPStudio_Creative_Agency.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MVPStudio_Creative_Agency.ViewModels
{
    class ProjectViewModel : BaseViewModel
    {
        private ProjectService _projectService; // injecting the service

        public ObservableCollection<Project> Projects { get; set; }

        public ProjectViewModel(ProjectService projectService)
        {
            _projectService = projectService;
            Projects = new ObservableCollection<Project>();
        }

        public async Task fetchAllProjects()
        {
            var projects = await _projectService.GetAllProjects();
            Projects.Clear();
            foreach (var project in projects)
            {
                Projects.Add(project);
                Debug.WriteLine(project.Description);
                Debug.WriteLine(project.Project_Type);
                Debug.WriteLine(project.Project_Name);
                Debug.WriteLine(project.Project_Time);
                Debug.WriteLine(project.ClientId);
            }
        }
    }
}
