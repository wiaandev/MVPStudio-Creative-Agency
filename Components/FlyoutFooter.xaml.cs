using MVPStudio_Creative_Agency.Services;
using MVPStudio_Creative_Agency.Views;

namespace MVPStudio_Creative_Agency.Components;

public partial class FlyoutFooter : ContentView
{
	public FlyoutFooter()
	{
		InitializeComponent();
	}

    private async void Logout(object sender, EventArgs e)
    {
        new AuthService().LogOutUser();
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
}
