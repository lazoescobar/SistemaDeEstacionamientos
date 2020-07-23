using SistemaDeEstacionamientos.Models.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeEstacionamientos.Models
{
    public class TablaBoleta
    {

        ESTACIONAMIENTOEntities DB = new ESTACIONAMIENTOEntities();

        public Ingreso obtenerIngreso(Ingreso ingreso)
        {
            Ingreso ingres = new Ingreso();

            try
            {
                var obteneringre = (from ing in DB.INGRESO
                                    where ing.ID_INGRESO == ingreso.idIngreso
                                    select ing).FirstOrDefault();

                if (obteneringre != null)
                {
                    Vehiculo vehic = new Vehiculo(obteneringre.PATENTE_VEHICULO);

                    ingres.vehiculo = vehic;
                    ingres.fechaEntrada = obteneringre.FECHA_ENTRADA;
                    ingres.horaEntrada = obteneringre.HORA_ENTRADA;
                }

            }
            catch (Exception) { }

            return ingres;
        }

        public Salida obtenerSalida(Ingreso ingreso)
        {
            Salida salid = new Salida();

            try
            {
                var obtenersalid = (from sal in DB.SALIDA
                                    where sal.ID_INGRESO == ingreso.idIngreso
                                    select sal).FirstOrDefault();

                if (obtenersalid != null)
                {
                    salid.idsalida = obtenersalid.ID_SALIDA;
                    salid.fechaSalida = obtenersalid.FECHA_SALIDA;
                    salid.horaSalida = obtenersalid.HORA_SALIDA;
                }

            }
            catch (Exception) { }

            return salid;
        }

        public Boolean registrar(Boleta boleta)
        {
            Boolean resultado;

            var boletaDB = new BOLETA();

            boletaDB.ID_SALIDA = boleta.salid.idsalida;
            boletaDB.TOTAL_A_PAGAR = boleta.totalApagar;
            try
            {
                DB.BOLETA.Add(boletaDB);
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