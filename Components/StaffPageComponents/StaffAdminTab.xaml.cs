using System.Data;

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

    public StaffAdminTab()
	{
		InitializeComponent();
	}
}