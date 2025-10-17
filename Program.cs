using System;
using Wisej.Core;
using Wisej.Web;

namespace EFV_GestionPlantilla
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
           
            Application.MainPage = new EFV_GestionPlantilla.Pages.LoginPage();
        }
    }
}