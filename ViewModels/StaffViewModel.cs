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
    public class StaffViewModel : BaseViewModel
    {
        public StaffRestService _restService;

        //define all my observed properties
        public ObservableCollection<Employee> EmployeeList { get; set; }

        public StaffViewModel(StaffRestService restService) //passing the instance of rest service in constuctor
        {
            _restService = restService;

            EmployeeList = new ObservableCollection<Employee>();
        }

        public async Task LoadAllStaffAsync()
        {
            var items = await _restService.RefreshDataAsync();
            EmployeeList.Clear();
            foreach (var item in items)
            {
                EmployeeList.Add(item);
                Debug.WriteLine(item.Name);
                Debug.WriteLine(item.RoleId);
                Debug.WriteLine(item.Id);
                Debug.WriteLine(item.Surname);
                Debug.WriteLine(item.Gender);
                Debug.WriteLine(item.Birth_Date);
                Debug.WriteLine(item.Curr_Hours);
                Debug.WriteLine(item.ProfileImg);




            }
        }
        
    }
}
