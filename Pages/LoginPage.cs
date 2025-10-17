using System;
using System.Drawing;
using Wisej.Web;

namespace EFV_GestionPlantilla.Pages
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();

            btnLogin.BackColor = Color.FromArgb(70, 130, 180);
            btnLogin.ForeColor = Color.White; // Texto visible
            //string ruta = Application.MapPath("Resources/logo-finalgrande.png");
            //pictureBoxLogo.Image = Image.FromFile(ruta);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (ValidarLogin(usuario, password))
            {
               
                Application.MainPage = new EFV_GestionPlantilla.Pages.MainPage();
            }
            else
            {
                lblError.Text = "Usuario o contraseña incorrectos";
            }
        }

        private bool ValidarLogin(string usuario, string password)
        {
            return usuario == "admin" && password == "1234";
        }
    }
}

