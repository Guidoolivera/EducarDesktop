namespace EducarWeb
{
    partial class SolicitarInscripcionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolicitarInscripcionForm));
            this.comboBoxMaterias = new System.Windows.Forms.ComboBox();
            this.btn_SolicitarInscripcion = new System.Windows.Forms.Button();
            this.lbl_bienvenido = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxMaterias
            // 
            this.comboBoxMaterias.BackColor = System.Drawing.Color.White;
            this.comboBoxMaterias.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxMaterias.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMaterias.FormattingEnabled = true;
            this.comboBoxMaterias.Location = new System.Drawing.Point(12, 102);
            this.comboBoxMaterias.Name = "comboBoxMaterias";
            this.comboBoxMaterias.Size = new System.Drawing.Size(342, 35);
            this.comboBoxMaterias.TabIndex = 0;
            // 
            // btn_SolicitarInscripcion
            // 
            this.btn_SolicitarInscripcion.BackColor = System.Drawing.Color.White;
            this.btn_SolicitarInscripcion.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btn_SolicitarInscripcion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite;
            this.btn_SolicitarInscripcion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_SolicitarInscripcion.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SolicitarInscripcion.Location = new System.Drawing.Point(116, 185);
            this.btn_SolicitarInscripcion.Name = "btn_SolicitarInscripcion";
            this.btn_SolicitarInscripcion.Size = new System.Drawing.Size(134, 36);
            this.btn_SolicitarInscripcion.TabIndex = 1;
            this.btn_SolicitarInscripcion.Text = "Solicitar inscripción";
            this.btn_SolicitarInscripcion.UseVisualStyleBackColor = false;
            this.btn_SolicitarInscripcion.Click += new System.EventHandler(this.btn_SolicitarInscripcion_Click);
            // 
            // lbl_bienvenido
            // 
            this.lbl_bienvenido.AutoSize = true;
            this.lbl_bienvenido.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_bienvenido.Location = new System.Drawing.Point(111, 9);
            this.lbl_bienvenido.Name = "lbl_bienvenido";
            this.lbl_bienvenido.Size = new System.Drawing.Size(139, 27);
            this.lbl_bienvenido.TabIndex = 2;
            this.lbl_bienvenido.Text = "Listado de materias";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seleccione una:";
            // 
            // SolicitarInscripcionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(366, 264);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_bienvenido);
            this.Controls.Add(this.btn_SolicitarInscripcion);
            this.Controls.Add(this.comboBoxMaterias);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SolicitarInscripcionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitar inscripción";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxMaterias;
        private System.Windows.Forms.Button btn_SolicitarInscripcion;
        private System.Windows.Forms.Label lbl_bienvenido;
        private System.Windows.Forms.Label label1;
    }
}