namespace MVPStudio_Creative_Agency.Components;

public partial class ClientCard : ContentView
{
    public static readonly BindableProperty NameProperty =
    BindableProperty.Create(nameof(Name), typeof(string), typeof(ClientCard), default(string));

    public static readonly BindableProperty EmailProperty =
    BindableProperty.Create(nameof(Email), typeof(string), typeof(ClientCard), default(string));

    public static readonly BindableProperty ImageProperty =
    BindableProperty.Create(nameof(ImgUrl), typeof(string), typeof(ClientCard), default(string));

    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }

    public string Email
    {
        get => (string)GetValue(EmailProperty);
        set => SetValue(EmailProperty, value);
    }
    public string ImgUrl
    {
        get => (string)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }

    public ClientCard()
	{
		InitializeComponent();
	}
}