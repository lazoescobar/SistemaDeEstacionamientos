using SistemaDeEstacionamientos.Models;
using SistemaDeEstacionamientos.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeEstacionamientos.Controllers
{
    public class BoletaController : Controller
    {
        TablaBoleta tablBole = new TablaBoleta();

        // GET: Boleta

        [Authorize]
        public ActionResult Index(string idIngreso, string total)
        {
            Ingreso ingres = new Ingreso();
            Salida salid = new Salida();

            if (idIngreso != null)
            {
                ingres.idIngreso = Convert.ToInt32(idIngreso);

                ingres = tablBole.obtenerIngreso(ingres);

                ingres.idIngreso = Convert.ToInt32(idIngreso);

                salid = tablBole.obtenerSalida(ingres);

                ViewBag.patente = ingres.vehiculo.patente;
                ViewBag.fechaEntrada = ingres.fechaEntrada.ToShortDateString();
                ViewBag.horaEntrada = ingres.horaEntrada;
                ViewBag.idSalida = salid.idsalida;
                ViewBag.fechaSalida = salid.fechaSalida.ToShortDateString();
                ViewBag.horaSalida = salid.horaSalida;
            }

            if(total != null)
            {
                ViewBag.Mensaje = "Registrada Boleta con exito, Total a Pagar $ " + total;
                
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Cobrar(string idSalida, string horaEntrada, string horaSalida)
        {
            CalcularTiempo calcuTiemp = new CalcularTiempo(horaEntrada, horaSalida);

            string Monto = calcuTiemp.obtenerTotalAPagar();

            Salida salid = new Salida(Convert.ToInt32(idSalida));

            Boleta bolet = new Boleta(salid, Monto);
            
            if(tablBole.registrar(bolet) == true)
            {
                return RedirectToAction("Index", new { total = Monto });
            }

            return View();
        }
    }
}