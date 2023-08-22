namespace MVPStudio_Creative_Agency.Components.StaffPageComponents;

public partial class AllProjectsComponent : ContentView
{
	public static readonly BindableProperty ProjectNameProperty =
        BindableProperty.Create(nameof(ProjectName), typeof(string), typeof(AllProjectsComponent), default(string));

    public static readonly BindableProperty ImageProperty =
        BindableProperty.Create(nameof(Image), typeof(string), typeof(AllProjectsComponent), default(string));

    public static readonly BindableProperty DateProperty =
        BindableProperty.Create(nameof(Date), typeof(string), typeof(AllProjectsComponent), default(string));

    public static readonly BindableProperty StateProperty =
        BindableProperty.Create(nameof(State), typeof(string), typeof(AllProjectsComponent), default(string));

    public string ProjectName
    {
        get => (string)GetValue(ProjectNameProperty);
        set => SetValue(ProjectNameProperty, value);
    }

    public string Image
    {
        get => (string)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }

    public string Date
    {
        get => (string)GetValue(DateProperty);
        set => SetValue(DateProperty, value);
    }

    public string State
    {
        get => (string)GetValue(StateProperty);
        set => SetValue(StateProperty, value);
    }


	public AllProjectsComponent()
	{
		InitializeComponent();
	}
}
