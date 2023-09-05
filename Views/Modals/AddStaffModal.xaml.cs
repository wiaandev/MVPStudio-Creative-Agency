using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using MVPStudio_Creative_Agency.Models;
using MVPStudio_Creative_Agency.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace MVPStudio_Creative_Agency.Views.Modals
{
    public partial class AddStaffModal : Popup
    {
        /*  private DateTime dateOfBirth = DateTime.Now;

          public DateTime DateOfBirth
          {
              get => dateOfBirth; // Convert DateOnly to DateTime
              set => dateOfBirth = value; // Convert DateTime to DateOnly
          }*/

        // Define a DateOnly property for the actual data binding     
        public DateOnly SelectedDate { get; set; }



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
            Debug.WriteLine(newEmployee);
            Debug.WriteLine(newEmployee.Name);
   

    
            Debug.WriteLine(newEmployee.Id);
            Debug.WriteLine(newEmployee.Surname);
            Debug.WriteLine(newEmployee.Gender);
            Debug.WriteLine(newEmployee.Birth_Date);
            Debug.WriteLine(newEmployee.Curr_Hours);
            Debug.WriteLine(newEmployee.ProfileImg);

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
