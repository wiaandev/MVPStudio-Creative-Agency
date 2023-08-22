using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPStudio_Creative_Agency.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public int RoleId { get; set; }
        //public Role Role { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Gender { get; set; }

        public string ProfileImg { get; set; }

        public DateOnly? Birth_Date { get; set; }

        public int Curr_Hours { get; set; }
    }
}
