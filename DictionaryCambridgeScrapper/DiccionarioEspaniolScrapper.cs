using DictionaryCambridgeScrapper;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;

namespace InglesToAnki
{
    public static class DiccionarioEspaniolScrapper
    {
        private static readonly string UrlBase = "https://dle.rae.es/";
        private static HtmlWeb web = new HtmlWeb();

        public static ResultadoEspaniol returnResultado(string palabraBuscada)
        {
           
            List<string> Variantes = new();
            List<string> etimologia = new();
            List<string> Ortografia = new();
            List<string> Definiciones = new();
            List<string> FormasComplejas = new();

            var htmlDoc = web.Load(UrlBase + palabraBuscada);
            
            var htmlNodePosBody = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[1]/div[3]/div[1]/section/div[2]/article");

            if (htmlNodePosBody != null)
            {
                foreach (var nNode in htmlNodePosBody.Descendants("p"))
                {
                    if (nNode.NodeType == HtmlNodeType.Element && nNode.HasAttributes )
                    {
                        switch (nNode.Attributes[0].Value)
                        {
                            case "l2": //redirigir a la variante
                                var nNodeAnvchores = nNode.Descendants("a");
                                var nNodeAnvchor = nNodeAnvchores.First();
                                if (nNodeAnvchor != null && nNodeAnvchor.NodeType == HtmlNodeType.Element && nNodeAnvchor.HasAttributes && nNodeAnvchor.Attributes.Count > 1)
                                {
                                    string direccion = nNodeAnvchor.Attributes[1].Value;
                                    return returnResultado(direccion);
                                }
                                break;
                            case "n1": //variantes
                                Variantes.Add(HttpUtility.HtmlDecode(nNode.InnerText).Replace(";",","));
                                break;
                            case "n2":
                            case "n3"://etimologia
                                etimologia.Add(HttpUtility.HtmlDecode(nNode.InnerText).Replace(";", ","));
                                break;
                            case "n5"://Ortografia
                                Ortografia.Add(HttpUtility.HtmlDecode(nNode.InnerText).Replace(";", ","));
                                break;
                            case "j"://Definiciones
                                Definiciones.Add("<p>"+HttpUtility.HtmlDecode(nNode.InnerText).Replace(";", ",")+"</p>");
                                break;
                            case "k5"://Formas Complejas Titulo
                            case "k6":
                                FormasComplejas.Add("<h5>"+HttpUtility.HtmlDecode(nNode.InnerText).Replace(";", ",") + ": </h5>");
                                break;
                            case "m"://Formas Complejas Definicion
                                FormasComplejas.Add("<p>" + HttpUtility.HtmlDecode(nNode.InnerText).Replace(";", ",") + "</p>");
                                break;
                        }
                    }
                    
                }
                foreach (var nNode in htmlNodePosBody.Descendants("header"))
                {
                    if (nNode.NodeType == HtmlNodeType.Element && nNode.HasAttributes && nNode.Attributes[0].Value == "f")
                    {
                        palabraBuscada = nNode.InnerText;
                    }
                }
            }

            Form1.progreso.Value++;

            return new ResultadoEspaniol(palabraBuscada, Variantes, etimologia, Ortografia, Definiciones.Distinct().ToList(), FormasComplejas.Distinct().ToList()); ;
        }
    }
}
