using Microsoft.VisualBasic;
using MVPStudio_Creative_Agency.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace MVPStudio_Creative_Agency.Services
{
    public class StaffRolesServices : IRestService
    {
        //Our httpClient
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        //Base Api Url
        internal string baseUrl = "https://localhost:7193/api/";

        //List of Items
        public List<StaffRoles> Items { get; private set; }

        //Constructor - Creating our httpClient
        public StaffRolesServices()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<StaffRoles>> GetStaffRolesAsync()
        {
            Items = new List<StaffRoles>();
                Debug.WriteLine("Getting roles");
            

            Uri uri = new(string.Format(baseUrl + "Roles", string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonSerializer.Deserialize<List<StaffRoles>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            Debug.WriteLine(Items[0]);

            return Items;
        }

        public Task<List<Employee>> RefreshDataAsync()
        {
            throw new NotImplementedException();
        }
    }
}
