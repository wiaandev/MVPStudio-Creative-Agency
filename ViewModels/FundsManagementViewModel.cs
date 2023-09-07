using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPStudio_Creative_Agency.ViewModels
{
    class FundsManagementViewModel : BaseViewModel
    {
        public ProjectViewModel ProjectViewModel { get; set; }
        public StaffViewModel StaffViewModel { get; set; }
        public double ProfitValueLabel { get; set; }
    }
}
