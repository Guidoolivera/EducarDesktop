namespace EducarWeb
{
    partial class InscribirAlumnoForm
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
            this.comboBoxMaterias = new System.Windows.Forms.ComboBox();
            this.btn_InscribirAlumno = new System.Windows.Forms.Button();
            this.tb_idAlumno = new System.Windows.Forms.TextBox();
            this.lbl_Username = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxMaterias
            // 
            this.comboBoxMaterias.FormattingEnabled = true;
            this.comboBoxMaterias.Location = new System.Drawing.Point(12, 28);
            this.comboBoxMaterias.Name = "comboBoxMaterias";
            this.comboBoxMaterias.Size = new System.Drawing.Size(380, 21);
            this.comboBoxMaterias.TabIndex = 1;
            // 
            // btn_InscribirAlumno
            // 
            this.btn_InscribirAlumno.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_InscribirAlumno.Location = new System.Drawing.Point(267, 224);
            this.btn_InscribirAlumno.Name = "btn_InscribirAlumno";
            this.btn_InscribirAlumno.Size = new System.Drawing.Size(125, 31);
            this.btn_InscribirAlumno.TabIndex = 3;
            this.btn_InscribirAlumno.Text = "Inscribir Alumno";
            this.btn_InscribirAlumno.UseVisualStyleBackColor = false;
            this.btn_InscribirAlumno.Click += new System.EventHandler(this.btn_InscribirAlumno_Click);
            // 
            // tb_idAlumno
            // 
            this.tb_idAlumno.Font = new System.Drawing.Font("Dubai", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_idAlumno.Location = new System.Drawing.Point(189, 226);
            this.tb_idAlumno.Name = "tb_idAlumno";
            this.tb_idAlumno.Size = new System.Drawing.Size(72, 29);
            this.tb_idAlumno.TabIndex = 4;
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Username.Location = new System.Drawing.Point(7, 226);
            this.lbl_Username.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(169, 27);
            this.lbl_Username.TabIndex = 5;
            this.lbl_Username.Text = "ID de alumno a inscribir:";
            // 
            // InscribirAlumnoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(417, 268);
            this.Controls.Add(this.lbl_Username);
            this.Controls.Add(this.tb_idAlumno);
            this.Controls.Add(this.btn_InscribirAlumno);
            this.Controls.Add(this.comboBoxMaterias);
            this.Name = "InscribirAlumnoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListarMateriasForm";
            this.Load += new System.EventHandler(this.ListarMateriasForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxMaterias;
        private System.Windows.Forms.Button btn_InscribirAlumno;
        private System.Windows.Forms.TextBox tb_idAlumno;
        private System.Windows.Forms.Label lbl_Username;
    }
}