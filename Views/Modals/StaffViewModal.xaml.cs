using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Platform;
using MVPStudio_Creative_Agency.Models;
using MVPStudio_Creative_Agency.Services;
using MVPStudio_Creative_Agency.ViewModels;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Input;


namespace MVPStudio_Creative_Agency.Views.Modals
{
    public partial class StaffViewModal : Popup
    {
        private StaffManagementPage _staffManagementPage;

        public List<Employee> StaffList { get; set; }
        public Employee SelectedStaff { get; set; }

        public StaffViewModal()
        {
            InitializeComponent();

            ChangeDesignerFilterCommand = new Command(ChangeToFilterDesigner);
            ChangeDeveloperFilterCommand = new Command(ChangeToFilterDeveloper);
            StaffList = GetStaffMembers();
            Debug.WriteLine(StaffList[0].FullName);


            BindingContext = this;
     

        }

        private List<Employee> GetStaffMembers()
        {
            // Retrieve the list of staff members from your data source
            // and return it as a List<Employee>
            // Example:
            // return staffRestService.GetStaffMembers();

            // For demonstration purposes, let's create a sample list of staff members
            return new List<Employee>
            {
                new Employee { Id = 1, FullName = "John Doe", Role_Type = "Developer" },
                new Employee { Id = 2, FullName = "Jane Smith", Role_Type = "Designer" },
                // Add more staff members as needed
            };
        }

        private int filteringStaff = 0;
        public ICommand ChangeDeveloperFilterCommand { get; private set; }



        public ICommand ChangeDesignerFilterCommand { get; private set; }

        public int MyFilterAction
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

        // ChangeTo to be applied to filtering buttnos
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

        // ChangeTo to be applied to filtering buttnos
        private bool isDesignButtonActive = false;
        public bool IsDesignButtonActive
        {
            get => isDesignButtonActive;
            set
            {
                if (isDesignButtonActive != value)
                {
                    isDesignButtonActive = value;
                    OnPropertyChanged(nameof(IsDesignButtonActive));
                }
            }
        }

        private void ChangeToFilterDeveloper()
        {
            MyFilterAction = 2;
            IsDeveloperButtonActive = true;
            IsDesignButtonActive = false;

            Debug.WriteLine("Set Filter to Developer");

        }
        private void ChangeToFilterDesigner()
        {
            MyFilterAction = 3;
            IsDeveloperButtonActive = false;
            IsDesignButtonActive = true;

            Debug.WriteLine("Set Filter to Designer");

        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            string name = entryName.Text;
            int roledId = filteringStaff;
            string surname = entrySurname.Text;
            string gender = entryGender.Text;
            string profileImg = entryProfileImg.Text;


            int currHours = 0;


            // Create a new Employee object and populate it
            if (int.TryParse(entryCurrHours.Text, out int parsedCurrHours))
            {
                // The nullable integer has a value (not null)
                currHours = Int32.Parse(entryCurrHours.Text); // Access the integer value

            }



            Employee newEmployee = new Employee
            {
                Name = name,
                RoleId = roledId,
                Surname = surname,
                Gender = gender,
                ProfileImg = profileImg,
                Curr_Hours = currHours

            };
            //validation
            if (string.IsNullOrWhiteSpace(name))
            {
                // Name is required. You can display an error message to the user.
                await ShowCustomAlertDialog("Validation Error", "Please enter a valid name.");
                return;
            }

            if (filteringStaff == 0)
            {
                // Role ID is required or you can perform additional validation here.
                await ShowCustomAlertDialog("Validation Error", "Please select a valid role.");
                return;
            }

            if (string.IsNullOrWhiteSpace(surname))
            {
                // Surname is required. You can display an error message to the user.
                await ShowCustomAlertDialog("Validation Error", "Please enter a valid surname.");
                return;
            }

            if (string.IsNullOrWhiteSpace(gender))
            {
                // Gender is required. You can display an error message to the user.
                await ShowCustomAlertDialog("Validation Error", "Please enter a valid gender.");
                return;
            }

            if (string.IsNullOrWhiteSpace(profileImg))
            {
                // Profile Image URL is required. You can display an error message to the user.
                await ShowCustomAlertDialog("Validation Error", "Please enter a valid profile image URL.");
                return;
            }

            if (!int.TryParse(entryCurrHours.Text, out currHours) || currHours < 0)
            {
                // Current Hours must be a non-negative integer. You can display an error message to the user.
                await ShowCustomAlertDialog("Validation Error", "Please enter a valid non-negative number for current hours.");
                return;
            }


           // StaffRestService staffRestService = new StaffRestService(); // Create an instance
           // bool success = await staffRestService.UpdateEmployeeAsync(CurrentEmployee); // Call UpdateEmployeeAsync instead of PostEmployeeAsync

           /* if (success)
            {
                // Employee was successfully created
                Debug.WriteLine("Employee created successfully.");
                //  await Navigation.PopPopupAsync(); // Close the modal
                await ShowCustomAlertDialog("Success", "Staff member added successfully");
                await this.CloseAsync();


            }
            else
            {
                // Handle the case where the POST request failed
                Debug.WriteLine("Failed to create employee.");
                // display an error message to the user

                await ShowCustomAlertDialog("Failure", "Failed to create employee.");

       }   */  

        }


        private async Task ShowCustomAlertDialog(string title, string message)
        {
            // Assuming this modal is opened from a parent page, use the parent page to display the alert

            await _staffManagementPage.DisplayAlert(title, message, "OK");
        }


    }
}