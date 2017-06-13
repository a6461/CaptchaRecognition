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
        private Image<Gray, byte> InImage;
        private Image<Gray, byte> ThresImage;
        private Image<Gray, byte> BitNotImage;
        private Image<Gray, byte> OutImage;

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
                InImage = new Image<Gray, byte>(ofd.FileName);
                BitNotImage = ThresImage = OutImage = InImage;
                
                OutImage = ThresImage = InImage.ThresholdBinary(new Gray(200), new Gray(255));
                CvInvoke.BitwiseNot(ThresImage, BitNotImage);
                if (checkBox1.Checked)
                    CvInvoke.MorphologyEx(BitNotImage, OutImage, Emgu.CV.CvEnum.MorphOp.Dilate,
                        CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Ellipse, new Size(3, 3), new Point(-1, -1)),
                        new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar());

                Tesseract tess = new Tesseract();

                tess.Init(@"C:\Emgu\tessdata", "eng", OcrEngineMode.Default);
                tess.SetVariable("tessedit_char_blacklist", "\\/'`‘");
                tess.Recognize(OutImage);
                captchaBox.Image = OutImage.ToBitmap();
                captchaBox.Refresh();
                result.Text = "Результат: " + tess.GetText();
            }
        }
    }
}
