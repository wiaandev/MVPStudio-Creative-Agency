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

        private string _project_Count;
        public string Project_Count
        {
            get => _project_Count;
            set => SetProperty(ref _project_Count, value);
        }

        private string _client_Name;
        public string ClienName
        {
            get => _client_Name;
            set => SetProperty(ref _client_Name, value);
        }

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
                Debug.WriteLine(project.ClienName);
            }

            Project_Count = $"{Projects.Count()}";
        }

        public async Task fetchSingleProject(int id)
        {
            var project = await _projectService.GetSingleProject(id);
            Projects.Clear();

            if (project != null)
            {
                Projects.Add(project);
                Debug.WriteLine($"Project client is: {Projects.First()}"); // Corrected property name
                Project_Count = $"{Projects.Count}";
            }
        }
    }
}
