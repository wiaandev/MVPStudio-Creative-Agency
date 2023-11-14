using MVPStudio_Creative_Agency.ViewModels;

namespace MVPStudio_Creative_Agency.Components;

public partial class ProjectsCard : ContentView
{
	private ProjectViewModel _projectViewModel;

    public static readonly BindableProperty ClientProfileImgProperty =
   BindableProperty.Create(nameof(ClientProfileImg), typeof(string), typeof(ProjectsCard), default(string));

    public static readonly BindableProperty ClienNameProperty =
    BindableProperty.Create(nameof(ClienName), typeof(string), typeof(ProjectsCard), default(string));

    public static readonly BindableProperty Project_NameProperty =
    BindableProperty.Create(nameof(ClienName), typeof(string), typeof(ProjectsCard), default(string));

    public string ClientProfileImg
    {
        get => (string)GetValue(ClientProfileImgProperty);
        set => SetValue(ClientProfileImgProperty, value);
    }

    public string ClienName
    {
        get => (string)GetValue(ClienNameProperty);
        set => SetValue(ClienNameProperty, value);
    }

    public string Project_Name
    {
        get => (string)GetValue(Project_NameProperty);
        set => SetValue(Project_NameProperty, value);
    }
    public ProjectsCard()
	{
		InitializeComponent();
	}
}
