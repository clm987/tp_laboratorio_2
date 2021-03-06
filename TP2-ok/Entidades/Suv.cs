﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        #region Constructores
        /// <summary>
        /// Constructor con parámetros de la clase ciclomotor
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
       : base(marca, chasis, color)
        {
        }
        #endregion

        #region Propiedades
        /// <summary>
        ///Propiedad de solo lectura. Retorna un valor de Etamanio
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// /Método que muestra el contenido de los atributos de un objeto del tipo SUV
        /// </summary>
        /// <returns>Retorna un objeto de tipo String Builder </returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO :  {this.Tamanio}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
