using MVPStudio_Creative_Agency.Services;
using MVPStudio_Creative_Agency.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Input;

namespace MVPStudio_Creative_Agency.ViewModels
{
    class ProjectViewModel : BaseViewModel
    {
        //injecting the services I need
        private ProjectService _projectService;
        private TeamService _teamService;

        //getting the arrays of projects and clients so I can loop / map  them and set it to the front-end
        public ObservableCollection<Client> Clients { get; set; }   
        public ObservableCollection<Project> Projects { get; set; }

        public ObservableCollection<Team> Teams { get; set; }

        private Client _selectedClient;

        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                if (_selectedClient != value)
                {
                    _selectedClient = value;
                    OnPropertyChanged(nameof(SelectedClient));
                }
            }
        }

        private Team _selectedTeam;

        public Team SelectedTeam
        {
            get { return _selectedTeam; }
            set
            {
                if (_selectedTeam != value)
                {
                    _selectedTeam = value;
                    OnPropertyChanged(nameof(SelectedTeam));
                }
            }
        }
        //setting up my command to add a project to the db
        public ICommand OnAddNewProject { get; }
        public ICommand DeleteProject { get; }
        public ICommand TestCommand { get; }

        //setting up project count variable
        private string _project_Count;


        public string Project_Count
        {
            get => _project_Count;
            set => SetProperty(ref _project_Count, value);
        }

        //setting up project incomplete variable
        private string _project_Incomplete;

        public string Project_Incomplete
        {
            get => _project_Incomplete;
            set => SetProperty(ref _project_Incomplete, value);
        }

        //Project Model
        public int Id { get; set; }

        public string ClienName { get; set; }

        public string ClientProfileImg { get; set; }

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

        public string TeamAssigned { get; set; }

        private double _totalProjectCost;
        public double TotalProjectCost
        {
            get => _totalProjectCost;
            set => SetProperty(ref _totalProjectCost, value);
        }

        private DateOnly _selectedDate = DateOnly.FromDateTime(DateTime.Now);

        public DateOnly SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    OnPropertyChanged(nameof(SelectedDate));
                }
            }
        }

        public ProjectViewModel(ProjectService projectService, TeamService teamService)
        {
            _projectService = projectService;
            _teamService = teamService;
            Projects = new ObservableCollection<Project>();
            Clients = new ObservableCollection<Client>();
            Teams = new ObservableCollection<Team>();

            OnAddNewProject = new Command(async () => await AddNewProjectToDb());
            DeleteProject = new Command(async () => await DeleteAddedProject());
            TestCommand = new Command(async () => await NewTestCommand());

        }

        private async Task NewTestCommand()
        {
            Debug.WriteLine("Test button clicked");
        }

        private async Task DeleteAddedProject()
        {
            Debug.WriteLine("Delete button clicked");
            await _projectService.DeleteProjectAsync(Id);
            fetchAllProjects();
        }

        private async Task AddNewProjectToDb()
        {
            var newProject = new Project
            {
                Id = SelectedClient.Id,
                ClienName = SelectedClient.Name,
                ClientProfileImg = SelectedClient.ImgUrl,
                Project_Name = Project_Name,
                Description = Description,
                Project_Start = SelectedDate,
                Duration_Week = Duration_Week,
                Project_Time = Project_Time,
                Project_Type = Project_Type, 
                Project_Cost = Project_Cost,
                Amount_Paid = 0,
                isCompleted = true,
                Progress = 0,
                TeamAssigned = SelectedTeam.TeamName
            };

            Debug.WriteLine(newProject);

            await _projectService.AddNewProject(newProject);
            Debug.WriteLine($"Your Added Projec: { newProject}");
            _ = fetchAllProjects();

        }

        public async Task fetchAllProjects()
        {
            var projects = await _projectService.GetAllProjects();;
            Projects.Clear();
            double totalCost = 0;
            foreach (var project in projects)
            {
                    Projects.Add(project);
                    totalCost += project.Project_Cost;
                    Debug.WriteLine(project.ClienName);

                if(!project.isCompleted)
                {
                    Project_Incomplete = $"{Projects.Count()}";
                }

            }
            TotalProjectCost = totalCost;
            Project_Count = $"{Projects.Count()}";
        }

        public async Task fetchAllClients()
        {
            var clients = await _projectService.RefreshDataAsync();
            Debug.WriteLine(clients);
            Clients.Clear();
            foreach (var client in clients)
            {

                Clients.Add(client);
                Debug.WriteLine(client.Name);
            }
        }

        public async Task fetchAllTeams()
        {
            var ap = await _teamService.GetTeamsAsync();
            Debug.WriteLine(ap);
            Teams.Clear();
            foreach(var p in ap)
            {
                Teams.Add(p);
                Debug.WriteLine($"Teams: {p.TeamName}");
            }
        }

        
    }
}
