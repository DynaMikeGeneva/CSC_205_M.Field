using CSC205_Madeira.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace CSC_205_M.Field.Controllers
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
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["familyList"] == null)
            {
                Session["familyList"] = families;
            }
        }
        // GET: Family
        public ActionResult Index()
        {
            var f = (List<Family>)Session["FamilyList"];
            return View(f);
        }

        // GET: Family/Details/5
        public ActionResult Details(int id)
        {
            var fList = (List<Family>)Session["familyList"];
            var f = fList[id];

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
            try
            {
                families = (List<Family>)Session["familyList"];
                Family newFamily = new Family()
                {
                    id = families.Count(),
                    familyname = collection["familyname"],
                    address1 = collection["middlename"],
                    city = collection["lastname"],
                    state = collection["cell"],
                    zip = collection["relationship"],
                    homephone = collection["homephone"]

                };

                families = (List<Family>)Session["familyList"];
                families.Add(newFamily);
                Session["familyList"] = families;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Family/Edit/5
        public ActionResult Edit(int id)
        {
            var fList = (List<Family>)Session["familyList"];
            var f = fList[id];
            //var f = families[id];

            return View(f);
        }

        // POST: Family/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var fList = (List<Family>)Session["familyList"];


                var f = fList[id];

                Family newFamily = new Family()
                {
                    id = id,
                    familyname = collection["familyname"],
                    address1 = collection["address1"],
                    city = collection["city"],
                    state = collection["state"],
                    zip = collection["zip"],
                    homephone = collection["homephone"]

                };
                fList.Where(x => x.id == id).First().familyname = collection["familyname"];
                fList.Where(x => x.id == id).First().address1 = collection["address1"];
                fList.Where(x => x.id == id).First().city = collection["city"];
                fList.Where(x => x.id == id).First().state = collection["state"];
                fList.Where(x => x.id == id).First().zip = collection["zip"];
                fList.Where(x => x.id == id).First().homephone = collection["homephone"];
                //Session["peopleList"] = pList.Where(x => x.id != id).ToList();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Family/Delete/5
        public ActionResult Delete(int id)
        {
            var fList = (List<Family>)Session["familyList"];
            var f = fList[id];
            return View(f);
        }

        // POST: Family/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var fList = (List<Family>)Session["familyList"];


                var f = fList[id];

                Session["familyList"] = fList.Where(x => x.id != id).ToList();
                fList = (List<Family>)Session["familyList"];
                for (int x = id; x < fList.Count(); x++)
                {
                    if (fList[x] != null)
                        fList[x].id = x;
                }




                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public string CreatePopup()
        {
            return "<h1>You have created a Family!</h1>";
        }
    }
}