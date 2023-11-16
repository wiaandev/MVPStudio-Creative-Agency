using Microcharts;
using MVPStudio_Creative_Agency.ViewModels;
using SkiaSharp;
using System.Diagnostics;

namespace MVPStudio_Creative_Agency.Views
{
    public partial class DashboardPage : ContentPage
    {
        private ProjectViewModel _projectViewModel;
        private FundsManagementViewModel _fundsManagementViewModel;
        ChartEntry[] entries = new[]
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
            /*new ChartEntry(514)
            {
                Label = ".NET MAUI",
                ValueLabel = "214",
                Color = SKColor.Parse("#3498db")
            }*/
        };

        public DashboardPage()
        {
            InitializeComponent();

            chartView.Chart = new RadarChart
            {
                Entries = entries
            };
            _fundsManagementViewModel = new FundsManagementViewModel
            {
                ProjectViewModel = new ProjectViewModel(new Services.ProjectService(), new Services.TeamService()),
                StaffViewModel = new StaffViewModel(new Services.StaffRestService(), new Services.StaffRolesServices())
            };

            BindingContext = _fundsManagementViewModel;
        }

        protected override async void OnAppearing()
        {
            try
            {
                // add some code
                await _fundsManagementViewModel.ProjectViewModel.fetchAllProjects();
                await _fundsManagementViewModel.ProjectViewModel.fetchAllClients();
                _fundsManagementViewModel.ProfitValueLabel = (_fundsManagementViewModel.ProjectViewModel.TotalProjectCost - _fundsManagementViewModel.StaffViewModel.TotalSalaryAndHourlyRate);
                _fundsManagementViewModel.StaffViewModel.TotalSalaryAndHourlyRate = await _fundsManagementViewModel.StaffViewModel.GetTotalSalaryAndHourlyRateAsync();

                Debug.WriteLine($"Projects sahn are {_fundsManagementViewModel.ProjectViewModel.Projects[0]}");

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
                    Color = SKColor.Parse("#2c3e50"),
                };

                entries[2] = new ChartEntry((float)_fundsManagementViewModel.ProfitValueLabel)
                {
                    Label = "Profit",
                    ValueLabel = "R " + ((float)_fundsManagementViewModel.ProfitValueLabel).ToString(),
                    Color = SKColor.Parse("#2c3e50")
                };
                chartView.Chart = new RadarChart { Entries = entries };

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error updating chart: {ex}");
            }
        }

        private void NavigateToProjects(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("ProjectsManagementPage");
        }
    }
}
