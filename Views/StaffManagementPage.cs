namespace MVPStudio_Creative_Agency.Views;

public class StaffManagementPage : ContentPage
{
	public StaffManagementPage()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};
	}
}
