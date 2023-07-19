namespace DictionaryCambridgeScrapper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxPalabras = new System.Windows.Forms.RichTextBox();
            this.buttonObtener = new System.Windows.Forms.Button();
            this.buttonCargarArchivo = new System.Windows.Forms.Button();
            this.checkBoxCargarDesdeArchivo = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.comboBoxIdioma = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBoxPalabras
            // 
            this.richTextBoxPalabras.Enabled = false;
            this.richTextBoxPalabras.Location = new System.Drawing.Point(12, 42);
            this.richTextBoxPalabras.Name = "richTextBoxPalabras";
            this.richTextBoxPalabras.Size = new System.Drawing.Size(325, 328);
            this.richTextBoxPalabras.TabIndex = 0;
            this.richTextBoxPalabras.Text = "";
            // 
            // buttonObtener
            // 
            this.buttonObtener.Location = new System.Drawing.Point(12, 388);
            this.buttonObtener.Name = "buttonObtener";
            this.buttonObtener.Size = new System.Drawing.Size(94, 29);
            this.buttonObtener.TabIndex = 1;
            this.buttonObtener.Text = "Obtener";
            this.buttonObtener.UseVisualStyleBackColor = true;
            this.buttonObtener.Click += new System.EventHandler(this.buttonObtener_Click);
            // 
            // buttonCargarArchivo
            // 
            this.buttonCargarArchivo.Location = new System.Drawing.Point(343, 42);
            this.buttonCargarArchivo.Name = "buttonCargarArchivo";
            this.buttonCargarArchivo.Size = new System.Drawing.Size(116, 29);
            this.buttonCargarArchivo.TabIndex = 0;
            this.buttonCargarArchivo.Text = "Cargar Archivo";
            this.buttonCargarArchivo.UseVisualStyleBackColor = true;
            this.buttonCargarArchivo.Click += new System.EventHandler(this.buttonCargarArchivo_Click);
            // 
            // checkBoxCargarDesdeArchivo
            // 
            this.checkBoxCargarDesdeArchivo.AutoSize = true;
            this.checkBoxCargarDesdeArchivo.Checked = true;
            this.checkBoxCargarDesdeArchivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCargarDesdeArchivo.Location = new System.Drawing.Point(12, 12);
            this.checkBoxCargarDesdeArchivo.Name = "checkBoxCargarDesdeArchivo";
            this.checkBoxCargarDesdeArchivo.Size = new System.Drawing.Size(171, 24);
            this.checkBoxCargarDesdeArchivo.TabIndex = 2;
            this.checkBoxCargarDesdeArchivo.Text = "Cargar desde archivo";
            this.checkBoxCargarDesdeArchivo.UseVisualStyleBackColor = true;
            this.checkBoxCargarDesdeArchivo.CheckedChanged += new System.EventHandler(this.checkBoxCargarDesdeArchivo_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(121, 396);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(277, 21);
            this.progressBar1.Step = 5;
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Visible = false;
            // 
            // comboBoxIdioma
            // 
            this.comboBoxIdioma.FormattingEnabled = true;
            this.comboBoxIdioma.Items.AddRange(new object[] {
            "Ingles",
            "Español"});
            this.comboBoxIdioma.Location = new System.Drawing.Point(549, 41);
            this.comboBoxIdioma.Name = "comboBoxIdioma";
            this.comboBoxIdioma.Size = new System.Drawing.Size(151, 28);
            this.comboBoxIdioma.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(484, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Idioma:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxIdioma);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.checkBoxCargarDesdeArchivo);
            this.Controls.Add(this.buttonCargarArchivo);
            this.Controls.Add(this.buttonObtener);
            this.Controls.Add(this.richTextBoxPalabras);
            this.Name = "Form1";
            this.Text = "Dictionary Cambridge Scrapper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox richTextBoxPalabras;
        private Button buttonObtener;
        private Button buttonCargarArchivo;
        private CheckBox checkBoxCargarDesdeArchivo;
        private ProgressBar progressBar1;
        private ComboBox comboBoxIdioma;
        private Label label1;
    }
}