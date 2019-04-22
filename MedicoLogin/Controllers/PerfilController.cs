using MedicoLogin.DAO;
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
    public class PerfilController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Perfil
        [Authorize]
        public ActionResult AlterarSenha()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AlterarSenha(AlterarSenhaViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var identity = User.Identity as ClaimsIdentity;
            //var login = db.Identity.Claims.FirstOrDefault(u => u.login == login);
            var login = identity.Claims.FirstOrDefault(c => c.Type == "Login").Value; //transforma o tipo do login para LOGIN
            var usuario = db.Usuarios.FirstOrDefault(u => u.Login == login); //recebe o novo tpo e procura n odv

            if (Hash.GerarHash(viewModel.SenhaAtual) != usuario.Senha)
            {
                ModelState.AddModelError("SenhaAtual", "Senha Incorreta");
                return View();
            }

            usuario.Senha = Hash.GerarHash(viewModel.NovaSenha);
            db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "Painel");


        }
    }
}