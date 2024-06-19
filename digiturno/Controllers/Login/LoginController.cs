using digiturno.Data.Usuarios;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace digiturno.Controllers.Login
{
    public class LoginController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(string user,string pass)
        {
            try {
                var usuario = UsuariosData.GetUsuarioPorUsuarioYContrasena(user,pass);
                if (usuario == null)
                {
                    ViewBag.mensaje = "Verifique Usuario y Contraseña";
                }
                else {
                    FormsAuthentication.SetAuthCookie(usuario.Id.ToString(), false);
                    return RedirectToAction("Index","Home");
                }
            }
            catch(Exception) {
                throw;
            }
            return View("Index");
        }
    }
}