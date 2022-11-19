using Business.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stars2.Controllers
{
    public class ArmasController : Controller
    {
        // GET: Armas
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
        public ActionResult Delete(int id)
        {
            bool result = new ArmasBusiness().Delete(id);
            if (result)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Erro");
        }
        public ActionResult Edit(int id)
        {
            var arma = new ArmasBusiness().Get(id);
            return View(arma);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            var result = new ArmasBusiness().Save(
                    form["ID"],
                    form["Nome"],
                    form["Descricao"]);
            if (result)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Erro");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            var result = new ArmasBusiness().Save(
                "0",
                form["Nome"],
                form["Descricao"]);

            if (result)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Erro");
        }
        public ActionResult Upload(int id)
        {
            ViewBag.ID = id;
            return View();
        }
        public ActionResult FileUpload(int idArma, HttpPostedFileBase file)
        {
            int idArm = idArma;

            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string ext = "a.jpg";
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Content/Estilo/"), idArm + ext);                
                file.SaveAs(path);
                path = System.IO.Path.Combine(
                                       Server.MapPath("~/Areas/Admin/Content/Armas/"), idArm + ext);
                file.SaveAs(path);
            }            
            return RedirectToAction("Details", "Armas", new { id = idArm });
        }

    }
}