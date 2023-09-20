using MVPStudio_Creative_Agency.Components.StaffPageComponents;
using MVPStudio_Creative_Agency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPStudio_Creative_Agency.Services
{
    public interface IAuthService
    {
        Task<bool> LoginUser(Admin admin);
    }
}
