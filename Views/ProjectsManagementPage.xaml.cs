using CommunityToolkit.Maui.Views;
using MVPStudio_Creative_Agency.Components;
using MVPStudio_Creative_Agency.Models;
using MVPStudio_Creative_Agency.ViewModels;
using System.Diagnostics;

namespace MVPStudio_Creative_Agency.Views;

public partial class ProjectsManagementPage : ContentPage
{
    private ProjectViewModel _projectViewModel;
    public string projectCount = "";

    public ProjectsManagementPage()
    {
        InitializeComponent();
        _projectViewModel = new ProjectViewModel(new Services.ProjectService());
        BindingContext = _projectViewModel;
    }

    protected override async void OnAppearing()
    {
        Debug.WriteLine("Getting the data: ");
        base.OnAppearing();
        await _projectViewModel.fetchAllProjects();
        _projectViewModel.Project_Count = $"{_projectViewModel.Projects.Count}";
        // Project_Count = $"{_projectViewModel.Projects.Count}";
        Debug.WriteLine($"PRoject count is {_projectViewModel.Project_Count}");
    }

    private void AddProject(object sender, EventArgs e)
    {
        this.ShowPopup(new AddProjectModal());
    }
}
