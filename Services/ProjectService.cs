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
        public List<Client> Clients { get; private set; }
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
            Debug.WriteLine(Projects);
            return Projects;
        }

        public async Task<Project> GetSingleProject(int id)
        {
            Project project = null;

            try
            {
                Uri uri = new Uri(baseUrl + $"Projects/{id}");
                HttpResponseMessage response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"From Individual Task: {content}");
                    project = JsonSerializer.Deserialize<Project>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR: {ex.Message}");
            }

            return project;
        }

        public async Task<List<Client>> RefreshDataAsync()
        {
            Clients = new List<Client>();

            Uri uri = new(string.Format(baseUrl + "Clients", string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Clients = JsonSerializer.Deserialize<List<Client>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Clients;
        }

        public async Task<List<Project>> AddNewProject(Project project)
        {

            Uri uri = new(string.Format(baseUrl + "/Project"));
            try
            {
                var body = JsonSerializer.Serialize(project, _serializerOptions);
                StringContent stringContent = new(body, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _client.PostAsync(uri, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"From Recipe Service: {content}");
                    Projects = JsonSerializer.Deserialize<List<Project>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            Debug.WriteLine(Projects);
            return Projects;
        }
    }
}
