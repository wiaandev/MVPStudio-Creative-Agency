using CommunityToolkit.Maui.Views;
using MVPStudio_Creative_Agency.Models;
using MVPStudio_Creative_Agency.Services;
using MVPStudio_Creative_Agency.ViewModels;
using System.Diagnostics;

namespace MVPStudio_Creative_Agency.Views;

public partial class AddClientPopUp : Popup
{
    public AddClientPopUp()
    {
        InitializeComponent();
    }

    private void ClosePopUp(object sender, EventArgs e)
    {
        Close();
    }
}