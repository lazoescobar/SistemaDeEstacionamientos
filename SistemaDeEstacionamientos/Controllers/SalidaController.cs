using SistemaDeEstacionamientos.Models;
using SistemaDeEstacionamientos.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeEstacionamientos.Controllers
{
    public class SalidaController : Controller
    {
        private Vehiculo vehic;
        private Ingreso ingres;
        private Salida salid;

        private TablaVehiculo tablVehic = new TablaVehiculo();
        private TablaIngreso tablIngre = new TablaIngreso();
        private TablaSalida tablSali = new TablaSalida();

        // GET: Salida
        [Authorize]
        public ActionResult Index(string patente)
        {
            if(patente != null)
            {
                this.vehic = new Vehiculo(patente);
                Ingreso ingres = new Ingreso();

                ingres = tablIngre.seleccionarIngresoPorPatente(vehic);

                ViewBag.encontrado = "encontado";
                ViewBag.idIngreso = ingres.idIngreso;
                ViewBag.fechaEntrada = ingres.fechaEntrada.ToShortDateString();
                ViewBag.horaEntrada = ingres.horaEntrada;
                ViewBag.estado = ingres.estado;
                ViewBag.patenteVehiculo = ingres.vehiculo.patente;

                ViewBag.fechaActual = this.obtenerFechaActual();
                ViewBag.horaActual = this.obtenerHoraActual();
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult IngresoPorPatente(string patente)
        {
            this.vehic = new Vehiculo(patente);

            if (tablVehic.leerPorPatente(vehic) == true)
            {
                if (tablIngre.estaEstacionado(vehic) == true)
                {
                    
                    return RedirectToAction("Index" ,new { patente = vehic.patente });
                }
                else
                {
                    ViewBag.Mensaje = "Vehiculo PATENTE : " + vehic.patente + " no se encuentra en el estaciomiento";
                }
            }
            else
            {
                ViewBag.Mensaje = "Vehiculo PATENTE : " + vehic.patente + " no se encuentra registrado, por favor registrelo";
            }

            return View("Index");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Salida(DateTime fechaSalida, TimeSpan horaSalida, string idIngresoo)
        {
            this.ingres = new Ingreso(Convert.ToInt32(idIngresoo));
            this.ingres.estado = "RETIRADO";

            this.salid = new Salida(fechaSalida, horaSalida, ingres);
           
            if(tablSali.salida(salid) == true) // se registra la salida en la BD
            {             
                if(tablIngre.actualizarEstado(ingres) == true)
                {
                    return RedirectToAction("Index", "Boleta", new { idIngreso = ingres.idIngreso  });

                }
                else
                {
                    return RedirectToAction("Index");
                }
              
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        private string obtenerFechaActual()
        {
            var fecha = DateTime.Now.Date.Date.ToShortDateString();

            return fecha;
        }

        private string obtenerHoraActual()
        {
            var hora = DateTime.Now.ToShortTimeString();

            return hora;
        }
    }
}