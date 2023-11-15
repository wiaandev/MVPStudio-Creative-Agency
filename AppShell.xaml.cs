namespace MVPStudio_Creative_Agency;
using MVPStudio_Creative_Agency.Views;

public partial class AppShell : Shell
{

    async protected override void OnAppearing()
    {
        base.OnAppearing();

        await Task.Delay(3000);

        var color = Color.FromArgb("#FAFAFA");

        FlyoutBackgroundColor = color;
        FlyoutBackground = Color.FromArgb("#FAFAFA");
    }

    public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
        Routing.RegisterRoute("EditClientPopUp", typeof(EditClientPopUp));
        Routing.RegisterRoute("ProjectsManagementPage", typeof(ProjectsManagementPage));
        BindingContext = this;
    }


}

