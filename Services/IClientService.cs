using MVPStudio_Creative_Agency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPStudio_Creative_Agency.Services
{
    public interface IClientService
    {
        Task<List<Client>> RefreshDataAsync();

        Task SaveClientAsync(Client client, bool isNewClient = true); // post
    }
}
