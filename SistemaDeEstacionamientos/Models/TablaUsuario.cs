using SistemaDeEstacionamientos.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeEstacionamientos.Models
{
    public class TablaUsuario
    {
        ESTACIONAMIENTOEntities DB = new ESTACIONAMIENTOEntities();

        public Boolean logear(Usuario usuario)
        {
            Boolean resultado ;

            try
            {
                var user = (from us in DB.USUARIO
                            where us.NOMBRE_USUARIO == usuario.nombreUsuario
                            && us.CONTRASENIA == usuario.contrasenia
                            select us).FirstOrDefault();

                if(user != null)
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }

            }catch(InvalidOperationException e)
            {
                resultado = false;
            }

            return resultado;
        }
        
    }
    
}