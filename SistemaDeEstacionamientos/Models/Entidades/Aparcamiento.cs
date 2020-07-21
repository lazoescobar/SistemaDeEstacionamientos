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
        private TimeSpan HoraEntrada;
        private DateTime FechaSalida;
        private DateTime HoraSalida;
        private Vehiculo vehicu;

        public Aparcamiento() { }

        public Aparcamiento(DateTime fechaEntrada, TimeSpan horaEntrada)
        {
            this.FechaEntrada = fechaEntrada;
            this.HoraEntrada = horaEntrada;
        }


        public DateTime fechaEntrada
        {
            get { return this.FechaEntrada; }

            set { this.FechaEntrada = value; }        
        }

        public TimeSpan horaEntrada
        {
            get { return this.HoraEntrada; }

            set { this.HoraEntrada = value; }
        }

        public DateTime fechaSalida
        {
            get { return this.FechaSalida; }

            set { this.FechaSalida = value; }
        }

        public DateTime horaSalida
        {
            get { return this.HoraSalida; }

            set { this.HoraSalida = value; }
        }

        public Vehiculo vehiculo
        {
            get { return this.vehicu; }

            set { this.vehicu = value; }
        }
    }
}