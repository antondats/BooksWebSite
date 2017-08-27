using BooksWebSite.Abstract;
using BooksWebSite.Infrastructure;
using BooksWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksWebSite.Controllers
{
    public class BookEditorController : Controller
    {
        IRepository repository;

        public BookEditorController()
        {
            repository = new XMLRepository();
        }

        public ActionResult Index()
        {
            return View("BooksList", repository.Books);
        }

        public ActionResult BookEdit(int Id)
        {
            Book book = repository.Books.FirstOrDefault(b => b.Id == Id);
            return View(book);
        }

        [HttpPost]
        public ActionResult BookEdit(Book book)
        {
            if (ModelState.IsValid)
            {
                repository.SaveBook(book);
                TempData["message"] = string.Format("Changes of the book \"{0}\" was saved", book.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }

        public ActionResult CreateBook()
        {
            return View("BookEdit", new Book());
        }

        [HttpPost]
        public ActionResult DeleteBook(int Id)
        {
            Book deletedBook = repository.DeleteBook(Id);
            if (deletedBook != null)
            {
                TempData["message"] = string.Format("The book \"{0}\" was deleted",
                    deletedBook.Name);
            }
            return RedirectToAction("Index");
        }

    }
}