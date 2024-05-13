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
    }
}
