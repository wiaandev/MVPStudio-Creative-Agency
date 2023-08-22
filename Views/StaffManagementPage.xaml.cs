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
        // Populate the Cards collection with dummy data Array

        Cards = new ObservableCollection<Card>
            {
                new Card { Title = "Card 1" },
                new Card { Title = "Card 2" },
                new Card { Title = "Card 3" },
                new Card { Title = "Card 4" },
                new Card { Title = "Card 5" },
                  new Card { Title = "Card 5" },
                    new Card { Title = "Card 5" },
                      new Card { Title = "Card 5" },
                         new Card { Title = "Card 4" },
                new Card { Title = "Card 5" },
                  new Card { Title = "Card 5" },
                    new Card { Title = "Card 5" },
                      new Card { Title = "Card 5" },
                // Add more dummy data as needed
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
    public string Title { get; internal set; }
}

public class ProjectCard
{
    public string ProjectName { get; internal set; }
    public string Image { get; internal set; }
    public string Date { get; internal set; }
    public string State { get; internal set; }

}