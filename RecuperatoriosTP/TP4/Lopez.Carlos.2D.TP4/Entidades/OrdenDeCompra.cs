using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase instanciable que permite levantar las ordenes de compra que se dejan en el archivo Xlm
    /// </summary>
    public class OrdenDeCompra
    {
        #region Atributos y propiedades
        int idtienda;
        int idarticulo;
        int cantidad;
        float montoventa;

        public int IdTienda
        {
            get { return this.idtienda; }
            set { this.idtienda = value; }
        }

        public int IdArticulo
        {
            get { return this.idarticulo; }
            set { this.idarticulo = value; }
        }

        public int Cantidad
        {
            get { return this.cantidad; }
            set { this.cantidad = value; }
        }

        public float Monto
        {
            get { return this.montoventa; }
            set { this.montoventa = value; }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto necesario para realizar la serializacion en xlm 
        /// </summary>
        public OrdenDeCompra()
        {

        }

        /// <summary>
        /// Contructor de objetos de tipo OrdenDeCompra
        /// </summary>
        /// <param name="idTienda">Entero que representa el id de la tienda que hace la orden de compra</param>
        /// <param name="idArticulo">Entero que representa el id del articulo solicitado</param>
        /// <param name="cantidad">Entero que representa la cantidad solicitada del producto</param>
        /// <param name="monto">float que representa el monto de la orden de compra</param>
        public OrdenDeCompra(int idTienda, int idArticulo, int cantidad, float monto)
        {
            IdTienda = idTienda;
            IdArticulo = idArticulo;
            Cantidad = cantidad;
            Monto = monto;
        }
        #endregion

    }
}
