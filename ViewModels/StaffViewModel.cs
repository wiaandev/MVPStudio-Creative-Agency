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
        public StaffRolesServices _staffRolesServices;

        //define all my observed properties
        public ObservableCollection<Employee> EmployeeList { get; set; }

        public StaffViewModel(StaffRestService restService, StaffRolesServices staffRolesServices) //passing the instance of rest service in constuctor
        {
            _restService = restService;
            _staffRolesServices = staffRolesServices;

            EmployeeList = new ObservableCollection<Employee>();
        }

        public async Task LoadAllStaffAsync()
        {
            var items = await _restService.RefreshDataAsync();
            var roles = await _staffRolesServices.GetStaffRolesAsync();
            EmployeeList.Clear();
            Debug.WriteLine("roles" + roles);

            foreach (var item in items)
            {
                item.FullName = $"{item.Name} {item.Surname}";
              /*  if((roles != null && !string.IsNullOrEmpty((await GetRoleById(int.Parse(((IEnumerable<StaffRole>)roles).FirstOrDefault().*/
                var role = roles.FirstOrDefault(r => r.Id ==  item.RoleId);
                if (role != null)
                {
                    /*Hier Bou ek die object op*/
                    item.Role_Type = role.Role_Type;
                    item.Hourly_Rate = role.Hourly_Rate;
                    item.Salary = role.Salary;
                    Debug.WriteLine("the role " + role.Role_Type);

                    
                }

                if (item.Salary != 0){
                    item.Payment = "R " + item.Salary + "  p/m";
                }
                else{
                    item.Payment = "R " + item.Hourly_Rate + "  h/r";
                }

                EmployeeList.Add(item);
                Debug.WriteLine(item.Name);
                Debug.WriteLine(item.FullName);

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
