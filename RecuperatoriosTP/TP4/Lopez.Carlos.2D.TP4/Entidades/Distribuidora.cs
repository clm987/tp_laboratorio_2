using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Archivos;
using Excepciones;

namespace Entidades
{
    //Delegado que permite asociar el metodo manejador del evento ventaRechazada (Tema Delegados)
    public delegate bool DelegadoVentaRechazada(Venta auxVenta);
    /// <summary>
    /// Clase estatica que maneja las listas de datos y contiene el evento ventaRechazada (Tema Eventos)
    /// </summary>
    public static class Distribuidora
    {
        #region Atributos y propiedades
        public static event DelegadoVentaRechazada ventaRechazada;
        public static List<Articulo> listaDeArticulos;
        public static List<Venta> listaDeVentas;
        public static List<OrdenDeCompra> listaDeOrdenesDeCompra;
        public static List<Tienda> listaDeTiendas;
        public static Queue<Venta> colaVentasProcesadas;
        public static Queue<Venta> colaVentasPendientes;
        public static bool hiloActivoConsola = false;

        public static List<Articulo> listArticulos
        {
            get { return listaDeArticulos; }
        }

        public static List<Tienda> listTiendas
        {
            get { return listaDeTiendas; }
        }
        #endregion
        #region Constructor estatico
        /// <summary>
        /// Contructor de la clase estatica
        /// </summary>
        static Distribuidora()
        {
            listaDeArticulos = new List<Articulo>();
            listaDeTiendas = new List<Tienda>();
            listaDeVentas = new List<Venta>();
            colaVentasProcesadas = new Queue<Venta>();
            colaVentasPendientes = new Queue<Venta>();
            listaDeOrdenesDeCompra = new List<OrdenDeCompra>();
        }
        #endregion
        #region Metodos
        /// <summary>
        /// Metodo que busca un articulo en la lista de articulos (metodo probado con test unitario Tema Test Unitarios)
        /// </summary>
        /// <param name="idArticulo">entero que represeta el Id del articulo buscado</param>
        /// <returns>Objeto de tipo Articulo</returns>
        public static Articulo buscarArticuloPorId(int idArticulo)
        {
            Articulo auxArticulo = null;
            for (int i = 0; i < Distribuidora.listaDeArticulos.Count; i++)
            {
                if (Distribuidora.listaDeArticulos[i].IdArticulo == idArticulo)
                {
                    auxArticulo = Distribuidora.listaDeArticulos[i];
                }
            }
            return auxArticulo;
        }

