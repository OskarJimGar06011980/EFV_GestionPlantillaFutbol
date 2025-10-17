using EFV_GestionPlantilla.Models;
using EFV_GestionPlantilla.Pages;
using System;
using System.Drawing;
using System.Threading.Tasks;
using Wisej.Web;

namespace EFV_GestionPlantilla.Forms
{
    public partial class IntroducirResultadoDialog : Wisej.Web.Form
    {
        private Partido partido;
        private NumericUpDown numericLocal;
        private NumericUpDown numericVisitante;
        private Button btnGuardar;

        public IntroducirResultadoDialog(Partido partido)
        {
           
            InitializeComponent();

            this.partido = partido;

            this.Text = "Introducir Resultado";
            this.Size = new Size(700, 400); // Más grande para mejor visualización

            // Panel principal
            var panel = new Wisej.Web.Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };
            this.Controls.Add(panel);

            // GroupBox para contener resultado
            var groupBox = new Wisej.Web.GroupBox
            {
                Text = "Resultado",
                Dock = DockStyle.Top,
                Height = 250
            };
            panel.Controls.Add(groupBox);

            // TableLayoutPanel para alinear controles
            var table = new Wisej.Web.TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2,
                AutoSize = true,
                Padding = new Padding(20)
            };
            groupBox.Controls.Add(table);

            // Crear labels y numericUpDown
            Label lblLocal = new Label { AutoSize = true, Font = new Font("Segoe UI", 12, FontStyle.Bold) };
            Label lblVisitante = new Label { AutoSize = true, Font = new Font("Segoe UI", 12, FontStyle.Bold) };

            numericLocal = new NumericUpDown { Minimum = 0, Value = 0, Width = 60 };
            numericVisitante = new NumericUpDown { Minimum = 0, Value = 0, Width = 60 };

            if (partido.LocalVisitante == "Local")
            {
                lblLocal.Text = "Esc.Valdemoro Fem.Cadete";
                lblVisitante.Text = partido.Rival;
            }
            else
            {
                lblLocal.Text = partido.Rival;
                lblVisitante.Text = "Esc.Valdemoro Fem.Cadete";
            }

            // Añadir controles al TableLayoutPanel
            table.Controls.Add(lblLocal, 0, 0);
            table.Controls.Add(lblVisitante, 1, 0);
            table.Controls.Add(numericLocal, 0, 1);
            table.Controls.Add(numericVisitante, 1, 1);

            // Separación entre columnas
            table.ColumnStyles.Add(new Wisej.Web.ColumnStyle(SizeType.Percent, 50F));
            table.ColumnStyles.Add(new Wisej.Web.ColumnStyle(SizeType.Percent, 50F));

            // Botón Guardar centrado abajo
            var btnGuardar = new Wisej.Web.Button
            {
                Text = "Guardar",
                Width = 120,
                Height = 40,
                Anchor = AnchorStyles.None
            };
            btnGuardar.Click += btnGuardar_Click;

            // Panel para centrar botón
            var panelBoton = new Wisej.Web.Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60
            };
            panelBoton.Controls.Add(btnGuardar);
            panel.Controls.Add(panelBoton);

            // Centrar botón dentro del panel
            btnGuardar.Location = new Point((panelBoton.ClientSize.Width - btnGuardar.Width) / 2, 10);


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            partido.Resultado = $"{numericLocal.Value} - {numericVisitante.Value}";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void IntroducirResultadoDialog_Load(object sender, EventArgs e)
        {
            this.HeaderBackColor = System.Drawing.Color.DarkGreen;
            this.StartPosition = FormStartPosition.CenterParent;
        }
    }
}