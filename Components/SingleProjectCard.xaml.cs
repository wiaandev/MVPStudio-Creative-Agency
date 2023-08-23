namespace MVPStudio_Creative_Agency.Components;

public partial class SingleProjectCard : ContentView
{
	public static readonly BindableProperty ProjectCardProperty = 
		BindableProperty.Create(nameof(ProjectClient), typeof(string), typeof(SingleProjectCard), default(string));

    public static readonly BindableProperty ProjectTypeProperty =
    BindableProperty.Create(nameof(ProjectType), typeof(string), typeof(SingleProjectCard), default(string));

    public static readonly BindableProperty DescriptionProperty =
BindableProperty.Create(nameof(Description), typeof(string), typeof(SingleProjectCard), default(string));

    public string ProjectClient
    {
        get => (string)GetValue(ProjectCardProperty);
        set => SetValue(ProjectCardProperty, value);
    }

    public string ProjectType
    {
        get => (string)GetValue(ProjectTypeProperty);
        set => SetValue(ProjectTypeProperty, value);
    }

    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }


    public SingleProjectCard()
	{
		InitializeComponent();
	}
}
