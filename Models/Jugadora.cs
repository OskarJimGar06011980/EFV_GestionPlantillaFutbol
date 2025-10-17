using System;

namespace EFV_GestionPlantilla.Models
{
    public class Jugadora
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; }
        public int Dorsal { get; set; }
    }
}