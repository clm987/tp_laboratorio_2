using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ArticuloComputacion : Articulo
    {
        #region Propiedades
        public override string Nombre
        {
            get { return base.nombre; }
        }

        public override float PrecioUnitario
        {
            get { return base.precioUnitario; }
        }

        public override int Cantidad
        {
            get { return base.cantidad; }
            set { this.cantidad = value; }
        }

        public override int IdArticulo
        {
            get { return base.idArticulo; }
        }
        /// <summary>
        /// Sobrecarga de propiedad para asignar el tipo de articulo correspondiente a esta clase
        /// </summary>
        public override ETipoDeArticulo TipoDeArticulo
        {
            get { return Articulo.ETipoDeArticulo.Computacion; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Consturctor de objetos de tipo ArticuloComputacion
        /// </summary>
        /// <param name="nombre">String que representa el nombre del articulo</param>
        /// <param name="precioUnitario">float que representa el precio unitario del articulo</param>
        /// <param name="cantidad">int que representa el stock que existe del articulo</param>
        /// <param name="IdArticuloComputacion">int que representa el id unico de un articulo</param>
        public ArticuloComputacion(string nombre, float precioUnitario, int cantidad, int IdArticuloComputacion) : base(nombre, precioUnitario, cantidad, IdArticuloComputacion)
        {

        }
        #endregion

        #region Métodos
        /// <summary>
        ///  Override del método virtual que permite devolver los datos de un Articulo del tipo ArticuloComputacion
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar());
            sb.AppendLine(IdArticulo.ToString());
            return sb.ToString();
        }
        #endregion
    }
}
