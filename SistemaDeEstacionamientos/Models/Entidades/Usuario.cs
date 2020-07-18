using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeEstacionamientos.Models.Entidades
{
    public class Usuario
    {
        private int IdUsuario;
        private string Nombre;
        private string NombreUsuario;
        private string Contrasenia;

        public Usuario(string nombreUsuario, string contrasenia)
        {
            this.NombreUsuario = nombreUsuario;
            this.Contrasenia = contrasenia;
        }

        public int idUsuario
        {
            get { return this.IdUsuario; }

            set { this.IdUsuario = value;  }
        }

        public string nombre
        {
            get { return this.Nombre;  }

            set { this.Nombre = value;  }
        }

        public string nombreUsuario
        {
            get { return this.NombreUsuario.Trim().ToUpper(); }

            set { this.NombreUsuario = value; }
        }

        public string contrasenia
        {
            get { return this.Contrasenia.Trim().ToUpper(); }

            set { this.Contrasenia = value;  }
        }
    }
}