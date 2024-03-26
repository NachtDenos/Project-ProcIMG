
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CamaraForm));
            this.btnExitFormCamara = new System.Windows.Forms.Button();
            this.lblImagen = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumPerson = new System.Windows.Forms.Label();
            this.cbCamera = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOnOffCamera = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pbCamera = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExitFormCamara
            // 
            this.btnExitFormCamara.FlatAppearance.BorderSize = 0;
            this.btnExitFormCamara.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitFormCamara.ForeColor = System.Drawing.Color.White;
            this.btnExitFormCamara.Location = new System.Drawing.Point(13, 13);
            this.btnExitFormCamara.Margin = new System.Windows.Forms.Padding(4);
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
            this.lblImagen.Location = new System.Drawing.Point(514, 13);
            this.lblImagen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImagen.Name = "lblImagen";
            this.lblImagen.Size = new System.Drawing.Size(165, 48);
            this.lblImagen.TabIndex = 2;
            this.lblImagen.Text = "Cámara";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(86, 603);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(302, 33);
            this.label3.TabIndex = 47;
            this.label3.Text = "Encendido de Cámara";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(983, 121);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 28);
            this.label2.TabIndex = 49;
            this.label2.Text = "Personas:";
            // 
            // lblNumPerson
            // 
            this.lblNumPerson.AutoSize = true;
            this.lblNumPerson.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumPerson.ForeColor = System.Drawing.Color.White;
            this.lblNumPerson.Location = new System.Drawing.Point(1079, 121);
            this.lblNumPerson.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumPerson.Name = "lblNumPerson";
            this.lblNumPerson.Size = new System.Drawing.Size(25, 28);
            this.lblNumPerson.TabIndex = 50;
            this.lblNumPerson.Text = "0";
            // 
            // cbCamera
            // 
            this.cbCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(53)))));
            this.cbCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCamera.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCamera.ForeColor = System.Drawing.SystemColors.Window;
            this.cbCamera.Location = new System.Drawing.Point(424, 665);
            this.cbCamera.Name = "cbCamera";
            this.cbCamera.Size = new System.Drawing.Size(244, 36);
            this.cbCamera.TabIndex = 53;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProcIMG.Properties.Resources.usuario;
            this.pictureBox1.Location = new System.Drawing.Point(951, 121);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 52;
            this.pictureBox1.TabStop = false;
            // 
            // btnOnOffCamera
            // 
            this.btnOnOffCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(53)))));
            this.btnOnOffCamera.FlatAppearance.BorderSize = 0;
            this.btnOnOffCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnOffCamera.ForeColor = System.Drawing.Color.White;
            this.btnOnOffCamera.Image = global::ProcIMG.Properties.Resources.boton_de_encendido_apagado;
            this.btnOnOffCamera.Location = new System.Drawing.Point(674, 661);
            this.btnOnOffCamera.Name = "btnOnOffCamera";
            this.btnOnOffCamera.Size = new System.Drawing.Size(40, 40);
            this.btnOnOffCamera.TabIndex = 51;
            this.btnOnOffCamera.UseVisualStyleBackColor = false;
            this.btnOnOffCamera.Click += new System.EventHandler(this.btnOnOffCamera_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::ProcIMG.Properties.Resources.linea;
            this.pictureBox7.Location = new System.Drawing.Point(28, 615);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(51, 10);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 48;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::ProcIMG.Properties.Resources.linea;
            this.pictureBox6.Location = new System.Drawing.Point(335, 615);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(777, 10);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 46;
            this.pictureBox6.TabStop = false;
            // 
            // pbCamera
            // 
            this.pbCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCamera.Location = new System.Drawing.Point(237, 94);
            this.pbCamera.Name = "pbCamera";
            this.pbCamera.Size = new System.Drawing.Size(685, 473);
            this.pbCamera.TabIndex = 28;
            this.pbCamera.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(979, 397);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 54;
            // 
            // CamaraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(1174, 793);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.cbCamera);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnOnOffCamera);
            this.Controls.Add(this.lblNumPerson);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pbCamera);
            this.Controls.Add(this.lblImagen);
            this.Controls.Add(this.btnExitFormCamara);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CamaraForm";
            this.Text = "CamaraForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CamaraForm_FormClosed);
            this.Load += new System.EventHandler(this.CamaraForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCamera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExitFormCamara;
        private System.Windows.Forms.Label lblImagen;
        private System.Windows.Forms.PictureBox pbCamera;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumPerson;
        private System.Windows.Forms.Button btnOnOffCamera;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbCamera;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}