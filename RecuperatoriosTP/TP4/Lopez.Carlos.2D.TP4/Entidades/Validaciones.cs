using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades
{
    /// <summary>
    /// Clase estatica que habilita métodos para realizar validaciones de ingreso de datos. Hace uso de excepciones de tipo ImputException. (Tema Manejo de Errores)
    /// </summary>
    public static class Validaciones
    {
        public static ImputException ex = null;
        /// <summary>
        ///  Método que valida que el dato ingresado por el usuario en un caampo definido como cantidad no sea nulo ni este compuesto solo por espacios y NO contenga letras
        /// </summary>
        /// <param name="cantidadIngresada">string que representa la cantidad ingresada</param>
        public static void validarEntradaCantidad(string cantidadIngresada)
        {
            int.TryParse(cantidadIngresada, out int auxcantidad);
            if (String.IsNullOrWhiteSpace(cantidadIngresada))
            {
                throw ex = new ImputException("Debe ingresar una cantidad mayor a cero");
            }
            else
            {
                for (int i = 0; i < cantidadIngresada.Length; i++)
                {
                    if (Char.IsLetter(cantidadIngresada[i]))
                    {
                        throw ex = new ImputException("Debe ingresar una cantidad valida");
                    }
                }
            }

            if (auxcantidad <= 0)
            {
                throw ex = new ImputException("Debe ingresar una cantidad mayor a cero");
            }
        }

        /// <summary>
        /// Metodo que valida que un nombre de articulo ingresado no sea nulo o solo espacios
        /// </summary>
        /// <param name="NombreIngresado"></param>
        public static void validarEntradaNombreArticulo(string NombreIngresado)
        {
            if (String.IsNullOrWhiteSpace(NombreIngresado))
            {
                throw ex = new ImputException("Verifique los datos ingresados");
            }
        }

        /// <summary>
        /// Método que valida que el dato ingresado por el usuario en un campo definido como precio no sea nulo, no este compuesto solo por espacios y NO contenga letras
        /// </summary>
        /// <param name="PrecioIngresado">string que representa el precio ingresado por el usuario</param>
        public static void validarEntradaPrecio(string PrecioIngresado)
        {
            float.TryParse(PrecioIngresado, out float auxprecio);
            if (String.IsNullOrWhiteSpace(PrecioIngresado))
            {
                throw ex = new ImputException("Verifique los datos ingresados");
            }
            else
            {
                for (int i = 0; i < PrecioIngresado.Length; i++)
                {
                    if (Char.IsLetter(PrecioIngresado[i]))
                    {
                        throw ex = new ImputException("Debe ingresar un precio valido");
                    }
                }
            }

            if (auxprecio <= 0)
            {
                throw ex = new ImputException("El precio no puede ser igual a cero");
            }
        }
    }
}
