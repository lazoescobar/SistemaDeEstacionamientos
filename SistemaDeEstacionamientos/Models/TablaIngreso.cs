using SistemaDeEstacionamientos.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeEstacionamientos.Models
{
    public class TablaIngreso
    {

        ESTACIONAMIENTOEntities DB = new ESTACIONAMIENTOEntities();

        public Boolean estaEstacionado(Vehiculo vehiculo)
        {
            Boolean resultado;

            try
            {
                var vehicu = (from ingr in DB.INGRESO
                              where ingr.PATENTE_VEHICULO == vehiculo.patente
                              && ingr.ESTADO == "ESTACIONADO"
                              select ingr).FirstOrDefault();

                if (vehicu != null)
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
            }
            catch (Exception)
            {
                resultado = false;
            }

            return resultado;

        }

        public Ingreso seleccionarIngresoPorPatente(Vehiculo vehiculo)
        {
            Ingreso ingres = new Ingreso();

            try
            {
                var vehicu = (from ingr in DB.INGRESO
                              where ingr.PATENTE_VEHICULO == vehiculo.patente
                              && ingr.ESTADO == "ESTACIONADO"
                              select ingr).FirstOrDefault();

                ingres.idIngreso = Convert.ToInt32(vehicu.ID_INGRESO);
                ingres.fechaEntrada = vehicu.FECHA_ENTRADA;
                ingres.horaEntrada = vehicu.HORA_ENTRADA;
                ingres.estado = vehicu.ESTADO;
                Vehiculo vehi = new Vehiculo(vehicu.PATENTE_VEHICULO);
                ingres.vehiculo = vehi;
            }

            catch (Exception) { }

            return ingres;
        }

        public Boolean ingreso(Ingreso ingreso)
        {
            Boolean resultado;

            var ingresoDB = new INGRESO();

            ingresoDB.FECHA_ENTRADA = ingreso.fechaEntrada;
            ingresoDB.HORA_ENTRADA = ingreso.horaEntrada;
            ingresoDB.ESTADO = ingreso.estado;
            ingresoDB.PATENTE_VEHICULO = ingreso.vehiculo.patente;

            try
            {
                DB.INGRESO.Add(ingresoDB);
                DB.SaveChanges();

                resultado = true;
            }
            catch (Exception)
            {
                resultado = false;
            }

            return resultado;
        }

        public int cantidadEstacionados()
        {
            int total = 0;
            try
            {
                var totalEstacionados = (from ingr in DB.INGRESO
                                         where ingr.ESTADO == "ESTACIONADO"
                                         select ingr).Count();

                total = Convert.ToInt32(totalEstacionados);
            }
            catch (Exception){ }

            return total;
        }

        /*
        public Boolean actualizarEstado(Ingreso ingreso)
        {

        }
        */
    }
}