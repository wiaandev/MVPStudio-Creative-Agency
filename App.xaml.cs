namespace MVPStudio_Creative_Agency;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        const int newWidth = 1440;
        const int newHeight = 900;

        window.Width = newWidth;
        window.Height = newHeight;

        return window;
    }
}

