namespace EducarWeb
{
    partial class MateriaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MateriaForm));
            this.btn_CrearMateria = new System.Windows.Forms.Button();
            this.btn_InscribirAlumno = new System.Windows.Forms.Button();
            this.btn_ListarMaterias = new System.Windows.Forms.Button();
            this.btn_GestionarInscripciones = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_CrearMateria
            // 
            this.btn_CrearMateria.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_CrearMateria.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btn_CrearMateria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btn_CrearMateria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CrearMateria.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CrearMateria.Location = new System.Drawing.Point(28, 23);
            this.btn_CrearMateria.Name = "btn_CrearMateria";
            this.btn_CrearMateria.Size = new System.Drawing.Size(176, 36);
            this.btn_CrearMateria.TabIndex = 0;
            this.btn_CrearMateria.Text = "Crear Materia";
            this.btn_CrearMateria.UseVisualStyleBackColor = false;
            this.btn_CrearMateria.Click += new System.EventHandler(this.btn_CrearMateria_Click);
            // 
            // btn_InscribirAlumno
            // 
            this.btn_InscribirAlumno.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_InscribirAlumno.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btn_InscribirAlumno.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btn_InscribirAlumno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_InscribirAlumno.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_InscribirAlumno.Location = new System.Drawing.Point(28, 191);
            this.btn_InscribirAlumno.Name = "btn_InscribirAlumno";
            this.btn_InscribirAlumno.Size = new System.Drawing.Size(176, 36);
            this.btn_InscribirAlumno.TabIndex = 1;
            this.btn_InscribirAlumno.Text = "Solicitar Inscripción";
            this.btn_InscribirAlumno.UseVisualStyleBackColor = false;
            this.btn_InscribirAlumno.Click += new System.EventHandler(this.btn_InscribirAlumno_Click);
            // 
            // btn_ListarMaterias
            // 
            this.btn_ListarMaterias.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_ListarMaterias.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btn_ListarMaterias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btn_ListarMaterias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ListarMaterias.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ListarMaterias.Location = new System.Drawing.Point(28, 79);
            this.btn_ListarMaterias.Name = "btn_ListarMaterias";
            this.btn_ListarMaterias.Size = new System.Drawing.Size(176, 36);
            this.btn_ListarMaterias.TabIndex = 2;
            this.btn_ListarMaterias.Text = "Listado de materias";
            this.btn_ListarMaterias.UseVisualStyleBackColor = false;
            this.btn_ListarMaterias.Click += new System.EventHandler(this.btn_ListarMaterias_Click);
            // 
            // btn_GestionarInscripciones
            // 
            this.btn_GestionarInscripciones.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_GestionarInscripciones.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btn_GestionarInscripciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btn_GestionarInscripciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GestionarInscripciones.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GestionarInscripciones.Location = new System.Drawing.Point(28, 135);
            this.btn_GestionarInscripciones.Name = "btn_GestionarInscripciones";
            this.btn_GestionarInscripciones.Size = new System.Drawing.Size(176, 36);
            this.btn_GestionarInscripciones.TabIndex = 3;
            this.btn_GestionarInscripciones.Text = "Gestionar Inscripciones";
            this.btn_GestionarInscripciones.UseVisualStyleBackColor = false;
            this.btn_GestionarInscripciones.Click += new System.EventHandler(this.btn_GestionarInscripciones_Click);
            // 
            // MateriaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(242, 260);
            this.Controls.Add(this.btn_GestionarInscripciones);
            this.Controls.Add(this.btn_ListarMaterias);
            this.Controls.Add(this.btn_InscribirAlumno);
            this.Controls.Add(this.btn_CrearMateria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MateriaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de materias";
            this.Load += new System.EventHandler(this.MateriaForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_CrearMateria;
        private System.Windows.Forms.Button btn_InscribirAlumno;
        private System.Windows.Forms.Button btn_ListarMaterias;
        private System.Windows.Forms.Button btn_GestionarInscripciones;
    }
}