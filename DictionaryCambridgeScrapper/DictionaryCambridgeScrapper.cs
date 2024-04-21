using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DictionaryCambridgeScrapper
{
    public static class DictionaryCambridgeScrapper
    {
        private static readonly string UrlBase = "https://dictionary.cambridge.org/dictionary/english-spanish/";
        private static readonly string UrlBaseSoloIngles = "https://dictionary.cambridge.org/dictionary/english/";
        private static HtmlWeb web = new HtmlWeb();
        
        public static ResultadoIngles returnResultado(string palabraBuscada )
        {
            string pronuc = "";
            List<string> Traduclist = new();
            List<string> OracionesEjemploIngles = new();
            List<string> Definiciones = new();
            
            var htmlDoc = web.Load(UrlBase + palabraBuscada);
            var htmlNodePalabraBuscada = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[2]/div/div[1]/div[2]/article/div[2]/div[1]/div[2]/div[2]/div/span/div/span/div/div[1]/h2/span");
            if( htmlNodePalabraBuscada != null)
            {
                palabraBuscada = htmlNodePalabraBuscada.InnerText;
            }
            var htmlNodePronun = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[2]/div/div[1]/div[2]/article/div[2]/div[1]/div[2]/div[2]/div/span/div/span/div/span[1]/span[2]/span");
            if (htmlNodePronun != null)
            {
                pronuc = htmlNodePronun.InnerText;
            }
            else
            {
                htmlNodePronun = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[2]/div/div[1]/div[2]/article/div[2]/div[1]/div[2]/div[2]/div/span/div[1]/span/div/span[3]/span[2]/span");
                if (htmlNodePronun != null)
                {
                    pronuc = htmlNodePronun.InnerText;
                }
            }
            var htmlNodePosBody = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[2]/div/div[1]/div[2]/article/div[2]/div[1]/div[2]/div[2]/div/span/div/div[3]");

            if (htmlNodePosBody != null)
            {
                foreach (var nNode in htmlNodePosBody.Descendants("span"))
                {
                    if (nNode.NodeType == HtmlNodeType.Element && nNode.HasAttributes && nNode.Attributes[0].Value == "trans dtrans dtrans-se ")
                    {
                        Traduclist.Add(nNode.InnerText);
                    }
                    if (nNode.NodeType == HtmlNodeType.Element && nNode.HasAttributes && nNode.Attributes[0].Value == "eg deg")
                    {
                        OracionesEjemploIngles.Add(nNode.InnerText);
                    }
                }
                foreach (var nNode in htmlNodePosBody.Descendants("div"))
                {
                    if (nNode.NodeType == HtmlNodeType.Element && nNode.HasAttributes && nNode.Attributes[0].Value == "def ddef_d db")
                    {
                        Definiciones.Add(nNode.InnerText);
                    }
                }
            }

            if (!OracionesEjemploIngles.Any())
            {
                OracionesEjemploIngles.AddRange(ObtenerEjemplosExtraSoloIngles(palabraBuscada));
            }

            Form1.progreso.Value++;

            return new ResultadoIngles(palabraBuscada,pronuc,Traduclist.Distinct().ToList(), OracionesEjemploIngles.Distinct().ToList(),Definiciones.Distinct().ToList());
        }

        private static List<string> ObtenerEjemplosExtraSoloIngles(string palabra)
        {
            List<string> respuesta = new List<string>();
            var htmlDoc = web.Load(UrlBaseSoloIngles + palabra);
            var htmlNodePosBody = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[2]/div/div[1]/div[2]/article/div[2]/div[1]/div[2]/div[2]/div/span/div/div[3]");

            if (htmlNodePosBody != null)
            {
                foreach (var nNode in htmlNodePosBody.Descendants("span"))
                {
                    
                    if (nNode.NodeType == HtmlNodeType.Element && nNode.HasAttributes && nNode.Attributes[0].Value == "eg deg")
                    {
                        respuesta.Add(nNode.InnerText);
                    }
                }                
            }

            return respuesta;
        }
    }
}
