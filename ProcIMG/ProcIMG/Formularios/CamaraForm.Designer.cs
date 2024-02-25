
namespace ProcIMG
{
    partial class CamaraForm
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
            this.btnExitFormCamara = new System.Windows.Forms.Button();
            this.lblImagen = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExitFormCamara
            // 
            this.btnExitFormCamara.Location = new System.Drawing.Point(13, 13);
            this.btnExitFormCamara.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExitFormCamara.Name = "btnExitFormCamara";
            this.btnExitFormCamara.Size = new System.Drawing.Size(30, 30);
            this.btnExitFormCamara.TabIndex = 0;
            this.btnExitFormCamara.Text = "X";
            this.btnExitFormCamara.UseVisualStyleBackColor = true;
            this.btnExitFormCamara.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblImagen
            // 
            this.lblImagen.AutoSize = true;
            this.lblImagen.Font = new System.Drawing.Font("Arial Black", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImagen.ForeColor = System.Drawing.Color.White;
            this.lblImagen.Location = new System.Drawing.Point(427, 13);
            this.lblImagen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImagen.Name = "lblImagen";
            this.lblImagen.Size = new System.Drawing.Size(131, 38);
            this.lblImagen.TabIndex = 2;
            this.lblImagen.Text = "Cámara";
            this.lblImagen.Click += new System.EventHandler(this.lblImagen_Click);
            // 
            // CamaraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(960, 680);
            this.Controls.Add(this.lblImagen);
            this.Controls.Add(this.btnExitFormCamara);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CamaraForm";
            this.Text = "CamaraForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExitFormCamara;
        private System.Windows.Forms.Label lblImagen;
    }
}