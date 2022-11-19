using Business.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stars2.Controllers
{
    public class PersonagensController : Controller
    {
        // GET: Personagens
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
        public ActionResult Delete(int id)
        {
            bool result = new PersonagensBusiness().Delete(id);
            if (result)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Erro");
        }
        public ActionResult Edit(int id)
        {
            var personagem = new PersonagensBusiness().Get(id);
            return View(personagem);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            var result = new PersonagensBusiness().Save(
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
            var result = new PersonagensBusiness().Save(
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
        public ActionResult FileUpload(int idPersonagem, HttpPostedFileBase file)
        {
            int idPer = idPersonagem;

            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string ext = "p.jpg";
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Content/Estilo/"), idPer + ext);
                file.SaveAs(path);
                path = System.IO.Path.Combine(
                                       Server.MapPath("~/Areas/Admin/Content/Personagens/"), idPer + ext);
                file.SaveAs(path);
            }
            return RedirectToAction("Details", "Personagens", new { id = idPer });
        }
    }
}