        /// <summary>
        /// Metodo que evalua la cantidad solicitada de un Articulo en funcion de la cantidad solicitada (metodo probado con test unitario)
        /// </summary>
        /// <param name="idArticuloAValidar">Entero que representa el Id del articulo solicitado</param>
        /// <param name="cantidadArticuloSeleccionado">Entero que representa la cantidad solicitada</param>
        public static void ConfirmarStock(int idArticuloAValidar, int cantidadArticuloSeleccionado)
        {
            StockException ex = new StockException("No hay suficiente stock");

            foreach (Articulo item in listArticulos)
            {
                if (item.IdArticulo == idArticuloAValidar)
                {
                    if (item.Cantidad > 0)
                    {
                        if (cantidadArticuloSeleccionado <= item.Cantidad)
                        {
                            continue;
                        }
                        else
                        {
                            throw ex;
                        }
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// Método que valida el stock disponible de un producto que se esta solicitando en una venta determinada contra una lista actualizada de la base de datos
        /// </summary>
        /// <param name="auxVenta">Objeto de tipo Venta</param>
        /// <returns>Devuelve un booleano para control de ejecucion</returns>
        public static bool ConfirmarStockVentasExternas(Venta auxVenta)
        {
            bool retValue = false;
            try
            {
                List<Articulo> auxListaDeArticulos = HelperBD.TraerArticulos();
                if (auxListaDeArticulos != null)
                {
                    foreach (Articulo unArticulo in auxListaDeArticulos)
                    {
                        if (unArticulo.IdArticulo == auxVenta.IdArticulo)
                        {
                            if (unArticulo.Cantidad >= auxVenta.Cantidad)
                            {
                                retValue = true;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return retValue;
        }

        /// <summary>
        /// Metodo que genera el ticket de venta una vez se ha confirmado la nueva venta (Tema Archivos)
        /// </summary>
        /// <param name="ventaActual">Objeto de tipo venta</param>
        /// <param name="tiendaSolicitante">objeto de tipo tienda</param>
        /// <returns>Devuelve un booleano para control de ejecucion</returns>
        public static bool GenerarTicketVenta(Venta ventaActual, Tienda tiendaSolicitante)
        {
            string rutaDeArchivo = String.Format("{0}\\ticketDeVenta.txt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            Articulo auxArticulo = buscarArticuloPorId(ventaActual.IdArticulo);

            Texto ArchivoDeTexto = new Texto();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------DATOS DE LA TIENDA-------------");
            sb.AppendLine($"{tiendaSolicitante.Mostrar()}");
            sb.AppendLine("----------DETALLE DE LA VENTA-------------");
            sb.AppendLine(auxArticulo.Mostrar());
            sb.AppendLine("------------------------------------------");
            sb.AppendLine($"MONTO TOTAL: {ventaActual.Monto.ToString()}");

            return ArchivoDeTexto.Guardar(rutaDeArchivo, sb.ToString());
        }

        /// <summary>
        /// Metodo que genera un archivo de texto en el escritorio que funciona como log de ventas rechazadas (Tema Archivos) este metodo es asociado al delegado y se ejecuta al lanzar el evento ventaRechazada (tema eventos)
        /// </summary>
        /// <param name="ventaActual">objeto de tipo venta</param>
        /// <returns>Devuelve un booleano para control de ejecucion</returns>
        public static bool GenerarLogVentasRechazadas(Venta ventaActual)
        {
            bool retValue = false;
            Tienda auxtiendaSolicitante = BuscarTiendaPorId(ventaActual.IdTienda);

            if (auxtiendaSolicitante != null)
            {
                string rutaDeArchivo = String.Format("{0}\\logVentasRechazadas.txt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                Articulo auxArticulo = buscarArticuloPorId(ventaActual.IdArticulo);

                Texto ArchivoDeTexto = new Texto();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("----------DATOS DE LA TIENDA-------------");
                sb.AppendLine($"{auxtiendaSolicitante.Mostrar()}");
                sb.AppendLine("----------DETALLE DE LA VENTA-------------");
                sb.AppendLine(auxArticulo.Mostrar());
                sb.AppendLine("------------------------------------------");
                sb.AppendLine($"MONTO TOTAL: {ventaActual.Monto.ToString()}");

                retValue = ArchivoDeTexto.GuardarLog(rutaDeArchivo, sb.ToString());
                return retValue;
            }
            return retValue;

        }
        /// <summary>
        /// Metodo que busca un objeto de tipo Tienda partiendo de la Id de Tienda
        /// </summary>
        /// <param name="idTiendaABuscar">Entero que representa el id unico de tienda</param>
        /// <returns>Devuelve un objeto de tipo Tienda</returns>
        public static Tienda BuscarTiendaPorId(int idTiendaABuscar)
        {
            Tienda auxtienda = null;
            foreach (Tienda unatienda in listaDeTiendas)
            {
                if (unatienda.IdTienda == idTiendaABuscar)
                {
                    auxtienda = unatienda;
                }
            }
            return auxtienda;
        }

        /// <summary>
        /// Metodo utlizado para generar el xml de Ordenes de compra que permite simular la carga de ordenes externas. Puede usarse si se prefiere generar el archivo en lugar de copiar el que se adjunta al proyecto en la ruta definida
        /// </summary>
        /// <param name="auxOrdenesDeCompra">Lista de ordenes de compra</param>
        /// <returns>Devuelve un booleano para control de ejecucion</returns>
        public static bool Guardar(List<OrdenDeCompra> auxOrdenesDeCompra)
        {
            string path = String.Format("{0}\\OrdenesDeCompraExternas.xml", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            Xml<List<OrdenDeCompra>> auxOrden = new Xml<List<OrdenDeCompra>>();

            return auxOrden.Guardar(path, auxOrdenesDeCompra);
        }

        /// <summary>
        /// Metodo que permite leer el archivo Xlm de ordenes de compra externas (Temas Archivos y deserializacion)
        /// </summary>
        /// <returns>Devuelve un booleano para control de ejecucion</returns>
        public static bool Leer()
        {
            bool retValue = false;
            string path = String.Format("{0}\\OrdenesDeCompraExternas.xml", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            Xml<List<OrdenDeCompra>> auxListaOrdenes = new Xml<List<OrdenDeCompra>>();

            if (auxListaOrdenes.Leer(path, out Distribuidora.listaDeOrdenesDeCompra))
            {
                retValue = true;
            }

            return retValue;

        }

        /// <summary>
        /// Metodo que permite generar en la base de datos ventas en estado pendiente en funcion de las ordenes de compra recibidas
        /// </summary>
        /// <param name="listaDeOrdenesDeCompra">Lista de objetos de tipo OrdenDeCompra</param>
        public static void GenerarVentasPendientes(List<OrdenDeCompra> listaDeOrdenesDeCompra)
        {
            foreach (OrdenDeCompra item in listaDeOrdenesDeCompra)
            {
                HelperBD.GenerarVenta(item.IdTienda, item.IdArticulo, item.Cantidad, item.Monto, Venta.EEstadoVenta.Pendiente.ToString());
            }
        }

        /// <summary>
        /// Metodo que carga la cola de Ventas Pendientes seleccionando de la listaDeVentas solo aquellas que se encuentran pendientes de procesamiento
        /// </summary>
        public static void EncolarVentasPendientes()
        {
            foreach (Venta item in listaDeVentas)
            {
                if (item.EstadoVenta == Venta.EEstadoVenta.Pendiente)
                {
                    colaVentasPendientes.Enqueue(item);
                }
            }
        }

        /// <summary>
        /// Metodo que permite calcular el monto de una venta en funcion de la cantidad solicitada y el precio untario del articulo
        /// </summary>
        /// <param name="cantidad">entero que representa la cantidad solicitada</param>
        /// <param name="precioUnitario">float que representa el precio unitario del produto</param>
        /// <returns>Devuelve un float que representa el monto</returns>
        public static float CalcularMontoVenta(int cantidad, float precioUnitario)
        {
            float monto = 0;
            if (cantidad > 0 && precioUnitario > 0)
            {
                monto = cantidad * precioUnitario;
            }
            return monto;
        }

        /// <summary>
        /// Este método se puede usar si se desea emular la generación del archivo xml de ordenes de compra en lugar de copiar el archivo que se adjunta en el proyecto. No condiciona el funcionamiento de la solucion, sus implementaciones se dejan comentadas en caso que se quiera usar para la prueba se deberá descomentar
        /// </summary>
        /*public static void HardCodeOrdenesDeCompra()
        {
            List<OrdenDeCompra> auxListaDeOrdenes = new List<OrdenDeCompra>();
            OrdenDeCompra auxOrden1 = new OrdenDeCompra(1, 11, 2, 1200);
            OrdenDeCompra auxOrden2 = new OrdenDeCompra(1, 11, 2, 1200);
            OrdenDeCompra auxOrden3 = new OrdenDeCompra(2, 11, 2, 1200);
            OrdenDeCompra auxOrden4 = new OrdenDeCompra(2, 4, 3, 24000);
            OrdenDeCompra auxOrden5 = new OrdenDeCompra(3, 6, 1, 38000);
            OrdenDeCompra auxOrden6 = new OrdenDeCompra(4, 5, 2, 70000);
            OrdenDeCompra auxOrden7 = new OrdenDeCompra(5, 1, 2, 30000);
            OrdenDeCompra auxOrden8 = new OrdenDeCompra(4, 4, 2, 16000);
            OrdenDeCompra auxOrden9 = new OrdenDeCompra(2, 4, 3, 24000);
            OrdenDeCompra auxOrden10 = new OrdenDeCompra(1, 4, 2, 16000);
            OrdenDeCompra auxOrden11 = new OrdenDeCompra(3, 9, 5, 20000);
            OrdenDeCompra auxOrden12 = new OrdenDeCompra(6, 9, 2, 8000);
            OrdenDeCompra auxOrden13 = new OrdenDeCompra(5, 11, 3, 1800);

            auxListaDeOrdenes.Add(auxOrden1);
            auxListaDeOrdenes.Add(auxOrden2);
            auxListaDeOrdenes.Add(auxOrden3);
            auxListaDeOrdenes.Add(auxOrden4);
            auxListaDeOrdenes.Add(auxOrden5);
            auxListaDeOrdenes.Add(auxOrden6);
            auxListaDeOrdenes.Add(auxOrden7);
            auxListaDeOrdenes.Add(auxOrden8);
            auxListaDeOrdenes.Add(auxOrden9);
            auxListaDeOrdenes.Add(auxOrden10);
            auxListaDeOrdenes.Add(auxOrden11);
            auxListaDeOrdenes.Add(auxOrden12);
            auxListaDeOrdenes.Add(auxOrden13);

            Guardar(auxListaDeOrdenes);
        }*/


        /// <summary>
        /// Metodo que sirve para invocar el evento ventaRechazada 
        /// </summary>
        /// <param name="auxVentaRechazada">Objeto de tipo Venta que representa la venta que ha sido rechazada en el procesamiento automatico</param>
        public static void InvocarEvento(Venta auxVentaRechazada)
        {
            ventaRechazada.Invoke(auxVentaRechazada);
        }

        /// <summary>
        /// Este método permite emular el procesamiento de ventas de manera automatica mediante el uso de un hilo pero haciendolo visible desde la consola y depurando algunas especificidades del front de windows forms
        /// </summary>
        public static void ProcesarVentasConsola()
        {
            bool continuar = true;
            try
            {
                hiloActivoConsola = true;
                while (continuar == true)
                {
                    //Se valida que existan ventas pendientes en la cola 
                    if (Distribuidora.colaVentasPendientes.Count > 0)
                    {
                        //Se obtiene un elemento de la cola de ventas pendientes
                        Venta auxVenta = Distribuidora.colaVentasPendientes.Dequeue();
                        //Calida si hay stock disponible del producto solicitado en la venta
                        if (Distribuidora.ConfirmarStockVentasExternas(auxVenta))
                        {
                            //Procesa una venta dejandola como conforme en la base de datos y actualizando el stock
                            Articulo auxArticulo = Distribuidora.buscarArticuloPorId(auxVenta.IdArticulo);
                            auxArticulo.Cantidad = auxArticulo.Cantidad - auxVenta.Cantidad;
                            HelperBD.ActualizarStockArticulo(auxArticulo);
                            auxVenta.EstadoVenta = Venta.EEstadoVenta.Conforme;
                            HelperBD.ActualizarEstadoVenta(auxVenta);
                            Distribuidora.colaVentasProcesadas.Enqueue(auxVenta);
                        }
                        else
                        {
                            //Establece el estado de la venta como rechazada
                            auxVenta.EstadoVenta = Venta.EEstadoVenta.Rechazada;
                            HelperBD.ActualizarEstadoVenta(auxVenta);
                            //Asigna la venta a la cola de ventas procesadas. 
                            Distribuidora.colaVentasProcesadas.Enqueue(auxVenta);
                            //Suscirbe al Delegado ventaRechazada el metodo GenerarLogVentasRechazadas
                            Distribuidora.ventaRechazada += Distribuidora.GenerarLogVentasRechazadas;
                            //Llamada al metodo que invoca al evento para generar el registro en el log de ventas rechazadas.
                            Distribuidora.InvocarEvento(auxVenta);
                        }
                    }
                    else
                    {
                        continuar = false;
                    }
                }
                hiloActivoConsola = false;
            }
            catch (StockException)
            {

            }
            catch (Exception)
            {

            }
        }
        #endregion
    }
}
