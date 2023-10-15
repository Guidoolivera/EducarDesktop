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
            this.dgvMaterias = new System.Windows.Forms.DataGridView();
            this.listBoxAlumnos = new System.Windows.Forms.ListBox();
            this.lblAlumnosInscritos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterias)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMaterias
            // 
            this.dgvMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterias.Location = new System.Drawing.Point(23, 40);
            this.dgvMaterias.Name = "dgvMaterias";
            this.dgvMaterias.Size = new System.Drawing.Size(436, 186);
            this.dgvMaterias.TabIndex = 0;
            // 
            // listBoxAlumnos
            // 
            this.listBoxAlumnos.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.listBoxAlumnos.FormattingEnabled = true;
            this.listBoxAlumnos.Location = new System.Drawing.Point(476, 40);
            this.listBoxAlumnos.Name = "listBoxAlumnos";
            this.listBoxAlumnos.Size = new System.Drawing.Size(166, 186);
            this.listBoxAlumnos.TabIndex = 1;
            // 
            // lblAlumnosInscritos
            // 
            this.lblAlumnosInscritos.AutoSize = true;
            this.lblAlumnosInscritos.Location = new System.Drawing.Point(473, 9);
            this.lblAlumnosInscritos.Name = "lblAlumnosInscritos";
            this.lblAlumnosInscritos.Size = new System.Drawing.Size(91, 13);
            this.lblAlumnosInscritos.TabIndex = 2;
            this.lblAlumnosInscritos.Text = "Alumnos inscritos:";
            // 
            // ListarMateriasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(654, 283);
            this.Controls.Add(this.lblAlumnosInscritos);
            this.Controls.Add(this.listBoxAlumnos);
            this.Controls.Add(this.dgvMaterias);
            this.Name = "ListarMateriasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListarMateriasForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMaterias;
        private System.Windows.Forms.ListBox listBoxAlumnos;
        private System.Windows.Forms.Label lblAlumnosInscritos;
    }
}