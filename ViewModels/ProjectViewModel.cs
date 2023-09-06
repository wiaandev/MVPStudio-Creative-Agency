using MVPStudio_Creative_Agency.Services;
using MVPStudio_Creative_Agency.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Windows.ApplicationModel.Store;
using System.Windows.Input;

namespace MVPStudio_Creative_Agency.ViewModels
{
    class ProjectViewModel : BaseViewModel
    {
        //injecting the services I need
        private ProjectService _projectService;
        private ClientService _clientService;

        //getting the arrays of projects and clients so I can loop / map  them and set it to the front-end
        public ObservableCollection<Client> Clients { get; set; }   
        public ObservableCollection<Project> Projects { get; set; }

        public List<ProjectType> ProjectTypes { get; set; }

        public string _selectedProject;
        public string SelectedProjectType
        {
             get => _selectedProject;
            set => SetProperty(ref _selectedProject, value); 
        }

        //setting up my command to add a project to the db
        public ICommand OnAddNewProject { get; }

        //setting up project count variable
        private string _project_Count;
        public string Project_Count
        {
            get => _project_Count;
            set => SetProperty(ref _project_Count, value);
        }

        //Project Model
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

        public ProjectViewModel(ProjectService projectService)
        {
            _projectService = projectService;
            Projects = new ObservableCollection<Project>();
            Clients = new ObservableCollection<Client>();

            OnAddNewProject = new Command(async () => await AddNewProjectToDb());

            ProjectTypes = new List<ProjectType>
            {
                new ProjectType {Name = "Web Development"},
                new ProjectType {Name = "App Development"},
                new ProjectType {Name = "IoT"},
                new ProjectType {Name = "CMS"},
                new ProjectType {Name = "Secure System"},
                new ProjectType {Name = "Wordpress"},
                new ProjectType {Name = "Webflow"},
            };

        }

        private async Task AddNewProjectToDb()
        {
            var newProject = new Project
            {
                ClienName = ClienName,
                Project_Name = Project_Name,
                Description = Description,
                Project_Start = Project_Start,
                Duration_Week = Duration_Week,
                Project_Time = Project_Time,
                Project_Type = Project_Type, 
                Project_Cost = Project_Cost,
                Amount_Paid = 0,
                isCompleted = false,
                Progress = 0
            };

            await _projectService.AddNewProject(newProject);

            fetchAllProjects();
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
                Debug.WriteLine($"Project client is: {project.ClienName}"); // Corrected property name
                Project_Count = $"{Projects.Count}";
            }
        }

        public async Task fetchAllClients()
        {
            var clients = await _projectService.RefreshDataAsync();
            Clients.Clear();
            foreach (var client in clients)
            {

                Clients.Add(client);
                Debug.WriteLine(client.Name);
            }
        }
    }
}
