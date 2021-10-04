using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        
        string chasis;
        ConsoleColor color;
        EMarca marca;
      
        /// <summary>
        /// Constructor base que luego es sobrecargado en las clases herederas
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }

        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        
        /// <summary>
        /// ReadOnly: Retornará el tamaño definido por la clase hija
        /// </summary>
        protected abstract ETamanio Tamanio { get; }
        
        /// <summary>
        /// Publica todos los datos del Vehiculo
        /// </summary>
        /// <returns>El objeto vehiculo convertido expliciamente en valor string</returns>
        public string Mostrar()
        {
            return (string)this;
        }

        

        /// <summary>
        /// Al convertir explicitamente al objeto Vehiculo en string, este contiene toda la informacion sobre este
        /// </summary>
        /// <param name="p">El objeto vehiculo que se convierte</param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendFormat("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }

        /// <summary>
        /// Metodo Equals sobreescrito para evitar un warning del compilador
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this == (Vehiculo)obj;
        }

        /// <summary>
        /// Metodo GetHashCode Sobreescrito para evitar un warning del compilador
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }
}
