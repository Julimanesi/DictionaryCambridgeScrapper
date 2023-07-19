using InglesToAnki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DictionaryCambridgeScrapper.Form1;

namespace DictionaryCambridgeScrapper
{
    public class Exportar
    {
        public List<string> ListaPalabras { get; set; }

        public Exportar(List<string> listaPalabras)
        {
            ListaPalabras = listaPalabras;
        }

        async Task<List<ResultadoIngles>> ObtenerResultadosIngles()
        {
            List<ResultadoIngles> resultado = new List<ResultadoIngles>();
            foreach (var item in ListaPalabras)
            {
                resultado.Add(DictionaryCambridgeScrapper.returnResultado(item));
                //resultado.Add(await DictionaryApi.returnResultado(item)); 
                //Agregar las traducciones de la otra api
            }
            return resultado;
        }

        public async void GuardarArchivoIngles()
        {
            List<string> Archivo = CrearArchivoIngles(await ObtenerResultadosIngles());
            List<string> SinTraducir = Archivo.Where(x => x.Contains("; []; ;;")).Select(x=>x.Replace("; []; ;;", "")).ToList();
            Archivo = Archivo.Where(x => !x.Contains("; []; ;;")).ToList();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Texto |*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllLines(saveFileDialog.FileName, Archivo);
                    if (SinTraducir.Count > 0)
                        System.IO.File.WriteAllLines(saveFileDialog.FileName.Insert(saveFileDialog.FileName.LastIndexOf(".txt"),"_SinTraducir"), SinTraducir);
                    System.IO.File.AppendAllLines(Form1.PathArchivoYaImportadasIngles,ListaPalabras);
                }
                catch(IOException e)
                {
                    MessageBox.Show("Error al guardar: " + e.ToString());
                }
            }
        }

        List<string> CrearArchivoIngles(List<ResultadoIngles> resultados)
        {
            List<string> strings = new List<string>();

            foreach(ResultadoIngles resultado in resultados.DistinctBy(x=>x.PalabraBuscada).ToList())
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

        async Task<List<ResultadoEspaniol>> ObtenerResultadosEspaniol()
        {
            List<ResultadoEspaniol> resultado = new List<ResultadoEspaniol>();
            foreach (var item in ListaPalabras)
            {
                resultado.Add(DiccionarioEspaniolScrapper.returnResultado(item));
                //resultado.Add(await DictionaryApi.returnResultado(item)); 
                //Agregar las traducciones de la otra api
            }
            return resultado;
        }

        public async void GuardarArchivoEspaniol()
        {
            List<string> Archivo = CrearArchivoEspaniol(await ObtenerResultadosEspaniol());
            List<string> SinTraducir = Archivo.Where(x => x.Contains(";;;;;")).Select(x => x.Replace(";;;;;", "")).ToList();
            Archivo = Archivo.Where(x => !x.Contains(";;;;;")).ToList();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Texto |*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllLines(saveFileDialog.FileName, Archivo);
                    if(SinTraducir.Count>0)
                        System.IO.File.WriteAllLines(saveFileDialog.FileName.Insert(saveFileDialog.FileName.LastIndexOf(".txt"), "_SinTraducir"), SinTraducir);
                    System.IO.File.AppendAllLines(Form1.PathArchivoYaImportadasEspaniol, ListaPalabras);
                }
                catch (IOException e)
                {
                    MessageBox.Show("Error al guardar: " + e.ToString());
                }
            }
        }

        List<string> CrearArchivoEspaniol(List<ResultadoEspaniol> resultados)
        {
            List<string> strings = new List<string>();

            foreach (ResultadoEspaniol resultado in resultados.DistinctBy(x => x.Palabra).ToList())
            {
                string aux = resultado.Palabra + ";";
                aux += string.Join(' ', resultado.Variantes);
                aux += ";";
                aux += resultado.etimologia.FirstOrDefault() ?? "";
                aux += ";";
                aux += resultado.Ortografia.FirstOrDefault() ?? "";
                aux += ";";
                aux += string.Join(' ', resultado.Definiciones);
                aux += ";";
                aux += string.Join(' ', resultado.FormasComplejas);
                strings.Add(aux);
            }

            return strings;
        }
    }
}
