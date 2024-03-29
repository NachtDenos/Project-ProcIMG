using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcIMG
{
    public partial class PhotoCraft : Form
    {

        private Form activeForm = null;

        public PhotoCraft()
        {
            InitializeComponent();
        }

        #region Buttons
        private void btnPhotos_Click(object sender, EventArgs e)
        {
            openChildForm(new ImagenesForm());
        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            openChildForm(new VideosForm());
        }

        private void btnCamara_Click(object sender, EventArgs e)
        {
            openChildForm(new CamaraForm());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            openChildForm(new ManualForm());
        }
        #endregion

        #region Functions
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        #endregion

    }
}
