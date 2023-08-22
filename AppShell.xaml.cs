namespace MVPStudio_Creative_Agency;
using MVPStudio_Creative_Agency.Views;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
    }

}

