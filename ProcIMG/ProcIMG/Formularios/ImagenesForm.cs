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
        private int[,] conv3x3 = new int[3, 3];
        private int[] histogramR = new int[256];
        private int[] histogramG = new int[256];
        private int[] histogramB = new int[256];

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

        public void UpdateHistogram()
        {

            int x = 0;
            int y = 0;
            Color rColor = new Color();
            //resultImg = originalImg;

            for (x = 0; x < originalImg.Width; x++)
            {
                for (y = 0; y < originalImg.Height; y++)
                {
                    rColor = originalImg.GetPixel(x, y);
                    histogramR[rColor.R]++;
                    histogramG[rColor.G]++;
                    histogramB[rColor.B]++;
                }
            }

            HistogramRGB h = new HistogramRGB(histogramR, histogramG, histogramB);

            h.TopLevel = false;
            h.Location = new Point(30, 190);
            flowHistogram.Controls.Add(h);
            h.BringToFront();
            h.Show();
        }

        public void UpdateHistogram2()
        {

            int x = 0;
            int y = 0;
            Color rColor = new Color();
            //resultImg = originalImg;
            
            for (x = 0; x < originalImg.Width; x++)
            {
                for (y = 0; y < originalImg.Height; y++)
                {
                    rColor = resultImg.GetPixel(x, y);
                    histogramR[rColor.R]++;
                    histogramG[rColor.G]++;
                    histogramB[rColor.B]++;
                }
            }

            HistogramRGB h = new HistogramRGB(histogramR, histogramG, histogramB);

            h.TopLevel = false;
            h.Location = new Point(30, 190);
            flowHistogram2.Controls.Add(h);
            h.BringToFront();
            h.Show();
        }


        private Bitmap ApplyChannelFilter(Bitmap originalImg, Channel channel)
        {
            Bitmap resultImgLocal = new Bitmap(originalImg.Width, originalImg.Height);

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

                    resultImgLocal.SetPixel(x, y, newColor);
                }
            }
            resultImg = resultImgLocal;
            return resultImgLocal;
        }

        private void BrightnessFilter(float pBrightness)
        {
            Bitmap originalImage = (Bitmap)originalImg;
            FiltersC filters = new FiltersC();
            Bitmap filteredImage = filters.BrightnessFilter(originalImage, pBrightness);
            this.Invalidate();
            pbEditImage.Image = filteredImage;
            resultImg = filteredImage;
            UpdateHistogram2();
        }
        private void NoiseFilter(float noisePercent)
        {
            int x = 0;
            int y = 0;
            int rangeMin = 85;
            int rangeMax = 300;
            float pBrightness = 0;

            Random rnd = new Random();
            Color rColor;
            Color oColor;

            int r = 0;
            int g = 0;
            int b = 0;

            resultImg = new Bitmap(originalImg.Width, originalImg.Height);
            for (x = 0; x < originalImg.Width; x++)
            {
                for (y = 0; y < originalImg.Height; y++)
                {
                    if (rnd.Next(1, 100) <= noisePercent)
                    {
                        pBrightness = rnd.Next(rangeMin, rangeMax) / 100.0f;
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

                        rColor = Color.FromArgb(r,g,b);
                    }
                    else
                    {
                        rColor = originalImg.GetPixel(x, y);
                    }
                    resultImg.SetPixel(x, y, rColor);
                }
                
            }
            this.Invalidate();
            pbEditImage.Image = resultImg;
            UpdateHistogram2();
        }

        private void PixelFilter(int pixelPercent)
        {
            if (pixelPercent == 0)
                return;
            int x = 0;
            int y = 0;
            int xp = 0;
            int yp = 0;
            Color rColor;
            Color oColor;
            int rs = 0;
            int gs = 0;
            int bs = 0;
            int r = 0;
            int g = 0;
            int b = 0;
            resultImg = new Bitmap(originalImg.Width, originalImg.Height);
            for (x = 0; x < originalImg.Width - pixelPercent; x += pixelPercent)
            {
                for (y = 0; y < originalImg.Height - pixelPercent; y += pixelPercent)
                {
                    rs = 0;
                    gs = 0;
                    bs = 0;
                    for (xp = x; xp < (x + pixelPercent); xp++)
                    {
                        for (yp = y; yp < (y + pixelPercent); yp++)
                        {
                            oColor = originalImg.GetPixel(xp,yp);
                            rs += oColor.R;
                            gs += oColor.G;
                            bs += oColor.B;
                        }
                    }
                    r = rs / (pixelPercent * pixelPercent);
                    g = gs / (pixelPercent * pixelPercent);
                    b = bs / (pixelPercent * pixelPercent);
                    rColor = Color.FromArgb(r, g, b);
                    for (xp = x; xp < (x + pixelPercent); xp++)
                    {
                        for (yp = y; yp < (y + pixelPercent); yp++)
                        {
                            resultImg.SetPixel(xp, yp, rColor);
                        }
                    }
                }

            }
            this.Invalidate();
            pbEditImage.Image = resultImg;
            UpdateHistogram2();
        }

        private void ConstrastFilter(int contrast)
        {
            //int contrast = 30;
            float c = (100.0f + contrast / 100.0f);
            c *= c;
            int x = 0;
            int y = 0;
            resultImg = new Bitmap(originalImg.Width, originalImg.Height);
            Color rColor = new Color();
            Color oColor = new Color();
            float r = 0;
            float g = 0;
            float b = 0;
            for (x = 0; x < originalImg.Width; x++)
            {
                for (y = 0; y < originalImg.Height; y++)
                {
                    oColor = originalImg.GetPixel(x, y);

                    r = ((((oColor.R / 255.0f) - 0.5f) * c) + 0.5f) * 255;
                    if (r > 255)
                        r = 255;
                    else if (r < 0)
                        r = 0;

                    g = ((((oColor.G / 255.0f) - 0.5f) * c) + 0.5f) * 255;
                    if (g > 255)
                        g = 255;
                    else if (g < 0)
                        g = 0;

                    b = ((((oColor.B / 255.0f) - 0.5f) * c) + 0.5f) * 255;
                    if (b > 255)
                        b = 255;
                    else if (b < 0)
                        b = 0;

                    rColor = Color.FromArgb((int)r, (int)g, (int)b);
                    resultImg.SetPixel(x, y, rColor);
                }

            }
            this.Invalidate();
            pbEditImage.Image = resultImg;
            UpdateHistogram2();
        }

        private void ConvGris(int[,] pMatriz, Bitmap pImagen, int pInferior, int pSuperior)
        {
            int x = 0;
            int y = 0;
            int a = 0;
            int b = 0;
            Color oColor;
            int suma = 0;
            for (x = 1; x < pImagen.Width - 1; x++)
            {
                for (y = 1; y < pImagen.Height - 1; y++)
                {
                    suma = 0;
                    for (a = -1; a < 2; a++)
                    {
                        for (b = -1; b < 2; b++)
                        {
                            oColor = pImagen.GetPixel(x + a, y + b);
                            suma = suma + (oColor.R * pMatriz[a + 1, b + 1]);
                        }
                    }
                    if (suma < pInferior)
                        suma = 0;
                    else if (suma > pSuperior)
                        suma = 255;

                    resultImg.SetPixel(x, y, Color.FromArgb(suma, suma, suma));
                }
            }
        }

        private void BorderFilter()
        {
            conv3x3 = new int[,]
            {
                {-1,0,-1},
                {0, 4, 0},
                {-1,0,-1}
            };
            shadesOfGray();
            Bitmap intermedio = (Bitmap)resultImg.Clone();
            ConvGris(conv3x3, intermedio, 32, 64);
            this.Invalidate();
            pbEditImage.Image = resultImg;
            UpdateHistogram2();
        }

        private void shadesOfGray()
        {
            int x = 0;
            int y = 0;
            resultImg = new Bitmap(originalImg.Width, originalImg.Height);
            Color rColor = new Color();
            Color oColor = new Color();
            float g = 0;
            for (x = 0; x < originalImg.Width; x++)
            {
                for (y = 0; y < originalImg.Height; y++)
                {
                    oColor = originalImg.GetPixel(x, y);
                    g = oColor.R * 0.299f + oColor.G * 0.587f + oColor.B * 0.114f;
                    rColor = Color.FromArgb((int)g, (int)g, (int)g);
                    resultImg.SetPixel(x, y, rColor);
                }
            }
            this.Invalidate();
        }

        public void GaussianBlurFilter(int radius)
        {
            resultImg = new Bitmap(originalImg.Width, originalImg.Height);

            double deviation = radius / 3.0;

            double[] kernelX = CreateGaussianKernel(radius, deviation);
            double[] kernelY = CreateGaussianKernel(radius, deviation);

            ApplyConvolution(originalImg, resultImg, kernelX, radius, true);

            ApplyConvolution(originalImg, resultImg, kernelY, radius, false);

            this.Invalidate();
            pbEditImage.Image = resultImg;
        }

        private static void ApplyConvolution(Bitmap source, Bitmap destination, double[] kernel, int radius, bool horizontal)
        {
            int size = 2 * radius + 1;
            int offset = radius;

            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    double r = 0, g = 0, b = 0;

                    for (int i = 0; i < size; i++)
                    {
                        int index = horizontal ? x - offset + i : y - offset + i;
                        index = Math.Max(0, Math.Min(horizontal ? source.Width - 1 : source.Height - 1, index));

                        Color pixelColor = horizontal ? source.GetPixel(index, y) : source.GetPixel(x, index);
                        double weight = kernel[i];

                        r += pixelColor.R * weight;
                        g += pixelColor.G * weight;
                        b += pixelColor.B * weight;
                    }

                    destination.SetPixel(x, y, Color.FromArgb((int)r, (int)g, (int)b));
                }
            }
        }

        private static double[] CreateGaussianKernel(int radius, double deviation)
        {
            int size = 2 * radius + 1;
            double[] kernel = new double[size];
            double sum = 0;

            for (int i = -radius; i <= radius; i++)
            {
                double weight = Math.Exp(-(i * i) / (2 * deviation * deviation));
                kernel[i + radius] = weight;
                sum += weight;
            }

            for (int i = 0; i < size; i++)
            {
                kernel[i] /= sum;
            }

            return kernel;
        }

        #endregion

        #region Buttons
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnBrightnessImg_Click(object sender, EventArgs e)
        {
            sFilter = "BrightnessFilter";
            cleanConfiguration();
            if (originalImg == null)
            {
                MessageBox.Show("Debe seleccionar una imagen antes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            tbFilterOnlyImg.Visible = true;
            BrightnessFilter(1.0f);
        }
        private void btnConstrastImg_Click(object sender, EventArgs e)
        {
            sFilter = "ContrastFilter";
            cleanConfiguration();
            if (originalImg == null)
            {
                MessageBox.Show("Debe seleccionar una imagen antes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            tbFilterOnlyImg.Visible = true;
            ConstrastFilter(10);
        }
        private void btnBoderImg_Click(object sender, EventArgs e)
        {
            if (originalImg == null)
            {
                MessageBox.Show("Debe seleccionar una imagen antes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            BorderFilter();
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
            Bitmap originalImage = (Bitmap)originalImg;
            FiltersC filters = new FiltersC();
            Bitmap filteredImage = filters.NegativeFilter(originalImage);
            this.Invalidate();
            pbEditImage.Image = filteredImage;
            resultImg = filteredImage;
            UpdateHistogram2();
        }

        private void btnPixelImg_Click(object sender, EventArgs e)
        {
            sFilter = "PixelFilter";
            cleanConfiguration();
            if (originalImg == null)
            {
                MessageBox.Show("Debe seleccionar una imagen antes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            tbFilterOnlyImg.Visible = true;
            PixelFilter(10);
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
            sFilter = "NoiseFilter";
            cleanConfiguration();
            if (originalImg == null)
            {
                MessageBox.Show("Debe seleccionar una imagen antes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            NoiseFilter(10);
            tbFilterOnlyImg.Visible = true;
        }

        private void btnGaussianImg_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
            if (originalImg == null)
            {
                MessageBox.Show("Debe seleccionar una imagen antes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sFilter = "GaussianFilter";
            GaussianBlurFilter(15);
        }

        private void btnMirrorImg_Click(object sender, EventArgs e)
        {
            cleanConfiguration();
            if (originalImg == null)
            {
                MessageBox.Show("Debe seleccionar una imagen antes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
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
            UpdateHistogram();
        }

        private void btnRedImg_Click(object sender, EventArgs e)
        {
            if (sFilter == "Color")
            {
                pbEditImage.Image = ApplyChannelFilter(originalImg, Channel.Red);
                this.Invalidate();
                UpdateHistogram2();
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
                UpdateHistogram2();
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
                UpdateHistogram2();
            }
            else
            {

            }
        }



        #endregion

        private void tbFilterOnlyImg_Scroll(object sender, EventArgs e)
        {
            switch (sFilter)
            {
                case "BrightnessFilter":
                    float pBrightness = tbFilterOnlyImg.Value;
                    BrightnessFilter(pBrightness / 5);
                    break;
                case "NoiseFilter":
                    NoiseFilter(tbFilterOnlyImg.Value * 10);
                    break;
                case "PixelFilter":
                    PixelFilter(tbFilterOnlyImg.Value * 10);
                    break;
                case "ContrastFilter":
                    ConstrastFilter(tbFilterOnlyImg.Value);
                    break;
            }
        }

        private void btnHorizontalImg_Click(object sender, EventArgs e)
        {
            Bitmap originalImage = (Bitmap)originalImg;
            FiltersC filters = new FiltersC();
            Bitmap filteredImage = filters.HorizontalFilter(originalImage);
            this.Invalidate();
            resultImg = filteredImage;
            pbEditImage.Image = filteredImage;
            UpdateHistogram2();
        }

        private void btnVerticalImg_Click(object sender, EventArgs e)
        {
            Bitmap originalImage = (Bitmap)originalImg;
            FiltersC filters = new FiltersC();
            Bitmap filteredImage = filters.VerticalFilter(originalImage);
            this.Invalidate();
            resultImg = filteredImage;
            pbEditImage.Image = filteredImage;
            UpdateHistogram2();
        }
    }
}
