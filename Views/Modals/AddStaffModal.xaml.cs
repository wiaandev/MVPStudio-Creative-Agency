using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using System.Diagnostics;

namespace MVPStudio_Creative_Agency.Views.Modals;

public partial class AddStaffModal : Popup
{
	public AddStaffModal()
	{
		InitializeComponent();
	}

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        Debug.WriteLine("Save");
    }

    private void CancelButtom_Clicked(object sender, EventArgs e)
    {
        Debug.WriteLine("Cancel");
    }

}