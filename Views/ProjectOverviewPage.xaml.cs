using MVPStudio_Creative_Agency.ViewModels;
using System.Diagnostics;

namespace MVPStudio_Creative_Agency.Views;

public partial class ProjectOverviewPage : ContentPage
{

    private ProjectViewModel _projectViewModel;

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


    public ProjectOverviewPage()
    {
        InitializeComponent();
        _projectViewModel = new ProjectViewModel(new Services.ProjectService(), new Services.TeamService());
        BindingContext = _projectViewModel;

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

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
}