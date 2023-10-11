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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de la materia:";
            // 
            // tb_NombreMateria
            // 
            this.tb_NombreMateria.Location = new System.Drawing.Point(125, 9);
            this.tb_NombreMateria.Name = "tb_NombreMateria";
            this.tb_NombreMateria.Size = new System.Drawing.Size(246, 20);
            this.tb_NombreMateria.TabIndex = 1;
            // 
            // btn_CrearMateria
            // 
            this.btn_CrearMateria.Location = new System.Drawing.Point(161, 310);
            this.btn_CrearMateria.Name = "btn_CrearMateria";
            this.btn_CrearMateria.Size = new System.Drawing.Size(75, 23);
            this.btn_CrearMateria.TabIndex = 2;
            this.btn_CrearMateria.Text = "Crear";
            this.btn_CrearMateria.UseVisualStyleBackColor = true;
            this.btn_CrearMateria.Click += new System.EventHandler(this.btn_CrearMateria_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cupo Máximo:";
            // 
            // tb_CupoMaximo
            // 
            this.tb_CupoMaximo.Location = new System.Drawing.Point(125, 43);
            this.tb_CupoMaximo.Name = "tb_CupoMaximo";
            this.tb_CupoMaximo.Size = new System.Drawing.Size(246, 20);
            this.tb_CupoMaximo.TabIndex = 4;
            // 
            // tb_DescripcionMateria
            // 
            this.tb_DescripcionMateria.Location = new System.Drawing.Point(125, 84);
            this.tb_DescripcionMateria.Name = "tb_DescripcionMateria";
            this.tb_DescripcionMateria.Size = new System.Drawing.Size(246, 20);
            this.tb_DescripcionMateria.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Descripción:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha de inicio:";
            // 
            // dtp_FechaFin
            // 
            this.dtp_FechaFin.Location = new System.Drawing.Point(125, 162);
            this.dtp_FechaFin.Name = "dtp_FechaFin";
            this.dtp_FechaFin.Size = new System.Drawing.Size(246, 20);
            this.dtp_FechaFin.TabIndex = 9;
            // 
            // dtp_FechaInicio
            // 
            this.dtp_FechaInicio.Location = new System.Drawing.Point(125, 126);
            this.dtp_FechaInicio.Name = "dtp_FechaInicio";
            this.dtp_FechaInicio.Size = new System.Drawing.Size(246, 20);
            this.dtp_FechaInicio.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fecha de fin:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Horarios:";
            // 
            // tb_Horarios
            // 
            this.tb_Horarios.Location = new System.Drawing.Point(125, 204);
            this.tb_Horarios.Name = "tb_Horarios";
            this.tb_Horarios.Size = new System.Drawing.Size(246, 20);
            this.tb_Horarios.TabIndex = 12;
            // 
            // comboBoxProfesores
            // 
            this.comboBoxProfesores.FormattingEnabled = true;
            this.comboBoxProfesores.Location = new System.Drawing.Point(125, 247);
            this.comboBoxProfesores.Name = "comboBoxProfesores";
            this.comboBoxProfesores.Size = new System.Drawing.Size(246, 21);
            this.comboBoxProfesores.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 255);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Profesor:";
            // 
            // CrearMateriaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 345);
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
            this.Name = "CrearMateriaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CrearMateriaForm";
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
    }
}