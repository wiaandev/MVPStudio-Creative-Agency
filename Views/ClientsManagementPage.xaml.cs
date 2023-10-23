using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;

using Microcharts.Maui;
using Mopups.Services;
using MVPStudio_Creative_Agency.Components;
using MVPStudio_Creative_Agency.Models;
using MVPStudio_Creative_Agency.ViewModels;
using MVPStudio_Creative_Agency.Views.Modals;
using System.Collections.ObjectModel;

namespace MVPStudio_Creative_Agency.Views;

public partial class ClientsManagementPage : ContentPage
{

    private ClientViewModel _clientViewModel;
    public ClientsManagementPage()
    {
        InitializeComponent();
        _clientViewModel = new ClientViewModel(new Services.ClientService()); // init our service
        BindingContext = _clientViewModel; //context of xaml is the view model

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _clientViewModel.FetchClients();
    }

    private void OpenPopUp(object sender, EventArgs e)
    {

        this.ShowPopup(new AddClientPopUp());
    }

    private async void OpenEditPopUp(object sender, EventArgs e)
    {
        



    }


}