using CommunityToolkit.Maui.Views;
using MVPStudio_Creative_Agency.Components;
using MVPStudio_Creative_Agency.Models;
using MVPStudio_Creative_Agency.ViewModels;
using System.Collections.ObjectModel;
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

        clientPicker.SelectedIndexChanged += (sender, args) =>
        {
            if (clientPicker.SelectedIndex >= 0)
            {
                _projectViewModel.SelectedClient = (Client)clientPicker.SelectedItem;
                Debug.WriteLine($"Selected client is: {_projectViewModel.SelectedClient.Name}");
            }
        };

    }

    private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        // You can access your ViewModel here if needed
        var viewModel = (ProjectViewModel)BindingContext;

        // Get the selected date (already of type DateOnly)
        DateOnly selectedDate = DateOnly.FromDateTime(e.NewDate);

        viewModel.SelectedDate = selectedDate;

        // Print the selected date to the debug output
        Debug.WriteLine($"Selected date: {viewModel.SelectedDate}");
    }



    protected override async void OnAppearing()
    {
        Debug.WriteLine("Getting the data: ");
        base.OnAppearing();
        await _projectViewModel.fetchAllProjects();
        await _projectViewModel.fetchAllClients();
        _projectViewModel.Project_Count = $"{_projectViewModel.Projects.Count}";
        // Project_Count = $"{_projectViewModel.Projects.Count}";
        Debug.WriteLine($"Clients are {_projectViewModel.Clients.Count}");
    }
}