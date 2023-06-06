using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP15_Edge_Detection_RGB
{
    public partial class MP15 : Form
    {
        Bitmap hinhGoc;
        int nguong;
        public MP15()
        {
            InitializeComponent();
            // Load hình gốc:
            hinhGoc = new Bitmap(@"D:\Tai Lieu\Machine Vision\lena_color.gif");

            // Load anh vao picbox
            pictureBox1.Image = hinhGoc;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label_Track_Bar.Text = trackBar1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nguong = (byte)trackBar1.Value;
            pictureBox2.Image = EdgeDetection(hinhGoc, nguong);
        }
        public Bitmap EdgeDetection(Bitmap hinhGoc, int nguong)
        {

            Bitmap ImageDetected = new Bitmap(hinhGoc.Width, hinhGoc.Height);
            double[,] Sobel_X = { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
            double[,] Sobel_Y = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };

            for (int x = 1; x < hinhGoc.Width - 1; x++)
                for (int y = 1; y < hinhGoc.Height - 1; y++)
                {
                    double[,] Gradient = { { 0, 0 }, { 0, 0 }, { 0, 0 } };

                    for (int i = -1; i <= 1; i++)
                        for (int j = -1; j <= 1; j++)
                        {
                            Color pixel = hinhGoc.GetPixel(x + i, y + j);
                            double R = pixel.R;
                            double G = pixel.G;
                            double B = pixel.B;

                            Gradient[0, 0] += R * Sobel_X[i + 1, j + 1];
                            Gradient[0, 1] += R * Sobel_Y[i + 1, j + 1];

                            Gradient[1, 0] += G * Sobel_X[i + 1, j + 1];
                            Gradient[1, 1] += G * Sobel_Y[i + 1, j + 1];

                            Gradient[2, 0] += B * Sobel_X[i + 1, j + 1];
                            Gradient[2, 1] += B * Sobel_Y[i + 1, j + 1];


                            double gxx = (Gradient[0, 0] * Gradient[0, 0]) + (Gradient[1, 0] * Gradient[1, 0]) + (Gradient[2, 0] * Gradient[2, 0]);
                            double gyy = (Gradient[0, 0] * Gradient[0, 0]) + (Gradient[1, 0] * Gradient[1, 0]) + (Gradient[2, 0] * Gradient[2, 0]);
                            double gxy = (Gradient[0, 0] * Gradient[0, 1]) + (Gradient[1, 0] * Gradient[1, 1]) + (Gradient[2, 0] * Gradient[2, 1]);

                            double theta_xy = 0.5 * Math.Atan((2 * gxy) / (gxx - gyy));

                            double F0 = Math.Sqrt((gxx + gxy + (gxx - gyy) * Math.Cos(2 * theta_xy) + 2 * gxy * Math.Sin(2 * theta_xy)) / 2);

                            if (F0 <= nguong)
                            {
                                ImageDetected.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                            }
                            else
                            {
                                ImageDetected.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                            }
                        }

                }
            return ImageDetected;
        }

    }
}
