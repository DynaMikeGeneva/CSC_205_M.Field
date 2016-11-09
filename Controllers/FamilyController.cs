using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSC205_Madeira.Models;


namespace CSC205_Madeira.Controllers
{
    public class FamilyController : Controller
    {
        List<Family> families;

        public FamilyController()
        {
            families = new List<Family>
            {
                new Family() { id=0, familyname = "Madeira", address1 = "123 Hastings Dr", city = "Cranberry Township", state = "PA", zip = "16066", homephone = "7247797964" },
                new Family() { id=1, familyname = "Johns", address1 = "3200 College Ave", city = "Beaver Falls", state = "PA", zip = "15010", homephone = "7248461298" },
                new Family() { id=2, familyname = "Ellis", address1 = "1 Sycamore Hollow", city = "Pittsburgh", state = "PA", zip = "15212", homephone = "4122371212" },
                new Family() { id=3, familyname = "Braddock", address1 = "23 Livingstone Dr", city = "Monroeville", state = "PA", zip = "15010", homephone = "4123277486" }
            };
            
            
        }

        // GET: Family
        public ActionResult Index()
        {
   
            return View(families);                     
        }

        // GET: Family/Details/5
        public ActionResult Details(int id)
        {
            var f = families[id];

            return View(f);
        }

        // GET: Family/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Family/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            Family f = new Family() { id = 8, familyname = "Davidson", address1 = "123 Hastings Dr", city = "Cranberry Township", state = "PA", zip = "16066", homephone = "7247797964" };
            families.Add(f);

            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
            return RedirectToAction("Index");

        }
    }
}