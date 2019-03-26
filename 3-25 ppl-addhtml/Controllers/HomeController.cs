using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using People;

namespace _3_25_ppl_addhtml.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DbManger mgr = new DbManger(Properties.Settings.Default.ConStr);
            IEnumerable<Person> ppl =  mgr.GetPeople();
            return View(ppl);
        }

       
       public ActionResult AddPeople()
        {   
            return View();
        }

        [HttpPost]
        public ActionResult AddPeopleDB(List<Person> ppl)
        {
            DbManger mgr = new DbManger(Properties.Settings.Default.ConStr);
            mgr.AddPeople(ppl);
            return Redirect("/");
        }
    }
}