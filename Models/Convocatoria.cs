using System;

namespace EFV_GestionPlantilla.Models
{
    public class Convocatoria
    {
        public Guid JugadoraId { get; set; }
        public string NombreJugadora { get; set; }
        public string Posicion { get; set; }
        public int MinutosJugados { get; set; }
        public int Goles { get; set; } = 0;
        public string Condicion { get; set; } = "Por definir"; // Titular o Suplente
        public string Tarjeta { get; set; }

    }
}