using System.Collections.ObjectModel;

namespace MVPStudio_Creative_Agency.Views;

public partial class FundsManagementPage : ContentPage
{
    public ObservableCollection<Card1> Cards1 { get; set; }

    public FundsManagementPage()
    {
        InitializeComponent();
        // Populate the Cards collection with dummy data Array

        Cards1 = new ObservableCollection<Card1>
            {
                new Card1 { Title = "Card 1" },
                new Card1 { Title = "Card 2" },
                new Card1 { Title = "Card 3" },
                new Card1 { Title = "Card 4" },
                new Card1 { Title = "Card 5" },
                // Add more dummy data as needed
            };

        BindingContext = this;
    }
}

public class Card1
{
    public string Title { get; internal set; }
}