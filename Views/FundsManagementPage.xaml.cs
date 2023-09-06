using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
namespace MVPStudio_Creative_Agency.Views;

public partial class FundsManagementPage : ContentPage
{
    public ObservableCollection<FundCard> FundCards { get; set; }

    public FundsManagementPage()
    {
        InitializeComponent();
        // Populate the Cards collection with dummy data Array

        FundCards = new ObservableCollection<FundCard>
            {
                new FundCard { Name = "Google", Image = "profile_img.png", Bundle = "Web + App design bundle", Description = "This is a descrdddiption about the project overview/package", Team = "profile_img.png", Timeline = "2023", Cost = "R120 000.00", Paid = "R10 000.00", Progress = "50%"  },
                new FundCard { Name = "Google", Image = "profile_img.png", Bundle = "Web + App design bundle", Description = "This is a descrdddiption about the project overview/package", Team = "data", Timeline = "2023", Cost = "R120 000.00", Paid = "R10 000.00", Progress = "50%"  },
            };

        BindingContext = this;
    }
}

public class FundCard
{
    public string Name { get; internal set; }
    public string Image { get; internal set; }
    public string Bundle { get; internal set; }
    public string Description { get; internal set; }
    public string Team { get; internal set; }
    public string Timeline { get; internal set; }
    public string Cost { get; internal set; }
    public string Paid { get; internal set; }
    public string Progress { get; internal set; }
}