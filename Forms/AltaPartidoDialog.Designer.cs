namespace EFV_GestionPlantilla.Forms
{
    partial class AltaPartidoDialog
    {
        private System.ComponentModel.IContainer components = null;

        private Wisej.Web.Label lblRival;
        private Wisej.Web.TextBox txtRival;
        private Wisej.Web.Label lblFecha;
        private Wisej.Web.DateTimePicker dateTimePickerFecha;
        private Wisej.Web.Label lblJugadoras;
        private Wisej.Web.CheckedListBox checkedListBoxJugadoras;
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
            this.lblRival = new Wisej.Web.Label();
            this.txtRival = new Wisej.Web.TextBox();
            this.lblFecha = new Wisej.Web.Label();
            this.dateTimePickerFecha = new Wisej.Web.DateTimePicker();
            this.lblJugadoras = new Wisej.Web.Label();
            this.checkedListBoxJugadoras = new Wisej.Web.CheckedListBox();
            this.btnGuardar = new Wisej.Web.Button();
            this.radioLocal = new Wisej.Web.RadioButton();
            this.radioVisitante = new Wisej.Web.RadioButton();
            this.SuspendLayout();
            // 
            // lblRival
            // 
            this.lblRival.Location = new System.Drawing.Point(20, 20);
            this.lblRival.Name = "lblRival";
            this.lblRival.Size = new System.Drawing.Size(80, 22);
            this.lblRival.TabIndex = 0;
            this.lblRival.Text = "Rival:";
            // 
            // txtRival
            // 
            this.txtRival.Location = new System.Drawing.Point(110, 20);
            this.txtRival.Name = "txtRival";
            this.txtRival.Size = new System.Drawing.Size(180, 22);
            this.txtRival.TabIndex = 1;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(20, 60);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(80, 22);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha:";
            // 
            // dateTimePickerFecha
            // 
            this.dateTimePickerFecha.Location = new System.Drawing.Point(110, 60);
            this.dateTimePickerFecha.Name = "dateTimePickerFecha";
            this.dateTimePickerFecha.Size = new System.Drawing.Size(180, 22);
            this.dateTimePickerFecha.TabIndex = 3;
            // 
            // lblJugadoras
            // 
            this.lblJugadoras.Location = new System.Drawing.Point(20, 172);
            this.lblJugadoras.Name = "lblJugadoras";
            this.lblJugadoras.Size = new System.Drawing.Size(196, 22);
            this.lblJugadoras.TabIndex = 4;
            this.lblJugadoras.Text = "Jugadoras convocadas:";
            // 
            // checkedListBoxJugadoras
            // 
            this.checkedListBoxJugadoras.Location = new System.Drawing.Point(20, 200);
            this.checkedListBoxJugadoras.Name = "checkedListBoxJugadoras";
            this.checkedListBoxJugadoras.Size = new System.Drawing.Size(576, 382);
            this.checkedListBoxJugadoras.TabIndex = 5;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(254, 606);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // radioLocal
            // 
            this.radioLocal.Checked = true;
            this.radioLocal.Location = new System.Drawing.Point(20, 108);
            this.radioLocal.Name = "radioLocal";
            this.radioLocal.Size = new System.Drawing.Size(62, 22);
            this.radioLocal.TabIndex = 7;
            this.radioLocal.TabStop = true;
            this.radioLocal.Text = "Local";
            // 
            // radioVisitante
            // 
            this.radioVisitante.Location = new System.Drawing.Point(110, 108);
            this.radioVisitante.Name = "radioVisitante";
            this.radioVisitante.Size = new System.Drawing.Size(80, 22);
            this.radioVisitante.TabIndex = 8;
            this.radioVisitante.Text = "Visitante";
            // 
            // AltaPartidoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 658);
            this.Controls.Add(this.radioVisitante);
            this.Controls.Add(this.radioLocal);
            this.Controls.Add(this.lblRival);
            this.Controls.Add(this.txtRival);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dateTimePickerFecha);
            this.Controls.Add(this.lblJugadoras);
            this.Controls.Add(this.checkedListBoxJugadoras);
            this.Controls.Add(this.btnGuardar);
            this.Name = "AltaPartidoDialog";
            this.Text = "Alta de Partido";
            this.Load += new System.EventHandler(this.AltaPartidoDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.RadioButton radioLocal;
        private Wisej.Web.RadioButton radioVisitante;
    }
}