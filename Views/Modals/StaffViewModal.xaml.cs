using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Platform;
using MVPStudio_Creative_Agency.Components.StaffPageComponents;
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

        public StaffViewModal(StaffManagementPage staffManagementPage)
        {
            InitializeComponent();
        }


    }
}