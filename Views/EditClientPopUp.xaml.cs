using MVPStudio_Creative_Agency.Models;
using MVPStudio_Creative_Agency.ViewModels;

namespace MVPStudio_Creative_Agency.Views;

public partial class EditClientPopUp : ContentPage
{

    private ClientViewModel _clientViewModel;
    public EditClientPopUp(Client clientData)
	{
		InitializeComponent();

        _clientViewModel = new ClientViewModel(new Services.ClientService());

        BindingContext = _clientViewModel;

        _ = _clientViewModel.updateFormValues(clientData);
    }
}