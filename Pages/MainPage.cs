
using EFV_GestionPlantilla.Data;
using EFV_GestionPlantilla.Forms;
using EFV_GestionPlantilla.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Wisej.Web;

namespace EFV_GestionPlantilla.Pages
{
    public partial class MainPage : Wisej.Web.Page
    {
        private List<Jugadora> jugadoras;
        private List<Partido> partidos;
        private Partido partidoSeleccionado;
        private AlineacionDialog alineacionDialog;
        // Variables de clase para mantener las imágenes en memoria
        private System.Drawing.Image yellowCardImage;
        private System.Drawing.Image redCardImage;
        public MainPage()
        {
            InitializeComponent();

            this.BackColor = System.Drawing.Color.LightBlue; // Color de fondo

            dataGridViewConvocadas.CellValueChanged += dataGridViewConvocadas_CellValueChanged;

            dataGridViewJugadoras.BackColor = System.Drawing.Color.LightBlue; // Fondo general del control

            dataGridViewJugadoras.DefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue; // Fondo de celdas
            dataGridViewJugadoras.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;

            dataGridViewJugadoras.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SteelBlue; // Fondo de encabezado
            dataGridViewJugadoras.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;

            dataGridViewPartidos.BackColor = System.Drawing.Color.LightBlue; // Fondo general del control

            dataGridViewPartidos.DefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue; // Fondo de celdas
            dataGridViewPartidos.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;

            dataGridViewPartidos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SteelBlue; // Fondo de encabezado
            dataGridViewPartidos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;

            dataGridViewConvocadas.BackColor = System.Drawing.Color.LightBlue; // Fondo general del control

            dataGridViewConvocadas.DefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue; // Fondo de celdas
            dataGridViewConvocadas.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;

            dataGridViewConvocadas.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SteelBlue; // Fondo de encabezado
            dataGridViewConvocadas.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;


            dataGridViewConvocadas.DefaultCellStyle.Alignment = Wisej.Web.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewConvocadas.ColumnHeadersDefaultCellStyle.Alignment = Wisej.Web.DataGridViewContentAlignment.MiddleCenter;

            dataGridViewJugadoras.DefaultCellStyle.Alignment = Wisej.Web.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewJugadoras.ColumnHeadersDefaultCellStyle.Alignment = Wisej.Web.DataGridViewContentAlignment.MiddleCenter;

            dataGridViewPartidos.DefaultCellStyle.Alignment = Wisej.Web.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewPartidos.ColumnHeadersDefaultCellStyle.Alignment = Wisej.Web.DataGridViewContentAlignment.MiddleCenter;

            
            CargarDatos();
            MostrarJugadoras();
            MostrarPartidos();

            dataGridViewJugadoras.DefaultCellStyle.Font = new Font("Segoe UI", 10); // tamaño 10
            dataGridViewPartidos.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewConvocadas.DefaultCellStyle.Font = new Font("Segoe UI", 10);
        }

     
        private void CargarDatos()
        {
            jugadoras = EquipoData.CargarJugadoras();
            partidos = EquipoData.CargarPartidos();
        }



        private void ActualizarTotalesTarjetas()
        {
            foreach (Wisej.Web.DataGridViewRow row in dataGridViewJugadoras.Rows)
            {
                if (row.Cells["Id"].Value == null) continue;

                // Convertir el valor a Guid
                Guid jugadoraId = (Guid)row.Cells["Id"].Value;

                // Obtener todas las convocatorias de esa jugadora
                var convocadas = partidos
                    .SelectMany(p => p.Convocadas)
                    .Where(c => c.JugadoraId == jugadoraId) // ✅ ahora ambos son Guid
                    .ToList();

                // Contar tarjetas
                int tarjetasAmarillas = convocadas.Count(c => string.Equals(c.Tarjeta, "Amarilla", StringComparison.OrdinalIgnoreCase));
                int tarjetasRojas = convocadas.Count(c => string.Equals(c.Tarjeta, "Roja", StringComparison.OrdinalIgnoreCase));

                // Actualizar celdas
                row.Cells["TarjetasAmarillas"].Value = tarjetasAmarillas;
                row.Cells["TarjetasRojas"].Value = tarjetasRojas;
            }
        }

