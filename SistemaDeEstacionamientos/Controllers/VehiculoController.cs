using SistemaDeEstacionamientos.Models;
using SistemaDeEstacionamientos.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeEstacionamientos.Controllers
{
    public class VehiculoController : Controller
    {
        private Vehiculo vehicul;
        private TablaVehiculo tablVehic;
        // GET: Vehiculo

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

        [Authorize]
        [HttpPost]
        public ActionResult Registrar(string patente, string marca, string modelo)
        {
            this.vehicul = new Vehiculo(patente, marca, modelo);

            this.tablVehic = new TablaVehiculo();

            if(tablVehic.leerPorPatente(vehicul) == false)
            {
                if(tablVehic.registrar(vehicul) == true)
                {
                    ViewBag.Mensaje = "registrado con exito";
                }
                else
                {
                    ViewBag.Mensaje = "Error en el registro";
                }
            }
            else
            {
                ViewBag.Mensaje = "Patente ya esta registrada";

                ViewBag.Patente = patente;
                ViewBag.Marca = marca;
                ViewBag.Modelo = modelo;
            }

            return View();
        }
    }
}