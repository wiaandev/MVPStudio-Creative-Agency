using Microsoft.Maui.Controls;
using CommunityToolkit.Maui.Views;
using MVPStudio_Creative_Agency.Components;
using MVPStudio_Creative_Agency.Models;
using MVPStudio_Creative_Agency.ViewModels;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MVPStudio_Creative_Agency.Views;

public partial class FundsManagementPage : ContentPage
{
    public ObservableCollection<FundCard> FundCards { get; set; }

    public FundsManagementPage()
    {
        InitializeComponent();
        _projectViewModel = new ProjectViewModel(new Services.ProjectService());
        BindingContext = _projectViewModel;
        
       /* BindingContext = this;*/
    }


    private ProjectViewModel _projectViewModel;
    public string projectCount = "";
    public double totalProjectCost { get; set; } = 0;

    protected override async void OnAppearing()
    {
        Debug.WriteLine("Getting the data: ");
        base.OnAppearing();
        await _projectViewModel.fetchAllProjects();
        await _projectViewModel.fetchAllClients();
        _projectViewModel.Project_Count = $"{_projectViewModel.Projects.Count}";
        
        foreach (var project in _projectViewModel.Projects)
        {
            totalProjectCost += (double)project.Project_Cost;
        }
        
        Debug.WriteLine($"Total Project Cost: {totalProjectCost}");

        // Project_Count = $"{_projectViewModel.Projects.Count}";
        Debug.WriteLine($"Clients are {_projectViewModel.Clients.Count}");
    }
}

public class FundCard
{
    public string Name { get; internal set; }
    public string Image { get; internal set; }
    public string Bundle { get; internal set; }
    public string Description { get; internal set; }
    public string Team { get; internal set; }
    public string Timeline { get; internal set; }
    public string Cost { get; internal set; }
    public string Paid { get; internal set; }
    public string Progress { get; internal set; }
}