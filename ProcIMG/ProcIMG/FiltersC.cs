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
    public class FiltersC
    {
        public Bitmap HorizontalFilter(Bitmap original)
        {
            Bitmap filteredImage = new Bitmap(original.Width, original.Height);
            Color rColor = new Color();
            Color oColor = new Color();
            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    oColor = original.GetPixel(x, y);

                    rColor = Color.FromArgb(oColor.R,
                                            oColor.G,
                                            oColor.B);

                    filteredImage.SetPixel(original.Width - x - 1, y, rColor);
                }
            }
            return filteredImage;
        }

        public Bitmap VerticalFilter(Bitmap original)
        {
            Bitmap filteredImage = new Bitmap(original.Width, original.Height);
            Color rColor = new Color();
            Color oColor = new Color();
            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    oColor = original.GetPixel(x, y);

                    rColor = Color.FromArgb(oColor.R,
                                            oColor.G,
                                            oColor.B);

                    filteredImage.SetPixel(x, original.Height - y - 1, rColor);
                }
            }
            return filteredImage;
        }

        public Bitmap BrightnessFilter(Bitmap original, float pBrightness)
        {
            Bitmap filteredImage = new Bitmap(original.Width, original.Height);
            Color rColor = new Color();
            Color oColor = new Color();
            int r = 0;
            int g = 0;
            int b = 0;
            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    oColor = original.GetPixel(x, y);
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
                    filteredImage.SetPixel(x, y, rColor);
                }

            }
            return filteredImage;
        }

        public Bitmap NegativeFilter(Bitmap original)
        {
            Bitmap filteredImage = new Bitmap(original.Width, original.Height);
            Color rColor = new Color();
            Color oColor = new Color();
            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    oColor = original.GetPixel(x, y);

                    rColor = Color.FromArgb(255 - oColor.R,
                                            255 - oColor.G,
                                            255 - oColor.B);

                    filteredImage.SetPixel(x, y, rColor);
                }
            }
            return filteredImage;
        }

        public Bitmap PixelFilter(Bitmap original, int pixelPercent)
        {
            if (pixelPercent == 0)
                pixelPercent = 1;
            Bitmap filteredImage = new Bitmap(original.Width, original.Height);
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
            filteredImage = new Bitmap(original.Width, original.Height);
            for (x = 0; x < original.Width - pixelPercent; x += pixelPercent)
            {
                for (y = 0; y < original.Height - pixelPercent; y += pixelPercent)
                {
                    rs = 0;
                    gs = 0;
                    bs = 0;
                    for (xp = x; xp < (x + pixelPercent); xp++)
                    {
                        for (yp = y; yp < (y + pixelPercent); yp++)
                        {
                            oColor = original.GetPixel(xp, yp);
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
                            filteredImage.SetPixel(xp, yp, rColor);
                        }
                    }
                }

            }
            return filteredImage;
        }

        public Bitmap ContrastFilter(Bitmap original, int contrast)
        {
            float c = (100.0f + contrast / 100.0f);
            c *= c;
            int x = 0;
            int y = 0;
            Bitmap filteredImage = new Bitmap(original.Width, original.Height);
            Color rColor = new Color();
            Color oColor = new Color();
            float r = 0;
            float g = 0;
            float b = 0;
            for (x = 0; x < original.Width; x++)
            {
                for (y = 0; y < original.Height; y++)
                {
                    oColor = original.GetPixel(x, y);

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
                    filteredImage.SetPixel(x, y, rColor);
                }

            }
            return filteredImage;
        }

        public Bitmap NoiseFilter(Bitmap original, float noisePercent)
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

            Bitmap filteredImage = new Bitmap(original.Width, original.Height);
            for (x = 0; x < original.Width; x++)
            {
                for (y = 0; y < original.Height; y++)
                {
                    if (rnd.Next(1, 100) <= noisePercent)
                    {
                        pBrightness = rnd.Next(rangeMin, rangeMax) / 100.0f;
                        oColor = original.GetPixel(x, y);
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
                    }
                    else
                    {
                        rColor = original.GetPixel(x, y);
                    }
                    filteredImage.SetPixel(x, y, rColor);
                }

            }
            return filteredImage;
        }

        public Bitmap ColorFilter(Bitmap originalImg, string channel)
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
                        case "Red":
                            newColor = Color.FromArgb(oColor.R, 0, 0);
                            break;
                        case "Green":
                            newColor = Color.FromArgb(0, oColor.G, 0);
                            break;
                        case "Blue":
                            newColor = Color.FromArgb(0, 0, oColor.B);
                            break;
                        default:
                            newColor = oColor;
                            break;
                    }

                    resultImgLocal.SetPixel(x, y, newColor);
                }
            }
            return resultImgLocal;
        }
    }
}
