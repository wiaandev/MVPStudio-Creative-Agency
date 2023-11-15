using MVPStudio_Creative_Agency.Models;
using MVPStudio_Creative_Agency.Services;
using MVPStudio_Creative_Agency.ViewModels;
using System.Diagnostics;
using MVPStudio_Creative_Agency.Views.Modals;
using MVPStudio_Creative_Agency.Views;
using CommunityToolkit.Maui.Views;

namespace MVPStudio_Creative_Agency.Components;

public partial class SingleCard : ContentView
{
    private ProjectService _projectService;
    public static readonly BindableProperty ClienNameProperty =
    BindableProperty.Create(nameof(ClienName), typeof(string), typeof(SingleProjectCard), default(string));

    public static readonly BindableProperty Project_NameProperty =
    BindableProperty.Create(nameof(Project_Name), typeof(string), typeof(SingleProjectCard), default(string));

    public static readonly BindableProperty Project_StartProperty =
    BindableProperty.Create(nameof(Project_Start), typeof(DateOnly), typeof(SingleProjectCard), default(DateOnly));

    public static readonly BindableProperty ProgressProperty =
    BindableProperty.Create(nameof(Progress), typeof(double), typeof(SingleProjectCard), default(double));

    public static readonly BindableProperty IsCompletedProperty =
    BindableProperty.Create(nameof(IsCompleted), typeof(bool), typeof(SingleProjectCard), default(bool));

    public static readonly BindableProperty TeamAssignedProperty =
    BindableProperty.Create(nameof(TeamAssigned), typeof(string), typeof(SingleProjectCard), default(string));

    public static readonly BindableProperty ClientProfileImgProperty =
    BindableProperty.Create(nameof(ClientProfileImg), typeof(string), typeof(ProjectsCard), default(string));



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

    public double Progress
    {
        get => (double)GetValue(ProgressProperty);
        set => SetValue(ProgressProperty, value / 100);
    }

    public bool IsCompleted
    {
        get => (bool)GetValue(IsCompletedProperty);
        set => SetValue(IsCompletedProperty, value);
    }

    public string TeamAssigned
    {
        get => (string)GetValue(TeamAssignedProperty);
        set => SetValue(TeamAssignedProperty, value);
    }

    public string ClientProfileImg
    {
        get => (string)GetValue(ClientProfileImgProperty);
        set => SetValue(ClientProfileImgProperty, value);
    }


    public SingleCard()
    {
        BindingContext = this;
        InitializeComponent();
        Debug.WriteLine($"IsCompleted: {IsCompleted}");

    }

    public async void ViewProject(object sender, EventArgs e)
    {
        if (BindingContext is Project project)
        {
            Debug.WriteLine(project.Id);
            var projectCardViewModel = new ProjectCardViewModel(_projectService);
            await projectCardViewModel.NavigateToOverviewScreenAsync(project.Id);
            Debug.WriteLine(project.Id);
        }
    }

    public async void DeleteProject(object sender, EventArgs e)
    {
            if (BindingContext is Project project)
            {
                Debug.WriteLine($"Deleting project with ID: {project.Id}");

                try
                {
                    var projectCardViewModel = new ProjectCardViewModel(_projectService);
                    await projectCardViewModel.DeleteProject(project.Id);

                    Debug.WriteLine($"Project with ID {project.Id} deleted successfully");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error deleting project with ID {project.Id}: {ex.Message}");
                    // You may want to handle or log the exception here.
                }
        }
    }


}