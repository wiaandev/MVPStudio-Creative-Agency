namespace MVPStudio_Creative_Agency.Components;

public partial class FundCard : ContentView
{
    public static readonly BindableProperty FundAmountProperty =
        BindableProperty.Create(nameof(FundAmount), typeof(string), typeof(FundCard), default(string));

    public static readonly BindableProperty FundTypeProperty =
        BindableProperty.Create(nameof(FundType), typeof(string), typeof(FundCard), default(string));

    public static readonly BindableProperty CardColorProperty =
    BindableProperty.Create(nameof(CardColor), typeof(string), typeof(FundCard), default(string));

    public string FundAmount
    {
        get => (string)GetValue(FundAmountProperty);
        set => SetValue(FundAmountProperty, value);
    }

    public string FundType
    {
        get => (string)GetValue(FundTypeProperty);
        set => SetValue(FundTypeProperty, value);
    }

    public string CardColor
    {
        get => (string)GetValue(CardColorProperty);
        set => SetValue(CardColorProperty, value);
    }

    public FundCard()
    {
        InitializeComponent();
        BindingContext = this;
    }
}
