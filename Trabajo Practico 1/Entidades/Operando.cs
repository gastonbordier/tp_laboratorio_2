using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// Propiedad de la clase que utiliza el metodo validad numero para 
        /// establecer el atributo privado numero.
        /// </summary>
        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }

        }
        /// <summary>
        /// Constructor que no toma parametros. Establece el atributo privado tipo 
        /// double en 0.
        /// </summary>
        public Operando()
        {
            this.numero = 0;
        }
        
        
        /// <summary>
        /// Constructor que toma dato tipo double para establecer el atributo privado 
        /// numero de manera directa.
        /// </summary>
        /// <param name="numero">dato tipo double</param>
        public Operando(double numero)
        {
            this.numero = numero;
        }



        /// <summary>
        /// Constructor que toma un dato de tipo string y lo envia a la propiedad setNumero.
        /// </summary>
        /// <param name="strNumero">dato tipo string</param>
        public Operando(string strNumero)
        {
            Numero = strNumero;
        }


        /// <summary>
        /// Sobrecarga del operador de division "+" para que dos objetos numeros se sumen 
        /// entre si como numeros reales
        /// </summary>
        /// <param name="n1">El primer sumando de la suma </param>
        /// <param name="n2"> el segundo sumando de la suma.</param>
        /// <returns>dato tipo double resultado</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }


        /// <summary>
        /// Sobrecarga del operador de division "-" para que dos objetos numeros se resten 
        /// entre si como numeros reales
        /// </summary>
        /// <param name="n1">El minuendo de la resta</param>
        /// <param name="n2"> el sustraendo de la resta.</param>
        /// <returns>dato tipo double resultado</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }


        /// <summary>
        /// Sobrecarga del operador de multiplicacion "*" para que dos objetos numeros se 
        /// multipliquen entre si como numeros reales
        /// </summary>
        /// <param name="n1">El primer factor del producto</param>
        /// <param name="n2"> el segundo factor del producto</param>
        /// <returns>dato tipo double resultado</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        
        
        /// <summary>
        /// Sobrecarga del operador de division "/" para que dos objetos numeros se dividan 
        /// entre si como numeros reales
        /// </summary>
        /// <param name="n1">El numero dividendo de la division</param>
        /// <param name="n2"> el divisor de la division. Si es cero, la operacion 
        /// devuelve double.MinValue</param>
        /// <returns>dato tipo double resultado</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero != 0)
            {
                return n1.numero / n2.numero;

            }
            else
            {
                return double.MinValue;
            }

        }


        /// <summary>
        /// Convierte un numero decimal a binario. En caso de que no sea posible de 
        /// convertir devuelve la cadena "Valor invalido"
        /// </summary>
        /// <param name="numero">dato tipo string</param>
        /// <returns>retorna un dato tipo string</returns>
        public string DecimalBinario(string numero)
        {
            double numeroDecimal;

            if (Double.TryParse(numero, out numeroDecimal))
            {
                return DecimalBinario(Double.Parse(numero));

            }
            else
            {
                return "Valor Invalido";
            }

        }
        /// <summary>
        /// Convierte un numero binario a decimal
        /// </summary>
        /// <param name="numero">tipo de dato double</param>
        /// <returns>Variable de tipo string con el numero binario conseguido</returns>
        public string DecimalBinario(double numero)
        {
            string numeroBinario = "";
            int numeroADividir = Math.Abs((int)numero);

            List<double> list = new List<double>();

            while (numeroADividir != 1)
            {
                list.Add(numeroADividir % 2);
                numeroADividir = numeroADividir / 2 - (numeroADividir % 2) / 2;

                if (numeroADividir == 1)
                {
                    list.Add(numeroADividir);
                }
            }
            for (int i = list.Count - 1; i >= 0; i--)
            {
                numeroBinario = numeroBinario + list[i].ToString();
            }
            return numeroBinario;
        }
        
        
        /// <summary>
        /// Informa si el dato aportado es un conjunto de numeros factible de analizar 
        /// como binario
        /// </summary>
        /// <param name="binario">tipo string</param>
        /// <returns>dato tipo bool</returns>
        public bool EsBinario(string binario)
        {
            bool retorno = true;


            for (int i = 0; i < binario.Length; i++)
            {
                Console.WriteLine(binario[i]);


                if (binario[i] != '0' && binario[i] != '1')
                {
                    retorno = false;
                    break;
                }
            }

            return retorno;
        }

       
        /// <summary>
        /// Toma dato de tipo string que contenga un numero binario y devuelve un decimal
        /// </summary>
        /// <param name="binario">tipo string</param>
        /// <returns>numero decimal de tipo string</returns>
        public string BinarioDecimal(string binario)
        {





            if (EsBinario(binario))
            {
                int numeroDecimal = 0;

                for (int i = 0; i < binario.Length; i++)
                {
                    int digito = int.Parse(binario[i].ToString());
                    numeroDecimal += (int)(digito * Math.Pow(2, binario.Length - i - 1));
                }
                return numeroDecimal.ToString();
            }
            else
            {
                return "Valor Invalido";
            }
        }
       
        
        /// <summary>
        /// Valida que un string sea nulo para convetirlo en tipo double. En caso que sea
        /// imposible, retorna 0(cero).
        /// </summary>
        /// <param name="strNumero">string que proviene de la propiedad SetNumero</param>
        /// <returns></returns>
        public double ValidarOperando(string strNumero)
        {
            double resultado = 0;
           
            double.TryParse(strNumero, out resultado);


            return resultado;

        }


    }
}
