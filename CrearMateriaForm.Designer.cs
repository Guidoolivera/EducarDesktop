namespace EducarWeb
{
    partial class CrearMateriaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearMateriaForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tb_NombreMateria = new System.Windows.Forms.TextBox();
            this.btn_CrearMateria = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_CupoMaximo = new System.Windows.Forms.TextBox();
            this.tb_DescripcionMateria = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_FechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtp_FechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_Horarios = new System.Windows.Forms.TextBox();
            this.comboBoxProfesores = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxCursos = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de la materia:";
            // 
            // tb_NombreMateria
            // 
            this.tb_NombreMateria.Location = new System.Drawing.Point(167, 42);
            this.tb_NombreMateria.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tb_NombreMateria.Name = "tb_NombreMateria";
            this.tb_NombreMateria.Size = new System.Drawing.Size(327, 35);
            this.tb_NombreMateria.TabIndex = 1;
            // 
            // btn_CrearMateria
            // 
            this.btn_CrearMateria.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_CrearMateria.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btn_CrearMateria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btn_CrearMateria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CrearMateria.Location = new System.Drawing.Point(214, 438);
            this.btn_CrearMateria.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_CrearMateria.Name = "btn_CrearMateria";
            this.btn_CrearMateria.Size = new System.Drawing.Size(100, 48);
            this.btn_CrearMateria.TabIndex = 2;
            this.btn_CrearMateria.Text = "Crear";
            this.btn_CrearMateria.UseVisualStyleBackColor = false;
            this.btn_CrearMateria.Click += new System.EventHandler(this.btn_CrearMateria_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cupo Máximo:";
            // 
            // tb_CupoMaximo
            // 
            this.tb_CupoMaximo.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_CupoMaximo.Location = new System.Drawing.Point(167, 89);
            this.tb_CupoMaximo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tb_CupoMaximo.Name = "tb_CupoMaximo";
            this.tb_CupoMaximo.Size = new System.Drawing.Size(327, 35);
            this.tb_CupoMaximo.TabIndex = 4;
            // 
            // tb_DescripcionMateria
            // 
            this.tb_DescripcionMateria.Location = new System.Drawing.Point(167, 136);
            this.tb_DescripcionMateria.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tb_DescripcionMateria.Name = "tb_DescripcionMateria";
            this.tb_DescripcionMateria.Size = new System.Drawing.Size(327, 35);
            this.tb_DescripcionMateria.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 139);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 27);
            this.label3.TabIndex = 6;
            this.label3.Text = "Descripción:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(57, 189);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 27);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha de inicio:";
            // 
            // dtp_FechaFin
            // 
            this.dtp_FechaFin.Location = new System.Drawing.Point(167, 230);
            this.dtp_FechaFin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dtp_FechaFin.Name = "dtp_FechaFin";
            this.dtp_FechaFin.Size = new System.Drawing.Size(327, 35);
            this.dtp_FechaFin.TabIndex = 9;
            // 
            // dtp_FechaInicio
            // 
            this.dtp_FechaInicio.Location = new System.Drawing.Point(167, 183);
            this.dtp_FechaInicio.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dtp_FechaInicio.Name = "dtp_FechaInicio";
            this.dtp_FechaInicio.Size = new System.Drawing.Size(327, 35);
            this.dtp_FechaInicio.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(75, 236);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 27);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fecha de fin:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(95, 280);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 27);
            this.label6.TabIndex = 13;
            this.label6.Text = "Horarios:";
            // 
            // tb_Horarios
            // 
            this.tb_Horarios.Location = new System.Drawing.Point(167, 277);
            this.tb_Horarios.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tb_Horarios.Name = "tb_Horarios";
            this.tb_Horarios.Size = new System.Drawing.Size(327, 35);
            this.tb_Horarios.TabIndex = 12;
            // 
            // comboBoxProfesores
            // 
            this.comboBoxProfesores.FormattingEnabled = true;
            this.comboBoxProfesores.Location = new System.Drawing.Point(167, 324);
            this.comboBoxProfesores.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.comboBoxProfesores.Name = "comboBoxProfesores";
            this.comboBoxProfesores.Size = new System.Drawing.Size(327, 35);
            this.comboBoxProfesores.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(96, 324);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 27);
            this.label7.TabIndex = 15;
            this.label7.Text = "Profesor:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(106, 374);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 27);
            this.label8.TabIndex = 16;
            this.label8.Text = "Curso:";
            // 
            // comboBoxCursos
            // 
            this.comboBoxCursos.FormattingEnabled = true;
            this.comboBoxCursos.Location = new System.Drawing.Point(167, 371);
            this.comboBoxCursos.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.comboBoxCursos.Name = "comboBoxCursos";
            this.comboBoxCursos.Size = new System.Drawing.Size(327, 35);
            this.comboBoxCursos.TabIndex = 17;
            // 
            // CrearMateriaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(550, 501);
            this.Controls.Add(this.comboBoxCursos);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxProfesores);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_Horarios);
            this.Controls.Add(this.dtp_FechaInicio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtp_FechaFin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_DescripcionMateria);
            this.Controls.Add(this.tb_CupoMaximo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_CrearMateria);
            this.Controls.Add(this.tb_NombreMateria);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "CrearMateriaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear materia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_NombreMateria;
        private System.Windows.Forms.Button btn_CrearMateria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_CupoMaximo;
        private System.Windows.Forms.TextBox tb_DescripcionMateria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_FechaFin;
        private System.Windows.Forms.DateTimePicker dtp_FechaInicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_Horarios;
        private System.Windows.Forms.ComboBox comboBoxProfesores;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxCursos;
    }
}