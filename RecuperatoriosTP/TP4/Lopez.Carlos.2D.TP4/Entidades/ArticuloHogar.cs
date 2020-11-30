using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ArticuloHogar : Articulo
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
        /// Override que permite devolver el tipo de articulo correspondiente a la clase
        /// </summary>
        public override ETipoDeArticulo TipoDeArticulo
        {
            get { return Articulo.ETipoDeArticulo.Hogar; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de objetos de tipo ArticuloHogar
        /// </summary>
        /// <param name="nombre">String que representa el nombre del articulo</param>
        /// <param name="precioUnitario">float que representa el precio unitario del articulo</param>
        /// <param name="cantidad">int que representa el stock que existe del articulo</param>
        /// <param name="IdArticuloHogar">int que representa el id unico de un articulo</param>
        public ArticuloHogar(string nombre, float precioUnitario, int cantidad, int IdArticuloHogar) : base(nombre, precioUnitario, cantidad, IdArticuloHogar)
        {

        }

        #endregion

        #region Métodos
        /// <summary>
        /// Método que muestra las propiedades de un objeto de tipo ArticuloHogar
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
