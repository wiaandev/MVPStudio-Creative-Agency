namespace MVPStudio_Creative_Agency.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void login(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("/DashboardPage");
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (Shell.Current != null)
        {
            // Hide the flyout when on the LoginPage
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        if (Shell.Current != null)
        {
            // Restore the default flyout behavior when leaving the LoginPage
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
        }
    }

}
