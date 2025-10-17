namespace EFV_GestionPlantilla.Forms
{
    partial class AltaJugadoraDialog
    {
        private System.ComponentModel.IContainer components = null;

        private Wisej.Web.Label lblNombre;
        private Wisej.Web.TextBox txtNombre;
        private Wisej.Web.Label lblDorsal;
        private Wisej.Web.NumericUpDown numDorsal;
        private Wisej.Web.Button btnGuardar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Wisej Designer generated code

        private void InitializeComponent()
        {
            this.lblNombre = new Wisej.Web.Label();
            this.txtNombre = new Wisej.Web.TextBox();
            this.lblDorsal = new Wisej.Web.Label();
            this.numDorsal = new Wisej.Web.NumericUpDown();
            this.btnGuardar = new Wisej.Web.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDorsal)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(20, 20);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(80, 22);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(110, 20);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(180, 22);
            this.txtNombre.TabIndex = 1;
            // 
            // lblDorsal
            // 
            this.lblDorsal.Location = new System.Drawing.Point(20, 60);
            this.lblDorsal.Name = "lblDorsal";
            this.lblDorsal.Size = new System.Drawing.Size(80, 22);
            this.lblDorsal.TabIndex = 2;
            this.lblDorsal.Text = "Dorsal:";
            // 
            // numDorsal
            // 
            this.numDorsal.Location = new System.Drawing.Point(110, 60);
            this.numDorsal.Minimum = new decimal(1);
            this.numDorsal.Name = "numDorsal";
            this.numDorsal.Size = new System.Drawing.Size(80, 22);
            this.numDorsal.TabIndex = 3;
            this.numDorsal.Value = new decimal(1);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(110, 100);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // AltaJugadoraDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 150);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblDorsal);
            this.Controls.Add(this.numDorsal);
            this.Controls.Add(this.btnGuardar);
            this.Name = "AltaJugadoraDialog";
            this.Text = "Alta de Jugadora";
            this.Load += new System.EventHandler(this.AltaJugadoraDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDorsal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}