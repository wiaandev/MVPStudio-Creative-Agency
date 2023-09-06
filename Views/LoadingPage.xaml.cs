using Microsoft.Maui.Controls.Compatibility.Platform.UWP;
using MVPStudio_Creative_Agency.Services;

namespace MVPStudio_Creative_Agency.Views;

public partial class LoadingPage : ContentPage
{
    private readonly AuthService _authService;

    public LoadingPage(AuthService authService)
    {
        InitializeComponent();
        _authService = authService;
    }

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        if (await _authService.IsAuthenticatedAsync())
        {
            // user is authenticated
            // direct to main page
            await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");

        }
        else
        {
            // user is not authenticated
            // direct to login page
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

    }
}