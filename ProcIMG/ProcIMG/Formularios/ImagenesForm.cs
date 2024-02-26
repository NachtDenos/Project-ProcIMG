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
    public partial class ImagenesForm : Form
    {
        public ImagenesForm()
        {
            InitializeComponent();
        }
        #region Functions
        private void cleanConfiguration()
        {
            lblColorChoiceImg.Visible = false;
            lblColorChoiceImg2.Visible = false;
            btnRedImg.Visible = false;
            btnRedImg2.Visible = false;
            btnGreenImg.Visible = false;
            btnGreenImg2.Visible = false;
            btnBlueImg.Visible = false;
            btnBlueImg2.Visible = false;
            btnMoreColorsImg.Visible = false;
            btnMoreColorsImg2.Visible = false;
            tbGradientImg.Visible = false;
            tbFilterOnlyImg.Visible = false;
            btnVerticalImg.Visible = false;
            btnHorizontalImg.Visible = false;
        }
        #endregion

        #region Buttons
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnBrightnessImg_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
            tbFilterOnlyImg.Visible = true;
        }
        private void btnConstrastImg_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
            tbFilterOnlyImg.Visible = true;
        }
        private void btnBoderImg_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
        }

        private void btnGradientImg_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
            lblColorChoiceImg.Visible = true;
            lblColorChoiceImg2.Visible = true;
            btnRedImg.Visible = true;
            btnRedImg2.Visible = true;
            btnGreenImg.Visible = true;
            btnGreenImg2.Visible = true;
            btnBlueImg.Visible = true;
            btnBlueImg2.Visible = true;
            btnMoreColorsImg.Visible = true;
            btnMoreColorsImg2.Visible = true;
        }

        private void btnNegativeImg_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
        }

        private void btnPixelImg_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
            tbFilterOnlyImg.Visible = true;
        }

        private void btnColorImg_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
            lblColorChoiceImg.Visible = true;
            btnRedImg.Visible = true;
            btnGreenImg.Visible = true;
            btnBlueImg.Visible = true;
            btnMoreColorsImg.Visible = true;
        }

        private void btnNoiseImg_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
            tbFilterOnlyImg.Visible = true;
        }

        private void btnGaussianImg_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
            tbFilterOnlyImg.Visible = true;
        }

        private void btnMirrorImg_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
            btnVerticalImg.Visible = true;
            btnHorizontalImg.Visible = true;
        }

        #endregion

        private void btnEraseImg_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
        }
    }
}
