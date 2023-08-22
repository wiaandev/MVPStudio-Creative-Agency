using MVPStudio_Creative_Agency.Models;
using MVPStudio_Creative_Agency.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPStudio_Creative_Agency.ViewModels
{
    public class StaffViewModel : BaseViewModel
    {
        public StaffRestService _restService;

        //define all my observed properties
        public List<Employee> EmployeeList;

        public StaffViewModel(StaffRestService restService) //passing the instance of rest service in constuctor
        {
            _restService = restService;

            EmployeeList = new List<Employee>();
        }

        public async Task fetchAllStaff()
        {
            var items = await _restService.RefreshDataAsync();
            EmployeeList.Clear();
            foreach (var item in items)
            {
                EmployeeList.Add(item);
                Debug.WriteLine(item.Name);
            }
        }
        
    }
}
