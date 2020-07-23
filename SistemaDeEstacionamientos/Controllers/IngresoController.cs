using SistemaDeEstacionamientos.Models;
using SistemaDeEstacionamientos.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeEstacionamientos.Controllers
{
    public class IngresoController : Controller
    {
        private Vehiculo vehic;
        private Ingreso ingres;

        private TablaVehiculo tablVehic = new TablaVehiculo();
        private TablaIngreso tablIngre = new TablaIngreso();

        // GET: Aparcamiento

        [Authorize]
        public ActionResult Index()
        {

            ViewBag.totalEstacionados = tablIngre.cantidadEstacionados();
            ViewBag.fechaActual = this.obtenerFechaActual();
            ViewBag.horaActual = this.obtenerHoraActual();

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Ingreso(DateTime fechaEntrada, TimeSpan horaEntrada, string patente) 
        {
            this.vehic = new Vehiculo(patente);
            this.ingres = new Ingreso(fechaEntrada, horaEntrada, vehic);
            this.ingres.estado = "ESTACIONADO"; //se asigan por defecto 'estacionado'

            if (tablVehic.leerPorPatente(vehic) == true) // el auto existe en la BD
            {
                if (tablIngre.estaEstacionado(vehic) == false) // el auto no esta estacionado
                {
                    if (tablIngre.ingreso(ingres) == true) //lo registra en la BD
                    {

                        ViewBag.totalEstacionados = tablIngre.cantidadEstacionados();
                        ViewBag.Mensaje = "ingresado con exito";
                        ViewBag.fechaActual = this.obtenerFechaActual();
                        ViewBag.horaActual = this.obtenerHoraActual();                        
                    }
                    else
                    {
                        ViewBag.totalEstacionados = tablIngre.cantidadEstacionados();
                        ViewBag.Mensaje = "Error en el registro";
                        ViewBag.fechaActual = this.obtenerFechaActual();
                        ViewBag.horaActual = this.obtenerHoraActual();
                    }
                }
                else
                {
                    ViewBag.totalEstacionados = tablIngre.cantidadEstacionados();
                    ViewBag.Mensaje = "Vehiculo PATENTE : " + vehic.patente + " se encuentra en el estaciomiento";
                    ViewBag.patente = vehic.patente;
                    ViewBag.fechaActual = this.obtenerFechaActual();
                    ViewBag.horaActual = this.obtenerHoraActual();
                }
            }
            else
            {
                ViewBag.totalEstacionados = tablIngre.cantidadEstacionados();
                ViewBag.Alerta = "Vehiculo PATENTE : " + vehic.patente + " no se encuentra registrado, por favor registrelo";
                
                return RedirectToAction("Registrar", "Vehiculo" ,new { patente = vehic.patente });
                
            }
            return View("Index");
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