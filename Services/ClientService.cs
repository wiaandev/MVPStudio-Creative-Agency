using Microsoft.VisualBasic;
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
    public class ClientService: IClientService
    {
        //Our httpClient
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        //Base Api Url
        internal string baseUrl = "https://localhost:7193/api/";

        //List of Items
        public List<Client> Items { get; private set; }

        //Constructor - Creating our httpClient
        public ClientService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task SaveClientAsync(Client item, bool isNewItem = false)
        {
            Uri uri = new(string.Format($"{baseUrl}Clients", string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<Client>(item, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                    response = await _client.PostAsync(uri, content);
                else
                    response = await _client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task<List<Client>> RefreshDataAsync()
        {
            Items = new List<Client>();

            Uri uri = new (string.Format($"{baseUrl}Clients", string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonSerializer.Deserialize<List<Client>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }

    }
}
