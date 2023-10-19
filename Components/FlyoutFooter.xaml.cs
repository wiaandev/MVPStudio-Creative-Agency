using MVPStudio_Creative_Agency.Services;
using MVPStudio_Creative_Agency.Views;

namespace MVPStudio_Creative_Agency.Components;

public partial class FlyoutFooter : ContentView
{

    public string Username { get; set; }
    public FlyoutFooter()
	{
		InitializeComponent();

        Username = Preferences.Get("Username", "no val");

        UsernameVal.Text = Username;

    }
    
    private async void Logout(object sender, EventArgs e)
    {
        new AuthService().LogOutUser();
        await Shell.Current.GoToAsync(nameof(LoginPage));
    }
}
