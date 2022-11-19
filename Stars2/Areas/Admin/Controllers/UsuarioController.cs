using Business;
using Business.Business;
using Business.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Stars2.Areas.Admin.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            var usuario = new UsuarioBusiness().Logar(form["Login"], form["Senha"]);
            if (usuario == null)
            {
                TempData["msg"] = "<script>alert('Usuário inválido!');</script>";
                Session["usuarioLogado"] = "";
                FormsAuthentication.SignOut();
                return View();
            }
            else
            {
                TempData["msg"] = "";
                Session["usuarioLogado"] = usuario;
                FormsAuthentication.SetAuthCookie(usuario.Login, false);
                return RedirectToAction("Lobby", "Usuario", new { area = "admin" });
            }
        }

        [HttpGet]
        public ActionResult Sair()
        {
            Session["usuarioLogado"] = "";
            FormsAuthentication.SignOut();
            return RedirectToAction("Lobby");
        }

        [HttpGet]
        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(FormCollection form)
        {
            try
            {
                var usuario = new UsuarioBusiness().Criar(
                    form["Login"],
                    form["Nome"]);

                if (usuario)
                {
                    TempData["msg"] = "<script>alert('Usuário Criado com sucesso!');</script>";
                    return View();
                }
                else
                {
                    TempData["msg"] = "<script>alert('Usuário não Criado!');</script>";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "<script>alert('" + ex.Message + "');</script>";
                return View();
            }
        }


        [HttpGet]
        public ActionResult Ativar(string chave)
        {
            var deucerto = false;
            string[] str = new string[] { };
            var data = DateTime.Now;
            Guid id = new Guid();
            try
            {
                str = new Utilitario().Descriptografar(chave).Split(';');
                data = Convert.ToDateTime(str[0]);
                id = new Guid(str[1]);
                deucerto = true;
            }
            catch { }

            if (deucerto)
            {
                //verifica a validade do link
                if (data < DateTime.Now)
                {
                    TempData["msg"] = "<script>alert('O link expirou!');</script>";
                    return RedirectToAction("login", "usuario");
                }

                //executa a ativação
                deucerto = new UsuarioBusiness().Ativar(id);

                if (deucerto)
                    return RedirectToAction("CriarSenha", new { id = id });
                else
                {
                    TempData["msg"] = "<script>alert('Erro ao ativar');</script>";
                    return RedirectToAction("login", "usuario");

                }
            }
            else
            {
                TempData["msg"] = "<script>alert('Código de ativação inválido');</script>";
                return RedirectToAction("login", "usuario");
            }
        }


        [HttpGet]
        public ActionResult CriarSenha(Guid id)
        {
            var usuario = new UsuarioBusiness().Buscar(id);
            return View(usuario);
        }

        [HttpPost]
        public ActionResult CriarSenha(FormCollection form)
        {
            Usuario usuario = new Usuario();
            usuario.ID = new Guid(form["id"]);
            usuario.Senha = form["senha"];
            var resp = new UsuarioBusiness().TrocarSenha(usuario);
            if (resp)
                TempData["msg"] = "<script>alert('Senha criada/alterada com sucesso!');</script>";
            else
                TempData["msg"] = "<script>alert('Erro ao criar senha');</script>";

            return RedirectToAction("Login");
        }


        [HttpGet]
        public ActionResult Recuperar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Recuperar(FormCollection form)
        {
            var resp = new UsuarioBusiness().Recuperar(form["login"]);

            if (resp)
                TempData["msg"] = "<script>alert('Verifique seu E-mail');</script>";
            else
                TempData["msg"] = "<script>alert('Erro ao recuperar a senha.');</script>";


            return RedirectToAction("Login");
        }
        public ActionResult Lobby()
        {
            return View();
        }

    }
}