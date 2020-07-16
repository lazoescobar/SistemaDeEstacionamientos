using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeEstacionamientos.Models.Entidades
{
    public class Vehiculo
    {
        private string Patente;
        private string Modelo;
        private string Marca;

        public string patente
        {
            get { return this.Patente; }

            set { this.Patente = value; }
        }

        public string modelo
        {
            get { return this.Modelo; }

            set { this.Modelo = value; }
        }

        public string marca
        {
            get { return this.Marca; }

            set { this.Marca = value; }
        }
    }
}