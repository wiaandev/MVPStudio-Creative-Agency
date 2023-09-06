using MVPStudio_Creative_Agency.ViewModels;
using System.Data;
using MVPStudio_Creative_Agency.Views.Modals;
using System.Diagnostics;
using MVPStudio_Creative_Agency.Services;
using MVPStudio_Creative_Agency.Views;
using CommunityToolkit.Maui.Views;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Platform;
using Mopups.Services;
using System;
using System.Globalization;
using System.Windows.Input;
using Popup = Microsoft.UI.Xaml.Controls.Primitives.Popup;
using Mopups.Pages;

namespace MVPStudio_Creative_Agency.Components.StaffPageComponents;

public partial class StaffAdminTab : ContentView
{
    public static readonly BindableProperty NameProperty =
        BindableProperty.Create(nameof(Name), typeof(string), typeof(StaffAdminTab), default(string));

    public static readonly BindableProperty Birth_DateProperty =
        BindableProperty.Create(nameof(Birth_Date), typeof(string), typeof(StaffAdminTab), default(string));

    public static readonly BindableProperty ProfileImgProperty =
        BindableProperty.Create(nameof(ProfileImg), typeof(string), typeof(StaffAdminTab), default(string));

    public static readonly BindableProperty ProjectsProperty =
        BindableProperty.Create(nameof(Projects), typeof(string), typeof(StaffAdminTab), default(string));

    public static readonly BindableProperty SalaryProperty =
        BindableProperty.Create(nameof(Salary), typeof(string), typeof(StaffAdminTab), default(string));

    public static readonly BindableProperty IDProperty =
        BindableProperty.Create(nameof(ID), typeof(string), typeof(StaffAdminTab), default(string));
    public static readonly BindableProperty ViewModelProperty =
        BindableProperty.Create(nameof(ViewModel), typeof(StaffViewModel), typeof(StaffAdminTab), default(StaffViewModel));

    public StaffViewModel ViewModel
    {
        get => (StaffViewModel)GetValue(ViewModelProperty);
        set => SetValue(ViewModelProperty, value);
    }

    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }

    public string Birth_Date
    {
        get => (string)GetValue(Birth_DateProperty);
        set => SetValue(Birth_DateProperty, value);
    }

    public string ProfileImg
    {
        get => (string)GetValue(ProfileImgProperty);
        set => SetValue(ProfileImgProperty, value);
    }

    public string Projects
    {
        get => (string)GetValue(ProjectsProperty);
        set => SetValue(ProjectsProperty, value);
    }

    public string Salary
    {
        get => (string)GetValue(SalaryProperty);
        set => SetValue(SalaryProperty, value);
    }

    public string ID
    {
        get => (string)GetValue(IDProperty);
        set => SetValue(IDProperty, value);
    }



    void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button != null)
        {
            var id = button.ClassId;
            if (!string.IsNullOrEmpty(id))
            {
                int employeeId;
                if (Int32.TryParse(id, out employeeId))
                {
                    ViewModel.DeleteEmployeeByIdAsync(employeeId);
                }
                else
                {
                    Debug.WriteLine("ID is not a valid integer");
                }
            }
            else
            {
                Debug.WriteLine("ID is not set");
            }
        }

    
    }

    //popup
    /*private void OpenStaffModalButton_Clicked(object sender, EventArgs e)
    {
        var staffAdminTab = this; // Assuming 'this' is your StaffAdminTab instance.
        var staffViewModalPage = new StaffViewModal(staffAdminTab);
        var popup = new CommunityToolkit.Maui.Views.Popup { Content = staffViewModalPage.Content };
        popup.ShowPopupAsync(<StaffViewModal>); // Show the modal as a popup
    }*/



    private StaffRestService _staffRestService;
    private StaffRolesServices _staffRolesServices;
    private StaffViewModel _staffViewModel;
    private StaffManagementPage _staffManagementPage;
    public StaffAdminTab()
    {
        InitializeComponent();
        // You'll need to provide the StaffRestService and StaffRolesServices instances here
        _staffRestService = new StaffRestService();
        _staffRolesServices = new StaffRolesServices(); // Assuming you also need to initialize this

        // Initialize the StaffViewModel
        _staffViewModel = new StaffViewModel(_staffRestService, _staffRolesServices);

        BindingContext = _staffViewModel;
    }

    void ShowCustomAlertDialog(string title, string message)
    {
        // Assuming this modal is opened from a parent page, use the parent page to display the alert

        _staffManagementPage.DisplayAlert(title, message, "OK");
    }
    
}