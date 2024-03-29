
namespace ProcIMG
{
    partial class ManualForm
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
            this.SuspendLayout();
            // 
            // btnExitFormCamara
            // 
            this.btnExitFormCamara.FlatAppearance.BorderSize = 0;
            this.btnExitFormCamara.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitFormCamara.ForeColor = System.Drawing.Color.White;
            this.btnExitFormCamara.Location = new System.Drawing.Point(14, 14);
            this.btnExitFormCamara.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnExitFormCamara.Name = "btnExitFormCamara";
            this.btnExitFormCamara.Size = new System.Drawing.Size(38, 38);
            this.btnExitFormCamara.TabIndex = 1;
            this.btnExitFormCamara.Text = "X";
            this.btnExitFormCamara.UseVisualStyleBackColor = true;
            this.btnExitFormCamara.Click += new System.EventHandler(this.btnExitFormCamara_Click);
            // 
            // ManualForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(1174, 793);
            this.Controls.Add(this.btnExitFormCamara);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ManualForm";
            this.Text = "ManualForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExitFormCamara;
    }
}