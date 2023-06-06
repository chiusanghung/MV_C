using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP13_Segmentation
{
    public partial class MP13 : Form
    {
        Bitmap hinhGoc;
        int x1, x2, y1, y2, nguong;
        public MP13()
        {

            InitializeComponent();
            // Load hình gốc:
            hinhGoc = new Bitmap(@"D:\Tai Lieu\Machine Vision\lena_color.gif");

            // Load anh vao picbox
            pictureBox1.Image = hinhGoc;
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label_TrackBar.Text = trackBar1.Value.ToString();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            // lấy dữ liệu từ Textbox và Chuyển kiểu dữ liệu về dạng số nguyên:
            x1 = Int32.Parse(textBox1.Text);
            x2 = Int32.Parse(textBox3.Text);
            y1 = Int32.Parse(textBox2.Text);
            y2 = Int32.Parse(textBox4.Text);
            nguong = (byte)trackBar1.Value;
            pictureBox2.Image = ColorSegmentation(hinhGoc, x1, x2, y1, y2, nguong);
        }

        public Bitmap ColorSegmentation(Bitmap hinhGoc, int x1, int x2, int y1, int y2, int nguong)
        {
            Bitmap ImageSegmentation = new Bitmap(hinhGoc.Width, hinhGoc.Height);
            // averageRGB là vecto màu trung bình
            double[] averageRGB = new double[3];
            // So diem anh trong vung da chon:
            int Size = Math.Abs(x2 - x1) * Math.Abs(y2 - y1);
            for (int x = x1; x <= x2; x++)
                for (int y = y1; y <= y2; y++)
                {
                    // Cộng dồn các giá trị:
                    Color RGB_Image = hinhGoc.GetPixel(x, y);
                    averageRGB[0] += RGB_Image.R;
                    averageRGB[1] += RGB_Image.G;
                    averageRGB[2] += RGB_Image.B;
                }
            averageRGB[0] = (int)(averageRGB[0] / Size);
            averageRGB[1] = (int)(averageRGB[1] / Size);
            averageRGB[2] = (int)(averageRGB[2] / Size);

            for (int x = 0; x < hinhGoc.Width; x++)
                for (int y = 0; y < hinhGoc.Height; y++)
                {
                    Color RGB_Image = hinhGoc.GetPixel(x, y);
                    double zR = RGB_Image.R;
                    double zG = RGB_Image.G;
                    double zB = RGB_Image.B;
                    int D_za = (int)Math.Sqrt((zR - averageRGB[0]) * (zR - averageRGB[0]) +
                        (zG - averageRGB[1]) * (zG - averageRGB[1]) + (zB - averageRGB[2]) *
                        (zB - averageRGB[2]));
                    if (D_za <= nguong)
                    {
                        zR = 255;
                        zG = 255;
                        zB = 255;
                    }
                    ImageSegmentation.SetPixel(x, y, Color.FromArgb((byte)zR, (byte)zG, (byte)zB));
                }
            return ImageSegmentation;
        }

        private void label_trackBAr_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
