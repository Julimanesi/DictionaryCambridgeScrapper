using DictionaryCambridgeScrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InglesToAnki
{
    public class DictionaryApi
    {
        private static readonly string UrlBase = "https://api.dictionaryapi.dev/api/v2/entries/en/";
        private static HttpClient _httpClient = new();
        public static async Task<ResultadoIngles> returnResultado(string palabraBuscada)
        {
            try
            {
                //var respuestaApi = await _httpClient.GetFromJsonAsync<DictionaryApiDTO>(UrlBase + palabraBuscada);
                var respuesta = await _httpClient.GetAsync(UrlBase + palabraBuscada);
                if (respuesta == null)
                    return new ResultadoIngles();
                if(!respuesta.IsSuccessStatusCode)
                    return new ResultadoIngles();
                if(respuesta.Content==null)
                    return new ResultadoIngles();
                 //var resultado2 = await respuesta.Content.ReadAsStringAsync();
                 var respuestaApi = await respuesta.Content.ReadFromJsonAsync<List<DictionaryApiDTO>>();
                 List<string> OracionesEjemIngles  = new List<string>();
                 List<string> Definiciones  = new List<string>();
                foreach (DictionaryApiDTO palabra in respuestaApi)
                {
                    foreach(Meaning significados in palabra.meanings)
                    {
                        Definiciones.AddRange(significados.definitions.Select(x=>x.definition));
                        OracionesEjemIngles.AddRange(significados.definitions.Select(x => x.example != null ? x.example : ""));
                    }
                }

                Form1.progreso.Value++;

                return new ResultadoIngles(palabraBuscada, respuestaApi[0].phonetic,OracionesEjemIngles, Definiciones);
            }
            catch(Exception e)
            {
                return new ResultadoIngles();
            }
        }
    }
}
