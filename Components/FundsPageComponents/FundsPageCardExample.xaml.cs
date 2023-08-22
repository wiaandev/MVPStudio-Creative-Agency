namespace MVPStudio_Creative_Agency.Components.FundsPageComponents;

public partial class FundsPageCardExample : ContentView
{

    public static readonly BindableProperty NameProperty =
        BindableProperty.Create(nameof(Name), typeof(string), typeof(FundsPageCardExample), default(string));

    public static readonly BindableProperty ImageProperty =
        BindableProperty.Create(nameof(Image), typeof(string), typeof(FundsPageCardExample), default(string));

    public static readonly BindableProperty BundleProperty =
        BindableProperty.Create(nameof(Bundle), typeof(string), typeof(FundsPageCardExample), default(string));

    public static readonly BindableProperty DescriptionProperty =
        BindableProperty.Create(nameof(Description), typeof(string), typeof(FundsPageCardExample), default(string));

    public static readonly BindableProperty TeamProperty =
        BindableProperty.Create(nameof(Team), typeof(string), typeof(FundsPageCardExample), default(string));

    public static readonly BindableProperty TimelineProperty =
        BindableProperty.Create(nameof(Timeline), typeof(string), typeof(FundsPageCardExample), default(string));

    public static readonly BindableProperty CostProperty =
        BindableProperty.Create(nameof(Cost), typeof(string), typeof(FundsPageCardExample), default(string));

    public static readonly BindableProperty PaidProperty =
        BindableProperty.Create(nameof(Paid), typeof(string), typeof(FundsPageCardExample), default(string));

    public static readonly BindableProperty ProgressProperty =
        BindableProperty.Create(nameof(Progress), typeof(string), typeof(FundsPageCardExample), default(string));

    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }

    public string Image
    {
        get => (string)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }

    public string Bundle
    {
        get => (string)GetValue(BundleProperty);
        set => SetValue(BundleProperty, value);
    }

    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public string Team
    {
        get => (string)GetValue(TeamProperty);
        set => SetValue(TeamProperty, value);
    }
    public string Timeline
    {
        get => (string)GetValue(TimelineProperty);
        set => SetValue(TimelineProperty, value);
    }
    public string Cost
    {
        get => (string)GetValue(CostProperty);
        set => SetValue(CostProperty, value);
    }
    public string Paid
    {
        get => (string)GetValue(PaidProperty);
        set => SetValue(PaidProperty, value);
    }
    public string Progress
    {
        get => (string)GetValue(ProgressProperty);
        set => SetValue(ProgressProperty, value);
    }
    public FundsPageCardExample()
	{
		InitializeComponent();
	}
}
