namespace EFV_GestionPlantilla.Pages
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Wisej.Web.DataGridView dataGridViewJugadoras;
        private Wisej.Web.DataGridView dataGridViewPartidos;
        private Wisej.Web.DataGridView dataGridViewConvocadas;
        private Wisej.Web.Button btnAltaJugadora;
        private Wisej.Web.Button btnBajaJugadora;
        private Wisej.Web.Button btnAltaPartido;

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

        #region Wisej Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewJugadoras = new Wisej.Web.DataGridView();
            this.dataGridViewPartidos = new Wisej.Web.DataGridView();
            this.dataGridViewConvocadas = new Wisej.Web.DataGridView();
            this.btnAltaJugadora = new Wisej.Web.Button();
            this.btnBajaJugadora = new Wisej.Web.Button();
            this.btnAltaPartido = new Wisej.Web.Button();
            this.btnBajaPartido = new Wisej.Web.Button();
            this.btnIntroducirResultado = new Wisej.Web.Button();
            this.tableLayoutPanel1 = new Wisej.Web.TableLayoutPanel();
            this.btnVerCampo = new Wisej.Web.Button();
            this.pictureBox1 = new Wisej.Web.PictureBox();
            this.label4 = new Wisej.Web.Label();
            this.label3 = new Wisej.Web.Label();
            this.label2 = new Wisej.Web.Label();
            this.label1 = new Wisej.Web.Label();
            this.tableLayoutPanel2 = new Wisej.Web.TableLayoutPanel();
            this.tableLayoutPanel3 = new Wisej.Web.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJugadoras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPartidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConvocadas)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewJugadoras
            // 
            this.dataGridViewJugadoras.Dock = Wisej.Web.DockStyle.Fill;
            this.dataGridViewJugadoras.Location = new System.Drawing.Point(3, 103);
            this.dataGridViewJugadoras.Name = "dataGridViewJugadoras";
            this.dataGridViewJugadoras.Size = new System.Drawing.Size(768, 189);
            this.dataGridViewJugadoras.TabIndex = 0;
            // 
            // dataGridViewPartidos
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridViewPartidos, 2);
            this.dataGridViewPartidos.Dock = Wisej.Web.DockStyle.Fill;
            this.dataGridViewPartidos.Location = new System.Drawing.Point(777, 103);
            this.dataGridViewPartidos.Name = "dataGridViewPartidos";
            this.dataGridViewPartidos.Size = new System.Drawing.Size(611, 189);
            this.dataGridViewPartidos.TabIndex = 1;
            this.dataGridViewPartidos.SelectionChanged += new System.EventHandler(this.dataGridViewPartidos_SelectionChanged);
            // 
            // dataGridViewConvocadas
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridViewConvocadas, 3);
            this.dataGridViewConvocadas.Dock = Wisej.Web.DockStyle.Fill;
            this.dataGridViewConvocadas.Location = new System.Drawing.Point(3, 388);
            this.dataGridViewConvocadas.Name = "dataGridViewConvocadas";
            this.dataGridViewConvocadas.Size = new System.Drawing.Size(1385, 190);
            this.dataGridViewConvocadas.TabIndex = 2;
            // 
            // btnAltaJugadora
            // 
            this.btnAltaJugadora.BackColor = System.Drawing.Color.FromName("@accent");
            this.btnAltaJugadora.Dock = Wisej.Web.DockStyle.Fill;
            this.btnAltaJugadora.Font = new System.Drawing.Font("default", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btnAltaJugadora.Location = new System.Drawing.Point(287, 3);
            this.btnAltaJugadora.Name = "btnAltaJugadora";
            this.btnAltaJugadora.Size = new System.Drawing.Size(94, 38);
            this.btnAltaJugadora.TabIndex = 3;
            this.btnAltaJugadora.Text = "Alta Jugadora";
            this.btnAltaJugadora.Click += new System.EventHandler(this.btnAltaJugadora_Click);
            // 
            // btnBajaJugadora
            // 
            this.btnBajaJugadora.BackColor = System.Drawing.Color.FromName("@accent");
            this.btnBajaJugadora.Dock = Wisej.Web.DockStyle.Fill;
            this.btnBajaJugadora.Font = new System.Drawing.Font("default", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btnBajaJugadora.Location = new System.Drawing.Point(387, 3);
            this.btnBajaJugadora.Name = "btnBajaJugadora";
            this.btnBajaJugadora.Size = new System.Drawing.Size(94, 38);
            this.btnBajaJugadora.TabIndex = 4;
            this.btnBajaJugadora.Text = "Baja Jugadora";
            this.btnBajaJugadora.Click += new System.EventHandler(this.btnBajaJugadora_Click);
            // 
            // btnAltaPartido
            // 
            this.btnAltaPartido.BackColor = System.Drawing.Color.FromName("@accent");
            this.btnAltaPartido.Dock = Wisej.Web.DockStyle.Fill;
            this.btnAltaPartido.Font = new System.Drawing.Font("default", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btnAltaPartido.Location = new System.Drawing.Point(158, 3);
            this.btnAltaPartido.Name = "btnAltaPartido";
            this.btnAltaPartido.Size = new System.Drawing.Size(94, 38);
            this.btnAltaPartido.TabIndex = 5;
            this.btnAltaPartido.Text = "Alta Partido";
            this.btnAltaPartido.Click += new System.EventHandler(this.btnAltaPartido_Click);
            // 
            // btnBajaPartido
            // 
            this.btnBajaPartido.BackColor = System.Drawing.Color.FromName("@accent");
            this.btnBajaPartido.Dock = Wisej.Web.DockStyle.Fill;
            this.btnBajaPartido.Font = new System.Drawing.Font("default", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btnBajaPartido.Location = new System.Drawing.Point(258, 3);
            this.btnBajaPartido.Name = "btnBajaPartido";
            this.btnBajaPartido.Size = new System.Drawing.Size(94, 38);
            this.btnBajaPartido.TabIndex = 6;
            this.btnBajaPartido.Text = "Baja Partido";
            this.btnBajaPartido.Click += new System.EventHandler(this.btnBajaPartido_Click);
            // 
            // btnIntroducirResultado
            // 
            this.btnIntroducirResultado.BackColor = System.Drawing.Color.FromName("@accent");
            this.btnIntroducirResultado.Dock = Wisej.Web.DockStyle.Fill;
            this.btnIntroducirResultado.Font = new System.Drawing.Font("default", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btnIntroducirResultado.Location = new System.Drawing.Point(358, 3);
            this.btnIntroducirResultado.Name = "btnIntroducirResultado";
            this.btnIntroducirResultado.Size = new System.Drawing.Size(94, 38);
            this.btnIntroducirResultado.TabIndex = 7;
            this.btnIntroducirResultado.Text = "Resultado";
            this.btnIntroducirResultado.Click += new System.EventHandler(this.btnIntroducirResultado_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new Wisej.Web.ColumnStyle(Wisej.Web.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new Wisej.Web.ColumnStyle(Wisej.Web.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new Wisej.Web.ColumnStyle(Wisej.Web.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnVerCampo, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewJugadoras, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewPartidos, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewConvocadas, 0, 5);
            this.tableLayoutPanel1.Dock = Wisej.Web.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new Wisej.Web.RowStyle(Wisej.Web.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new Wisej.Web.RowStyle(Wisej.Web.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new Wisej.Web.RowStyle(Wisej.Web.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new Wisej.Web.RowStyle(Wisej.Web.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new Wisej.Web.RowStyle(Wisej.Web.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new Wisej.Web.RowStyle(Wisej.Web.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new Wisej.Web.RowStyle(Wisej.Web.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1391, 581);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // btnVerCampo
            // 
            this.btnVerCampo.BackColor = System.Drawing.Color.FromName("@accent");
            this.btnVerCampo.Dock = Wisej.Web.DockStyle.Fill;
            this.btnVerCampo.Font = new System.Drawing.Font("default", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.btnVerCampo.Location = new System.Drawing.Point(1293, 348);
            this.btnVerCampo.Name = "btnVerCampo";
            this.btnVerCampo.Size = new System.Drawing.Size(95, 34);
            this.btnVerCampo.TabIndex = 9;
            this.btnVerCampo.Text = "Alineación";
            this.btnVerCampo.Click += new System.EventHandler(this.btnVerCampo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = Wisej.Web.DockStyle.Fill;
            this.pictureBox1.ImageSource = "Resources\\logo-finalgrande.png";
            this.pictureBox1.Location = new System.Drawing.Point(1290, 0);
            this.pictureBox1.Margin = new Wisej.Web.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.tableLayoutPanel1.SetRowSpan(this.pictureBox1, 2);
            this.pictureBox1.Size = new System.Drawing.Size(101, 100);
            this.pictureBox1.SizeMode = Wisej.Web.PictureBoxSizeMode.StretchImage;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 2);
            this.label4.Dock = Wisej.Web.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("default, Arial", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1284, 54);
            this.label4.TabIndex = 8;
            this.label4.Text = "ESCUELA DE FÚTBOL VALDEMORO CADETE FEMENINO";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = Wisej.Web.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("default", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label3.Location = new System.Drawing.Point(3, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(768, 34);
            this.label3.TabIndex = 7;
            this.label3.Text = "CONVOCATORIAS PARTIDOS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = Wisej.Web.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("default", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label2.Location = new System.Drawing.Point(777, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(510, 34);
            this.label2.TabIndex = 6;
            this.label2.Text = "PARTIDOS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = Wisej.Web.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("default, Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(3, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(768, 34);
            this.label1.TabIndex = 5;
            this.label1.Text = "JUGADORAS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new Wisej.Web.ColumnStyle(Wisej.Web.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new Wisej.Web.ColumnStyle(Wisej.Web.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new Wisej.Web.ColumnStyle(Wisej.Web.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new Wisej.Web.ColumnStyle(Wisej.Web.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnAltaJugadora, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnBajaJugadora, 2, 0);
            this.tableLayoutPanel2.Dock = Wisej.Web.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 298);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new Wisej.Web.RowStyle(Wisej.Web.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(768, 44);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new Wisej.Web.ColumnStyle(Wisej.Web.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new Wisej.Web.ColumnStyle(Wisej.Web.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new Wisej.Web.ColumnStyle(Wisej.Web.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new Wisej.Web.ColumnStyle(Wisej.Web.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new Wisej.Web.ColumnStyle(Wisej.Web.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnAltaPartido, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnIntroducirResultado, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnBajaPartido, 2, 0);
            this.tableLayoutPanel3.Dock = Wisej.Web.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(777, 298);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new Wisej.Web.RowStyle(Wisej.Web.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(611, 44);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromName("@table-row-background-selected");
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainPage";
            this.Size = new System.Drawing.Size(1391, 581);
            this.Load += new System.EventHandler(this.MainPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJugadoras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPartidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConvocadas)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Wisej.Web.Button btnBajaPartido;
        private Wisej.Web.Button btnIntroducirResultado;
        private Wisej.Web.TableLayoutPanel tableLayoutPanel1;
        private Wisej.Web.TableLayoutPanel tableLayoutPanel3;
        private Wisej.Web.TableLayoutPanel tableLayoutPanel2;
        private Wisej.Web.Label label1;
        private Wisej.Web.Label label3;
        private Wisej.Web.Label label2;
        private Wisej.Web.Label label4;
        private Wisej.Web.PictureBox pictureBox1;
        private Wisej.Web.Button btnVerCampo;
    }
}