using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeEstacionamientos.Models.Entidades
{
    public class Boleta
    {
        private int idBoleta;
        private Ingreso ingre;
        private Salida sali;
        private int totalAPagar;

        public Boleta() { }
    }
}