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


        public Vehiculo(string patente, string marca, string modelo )
        {
            this.Patente = patente;
            this.Marca = marca;
            this.Modelo = modelo;
        }

        public string patente
        {
            get { return this.Patente.Trim().ToUpper(); }

            set { this.Patente = value; }
        }

        public string modelo
        {
            get { return this.Modelo.Trim().ToUpper(); }

            set { this.Modelo = value; }
        }

        public string marca
        {
            get { return this.Marca.Trim().ToUpper(); }

            set { this.Marca = value; }
        }
    }
}