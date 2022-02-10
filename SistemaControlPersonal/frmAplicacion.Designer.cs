namespace SistemaControlPersonal
{
    partial class frmAplicacion
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAsistencia = new System.Windows.Forms.Button();
            this.btnAdmi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(311, 120);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(562, 36);
            this.label1.TabIndex = 10;
            this.label1.Text = "Sistema de administración de personal";
            // 
            // btnAsistencia
            // 
            this.btnAsistencia.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAsistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsistencia.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnAsistencia.Location = new System.Drawing.Point(373, 272);
            this.btnAsistencia.Name = "btnAsistencia";
            this.btnAsistencia.Size = new System.Drawing.Size(210, 75);
            this.btnAsistencia.TabIndex = 9;
            this.btnAsistencia.Text = "Modulo Asistencia";
            this.btnAsistencia.UseVisualStyleBackColor = false;
            this.btnAsistencia.Click += new System.EventHandler(this.btnAsistencia_Click);
            // 
            // btnAdmi
            // 
            this.btnAdmi.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAdmi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmi.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnAdmi.Location = new System.Drawing.Point(136, 272);
            this.btnAdmi.Name = "btnAdmi";
            this.btnAdmi.Size = new System.Drawing.Size(208, 75);
            this.btnAdmi.TabIndex = 8;
            this.btnAdmi.Text = "Modulo Administración";
            this.btnAdmi.UseVisualStyleBackColor = false;
            this.btnAdmi.Click += new System.EventHandler(this.btnAdmi_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 471);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAsistencia);
            this.Controls.Add(this.btnAdmi);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAsistencia;
        private System.Windows.Forms.Button btnAdmi;
    }
}

