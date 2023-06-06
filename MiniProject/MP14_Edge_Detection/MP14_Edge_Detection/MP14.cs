using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP14_Edge_Detection
{
    public partial class MP14 : Form
    {
        Bitmap hinhGoc;
        int nguong;
        public MP14()
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
            double[,] Sober_X = { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
            double[,] Sober_Y = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };

            for (int x = 1; x < hinhGoc.Width - 1; x++)
                for (int y = 1; y < hinhGoc.Height - 1; y++)
                {
                    double[] Gradient = { 0, 0 };

                    for (int i = -1; i <= 1; i++)
                        for (int j = -1; j <= 1; j++)
                        {
                            Color pixel = hinhGoc.GetPixel(x + i, y + j);
                            double R = pixel.R;
                            double G = pixel.G;
                            double B = pixel.B;

                            double gray = (0.2126 * R + 0.7152 * G + 0.0722 * B);
                            Gradient[0] += gray * Sober_X[i + 1, j + 1];
                            Gradient[1] += gray * Sober_Y[i + 1, j + 1];
                            double M = Math.Abs(Gradient[0]) + Math.Abs(Gradient[1]);
                            if (M <= nguong)
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
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        
    }
}
