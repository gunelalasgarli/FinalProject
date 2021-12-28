using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace dominospizza.Models
{
    public class Settings
    {
        public int Id { get; set; }
        public string HeaderLogo { get; set; }
        public string PhoneImg { get; set; }
        public int PhoneNum { get; set; }
       
        public bool IsDeleted { get; set; }

        [NotMapped]
        public IFormFile HeaderImage { get; set; }
      
    }
}
