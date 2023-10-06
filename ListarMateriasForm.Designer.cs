namespace EducarWeb
{
    partial class ListarMateriasForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewMaterias = new System.Windows.Forms.DataGridView();
            this.comboBoxAlumnos = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaterias)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMaterias
            // 
            this.dataGridViewMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMaterias.Location = new System.Drawing.Point(34, 35);
            this.dataGridViewMaterias.Name = "dataGridViewMaterias";
            this.dataGridViewMaterias.Size = new System.Drawing.Size(487, 214);
            this.dataGridViewMaterias.TabIndex = 0;
            dataGridViewMaterias.CellFormatting += dataGridViewMaterias_CellFormatting;
            // 
            // comboBoxAlumnos
            // 
            this.comboBoxAlumnos.FormattingEnabled = true;
            this.comboBoxAlumnos.Location = new System.Drawing.Point(34, 280);
            this.comboBoxAlumnos.Name = "comboBoxAlumnos";
            this.comboBoxAlumnos.Size = new System.Drawing.Size(487, 21);
            this.comboBoxAlumnos.TabIndex = 1;
            // 
            // ListarMateriasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(557, 384);
            this.Controls.Add(this.comboBoxAlumnos);
            this.Controls.Add(this.dataGridViewMaterias);
            this.Name = "ListarMateriasForm";
            this.Text = "InscribirAMateriaForm";
            this.Load += new System.EventHandler(this.ListarMateriasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaterias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMaterias;
        private System.Windows.Forms.ComboBox comboBoxAlumnos;
    }
}