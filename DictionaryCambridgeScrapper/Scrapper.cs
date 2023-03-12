using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DictionaryCambridgeScrapper
{
    public static class Scrapper
    {
        private static readonly string UrlBase = "https://dictionary.cambridge.org/dictionary/english-spanish/";
        private static HtmlWeb web = new HtmlWeb();
        
        public static Resultado returnResultado(string palabraBuscada )
        {
            string pronuc = "";
            List<string> Traduclist = new();
            
            var htmlDoc = web.Load(UrlBase + palabraBuscada);
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
                }
            }





            Form1.progreso.Value++;

            return new Resultado(palabraBuscada,pronuc,Traduclist.Distinct().ToList());
        }
    }
}
