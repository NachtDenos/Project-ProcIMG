using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;

namespace ProcIMG
{
    public partial class CamaraForm : Form
    {
        private bool DevicesExist;
        private FilterInfoCollection MyDevices;
        private VideoCaptureDevice MyWebCam;
        public CamaraForm()
        {
            InitializeComponent();
        }

        public void loadDevices()
        {
            MyDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if(MyDevices.Count > 0)
            {
                DevicesExist = true;
                for(int i = 0; i < MyDevices.Count; i++)
                    comboBox1.Items.Add(MyDevices[i].Name.ToString());
                comboBox1.Text = MyDevices[0].ToString();
            }
            else
            {
                DevicesExist = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CamaraForm_Load(object sender, EventArgs e)
        {
            loadDevices();
        }

        public void turnOffWebCam()
        {
            if (MyWebCam != null && MyWebCam.IsRunning)
            {
                MyWebCam.SignalToStop();
                MyWebCam = null;
            }
        }

        private void btnOnOffCamera_Click(object sender, EventArgs e)
        {
            turnOffWebCam();
            int i = comboBox1.SelectedIndex;
            string nameVideo = MyDevices[i].MonikerString;
            MyWebCam = new VideoCaptureDevice(nameVideo);
            MyWebCam.NewFrame += new NewFrameEventHandler(capture);
            MyWebCam.Start();
        }

        private void capture(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap ImageV = (Bitmap)eventArgs.Frame.Clone();
            pbCamera.Image = ImageV;
        }

        private void CamaraForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            turnOffWebCam();
        }
    }
}
