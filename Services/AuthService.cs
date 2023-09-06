using MVPStudio_Creative_Agency.Components.StaffPageComponents;
using MVPStudio_Creative_Agency.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.System;

namespace MVPStudio_Creative_Agency.Services
{
    public class AuthService
    {

        // local auth key
        private const string AuthStateKey = "AuthState";

        //Our httpClient
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        //Base Api Url
        internal string baseUrl = "https://localhost:7193/api/";

        public AuthService() {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

        }

        // check if authenticated 
        public async Task<bool> IsAuthenticatedAsync()
        {
            await Task.Delay(2000);

            var authState = Preferences.Default.Get<bool>(AuthStateKey, false);

            return authState;   
        }

        // set auth to true
        public async Task<bool> LoginUser(Admin admin)
        {
            Uri uri = new(string.Format($"{baseUrl}Auth/login", string.Empty));
            try
            {
                string json = JsonSerializer.Serialize<Admin>(admin, _serializerOptions);
                StringContent content = new (json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await _client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Preferences.Default.Set<bool>(AuthStateKey, true);
                    Debug.WriteLine(@"\auth"); 
                    return true;
                }
                return false; 
                

            }
            catch(Exception ex)
            {
                Debug.WriteLine(@"\ERROR", ex.Message);
                return false;
            }
        }

        // logout
        public void LogOutUser()
        {
            Preferences.Default.Remove(AuthStateKey); // auth state is false
        }
    }


}
