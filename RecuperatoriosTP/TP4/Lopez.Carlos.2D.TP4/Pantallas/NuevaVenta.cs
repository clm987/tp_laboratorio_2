using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Excepciones;
using Archivos;

namespace Pantallas
{
    /// <summary>
    /// Clase parcial que permite el manejo del formulario de carga de una nueva venta
    /// </summary>
    public partial class NuevaVenta : Form
    {
        public NuevaVenta()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metodo que carga el formulario. Se cargan los controles cmbListatiendas y cmbListaArticulos con la informacion de las listas de tiendas y articulos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NuevaVenta_Load(object sender, EventArgs e)
        {
            CargarComboTiendas();
            CargarComboArticulos();

        }

        /// <summary>
        /// Metodo que carga el control cmbListatiendas con la lista de tiendas 
        /// </summary>
        public void CargarComboTiendas()
        {
            cmbListatiendas.DataSource = Distribuidora.listTiendas;
            cmbListatiendas.DisplayMember = "Nombre";
        }

        /// <summary>
        /// Metodo que carga el control cmbListaArticulos con la lista de articulos 
        /// </summary>
        public void CargarComboArticulos()
        {
            cmbListaArticulos.DataSource = Distribuidora.listArticulos;
            cmbListaArticulos.DisplayMember = "Nombre";
        }

        /// <summary>
        /// Metodo que maneja el evento click del control btnAceptar. Este evento genera la carga de una nueva venta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //Carga los datos de entrada en variables auxiliares realizando las validaciones correspondientes
                Tienda auxtiendaSeleccionada = (Tienda)cmbListatiendas.SelectedItem;
                Articulo auxArticuloSeleccionado = (Articulo)cmbListaArticulos.SelectedItem;
                Validaciones.validarEntradaCantidad(txtCantidad.Text);
                int auxCantidad = int.Parse(txtCantidad.Text);
                //Confirma el stock disponible para el articulo seleccionado
                Distribuidora.ConfirmarStock(auxArticuloSeleccionado.IdArticulo, auxCantidad);
                //Calcula el monto de la venta
                float auxmonto = Distribuidora.CalcularMontoVenta(auxCantidad, auxArticuloSeleccionado.PrecioUnitario);
                //Genera la nueva venta. Las ventas directas se generan con estado Conforme
                Venta nuevaVenta = HelperBD.GenerarVenta(auxtiendaSeleccionada.IdTienda, auxArticuloSeleccionado.IdArticulo, auxCantidad, auxmonto, Venta.EEstadoVenta.Conforme.ToString());
                auxArticuloSeleccionado.Cantidad = auxArticuloSeleccionado.Cantidad - auxCantidad;
                HelperBD.ActualizarStockArticulo(auxArticuloSeleccionado);
                //Genera un ticket de venta con los datos de la venta. (Tema Archivos)
                Distribuidora.GenerarTicketVenta(nuevaVenta, auxtiendaSeleccionada);
                MessageBox.Show(String.Concat("Venta realizada con exito!\n Monto Total: ", auxmonto.ToString()));
                DialogResult = DialogResult.OK;

            }
            catch (ImputException ex)
            {

                MessageBox.Show(ex.Message);
            }
            catch (StockException ex)
            {

                MessageBox.Show(ex.Message);
            }
            catch (NullReferenceException)
            {

                MessageBox.Show("Seleccione correctamente la tienda y el articulo");
            }
            catch (Exception)
            {

                MessageBox.Show("Ha ocurrido un error. Verifique los datos");
            }
        }
    }
}
