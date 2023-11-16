using MVPStudio_Creative_Agency.ViewModels;
using System.Diagnostics;

namespace MVPStudio_Creative_Agency.Components;

public partial class DashboardCard : ContentView
{
    private ClientViewModel _clientViewModel;

    public static readonly BindableProperty CardTitleProperty =
    BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(DashboardCard), default(string));

    public static readonly BindableProperty ImgUrlProperty =
    BindableProperty.Create(nameof(ImgUrl), typeof(string), typeof(DashboardCard), default(string));

    public static readonly BindableProperty DataTypeProperty =
    BindableProperty.Create(nameof(DataType), typeof(string), typeof(DashboardCard), default(string));

    public string CardTitle
    {
        get => (string)GetValue(CardTitleProperty);
        set => SetValue(CardTitleProperty, value);
    }

    public string ImgUrl
    {
        get => (string)GetValue(ImgUrlProperty);
        set => SetValue(ImgUrlProperty, value);
    }
    public string DataType
    {
        get => (string)GetValue(DataTypeProperty);
        set => SetValue(DataTypeProperty, value);
    }


    public DashboardCard()
    {
        InitializeComponent();
        _clientViewModel = new ClientViewModel(new Services.ClientService()); // init our service
        BindingContext = _clientViewModel; //context of xaml is the view model
        var clients = _clientViewModel.FetchClients();
        Debug.WriteLine("THESE ARE THE CLIENTS SAHN: ", clients);
    }

}