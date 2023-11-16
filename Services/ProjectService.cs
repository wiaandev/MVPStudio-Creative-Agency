using MVPStudio_Creative_Agency.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MVPStudio_Creative_Agency.Services
{
    class ProjectService : IProjectService
    {
        //Our httpClient
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        //Base Api Url
        internal string baseUrl = "https://localhost:7193/api/";

        //List of Items
        public List<Client> Clients { get; private set; }
        public List<Project> Projects { get; private set; }

        public Project SingleProject { get; private set; }

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

        public async Task<Project> AddNewProject(Project project)
        {
            try
            {
                Uri uri = new Uri($"{baseUrl}Projects");
                var body = JsonSerializer.Serialize(project, _serializerOptions);
                StringContent stringContent = new StringContent(body, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _client.PostAsync(uri, stringContent);

                if (!response.IsSuccessStatusCode)
                {
                    // Consider logging the error details for production
                    string errorContent = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"HTTP request failed with status code {response.StatusCode}. Error content: {errorContent}");

                    throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
                }

                string content = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"From AddProjectService: {content}");
                SingleProject = JsonSerializer.Deserialize<Project>(content, _serializerOptions);

                return SingleProject; // Consider if this is needed
            }
            catch (HttpRequestException ex)
            {
                // Log the exception and handle it as needed
                Debug.WriteLine($"\tERROR: {ex.Message}");
                throw; // Rethrow the exception
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., network issues, JSON parsing errors)
                Debug.WriteLine($"\tERROR: {ex.Message}");
                throw; // Rethrow the exception or handle it according to your requirements
            }
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            Uri uri = new Uri($"{baseUrl}Projects/{id}");
            try
            {
                HttpResponseMessage res = await _client.DeleteAsync(uri);
                if (res.IsSuccessStatusCode)
                {
                    string responseContent = await res.Content.ReadAsStringAsync();
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return true;
        }

        public async Task UpdateProjectTeam(int projectId, int newTeamId)
        {
            Uri uri = new Uri(string.Format(baseUrl + "Projects/ChangeProjectTeam"));

            var data = new { projectId, newTeamId };
            var json = JsonSerializer.Serialize(data, _serializerOptions);

            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await _client.PutAsync(uri, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    Debug.WriteLine("Something went wrong!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public async Task UpdateProjectProgress(int projectId, int newProgressAmount)
        {
            Uri uri = new Uri(string.Format(baseUrl + "Projects/UpdateProjectProgress"));

            var data = new { projectId, newProgressAmount };
            var json = JsonSerializer.Serialize(data, _serializerOptions);

            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await _client.PutAsync(uri, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    Debug.WriteLine("Something went wrong!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}