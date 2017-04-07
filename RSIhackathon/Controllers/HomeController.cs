using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RSIhackathon.Models;

namespace RSIhackathon.Controllers
{
    public class HomeController : Controller
    {
        RSIDataDataContext _context = new RSIDataDataContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SignInFormModel signInModel)
        {
            var visitor = new Visitor()
            {
                Firstname = signInModel.Firstname,
                Lastname = signInModel.Lastname,
                IDNumber = signInModel.IDNumber,
                IDType = signInModel.IDType,
                ArivalDate = DateTime.Now,
                DepatureDate = null
            };

            _context.Visitors.InsertOnSubmit(visitor);
            _context.SubmitChanges();
            
            return View("Index");
        }

        public ActionResult List(SearchModel searchModel)
        {
            if (searchModel == null)
            {
                IEnumerable<Visitor> visitors = _context.Visitors.ToList();
                return View(visitors);
            }
            IEnumerable<Visitor> results = _context.Visitors.Where(v => string.Equals(v.Firstname, searchModel.FirstName));
            return View(results);
        }
    }
}