using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksWebSite.Models
{
    public class Book: Wastepaper
    {
        [Display(Name = "Author")]
        [Required(ErrorMessage = "Please, enter author of the book")]
        public string Author { get; set; }

        [Display(Name = "Year of writing")]
        [Required(ErrorMessage = "Please, enter the year of writing the book")]
        public int YearOfWriting { get; set; }

        public override string Type()
        {
            return "Book";
        }
    }
}