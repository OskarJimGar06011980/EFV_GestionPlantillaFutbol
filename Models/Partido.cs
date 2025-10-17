using System;
using System.Collections.Generic;

namespace EFV_GestionPlantilla.Models
{
    public class Partido
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Rival { get; set; }
        public DateTime Fecha { get; set; }
        public List<Convocatoria> Convocadas { get; set; } = new List<Convocatoria>();
        public int ConvocadasCount => Convocadas?.Count ?? 0;
        public string LocalVisitante { get; set; } = "Local/Visitante";
        public string Resultado { get; set; } = string.Empty;


    }
}