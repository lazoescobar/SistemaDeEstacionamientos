using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeEstacionamientos.Controllers
{
    public class BoletaController : Controller
    {
        // GET: Boleta
        public ActionResult Index(string correcto, string Incorrecto)
        { 
            if(correcto != null)
            {
                ViewBag.Mensaje = correcto;
            }

            if(Incorrecto != null)
            {
                ViewBag.Mensaje = Incorrecto;
            }
            return View();
        }
    }
}