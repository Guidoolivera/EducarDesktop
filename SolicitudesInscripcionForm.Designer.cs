namespace EducarWeb
{
    partial class SolicitudesInscripcionForm
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
            this.btn_AceptarSolicitud = new System.Windows.Forms.Button();
            this.dgvSolicitudes = new System.Windows.Forms.DataGridView();
            this.btn_RechazarSolicitud = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_AceptarSolicitud
            // 
            this.btn_AceptarSolicitud.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btn_AceptarSolicitud.Location = new System.Drawing.Point(64, 225);
            this.btn_AceptarSolicitud.Name = "btn_AceptarSolicitud";
            this.btn_AceptarSolicitud.Size = new System.Drawing.Size(125, 31);
            this.btn_AceptarSolicitud.TabIndex = 3;
            this.btn_AceptarSolicitud.Text = "ACEPTAR";
            this.btn_AceptarSolicitud.UseVisualStyleBackColor = false;
            this.btn_AceptarSolicitud.Click += new System.EventHandler(this.btn_AceptarSolicitud_Click);
            // 
            // dgvSolicitudes
            // 
            this.dgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolicitudes.Location = new System.Drawing.Point(12, 12);
            this.dgvSolicitudes.Name = "dgvSolicitudes";
            this.dgvSolicitudes.Size = new System.Drawing.Size(393, 166);
            this.dgvSolicitudes.TabIndex = 4;
            // 
            // btn_RechazarSolicitud
            // 
            this.btn_RechazarSolicitud.BackColor = System.Drawing.Color.Firebrick;
            this.btn_RechazarSolicitud.Location = new System.Drawing.Point(217, 225);
            this.btn_RechazarSolicitud.Name = "btn_RechazarSolicitud";
            this.btn_RechazarSolicitud.Size = new System.Drawing.Size(125, 31);
            this.btn_RechazarSolicitud.TabIndex = 5;
            this.btn_RechazarSolicitud.Text = "RECHAZAR";
            this.btn_RechazarSolicitud.UseVisualStyleBackColor = false;
            this.btn_RechazarSolicitud.Click += new System.EventHandler(this.btn_RechazarSolicitud_Click);
            // 
            // SolicitudesInscripcionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(417, 268);
            this.Controls.Add(this.btn_RechazarSolicitud);
            this.Controls.Add(this.dgvSolicitudes);
            this.Controls.Add(this.btn_AceptarSolicitud);
            this.Name = "SolicitudesInscripcionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListarMateriasForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_AceptarSolicitud;
        private System.Windows.Forms.DataGridView dgvSolicitudes;
        private System.Windows.Forms.Button btn_RechazarSolicitud;
    }
}