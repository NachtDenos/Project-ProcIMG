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
        public Bitmap resultImg;
        public Bitmap originalImg;
        public string sFilter = "";
        public enum Channel
        {
            Red,
            Green,
            Blue
        }


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
        private Bitmap ApplyChannelFilter(Bitmap originalImg, Channel channel)
        {
            Bitmap resultImg = new Bitmap(originalImg.Width, originalImg.Height);

            for (int x = 0; x < originalImg.Width; x++)
            {
                for (int y = 0; y < originalImg.Height; y++)
                {
                    Color oColor = originalImg.GetPixel(x, y);
                    Color newColor;

                    switch (channel)
                    {
                        case Channel.Red:
                            newColor = Color.FromArgb(oColor.R, 0, 0);
                            break;
                        case Channel.Green:
                            newColor = Color.FromArgb(0, oColor.G, 0);
                            break;
                        case Channel.Blue:
                            newColor = Color.FromArgb(0, 0, oColor.B);
                            break;
                        default:
                            newColor = oColor;
                            break;
                    }

                    resultImg.SetPixel(x, y, newColor);
                }
            }
            return resultImg;
        }

        private void BrightnessFilter(float pBrightness)
        {
            int x = 0;
            int y = 0;
            resultImg = new Bitmap(originalImg.Width, originalImg.Height);
            Color rColor = new Color();
            Color oColor = new Color();
            int r = 0;
            int g = 0;
            int b = 0;
            for (x = 0; x < originalImg.Width; x++)
            {
                for (y = 0; y < originalImg.Height; y++)
                {
                    oColor = originalImg.GetPixel(x, y);
                    r = (int)(oColor.R * pBrightness);
                    g = (int)(oColor.G * pBrightness);
                    b = (int)(oColor.B * pBrightness);

                    if (r > 255)
                        r = 255;
                    else if (r < 0)
                        r = 0;

                    if (g > 255)
                        g = 255;
                    else if (g < 0)
                        g = 0;

                    if (b > 255)
                        b = 255;
                    else if (b < 0)
                        b = 0;
                    rColor = Color.FromArgb(r, g, b);
                    resultImg.SetPixel(x, y, rColor);
                }
                this.Invalidate();
                pbEditImage.Image = resultImg;
            }
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
            BrightnessFilter(1.0f);
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
            sFilter = "Gradiente";
        }

        private void btnNegativeImg_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
            if (originalImg == null)
            {
                MessageBox.Show("Debe seleccionar una imagen antes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int x = 0;
            int y = 0;
            resultImg = new Bitmap(originalImg.Width, originalImg.Height);
            Color rColor = new Color();
            Color oColor = new Color();
            for (x = 0; x < originalImg.Width; x++)
            {
                for (y = 0; y < originalImg.Height; y++)
                {
                    oColor = originalImg.GetPixel(x, y);

                    rColor = Color.FromArgb(255 - oColor.R,
                                            255 - oColor.G,
                                            255 - oColor.B);

                    resultImg.SetPixel(x, y, rColor);
                }
            }
            this.Invalidate();
            pbEditImage.Image = resultImg;
        }

        private void btnPixelImg_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
            tbFilterOnlyImg.Visible = true;
        }

        private void btnColorImg_Click(object sender, EventArgs e)
        {
            if (originalImg == null)
            {
                MessageBox.Show("Debe seleccionar una imagen antes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cleanConfiguration();
            lblColorChoiceImg.Visible = true;
            btnRedImg.Visible = true;
            btnGreenImg.Visible = true;
            btnBlueImg.Visible = true;
            btnMoreColorsImg.Visible = true;
            sFilter = "Color";
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

        private void btnEraseImg_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
        }

        private void btnUploadImg_Click(object sender, EventArgs e)
        {
            Bitmap bitmapImage = null;
            OpenFileDialog fileImage = new OpenFileDialog();
            fileImage.Filter = "archivos de imagenes (*.png; *.jpg; *.jpeg)| *.png;*jpg;*jpeg";
            if (fileImage.ShowDialog() == DialogResult.OK)
            {
                pbEditImage.Image = Image.FromFile(fileImage.FileName);
                pbOriginalImage.Image = Image.FromFile(fileImage.FileName);
                bitmapImage = new Bitmap(fileImage.FileName);
                originalImg = bitmapImage;
            }
        }

        private void btnRedImg_Click(object sender, EventArgs e)
        {
            if (sFilter == "Color")
            {
                pbEditImage.Image = ApplyChannelFilter(originalImg, Channel.Red);
                this.Invalidate();
            }
            else
            {

            }
        }

        private void btnGreenImg_Click(object sender, EventArgs e)
        {
            if (sFilter == "Color")
            {
                pbEditImage.Image = ApplyChannelFilter(originalImg, Channel.Green);
                this.Invalidate();
            }
            else
            {

            }
        }

        private void btnBlueImg_Click(object sender, EventArgs e)
        {
            if (sFilter == "Color")
            {
                pbEditImage.Image = ApplyChannelFilter(originalImg, Channel.Blue);
                this.Invalidate();
            }
            else
            {

            }
        }



        #endregion

        private void tbFilterOnlyImg_Scroll(object sender, EventArgs e)
        {
            float pBrillo = tbFilterOnlyImg.Value;
            BrightnessFilter(pBrillo / 5);
        }
    }
}
