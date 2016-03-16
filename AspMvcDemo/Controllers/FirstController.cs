using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMvcDemo.Controllers
{
    public class FirstController : Controller
    {
        // GET: First
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            Models.FirstModel.first objcon = new Models.FirstModel.first();
            List<Models.FirstModel.first> Li = objcon.getdata(0,"","");
            return View("home", Li.ToList());
        }
        public ActionResult getdata()
        {
            Models.FirstModel.first objcon = new Models.FirstModel.first();
            List<Models.FirstModel.first> Li = objcon.getdata(0, "", "");
            return View("home", Li.ToList());
        }
        public ActionResult editdata(int id, string name, string address)
        {
            Models.FirstModel.first obj = new Models.FirstModel.first();
            List<Models.FirstModel.first> Li = obj.getdata(id, name, address);
            return View("editData",Li.ToList());
        }
        public ActionResult savedata(string name, string address)
        {
            int id = Convert.ToInt32(Session["id"].ToString());
            Models.FirstModel.first obj = new Models.FirstModel.first();
            obj.updatedata(id, name, address);
            List<Models.FirstModel.first> Li = obj.getdata(0, "","");
            return View("home", Li.ToList());
        }
        public ActionResult deletedata(int id)
        {
            Models.FirstModel.first obj = new Models.FirstModel.first();
            obj.deletedata(id);
            List<Models.FirstModel.first> Li = obj.getdata(0, "","");

            return RedirectToAction("home", "first", new { id = 0 });
        }
        public ActionResult adddata()
        {
            return View();
        }

        [HttpPost]
        public ActionResult insertdata(string name = "", string address = "")
        {
            Models.FirstModel.first obj = new Models.FirstModel.first();
            obj.insertdata(name, address);
            List<Models.FirstModel.first> Li = obj.getdata(0, "", "");
            return View("home", Li.ToList());
        }
    }
}