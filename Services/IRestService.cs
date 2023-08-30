using Microsoft.Maui.ApplicationModel.DataTransfer;
using Microsoft.Maui.Controls.PlatformConfiguration;
using MVPStudio_Creative_Agency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace MVPStudio_Creative_Agency.Services
{
    public interface IRestService
    {
        public Task<List<StaffRoles>> GetStaffRolesAsync()
    {
        // Your implementation here.
        // This is just a placeholder return statement.
        return Task.FromResult(new List<StaffRoles>());
    }

        //Define all of our REST Methods
        Task<List<Employee>> RefreshDataAsync(); //GET all Employees 
    }
}