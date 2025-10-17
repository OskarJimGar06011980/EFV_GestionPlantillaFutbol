using System;
using System.Collections.Generic;
using Wisej.Web;
using EFV_GestionPlantilla.Models;

namespace EFV_GestionPlantilla.Forms
{
    public partial class AltaPartidoDialog : Wisej.Web.Form
    {
        public Partido NuevoPartido { get; private set; }
        private List<Jugadora> jugadoras;

        public AltaPartidoDialog(List<Jugadora> jugadoras)
        {
            InitializeComponent();
            this.jugadoras = jugadoras;
            foreach (var j in jugadoras)
                checkedListBoxJugadoras.Items.Add(j.Nombre);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRival.Text) || checkedListBoxJugadoras.CheckedItems.Count == 0)
            {
                Wisej.Web.MessageBox.Show("Introduce el rival y selecciona al menos una jugadora.");
                return;
            }

            // 🆕 Determinar si es local o visitante
            string condicion = radioLocal.Checked ? "Local" : "Visitante";

            NuevoPartido = new Partido
            {
                Rival = txtRival.Text,
                Fecha = dateTimePickerFecha.Value,
                LocalVisitante = condicion,
                Resultado = string.Empty
            };

            foreach (var item in checkedListBoxJugadoras.CheckedItems)
            {
                var nombre = item.ToString();
                var jugadora = jugadoras.Find(j => j.Nombre == nombre);
                if (jugadora != null)
                {
                    NuevoPartido.Convocadas.Add(new Convocatoria
                    {
                        JugadoraId = jugadora.Id,
                        NombreJugadora = jugadora.Nombre,
                        Posicion = "Por definir",
                        MinutosJugados = 0
                    });
                }
            }

            DialogResult = DialogResult.OK;
            Close();


        }

        private void AltaPartidoDialog_Load(object sender, EventArgs e)
        {
            this.HeaderBackColor = System.Drawing.Color.DarkGreen;
            this.StartPosition = FormStartPosition.CenterParent;
        }
    }
}