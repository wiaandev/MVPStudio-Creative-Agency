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

        public string ClienName { get; set; }

        public string ClientProfileImg { get; set; }

        public string Project_Name { get; set; }

        public string Description { get; set; }

        public DateOnly Project_Start { get; set; }
        public int Duration_Week { get; set; }

        public int Project_Time { get; set; }

        public string Project_Type { get; set; }

        public int Project_Cost { get; set; }

        public int Amount_Paid { get; set; }

        public bool isCompleted { get; set; }

        public int Progress { get; set; }
        public string TeamAssigned { get; set; }
    }
}

        