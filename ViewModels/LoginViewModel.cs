using MVPStudio_Creative_Agency;
using MVPStudio_Creative_Agency.Models;
using MVPStudio_Creative_Agency.Services;
using MVPStudio_Creative_Agency.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.System;

namespace MVPStudio_Creative_Agency.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public AuthService _authService;
        public string Email { get; set; }

        public string Password { get; set; }

        public ICommand LoginCommand { get; set; }

        public string ErrorMessage {get; set;} = string.Empty;

        public LoginViewModel(AuthService authService) {
            _authService = authService;
            LoginCommand = new Command(async () => await AttemptUserLogin());
        }

        private async Task AttemptUserLogin()
        {
            ErrorMessage = "";

            
            var loginUser = new Admin
            { Email = Email,
            Password = Password,
            };

            var authSuccess = await _authService.LoginUser(loginUser);

            if (authSuccess)
            {
                await Shell.Current.GoToAsync(nameof(DashboardPage));
            } else
            {
                ErrorMessage = "Invalid Email or password, please try again";
            }
            
            /*if (Password == "" | Email == "")
            {

            }*/
            OnPropertyChanged(nameof(ErrorMessage));
        }
    }
}
/*protected async override void OnNavigatedTo(NavigatedToEventArgs args)
{
    base.OnNavigatedTo(args);

    if (await _authService.IsAuthenticatedAsync())
    {
        // User is logged in
        // redirect to main page
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
    }
    else
    {
        // User is not logged in 
        // Redirect to LoginPage
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }*/