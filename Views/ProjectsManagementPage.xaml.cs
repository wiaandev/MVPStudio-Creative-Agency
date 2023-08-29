using MVPStudio_Creative_Agency.ViewModels;
using System.Diagnostics;

namespace MVPStudio_Creative_Agency.Views;

public partial class ProjectsManagementPage : ContentPage
{
	private ProjectViewModel _projectViewModel;
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
        Debug.WriteLine(_projectViewModel);
    }
}
