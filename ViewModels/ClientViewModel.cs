using CommunityToolkit.Mvvm.ComponentModel;
using MVPStudio_Creative_Agency.Models;
using MVPStudio_Creative_Agency.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVPStudio_Creative_Agency.ViewModels
{
    public class ClientViewModel : BaseViewModel
    {
        public ClientService _clientService;

        // define all observed props
        public ObservableCollection<Client> Clients { get; set; }

        public Client CurrentClient { get; set; }

        // ADDING CLIENTS
        public string Name { get; set; }    

        public string Email { get; set; } 

        public string ImgUrl { get; set; } 

        public int ClientTypeId { get; set; }  

        public ICommand AddClientCommand { get; set; }  



        public ClientViewModel(ClientService clientService)
        {
            _clientService = clientService;
            Clients = new ObservableCollection<Client>();
             
            AddClientCommand = new Command(async () => await AddClient());
        }

        private async Task AddClient()
        {
            // add client 
            var newClient = new Client
            {
                Name = Name,
                Email = Email,
                ClientTypeId = ClientTypeId,
                
            };

            await _clientService.SaveClientAsync(newClient, true);
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
