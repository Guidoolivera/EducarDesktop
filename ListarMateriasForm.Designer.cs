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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListarMateriasForm));
            this.dgvMaterias = new System.Windows.Forms.DataGridView();
            this.listBoxAlumnos = new System.Windows.Forms.ListBox();
            this.lblAlumnosInscritos = new System.Windows.Forms.Label();
            this.btnGenerarPDFs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterias)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMaterias
            // 
            this.dgvMaterias.BackgroundColor = System.Drawing.Color.White;
            this.dgvMaterias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMaterias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterias.Location = new System.Drawing.Point(12, 34);
            this.dgvMaterias.Name = "dgvMaterias";
            this.dgvMaterias.Size = new System.Drawing.Size(506, 220);
            this.dgvMaterias.TabIndex = 0;
            // 
            // listBoxAlumnos
            // 
            this.listBoxAlumnos.BackColor = System.Drawing.Color.White;
            this.listBoxAlumnos.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAlumnos.FormattingEnabled = true;
            this.listBoxAlumnos.ItemHeight = 27;
            this.listBoxAlumnos.Location = new System.Drawing.Point(580, 34);
            this.listBoxAlumnos.Name = "listBoxAlumnos";
            this.listBoxAlumnos.Size = new System.Drawing.Size(179, 220);
            this.listBoxAlumnos.TabIndex = 1;
            // 
            // lblAlumnosInscritos
            // 
            this.lblAlumnosInscritos.AutoSize = true;
            this.lblAlumnosInscritos.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlumnosInscritos.Location = new System.Drawing.Point(578, 4);
            this.lblAlumnosInscritos.Name = "lblAlumnosInscritos";
            this.lblAlumnosInscritos.Size = new System.Drawing.Size(141, 27);
            this.lblAlumnosInscritos.TabIndex = 2;
            this.lblAlumnosInscritos.Text = "Alumnos inscriptos:";
            // 
            // btnGenerarPDFs
            // 
            this.btnGenerarPDFs.BackColor = System.Drawing.Color.White;
            this.btnGenerarPDFs.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnGenerarPDFs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btnGenerarPDFs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarPDFs.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarPDFs.Location = new System.Drawing.Point(583, 276);
            this.btnGenerarPDFs.Name = "btnGenerarPDFs";
            this.btnGenerarPDFs.Size = new System.Drawing.Size(176, 36);
            this.btnGenerarPDFs.TabIndex = 5;
            this.btnGenerarPDFs.Text = "Generar PDF";
            this.btnGenerarPDFs.UseVisualStyleBackColor = false;
            this.btnGenerarPDFs.Click += new System.EventHandler(this.btnGenerarPDFs_Click);
            // 
            // ListarMateriasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(784, 330);
            this.Controls.Add(this.btnGenerarPDFs);
            this.Controls.Add(this.lblAlumnosInscritos);
            this.Controls.Add(this.listBoxAlumnos);
            this.Controls.Add(this.dgvMaterias);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListarMateriasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de materias";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMaterias;
        private System.Windows.Forms.ListBox listBoxAlumnos;
        private System.Windows.Forms.Label lblAlumnosInscritos;
        private System.Windows.Forms.Button btnGenerarPDFs;
    }
}