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
    public partial class HistogramRGB : Form
    {
        private int[] histogramR;
        private int[] histogramG;
        private int[] histogramB;
        private int mayorR;
        private int mayorG;
        private int mayorB;
        public HistogramRGB(int[] pHistogramR, int[] pHistogramG, int[] pHistogramB)
        {
            InitializeComponent();
            histogramR = pHistogramR;
            histogramG = pHistogramG;
            histogramB = pHistogramB;
            int n = 0;
            mayorR = 0;
            mayorG = 0;
            mayorB = 0;
            for (n = 0; n < 256; n++)
            {
                if (histogramR[n] > mayorR)
                    mayorR = histogramR[n];
                if (histogramG[n] > mayorG)
                    mayorG = histogramG[n];
                if (histogramB[n] > mayorB)
                    mayorB = histogramB[n];
            }
            for (n = 0; n < 256; n++)
            {
                histogramR[n] = (int)((float)histogramR[n] / (float)mayorR * 256.0f);
                histogramG[n] = (int)((float)histogramG[n] / (float)mayorG * 256.0f);
                histogramB[n] = (int)((float)histogramB[n] / (float)mayorB * 256.0f);
            }
        }

        private void HistogramRGB_Paint(object sender, PaintEventArgs e)
        {
            int n = 0;
            int height = 0;
            Graphics g = e.Graphics;
            Pen PenR = new Pen(Color.Red);
            Pen PenG = new Pen(Color.Green);
            Pen PenB = new Pen(Color.Blue);
            Pen PenA = new Pen(Color.Coral);

            g.DrawLine(PenA, 19, 271, 277, 271);
            g.DrawLine(PenA, 19, 270, 19, 14);

            for (n = 0; n < 256; n++)
            {
                g.DrawLine(PenR, n + 20, 270, n + 20, 270 - histogramR[n]);
                g.DrawLine(PenG, n + 20, 270, n + 20, 270 - histogramG[n]);
                g.DrawLine(PenB, n + 20, 270, n + 20, 270 - histogramB[n]);
            }
        }
    }
}
