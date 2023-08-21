using Microcharts;
using SkiaSharp;

namespace MVPStudio_Creative_Agency.Views
{
    public partial class DashboardPage : ContentPage
    {
        ChartEntry[] entries = new[]
        {
            new ChartEntry(212)
            {
                Label = "Revenue",
                ValueLabel = "112",
                Color = SKColor.Parse("#2c3e50")
            },
            new ChartEntry(248)
            {
                Label = "Unpaid",
                ValueLabel = "648",
                Color = SKColor.Parse("#e3e3e3")
            },
            new ChartEntry(128)
            {
                Label = "Profit",
                ValueLabel = "428",
                Color = SKColor.Parse("#b455b6")
            },
            /*new ChartEntry(514)
            {
                Label = ".NET MAUI",
                ValueLabel = "214",
                Color = SKColor.Parse("#3498db")
            }*/
        };

        public DashboardPage()
        {
            InitializeComponent();

            chartView.Chart = new RadarChart
            {
                Entries = entries
            };
        }
    }
}
