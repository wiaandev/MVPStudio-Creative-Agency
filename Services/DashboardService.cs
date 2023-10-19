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
    internal class DashboardService : IDashboardService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        //Base Api Url
        internal string baseUrl = "https://localhost:7193/api/";

        public List<Project> Projects { get; private set; }
        //TODO: list of Clients
        //TODO: list of Employees 
        //TODO: list of funds

        public DashboardService()
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

            Uri uri = new(string.Format(baseUrl + "Projects", string.Empty));
            try
            {
                Debug.WriteLine(Projects);
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"From Project Service: {content}");
                    Projects = JsonSerializer.Deserialize<List<Project>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            Debug.WriteLine($"Projects from DashVM: {Projects}");
            return Projects;
        }
    }
}