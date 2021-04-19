using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {

        /// <summary>
        /// Realiza las operaciones matematicas basicas de numeros reales entre dos objetos 
        /// numeros para devolver un double como resultado.
        /// </summary>
        /// <param name="numero1">El primer objeto numero de la operacion.</param>
        /// <param name="numero2">El segundo objeto numero de la operacion.</param>
        /// <param name="operador">El operador que identifica a la operacion a realizar,
        /// antes validado y convertido a '+' en caso de que no responda a ninguna 
        /// operacion permitida.</param>
        /// <returns>El dato de tipo double resultado de la operacion.</returns>
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {

            double resultado = 0;

            operador = ValidarOperador(operador[0]);



            if (operador == "+")
            {
                resultado = numero1 + numero2;
            }
            if (operador == "-")
            {
                resultado = numero1 - numero2;

            }
            if (operador == "*")
            {
                resultado = numero1 * numero2;

            }
            if (operador == "/")
            {
                resultado = numero1 / numero2;

            }

            return resultado;




        }
        
        /// <summary>
        /// Validad que el dato de tipo char sea una de las cuatro operaciones matematicas 
        /// basicas. Si no es una de ellas devuelve el que identifica la operacion suma
        /// </summary>
        /// <param name="operador">dato de tipo char</param>
        /// <returns>retorna un dato de tipo string </returns>
        private static string ValidarOperador(char operador)
        {

            if (operador != '+' && operador != '-' && operador != '*' && operador != '/')
            {
                operador = '+';
            }



            return operador.ToString();
        }

        static void Main( string[ ] args)
        {

        }
    }
}
