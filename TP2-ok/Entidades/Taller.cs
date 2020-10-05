using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Taller
    {
        #region Atributos
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;
        #endregion
        #region Enumerado
        /// <summary>
        /// Enumerado para Tipo de vehículo
        /// </summary>
        public enum ETipo
        {
            Ciclomotor, Sedan, SUV, Todos
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor del tipo de dato tipo Taller. Instacia una lista de Vehículos. 
        /// </summary>
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        public Taller(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del método ToString para devolver los datos del objeto
        /// </summary>
        /// <returns>Devuelve un objeto de tipo string</returns>
        public override string ToString()
        {
            return Listar(this, ETipo.Todos);
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>Devuelve un objeto de tipo string con los datos de la lista</returns>
        public static string Listar(Taller t, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", t.vehiculos.Count, t.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in t.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.SUV:
                        if (v is Suv)
                        {
                            sb.AppendLine(v.Mostrar());

                        }
                        break;
                    case ETipo.Ciclomotor:
                        if (v is Ciclomotor)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Sedan:
                        if (v is Sedan)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns>Retorna un objeto de tipo taller</returns>
        public static Taller operator +(Taller t, Vehiculo vehiculo)
        {

            if (t.vehiculos.Count < t.espacioDisponible)
            {
                foreach (Vehiculo v in t.vehiculos)
                {
                    if (v == vehiculo)
                        return t;
                }

                t.vehiculos.Add(vehiculo);
                return t;
            }
            return t;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Taller operator -(Taller t, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in t.vehiculos)
            {
                if (v == vehiculo)
                {
                    t.vehiculos.Remove(v);
                    return t;
                }
            }

            return t;
        }
        #endregion
    }
}
