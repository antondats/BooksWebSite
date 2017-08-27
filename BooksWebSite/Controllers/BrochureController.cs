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
    public class BrochureController : Controller
    {
        IRepository repository;

        public BrochureController()
        {
            repository = new XMLRepository();
        }
        
        public ActionResult Index()
        {
            return View(repository.Brochures);
        }

        public ActionResult BrochureEdit(int Id)
        {
            Brochure brochure = repository.Brochures.FirstOrDefault(b => b.Id == Id);
            return View(brochure);
        }

        [HttpPost]
        public ActionResult BrochureEdit(Brochure brochure)
        {
            if (ModelState.IsValid)
            {
                repository.SaveBrochure(brochure);
                TempData["message"] = string.Format("Changes of the brochure \"{0}\" was saved", brochure.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(brochure);
            }
        }

        public ActionResult CreateBrochure()
        {
            return View("BrochureEdit", new Brochure());
        }

        [HttpPost]
        public ActionResult DeleteBrochure(int Id)
        {
            Brochure deletedBrochure = repository.DeleteBrochure(Id);
            if (deletedBrochure != null)
            {
                TempData["message"] = string.Format("The brochure \"{0}\" was deleted",
                    deletedBrochure.Name);
            }
            return RedirectToAction("Index");
        }


    }
}