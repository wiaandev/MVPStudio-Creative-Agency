using MVPStudio_Creative_Agency.Models;
using MVPStudio_Creative_Agency.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPStudio_Creative_Agency.ViewModels
{
    class DashboardViewModel : BaseViewModel
    {
        private DashboardService _dashboardService; // injecting the service

        public ObservableCollection<Project> Projects { get; set; }

        public DashboardViewModel(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
            Projects = new ObservableCollection<Project>();
        }

        public async Task fetchAllProjects()
        {
            var projects = await _dashboardService.GetAllProjects();
            Projects.Clear();
            var firstTwoProjects = projects.Take(2); // Take the first two projects
            foreach (var project in firstTwoProjects)
            {
                Projects.Add(project);
                Debug.WriteLine($"From DBVM: {project.ClienName}");
            }

        }
    }
}
