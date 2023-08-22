namespace MVPStudio_Creative_Agency.Components.StaffPageComponents;

public partial class StaffAdminTab : ContentView
{
    public static readonly BindableProperty NameProperty =
        BindableProperty.Create(nameof(Name), typeof(string), typeof(StaffAdminTab), default(string));

    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(StaffAdminTab), default(string));

    public static readonly BindableProperty ImageProperty =
        BindableProperty.Create(nameof(Image), typeof(string), typeof(StaffAdminTab), default(string));

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

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string Image
    {
        get => (string)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
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