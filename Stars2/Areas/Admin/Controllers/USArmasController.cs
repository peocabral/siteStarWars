using Business.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stars2.Areas.Admin.Controllers
{
    public class USArmasController : Controller
    {
        // GET: Admin/USArmas
        public ActionResult Index()
        {
            var list = new ArmasBusiness().List();
            return View(list);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var arma = new ArmasBusiness().Get(id);
            return View(arma);
        }
    }
}