using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeEstacionamientos.Models.Entidades
{
    public class Ingreso
    {
        private int IdIngreso;
        private DateTime FechaEntrada;
        private TimeSpan HoraEntrada;
        private string Estado;
        private Vehiculo vehicu;

        public Ingreso() { }

        public Ingreso(int idIngreso)
        {
            this.IdIngreso = idIngreso;
        }

        public Ingreso(DateTime fechaEntrada, TimeSpan horaEntrada, Vehiculo vehiculo)
        {
            this.FechaEntrada = fechaEntrada;
            this.HoraEntrada = horaEntrada;
            this.vehicu = vehiculo;
        }

        public int idIngreso
        {
            get { return this.IdIngreso; }

            set { this.IdIngreso = value; }
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

        public string estado
        {
            get { return this.Estado.Trim().ToUpper(); }

            set { this.Estado = value; }
        }

        public Vehiculo vehiculo
        {
            get { return this.vehicu; }

            set { this.vehicu = value; }
        }
    }
}