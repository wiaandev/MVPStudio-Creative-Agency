using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.Maui.Controls;
using MVPStudio_Creative_Agency.ViewModels;

namespace MVPStudio_Creative_Agency.Views;

public partial class StaffManagementPage : ContentPage
{
    public ObservableCollection<Card> Cards { get; set; }
    public ObservableCollection<ProjectCard> ProjectCards { get; set; }

    private StaffViewModel _staffViewModel;

    public StaffManagementPage()
    {
        InitializeComponent();
        _staffViewModel = new StaffViewModel(new Services.StaffRestService()); //init our service
        BindingContext = _staffViewModel; //the context of the xaml is this viewModel


        Cards = new ObservableCollection<Card>
            {
                new Card { Name = "John", Title = "Developer", Image = "profile_img.png", Projects = "4", Salary = "R13 500.00", ID = "1"},
                new Card { Name = "Jane", Title = "Developer", Image = "profile_img.png", Projects = "8", Salary = "R15 500.00", ID = "2"},
            };

        ProjectCards = new ObservableCollection<ProjectCard>
            {
                new ProjectCard { ProjectName = "Card 1", Image = "profile_img.png", Date = "2023", State = "Current" },
                new ProjectCard { ProjectName = "Card 2", Image = "profile_img.png", Date = "2021", State = "Closed" },
                new ProjectCard { ProjectName = "Card 3", Image = "profile_img.png", Date = "2022", State = "Current" },

            };

        //BindingContext = this;
    }
    //on appear
    protected override async void OnAppearing()
    {
        Debug.WriteLine("Getting data");
        base.OnAppearing();
        await _staffViewModel.LoadAllStaffAsync();
        Debug.WriteLine(_staffViewModel.EmployeeList);
    }

}

public class Card
{
    public string Name { get; internal set; }
    public string Title { get; internal set; }
    public string Image { get; internal set; }
    public string Projects { get; internal set; }
    public string Salary { get; internal set; }
    public string ID { get; internal set; }
}

public class ProjectCard
{
    public string ProjectName { get; internal set; }
    public string Image { get; internal set; }
    public string Date { get; internal set; }
    public string State { get; internal set; }

}