using Business.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stars2.Areas.Admin.Controllers
{
    public class USPersonagensController : Controller
    {
        // GET: Admin/USPersonagens
        public ActionResult Index()
        {
            var list = new PersonagensBusiness().List();
            return View(list);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var personagem = new PersonagensBusiness().Get(id);
            return View(personagem);
        }
    }
}