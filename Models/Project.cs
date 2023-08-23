using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPStudio_Creative_Agency.Models
{
    public class Project
    {
        public int Id { get; set; }
        public int ClientId { get; set; }

        public string Project_Name { get; set; }

        public string Description { get; set; }

        public int Project_Time { get; set; }

        public string Project_Type { get; set; }

        public int Project_Cost { get; set; }

        public int Amount_Paid { get; set; } = 0;
    }
}
