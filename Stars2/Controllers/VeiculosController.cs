using Business.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stars2.Controllers
{
    public class VeiculosController : Controller
    {
        // GET: Veiculos
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
        public ActionResult Delete(int id)
        {
            bool result = new VeiculosBusiness().Delete(id);
            if (result)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Erro");
        }
        public ActionResult Edit(int id)
        {
            var veiculo = new VeiculosBusiness().Get(id);
            return View(veiculo);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            var result = new VeiculosBusiness().Save(
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
            var result = new VeiculosBusiness().Save(
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
        public ActionResult FileUpload(int idVeiculo, HttpPostedFileBase file)
        {
            int idVeic = idVeiculo;

            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string ext = "v.jpg";
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Content/Estilo/"), idVeic + ext);
                file.SaveAs(path);
                path = System.IO.Path.Combine(
                                       Server.MapPath("~/Areas/Admin/Content/Veiculos/"), idVeic + ext);
                file.SaveAs(path);
            }
            return RedirectToAction("Details", "Veiculos", new { id = idVeic });
        }
    }
}