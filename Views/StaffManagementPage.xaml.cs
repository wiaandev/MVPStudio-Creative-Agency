using System.Collections.ObjectModel;
using Microsoft.Maui.Controls; 
namespace MVPStudio_Creative_Agency.Views;

public partial class StaffManagementPage : ContentPage
{
    public ObservableCollection<Card> Cards { get; set; }
    public ObservableCollection<ProjectCard> ProjectCards { get; set; }


    public StaffManagementPage()
    {
        InitializeComponent();

        Cards = new ObservableCollection<Card>
            {
                new Card { Name = "John", Title = "Developer", Image = "profile_img.png", Projects = "4", Salary = "R13 500.00", ID = "1"},
                new Card { Name = "Jane", Title = "Developer", Image = "profile_img.png", Projects = "8", Salary = "R15 500.00", ID = "2"},
            };

        ProjectCards = new ObservableCollection<ProjectCard>
            {
                new ProjectCard { ProjectName = "Card 1", Image = "profile_img.png", Date = "2023", State = "Current" },
                new ProjectCard { ProjectName = "Card 2", Image = "profile_img.png", Date = "2021", State = "Closed" },
                new ProjectCard { ProjectName = "Card 3", Image = "profile_img.png", Date = "2022", State = "Current" },

            };

        BindingContext = this;
    }
}

public class Card
{
    public string Name { get; internal set; }
    public string Title { get; internal set; }
    public string Image { get; internal set; }
    public string Projects { get; internal set; }
    public string Salary { get; internal set; }
    public string ID { get; internal set; }
}

public class ProjectCard
{
    public string ProjectName { get; internal set; }
    public string Image { get; internal set; }
    public string Date { get; internal set; }
    public string State { get; internal set; }

}