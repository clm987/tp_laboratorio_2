using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tienda
    {
        #region Atributos y propiedades
        int idTienda;
        string nombre;
        string direccion;
        string telefono;

        public int IdTienda
        {
            get { return this.idTienda; }
            set { this.idTienda = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public string Direccion
        {
            get { return this.direccion; }
            set { this.direccion = value; }
        }
        public string Telefono
        {
            get { return this.telefono; }
            set { this.telefono = value; }
        }
        #endregion

        #region Constructor

        public Tienda(int idTienda, string nombre, string direccion, string telefono)
        {
            this.IdTienda = idTienda;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
        }
        #endregion

        #region Metodo
        /// <summary>
        /// Metodo que permite mostrar como mediante un string los datos de un Objeto de tipo Tienda
        /// </summary>
        /// <returns>String que representa los datos del objeto de tipo Tienda</returns>
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Id de Tienda: {IdTienda.ToString()}");
            sb.AppendLine($"Nombre de tienda {Nombre.ToString()}");
            sb.AppendLine($"Direccion: {Direccion.ToString()}");
            sb.AppendLine($"Telefono: {Telefono.ToString()}");

            return sb.ToString();
        }
        #endregion

    }
}
