using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeEstacionamientos.Models.Entidades
{
    public class Salida
    {

        private int idSalida;
        private DateTime FechaSalida;
        private TimeSpan HoraSalida;
        private Ingreso ingres;

        public Salida() { }

        public Salida(DateTime fechaSalida, TimeSpan horaSalida, Ingreso ingreso)
        {
            this.FechaSalida = fechaSalida;
            this.HoraSalida = horaSalida;
            this.ingres = ingreso;
        }

        public DateTime fechaSalida
        {
            get { return this.FechaSalida; }

            set { this.FechaSalida = value; }
        }

        public TimeSpan horaSalida
        {
            get { return this.HoraSalida; }

            set { this.HoraSalida = value; }
        }

        public Ingreso ingreso
        {
            get { return this.ingres; }

            set { this.ingres = value; }
        }
    }
}