using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dominospizza.Models
{
    public class HomePage
    {
        public int Id { get; set; }
        public string SectionImg1 { get; set; }
        public string Title1 { get; set; }
        public string Subtitle1 { get; set; }
        public string Description1 { get; set; }
        public string SectionImg2 { get; set; }
        public string SectionImg3 { get; set; }
        public string Title2 { get; set; }
        public string Subtitle2 { get; set; }
        public string Description2 { get; set; }
        public string SignImg { get; set; }
        [NotMapped]
        public IFormFile SectionImage1 { get; set; }
        [NotMapped]
        public IFormFile SignImage1 { get; set; }
        [NotMapped]
        public IFormFile SectionImage2 { get; set; }
        [NotMapped]
        public IFormFile SectionImage3 { get; set; }
    }
}
