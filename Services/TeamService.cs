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
    public class TeamService: ITeamService
    {
        //Our httpClient
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        //Base Api Url
        internal string baseUrl = "https://localhost:7193/api/";

        public List<Team> Teams { get; private set; }

        //Constructor - Creating our httpClient
        public TeamService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<Team>> GetTeamsAsync()
        {
            Teams = new List<Team>();

            Uri uri = new(string.Format(baseUrl + "Teams"));
            try
            {
                Debug.WriteLine(Teams);
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"From Teams Service: {content}");
                    Teams = JsonSerializer.Deserialize<List<Team>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            Debug.WriteLine(Teams);
            return Teams;
        }

    }
}
