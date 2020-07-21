using SistemaDeEstacionamientos.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeEstacionamientos.Models
{
    public class TablaAparcamiento
    {

        ESTACIONAMIENTOEntities DB = new ESTACIONAMIENTOEntities();

        public Boolean estaEstacionado(Vehiculo vehiculo)
        {
            Boolean resultado;

            try
            {
                var vehicu = (from apa in DB.APARCAMIENTO
                              where apa.PATENTE_VEHICULO == vehiculo.patente
                              && apa.FECHA_SALIDA == null && apa.HORA_SALIDA == null
                              select apa).FirstOrDefault();

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


        public Boolean ingreso(Aparcamiento aparcamiento)
        {
            Boolean resultado;

            var aparcamientoDB = new APARCAMIENTO();

            aparcamientoDB.FECHA_ENTRADA = aparcamiento.fechaEntrada;
            aparcamientoDB.HORA_ENTRADA = aparcamiento.horaEntrada;
            aparcamientoDB.PATENTE_VEHICULO = aparcamiento.vehiculo.patente;

            try
            {
                DB.APARCAMIENTO.Add(aparcamientoDB);
                DB.SaveChanges();

                resultado = true;
            }
            catch (Exception)
            {
                resultado = false;
            }

            return resultado;

        }


    }
}