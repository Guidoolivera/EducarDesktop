namespace EducarWeb
{
    partial class GestionCursosForm
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
            this.dgvCursos = new System.Windows.Forms.DataGridView();
            this.btnImprimirPDF = new System.Windows.Forms.Button();
            this.lbl_Username = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNombreCurso = new System.Windows.Forms.TextBox();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.tbDescripcionCurso = new System.Windows.Forms.TextBox();
            this.btnCrearCurso = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAulaCurso = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCursos
            // 
            this.dgvCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursos.Location = new System.Drawing.Point(583, 51);
            this.dgvCursos.Name = "dgvCursos";
            this.dgvCursos.Size = new System.Drawing.Size(447, 150);
            this.dgvCursos.TabIndex = 0;
            // 
            // btnImprimirPDF
            // 
            this.btnImprimirPDF.BackColor = System.Drawing.Color.SkyBlue;
            this.btnImprimirPDF.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnImprimirPDF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnImprimirPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirPDF.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirPDF.Location = new System.Drawing.Point(715, 243);
            this.btnImprimirPDF.Name = "btnImprimirPDF";
            this.btnImprimirPDF.Size = new System.Drawing.Size(226, 36);
            this.btnImprimirPDF.TabIndex = 5;
            this.btnImprimirPDF.Text = "Imprimir listado de cursos";
            this.btnImprimirPDF.UseVisualStyleBackColor = false;
            this.btnImprimirPDF.Click += new System.EventHandler(this.btnImprimirPDF_Click);
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Username.Location = new System.Drawing.Point(172, 9);
            this.lbl_Username.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(129, 27);
            this.lbl_Username.TabIndex = 6;
            this.lbl_Username.Text = "Crear nuevo curso";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 27);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 27);
            this.label2.TabIndex = 8;
            this.label2.Text = "Descripción:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 27);
            this.label3.TabIndex = 9;
            this.label3.Text = "Fecha de inicio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 174);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 27);
            this.label4.TabIndex = 10;
            this.label4.Text = "Fecha de fin:";
            // 
            // tbNombreCurso
            // 
            this.tbNombreCurso.Location = new System.Drawing.Point(124, 53);
            this.tbNombreCurso.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbNombreCurso.Name = "tbNombreCurso";
            this.tbNombreCurso.Size = new System.Drawing.Size(400, 20);
            this.tbNombreCurso.TabIndex = 11;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(124, 136);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(400, 20);
            this.dtpFechaInicio.TabIndex = 12;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(124, 175);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(400, 20);
            this.dtpFechaFin.TabIndex = 13;
            // 
            // tbDescripcionCurso
            // 
            this.tbDescripcionCurso.Location = new System.Drawing.Point(124, 96);
            this.tbDescripcionCurso.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbDescripcionCurso.Name = "tbDescripcionCurso";
            this.tbDescripcionCurso.Size = new System.Drawing.Size(400, 20);
            this.tbDescripcionCurso.TabIndex = 14;
            // 
            // btnCrearCurso
            // 
            this.btnCrearCurso.BackColor = System.Drawing.Color.SkyBlue;
            this.btnCrearCurso.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btnCrearCurso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnCrearCurso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearCurso.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearCurso.Location = new System.Drawing.Point(177, 262);
            this.btnCrearCurso.Name = "btnCrearCurso";
            this.btnCrearCurso.Size = new System.Drawing.Size(176, 36);
            this.btnCrearCurso.TabIndex = 15;
            this.btnCrearCurso.Text = "Crear curso";
            this.btnCrearCurso.UseVisualStyleBackColor = false;
            this.btnCrearCurso.Click += new System.EventHandler(this.btnCrearCurso_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 222);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 27);
            this.label5.TabIndex = 16;
            this.label5.Text = "Aula:";
            // 
            // tbAulaCurso
            // 
            this.tbAulaCurso.Location = new System.Drawing.Point(124, 226);
            this.tbAulaCurso.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tbAulaCurso.Name = "tbAulaCurso";
            this.tbAulaCurso.Size = new System.Drawing.Size(400, 20);
            this.tbAulaCurso.TabIndex = 17;
            // 
            // GestionCursosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 338);
            this.Controls.Add(this.tbAulaCurso);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCrearCurso);
            this.Controls.Add(this.tbDescripcionCurso);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.tbNombreCurso);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_Username);
            this.Controls.Add(this.btnImprimirPDF);
            this.Controls.Add(this.dgvCursos);
            this.Name = "GestionCursosForm";
            this.Text = "GestionCursosForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCursos;
        private System.Windows.Forms.Button btnImprimirPDF;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNombreCurso;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.TextBox tbDescripcionCurso;
        private System.Windows.Forms.Button btnCrearCurso;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbAulaCurso;
    }
}