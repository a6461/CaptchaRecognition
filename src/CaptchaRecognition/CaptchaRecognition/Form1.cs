using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaptchaRecognition
{
    public partial class CaptchaForm : Form
    {
        private Image<Bgr, byte> InImage;
        private Image<Bgr, byte> ThresImage;
        private Image<Bgr, byte> BitNotImage;
        private Image<Bgr, byte> OutImage;

        public CaptchaForm()
        {
            InitializeComponent();
            ofd.Filter = "Image files (*.bmp, *.jpg, *.jpeg, *.png) | *.bmp; *.jpg; *.jpeg; *.png";
        }

        private void LoadMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                captchaBox.Image = Image.FromFile(ofd.FileName);
                captchaBox.Invalidate();
            }
        }

        private void Recognize_Click(object sender, EventArgs e)
        {
            if (ofd.FileName != "")
            {
                InImage = new Image<Bgr, byte>(ofd.FileName);
                BitNotImage = ThresImage = OutImage = InImage;
                ThresImage = InImage.ThresholdBinary(new Bgr(100, 100, 100), new Bgr(255, 255, 255));
                CvInvoke.BitwiseNot(ThresImage, BitNotImage);
                CvInvoke.MorphologyEx(BitNotImage, OutImage, Emgu.CV.CvEnum.MorphOp.Dilate,
                    CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Ellipse, new Size(3, 3), new Point(-1, -1)),
                    new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar());

                Tesseract tess = new Tesseract();
                tess.Init(@"C:\Emgu\emgucv-windesktop 3.1.0.2504\Emgu.CV.World\tessdata", "eng", OcrEngineMode.Default);
                tess.Recognize(OutImage);
                result.Text = "Результат: " + tess.GetText();
            }
        }
    }
}
