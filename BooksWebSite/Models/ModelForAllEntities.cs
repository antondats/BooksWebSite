using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksWebSite.Models
{
    public struct Subject
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
    public class ModelForAllEntities
    {
        public List<Subject> data = new List<Subject>();
        public List<Subject> Data { get; set; }
        public int Total { get; set; }
        public int ItemPerPage { get; set; }
        public int CurrentPage { get; set; }
    }
}