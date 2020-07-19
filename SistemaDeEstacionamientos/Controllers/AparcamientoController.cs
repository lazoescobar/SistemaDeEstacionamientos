using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeEstacionamientos.Controllers
{
    public class AparcamientoController : Controller
    {
        // GET: Aparcamiento

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Registrar() 
        {

            return View();
        }
    }
}