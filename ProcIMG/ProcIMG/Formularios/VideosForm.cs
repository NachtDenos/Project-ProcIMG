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

        VideoCapture capture;
        bool pause = false;
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
            int x = 0;
            int y = 0;
            resultVid = new Bitmap(originalVid.Width, originalVid.Height);
            Color rColor = new Color();
            Color oColor = new Color();
            for (x = 0; x < originalVid.Width; x++)
            {
                for (y = 0; y < originalVid.Height; y++)
                {
                    oColor = originalVid.GetPixel(x, y);

                    rColor = Color.FromArgb(255 - oColor.R,
                                            255 - oColor.G,
                                            255 - oColor.B);

                    resultVid.SetPixel(x, y, rColor);
                }
            }
            this.Invalidate();
            pbEditVideo.Image = resultVid;
            //UpdateHistogram2();
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
            if (pause == true)
                pause = false;
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
                        pbEditVideo.Image = m.Bitmap;
                        double fps = capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps);
                        await Task.Delay(1000 / Convert.ToInt32(fps));
                    }
                    else
                    {
                        capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPauseVi_Click(object sender, EventArgs e)
        {
            pause = !pause;
        }

    }
}
