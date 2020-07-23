using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeEstacionamientos.Models.Entidades
{
    public class Boleta
    {
        private int idBoleta;
        private Salida sali;
        private string totalAPagar;

        public Boleta(Salida salida , string monto)
        {
            this.sali = salida;
            this.totalAPagar = monto;
        }

        public Salida salid
        {
            get { return this.sali; }

            set { this.sali = value; }
        }

        public string totalApagar
        {
            get { return this.totalAPagar; }

            set { this.totalAPagar = value; }
        }
    }
}