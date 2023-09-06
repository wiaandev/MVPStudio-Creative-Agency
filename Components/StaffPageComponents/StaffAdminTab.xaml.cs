using MVPStudio_Creative_Agency.ViewModels;
using System.Data;
using MVPStudio_Creative_Agency.Views.Modals;
using MVPStudio_Creative_Agency.Services;
using System.Diagnostics;
using System.Windows.Input;

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
        BindableProperty.Create(nameof(Id), typeof(string), typeof(StaffAdminTab), default(string));
    
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

    public string Id
    {
        get => (string)GetValue(IDProperty);
        set
        {
            SetValue(IDProperty, value);
            OnPropertyChanged(nameof(Id)); // Notify that there was a change on this property
        }
    }

    void OnButtonClicked(object sender, EventArgs e)
    {
        var image = sender as Image;
        if (image != null)
        {
            var id = image.ClassId;
            Debug.WriteLine("Select button pressed");
            Debug.WriteLine(id);

            if (!string.IsNullOrEmpty(id))
            {
                ViewModel.ChangeSelectedStaff(id);
            }
            else
            {
                Debug.WriteLine("ID is not set");
            }
        }
    }


    private StaffRestService _staffRestService;
    private StaffRolesServices _staffRolesServices;
    private StaffViewModel _staffViewModel;
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
}