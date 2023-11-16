using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPStudio_Creative_Agency.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string TeamName { get; set; }

        public int? ProjectId { get; set; }

        public List<int> EmployeeId { get; set; }
    }
}
