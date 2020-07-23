using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeEstacionamientos.Controllers
{
    public class CalcularTiempo
    {
        private string HoraEntrada;
        private string HoraSalida;
        private readonly int valorMinuto = 20;

        ArrayList arrayingreso = new ArrayList();
        ArrayList arraysalida = new ArrayList();

        public CalcularTiempo(string horaEntrada, string horaSalida)
        {
            this.HoraEntrada = horaEntrada;
            this.HoraSalida = horaSalida;
        }

        private ArrayList obtenerHoraYminutos(string horaBD)
        {
            ArrayList arrayTiempo = new ArrayList();

            string hora = horaBD.Substring(0, 2);
            string minutos = horaBD.Substring(2, 3);

            if (minutos.Substring(0, 1) == ":")
            {
                minutos = minutos.Substring(1, minutos.Length - 1);
            }

            int HORA = Convert.ToInt32(hora);
            int MINUTOS = Convert.ToInt32(minutos);

            arrayTiempo.Add(HORA);
            arrayTiempo.Add(MINUTOS);

            return arrayTiempo;
        }

        private int calcularTiempo()
        {
            arrayingreso = obtenerHoraYminutos(HoraEntrada);
            arraysalida = obtenerHoraYminutos(HoraSalida);

            int horaIngreso = Convert.ToInt32(arrayingreso[0]);
            int minutoIngreso = Convert.ToInt32(arrayingreso[1]);

            int horasalida = Convert.ToInt32(arraysalida[0]);
            int minutosalida = Convert.ToInt32(arraysalida[1]);

            int totalMinutosEstacionado = 0;

            int diferenciahoras = horasalida - horaIngreso;

            int diferenciaminutos = minutosalida - minutoIngreso;

            while (!(diferenciahoras == 0))
            {
                totalMinutosEstacionado += 60; //por cada hora le agrego 60 minutos

                diferenciahoras--;
            }

            if (diferenciaminutos < 0)
            {
                totalMinutosEstacionado = totalMinutosEstacionado + diferenciaminutos;
            }
            else
            {
                totalMinutosEstacionado = totalMinutosEstacionado + diferenciaminutos;
            }

            return totalMinutosEstacionado;
        }


        public string obtenerTotalAPagar()
        {
            int valorApagar = 0;
            int Minutosestacionados = this.calcularTiempo();

            if (Minutosestacionados < 20)
            {
                valorApagar = 400;
            }
            else
            {
                valorApagar = Minutosestacionados * this.valorMinuto;
            }

            string TOTAL = this.montoFormatoChileno(valorApagar);

            return TOTAL;
        }


        private string montoFormatoChileno(int montoTotal)
        {
            string saldo = montoTotal.ToString();
            String saldoConSeparadorDeMiles = "";
            String saldoEnFormtatoChileno = "";

            int subIndice = 1;
            int cont = 0;

            //invertir cadena
            for (int i = saldo.Length - 1; i >= 0; i--)
            {
                saldoConSeparadorDeMiles += saldo.Substring(i, subIndice);

                cont++;

                if (cont == 3)
                {
                    saldoConSeparadorDeMiles += ".";
                    cont = 0;
                }
            }

            for (int i = saldoConSeparadorDeMiles.Length - 1; i >= 0; i--)
            {
                saldoEnFormtatoChileno += saldoConSeparadorDeMiles.Substring(i, subIndice);
            }

            if (saldoEnFormtatoChileno.Substring(0, 1) == ".")
            {
                saldoEnFormtatoChileno = saldoEnFormtatoChileno.Substring(1, saldoEnFormtatoChileno.Length - 1);
            }

            return saldoEnFormtatoChileno;
        }
    }
}