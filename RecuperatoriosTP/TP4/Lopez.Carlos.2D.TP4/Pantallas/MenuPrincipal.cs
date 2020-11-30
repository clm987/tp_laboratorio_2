using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Entidades;
using Excepciones;


namespace Pantallas
{
    /// <summary>
    /// Clase parcial que permite manejar el formulario principal de la aplicacion. Permite mostrar mediante controladores de tipo DataGridView el procesamiento automatico de las ventas mediante un hilo (Tema Hilos)
    /// </summary>

    public partial class MenuPrincipal : Form
    {
        //Se declara el hilo que permitira el manejo automatico de ventas
        public Thread HiloVentas;
        public bool hiloActivo = false;

        public MenuPrincipal()
        {
            InitializeComponent();
            //Se instancia de manera parametrizada el hilo pasando el metodo ProcesarVentas que manejara el procesamiento de las ventas pendientes
            HiloVentas = new Thread(ProcesarVentas);
            //Se declara la propiedad IsBackground como true para que finalice junto con el hilo principal del formulario
            HiloVentas.IsBackground = true;
        }

        /// <summary>
        /// Metodo que maneja el evento click que control btnNuevaVenta. Permite la creacion de una instancia del formulario de tipo NuevaVenta y mostrarlo en modalidad ShowDialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            NuevaVenta auxNuevaVenta = new NuevaVenta();
            auxNuevaVenta.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                auxNuevaVenta.Close();
            }

        }

        /// <summary>
        /// Metodo que maneja el evento click que control btnCargarNuevoProducto. Permite la creacion de una instancia del formulario de tipo CargarArticulo y mostrarlo en modalidad ShowDialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargarNuevoProducto_Click(object sender, EventArgs e)
        {
            CargarArticulo auxCargarArticulo = new CargarArticulo();
            auxCargarArticulo.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                auxCargarArticulo.Close();
            }
        }


        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            //Carga las listas con datos de la base de datos
            Distribuidora.listaDeTiendas = HelperBD.TraerTiendas();
            Distribuidora.listaDeArticulos = HelperBD.TraerArticulos();
            try
            {
                ///Se hace una primera actualizacion de los DataGridView que mostraran el procesamiento de las ventas
                CargarVentasPendientes();
                ActualizarMostrarDtgVentasPendientes();

                ///Hacer star del hilo que procesara las ventas
                if (!HiloVentas.IsAlive)
                {
                    HiloVentas.Start();

                }
                else
                {
                    HiloVentas.Abort();
                    HiloVentas.Start();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Metodo que maneja el hilo que procesa de manera automatica las ventas y muestra los resultados por pantalla. 
        /// </summary>
        public void ProcesarVentas()
        {
            bool continuar = true;
            try
            {
                hiloActivo = true;
                while (continuar == true)
                {
                    ActualizarDtvVentasPendientes();
                    Thread.Sleep(4000);
                    //Valida que existan ventas pendientes
                    if (Distribuidora.colaVentasPendientes.Count > 0)
                    {
                        Venta auxVenta = Distribuidora.colaVentasPendientes.Dequeue();
                        if (Distribuidora.ConfirmarStockVentasExternas(auxVenta))
                        {
                            //Busca el articulo a vender
                            Articulo auxArticulo = Distribuidora.buscarArticuloPorId(auxVenta.IdArticulo);
                            auxArticulo.Cantidad = auxArticulo.Cantidad - auxVenta.Cantidad;
                            //Actualiza el stock del articulo
                            HelperBD.ActualizarStockArticulo(auxArticulo);
                            //Actualiza el estado de la venta
                            auxVenta.EstadoVenta = Venta.EEstadoVenta.Conforme;
                            HelperBD.ActualizarEstadoVenta(auxVenta);
                            //Pasa la venta a la cola de ventas procesadas
                            Distribuidora.colaVentasProcesadas.Enqueue(auxVenta);
                            //Actualiza los DataGridView que van mostrando los resultados del proceso
                            ActualizarDtvVentasPendientes();
                            ActualizarDtvVentasProcesadas();
                            Thread.Sleep(4000);
                        }
                        else
                        {
                            //Si no se pudo conformar la venta se cambia su estado a rechazada
                            auxVenta.EstadoVenta = Venta.EEstadoVenta.Rechazada;
                            HelperBD.ActualizarEstadoVenta(auxVenta);
                            Distribuidora.colaVentasProcesadas.Enqueue(auxVenta);

                            //Suscribe el método GenerarLogVentasRechazadas al delegado ventaRechazada a fin de ser ejecutado al lanzar el evento
                            Distribuidora.ventaRechazada += Distribuidora.GenerarLogVentasRechazadas;
                            //Llamada al evento que desencadena la escritura del archivo de texto con el log de ventas rechazadas
                            Distribuidora.InvocarEvento(auxVenta);
                            ActualizarDtvVentasPendientes();
                            ActualizarDtvVentasProcesadas();
                            Thread.Sleep(4000);
                        }
                    }
                    else
                    {
                        //Si no hay más ventas pendientes lo informa por pantalla validando antes que se pueda llamar al control lblmensajeventas que es manejado por el hilo del formulario
                        if (this.lblmensajeventas.InvokeRequired)
                        {
                            this.lblmensajeventas.BeginInvoke((MethodInvoker)delegate ()
                            {
                                lblmensajeventas.Visible = true;
                                this.lblmensajeventas.Text = "No hay ventas externas para procesar";
                            });
                        }
                        else
                        {
                            lblmensajeventas.Visible = true;
                            this.lblmensajeventas.Text = "No hay ventas externas para procesar";
                        }
                        continuar = false;
                    }
                }
                hiloActivo = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Metodo que detecta si existe un archivo de ordenes de compra y de ser asi genera las ventas pendientes correspondientes en la tabla Venta de la base Distribuidora
        /// </summary>
        public void CargarVentasPendientes()
        {
            //Lee el archivo xml con las ordenes de compra externas
            if (Distribuidora.Leer())
            {
                //Genera las ventas pendientes en base a las ordenes
                Distribuidora.GenerarVentasPendientes(Distribuidora.listaDeOrdenesDeCompra);
                //Actualiza la lista de ventas con las nuevas ventas
                Distribuidora.listaDeVentas = HelperBD.TraerVentas();
                //Carga las nuevas ventas pendientes en la cola de ventas pendientes
                Distribuidora.EncolarVentasPendientes();
                dgvVentasPendientes.DataSource = null;
                dgvVentasPendientes.DataSource = Distribuidora.colaVentasPendientes.ToArray();
            }
            else
            {
                //Si el archivo no existe informa que no hay ventas externas para procesar
                lblmensajeventas.Text = "No hay ventas externas para procesar";
            }
        }

        /// <summary>
        /// Actualiza el control dgvVentasPendientes para mostrar la cola de ventas pendientes
        /// </summary>
        public void ActualizarMostrarDtgVentasPendientes()
        {
            dgvVentasPendientes.DataSource = null;
            dgvVentasPendientes.DataSource = Distribuidora.colaVentasPendientes.ToArray();
        }

        /// <summary>
        ///  Actualiza el control dgvVentasProcesadas para mostrar la cola de ventas procesadas
        /// </summary>
        public void ActualizarMostrarDtgVentasProcesadas()
        {
            dgvVentasProcesadas.DataSource = null;
            dgvVentasProcesadas.DataSource = Distribuidora.colaVentasProcesadas.ToArray();
        }

        /// <summary>
        /// Maneja la actualizacion validando que se pueda invocar al control que pertenece al hilo del formulario
        /// </summary>
        private void ActualizarDtvVentasPendientes()
        {
            if (this.dgvVentasPendientes.InvokeRequired)
            {
                this.dgvVentasPendientes.BeginInvoke((MethodInvoker)delegate ()
                {
                    ActualizarMostrarDtgVentasPendientes();
                });
            }
            else
            {
                ActualizarMostrarDtgVentasPendientes();
            }
        }

        /// <summary>
        /// Maneja la actualizacion validando que se pueda invocar al control que pertenece al hilo del formulario
        /// </summary>
        private void ActualizarDtvVentasProcesadas()
        {
            if (this.dgvVentasProcesadas.InvokeRequired)
            {
                this.dgvVentasProcesadas.BeginInvoke((MethodInvoker)delegate ()
                {
                    ActualizarMostrarDtgVentasProcesadas();
                });
            }
            else
            {
                ActualizarMostrarDtgVentasProcesadas();
            }

            if (this.lblDatosMontoVentas.InvokeRequired)
            {
                this.lblDatosMontoVentas.BeginInvoke((MethodInvoker)delegate ()
                {

                    float auxMonto = Distribuidora.colaVentasProcesadas.CalcularTotalVentasProcesadas();
                    lblDatosMontoVentas.Text = auxMonto.ToString();
                });
            }
        }

    }
}
