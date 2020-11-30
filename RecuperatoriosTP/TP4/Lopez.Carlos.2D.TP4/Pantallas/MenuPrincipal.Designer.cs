namespace Pantallas
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCargarNuevoProducto = new System.Windows.Forms.Button();
            this.btnNuevaVenta = new System.Windows.Forms.Button();
            this.dgvVentasPendientes = new System.Windows.Forms.DataGridView();
            this.dgvVentasProcesadas = new System.Windows.Forms.DataGridView();
            this.lblMensajeVentasPendientes = new System.Windows.Forms.Label();
            this.lblVentasProcesadas = new System.Windows.Forms.Label();
            this.lblmensajeventas = new System.Windows.Forms.Label();
            this.lblMensajeTotalProcesadas = new System.Windows.Forms.Label();
            this.lblDatosMontoVentas = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasPendientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasProcesadas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCargarNuevoProducto
            // 
            this.btnCargarNuevoProducto.Location = new System.Drawing.Point(666, 150);
            this.btnCargarNuevoProducto.Name = "btnCargarNuevoProducto";
            this.btnCargarNuevoProducto.Size = new System.Drawing.Size(110, 45);
            this.btnCargarNuevoProducto.TabIndex = 0;
            this.btnCargarNuevoProducto.Text = "Cargar Nuevo Articulo";
            this.btnCargarNuevoProducto.UseVisualStyleBackColor = true;
            this.btnCargarNuevoProducto.Click += new System.EventHandler(this.btnCargarNuevoProducto_Click);
            // 
            // btnNuevaVenta
            // 
            this.btnNuevaVenta.Location = new System.Drawing.Point(666, 45);
            this.btnNuevaVenta.Name = "btnNuevaVenta";
            this.btnNuevaVenta.Size = new System.Drawing.Size(110, 48);
            this.btnNuevaVenta.TabIndex = 2;
            this.btnNuevaVenta.Text = "Cargar Nueva Venta";
            this.btnNuevaVenta.UseVisualStyleBackColor = true;
            this.btnNuevaVenta.Click += new System.EventHandler(this.btnNuevaVenta_Click);
            // 
            // dgvVentasPendientes
            // 
            this.dgvVentasPendientes.AllowUserToAddRows = false;
            this.dgvVentasPendientes.AllowUserToDeleteRows = false;
            this.dgvVentasPendientes.AllowUserToResizeColumns = false;
            this.dgvVentasPendientes.AllowUserToResizeRows = false;
            this.dgvVentasPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentasPendientes.Location = new System.Drawing.Point(16, 45);
            this.dgvVentasPendientes.Name = "dgvVentasPendientes";
            this.dgvVentasPendientes.RowHeadersVisible = false;
            this.dgvVentasPendientes.Size = new System.Drawing.Size(595, 150);
            this.dgvVentasPendientes.TabIndex = 3;
            // 
            // dgvVentasProcesadas
            // 
            this.dgvVentasProcesadas.AllowUserToAddRows = false;
            this.dgvVentasProcesadas.AllowUserToDeleteRows = false;
            this.dgvVentasProcesadas.AllowUserToResizeColumns = false;
            this.dgvVentasProcesadas.AllowUserToResizeRows = false;
            this.dgvVentasProcesadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentasProcesadas.Location = new System.Drawing.Point(16, 225);
            this.dgvVentasProcesadas.Name = "dgvVentasProcesadas";
            this.dgvVentasProcesadas.RowHeadersVisible = false;
            this.dgvVentasProcesadas.Size = new System.Drawing.Size(595, 150);
            this.dgvVentasProcesadas.TabIndex = 4;
            // 
            // lblMensajeVentasPendientes
            // 
            this.lblMensajeVentasPendientes.AutoSize = true;
            this.lblMensajeVentasPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajeVentasPendientes.Location = new System.Drawing.Point(12, 22);
            this.lblMensajeVentasPendientes.Name = "lblMensajeVentasPendientes";
            this.lblMensajeVentasPendientes.Size = new System.Drawing.Size(211, 20);
            this.lblMensajeVentasPendientes.TabIndex = 5;
            this.lblMensajeVentasPendientes.Text = "Ventas Externas Pendientes";
            // 
            // lblVentasProcesadas
            // 
            this.lblVentasProcesadas.AutoSize = true;
            this.lblVentasProcesadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentasProcesadas.Location = new System.Drawing.Point(12, 202);
            this.lblVentasProcesadas.Name = "lblVentasProcesadas";
            this.lblVentasProcesadas.Size = new System.Drawing.Size(215, 20);
            this.lblVentasProcesadas.TabIndex = 6;
            this.lblVentasProcesadas.Text = "Ventas Externas Procesadas";
            // 
            // lblmensajeventas
            // 
            this.lblmensajeventas.AutoSize = true;
            this.lblmensajeventas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmensajeventas.Location = new System.Drawing.Point(312, 22);
            this.lblmensajeventas.Name = "lblmensajeventas";
            this.lblmensajeventas.Size = new System.Drawing.Size(0, 20);
            this.lblmensajeventas.TabIndex = 7;
            // 
            // lblMensajeTotalProcesadas
            // 
            this.lblMensajeTotalProcesadas.AutoSize = true;
            this.lblMensajeTotalProcesadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajeTotalProcesadas.Location = new System.Drawing.Point(617, 258);
            this.lblMensajeTotalProcesadas.Name = "lblMensajeTotalProcesadas";
            this.lblMensajeTotalProcesadas.Size = new System.Drawing.Size(179, 15);
            this.lblMensajeTotalProcesadas.TabIndex = 8;
            this.lblMensajeTotalProcesadas.Text = "Monto total Ventas Procesadas:";
            // 
            // lblDatosMontoVentas
            // 
            this.lblDatosMontoVentas.AutoSize = true;
            this.lblDatosMontoVentas.Location = new System.Drawing.Point(646, 298);
            this.lblDatosMontoVentas.Name = "lblDatosMontoVentas";
            this.lblDatosMontoVentas.Size = new System.Drawing.Size(13, 13);
            this.lblDatosMontoVentas.TabIndex = 9;
            this.lblDatosMontoVentas.Text = "0";
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 394);
            this.Controls.Add(this.lblDatosMontoVentas);
            this.Controls.Add(this.lblMensajeTotalProcesadas);
            this.Controls.Add(this.lblmensajeventas);
            this.Controls.Add(this.lblVentasProcesadas);
            this.Controls.Add(this.lblMensajeVentasPendientes);
            this.Controls.Add(this.dgvVentasProcesadas);
            this.Controls.Add(this.dgvVentasPendientes);
            this.Controls.Add(this.btnNuevaVenta);
            this.Controls.Add(this.btnCargarNuevoProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MenuPrincipal";
            this.ShowIcon = false;
            this.Text = "Menu Principal";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasPendientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasProcesadas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCargarNuevoProducto;
        private System.Windows.Forms.Button btnNuevaVenta;
        private System.Windows.Forms.DataGridView dgvVentasPendientes;
        private System.Windows.Forms.DataGridView dgvVentasProcesadas;
        private System.Windows.Forms.Label lblMensajeVentasPendientes;
        private System.Windows.Forms.Label lblVentasProcesadas;
        private System.Windows.Forms.Label lblmensajeventas;
        private System.Windows.Forms.Label lblMensajeTotalProcesadas;
        private System.Windows.Forms.Label lblDatosMontoVentas;
    }
}