        private void MostrarJugadoras()
        {
            dataGridViewJugadoras.DataSource = null;

            var listaConEstadisticas = jugadoras.Select(j =>
            {
                var convocadas = partidos.SelectMany(p => p.Convocadas)
                                         .Where(c => c.JugadoraId == j.Id)
                                         .ToList();

                int partidosConvocado = convocadas.Count;
                int nTitularidades = convocadas.Count(c => string.Equals(c.Condicion, "Titular", StringComparison.OrdinalIgnoreCase));
                int totalMinutos = convocadas.Sum(c => c.MinutosJugados);
                double mediaMinutos = partidosConvocado > 0 ? (double)totalMinutos / partidosConvocado : 0;

                int tarjetasAmarillas = convocadas.Count(c => string.Equals(c.Tarjeta, "Amarilla", StringComparison.OrdinalIgnoreCase));
                int tarjetasRojas = convocadas.Count(c => string.Equals(c.Tarjeta, "Roja", StringComparison.OrdinalIgnoreCase));

                int totalGoles = convocadas.Sum(c => c.Goles); //  suma de goles por jugadora

                return new
                {
                    j.Id, // <-- clave para actualizar correctamente
                    j.Nombre,
                    j.Dorsal,
                    PartidosConvocado = partidosConvocado,
                    NTitularidades = nTitularidades,
                    TotalMinutosJugados = totalMinutos,
                    MediaMinutosJugados = mediaMinutos,
                    TarjetasAmarillas = tarjetasAmarillas,
                    TarjetasRojas = tarjetasRojas,
                    TotalGoles = totalGoles
                };
            }).ToList();

            dataGridViewJugadoras.DataSource = listaConEstadisticas;

            // Configurar encabezados
            dataGridViewJugadoras.Columns["Nombre"].HeaderText = "Nombre";
            dataGridViewJugadoras.Columns["Dorsal"].HeaderText = "Dorsal";
            dataGridViewJugadoras.Columns["PartidosConvocado"].HeaderText = "Partidos Convocado";
            dataGridViewJugadoras.Columns["NTitularidades"].HeaderText = "NºTitularidades";
            dataGridViewJugadoras.Columns["TotalGoles"].HeaderText = "Goles";
            dataGridViewJugadoras.Columns["TotalMinutosJugados"].HeaderText = "Total Minutos Jugados";
            dataGridViewJugadoras.Columns["MediaMinutosJugados"].HeaderText = "Media Minutos Jugados";
            dataGridViewJugadoras.Columns["TarjetasAmarillas"].HeaderText = "Tarjetas Amarillas";
            dataGridViewJugadoras.Columns["TarjetasRojas"].HeaderText = "Tarjetas Rojas";

           

            // Anchos fijos
            dataGridViewJugadoras.Columns["Dorsal"].Width = 80;
            dataGridViewJugadoras.Columns["Dorsal"].AutoSizeMode = Wisej.Web.DataGridViewAutoSizeColumnMode.None;

            dataGridViewJugadoras.Columns["Nombre"].Width = 160;
            dataGridViewJugadoras.Columns["Nombre"].AutoSizeMode = Wisej.Web.DataGridViewAutoSizeColumnMode.None;

            dataGridViewJugadoras.Columns["PartidosConvocado"].Width = 140;
            dataGridViewJugadoras.Columns["PartidosConvocado"].AutoSizeMode = Wisej.Web.DataGridViewAutoSizeColumnMode.None;

            dataGridViewJugadoras.Columns["NTitularidades"].Width = 120;
            dataGridViewJugadoras.Columns["NTitularidades"].AutoSizeMode = Wisej.Web.DataGridViewAutoSizeColumnMode.None;

            dataGridViewJugadoras.Columns["TotalMinutosJugados"].Width = 170;
            dataGridViewJugadoras.Columns["TotalMinutosJugados"].AutoSizeMode = Wisej.Web.DataGridViewAutoSizeColumnMode.None;

            dataGridViewJugadoras.Columns["MediaMinutosJugados"].Width = 170;
            dataGridViewJugadoras.Columns["MediaMinutosJugados"].AutoSizeMode = Wisej.Web.DataGridViewAutoSizeColumnMode.None;



            dataGridViewJugadoras.Columns["TarjetasAmarillas"].Width = 120;
            dataGridViewJugadoras.Columns["TarjetasAmarillas"].AutoSizeMode = Wisej.Web.DataGridViewAutoSizeColumnMode.None;

            dataGridViewJugadoras.Columns["TarjetasRojas"].Width = 120;
            dataGridViewJugadoras.Columns["TarjetasRojas"].AutoSizeMode = Wisej.Web.DataGridViewAutoSizeColumnMode.None;

            dataGridViewJugadoras.Columns["TotalGoles"].Width = 100;
            dataGridViewJugadoras.Columns["TotalGoles"].AutoSizeMode = Wisej.Web.DataGridViewAutoSizeColumnMode.None;

            // Estilos generales
            dataGridViewJugadoras.AutoSizeColumnsMode = Wisej.Web.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewJugadoras.RowTemplate.Height = 40;
            dataGridViewJugadoras.Font = new System.Drawing.Font("Segoe UI", 14);

            // Centrar texto
            foreach (Wisej.Web.DataGridViewColumn col in dataGridViewJugadoras.Columns)
                col.DefaultCellStyle.Alignment = Wisej.Web.DataGridViewContentAlignment.MiddleCenter;

            // Reordenar columnas
            dataGridViewJugadoras.Columns["Dorsal"].DisplayIndex = 0;
            dataGridViewJugadoras.Columns["Nombre"].DisplayIndex = 1;
            dataGridViewJugadoras.Columns["PartidosConvocado"].DisplayIndex = 2;
            dataGridViewJugadoras.Columns["NTitularidades"].DisplayIndex = 3;
            dataGridViewJugadoras.Columns["TotalGoles"].DisplayIndex = 4;
            dataGridViewJugadoras.Columns["TotalMinutosJugados"].DisplayIndex = 5;
            dataGridViewJugadoras.Columns["MediaMinutosJugados"].DisplayIndex = 6;
            dataGridViewJugadoras.Columns["TarjetasAmarillas"].DisplayIndex = 7;
            dataGridViewJugadoras.Columns["TarjetasRojas"].DisplayIndex = 8;

            if (dataGridViewJugadoras.Columns.Contains("Id"))
                dataGridViewJugadoras.Columns["Id"].Visible = false;

            // Configuración de columnas igual que antes...

            // 🔹 Actualizamos totales para reflejar cualquier cambio previo
            ActualizarTotalesTarjetas();
        }
     
