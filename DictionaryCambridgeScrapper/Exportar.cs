using InglesToAnki;
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

        async Task<List<Resultado>> ObtenerResultados()
        {
            List<Resultado> resultado = new List<Resultado>();
            foreach (var item in ListaPalabras)
            {
                resultado.Add(Scrapper.returnResultado(item));
                //resultado.Add(await DictionaryApi.returnResultado(item)); 
                //Agregar las traducciones de la otra api
            }
            return resultado;
        }

        public async void GuardarArchivo()
        {
            List<string> Archivo = CrearArchivo(await ObtenerResultados());
            List<string> SinTraducir = Archivo.Where(x => x.Contains("; []; ;;")).Select(x=>x.Replace("; []; ;;", "")).ToList();
            Archivo = Archivo.Where(x => !x.Contains("; []; ;;")).ToList();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Texto |*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllLines(saveFileDialog.FileName, Archivo);
                    System.IO.File.WriteAllLines(saveFileDialog.FileName.Insert(saveFileDialog.FileName.LastIndexOf(".txt"),"_SinTraducir"), SinTraducir);
                    System.IO.File.AppendAllLines(Form1.PathArchivoYaImportadas,ListaPalabras);
                }
                catch(IOException e)
                {
                    MessageBox.Show("Error al guardar: " + e.ToString());
                }
            }
        }

        List<string> CrearArchivo(List<Resultado> resultados)
        {
            List<string> strings = new List<string>();

            foreach(Resultado resultado in resultados.DistinctBy(x=>x.PalabraBuscada).ToList())
            {
                string aux = resultado.PalabraBuscada + "; " + "[" + resultado.Pronunciacion + "]; ";
                
                aux += string.Join('\n', resultado.OracionesEjemIngles);
                aux += ";";
                aux += string.Join('\n', SeparadorString(resultado.Definiciones));
                aux += ";";
                aux += string.Join('\n', SeparadorString(resultado.Traducciones));
                strings.Add(aux);
            }

            return strings;
        }
        string SeparadorString(List<string> ListaString) 
        {
            string aux = "";
            foreach (string trad in ListaString)
            {
                foreach (string sep in trad.Trim().Split(", "))
                    aux += !aux.Contains(sep) ? sep.Trim() + ", " : "";
            }
            aux = aux.Length > 2 ? aux.Substring(0, aux.Length - 2) : aux;
            return aux;
        }
    }
}
