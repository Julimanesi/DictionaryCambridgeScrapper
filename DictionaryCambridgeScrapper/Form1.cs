using System.Security.Cryptography;

namespace DictionaryCambridgeScrapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            progreso = progressBar1;
        }

        public static ProgressBar progreso;
        public static string PathArchivoYaImportadasIngles = "ya_importadas_ingles.txt";
        public static string PathArchivoYaImportadasEspaniol = "ya_importadas_español.txt";

        List<string> list = new List<string>();
        List<string> listYaimportadasIngles = new List<string>();
        List<string> listYaimportadasEspaniol = new List<string>();

        private void checkBoxCargarDesdeArchivo_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxCargarDesdeArchivo.Checked)
            {
                richTextBoxPalabras.Enabled = false;
            }
            else
            {
                richTextBoxPalabras.Enabled = true;
            }
        }

        private void buttonCargarArchivo_Click(object sender, EventArgs e)
        {
            if (checkBoxCargarDesdeArchivo.Checked)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Texto |*.txt";
                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    list = System.IO.File.ReadAllLines(ofd.FileName).ToList();
                }
            }
        }

        private void buttonObtener_Click(object sender, EventArgs e)
        {
            if (!checkBoxCargarDesdeArchivo.Checked)
            {

                list = richTextBoxPalabras.Lines.ToList();
            }
            else
            {
                richTextBoxPalabras.Lines = list.ToArray();
            }

            list = list.Distinct().ToList();

            switch (comboBoxIdioma.SelectedIndex)
            {
                case 0://Ingles
                    ObtenerYaImportadasIngles();
                    list = list.Where(x => !listYaimportadasIngles.Contains(x)).ToList();
                    break;
                case 1://Español
                    //ObtenerYaImportadasEspaniol();
                    list = list.Where(x => !listYaimportadasEspaniol.Contains(x)).ToList();
                    break;
            }
            progreso.Visible = true;
            progreso.Maximum = list.Count;
            progreso.Value = 0;
            buttonObtener.Text = "Obteniendo";
            Exportar exportar = new Exportar(list);

            switch (comboBoxIdioma.SelectedIndex)
            {
                case 0://Ingles
                    exportar.GuardarArchivoIngles();
                    break;
                case 1://Español
                    exportar.GuardarArchivoEspaniol();
                    break;
            }

            progreso.Visible = false;
            buttonObtener.Text = "Obtener";
        }

        private void ObtenerYaImportadasIngles()
        {
            
            if (System.IO.File.Exists(PathArchivoYaImportadasIngles))
            {
                listYaimportadasIngles = System.IO.File.ReadAllLines(PathArchivoYaImportadasIngles).ToList();
                listYaimportadasIngles = listYaimportadasIngles.Distinct().ToList();
            }
            else
            {
                System.IO.File.Create(PathArchivoYaImportadasIngles);
            }
        }
        private void ObtenerYaImportadasEspaniol()
        {

            if (System.IO.File.Exists(PathArchivoYaImportadasEspaniol))
            {
                listYaimportadasEspaniol = System.IO.File.ReadAllLines(PathArchivoYaImportadasEspaniol).ToList();
                listYaimportadasEspaniol = listYaimportadasEspaniol.Distinct().ToList();
            }
            else
            {
                System.IO.File.Create(PathArchivoYaImportadasEspaniol);
            }
        }
    }
}