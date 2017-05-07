using Emgu.CV;
using Emgu.CV.OCR;
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
                image = new Image<Bgr, byte>(ofd.FileName);
                invimage = image;
                image = image.ThresholdBinary(new Bgr(100, 100, 100), new Bgr(255, 255, 255));
                CvInvoke.BitwiseNot(image, invimage);
                CvInvoke.MorphologyEx(invimage, image, Emgu.CV.CvEnum.MorphOp.Dilate,
                  CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Ellipse, new Size(3, 3), new Point(-1, -1)),
                  new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar());
                pictureBox1.Image = image.ToBitmap();
                pictureBox1.Invalidate();

                Tesseract t = new Tesseract();
                t.SetVariable("tessedit_char_whitelist", "abcdefghijklmnopqrstuvwxyz0123456789");
                t.Init(@"C:\Emgu\emgucv-windesktop 3.1.0.2504\Emgu.CV.World\tessdata", "eng", OcrEngineMode.Default);
                t.Recognize(image);
                textBox1.Text = t.GetText();
            }
        }
    }
}
