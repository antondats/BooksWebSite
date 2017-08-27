using BooksWebSite.Abstract;
using BooksWebSite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace BooksWebSite.Infrastructure
{
    public class XMLRepository : IRepository 
    {
        XMLContext context = new XMLContext();

        public IEnumerable<Book> Books
        {
            get{ return context.Books;}
        }

        public IEnumerable<Magazine> Magazines
        {
            get{ return context.Magazines; }
        }

        public IEnumerable<Brochure> Brochures
        {
            get { return context.Brochures; }
        }

        public IEnumerable<Wastepaper> GetAllSubjects()
        {
            List<Wastepaper> list = new List<Wastepaper>();
            foreach(Book sbj in Books)
            {
                list.Add(sbj);
            }
            foreach (Magazine sbj in Magazines)
            {
                list.Add(sbj);
            }
            foreach (Brochure sbj in Brochures)
            {
                list.Add(sbj);
            }

            return list;
        }

        public void SaveBook(Book book)
        {
            if (book.Id == 0)
            {
                book.Id = context.GetBookID();
                context.Books.Add(book);
                context.AddBook(book);
            }
            else
            {
                context.AlterBook(book);
            }
        }

        public void SaveMagazine(Magazine magazine)
        {
            if (magazine.Id == 0)
            {
                magazine.Id = context.GetMagazineID();
                context.Magazines.Add(magazine);
                context.AddMagazine(magazine);
            }
            else
            {
                context.AlterMagazine(magazine);
            }
        }

        public void SaveBrochure(Brochure brochure)
        {
            if (brochure.Id == 0)
            {
                brochure.Id = context.GetBrochureID();
                context.Brochures.Add(brochure);
                context.AddBrochure(brochure);
            }
            else
            {
                context.AlterBrochure(brochure);
            }
        }

        public Book DeleteBook(int bookId)
        {
            Book book = context.Books.Find(b=>b.Id == bookId);

            if (book != null)
            {
                context.DeleteBook(bookId);
            }
            return book;
        }

        public Magazine DeleteMagazine(int magazineId)
        {
            Magazine magazine = context.Magazines.Find(m => m.Id == magazineId);

            if (magazine != null)
            {
                context.DeleteMagazine(magazineId);
            }
            return magazine;
        }

        public Brochure DeleteBrochure(int brochureId)
        {
            Brochure brochure = context.Brochures.Find(b => b.Id == brochureId);

            if (brochure != null)
            {
                context.DeleteBrochure(brochureId);
            }
            return brochure;
        }
    }
}