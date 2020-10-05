using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        #region Enumerado
        /// <summary>
        /// Tipo de dato Enum para Tipo de vehículo
        /// </summary>
        public enum ETipo
        { CuatroPuertas, 
          CincoPuertas }
        ETipo tipo;
        #endregion

        #region Constructores
        /// <summary>
        /// Contructor con parámetros heredados de la clase base. Asigna por defecto el tipo como CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : base(marca, chasis, color)
        {
            this.tipo = ETipo.CuatroPuertas;
        }

        /// <summary>
        /// /Sobrecarga del contructor de la clase base que agrega Etipo por parámetro
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipoDeauto"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipoDeauto)
           : base(marca, chasis, color)
        {
            this.tipo = tipoDeauto;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de solo léctura que devuelve el Tamaño del vehículo.
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que muestra el contenido de los atributos de un objeto del tipo Sedán
        /// </summary>
        /// <returns>Retorna un objeto de tipo String Builder </returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO :  {this.Tamanio}");
            sb.AppendLine($"TIPO   :  {this.tipo}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
