using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPStudio_Creative_Agency.Models
{
    public class Client
    {      
            public int Id { get; set; }

            public string Name { get; set; } = string.Empty;

            public string ImgUrl { get; set; } = string.Empty;

            public string Email { get; set; } = string.Empty;

            public int ClientTypeId { get; set; }
            public string ClientType { get; set; }
       
    }
}
