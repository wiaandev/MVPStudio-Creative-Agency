using MVPStudio_Creative_Agency.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace MVPStudio_Creative_Agency.Components;

public partial class DashboardCardStaff : ContentView
{
	private StaffViewModel _staffViewModel;
    public static readonly BindableProperty CardTitleProperty =
    BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(DashboardCard), default(string));

    public static readonly BindableProperty ProfileImgProperty =
    BindableProperty.Create(nameof(ProfileImg), typeof(string), typeof(DashboardCard), default(string));

    public string CardTitle
    {
        get => (string)GetValue(CardTitleProperty);
        set => SetValue(CardTitleProperty, value);
    }

    public string ProfileImg
    {
        get => (string)GetValue(ProfileImgProperty);
        set => SetValue(ProfileImgProperty, value);
    }

    public DashboardCardStaff()
	{

		InitializeComponent();
        _staffViewModel = new StaffViewModel(new Services.StaffRestService(), new Services.StaffRolesServices()); // init our service
        BindingContext = _staffViewModel; //context of xaml is the view model
        var staff = _staffViewModel.LoadAllStaffAsync();
        Debug.WriteLine("HERE ARE THE STAFF SAHN: ", staff);
    }
}