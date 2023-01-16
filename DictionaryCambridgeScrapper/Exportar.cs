using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryCambridgeScrapper
{
    public class Exportar
    {
        public List<string> ListaPalabras { get; set; }

        public Exportar(List<string> listaPalabras)
        {
            ListaPalabras = listaPalabras;
        }

        List<Resultado> ObtenerResultados()
        {
            List<Resultado> resultado = new List<Resultado>();
            foreach (var item in ListaPalabras)
            {
                resultado.Add(Scrapper.returnResultado(item));
            }
            return resultado;
        }

        public void GuardarArchivo()
        {
            List<string> Archivo = CrearArchivo(ObtenerResultados());
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Texto |*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllLines(saveFileDialog.FileName, Archivo);
                }catch(IOException e)
                {
                    MessageBox.Show("Error al guardar: " + e.ToString());
                }
            }
        }

        List<string> CrearArchivo(List<Resultado> resultados)
        {
            List<string> strings = new List<string>();

            foreach(Resultado resultado in resultados)
            {
                string aux = resultado.PalabraBuscada + "; " + "[" + resultado.Pronunciacion + "]; ";
                foreach (string trad in resultado.Traducciones)
                {
                    foreach(string sep in trad.Trim().Split(", "))
                        aux += !aux.Contains(sep) ? sep.Trim() + ", " : "";
                }
                aux = aux.Length> 2? aux.Substring(0, aux.Length - 2) : aux;

                if(resultado.Traducciones.Count>0)
                    strings.Add(aux);

            }

            return strings;
        }

    }
}
