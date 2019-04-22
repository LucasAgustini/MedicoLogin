using MedicoLogin.DAO;
using MedicoLogin.Models;
using MedicoLogin.Util;
using MedicoLogin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace MedicoLogin.Controllers
{
    public class AutenticacaoController : Controller
    {
      
        private EFContext db = new EFContext();
        // GET: Autenticacao
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastroUsuarioViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            if (db.Usuarios.Count(u => u.Login == viewModel.Login) > 0)
            {
                ModelState.AddModelError("Login", "Este login já está em uso");
                return View(viewModel);
            }

            Usuario novoUsuario = new Usuario
            {
                Nome = viewModel.Nome,
                Login = viewModel.Login,
                Senha = Hash.GerarHash(viewModel.Senha)
                //Senha = viewModel.Senha
            };
            db.Usuarios.Add(novoUsuario);
            db.SaveChanges();
            TempData["Mensagem"] = "Cadastro realizado com sucesso";

            //return RedirectToAction("Index", "Home");
            return View();

        }

        public ActionResult Login(string ReturnUrl)
        {
            var viewmodel = new LoginViewModel
            {
                UrlRetorno = ReturnUrl
            };
            return View(viewmodel);
        }



        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel) // string ReturnUrl
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var usuario = db.Usuarios.FirstOrDefault(u => u.Login == viewModel.Login);

            if (usuario == null)
            {
                ModelState.AddModelError("Login", "Falha no Login");
                return View(viewModel);
            }
            if (usuario.Senha != Hash.GerarHash(viewModel.Senha))
            {
                ModelState.AddModelError("Senha", "Senha incorreta");
                return View(viewModel);
            }

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim("Login", usuario.Login)

            }, "ApplicationCookie");

            Request.GetOwinContext().Authentication.SignIn(identity);

            if (!String.IsNullOrWhiteSpace(viewModel.UrlRetorno) || Url.IsLocalUrl(viewModel.UrlRetorno))
            {
                return Redirect(viewModel.UrlRetorno);
            }
            else
            {
                return RedirectToAction("Index", "Painel");
            }

            //var viewmodel = new LoginViewModel
            //{
            //    UrlRetorno = ReturnUrl
            //};
            //return View(viewmodel);
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }

    }
}
