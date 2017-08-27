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
    public class XMLContext
    {
        private List<Book> books = new List<Book>();
        private List<Magazine> magazines = new List<Magazine>();
        private List<Brochure> brochures = new List<Brochure>();
        private string booksPath = @"C:\Users\Антон\Documents\Visual Studio 2015\Projects\BooksWebSite\BooksWebSite\Storage\books.xml";
        private string magazinesPath = @"C:\Users\Антон\Documents\Visual Studio 2015\Projects\BooksWebSite\BooksWebSite\Storage\magazines.xml";
        private string brochurePath = @"C:\Users\Антон\Documents\Visual Studio 2015\Projects\BooksWebSite\BooksWebSite\Storage\brochures.xml";

        public XMLContext()
        {
            books = GetBooks();
            magazines = GetMagazines();
            brochures = GetBrochures();
        }

        public List<Book> Books
        {
            get { return books; }
        }

        public List<Magazine> Magazines
        {
            get { return magazines; }
        }

        public List<Brochure> Brochures
        {
            get { return brochures; }
        }

        /// <summary>
        /// Xml editor for magazines
        /// </summary>
        /// <returns></returns>

        private List<Book> GetBooks()
        {
            List<Book> container = new List<Book>();
            if (!File.Exists(booksPath))
            {
                XDocument xdoc = new XDocument();
                XElement books = new XElement("books");
                xdoc.Add(books);
                xdoc.Save(booksPath);
            }
            XDocument xDoc = XDocument.Load(booksPath);

            foreach(XElement bookElement in xDoc.Element("books").Elements("book"))
            {
                Book book = new Book();
                XAttribute idAttr = bookElement.Attribute("id");
                XElement nameEl = bookElement.Element("name");
                XElement authorEl = bookElement.Element("author");
                XElement yearEl = bookElement.Element("yearOfWriting");

                if(idAttr != null && nameEl != null && authorEl != null && yearEl != null)
                {
                    book.Id = Int32.Parse(idAttr.Value);
                    book.Author = authorEl.Value;
                    book.Name = nameEl.Value;
                    book.YearOfWriting = Int32.Parse(yearEl.Value);
                    container.Add(book);
                }
            }
            return container;
        }

        public void AddBook(Book book)
        {
            XDocument xDoc = XDocument.Load(booksPath);
            XElement xRoot = xDoc.Element("books");

            xRoot.Add(new XElement("book",
                    new XAttribute("id", book.Id.ToString()),
                    new XElement("name", book.Name),
                    new XElement("author", book.Author),
                    new XElement("yearOfWriting", book.YearOfWriting.ToString())));

            xDoc.Save(booksPath);
        }

        public void AlterBook(Book book)
        {
            XDocument xDoc = XDocument.Load(booksPath);
            XElement xRoot = xDoc.Element("books");

            foreach (XElement element in xRoot.Elements("book").ToList())
            {
                if (Int32.Parse(element.Attribute("id").Value) == book.Id)
                {
                    element.Element("name").Value = book.Name;
                    element.Element("author").Value = book.Author;
                    element.Element("yearOfWriting").Value = book.YearOfWriting.ToString();
                }
            }

            xDoc.Save(booksPath);
        }

        public void DeleteBook(int bookId)
        {
            XDocument xDoc = XDocument.Load(booksPath);
            XElement xRoot = xDoc.Element("books");
            foreach (XElement element in xRoot.Elements("book").ToList())
            {
                if (Int32.Parse(element.Attribute("id").Value) == bookId)
                {
                    element.Remove();
                }
            }
            xDoc.Save(booksPath);
        }

        public int GetBookID()
        {
            int id;
            XDocument xDoc = XDocument.Load(booksPath);
            if (xDoc.Element("books").Elements("book").ToList().Count != 0)
            {
                id = Int32.Parse(xDoc.Element("books").Elements("book").Last().Attribute("id").Value) + 1;
            }
            else id = 1;
            return id; 
        }

        /// <summary>
        /// Xml editor for magazines
        /// </summary>
        /// <returns></returns>

        private List<Magazine> GetMagazines()
        {
            List<Magazine> container = new List<Magazine>();
            if (!File.Exists(magazinesPath))
            {
                XDocument xdoc = new XDocument();
                XElement magazines = new XElement("magazines");
                xdoc.Add(magazines);
                xdoc.Save(magazinesPath);
            }
            XDocument xDoc = XDocument.Load(magazinesPath);

            foreach (XElement magazineElement in xDoc.Element("magazines").Elements("magazine"))
            {
                Magazine magazine = new Magazine();
                XAttribute idAttr = magazineElement.Attribute("id");
                XElement nameEl = magazineElement.Element("name");
                XElement numberEl = magazineElement.Element("number");
                XElement dateEl = magazineElement.Element("date");

                if (idAttr != null && nameEl != null && dateEl != null && numberEl != null)
                {
                    magazine.Id = Int32.Parse(idAttr.Value);
                    magazine.Name = nameEl.Value;
                    magazine.Number = Int32.Parse(numberEl.Value);
                    magazine.Date = DateTime.Parse(dateEl.Value);
                    container.Add(magazine);
                }
            }
            return container;
        }

        public void AddMagazine(Magazine magazine)
        {
            XDocument xDoc = XDocument.Load(magazinesPath);
            XElement xRoot = xDoc.Element("magazines");

            xRoot.Add(new XElement("magazine",
                    new XAttribute("id", magazine.Id.ToString()),
                    new XElement("name", magazine.Name),
                    new XElement("number", magazine.Number.ToString()),
                    new XElement("date", magazine.Date.ToString())));

            xDoc.Save(magazinesPath);
        }

        public void AlterMagazine(Magazine magazine)
        {
            XDocument xDoc = XDocument.Load(magazinesPath);
            XElement xRoot = xDoc.Element("magazines");

            foreach (XElement element in xRoot.Elements("magazine").ToList())
            {
                if (Int32.Parse(element.Attribute("id").Value) == magazine.Id)
                {
                    element.Element("name").Value = magazine.Name;
                    element.Element("number").Value = magazine.Number.ToString();
                    element.Element("date").Value = magazine.Date.ToString();
                }
            }
            xDoc.Save(magazinesPath);
        }

        public void DeleteMagazine(int magazineId)
        {
            XDocument xDoc = XDocument.Load(magazinesPath);
            XElement xRoot = xDoc.Element("magazines");
            foreach (XElement element in xRoot.Elements("magazine").ToList())
            {
                if (Int32.Parse(element.Attribute("id").Value) == magazineId)
                {
                    element.Remove();
                }
            }
            xDoc.Save(magazinesPath);
        }

        public int GetMagazineID()
        {
            int id;
            XDocument xDoc = XDocument.Load(magazinesPath);
            if (xDoc.Element("magazines").Elements("magazine").ToList().Count != 0)
            {
                id = Int32.Parse(xDoc.Element("magazines").Elements("magazine").Last().Attribute("id").Value) + 1;
            }
            else id = 1;
            return id;
        }

        /// <summary>
        /// Xml editor for brochures
        /// </summary>
        /// <returns></returns> 

        private List<Brochure> GetBrochures()
        {
            List<Brochure> container = new List<Brochure>();
            if (!File.Exists(brochurePath))
            {
                XDocument xdoc = new XDocument();
                XElement brochures = new XElement("brochures");
                xdoc.Add(brochures);
                xdoc.Save(brochurePath);
            }
            XDocument xDoc = XDocument.Load(brochurePath);

            foreach (XElement brochureElement in xDoc.Element("brochures").Elements("brochure"))
            {
                Brochure brochure = new Brochure();
                XAttribute idAttr = brochureElement.Attribute("id");
                XElement nameEl = brochureElement.Element("name");
                XElement authorEl = brochureElement.Element("author");
                XElement coverEl = brochureElement.Element("cover");
                XElement pagesEl = brochureElement.Element("pages");

                if (idAttr != null && nameEl != null && authorEl != null && pagesEl != null && pagesEl != null)
                {
                    brochure.Id = Int32.Parse(idAttr.Value);
                    brochure.Author = authorEl.Value;
                    brochure.Name = nameEl.Value;
                    brochure.Cover = coverEl.Value;
                    brochure.Pages = Int32.Parse(pagesEl.Value);
                    container.Add(brochure);
                }
            }
            return container;
        }

        public void AddBrochure(Brochure brochure)
        {
            XDocument xDoc = XDocument.Load(brochurePath);
            XElement xRoot = xDoc.Element("brochures");

            xRoot.Add(new XElement("brochure",
                    new XAttribute("id", brochure.Id.ToString()),
                    new XElement("name", brochure.Name),
                    new XElement("author", brochure.Author),
                    new XElement("cover", brochure.Cover),
                    new XElement("pages", brochure.Pages.ToString())));

            xDoc.Save(brochurePath);
        }

        public void AlterBrochure(Brochure brochure)
        {
            XDocument xDoc = XDocument.Load(brochurePath);
            XElement xRoot = xDoc.Element("brochures");

            foreach (XElement element in xRoot.Elements("brochure").ToList())
            {
                if (Int32.Parse(element.Attribute("id").Value) == brochure.Id)
                {
                    element.Element("name").Value = brochure.Name;
                    element.Element("author").Value = brochure.Author;
                    element.Element("cover").Value = brochure.Cover;
                    element.Element("pages").Value = brochure.Pages.ToString();
                }
            }

            xDoc.Save(brochurePath);
        }

        public void DeleteBrochure(int bookId)
        {
            XDocument xDoc = XDocument.Load(brochurePath);
            XElement xRoot = xDoc.Element("brochures");
            foreach (XElement element in xRoot.Elements("brochure").ToList())
            {
                if (Int32.Parse(element.Attribute("id").Value) == bookId)
                {
                    element.Remove();
                }
            }
            xDoc.Save(brochurePath);
        }

        public int GetBrochureID()
        {
            int id;
            XDocument xDoc = XDocument.Load(brochurePath);
            if (xDoc.Element("brochures").Elements("brochure").ToList().Count != 0)
            {
                id = Int32.Parse(xDoc.Element("brochures").Elements("brochure").Last().Attribute("id").Value) + 1;
            }
            else id = 1;
            return id;
        }

    }
}