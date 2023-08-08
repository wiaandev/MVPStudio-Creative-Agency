namespace MVPStudio_Creative_Agency.Components;

public partial class DashboardCard : ContentView
{

    public static readonly BindableProperty CardTitleProperty =
    BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(DashboardCard), default(string));

    public string CardTitle
    {
        get => (string)GetValue(CardTitleProperty);
        set => SetValue(CardTitleProperty, value);
    }

    public DashboardCard()
    {
        InitializeComponent();
        BindingContext = this;
    }

}