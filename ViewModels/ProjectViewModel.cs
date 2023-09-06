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

        private ProjectType _selectedProjectType;

        public ObservableCollection<ProjectType> ProjectTypes { get; set; }

        public ProjectType SelectedProjectType
        {
            get { return _selectedProjectType; }
            set
            {
                if (_selectedProjectType != value)
                {
                    _selectedProjectType = value;
                    OnPropertyChanged(nameof(SelectedProjectType));
                }
            }
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

        private double _totalProjectCost;
        public double TotalProjectCost
        {
            get => _totalProjectCost;
            set => SetProperty(ref _totalProjectCost, value);
        }

        public ProjectViewModel(ProjectService projectService)
        {
            _projectService = projectService;
            Projects = new ObservableCollection<Project>();
            Clients = new ObservableCollection<Client>();

            OnAddNewProject = new Command(async () => await AddNewProjectToDb());

            ProjectTypes = new ObservableCollection<ProjectType>
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
                Project_Start = DateOnly.Parse("2023/09/23"),
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
            double totalCost = 0;
            foreach (var project in projects)
            {

                Projects.Add(project);
                totalCost += project.Project_Cost; 
                Debug.WriteLine(project.ClienName);
            }
            TotalProjectCost = totalCost;
            Project_Count = $"{Projects.Count()}";
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
