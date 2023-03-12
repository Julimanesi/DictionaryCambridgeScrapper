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

        List<string> list = new List<string>();

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
            list=list.Distinct().ToList();
            progreso.Visible = true;
            progreso.Maximum = list.Count;
            progreso.Value = 0;
            buttonObtener.Text = "Obteniendo";
            Exportar exportar = new Exportar(list);
            exportar.GuardarArchivo();

            progreso.Visible = false;
            buttonObtener.Text = "Obtener";
        }
    }
}