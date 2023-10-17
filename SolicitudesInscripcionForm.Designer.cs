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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolicitudesInscripcionForm));
            this.btn_AceptarSolicitud = new System.Windows.Forms.Button();
            this.dgvSolicitudes = new System.Windows.Forms.DataGridView();
            this.btn_RechazarSolicitud = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_AceptarSolicitud
            // 
            this.btn_AceptarSolicitud.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_AceptarSolicitud.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btn_AceptarSolicitud.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btn_AceptarSolicitud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AceptarSolicitud.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AceptarSolicitud.Location = new System.Drawing.Point(86, 220);
            this.btn_AceptarSolicitud.Name = "btn_AceptarSolicitud";
            this.btn_AceptarSolicitud.Size = new System.Drawing.Size(98, 36);
            this.btn_AceptarSolicitud.TabIndex = 3;
            this.btn_AceptarSolicitud.Text = "Aceptar";
            this.btn_AceptarSolicitud.UseVisualStyleBackColor = false;
            this.btn_AceptarSolicitud.Click += new System.EventHandler(this.btn_AceptarSolicitud_Click);
            // 
            // dgvSolicitudes
            // 
            this.dgvSolicitudes.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvSolicitudes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSolicitudes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSolicitudes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSolicitudes.Location = new System.Drawing.Point(12, 21);
            this.dgvSolicitudes.Name = "dgvSolicitudes";
            this.dgvSolicitudes.Size = new System.Drawing.Size(393, 166);
            this.dgvSolicitudes.TabIndex = 4;
            // 
            // btn_RechazarSolicitud
            // 
            this.btn_RechazarSolicitud.BackColor = System.Drawing.Color.SkyBlue;
            this.btn_RechazarSolicitud.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.btn_RechazarSolicitud.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btn_RechazarSolicitud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RechazarSolicitud.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RechazarSolicitud.Location = new System.Drawing.Point(234, 220);
            this.btn_RechazarSolicitud.Name = "btn_RechazarSolicitud";
            this.btn_RechazarSolicitud.Size = new System.Drawing.Size(98, 36);
            this.btn_RechazarSolicitud.TabIndex = 5;
            this.btn_RechazarSolicitud.Text = "Rechazar";
            this.btn_RechazarSolicitud.UseVisualStyleBackColor = false;
            this.btn_RechazarSolicitud.Click += new System.EventHandler(this.btn_RechazarSolicitud_Click);
            // 
            // SolicitudesInscripcionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(417, 268);
            this.Controls.Add(this.btn_RechazarSolicitud);
            this.Controls.Add(this.dgvSolicitudes);
            this.Controls.Add(this.btn_AceptarSolicitud);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SolicitudesInscripcionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitudes de Inscripción";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_AceptarSolicitud;
        private System.Windows.Forms.DataGridView dgvSolicitudes;
        private System.Windows.Forms.Button btn_RechazarSolicitud;
    }
}