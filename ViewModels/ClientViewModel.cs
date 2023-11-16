using CommunityToolkit.Mvvm.ComponentModel;
using MVPStudio_Creative_Agency.Models;
using MVPStudio_Creative_Agency.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Numerics;
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

     
        public Client Upd_ClientDetails { get; set; }

        // ADDING CLIENTS
        public string Name { get; set; }    

        public string Email { get; set; } 

        public string ImgUrl { get; set; } 

        public int ClientTypeId { get; set; }  

        public ICommand AddClientCommand { get; set; }

        public ICommand EditClientCommand { get; }

        public string ErrorMessage { get; set; } = string.Empty;

        private Client _selectedUser;

        public Client SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged();
            }

        }

        public ClientViewModel(ClientService clientService)
        {
            _clientService = clientService;
            Clients = new ObservableCollection<Client>();
            AddClientCommand = new Command(async () => await AddClient());
            EditClientCommand = new Command(async () => await updateClient());
        }

        private async Task AddClient()
        {
            if (Name == string.Empty || Email == string.Empty || ImgUrl == string.Empty )       {
                ErrorMessage = "All fields are required";
            }
            else
            {
                var newClient = new Client
                {
                    Name = Name,
                    Email = Email,
                    ImgUrl = ImgUrl,    
                    ClientTypeId = ClientTypeId,    
                    
                };

                await _clientService.SaveClientAsync(newClient, true);
                
            }
            OnPropertyChanged(nameof(ErrorMessage));
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

        public async Task updateFormValues(Client clientData)
        {


            //save client details for update
            Upd_ClientDetails = clientData;
            Name = clientData.Name;
            Email = clientData.Email;
            

            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(_selectedUser));
        }

        public async Task updateClient()
        {
            var newClient = new Client
            {
                Id = Upd_ClientDetails.Id,
                Name = Upd_ClientDetails.Name,
                Email = Upd_ClientDetails.Email,
                ImgUrl = Upd_ClientDetails.ImgUrl,
                
            };

            await _clientService.UpdateClientAsync(newClient, false);
            
        }
    }
}
