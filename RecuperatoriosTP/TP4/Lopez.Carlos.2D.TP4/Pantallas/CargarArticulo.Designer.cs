namespace Pantallas
{
    partial class CargarArticulo
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
            this.lblMensajeNombreArticulo = new System.Windows.Forms.Label();
            this.lblMensajeCantidad = new System.Windows.Forms.Label();
            this.lblMensajePrecio = new System.Windows.Forms.Label();
            this.txtNombreArticulo = new System.Windows.Forms.TextBox();
            this.txtCantidadArticulo = new System.Windows.Forms.TextBox();
            this.txtPrecioUnitario = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cmbTipoArticulo = new System.Windows.Forms.ComboBox();
            this.lblMensajeTipoArticulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMensajeNombreArticulo
            // 
            this.lblMensajeNombreArticulo.AutoSize = true;
            this.lblMensajeNombreArticulo.Location = new System.Drawing.Point(12, 73);
            this.lblMensajeNombreArticulo.Name = "lblMensajeNombreArticulo";
            this.lblMensajeNombreArticulo.Size = new System.Drawing.Size(145, 13);
            this.lblMensajeNombreArticulo.TabIndex = 0;
            this.lblMensajeNombreArticulo.Text = "Ingrese el nombre del articulo";
            // 
            // lblMensajeCantidad
            // 
            this.lblMensajeCantidad.AutoSize = true;
            this.lblMensajeCantidad.Location = new System.Drawing.Point(12, 158);
            this.lblMensajeCantidad.Name = "lblMensajeCantidad";
            this.lblMensajeCantidad.Size = new System.Drawing.Size(151, 13);
            this.lblMensajeCantidad.TabIndex = 1;
            this.lblMensajeCantidad.Text = "Ingrese la cantidad del articulo";
            // 
            // lblMensajePrecio
            // 
            this.lblMensajePrecio.AutoSize = true;
            this.lblMensajePrecio.Location = new System.Drawing.Point(12, 214);
            this.lblMensajePrecio.Name = "lblMensajePrecio";
            this.lblMensajePrecio.Size = new System.Drawing.Size(122, 13);
            this.lblMensajePrecio.TabIndex = 2;
            this.lblMensajePrecio.Text = "Ingrese el precio unitario";
            // 
            // txtNombreArticulo
            // 
            this.txtNombreArticulo.Location = new System.Drawing.Point(185, 70);
            this.txtNombreArticulo.Name = "txtNombreArticulo";
            this.txtNombreArticulo.Size = new System.Drawing.Size(176, 20);
            this.txtNombreArticulo.TabIndex = 3;
            // 
            // txtCantidadArticulo
            // 
            this.txtCantidadArticulo.Location = new System.Drawing.Point(185, 158);
            this.txtCantidadArticulo.Name = "txtCantidadArticulo";
            this.txtCantidadArticulo.Size = new System.Drawing.Size(176, 20);
            this.txtCantidadArticulo.TabIndex = 4;
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.Location = new System.Drawing.Point(185, 214);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Size = new System.Drawing.Size(176, 20);
            this.txtPrecioUnitario.TabIndex = 5;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(125, 311);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(96, 34);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cmbTipoArticulo
            // 
            this.cmbTipoArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoArticulo.FormattingEnabled = true;
            this.cmbTipoArticulo.Location = new System.Drawing.Point(185, 261);
            this.cmbTipoArticulo.Name = "cmbTipoArticulo";
            this.cmbTipoArticulo.Size = new System.Drawing.Size(176, 21);
            this.cmbTipoArticulo.TabIndex = 7;
            // 
            // lblMensajeTipoArticulo
            // 
            this.lblMensajeTipoArticulo.AutoSize = true;
            this.lblMensajeTipoArticulo.Location = new System.Drawing.Point(12, 269);
            this.lblMensajeTipoArticulo.Name = "lblMensajeTipoArticulo";
            this.lblMensajeTipoArticulo.Size = new System.Drawing.Size(143, 13);
            this.lblMensajeTipoArticulo.TabIndex = 8;
            this.lblMensajeTipoArticulo.Text = "Seleccione el tipo de articulo";
            // 
            // CargarArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 372);
            this.Controls.Add(this.lblMensajeTipoArticulo);
            this.Controls.Add(this.cmbTipoArticulo);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtPrecioUnitario);
            this.Controls.Add(this.txtCantidadArticulo);
            this.Controls.Add(this.txtNombreArticulo);
            this.Controls.Add(this.lblMensajePrecio);
            this.Controls.Add(this.lblMensajeCantidad);
            this.Controls.Add(this.lblMensajeNombreArticulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CargarArticulo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CargarArticulo";
            this.Load += new System.EventHandler(this.CargarArticulo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMensajeNombreArticulo;
        private System.Windows.Forms.Label lblMensajeCantidad;
        private System.Windows.Forms.Label lblMensajePrecio;
        private System.Windows.Forms.TextBox txtNombreArticulo;
        private System.Windows.Forms.TextBox txtCantidadArticulo;
        private System.Windows.Forms.TextBox txtPrecioUnitario;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cmbTipoArticulo;
        private System.Windows.Forms.Label lblMensajeTipoArticulo;
    }
}