namespace EducarWeb
{
    partial class MainForm
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
            this.menuDesplegable = new System.Windows.Forms.Panel();
            this.btn_GestionarRoles = new System.Windows.Forms.Button();
            this.btn_Pagos = new System.Windows.Forms.Button();
            this.btn_Examenes = new System.Windows.Forms.Button();
            this.btn_Asistencia = new System.Windows.Forms.Button();
            this.btn_Materias = new System.Windows.Forms.Button();
            this.lbl_bienvenido = new System.Windows.Forms.Label();
            this.menuDesplegable.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuDesplegable
            // 
            this.menuDesplegable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.menuDesplegable.BackColor = System.Drawing.Color.SteelBlue;
            this.menuDesplegable.Controls.Add(this.btn_GestionarRoles);
            this.menuDesplegable.Controls.Add(this.btn_Pagos);
            this.menuDesplegable.Controls.Add(this.btn_Examenes);
            this.menuDesplegable.Controls.Add(this.btn_Asistencia);
            this.menuDesplegable.Controls.Add(this.btn_Materias);
            this.menuDesplegable.Location = new System.Drawing.Point(1, 0);
            this.menuDesplegable.Name = "menuDesplegable";
            this.menuDesplegable.Size = new System.Drawing.Size(154, 447);
            this.menuDesplegable.TabIndex = 0;
            // 
            // btn_GestionarRoles
            // 
            this.btn_GestionarRoles.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GestionarRoles.Location = new System.Drawing.Point(29, 246);
            this.btn_GestionarRoles.Name = "btn_GestionarRoles";
            this.btn_GestionarRoles.Size = new System.Drawing.Size(98, 36);
            this.btn_GestionarRoles.TabIndex = 4;
            this.btn_GestionarRoles.Text = "Roles";
            this.btn_GestionarRoles.UseVisualStyleBackColor = true;
            this.btn_GestionarRoles.Click += new System.EventHandler(this.btn_GestionarRoles_Click);
            // 
            // btn_Pagos
            // 
            this.btn_Pagos.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pagos.Location = new System.Drawing.Point(29, 191);
            this.btn_Pagos.Name = "btn_Pagos";
            this.btn_Pagos.Size = new System.Drawing.Size(98, 36);
            this.btn_Pagos.TabIndex = 3;
            this.btn_Pagos.Text = "Pagos";
            this.btn_Pagos.UseVisualStyleBackColor = true;
            this.btn_Pagos.Click += new System.EventHandler(this.btn_Pagos_Click);
            // 
            // btn_Examenes
            // 
            this.btn_Examenes.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Examenes.Location = new System.Drawing.Point(29, 139);
            this.btn_Examenes.Name = "btn_Examenes";
            this.btn_Examenes.Size = new System.Drawing.Size(98, 36);
            this.btn_Examenes.TabIndex = 2;
            this.btn_Examenes.Text = "Examenes";
            this.btn_Examenes.UseVisualStyleBackColor = true;
            // 
            // btn_Asistencia
            // 
            this.btn_Asistencia.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Asistencia.Location = new System.Drawing.Point(29, 87);
            this.btn_Asistencia.Name = "btn_Asistencia";
            this.btn_Asistencia.Size = new System.Drawing.Size(98, 36);
            this.btn_Asistencia.TabIndex = 1;
            this.btn_Asistencia.Text = "Asistencia";
            this.btn_Asistencia.UseVisualStyleBackColor = true;
            // 
            // btn_Materias
            // 
            this.btn_Materias.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Materias.Location = new System.Drawing.Point(29, 35);
            this.btn_Materias.Name = "btn_Materias";
            this.btn_Materias.Size = new System.Drawing.Size(98, 36);
            this.btn_Materias.TabIndex = 0;
            this.btn_Materias.Text = "Materias";
            this.btn_Materias.UseVisualStyleBackColor = true;
            this.btn_Materias.Click += new System.EventHandler(this.btn_Materias_Click);
            // 
            // lbl_bienvenido
            // 
            this.lbl_bienvenido.AutoSize = true;
            this.lbl_bienvenido.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_bienvenido.Location = new System.Drawing.Point(246, 44);
            this.lbl_bienvenido.Name = "lbl_bienvenido";
            this.lbl_bienvenido.Size = new System.Drawing.Size(83, 27);
            this.lbl_bienvenido.TabIndex = 1;
            this.lbl_bienvenido.Text = "Bienvenido";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(642, 448);
            this.Controls.Add(this.lbl_bienvenido);
            this.Controls.Add(this.menuDesplegable);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MainForm";
            this.menuDesplegable.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel menuDesplegable;
        private System.Windows.Forms.Button btn_Materias;
        private System.Windows.Forms.Label lbl_bienvenido;
        private System.Windows.Forms.Button btn_Pagos;
        private System.Windows.Forms.Button btn_Examenes;
        private System.Windows.Forms.Button btn_Asistencia;
        private System.Windows.Forms.Button btn_GestionarRoles;
    }
}