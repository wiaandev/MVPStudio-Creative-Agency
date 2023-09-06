using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;

using Microsoft.Maui.Controls.Platform;
using Mopups.Services;
using MVPStudio_Creative_Agency.Components.StaffPageComponents;


using MVPStudio_Creative_Agency.Models;
using MVPStudio_Creative_Agency.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace MVPStudio_Creative_Agency.Views.Modals
{
    public partial class AddStaffModal : Popup
    {

        
        private StaffManagementPage _staffManagementPage;

        public AddStaffModal(StaffManagementPage staffManagementPage)
        {
            InitializeComponent();

            ChangeDesignerFilterCommand = new Command(ChangeToFilterDesigner);
            ChangeDeveloperFilterCommand = new Command(ChangeToFilterDeveloper);
          
            BindingContext = this;
            _staffManagementPage = staffManagementPage;
        }

        public AddStaffModal(StaffAdminTab staffAdminTab)
        {
            this.staffAdminTab = staffAdminTab;
        }

        private int filteringStaff = 0;
        public ICommand ChangeDeveloperFilterCommand { get; private set; }

       


          public DateTime DateOfBirth
          {
              get => dateOfBirth; // Convert DateOnly to DateTime
              set => dateOfBirth = value; // Convert DateTime to DateOnly
          }*/

        // Define a DateOnly property for the actual data binding     
        public DateOnly SelectedDate { get; set; }


        // ChangeTo to be applied to filtering buttnos
        private bool isDesignButtonActive = false;
        private StaffAdminTab staffAdminTab;

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



        public Employee NewEmployee { get; set; } = new Employee();

        public AddStaffModal()
        {
            InitializeComponent();
            datePickerBirthDate.BindingContext = this;

        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine(SelectedDate);
            // Create a new Employee object and populate it

            if (int.TryParse(entryCurrHours.Text, out int parsedCurrHours))
            {
                // The nullable integer has a value (not null)
                currHours = Int32.Parse(entryCurrHours.Text); // Access the integer value
                
            }


            Employee newEmployee = new Employee
            {
                Name = NewEmployee.Name,
                Surname = NewEmployee.Surname,
                Gender = NewEmployee.Gender,
                ProfileImg = NewEmployee.ProfileImg,
                Birth_Date = SelectedDate,
                Curr_Hours = NewEmployee.Curr_Hours
                // Set other properties as needed
            };

            //validation
            if (string.IsNullOrWhiteSpace(name))
            {
          
                await ShowCustomAlertDialog("Validation Error", "Please enter a valid name.");
                return;
            }

            if (filteringStaff == 0)
            {
                // Role ID is required 
                await ShowCustomAlertDialog("Validation Error", "Please select a valid role.");
                return;
            }

            if (string.IsNullOrWhiteSpace(surname))
            {
                await ShowCustomAlertDialog("Validation Error", "Please enter a valid surname.");
                return;
            }

            if (string.IsNullOrWhiteSpace(gender))
            {
                await ShowCustomAlertDialog("Validation Error", "Please enter a valid gender.");
                return;
            }

            if (string.IsNullOrWhiteSpace(profileImg))
            {
                // Profile Image URL is required. 
                await ShowCustomAlertDialog("Validation Error", "Please enter a valid profile image URL.");
                return;
            }

            if (!int.TryParse(entryCurrHours.Text, out currHours) || currHours < 0)
            {
                // Current Hours must be a non-negative integer. You can display an error message to the user.
                await ShowCustomAlertDialog("Validation Error", "Please enter a valid non-negative number for current hours.");
                return;
            }



            StaffRestService staffRestService = new StaffRestService(); // Create an instance
            bool success = await staffRestService.PostEmployeeAsync(newEmployee);

            if (success)
            {
                // Employee was successfully created
                Debug.WriteLine("Employee created successfully.");
              //  await Navigation.PopPopupAsync(); // Close the modal
            }
            else
            {
                // Handle the case where the POST request failed
                Debug.WriteLine("Failed to create employee.");
                // Optionally, display an error message to the user
            }
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Cancel");
        }
    }
}
