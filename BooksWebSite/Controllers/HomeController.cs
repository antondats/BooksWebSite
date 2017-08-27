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
    public class HomeController : Controller
    {
        IRepository repository;

        public HomeController()
        {
            repository = new XMLRepository();
        }
           
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData(int page = 1)
        {
            int countPerPage = 2;
            ModelForAllEntities info = new ModelForAllEntities();
            List<Subject> data = new List<Subject>();
            foreach(Wastepaper wst in repository.GetAllSubjects())
            {
                Subject subject = new Subject();
                subject.Name = wst.Name;
                subject.Type = wst.Type();
                data.Add(subject);
            }
            info.Total = data.Count;
            info.Data = data.Skip((page - 1) * countPerPage).Take(countPerPage).ToList();
            info.ItemPerPage = countPerPage;
            info.CurrentPage = page;
            return Json(info, JsonRequestBehavior.AllowGet);
        }
    }
}