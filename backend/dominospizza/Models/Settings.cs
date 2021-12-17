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
        public string FooterLogo { get; set; }
        public string SectionImg { get; set; }
        public string SignImg { get; set; }

        public string TextImg { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string LinkImg { get; set; }
        public string PhoneImg { get; set; }
        public int PhoneNum { get; set; }
        [NotMapped]
        public IFormFile HeaderImage { get; set; }
        [NotMapped]
        public IFormFile FooterImage { get; set; }
        [NotMapped]
        public IFormFile SectionImage { get; set; }
        [NotMapped]
        public IFormFile SignImage { get; set; }
        [NotMapped]
        public IFormFile TextImage { get; set; }
        [NotMapped]
        public IFormFile LinkImage { get; set; }
        [NotMapped]
        public IFormFile PhoneImage { get; set; }
    }
}
