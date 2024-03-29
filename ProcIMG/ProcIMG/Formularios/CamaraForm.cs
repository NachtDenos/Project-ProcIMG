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
        private int activeCameraIndex = -1;
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
                    cbCamera.Items.Add(MyDevices[i].Name.ToString());
                cbCamera.Text = MyDevices[0].ToString();
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
            if (activeCameraIndex >= 0)
            {
                turnOffWebCam();
                activeCameraIndex = -1;
                pbCamera.Image = null;
            }
            else
            {
                int i = cbCamera.SelectedIndex;
                if (i >= 0 && i < MyDevices.Count)
                {
                    string nameVideo = MyDevices[i].MonikerString;
                    MyWebCam = new VideoCaptureDevice(nameVideo);
                    MyWebCam.NewFrame += new NewFrameEventHandler(capture);
                    MyWebCam.Start();
                    activeCameraIndex = i; 
                }
                else
                {
                    MessageBox.Show("Selecciona una cámara válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
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
