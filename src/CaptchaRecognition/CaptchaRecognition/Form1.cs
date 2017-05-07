using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaptchaRecognition
{
    public partial class Form1 : Form
    {
        private Image<Bgr, byte> image;
        private Image<Bgr, byte> invimage;

        public Form1()
        {
            InitializeComponent();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
        }

        private void loadMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //pictureBox1.Image = Image.FromFile(ofd.FileName);
                image = new Image<Bgr, byte>(ofd.FileName);
                invimage = image;
                //Image<Bgr, Byte> invImage = null;
                image = image.ThresholdBinary(new Bgr(100, 100, 100), new Bgr(255, 255, 255));
                CvInvoke.BitwiseNot(image, invimage);
                //var grayImage = image.Convert<Gray, Byte>();
                CvInvoke.MorphologyEx(invimage, image, Emgu.CV.CvEnum.MorphOp.Dilate,
                  CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Ellipse, new Size(3, 3), new Point(-1, -1)),
                  new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar());
                //pictureBox1.Image = grayImage.ToBitmap();
                pictureBox1.Image = image.ToBitmap();
                pictureBox1.Invalidate();
            }
        }
    }
}
