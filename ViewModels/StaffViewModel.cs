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
            //Filter
            ChangeAllStaffFilterCommand = new Command(ChangeToFilterAllStaff);
            ChangeDesignerFilterCommand = new Command(ChangeToFilterDesigner);
            ChangeAdminFilterCommand = new Command(ChangeToFilterAdmin);
            ChangeDeveloperFilterCommand = new Command(ChangeToFilterDeveloper);

   

        }

// filter
        private string filteringStaff = "AllStaff";
        public ICommand ChangeAllStaffFilterCommand { get; private set; }
        public ICommand ChangeDesignerFilterCommand { get; private set; }
        public ICommand ChangeAdminFilterCommand { get; private set; }
        public ICommand ChangeDeveloperFilterCommand { get; private set; }

        private string selectedStaff = "";



        public string MyFilterAction
        {
            get => filteringStaff;
            set
            {
                if (filteringStaff != value)
                {
                    filteringStaff = value;
                    OnPropertyChanged(nameof(MyFilterAction));
                }
            }
        }

        public string MySelectedAction
        {
            get => selectedStaff;
            set
            {
                if (selectedStaff != value)
                {
                    selectedStaff = value;
                    OnPropertyChanged(nameof(MySelectedAction));
                }
            }
        }


        
    

        public async Task LoadAllStaffAsync()
        {
            Debug.WriteLine("Get Staff");
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
                if (filteringStaff == "AllStaff")
                {
                    EmployeeList.Add(item);
 
                } else if (filteringStaff == item.Role_Type)
                {
                    EmployeeList.Add(item);
     
                }
                




            }
        }

        public void DeleteEmployeeByIdAsync(int id)
        {
            _restService.DeleteEmployeeAsync(id);
            Task.Delay(1000);
            LoadAllStaffAsync();
        }
        // ChangeTo to be applied to filtering buttnos
        private bool isAllStaffButtonActive = true;
        public bool IsAllStaffButtonActive
        {
            get => isAllStaffButtonActive;
            set
            {
                if (isAllStaffButtonActive != value)
                {
                    isAllStaffButtonActive = value;
                    OnPropertyChanged(nameof(IsAllStaffButtonActive));
                }
            }
        }

        private bool isAdminButtonActive = false;
        public bool IsAdminButtonActive
        {
            get => isAdminButtonActive;
            set
            {
                if (isAdminButtonActive != value)
                {
                    isAdminButtonActive = value;
                    OnPropertyChanged(nameof(IsAdminButtonActive));
                }
            }
        }

        private bool isDeveloperButtonActive = false;
        public bool IsDeveloperButtonActive
        {
            get => isDeveloperButtonActive;
            set
            {
                if (isDeveloperButtonActive != value)
                {
                    isDeveloperButtonActive = value;
                    OnPropertyChanged(nameof(IsDeveloperButtonActive));
                }
            }
        }

        private bool isDesignerButtonActive = false;
        public bool IsDesignerButtonActive
        {
            get => isDesignerButtonActive;
            set
            {
                if (isDesignerButtonActive != value)
                {
                    isDesignerButtonActive = value;
                    OnPropertyChanged(nameof(IsDesignerButtonActive));
                }
            }
        }

        // Modify your button click methods to set the button states
        private void ChangeToFilterAllStaff()
        {
            MyFilterAction = "AllStaff";
            IsAllStaffButtonActive = true;
            IsAdminButtonActive = false;
            IsDeveloperButtonActive = false;
            IsDesignerButtonActive = false;
            Debug.WriteLine("Set Filter to AllStaff");
            LoadAllStaffAsync();
        }

        private void ChangeToFilterAdmin()
        {
            MyFilterAction = "Admin";
            IsAllStaffButtonActive = false;
            IsAdminButtonActive = true;
            IsDeveloperButtonActive = false;
            IsDesignerButtonActive = false;
            Debug.WriteLine("Set Filter to Admin");
            LoadAllStaffAsync();
        }

        private void ChangeToFilterDesigner()
        {
            MyFilterAction = "Designer";
            IsAllStaffButtonActive = false;
            IsAdminButtonActive = false;
            IsDeveloperButtonActive = false;
            IsDesignerButtonActive = true;
            Debug.WriteLine("Set Filter to Designer");
            LoadAllStaffAsync();
        }

        private void ChangeToFilterDeveloper()
        {
            MyFilterAction = "Developer";
            IsAllStaffButtonActive = false;
            IsAdminButtonActive = false;
            IsDeveloperButtonActive = true;
            IsDesignerButtonActive = false;
            Debug.WriteLine("Set Filter to Developer");
            LoadAllStaffAsync();
        }

        public void ChangeSelectedStaff(string iD)
        {
            MySelectedAction = "Developer";

            Debug.WriteLine("Set Filter to Selected");
            Debug.WriteLine(iD);

        }
    }



}
