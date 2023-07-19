using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InglesToAnki
{
    public class ResultadoEspaniol
    {
        public string Palabra { get; set; } = "";
        public List<string> Variantes { get; set; } = new();
        public List<string> etimologia { get; set; } = new();
        public List<string> Ortografia { get; set; } = new();
        public List<string> Definiciones { get; set; } = new();
        public List<string> FormasComplejas { get; set; } = new();

        public ResultadoEspaniol()
        {
        }

        public ResultadoEspaniol(string palabra, List<string> variantes, List<string> etimologia, List<string> ortografia, List<string> definiciones, List<string> formasComplejas)
        {
            Palabra = palabra;
            Variantes = variantes;
            this.etimologia = etimologia;
            Ortografia = ortografia;
            Definiciones = definiciones;
            FormasComplejas = formasComplejas;
        }
    }
}
