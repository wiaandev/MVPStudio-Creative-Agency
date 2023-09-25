using MVPStudio_Creative_Agency.Components;
using MVPStudio_Creative_Agency.Services;
using MVPStudio_Creative_Agency.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPStudio_Creative_Agency.ViewModels
{
    class ProjectCardViewModel
    {
        private readonly ProjectService _projectService;
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


        public ProjectCardViewModel(ProjectService projectService)
        {
            _projectService = projectService;
            _projectService = new ProjectService();
        }



        public async Task NavigateToOverviewScreenAsync(int id)
        {
            var viewModel = new NavigationViewModel() { NavigationParameter = id };
            Debug.WriteLine(id);
            await Shell.Current.Navigation.PushAsync(new ProjectOverviewPage { BindingContext = viewModel });
        }

        public async Task DeleteProject(int id)
        {
            try
            {
                bool deleteResult = await _projectService.DeleteProjectAsync(id);

                if (deleteResult)
                {
                    Debug.WriteLine($"Project with ID {id} deleted successfully.");
                }
                else
                {
                    Debug.WriteLine($"Failed to delete project with ID {id}.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error deleting project with ID {id}: {ex.Message}");
            }
        }
    }
}