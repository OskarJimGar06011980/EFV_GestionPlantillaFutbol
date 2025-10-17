using System.Collections.Generic;
using System.IO;
using EFV_GestionPlantilla.Models;
using Newtonsoft.Json;


namespace EFV_GestionPlantilla.Data
{
    public static class EquipoData
    {
        private static string JugadorasFile = "jugadoras.json";
        private static string PartidosFile = "partidos.json";

        public static List<Jugadora> CargarJugadoras()
        {
            if (!File.Exists(JugadorasFile)) return new List<Jugadora>();
            var json = File.ReadAllText(JugadorasFile);
            return JsonConvert.DeserializeObject<List<Jugadora>>(json) ?? new List<Jugadora>();
        }

        public static void GuardarJugadoras(List<Jugadora> jugadoras)
        {
            var json = JsonConvert.SerializeObject(jugadoras, Formatting.Indented);
            File.WriteAllText(JugadorasFile, json);
        }

        public static List<Partido> CargarPartidos()
        {
            if (!File.Exists(PartidosFile)) return new List<Partido>();
            var json = File.ReadAllText(PartidosFile);
            return JsonConvert.DeserializeObject<List<Partido>>(json) ?? new List<Partido>();
        }

        public static void GuardarPartidos(List<Partido> partidos)
        {
            var json = JsonConvert.SerializeObject(partidos, Formatting.Indented);
            File.WriteAllText(PartidosFile, json);
        }
    }
}