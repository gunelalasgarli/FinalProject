using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string FooterLogo { get; set; }
        public string SocialLink { get; set; }
        public string SocialImg { get; set; }
        public string PayImg { get; set; }
        public bool IsDeleted { get; set; }

        [NotMapped]
        public IFormFile FooterImage { get; set; }
        [NotMapped]
        public IFormFile LinkImage { get; set; }
    }
}
