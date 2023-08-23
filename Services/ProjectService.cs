using MVPStudio_Creative_Agency.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVPStudio_Creative_Agency.Services
{
    class ProjectService: IProjectService
    {
        //Our httpClient
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        //Base Api Url
        internal string baseUrl = "https://localhost:7193/api/";

        //List of Items
        public List<Project> Projects { get; private set; }

        //Constructor - Creating our httpClient
        public ProjectService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
        public async Task<List<Project>> GetAllProjects()
        {
            Projects = new List<Project>();

            Uri uri = new(string.Format(baseUrl + "Employees", string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Projects = JsonSerializer.Deserialize<List<Project>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Projects;
        }
    }
}
