namespace Pantallas
{
    partial class NuevaVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbListatiendas = new System.Windows.Forms.ComboBox();
            this.cmbListaArticulos = new System.Windows.Forms.ComboBox();
            this.lblMensajeSeleccionTienda = new System.Windows.Forms.Label();
            this.lblMensajeSeleccionArticulo = new System.Windows.Forms.Label();
            this.lblMensajeIngreseCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbListatiendas
            // 
            this.cmbListatiendas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListatiendas.FormattingEnabled = true;
            this.cmbListatiendas.Location = new System.Drawing.Point(52, 70);
            this.cmbListatiendas.Name = "cmbListatiendas";
            this.cmbListatiendas.Size = new System.Drawing.Size(330, 21);
            this.cmbListatiendas.TabIndex = 0;
            // 
            // cmbListaArticulos
            // 
            this.cmbListaArticulos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListaArticulos.FormattingEnabled = true;
            this.cmbListaArticulos.Location = new System.Drawing.Point(52, 151);
            this.cmbListaArticulos.Name = "cmbListaArticulos";
            this.cmbListaArticulos.Size = new System.Drawing.Size(330, 21);
            this.cmbListaArticulos.TabIndex = 1;
            // 
            // lblMensajeSeleccionTienda
            // 
            this.lblMensajeSeleccionTienda.AutoSize = true;
            this.lblMensajeSeleccionTienda.Location = new System.Drawing.Point(49, 37);
            this.lblMensajeSeleccionTienda.Name = "lblMensajeSeleccionTienda";
            this.lblMensajeSeleccionTienda.Size = new System.Drawing.Size(103, 13);
            this.lblMensajeSeleccionTienda.TabIndex = 2;
            this.lblMensajeSeleccionTienda.Text = "Seleccione la tienda";
            // 
            // lblMensajeSeleccionArticulo
            // 
            this.lblMensajeSeleccionArticulo.AutoSize = true;
            this.lblMensajeSeleccionArticulo.Location = new System.Drawing.Point(49, 117);
            this.lblMensajeSeleccionArticulo.Name = "lblMensajeSeleccionArticulo";
            this.lblMensajeSeleccionArticulo.Size = new System.Drawing.Size(109, 13);
            this.lblMensajeSeleccionArticulo.TabIndex = 3;
            this.lblMensajeSeleccionArticulo.Text = "Seleccione el Articulo";
            // 
            // lblMensajeIngreseCantidad
            // 
            this.lblMensajeIngreseCantidad.AutoSize = true;
            this.lblMensajeIngreseCantidad.Location = new System.Drawing.Point(49, 210);
            this.lblMensajeIngreseCantidad.Name = "lblMensajeIngreseCantidad";
            this.lblMensajeIngreseCantidad.Size = new System.Drawing.Size(150, 13);
            this.lblMensajeIngreseCantidad.TabIndex = 4;
            this.lblMensajeIngreseCantidad.Text = "Ingrese la cantidad solicitada: ";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(282, 210);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 5;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(164, 299);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(103, 37);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // NuevaVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 368);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblMensajeIngreseCantidad);
            this.Controls.Add(this.lblMensajeSeleccionArticulo);
            this.Controls.Add(this.lblMensajeSeleccionTienda);
            this.Controls.Add(this.cmbListaArticulos);
            this.Controls.Add(this.cmbListatiendas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NuevaVenta";
            this.ShowIcon = false;
            this.Text = "NuevaVenta";
            this.Load += new System.EventHandler(this.NuevaVenta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbListatiendas;
        private System.Windows.Forms.ComboBox cmbListaArticulos;
        private System.Windows.Forms.Label lblMensajeSeleccionTienda;
        private System.Windows.Forms.Label lblMensajeSeleccionArticulo;
        private System.Windows.Forms.Label lblMensajeIngreseCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnAceptar;
    }
}