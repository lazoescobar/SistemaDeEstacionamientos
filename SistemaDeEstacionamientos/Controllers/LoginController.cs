using SistemaDeEstacionamientos.Models;
using SistemaDeEstacionamientos.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SistemaDeEstacionamientos.Controllers
{
    public class LoginController : Controller
    {
        private Usuario usuar;
        private TablaUsuario tablUser;

        // GET: Usuario
        public ActionResult Index(string mensaje)
        {
            
            if(mensaje != null)
            {
                ViewBag.mensaje = mensaje;
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(string nombreUsuario, string password)
        {
            this.usuar = new Usuario(nombreUsuario, password);

            this.tablUser = new TablaUsuario();

            if(tablUser.logear(usuar) == true)
            {
                FormsAuthentication.SetAuthCookie(usuar.nombreUsuario, true);

                //return RedirectToAction("Contact", "Home");
                return RedirectToAction("Index", "Aparcamiento");
            }
            else
            {
                return RedirectToAction("Index", new { mensaje = "Usuario o contrasenia incorrecto" });
            }

        }

        public ActionResult Close()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");

        }
    }
}