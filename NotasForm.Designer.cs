namespace EducarWeb
{
    partial class NotasForm
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
            this.txtNota = new System.Windows.Forms.TextBox();
            this.btnGuardarNotas = new System.Windows.Forms.Button();
            this.comboBoxCursos = new System.Windows.Forms.ComboBox();
            this.comboBoxMaterias = new System.Windows.Forms.ComboBox();
            this.comboBoxAlumnos = new System.Windows.Forms.ComboBox();
            this.comboBoxTrimestre = new System.Windows.Forms.ComboBox();
            this.lblAlumnosInscritos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNota
            // 
            this.txtNota.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNota.Location = new System.Drawing.Point(266, 45);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(134, 26);
            this.txtNota.TabIndex = 1;
            // 
            // btnGuardarNotas
            // 
            this.btnGuardarNotas.BackColor = System.Drawing.Color.White;
            this.btnGuardarNotas.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarNotas.Location = new System.Drawing.Point(266, 130);
            this.btnGuardarNotas.Name = "btnGuardarNotas";
            this.btnGuardarNotas.Size = new System.Drawing.Size(134, 30);
            this.btnGuardarNotas.TabIndex = 4;
            this.btnGuardarNotas.Text = "GUARDAR NOTA";
            this.btnGuardarNotas.UseVisualStyleBackColor = false;
            this.btnGuardarNotas.Click += new System.EventHandler(this.btnGuardarNotas_Click);
            // 
            // comboBoxCursos
            // 
            this.comboBoxCursos.BackColor = System.Drawing.Color.White;
            this.comboBoxCursos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxCursos.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCursos.FormattingEnabled = true;
            this.comboBoxCursos.Location = new System.Drawing.Point(12, 45);
            this.comboBoxCursos.Name = "comboBoxCursos";
            this.comboBoxCursos.Size = new System.Drawing.Size(191, 30);
            this.comboBoxCursos.TabIndex = 5;
            this.comboBoxCursos.SelectedIndexChanged += new System.EventHandler(this.comboBoxCursos_SelectedIndexChanged);
            // 
            // comboBoxMaterias
            // 
            this.comboBoxMaterias.BackColor = System.Drawing.Color.White;
            this.comboBoxMaterias.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxMaterias.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMaterias.FormattingEnabled = true;
            this.comboBoxMaterias.Location = new System.Drawing.Point(12, 131);
            this.comboBoxMaterias.Name = "comboBoxMaterias";
            this.comboBoxMaterias.Size = new System.Drawing.Size(191, 30);
            this.comboBoxMaterias.TabIndex = 6;
            this.comboBoxMaterias.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaterias_SelectedIndexChanged);
            // 
            // comboBoxAlumnos
            // 
            this.comboBoxAlumnos.BackColor = System.Drawing.Color.White;
            this.comboBoxAlumnos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxAlumnos.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAlumnos.FormattingEnabled = true;
            this.comboBoxAlumnos.Location = new System.Drawing.Point(12, 214);
            this.comboBoxAlumnos.Name = "comboBoxAlumnos";
            this.comboBoxAlumnos.Size = new System.Drawing.Size(191, 30);
            this.comboBoxAlumnos.TabIndex = 7;
            // 
            // comboBoxTrimestre
            // 
            this.comboBoxTrimestre.BackColor = System.Drawing.Color.White;
            this.comboBoxTrimestre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxTrimestre.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTrimestre.FormattingEnabled = true;
            this.comboBoxTrimestre.Location = new System.Drawing.Point(12, 297);
            this.comboBoxTrimestre.Name = "comboBoxTrimestre";
            this.comboBoxTrimestre.Size = new System.Drawing.Size(191, 30);
            this.comboBoxTrimestre.TabIndex = 8;
            // 
            // lblAlumnosInscritos
            // 
            this.lblAlumnosInscritos.AutoSize = true;
            this.lblAlumnosInscritos.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlumnosInscritos.Location = new System.Drawing.Point(12, 184);
            this.lblAlumnosInscritos.Name = "lblAlumnosInscritos";
            this.lblAlumnosInscritos.Size = new System.Drawing.Size(134, 27);
            this.lblAlumnosInscritos.TabIndex = 9;
            this.lblAlumnosInscritos.Text = "Seleccione alumno:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 27);
            this.label1.TabIndex = 10;
            this.label1.Text = "Seleccione materia:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 27);
            this.label2.TabIndex = 11;
            this.label2.Text = "Seleccione curso:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 27);
            this.label3.TabIndex = 12;
            this.label3.Text = "Seleccione trimestre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(261, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 27);
            this.label4.TabIndex = 13;
            this.label4.Text = "Ingrese nota:";
            // 
            // NotasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(423, 354);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAlumnosInscritos);
            this.Controls.Add(this.comboBoxTrimestre);
            this.Controls.Add(this.comboBoxAlumnos);
            this.Controls.Add(this.comboBoxMaterias);
            this.Controls.Add(this.comboBoxCursos);
            this.Controls.Add(this.btnGuardarNotas);
            this.Controls.Add(this.txtNota);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "NotasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NotasForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Button btnGuardarNotas;
        private System.Windows.Forms.ComboBox comboBoxCursos;
        private System.Windows.Forms.ComboBox comboBoxMaterias;
        private System.Windows.Forms.ComboBox comboBoxAlumnos;
        private System.Windows.Forms.ComboBox comboBoxTrimestre;
        private System.Windows.Forms.Label lblAlumnosInscritos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}