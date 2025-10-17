using System;
using System.Threading.Tasks;
using EFV_GestionPlantilla.Models;
using EFV_GestionPlantilla.Pages;
using Wisej.Web;

namespace EFV_GestionPlantilla.Forms
{
    public partial class AltaJugadoraDialog : Wisej.Web.Form
    {
        public Jugadora NuevaJugadora { get; private set; }

        public AltaJugadoraDialog()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || numDorsal.Value < 0)
            {
                Wisej.Web.MessageBox.Show("Introduce un nombre y un dorsal válido.");
                return;
            }

            NuevaJugadora = new Jugadora
            {
                Nombre = txtNombre.Text,
                Dorsal = (int)numDorsal.Value
            };
            DialogResult = DialogResult.OK;
            Close();
        }

        private void AltaJugadoraDialog_Load(object sender, EventArgs e)
        {
            this.HeaderBackColor = System.Drawing.Color.DarkGreen;
            this.StartPosition= FormStartPosition.CenterParent;
        }
    }
}