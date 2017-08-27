using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksWebSite.Models
{
    public class Wastepaper
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please, enter title")]
        public string Name { get; set; }

        public virtual string Type()
        {
            return "Wastepaper";  
        } 
    }
}