        private void MostrarPartidos()
        {
            dataGridViewPartidos.AutoGenerateColumns = false;
            dataGridViewPartidos.DataSource = null;
            dataGridViewPartidos.Columns.Clear();

            var colRival = new Wisej.Web.DataGridViewTextBoxColumn
            {
                Name = "Rival",
                DataPropertyName = "Rival",
                HeaderText = "Rival",
                Width = 250, // ancho en píxeles
                AutoSizeMode = Wisej.Web.DataGridViewAutoSizeColumnMode.None
            };

            var colFecha = new Wisej.Web.DataGridViewTextBoxColumn
            {
                Name = "Fecha",
                DataPropertyName = "Fecha",
                HeaderText = "Fecha",
                Width = 150, // ancho en píxeles
                AutoSizeMode = Wisej.Web.DataGridViewAutoSizeColumnMode.None
            };

            var colLocalVisitante = new Wisej.Web.DataGridViewTextBoxColumn
            {
                Name = "LocalVisitante",
                DataPropertyName = "LocalVisitante",
                HeaderText = "Local/Visitante",
                Width = 150, // ancho en píxeles
                AutoSizeMode = Wisej.Web.DataGridViewAutoSizeColumnMode.None
            };

            var colResultado = new Wisej.Web.DataGridViewTextBoxColumn
            {
                Name = "Resultado",
                DataPropertyName = "Resultado",
                HeaderText = "Resultado",
                Width = 120, // ancho en píxeles
                AutoSizeMode = Wisej.Web.DataGridViewAutoSizeColumnMode.None
            };

            var colConv = new Wisej.Web.DataGridViewTextBoxColumn
            {
                Name = "Convocadas",
                DataPropertyName = "ConvocadasCount",
                HeaderText = "Convocadas"
            };

            dataGridViewPartidos.Columns.AddRange(new Wisej.Web.DataGridViewColumn[]
            {
        colRival, colFecha, colLocalVisitante, colConv, colResultado
            });

            dataGridViewPartidos.DataSource = partidos;

         
            dataGridViewPartidos.RowTemplate.Height = 40;
            dataGridViewPartidos.Font = new System.Drawing.Font("Segoe UI", 14);

            dataGridViewPartidos.CellFormatting -= DataGridViewPartidos_CellFormatting;
            dataGridViewPartidos.CellFormatting += DataGridViewPartidos_CellFormatting;
        }


