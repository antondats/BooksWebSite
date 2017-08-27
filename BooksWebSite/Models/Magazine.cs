using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksWebSite.Models
{
    public class Magazine: Wastepaper
    {
        [Display(Name = "Number of magazine")]
        [Required(ErrorMessage = "Please, enter number of magazine")]
        public int Number { get; set; }

        [Display(Name = "Date of publishing")]
        [Required(ErrorMessage = "Please, enter date")]
        public DateTime Date { get; set; }

        public override string Type()
        {
            return "Magazine";
        }
    }
}