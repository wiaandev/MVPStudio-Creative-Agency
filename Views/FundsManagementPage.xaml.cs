using Microsoft.Maui.Controls;
using CommunityToolkit.Maui.Views;
using MVPStudio_Creative_Agency.Components;
using MVPStudio_Creative_Agency.Models;
using MVPStudio_Creative_Agency.ViewModels;
using System.Diagnostics;
using Microcharts;
using SkiaSharp;

namespace MVPStudio_Creative_Agency.Views;

public partial class FundsManagementPage : ContentPage
{
    private ProjectViewModel _projectViewModel;
    private StaffViewModel _staffViewModel;
    private FundsManagementViewModel _fundsManagementViewModel;
    private ChartEntry[] entries;

    public FundsManagementPage()
    {
        InitializeComponent();

        _fundsManagementViewModel = new FundsManagementViewModel
        {
            ProjectViewModel = new ProjectViewModel(new Services.ProjectService()),
            StaffViewModel = new StaffViewModel(new Services.StaffRestService(), new Services.StaffRolesServices())
        };
        BindingContext = _fundsManagementViewModel;


        entries = new[]
        {
            new ChartEntry(0)
            {
                Label = "Revenue",
                ValueLabel = "0",
                Color = SKColor.Parse("#2c3e50")
            },
            new ChartEntry(0)
            {
                Label = "Unpaid",
                ValueLabel = "0",
                Color = SKColor.Parse("#e3e3e3")
            },
            new ChartEntry(0)
            {
                Label = "Profit",
                ValueLabel = "0",
                Color = SKColor.Parse("#b455b6")
            },
        };

        chartView.Chart = new RadarChart
        {
            Entries = entries
        };
    }


    protected override async void OnAppearing()
    {
        try
        {
            Debug.WriteLine("Getting the data: ");

            await _fundsManagementViewModel.ProjectViewModel.fetchAllProjects();
            await _fundsManagementViewModel.ProjectViewModel.fetchAllClients();
            _fundsManagementViewModel.ProfitValueLabel = (_fundsManagementViewModel.ProjectViewModel.TotalProjectCost - _fundsManagementViewModel.StaffViewModel.TotalSalaryAndHourlyRate);
            _fundsManagementViewModel.StaffViewModel.TotalSalaryAndHourlyRate = await _fundsManagementViewModel.StaffViewModel.GetTotalSalaryAndHourlyRateAsync();

            _fundsManagementViewModel.ProjectViewModel.Project_Count = $"{_fundsManagementViewModel.ProjectViewModel.Projects.Count}";

            Debug.WriteLine($"Total Project Cost: {_fundsManagementViewModel.ProjectViewModel.TotalProjectCost}");
            Debug.WriteLine($"Total Salary and Hourly Rate: {_fundsManagementViewModel.StaffViewModel.TotalSalaryAndHourlyRate}");
            Debug.WriteLine($"Total Profit: {_fundsManagementViewModel.ProfitValueLabel}");

            // Update the chart entries after TotalProjectCost is updated
            entries[0] = new ChartEntry((float)_fundsManagementViewModel.ProjectViewModel.TotalProjectCost)
            {
                Label = "Revenue",
                ValueLabel = "R " + ((float)_fundsManagementViewModel.ProjectViewModel.TotalProjectCost).ToString(),
                Color = SKColor.Parse("#2c3e50")
            };

            entries[1] = new ChartEntry((float)_fundsManagementViewModel.StaffViewModel.TotalSalaryAndHourlyRate)
            {
                Label = "Unpaid",
                ValueLabel = "R " + ((float)_fundsManagementViewModel.StaffViewModel.TotalSalaryAndHourlyRate).ToString(),
                Color = SKColor.Parse("#2c3e50")
            };

            entries[2] = new ChartEntry((float)_fundsManagementViewModel.ProfitValueLabel)
            {
                Label = "Profit",
                ValueLabel = "R " + ((float)_fundsManagementViewModel.ProfitValueLabel).ToString(),
                Color = SKColor.Parse("#2c3e50")
            };
            chartView.Chart = new RadarChart { Entries = entries };


            Debug.WriteLine($"Clients are {_fundsManagementViewModel.ProjectViewModel.Clients.Count}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating chart: {ex}");
        }
    }
}