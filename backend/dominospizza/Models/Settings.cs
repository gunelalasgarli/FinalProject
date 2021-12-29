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
        [StringLength(100)]
        public string HeaderLogo { get; set; }
        [StringLength(100)]
        public string PhoneImg { get; set; }
        [StringLength(15)]
        public string PhoneNum { get; set; }
        [Required,StringLength(200)]
        public string Copyright { get; set; }
        public bool IsDeleted { get; set; }

        [NotMapped]
        public IFormFile HeaderImage { get; set; }
        [NotMapped]
        public IFormFile PhoneImage { get; set; }

    }
}
