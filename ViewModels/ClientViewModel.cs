using MVPStudio_Creative_Agency.Models;
using MVPStudio_Creative_Agency.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPStudio_Creative_Agency.ViewModels
{
    public class ClientViewModel : BaseViewModel
    {
        public ClientService _clientService;

        // define all observed props
        public ObservableCollection<Client> Clients { get; set; }

        public ClientViewModel(ClientService clientService)
        {
            _clientService = clientService;
            Clients = new ObservableCollection<Client>();   
        }
        
        public async Task FetchClients()
        {
            var clients = await _clientService.RefreshDataAsync();  
            Clients.Clear();    

            foreach (var client in clients) 
            { 
                Clients.Add(client);
                Debug.WriteLine(client.Name);
            }
        }
    }
}
