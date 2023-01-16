using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryCambridgeScrapper
{
    public class Resultado
    {
        public string PalabraBuscada { get; set; }
        public string Pronunciacion { get; set; }
        public List<string> Traducciones { get; set; } = new List<string>();

        public Resultado(string palabraBuscada, string pronunciacion, List<string> traducciones)
        {
            PalabraBuscada = palabraBuscada;
            Pronunciacion = pronunciacion;
            Traducciones = traducciones;
        }
    }
}
