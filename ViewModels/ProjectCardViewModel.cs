using MVPStudio_Creative_Agency.Components;
using MVPStudio_Creative_Agency.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPStudio_Creative_Agency.ViewModels
{
    public class ProjectCardViewModel
    {
        public async Task NavigateToOverviewScreenAsync(int id)
        {
            var viewModel = new NavigationViewModel { NavigationParameter = id };
            Debug.WriteLine(id);
            await Shell.Current.Navigation.PushAsync(new DetailedProjectPage { BindingContext = viewModel });
        }
    }
}