        private async void btnAltaJugadora_Click(object sender, EventArgs e)
        {
            var dlg = new AltaJugadoraDialog();
            var result = await dlg.ShowDialogAsync(null);
            if (result != Wisej.Web.DialogResult.OK)
            {
                return;
            }
            jugadoras.Add(dlg.NuevaJugadora);
            EquipoData.GuardarJugadoras(jugadoras);
            MostrarJugadoras();
        }

        private void btnBajaJugadora_Click(object sender, EventArgs e)
        {
            if (dataGridViewJugadoras.CurrentRow == null) return;
            var jugadora = (Jugadora)dataGridViewJugadoras.CurrentRow.DataBoundItem;
            if (Wisej.Web.MessageBox.Show($"¿Eliminar a {jugadora.Nombre}?", "Confirmar", Wisej.Web.MessageBoxButtons.YesNo) == Wisej.Web.DialogResult.Yes)
            {
                jugadoras.Remove(jugadora);
                EquipoData.GuardarJugadoras(jugadoras);
                MostrarJugadoras();
            }
        }

        private async void btnAltaPartido_Click(object sender, EventArgs e)
        {
            var dlg = new AltaPartidoDialog(jugadoras);
            var result = await dlg.ShowDialogAsync(null);
            if (result == Wisej.Web.DialogResult.OK)
            {
                partidos.Add(dlg.NuevoPartido);
                EquipoData.GuardarPartidos(partidos);
                MostrarPartidos();
            }
        }

        private void dataGridViewPartidos_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridViewPartidos.CurrentRow == null || dataGridViewPartidos.Rows.Count == 0)
                return;

            if (!dataGridViewPartidos.Columns.Contains("Rival") || !dataGridViewPartidos.Columns.Contains("Fecha"))
                return;

            var rival = dataGridViewPartidos.CurrentRow.Cells["Rival"].Value?.ToString();
            var fechaValor = dataGridViewPartidos.CurrentRow.Cells["Fecha"].Value?.ToString();

            if (string.IsNullOrEmpty(rival) || string.IsNullOrEmpty(fechaValor))
                return;

            if (!DateTime.TryParse(fechaValor, out var fecha))
                return;

