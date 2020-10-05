using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Vehiculo
    {

        #region Enumerado
        /// <summary>
        /// Enumerado para Marca
        /// </summary>
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        /// <summary>
        /// Enumerado para Tamaño del vehículo
        /// </summary>
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        protected EMarca marca;
        protected string chasis;
        protected ConsoleColor color;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor con parámetros de la clase Vehículo
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        protected Vehiculo(EMarca marca, string chasis, ConsoleColor color)
        {
            this.marca = marca;
            this.chasis = chasis;
            this.color = color;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de solo lectura que vuelve el tamaño del vehículo
        /// </summary>
        public abstract ETamanio Tamanio { get; }
        #endregion

        #region Metodos
        /// <summary>
        /// Método que publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns>Devuelve un string con los datos de los atributos del vehiculos</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion

        #region Sobrecarga de OPeradores
        /// <summary>
        /// Sobrecarga explicita del tipo string. 
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CHASIS: {p.chasis}");
            sb.AppendLine($"MARCA : {p.marca.ToString()}");
            sb.AppendLine($"COLOR : {p.color.ToString()}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del operador == para validar si dos objetos son iguales a partir del atributo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }

        /// <summary>
        /// Sobrecarga del operador != para validar si dos objetos son iguales a partir del atributo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        #endregion
    }
}
