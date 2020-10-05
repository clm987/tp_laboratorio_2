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

namespace miCalculadora
{
    public partial class FormCalculadora : Form
    {
        bool binaryFlag = false;
        int operarCount = 0;

        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
           
        }
        /// <summary>
        /// Metodo del evento boton "Cerrar". Cierra la aplicación. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Metodo que asigna espacios a la propiedad texto de los elementos
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "";
        }

        /// <summary>
        /// Controla el evento boton "Limpiar" llamando al metodo Limpiar()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Metodo que pasa elementos al metodo Operar de la clase Calculadora
        /// y retorna el resultado obtenido
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado = 0;
            Numero auxNum1 = new Numero(numero1);
            Numero auxNum2 = new Numero(numero2);
            resultado = Calculadora.Operar(auxNum1, auxNum2, operador);
            return resultado;
        }

        /// <summary>
        /// Controla el evento click del boton "Operar"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string auxNum1 = this.txtNumero1.Text;
            string auxNum2 = this.txtNumero2.Text;
            string auxOperador = this.cmbOperador.Text;
            double resultado = Operar(auxNum1, auxNum2, auxOperador);
            this.lblResultado.Text = Convert.ToString(resultado);
            operarCount++;
            if(operarCount > 0)
            {
                binaryFlag = false;
            }

            

        }

        /// <summary>
        /// Controla el evento boton "Convertir a Binario"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if(binaryFlag == false)
            {
                this.lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
                binaryFlag = true;
            }
            
            
        }

        /// <summary>
        /// Controla el evento del boton "Convertir a Decimal"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
        }
    }
}
