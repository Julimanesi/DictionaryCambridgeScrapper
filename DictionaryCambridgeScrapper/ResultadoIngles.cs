﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryCambridgeScrapper
{
    public class ResultadoIngles
    {
        public string PalabraBuscada { get; set; } = "";
        public string Pronunciacion { get; set; } = "";
        public List<string> Traducciones { get; set; } = new List<string>();
        public List<string> OracionesEjemIngles { get; set; } = new List<string>();
        public List<string> Definiciones { get; set; } = new List<string>();

        public ResultadoIngles()
        {
        }

        public ResultadoIngles(string palabraBuscada, string pronunciacion, List<string> traducciones)
        {
            PalabraBuscada = palabraBuscada;
            Pronunciacion = pronunciacion;
            Traducciones = traducciones;
        }

        public ResultadoIngles(string palabraBuscada, string pronunciacion, List<string> oracionesEjemIngles, List<string> definiciones) : this(palabraBuscada, pronunciacion, oracionesEjemIngles)
        {
            Definiciones = definiciones;
        }

        public ResultadoIngles(string palabraBuscada, string pronunciacion, List<string> traducciones, List<string> oracionesEjemIngles, List<string> definiciones) : this(palabraBuscada, pronunciacion, traducciones)
        {
            OracionesEjemIngles = oracionesEjemIngles;
            Definiciones = definiciones;
        }
    }
}
