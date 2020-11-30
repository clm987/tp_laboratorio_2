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

namespace Pantallas
{
    /// <summary>
    /// Clase parcial que permite manejar los eventos del formnulario de carga de un articulo nuevo
    /// </summary>
    public partial class CargarArticulo : Form
    {
        public CargarArticulo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metodo que carga el formulario. Se definen los datos a ser mostrados en el control cmbTipoArticulo que provienen del enumerado EtipoDeArticulo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CargarArticulo_Load(object sender, EventArgs e)
        {
            cmbTipoArticulo.DataSource = Enum.GetValues(typeof(Articulo.ETipoDeArticulo));
        }


        /// <summary>
        /// Metodo del evento click del control btnAceptar. Este evento desencadena las acciones necesarias para la carga del nuevo producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //Valida datos ingresados
                Validaciones.validarEntradaNombreArticulo(txtNombreArticulo.Text);
                Validaciones.validarEntradaCantidad(txtCantidadArticulo.Text);
                Validaciones.validarEntradaPrecio(txtPrecioUnitario.Text);

                //Arma variables auxiliares tomando datos de los controladores que seran necesarios para generar la nueva instancia del objeto de tipo Articulo
                int auxcantidad = int.Parse(txtCantidadArticulo.Text);
                float auxfloat = float.Parse(txtPrecioUnitario.Text);
                string auxTipoArticulo = cmbTipoArticulo.SelectedItem.ToString();

                //Se recibe la respuesta de la base de datos con los atributos necesarios para una nueva instancia de objeto de tipo Articulo
                Articulo auxArticulo = HelperBD.GenerarArticulo(txtNombreArticulo.Text, auxcantidad, auxfloat, auxTipoArticulo);
                MessageBox.Show(String.Concat("El articulo fue cargado con exito!\n", auxArticulo.Mostrar()));
                DialogResult = DialogResult.OK;

            }
            catch (ImputException ex)
            {

                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {

                MessageBox.Show("Ha ocurrido un error verifique los datos ingresados");
            }
        }
    }
}
