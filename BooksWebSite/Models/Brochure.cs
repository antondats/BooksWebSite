using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksWebSite.Models
{
    public class Brochure: Wastepaper
    {
        [Display(Name = "Cover")]
        [Required(ErrorMessage = "Please, enter cover of brochure")]
        public string Cover { get; set; }

        [Display(Name = "Count of pages")]
        [Required(ErrorMessage = "Please, entet count of pages")]
        [Range(0, 1000, ErrorMessage = "Incorrect count of pages")]
        public int Pages { get; set; }

        [Display(Name = "Author")]
        [Required(ErrorMessage = "Please, enter author of brochure")]
        public string Author { get; set; }

        public override string Type()
        {
            return "Brochure";
        }
    }
}