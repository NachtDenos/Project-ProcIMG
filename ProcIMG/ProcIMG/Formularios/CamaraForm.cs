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
using Emgu.CV;
using Emgu.CV.Structure;

namespace ProcIMG
{
    public partial class CamaraForm : Form
    {
        private int activeCameraIndex = -1;
        private bool DevicesExist;
        private FilterInfoCollection MyDevices;
        public static VideoCaptureDevice MyWebCam;
        static readonly CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");
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

        public static void turnOffWebCam()
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
                    MyWebCam.NewFrame += new NewFrameEventHandler(Capturing);
                    MyWebCam.Start();
                    activeCameraIndex = i; 
                }
                else
                {
                    MessageBox.Show("Selecciona una cámara válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Capturing(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            Image<Bgr, byte> grayImage = new Image<Bgr, byte>(bitmap);
            Rectangle[] rectangles = cascadeClassifier.DetectMultiScale(grayImage, 1.2, 1);

            // Obtener el número de rostros detectados
            int numRostros = rectangles.Length;

            if (lblNumPerson.IsHandleCreated)
            {
                lblNumPerson.Invoke((MethodInvoker)(() => lblNumPerson.Text = $"{numRostros}"));
            }

            foreach (Rectangle rectangle in rectangles)
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Pen pen = new Pen(Color.Red, 1))
                    {
                        graphics.DrawRectangle(pen, rectangle);
                    }
                }
            }

            pbCamera.Image = bitmap;
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
