using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPStudio_Creative_Agency.Models
{
    public class StaffRoles
    {
        public int Id { get; set; }

        public string Role_Type { get; set; }

        public int Hourly_Rate { get; set; }

        public int Salary { get; set; }
    }
}
