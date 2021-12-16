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
         [NotMapped]
        public IFormFile HeaderImage { get; set; }
        [NotMapped]
        public IFormFile FooterImage{get;set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public int Phone { get; set; }
    }
}
