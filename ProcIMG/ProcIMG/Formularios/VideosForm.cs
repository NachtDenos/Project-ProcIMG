using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;



namespace ProcIMG
{
    public partial class VideosForm : Form
    {
        public Bitmap resultVid;
        public Bitmap originalVid;
        public string sFilter = "";
        VideoCapture capture;
        bool pause = false;
        float valueScroll = 0.0f;
        public VideosForm()
        {
            InitializeComponent();
        }
        #region Functions
        private void cleanConfiguration()
        {
            lblColorChoiceVi.Visible = false;
            lblColorChoice2Vi.Visible = false;
            btnRedVi.Visible = false;
            btnRedVi2.Visible = false;
            btnGreenVi.Visible = false;
            btnGreenVi2.Visible = false;
            btnBlueVi.Visible = false;
            btnBlueVi2.Visible = false;
            btnMoreColorsVi.Visible = false;
            btnMoreColorsVi2.Visible = false;
            tbGradientVi.Visible = false;
            tbFilterOnlyVi.Visible = false;
            btnVerticalVi.Visible = false;
            btnHorizontalVi.Visible = false;
        }
        #endregion

        #region Buttons
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnBrightnessVi_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
            tbFilterOnlyVi.Visible = true;
            if (originalVid == null)
            {
                MessageBox.Show("Debe seleccionar un video antes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sFilter = "BrightnessFilter";
        }
        private void btnContrastVi_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
            tbFilterOnlyVi.Visible = true;
        }
        private void btnBorderVi_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
        }
        private void btnGradientVi_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
            lblColorChoiceVi.Visible = true;
            lblColorChoice2Vi.Visible = true;
            btnRedVi.Visible = true;
            btnRedVi2.Visible = true;
            btnGreenVi.Visible = true;
            btnGreenVi2.Visible = true;
            btnBlueVi.Visible = true;
            btnBlueVi2.Visible = true;
            btnMoreColorsVi.Visible = true;
            btnMoreColorsVi2.Visible = true;
            tbGradientVi.Visible = true;
        }
        private void btnNegativeVi_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
            if (originalVid == null)
            {
                MessageBox.Show("Debe seleccionar un video antes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sFilter = "NegativeFilter";
        }
        private void btnPixelVi_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
            tbFilterOnlyVi.Visible = true;
        }
        private void btnColorVi_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
            lblColorChoiceVi.Visible = true;
            btnRedVi.Visible = true;
            btnGreenVi.Visible = true;
            btnBlueVi.Visible = true;
            btnMoreColorsVi.Visible = true;
        }
        private void btnNoiseVi_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
            tbFilterOnlyVi.Visible = true;
        }
        private void btnGaussianVi_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
            tbFilterOnlyVi.Visible = true;
        }
        private void btnMirrorVi_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
            btnVerticalVi.Visible = true;
            btnHorizontalVi.Visible = true;
        }

        #endregion

        private void btnEraseVi_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
        }
        private void btnUploadVi_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                capture = new VideoCapture(ofd.FileName);
                Mat m = new Mat();
                capture.Read(m);
                resultVid = m.Bitmap;
                originalVid = m.Bitmap;
                pbEditVideo.Image = resultVid;
                pbOriginalVideo.Image = originalVid;
            }
        }

        private async void btnPlayVi_Click(object sender, EventArgs e)
        {
            if (pause)
            {
                pause = false;
                return;
            }

            if (capture == null)
            {
                return;
            }

            try
            {
                while (!pause)
                {
                    Mat m = new Mat();
                    capture.Read(m);

                    if (!m.IsEmpty)
                    {
                        Bitmap frame = m.Bitmap;

                        Bitmap filteredFrame = await Task.Run(() => ApplySelectedFilter(frame));

                        pbEditVideo.Image = filteredFrame;
                        pbOriginalVideo.Image = m.Bitmap;

                        double fps = capture.GetCaptureProperty(CapProp.Fps);
                        await Task.Delay((int)(1000 / fps)); 
                    }
                    else
                    {
                        capture.SetCaptureProperty(CapProp.PosFrames, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Bitmap ApplySelectedFilter(Bitmap frame)
        {

            switch (sFilter)
            {
                case "NegativeFilter":
                    return ApplyNegativeFilter(frame);
                case "HorizontalFilter":
                    return ApplyHorizontalFilter(frame);
                case "VerticalFilter":
                    return ApplyVerticalFilter(frame);
                case "BrightnessFilter":
                    return ApplyBrightnessFilter(frame);
                default:
                    return frame;
            }

        }

        private Bitmap ApplyNegativeFilter(Bitmap original)
        {
            Bitmap originalImage = (Bitmap)original;
            FiltersC filters = new FiltersC();
            Bitmap filteredImage = filters.NegativeFilter(originalImage);
            return filteredImage;
        }

        private Bitmap ApplyHorizontalFilter(Bitmap original)
        {
            Bitmap originalImage = (Bitmap)original;
            FiltersC filters = new FiltersC();
            Bitmap filteredImage = filters.HorizontalFilter(originalImage);
            return filteredImage;
        }
        private Bitmap ApplyVerticalFilter(Bitmap original)
        {
            Bitmap originalImage = (Bitmap)original;
            FiltersC filters = new FiltersC();
            Bitmap filteredImage = filters.VerticalFilter(originalImage);
            return filteredImage;
        }
        private Bitmap ApplyBrightnessFilter(Bitmap original)
        {
            Bitmap originalImage = (Bitmap)original;
            FiltersC filters = new FiltersC();
            Bitmap filteredImage = filters.BrightnessFilter(originalImage, valueScroll);
            return filteredImage;
        }
        private void btnPauseVi_Click(object sender, EventArgs e)
        {
            pause = !pause;
        }

        private void btnHorizontalVi_Click(object sender, EventArgs e)
        {
            if (originalVid == null)
            {
                MessageBox.Show("Debe seleccionar un video antes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sFilter = "HorizontalFilter";
        }

        private void btnVerticalVi_Click(object sender, EventArgs e)
        {
            if (originalVid == null)
            {
                MessageBox.Show("Debe seleccionar un video antes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sFilter = "VerticalFilter";
        }

        private void tbFilterOnlyVi_Scroll(object sender, EventArgs e)
        {
            valueScroll = tbFilterOnlyVi.Value;
        }
    }
}
