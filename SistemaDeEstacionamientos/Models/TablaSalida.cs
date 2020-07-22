using SistemaDeEstacionamientos.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeEstacionamientos.Models
{
    public class TablaSalida
    {
        ESTACIONAMIENTOEntities DB = new ESTACIONAMIENTOEntities();

        public Boolean salida(Salida salida)
        {
            Boolean resultado;

            var salidaDB = new SALIDA();

            salidaDB.FECHA_SALIDA = salida.fechaSalida;
            salidaDB.HORA_SALIDA = salida.horaSalida;
            salidaDB.ID_INGRESO = salida.ingreso.idIngreso;

            try
            {
                DB.SALIDA.Add(salidaDB);
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