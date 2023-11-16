using MVPStudio_Creative_Agency.Models;
using MVPStudio_Creative_Agency.Services;
using MVPStudio_Creative_Agency.ViewModels;
using System.Diagnostics;

namespace MVPStudio_Creative_Agency.Views;

public partial class ProjectOverviewPage : ContentPage
{




    public int ProjectId { get; set; }

    public string ClienName { get; set; } = "yes";

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

    public string Project_Progress { get; set; }

    private ProjectViewModel _projectViewModel;


    public ProjectOverviewPage()
    {
        InitializeComponent();
        _projectViewModel = new ProjectViewModel(new ProjectService(), new TeamService());
        BindingContext = _projectViewModel;

        teamPicker.SelectedIndexChanged += (sender, args) =>
        {
            if (teamPicker.SelectedIndex >= 0)
            {
                _projectViewModel.SelectedTeam = (Team)teamPicker.SelectedItem;
                Debug.WriteLine($"Selected team is: {_projectViewModel.SelectedTeam.TeamName}");
            }
        };

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _projectViewModel.fetchAllTeams();
        Debug.WriteLine("DONE FETCHING TEAMS IN INDIVIDUAL VIEW");
        Debug.WriteLine($"Total teams are {_projectViewModel.Teams.Count}");

        if (BindingContext is NavigationViewModel viewModel)
        {
            if (viewModel.NavigationParameter is int id)
            {
                await viewModel.fetchSingleProject(id);
                BindingContext = viewModel;
                Debug.WriteLine($"The project Id is: {viewModel.Project_Name}");
            }
        }
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}