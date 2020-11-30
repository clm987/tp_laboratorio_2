using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Articulo
    {
        #region Atributos y propiedades
        protected string nombre;
        protected float precioUnitario;
        protected int cantidad;
        protected int idArticulo;

        public abstract int IdArticulo
        {
            get;
        }

        public abstract string Nombre
        {
            get;
        }

        public abstract float PrecioUnitario
        {
            get;
        }

        public abstract int Cantidad
        {
            set;
            get;
        }

        public abstract ETipoDeArticulo TipoDeArticulo
        {
            get;
        }
        #endregion

        #region Enumerado
        /// <summary>
        /// Enumerado que sirve para definir que tipo de articulo es una instancia particular
        /// </summary>
        public enum ETipoDeArticulo
        {
            Computacion,
            Hogar,
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la clase Articulo
        /// </summary>
        /// <param name="nombre">String que representa el nombre del articulo</param>
        /// <param name="precioUnitario">float que representa el precio unitario del articulo</param>
        /// <param name="cantidad">int que representa el stock que existe del articulo</param>
        /// <param name="idArticulo">int que representa el id unico de un articulo</param>

        public Articulo(string nombre, float precioUnitario, int cantidad, int idArticulo)
        {
            this.nombre = nombre;
            this.precioUnitario = precioUnitario;
            this.cantidad = cantidad;
            this.idArticulo = idArticulo;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método virtual que permite devolver los datos de un Articulo en tipo string
        /// </summary>
        /// <returns>string que contiene los datos del Articulo</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion

        #region Sobrecarga de Tipo
        /// <summary>
        /// Sobrecarga explicita del tipo de dato string sobre los atributos de un objeto de tipo Articulo
        /// </summary>
        /// <param name="unArticulo">Objeto de tipo producto</param>
        public static explicit operator string(Articulo unArticulo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Nombre de articulo: {unArticulo.nombre}");
            sb.AppendLine($"Precio por unidad: {unArticulo.precioUnitario.ToString()}");

            return sb.ToString();
        }
        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// Sobrecarga del operador == para validar si dos Articulo son iguales a partir del atributo Id
        /// </summary>
        /// <param name="listaDeArticulo">Lista de objetos de tipo Articulo</param>
        /// <param name="unArticulo">Objeto de tipo Articulo</param>
        /// <returns></returns>
        public static bool operator ==(List<Articulo> listaDeArticulo, Articulo unArticulo)
        {
            bool retValue = false;

            for (int i = 0; i < listaDeArticulo.Count; i++)
            {
                if (listaDeArticulo[i].IdArticulo == unArticulo.IdArticulo)
                {
                    retValue = true;
                }
            }

            return retValue;
        }

        /// <summary>
        /// Sobrecarga del operador != para validar si dos Articulos NO son iguales a partir del atributo Id
        /// </summary>
        /// <param name="listaDeArticulo">Lista de objetos de tipo Articulo</param>
        /// <param name="unArticulo">Objeto de tipo Articulo </param>
        /// <returns></returns>
        public static bool operator !=(List<Articulo> listaDeArticulo, Articulo unArticulo)
        {
            return !(listaDeArticulo == unArticulo);
        }
        #endregion
    }
}
