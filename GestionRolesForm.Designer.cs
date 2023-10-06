namespace EducarWeb
{
    partial class GestionRolesForm
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
            this.btn_AsignarRol = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_AsignarRol
            // 
            this.btn_AsignarRol.Location = new System.Drawing.Point(49, 321);
            this.btn_AsignarRol.Name = "btn_AsignarRol";
            this.btn_AsignarRol.Size = new System.Drawing.Size(75, 23);
            this.btn_AsignarRol.TabIndex = 1;
            this.btn_AsignarRol.Text = "Asignar rol";
            this.btn_AsignarRol.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(49, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(637, 199);
            this.dataGridView1.TabIndex = 2;
            // 
            // GestionRolesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_AsignarRol);
            this.Name = "GestionRolesForm";
            this.Text = "GestionRolesForm";
            this.Load += new System.EventHandler(this.GestionRolesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            

        }

        #endregion
        private System.Windows.Forms.Button btn_AsignarRol;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}