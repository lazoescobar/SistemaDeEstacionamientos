using SistemaDeEstacionamientos.Models;
using SistemaDeEstacionamientos.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeEstacionamientos.Controllers
{
    public class AparcamientoController : Controller
    {
        private Vehiculo vehic;
        private Aparcamiento aparcam;
        private TablaVehiculo tablVehic;
        private TablaAparcamiento tablAparcam;
        // GET: Aparcamiento

        [Authorize]
        public ActionResult Index()
        {
            var fecha = DateTime.Now.Date.Date.ToShortDateString();
            var hora = DateTime.Now.ToShortTimeString();

            ViewBag.fechaActual = fecha;
            ViewBag.horaActual = hora;

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Registrar(DateTime fechaEntrada, DateTime horaEntrada, string patente) 
        {
            this.vehic = new Vehiculo(patente);
            this.aparcam = new Aparcamiento(fechaEntrada, horaEntrada);

            this.tablVehic = new TablaVehiculo();

            if(tablVehic.leerPorPatente(vehic) == true)
            {
                //
            }


            return View("Index");
        }
    }
}