using Microsoft.Maui.ApplicationModel.Communication;
using MVPStudio_Creative_Agency;
using MVPStudio_Creative_Agency.Models;
using MVPStudio_Creative_Agency.Services;
using MVPStudio_Creative_Agency.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

        public string UserName { get; set; }

        public LoginViewModel(AuthService authService) {
            _authService = authService;
            LoginCommand = new Command(async () => await AttemptUserLogin());

            
        }

        public async Task AttemptUserLogin()
        {

            

            
            ErrorMessage = "";

            
            var loginUser = new Admin
            { 
                Email = Email,
                Password = Password,
            };

            var authSuccess = await _authService.LoginUser(loginUser);

            if (authSuccess)
            {
                await Shell.Current.GoToAsync(nameof(DashboardPage));

                // setting the prefences 
                Preferences.Set(nameof(UserName), string.Empty);
                Debug.WriteLine(UserName);
            }
            
            else
            {
                ErrorMessage = "The username or password you entered is incorrect, try again";
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

/*if (email == email)
{
    if (staff type == "admin") {
        then password*/

/*1.Check does the email exist
2. Check if the user is admin
3. Then only check if password is correct*/