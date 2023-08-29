namespace MVPStudio_Creative_Agency.Components;

public partial class SingleProjectCard : ContentView
{
	public static readonly BindableProperty ClientIdProperty = 
	BindableProperty.Create(nameof(ClientId), typeof(string), typeof(SingleProjectCard), default(string));

    public static readonly BindableProperty Project_NameProperty =
    BindableProperty.Create(nameof(Project_Name), typeof(string), typeof(SingleProjectCard), default(string));

    public static readonly BindableProperty DescriptionProperty =
    BindableProperty.Create(nameof(Description), typeof(string), typeof(SingleProjectCard), default(string));

    public string ClientId
    {
        get => (string)GetValue(ClientIdProperty);
        set => SetValue(ClientIdProperty, value);
    }

    public string Project_Name
    {
        get => (string)GetValue(Project_NameProperty);
        set => SetValue(Project_NameProperty, value);
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
