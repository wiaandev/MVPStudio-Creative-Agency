using System.Text.RegularExpressions;

namespace MVPStudio_Creative_Agency.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void Login(object sender, EventArgs e)
    {
        var email = emailEntry.Text;
        
        var emailPattern = "^(?(\")(\".+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$";

        if (Regex.IsMatch(email, emailPattern))
        {
            
            await Shell.Current.GoToAsync("/DashboardPage");
        }
        else
        {
            
            ErrorLabel.Text = "Invalid email";
        }
       
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
