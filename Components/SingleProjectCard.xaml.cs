using MVPStudio_Creative_Agency.Models;
using MVPStudio_Creative_Agency.ViewModels;
using System.Diagnostics;

namespace MVPStudio_Creative_Agency.Components;

public partial class SingleProjectCard : ContentView
{
    public static readonly BindableProperty ClienNameProperty =
    BindableProperty.Create(nameof(ClienName), typeof(string), typeof(SingleProjectCard), default(string));

    public static readonly BindableProperty Project_NameProperty =
    BindableProperty.Create(nameof(Project_Name), typeof(string), typeof(SingleProjectCard), default(string));

    public static readonly BindableProperty Project_StartProperty =
    BindableProperty.Create(nameof(Project_Start), typeof(DateOnly), typeof(SingleProjectCard), default(DateOnly));



    public string ClienName
    {
        get => (string)GetValue(ClienNameProperty);
        set => SetValue(ClienNameProperty, value);
    }

    public string Project_Name
    {
        get => (string)GetValue(Project_NameProperty);
        set => SetValue(Project_NameProperty, value);
    }

    public DateOnly Project_Start
    {
        get => (DateOnly)GetValue(Project_StartProperty);
        set => SetValue(Project_StartProperty, value);
    }


    public SingleProjectCard()
    {
        BindingContext = this;
        InitializeComponent();
    }

    public async void ViewProject(object sender, EventArgs e)
    {
        if (BindingContext is Project project)
        {
            Debug.WriteLine(project.Id);
            var projectCardViewModel = new ProjectCardViewModel();
            await projectCardViewModel.NavigateToOverviewScreenAsync(project.Id);
            Debug.WriteLine(project.Id);
        }
    }
}
