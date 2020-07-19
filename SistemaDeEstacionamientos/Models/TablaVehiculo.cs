using SistemaDeEstacionamientos.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeEstacionamientos.Models
{
    public class TablaVehiculo
    {

        ESTACIONAMIENTOEntities DB = new ESTACIONAMIENTOEntities();

        public Boolean leerPorPatente(Vehiculo vehiculo)
        {
            Boolean resultado;

            try
            {
                var vehicu = (from veh in DB.VEHICULO
                              where veh.PATENTE == vehiculo.patente
                              select veh).FirstOrDefault();

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

        public Boolean registrar(Vehiculo vehiculo)
        {
            Boolean resultado;

            var vehiculoDB = new VEHICULO();

            vehiculoDB.PATENTE = vehiculo.patente;
            vehiculoDB.MARCA = vehiculo.marca;
            vehiculoDB.MODELO = vehiculo.modelo;

            try
            {
                DB.VEHICULO.Add(vehiculoDB);
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