            var partido = partidos.FirstOrDefault(p => p.Rival == rival && p.Fecha.Date == fecha.Date);
            if (partido != null)
                MostrarConvocadas(partido);
            else
                dataGridViewConvocadas.DataSource = null;

        }


        private void MostrarConvocadas(Partido partido)
        {
            partidoSeleccionado = partido;

            dataGridViewConvocadas.DataSource = null;
            dataGridViewConvocadas.Columns.Clear();

            // 🔹 Desactivar generación automática de columnas
            dataGridViewConvocadas.AutoGenerateColumns = false;

            // ======== Nombre ========
            var colNombre = new Wisej.Web.DataGridViewTextBoxColumn()
            {
                Name = "NombreJugadora",
                HeaderText = "Nombre",
                DataPropertyName = "NombreJugadora",
                ReadOnly = true
            };
            dataGridViewConvocadas.Columns.Add(colNombre);

            // ======== Minutos ========
            var colMinutos = new Wisej.Web.DataGridViewTextBoxColumn()
            {
                Name = "MinutosJugados",
                HeaderText = "Minutos",
                DataPropertyName = "MinutosJugados",
                ReadOnly = false,
                Width = 100
            };
            dataGridViewConvocadas.Columns.Add(colMinutos);

            // ======== Goles ========
            var colGoles = new Wisej.Web.DataGridViewTextBoxColumn()
            {
                Name = "Goles",
                HeaderText = "Goles",
                DataPropertyName = "Goles",
                ReadOnly = false,
                Width = 100
            };
            dataGridViewConvocadas.Columns.Add(colGoles);

            // ======== Titular/Suplente ========
            var colCondicion = new Wisej.Web.DataGridViewComboBoxColumn()
            {
                Name = "Titular/Suplente",
                HeaderText = "Titular/Suplente",
                DataPropertyName = "Condicion",
                ReadOnly = false
            };
            colCondicion.Items.AddRange(new object[] { "Sin definir", "Titular", "Suplente" });
            dataGridViewConvocadas.Columns.Add(colCondicion);

            // ======== Posición ========
            var colPosicion = new Wisej.Web.DataGridViewComboBoxColumn()
            {
                Name = "Posicion",
                HeaderText = "Posición",
                DataPropertyName = "Posicion",
                ReadOnly = false
            };
            colPosicion.Items.AddRange(new object[]
            {
        "Sin definir",
        "Portero",
        "Lateral Derecho",
        "Lateral Izquierdo",
        "Medio",
        "MediaPunta",
        "Extremo Derecho",
        "Extremo Izquierdo",
        "Delantero"
            });
            dataGridViewConvocadas.Columns.Add(colPosicion);

            // ======== Tarjetas ========
            var colTarjetas = new Wisej.Web.DataGridViewComboBoxColumn()
            {
                Name = "Tarjetas",
                HeaderText = "Tarjetas",
                DataPropertyName = "Tarjeta",
                Width = 120,
                ReadOnly = false
            };
            colTarjetas.Items.AddRange(new object[] { "", "Amarilla", "Roja" });
            dataGridViewConvocadas.Columns.Add(colTarjetas);

            // ======== Asignar datasource ========
            dataGridViewConvocadas.DataSource = partido.Convocadas;

            // 🔸 Aquí va el bloque de EVENTOS (muy importante)
            // Evitar duplicar handlers
            dataGridViewConvocadas.CellValueChanged -= dataGridViewConvocadas_CellValueChanged;
            dataGridViewConvocadas.CellValueChanged += dataGridViewConvocadas_CellValueChanged;

         

            // ======== Estilos ========
            dataGridViewConvocadas.AutoSizeColumnsMode = Wisej.Web.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewConvocadas.RowTemplate.Height = 40;
            dataGridViewConvocadas.Font = new System.Drawing.Font("Segoe UI", 14);
            dataGridViewConvocadas.DefaultCellStyle.Alignment = Wisej.Web.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewConvocadas.ColumnHeadersDefaultCellStyle.Alignment = Wisej.Web.DataGridViewContentAlignment.MiddleCenter;

            // ======== Evento de formato de celdas ========
            dataGridViewConvocadas.CellFormatting -= DataGridViewConvocadas_CellFormatting;
            dataGridViewConvocadas.CellFormatting += DataGridViewConvocadas_CellFormatting;
        }

      

        // -----------------------------
        // CellFormatting: mostrar imagenes en la celda sin cambiar el valor real
        // -----------------------------
        private void DataGridViewConvocadas_CellFormatting(object sender, Wisej.Web.DataGridViewCellFormattingEventArgs e)
        {
            // evita índices inválidos
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = dataGridViewConvocadas.Columns[e.ColumnIndex];

            // Titular/Suplente: color de fondo
            if (col.Name == "Titular/Suplente")
            {
                var valor = (e.Value ?? string.Empty).ToString();
                switch (valor)
                {
                    case "Titular": e.CellStyle.BackColor = System.Drawing.Color.LightGreen; break;
                    case "Suplente": e.CellStyle.BackColor = System.Drawing.Color.LightYellow; break;
                    default: e.CellStyle.BackColor = System.Drawing.Color.LightGray; break;
                }
            }

            // Tarjetas: mostramos la imagen visualmente, manteniendo el valor string
            if (col.Name == "Tarjetas")
            {
                // Limpiar estilo previo
                e.CellStyle.BackgroundImage = null;

                var val = (e.Value ?? string.Empty).ToString();

                switch (val)
                {
                    case "Amarilla": e.CellStyle.BackColor = System.Drawing.Color.Yellow; break;
                    case "Roja": e.CellStyle.BackColor = System.Drawing.Color.Red; break;
                    default: e.CellStyle.BackColor = System.Drawing.Color.White; break;
                }
          

            }
        }


      
        private void dataGridViewConvocadas_CellValueChanged(object sender, Wisej.Web.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var cell = dataGridViewConvocadas.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var convocatoria = dataGridViewConvocadas.Rows[e.RowIndex].DataBoundItem as Convocatoria;
            if (convocatoria == null) return;

            // Actualizamos el valor real en la convocatoria
            if (dataGridViewConvocadas.Columns[e.ColumnIndex].Name == "Tarjetas")
            {
                var valor = cell.Value?.ToString() ?? "";
                convocatoria.Tarjeta = valor; // 🔹 esto es crucial
            }

            // Estilos visuales (opcional)
            if (dataGridViewConvocadas.Columns[e.ColumnIndex].Name == "Tarjetas")
            {
                switch (cell.Value?.ToString())
                {
                    case "Amarilla": cell.Style.BackColor = Color.Yellow; break;
                    case "Roja": cell.Style.BackColor = Color.Red; break;
                    default: cell.Style.BackColor = Color.White; break;
                }

                // REFRESCAR TODO EL DATAGRIDVIEW DE JUGADORAS
                MostrarJugadoras(); // ✅ reemplaza a ActualizarTotalesTarjetas()
            }

            // 🔹 Actualizamos Goles y los balones en Alineación
            if ((dataGridViewConvocadas.Columns[e.ColumnIndex].Name == "Goles"))
            {
                int goles = 0;
                int.TryParse(cell.Value?.ToString(), out goles);
                convocatoria.Goles = goles;

                // Llamar al método de AlineacionDialog que dibuja los balones
                if (alineacionDialog != null && alineacionDialog.Visible)
                {
                    alineacionDialog.ActualizarBalonesEnAlineacion(convocatoria.NombreJugadora, goles);
                }
            }

            // Guardar cambios en la lista de partidos
            if (partidoSeleccionado != null)
                EquipoData.GuardarPartidos(partidos);
           

        }


        private void btnBajaPartido_Click(object sender, EventArgs e)
        {
            if (dataGridViewPartidos.CurrentRow == null)
            {
                Wisej.Web.MessageBox.Show("Selecciona un partido válido.", "Aviso");
                return;
            }

            var partido = dataGridViewPartidos.CurrentRow.DataBoundItem as Partido;
            if (partido == null)
                return;

            if (Wisej.Web.MessageBox.Show($"¿Eliminar el partido contra {partido.Rival}?",
                "Confirmar", Wisej.Web.MessageBoxButtons.YesNo) == Wisej.Web.DialogResult.Yes)
            {
                partidos.Remove(partido);
                EquipoData.GuardarPartidos(partidos);
                MostrarPartidos();

                // Evitar errores de selección cuando ya no hay filas
                if (dataGridViewPartidos.Rows.Count > 0)
                {
                    dataGridViewPartidos.ClearSelection();
                    dataGridViewPartidos.Rows[0].Selected = true;
                }
                else
                {
                    // Limpia el DataGridView de convocadas si no hay partidos
                    dataGridViewConvocadas.DataSource = null;
                }
            }


        }

        private void DataGridViewPartidos_CellFormatting(object sender, Wisej.Web.DataGridViewCellFormattingEventArgs e)
        {
            var col = dataGridViewPartidos.Columns[e.ColumnIndex];
            if (col.Name == "Fecha" && e.Value is DateTime dt)
            {
                e.Value = dt.ToString("dd/MM/yyyy"); // o el formato que prefieras
                e.FormattingApplied = true;
            }

        
        }

        private async  void btnIntroducirResultado_Click(object sender, EventArgs e)
        {
            if (dataGridViewPartidos.CurrentRow == null)
            {
                Wisej.Web.MessageBox.Show("Selecciona un partido para introducir el resultado.");
                return;
            }

            var partido = dataGridViewPartidos.CurrentRow.DataBoundItem as Partido;
            if (partido == null)
                return;

            var dlg = new IntroducirResultadoDialog(partido);
            var result = await dlg.ShowDialogAsync();
            if (result == Wisej.Web.DialogResult.OK)
            {
                EquipoData.GuardarPartidos(partidos);
                MostrarPartidos();
            }
        }

        private void btnVerCampo_Click(object sender, EventArgs e)
        {
            if (alineacionDialog == null || alineacionDialog.IsDisposed)
            {
                alineacionDialog = new AlineacionDialog();
                alineacionDialog.Show();
            }
            else
            {
                alineacionDialog.BringToFront();
            }

            // Cargar los datos actuales (aunque estén vacíos)
            alineacionDialog.ActualizarAlineacion(partidoSeleccionado?.Convocadas ?? new List<Convocatoria>());
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            btnAltaJugadora.BackColor = Color.FromArgb(70, 130, 180);
            btnAltaJugadora.ForeColor = Color.White;
            btnAltaPartido.BackColor = Color.FromArgb(70, 130, 180);
            btnAltaPartido.ForeColor = Color.White;
            btnBajaJugadora.BackColor = Color.FromArgb(70, 130, 180);
            btnBajaJugadora.ForeColor = Color.White;
            btnBajaPartido.BackColor = Color.FromArgb(70, 130, 180);
            btnBajaPartido.ForeColor = Color.White;
            btnVerCampo.BackColor = Color.FromArgb(70, 130, 180);
            btnVerCampo.ForeColor = Color.White;
            btnIntroducirResultado.BackColor = Color.FromArgb(70, 130, 180);
            btnIntroducirResultado.ForeColor = Color.White;


        }



    }
}