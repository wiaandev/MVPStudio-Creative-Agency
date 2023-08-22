using Microcharts.Maui;
using System.Collections.ObjectModel;

namespace MVPStudio_Creative_Agency.Views;

public partial class ClientsManagementPage : ContentPage
{
    

    public ClientsManagementPage()
    {
        InitializeComponent();

        /*List<Client> clients = new List<Client>() {
            new Client {Name="Mark Cuban", Email = "mark@123.com" },
            new Client {Name="Peter griffin", Email = "peter@gmail.com" },
            new Client {Name="Lionel messi", Email = "leo10@maimi.com" },
            new Client {Name="larry page", Email = "larry@google.com" },
            new Client {Name="Elon musk", Email = "elon@teslamotors.com" }

        };
        listClients.ItemsSource = clients;*/
    }
    public class Client 
    { 
        public string Name { get; set; }
        public string Email { get; set;}

    }
    
}
