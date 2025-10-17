using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Wisej.Web;
using EFV_GestionPlantilla.Models;

namespace EFV_GestionPlantilla.Forms
{
    public partial class AlineacionDialog : Wisej.Web.Form
    {
        private PictureBox campo;
        private Panel overlayPanel;
        private List<Convocatoria> convocadasActuales = new List<Convocatoria>();

        // Porcentaje vertical desde arriba (0=arriba, 1=abajo)
        private readonly Dictionary<string, float> YPorFila = new Dictionary<string, float>
        {
            // PORTERO
            { "portero", 0.90f },

            // DEFENSAS
            { "lateral izquierdo", 0.72f },
            { "central izquierdo", 0.70f },
            { "central derecho", 0.70f },
            { "lateral derecho", 0.72f },

            // MEDIOS
            { "medio izquierdo", 0.52f },
            { "medio", 0.50f },
            { "medio derecho", 0.52f },

            // MEDIA PUNTA
            { "media punta", 0.38f },

            // DELANTEROS
            { "extremo izquierdo", 0.25f },
            { "delantero", 0.23f },
            { "extremo derecho", 0.25f }
        };


        public AlineacionDialog()
        {
            InitializeComponent();

            this.Text = "Alineación";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.Black;

            CrearCampo();

            if (overlayPanel != null)
                overlayPanel.SizeChanged += (s, e) => RedibujarCampo();
        }

        /// <summary>
        /// Actualiza los balones de una jugadora específica sin recargar toda la lista.
        /// </summary>
        public void ActualizarBalonesEnAlineacion(string nombreJugadora, int goles)
        {
            if (string.IsNullOrWhiteSpace(nombreJugadora))
                return;

            var jugadora = convocadasActuales.FirstOrDefault(c => c.NombreJugadora == nombreJugadora);
            if (jugadora != null)
            {
                jugadora.Goles = goles;

                // Redibuja el overlay para reflejar los nuevos goles
                RedibujarCampo();
            }
        }

        private void CrearCampo()
        {
            campo = new PictureBox()
            {
                Dock = DockStyle.Fill,
                ImageSource = "Resources/CampoFutbol.jpg",
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(campo);

            overlayPanel = new Panel()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };
            this.Controls.Add(overlayPanel);
            overlayPanel.BringToFront();
        }

        public void ActualizarAlineacion(List<Convocatoria> nuevasConvocadas)
        {
            convocadasActuales = nuevasConvocadas ?? new List<Convocatoria>();
            RedibujarCampo();
        }

