using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeEstacionamientos.Models.Entidades
{
    public class Aparcamiento
    {

        private int Id_Aparcamiento;
        private DateTime FechaEntrada;
        private DateTime HoraEntrada;
        private DateTime FechaSalida;
        private DateTime HoraSalida;
        private Vehiculo vehicu;

        public Aparcamiento(Vehiculo vehiculo) {

            this.vehicu = vehiculo;
        }

        
    }
}