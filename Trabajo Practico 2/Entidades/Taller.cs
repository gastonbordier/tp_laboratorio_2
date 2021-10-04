using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public class Taller
    {
        #region "Campos"
        List<Vehiculo> vehiculos;
        int espacioDisponible;
        #endregion

        #region "Enumerados"
        public enum ETipo
        {
            Ciclomotor, Sedan, SUV, Todos
        }
        #endregion

        #region "Constructores"
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        public Taller(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Expone el nivel de ocupacion del taller e informacion sobre todos los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone el nivel de ocupacion del taller y detalle de los vehiculos ingresados
        /// con la posibilidad de filtrar el listado por tipo de vehiculo
        /// </summary>
        /// <param name="taller">Objeto taller del cual extraer la informacion para la lista</param>
        /// <param name="ETipo">Tipo de vehiculo</param>
        /// <returns></returns>
        public string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", taller.vehiculos.Count, taller.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in taller.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Ciclomotor:
                        if (v.GetType().ToString() == typeof(Ciclomotor).ToString())
                        {
                            sb.AppendLine(((Ciclomotor)v).Mostrar());
                        }
                        break;
                    case ETipo.Sedan:
                        if (v.GetType().ToString() == typeof(Sedan).ToString())
                        {
                            sb.AppendLine(((Sedan)v).Mostrar());
                        }
                        break;
                    case ETipo.SUV:
                        if (v.GetType().ToString() == typeof(Suv).ToString())
                        {
                            sb.AppendLine(((Suv)v).Mostrar());
                        }
                        break;
                    default:
                        if (v.GetType().ToString() == typeof(Ciclomotor).ToString())
                        {
                            sb.AppendLine(((Ciclomotor)v).Mostrar());
                        }
                        else if (v.GetType().ToString() == typeof(Sedan).ToString())
                        {
                            sb.AppendLine(((Sedan)v).Mostrar());
                        }
                        else if (v.GetType().ToString() == typeof(Suv).ToString())
                        {
                            sb.AppendLine(((Suv)v).Mostrar());
                        }
                        break;




                }




            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Taller al que se intentara agregar el vehiculo</param>
        /// <param name="vehiculo">Vehiculo a agregar</param>
        /// <returns></returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            if (taller.vehiculos.Count < taller.espacioDisponible)
            {

                foreach (Vehiculo v in taller.vehiculos)
                {
                    if (v == vehiculo)
                        return taller;
                }

                taller.vehiculos.Add(vehiculo);
            }

            return taller;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Taller del que se quitara el vehiculo, en caso de que este ingresado</param>
        /// <param name="vehiculo">Vehiculo a quitar</param>
        /// <returns></returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in taller.vehiculos)
            {
                if (v == vehiculo)
                {
                    taller.vehiculos.Remove(v);
                    break;
                }
            }

            return taller;
        }
        #endregion
    }
}
