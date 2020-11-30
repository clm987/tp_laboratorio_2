using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    /// <summary>
    /// Clase estatica que maneja las consultas a la base de datos Distribuidora (Tema Base de datos y SQL)
    /// </summary>
    public static class HelperBD
    {
        #region Atributos y Constantes
        /// <summary>
        /// Define el objeto conexión que utilizará en las consultas
        /// </summary>
        private static SqlConnection sqlconexion;
        /// <summary>
        /// Define el objeto SqlCommand que será usado para ejecutar las consultas
        /// </summary>
        private static SqlCommand sqlcomando;
        /// <summary>
        /// Define la dirección de conexión con la base datos
        /// </summary>
        const string STRINGCONNEC = "Data Source=.\\sqlexpress; Initial Catalog=Distribuidora; Integrated Security=True;";
        #endregion

        #region Constructor Estático
        static HelperBD()
        {
            sqlconexion = new SqlConnection();
            sqlconexion.ConnectionString = STRINGCONNEC;
            sqlcomando = new SqlCommand();
            sqlcomando.Connection = sqlconexion;
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Método que consulta la tabla Tienda y devuelve una lista de las tiendas
        /// </summary>
        /// <returns>Lista de objetos de tipo Tienda</returns>
        public static List<Tienda> TraerTiendas()
        {
            List<Tienda> listaTiendas = new List<Tienda>();
            string consulta = " Select * from Tienda ";

            try
            {
                sqlcomando.CommandText = consulta;
                sqlconexion.Open();
                SqlDataReader dr = sqlcomando.ExecuteReader();

                while (dr.Read())
                {
                    listaTiendas.Add(new Tienda(int.Parse(dr["Id"].ToString()), dr["Nombre"].ToString(), dr["Direccion"].ToString(), dr["Telefono"].ToString()));
                }

                return listaTiendas;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlconexion.Close();
            }
        }

        /// <summary>
        /// Método que consulta la tabla Articulo de la base de datos y devuelve una lista de objetos de tipo Articulo
        /// </summary>
        /// <returns>Lista de objetos de tipo Articulo</returns>
        public static List<Articulo> TraerArticulos()
        {
            List<Articulo> listaArticulos = new List<Articulo>();
            string consulta = " Select * from Articulo order by Id";

            try
            {
                sqlcomando.CommandText = consulta;
                sqlconexion.Open();
                SqlDataReader dr = sqlcomando.ExecuteReader();

                while (dr.Read())
                {
                    string tipoProducto = dr["Tipo"].ToString();

                    if (tipoProducto == Articulo.ETipoDeArticulo.Computacion.ToString())
                    {
                        listaArticulos.Add(new ArticuloComputacion(dr["Nombre"].ToString(), float.Parse(dr["Precio"].ToString()), int.Parse(dr["Stock"].ToString()), int.Parse(dr["Id"].ToString())));

                    }
                    else
                    {
                        listaArticulos.Add(new ArticuloHogar(dr["Nombre"].ToString(), float.Parse(dr["Precio"].ToString()), int.Parse(dr["Stock"].ToString()), int.Parse(dr["id"].ToString())));
                    }
                }

                return listaArticulos;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlconexion.Close();
            }
        }

        /// <summary>
        /// Método que realiza una consulta a la tabla de Venta y devuelve una lista
        /// </summary>
        /// <returns>Lista de objetos de tipo Venta</returns>
        public static List<Venta> TraerVentas()
        {
            List<Venta> listaVentas = new List<Venta>();
            string consulta = " Select * from Venta order by Id";

            try
            {
                sqlcomando.CommandText = consulta;
                sqlconexion.Open();
                SqlDataReader dr = sqlcomando.ExecuteReader();

                while (dr.Read())
                {
                    string auxEstadoVenta = dr["EstadoVenta"].ToString();

                    if (dr["EstadoVenta"].ToString() == Venta.EEstadoVenta.Conforme.ToString())
                    {
                        listaVentas.Add(new Venta(int.Parse(dr["Id"].ToString()), int.Parse(dr["IdTienda"].ToString()), int.Parse(dr["IdArticulo"].ToString()), int.Parse(dr["Cantidad"].ToString()), float.Parse(dr["Monto"].ToString()), Venta.EEstadoVenta.Conforme));
                    }
                    else if (dr["EstadoVenta"].ToString() == Venta.EEstadoVenta.Pendiente.ToString())
                    {
                        listaVentas.Add(new Venta(int.Parse(dr["Id"].ToString()), int.Parse(dr["IdTienda"].ToString()), int.Parse(dr["IdArticulo"].ToString()), int.Parse(dr["Cantidad"].ToString()), float.Parse(dr["Monto"].ToString()), Venta.EEstadoVenta.Pendiente));
                    }
                    else
                    {
                        listaVentas.Add(new Venta(int.Parse(dr["Id"].ToString()), int.Parse(dr["IdTienda"].ToString()), int.Parse(dr["IdArticulo"].ToString()), int.Parse(dr["Cantidad"].ToString()), float.Parse(dr["Monto"].ToString()), Venta.EEstadoVenta.Rechazada));
                    }
                }
                return listaVentas;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlconexion.Close();
            }
        }

        /// <summary>
        /// /Método que permite actualizar el stock de un Articulo en la Tabla Articulo
        /// </summary>
        /// <param name="unArticulo">Objeto de tipo Articulo</param>
        /// <returns>Devuelve un booleano para control de ejecucion</returns>
        public static bool ActualizarStockArticulo(Articulo unArticulo)
        {
            string consulta = "Update Articulo Set Stock = @Stock where Id = @auxID";
            bool retValue = false;
            try
            {
                sqlcomando.CommandText = consulta;
                sqlcomando.Parameters.Clear();
                sqlcomando.Parameters.Add(new SqlParameter("@Stock", unArticulo.Cantidad));
                sqlcomando.Parameters.Add(new SqlParameter("@auxID", unArticulo.IdArticulo));

                sqlconexion.Open();
                int retorno = sqlcomando.ExecuteNonQuery();
                retValue = true;

                return retValue;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlconexion.Close();
            }
        }

        /// <summary>
        /// Método que realiza un update al campo EstadoVenta de la tabla Venta
        /// </summary>
        /// <param name="unaVenta">Objeto de tipo venta que representa la venta a actualizar</param>
        /// <returns>Devuelve un booleano para control de ejecucion</returns>
        public static bool ActualizarEstadoVenta(Venta unaVenta)
        {
            string consulta = "Update Venta Set EstadoVenta = @EstadoVenta where Id = @auxID";
            bool retValue = false;
            try
            {
                sqlcomando.CommandText = consulta;
                sqlcomando.Parameters.Clear();
                sqlcomando.Parameters.Add(new SqlParameter("@EstadoVenta", unaVenta.EstadoVenta.ToString()));
                sqlcomando.Parameters.Add(new SqlParameter("@auxID", unaVenta.IdVenta));

                sqlconexion.Open();
                int retorno = sqlcomando.ExecuteNonQuery();
                retValue = true;

                return retValue;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlconexion.Close();
            }
        }

        /// <summary>
        /// Método que inserta un nuevo registro en la tabla Venta y devuelve un objeto de Venta con los atributos de dicho registro
        /// </summary>
        /// <param name="auxIdTienda">Entero que representa el Id de la tienda</param>
        /// <param name="auxIdArticulo">Entero que representa el Id del Articulo</param>
        /// <param name="auxCantidad">Entero que representa la Cantidad solicitada del Articulo</param>
        /// <param name="auxMonto">Float que representa el Monto de la Venta</param>
        /// <param name="auxEstadoVenta">String que representa el estado de la venta</param>
        /// <returns>Retorona un objeto de tipo Venta</returns>
        public static Venta GenerarVenta(int auxIdTienda, int auxIdArticulo, int auxCantidad, float auxMonto, string auxEstadoVenta)
        {
            Venta auxVenta = null;
            List<Venta> auxListaVentas = new List<Venta>();

            string consultaInsert = "INSERT INTO Venta ([IdTienda],[IdArticulo],[Cantidad],[Monto],[EstadoVenta]) VALUES (@IdTienda, @IdArticulo, @Cantidad, @Monto, @EstadoVenta)";
            try

            {
                sqlcomando.CommandText = consultaInsert;
                sqlcomando.Parameters.Clear();
                sqlcomando.Parameters.Add(new SqlParameter("@IdTienda", auxIdTienda));
                sqlcomando.Parameters.Add(new SqlParameter("@IdArticulo", auxIdArticulo));
                sqlcomando.Parameters.Add(new SqlParameter("@Cantidad", auxCantidad));
                sqlcomando.Parameters.Add(new SqlParameter("@Monto", auxMonto));
                sqlcomando.Parameters.Add(new SqlParameter("@EstadoVenta", auxEstadoVenta));

                sqlconexion.Open();
                int retorno = sqlcomando.ExecuteNonQuery();
                if (retorno > 0)
                {
                    sqlconexion.Close();
                    auxListaVentas = TraerVentas();
                    if (auxListaVentas.Count > 0)
                    {
                        for (int i = 0; i < auxListaVentas.Count; i++)
                        {
                            if (i == (auxListaVentas.Count - 1))
                            {
                                auxVenta = auxListaVentas[i];
                            }
                        }
                    }
                }

                return auxVenta;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlconexion.Close();
            }
        }

        /// <summary>
        /// Método que inserta un nuevo registro en la tabla Articulo y devuelve un objeto de Articulo con los atributos de dicho registro
        /// </summary>
        /// <param name="nombre">string que representa el nombre del articulo</param>
        /// <param name="auxstock">entero que representa el stock del articulo</param>
        /// <param name="auxPrecio">float que representa el precio unitario del articulo</param>
        /// <param name="auxTipoArticulo">string que representa el tipo de articulo</param>
        /// <returns></returns>
        public static Articulo GenerarArticulo(string nombre, int auxstock, float auxPrecio, string auxTipoArticulo)
        {
            Articulo auxArticulo = null;
            List<Articulo> auxListaArticulos = new List<Articulo>();

            string consultaInsert = "INSERT INTO Articulo ([Nombre],[Stock],[Precio],[Tipo]) VALUES (@Nombre, @Stock, @Precio, @Tipo)";
            try

            {
                sqlcomando.CommandText = consultaInsert;
                sqlcomando.Parameters.Clear();
                sqlcomando.Parameters.Add(new SqlParameter("@Nombre", nombre));
                sqlcomando.Parameters.Add(new SqlParameter("@Stock", auxstock));
                sqlcomando.Parameters.Add(new SqlParameter("@Precio", auxPrecio));
                sqlcomando.Parameters.Add(new SqlParameter("@Tipo", auxTipoArticulo));

                sqlconexion.Open();
                int retorno = sqlcomando.ExecuteNonQuery();
                if (retorno > 0)
                {
                    sqlconexion.Close();
                    auxListaArticulos = TraerArticulos();
                    if (auxListaArticulos.Count > 0)
                    {
                        for (int i = 0; i < auxListaArticulos.Count; i++)
                        {
                            if (i == (auxListaArticulos.Count - 1))
                            {
                                auxArticulo = auxListaArticulos[i];
                            }
                        }
                    }
                }

                return auxArticulo;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlconexion.Close();
            }
        }

        #endregion
    }
}
