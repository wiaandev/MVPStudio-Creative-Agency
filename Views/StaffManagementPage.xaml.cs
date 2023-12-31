using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using MVPStudio_Creative_Agency.ViewModels;
using MVPStudio_Creative_Agency.Views.Modals;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Views;
using MVPStudio_Creative_Agency.Services;

namespace MVPStudio_Creative_Agency.Views;

public partial class StaffManagementPage : ContentPage
{
    public ObservableCollection<Card> Cards { get; set; }
    public ObservableCollection<ProjectCard> ProjectCards { get; set; }

    private StaffViewModel _staffViewModel;

    public StaffManagementPage()
    {
        InitializeComponent();
        _staffViewModel = new StaffViewModel(new Services.StaffRestService(), new Services.StaffRolesServices()); //init our service
        BindingContext = _staffViewModel; //the context of the xaml is this viewModel

    }




    //on appear
    protected override async void OnAppearing()
    {
        Debug.WriteLine("Getting data");
        base.OnAppearing();
        await _staffViewModel.LoadAllStaffAsync();
        Debug.WriteLine(_staffViewModel.EmployeeList);
    }

    //popup
    private void OpenModalButton_Clicked(object sender, EventArgs e)
    {
        var modalPage = new AddStaffModal(this); // Create an instance of your modal page

        this.ShowPopup(modalPage); // Show the modal as a popup
    }

    public void DisplayPopup()
    {
        var popup = new AddStaffModal(this);

        this.ShowPopup(popup);
    }

    private void OpenStaffModalButton_Clicked(object sender, EventArgs e)
    {
        var staffManagementPage = this; // Assuming 'this' is your StaffManagementPage instance.
        var staffViewModalPage = new StaffViewModal();
        this.ShowPopup(staffViewModalPage);
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