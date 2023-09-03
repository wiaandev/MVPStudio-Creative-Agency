namespace MVPStudio_Creative_Agency.Components;

public partial class SingleProjectCard : ContentView
{
	public static readonly BindableProperty ClienNameProperty = 
	BindableProperty.Create(nameof(ClienName), typeof(string), typeof(SingleProjectCard), default(string));

    public static readonly BindableProperty Project_NameProperty =
    BindableProperty.Create(nameof(Project_Name), typeof(string), typeof(SingleProjectCard), default(string));

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


    public SingleProjectCard()
	{
		InitializeComponent();
	}
}
