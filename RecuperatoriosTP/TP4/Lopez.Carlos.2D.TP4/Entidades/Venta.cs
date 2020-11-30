using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta
    {
        #region Atributos y propiedades
        int idventa;
        int idtienda;
        int idarticulo;
        int cantidad;
        float montoventa;
        EEstadoVenta estadodelaventa;

        public int IdVenta
        {
            get { return this.idventa; }
            set { this.idventa = value; }
        }

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

        public EEstadoVenta EstadoVenta
        {
            get
            {
                return this.estadodelaventa;
            }
            set
            {
                this.estadodelaventa = value;
            }
        }
        #endregion

        #region Enum
        /// <summary>
        /// Enumerado que establece los estados posibles de una venta "Pendiente" = aun no se concreta la venta, "Conforme" = la venta se ha realizado con exito y "Rechazada" = no fue posible realizar la venta
        /// </summary>
        public enum EEstadoVenta
        {
            Pendiente,
            Conforme,
            Rechazada
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Contructor del Objeto de tipo Venta
        /// </summary>
        /// <param name="idVenta">Entero que representa el Id unico de venta</param>
        /// <param name="idTienda">Entero que representa el Id de la tienda solicitante</param>
        /// <param name="idArticulo">Entero que representa el Id del Articulo solicitado</param>
        /// <param name="cantidad">Entero que representa la cantidad solicitada</param>
        /// <param name="monto">Float que representa el monto de la venta</param>
        /// <param name="estadoVenta">Enumerado que define el estado de la venta</param>
        public Venta(int idVenta, int idTienda, int idArticulo, int cantidad, float monto, EEstadoVenta estadoVenta)
        {
            IdVenta = idVenta;
            IdTienda = idTienda;
            IdArticulo = idArticulo;
            Cantidad = cantidad;
            Monto = monto;
            EstadoVenta = estadoVenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que permite mostrar como un string los atributos de una instancia de objeto de tipo Venta
        /// </summary>
        /// <param name="unaVenta">Objeto de tipo venta</param>
        /// <returns>Devuelve un string que representa los atributos del objeto de tipo Venta</returns>
        public string Mostrar(Venta unaVenta)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"IdVenta: {unaVenta.IdVenta}");
            sb.AppendLine($"IdTienda: {unaVenta.IdTienda}");
            sb.AppendLine($"IdArticulo: {unaVenta.IdArticulo}");
            sb.AppendLine($"Cantidad: {unaVenta.Cantidad}");
            sb.AppendLine($"Monto: {unaVenta.Monto}");

            return sb.ToString();
        }
        #endregion
    }
}
