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
    public class MagazineEditorController : Controller
    {
        IRepository repository;

        public MagazineEditorController()
        {
            repository = new XMLRepository();
        }

        public ActionResult Index()
        {
            return View("MagazinesList", repository.Magazines);
        }

        public ActionResult MagazineEdit(int Id)
        {
            Magazine magazine = repository.Magazines.FirstOrDefault(m => m.Id == Id);
            return View(magazine);
        }

        [HttpPost]
        public ActionResult MagazineEdit(Magazine magazine)
        {
            if(ModelState.IsValid)
            {
                repository.SaveMagazine(magazine);
                TempData["message"] = string.Format("Changes of the magzine \"{0}\" was saved", magazine.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(magazine);
            }
        }

        public ActionResult CreateMagazine()
        {
            return View("MagazineEdit", new Magazine());
        }

        [HttpPost]
        public ActionResult DeleteMagazine(int Id)
        {
            Magazine deletedMagazine = repository.DeleteMagazine(Id);
            if (deletedMagazine != null)
            {
                TempData["message"] = string.Format("The magazine \"{0}\" was deleted",
                    deletedMagazine.Name);
            }
            return RedirectToAction("Index");
        }

    }
}