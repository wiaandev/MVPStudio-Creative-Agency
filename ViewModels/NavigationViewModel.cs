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
    class NavigationViewModel : BaseViewModel
    {
        private ProjectService _projectService;
        public Project Projects { get; set; }
        public int Id { get; set; }

        public string ClienName { get; set; }

        public string Project_Name { get; set; }

        public string Description { get; set; }

        public DateOnly Project_Start { get; set; }
        public int Duration_Week { get; set; }

        public int Project_Time { get; set; }

        public string Project_Type { get; set; }

        public int Project_Cost { get; set; }

        public int Amount_Paid { get; set; }

        public bool isCompleted { get; set; }

        public int Progress { get; set; }

        public int NavigationParameter { get; set; }

        public int Project_Progress { get; set; }

        public NavigationViewModel()
        {
            _projectService = new ProjectService();
            Projects = new Project();
        }

        public async Task fetchSingleProject(int id)
        {
            var project = await _projectService.GetSingleProject(id);
            if (project != null)
            {
                Projects = project;
                OnPropertyChanged(nameof(Projects));
                Debug.WriteLine($"1. Project client is: {project.ClienName}"); // Corrected property name
            }
        }
    }
}