        private void RedibujarCampo()
        {
            if (overlayPanel == null) return;

            overlayPanel.Controls.Clear();

            // Cargar la imagen del balón solo una vez
            var soccerBallImage = new Bitmap(Application.MapPath("Resources/ballsoccer_app.png"));

            // Agrupamos jugadoras
            var titulares = convocadasActuales
             .Where(c => string.Equals(c.Condicion, "Titular", StringComparison.OrdinalIgnoreCase)
                      && !string.IsNullOrWhiteSpace(c.Posicion)
                      && !string.Equals(c.Posicion, "Sin definir", StringComparison.OrdinalIgnoreCase))
             .ToList();

            var suplentes = convocadasActuales
                .Where(c => string.Equals(c.Condicion, "Suplente", StringComparison.OrdinalIgnoreCase)
                         && !string.IsNullOrWhiteSpace(c.Posicion)
                         && !string.Equals(c.Posicion, "Sin definir", StringComparison.OrdinalIgnoreCase))
                .ToList();

            bool hayMediaPunta = titulares.Any(j => NormalizePosition(j.Posicion) == "media punta");

            // ========== TITULARES ==========
            var gruposTitulares = titulares.GroupBy(j => NormalizePosition(j.Posicion));
            var mediosTitulares = gruposTitulares.FirstOrDefault(g => g.Key == "medio")?.ToList();
            int numMediosTitulares = mediosTitulares?.Count ?? 0;

            foreach (var grupo in gruposTitulares)
            {
                var total = grupo.Count();
                int i = 0;

                foreach (var jugadora in grupo)
                {
                    var lbl = new Label()
                    {
                        Text = jugadora.NombreJugadora,
                        AutoSize = false,
                        Size = new Size(140, 32),
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        ForeColor = Color.White,
                        BackColor = Color.FromArgb(180, 0, 80, 0), // verde semitransparente titulares
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    var posNorm = NormalizePosition(jugadora.Posicion);
                    Point punto = (posNorm == "medio" && numMediosTitulares > 1)
                        ? ObtenerCoordenadasMedios(numMediosTitulares, i, hayMediaPunta)
                        : ObtenerCoordenadas(posNorm, i, total, hayMediaPunta);

                    int x = punto.X - lbl.Width / 2;
                    int y = punto.Y - lbl.Height / 2;

                    x = Math.Max(0, Math.Min(x, overlayPanel.ClientSize.Width - lbl.Width));
                    y = Math.Max(0, Math.Min(y, overlayPanel.ClientSize.Height - lbl.Height));

                    lbl.Location = new Point(x, y);

                    var tt = new ToolTip();
                    tt.SetToolTip(lbl, $"Min: {jugadora.MinutosJugados}  |  Goles: {jugadora.Goles}  |  Pos: {jugadora.Posicion}");

                    overlayPanel.Controls.Add(lbl);

                    // Dibujar balones según goles
                    for (int g = 0; g < jugadora.Goles; g++)
                    {
                        var pb = new PictureBox()
                        {
                            Size = new Size(20, 20),
                            Image = soccerBallImage,
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };

                        int ballX = lbl.Right + 5 + g * (pb.Width + 2);
                        int ballY = lbl.Top + (lbl.Height - pb.Height) / 2;

                        if (ballX + pb.Width > overlayPanel.ClientSize.Width)
                            break;

                        pb.Location = new Point(ballX, ballY);
                        overlayPanel.Controls.Add(pb);
                    }

                    i++;
                }
            }

            // ========== SUPLENTES ==========
            var gruposSuplentes = suplentes.GroupBy(j => NormalizePosition(j.Posicion));
            var mediosSuplentes = gruposSuplentes.FirstOrDefault(g => g.Key == "medio")?.ToList();
            int numMediosSuplentes = mediosSuplentes?.Count ?? 0;

            foreach (var grupo in gruposSuplentes)
            {
                var total = grupo.Count();
                int i = 0;

                foreach (var jugadora in grupo)
                {
                    var lbl = new Label()
                    {
                        Text = jugadora.NombreJugadora,
                        AutoSize = false,
                        Size = new Size(140, 32),
                        Font = new Font("Segoe UI", 9, FontStyle.Regular),
                        ForeColor = Color.White,
                        BackColor = Color.FromArgb(180, 0, 0, 120), // azul semitransparente suplentes
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    var posNorm = NormalizePosition(jugadora.Posicion);
                    Point punto = (posNorm == "medio" && numMediosSuplentes > 1)
                        ? ObtenerCoordenadasMedios(numMediosSuplentes, i, hayMediaPunta)
                        : ObtenerCoordenadas(posNorm, i, total, hayMediaPunta);

                    // Desplazamos un poco hacia abajo a los suplentes (debajo de los titulares)
                    int yOffset = (int)(overlayPanel.ClientSize.Height * 0.05f);
                    punto.Y += yOffset;

                    int x = punto.X - lbl.Width / 2;
                    int y = punto.Y - lbl.Height / 2;

                    x = Math.Max(0, Math.Min(x, overlayPanel.ClientSize.Width - lbl.Width));
                    y = Math.Max(0, Math.Min(y, overlayPanel.ClientSize.Height - lbl.Height));

                    lbl.Location = new Point(x, y);

                    var tt = new ToolTip();
                    tt.SetToolTip(lbl, $"Suplente  |  Min: {jugadora.MinutosJugados}  |  Goles: {jugadora.Goles}  |  Pos: {jugadora.Posicion}");

                    overlayPanel.Controls.Add(lbl);

                    // Dibujar balones según goles
                    for (int g = 0; g < jugadora.Goles; g++)
                    {
                        var pb = new PictureBox()
                        {
                            Size = new Size(20, 20),
                            Image = soccerBallImage,
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };

                        int ballX = lbl.Right + 5 + g * (pb.Width + 2);
                        int ballY = lbl.Top + (lbl.Height - pb.Height) / 2;

                        if (ballX + pb.Width > overlayPanel.ClientSize.Width)
                            break;

                        pb.Location = new Point(ballX, ballY);
                        overlayPanel.Controls.Add(pb);
                    }

                    i++;
                }
            }
        }


        private string NormalizePosition(string posicion)
        {
            if (string.IsNullOrWhiteSpace(posicion))
                return string.Empty;

            var s = posicion.Trim().ToLowerInvariant();
            s = System.Text.RegularExpressions.Regex.Replace(s, @"\s+", " ");

            // Acentos
            s = s.Replace("á", "a").Replace("é", "e").Replace("í", "i")
                 .Replace("ó", "o").Replace("ú", "u").Replace("ü", "u").Replace("ñ", "n");

            // Sinónimos y abreviaturas
            switch (s)
            {
                case "portera":
                case "arquero": return "portero";

                case "li": return "lateral izquierdo";
                case "ld": return "lateral derecho";
                case "ci": return "central izquierdo";
                case "cd": return "central derecho";

                case "mc":
                case "medio centro": return "medio";

                case "mi": return "medio izquierdo";
                case "md": return "medio derecho";

                case "mediapunta":
                case "media-punta":
                case "media punta": return "media punta";

                case "ei": return "extremo izquierdo";
                case "ed": return "extremo derecho";
                case "dc": return "delantero";
            }

            return s;
        }

        private Point ObtenerCoordenadas(string posicionNormalizada, int indice = 0, int total = 1, bool hayMediaPunta = false)
        {
            if (overlayPanel == null) return new Point(0, 0);

            int w = Math.Max(overlayPanel.ClientSize.Width, 1);
            int h = Math.Max(overlayPanel.ClientSize.Height, 1);

            // Detectar extremos titulares actuales (usar NormalizePosition sobre convocadasActuales)
            bool hayExtremoIzqTitular = convocadasActuales.Any(c =>
                string.Equals(NormalizePosition(c.Posicion), "extremo izquierdo", StringComparison.OrdinalIgnoreCase)
                && string.Equals(c.Condicion, "Titular", StringComparison.OrdinalIgnoreCase));

            bool hayExtremoDerTitular = convocadasActuales.Any(c =>
                string.Equals(NormalizePosition(c.Posicion), "extremo derecho", StringComparison.OrdinalIgnoreCase)
                && string.Equals(c.Condicion, "Titular", StringComparison.OrdinalIgnoreCase));

            // Coordenada base Y según el diccionario
            float yBase = YPorFila.ContainsKey(posicionNormalizada)
                ? YPorFila[posicionNormalizada]
                : 0.50f;

            // X por defecto
            float xBaseRel = 0.50f;

            // Valores base por posición
            switch (posicionNormalizada)
            {
                case "lateral izquierdo": xBaseRel = 0.20f; break;
                case "central izquierdo": xBaseRel = 0.38f; break;
                case "central derecho": xBaseRel = 0.62f; break;
                case "lateral derecho": xBaseRel = 0.80f; break;

                case "medio izquierdo": xBaseRel = 0.32f; break;
                case "medio": xBaseRel = 0.50f; break;
                case "medio derecho": xBaseRel = 0.68f; break;

                case "media punta": xBaseRel = 0.50f; break;

                case "extremo izquierdo": xBaseRel = 0.28f; break;
                case "delantero": xBaseRel = 0.50f; break;
                case "extremo derecho": xBaseRel = 0.72f; break;

                case "portero": xBaseRel = 0.50f; break;
            }

            // Ajustes específicos para la línea de medios (si se están distribuyendo manualmente)
            if (posicionNormalizada.StartsWith("medio") && total == 3)
            {
                if (indice == 0) xBaseRel = 0.36f;      // medio izquierdo
                else if (indice == 1) xBaseRel = 0.50f; // medio central
                else if (indice == 2) xBaseRel = 0.64f; // medio derecho

                // Y: adelantamos un poco los laterales respecto al central
                if (indice == 0) yBase = 0.48f;      // izquierdo un poco más arriba
                else if (indice == 1) yBase = 0.50f; // central
                else if (indice == 2) yBase = 0.48f; // derecho un poco más arriba
            }

            if (posicionNormalizada.StartsWith("medio") && total == 2)
            {
                xBaseRel = (indice == 0) ? 0.42f : 0.58f;
                // dejar yBase igual
            }

            // Ajustes cuando hay MediaPunta
            if (hayMediaPunta)
            {
                // Extremar posiciones de los extremos para ganar separación
                if (posicionNormalizada == "extremo izquierdo")
                {
                    // Si no hay extremo derecho, colocarlo un poco más centrado; si sí lo hay, mantener ligeramente abierto.
                    xBaseRel = hayExtremoDerTitular ? 0.36f : 0.34f;
                    // si quieres adelantarlo un poco: yBase -= 0.01f;
                }

                if (posicionNormalizada == "extremo derecho")
                {
                    xBaseRel = hayExtremoIzqTitular ? 0.64f : 0.66f;
                }

                // Delantero: comportamiento dependiente de qué extremos existen
                if (posicionNormalizada == "delantero")
                {
                    if (hayExtremoDerTitular && !hayExtremoIzqTitular)
                    {
                        // Solo hay extremo derecho (y hay MediaPunta): desplazar delantero ligeramente a la izquierda
                        xBaseRel = 0.46f;
                    }
                    else if (hayExtremoIzqTitular && !hayExtremoDerTitular)
                    {
                        // Solo hay extremo izquierdo: desplazar delantero ligeramente a la derecha
                        xBaseRel = 0.54f;
                    }
                    else if (hayExtremoIzqTitular && hayExtremoDerTitular)
                    {
                        // Ambos extremos: mantener central pero un poco adelantado a la derecha como antes
                        xBaseRel = 0.55f;
                    }
                    else
                    {
                        // Ningún extremo: mantener centrado (o ligero ajuste si prefieres)
                        xBaseRel = 0.50f;
                    }

                    // pequeño adelantamiento vertical del delantero cuando hay MediaPunta
                    yBase -= 0.02f;
                }
            }
            else
            {
                // Si NO hay MediaPunta, aplicar lógica base para el caso de un solo extremo + delantero
                // si hay un extremo derecho y NO extremo izquierdo, mover delantero a la izquierda un poco para evitar solape
                if (posicionNormalizada == "delantero")
                {
                    if (hayExtremoDerTitular && !hayExtremoIzqTitular)
                        xBaseRel = 0.46f; // ligera izquierda
                    else if (hayExtremoIzqTitular && !hayExtremoDerTitular)
                        xBaseRel = 0.54f; // ligera derecha
                    else
                        xBaseRel = 0.50f; // central
                }

                // Si solo hay extremo derecho o izquierdo sin delantero, ajustar su X para que no queden demasiado pegados al centro
                if (posicionNormalizada == "extremo derecho" && !hayExtremoIzqTitular)
                {
                    xBaseRel = 0.66f;
                }
                if (posicionNormalizada == "extremo izquierdo" && !hayExtremoDerTitular)
                {
                    xBaseRel = 0.34f;
                }
            }

            // Seguridad: limitar a rangos razonables
            xBaseRel = Math.Max(0.03f, Math.Min(0.97f, xBaseRel));
            yBase = Math.Max(0.03f, Math.Min(0.97f, yBase));

            int x = (int)(xBaseRel * w);
            int y = (int)(yBase * h);
            return new Point(x, y);
        }

        private Point ObtenerCoordenadasMedios(int numMedios, int indice, bool hayMediaPunta)
        {
            if (overlayPanel == null)
                return new Point(0, 0);

            int w = Math.Max(overlayPanel.ClientSize.Width, 1);
            int h = Math.Max(overlayPanel.ClientSize.Height, 1);

            // Coordenadas base
            float yBase = 0.50f; // centro
            float xRel = 0.50f;

            if (numMedios == 2)
            {
                xRel = (indice == 0) ? 0.42f : 0.58f;
                yBase = 0.50f; // mantener mismo nivel
            }
            else if (numMedios == 3)
            {
                if (indice == 0)
                {
                    xRel = 0.36f;  // medio izquierdo
                    yBase = 0.48f; // ligeramente adelantado
                }
                else if (indice == 1)
                {
                    xRel = 0.50f;  // medio central
                    yBase = 0.50f; // nivel normal
                }
                else
                {
                    xRel = 0.64f;  // medio derecho
                    yBase = 0.48f; // ligeramente adelantado
                }
            }

            // Ajustes si hay MediaPunta
            if (hayMediaPunta)
            {
                // lateralizamos un poco si hay MediaPunta
                if (numMedios == 3)
                {
                    if (indice == 0) xRel -= 0.03f;
                    if (indice == 2) xRel += 0.03f;
                }
            }

            int x = (int)(xRel * w);
            int y = (int)(yBase * h);

            return new Point(x, y);
        }

        private void AlineacionDialog_Load(object sender, EventArgs e)
        {
            this.HeaderBackColor = System.Drawing.Color.DarkGreen;
            this.StartPosition = FormStartPosition.CenterParent;
        }
    }
}
