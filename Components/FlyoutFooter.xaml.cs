namespace MVPStudio_Creative_Agency.Components;

public partial class FlyoutFooter : ContentView
{
	public FlyoutFooter()
	{
		InitializeComponent();
	}

    private async void logout(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("/LoginPage");
    }
}
