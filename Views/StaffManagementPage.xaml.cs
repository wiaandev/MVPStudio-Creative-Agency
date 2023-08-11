using System.Collections.ObjectModel;

namespace MVPStudio_Creative_Agency.Views;

public partial class StaffManagementPage : ContentPage
{
    public ObservableCollection<Card> Cards { get; set; }

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
                // Add more dummy data as needed
            };

        BindingContext = this;
    }
}

public class Card
{
    public string Title { get; internal set; }
}