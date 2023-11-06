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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuDesplegable = new System.Windows.Forms.Panel();
            this.btn_Sobre = new System.Windows.Forms.Button();
            this.btn_GestionarRoles = new System.Windows.Forms.Button();
            this.btn_Pagos = new System.Windows.Forms.Button();
            this.btn_Examenes = new System.Windows.Forms.Button();
            this.btn_Materias = new System.Windows.Forms.Button();
            this.lbl_bienvenido = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuDesplegable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuDesplegable
            // 
            this.menuDesplegable.BackColor = System.Drawing.Color.SteelBlue;
            this.menuDesplegable.Controls.Add(this.btn_Sobre);
            this.menuDesplegable.Controls.Add(this.btn_GestionarRoles);
            this.menuDesplegable.Controls.Add(this.btn_Pagos);
            this.menuDesplegable.Controls.Add(this.btn_Examenes);
            this.menuDesplegable.Controls.Add(this.btn_Materias);
            this.menuDesplegable.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuDesplegable.Location = new System.Drawing.Point(0, 0);
            this.menuDesplegable.Name = "menuDesplegable";
            this.menuDesplegable.Size = new System.Drawing.Size(154, 448);
            this.menuDesplegable.TabIndex = 0;
            this.menuDesplegable.Visible = false;
            // 
            // btn_Sobre
            // 
            this.btn_Sobre.BackColor = System.Drawing.Color.White;
            this.btn_Sobre.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btn_Sobre.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btn_Sobre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Sobre.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sobre.Location = new System.Drawing.Point(24, 343);
            this.btn_Sobre.Name = "btn_Sobre";
            this.btn_Sobre.Size = new System.Drawing.Size(98, 36);
            this.btn_Sobre.TabIndex = 5;
            this.btn_Sobre.Text = "Sobre";
            this.btn_Sobre.UseVisualStyleBackColor = false;
            this.btn_Sobre.Visible = false;
            this.btn_Sobre.Click += new System.EventHandler(this.btn_Sobre_Click);
            // 
            // btn_GestionarRoles
            // 
            this.btn_GestionarRoles.BackColor = System.Drawing.Color.White;
            this.btn_GestionarRoles.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btn_GestionarRoles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btn_GestionarRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GestionarRoles.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GestionarRoles.Location = new System.Drawing.Point(24, 274);
            this.btn_GestionarRoles.Name = "btn_GestionarRoles";
            this.btn_GestionarRoles.Size = new System.Drawing.Size(98, 36);
            this.btn_GestionarRoles.TabIndex = 4;
            this.btn_GestionarRoles.Text = "Roles";
            this.btn_GestionarRoles.UseVisualStyleBackColor = false;
            this.btn_GestionarRoles.Visible = false;
            this.btn_GestionarRoles.Click += new System.EventHandler(this.btn_GestionarRoles_Click);
            // 
            // btn_Pagos
            // 
            this.btn_Pagos.BackColor = System.Drawing.Color.White;
            this.btn_Pagos.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btn_Pagos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btn_Pagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Pagos.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pagos.Location = new System.Drawing.Point(24, 205);
            this.btn_Pagos.Name = "btn_Pagos";
            this.btn_Pagos.Size = new System.Drawing.Size(98, 36);
            this.btn_Pagos.TabIndex = 3;
            this.btn_Pagos.Text = "Pagos";
            this.btn_Pagos.UseVisualStyleBackColor = false;
            this.btn_Pagos.Visible = false;
            this.btn_Pagos.Click += new System.EventHandler(this.btn_Pagos_Click);
            // 
            // btn_Examenes
            // 
            this.btn_Examenes.BackColor = System.Drawing.Color.White;
            this.btn_Examenes.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btn_Examenes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btn_Examenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Examenes.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Examenes.Location = new System.Drawing.Point(24, 136);
            this.btn_Examenes.Name = "btn_Examenes";
            this.btn_Examenes.Size = new System.Drawing.Size(98, 36);
            this.btn_Examenes.TabIndex = 2;
            this.btn_Examenes.Text = "Examenes";
            this.btn_Examenes.UseVisualStyleBackColor = false;
            this.btn_Examenes.Visible = false;
            this.btn_Examenes.Click += new System.EventHandler(this.btn_Examenes_Click);
            // 
            // btn_Materias
            // 
            this.btn_Materias.BackColor = System.Drawing.Color.White;
            this.btn_Materias.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btn_Materias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btn_Materias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Materias.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Materias.Location = new System.Drawing.Point(24, 67);
            this.btn_Materias.Name = "btn_Materias";
            this.btn_Materias.Size = new System.Drawing.Size(98, 36);
            this.btn_Materias.TabIndex = 0;
            this.btn_Materias.Text = "Gestión";
            this.btn_Materias.UseVisualStyleBackColor = false;
            this.btn_Materias.Visible = false;
            this.btn_Materias.Click += new System.EventHandler(this.btn_Materias_Click);
            // 
            // lbl_bienvenido
            // 
            this.lbl_bienvenido.AutoSize = true;
            this.lbl_bienvenido.Font = new System.Drawing.Font("Dubai", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_bienvenido.Location = new System.Drawing.Point(234, 22);
            this.lbl_bienvenido.Name = "lbl_bienvenido";
            this.lbl_bienvenido.Size = new System.Drawing.Size(178, 54);
            this.lbl_bienvenido.TabIndex = 1;
            this.lbl_bienvenido.Text = "¡Bienvenido!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(238, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Haga click en el logo para desplegar las opciones:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(243, 139);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(294, 245);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(642, 448);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_bienvenido);
            this.Controls.Add(this.menuDesplegable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Educar para transformar - Gestion";
            this.menuDesplegable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel menuDesplegable;
        private System.Windows.Forms.Button btn_Materias;
        private System.Windows.Forms.Label lbl_bienvenido;
        private System.Windows.Forms.Button btn_Pagos;
        private System.Windows.Forms.Button btn_Examenes;
        private System.Windows.Forms.Button btn_GestionarRoles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Sobre;
    }
}