using Business.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stars2.Areas.Admin.Controllers
{
    public class USVeiculosController : Controller
    {
        // GET: Admin/USVeiculos
        public ActionResult Index()
        {
            var list = new VeiculosBusiness().List();
            return View(list);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var veiculo = new VeiculosBusiness().Get(id);
            return View(veiculo);
        }
    }
}