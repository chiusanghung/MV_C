    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Project05_VebieudoHistogram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Load hình từ file
            Bitmap HinhGoc = new Bitmap(@"D:\Tai Lieu\Machine Vision\bird_small.jpg");

            //Cho hình hiển thị trên pictureBox
            picBoxHinhGoc.Image = HinhGoc;

            //Tính hình mức xám theo phương pháp Luminance và cho hiển thị
            Bitmap HinhMucXam = ChuyenHinhRGBSangXamLuminance(HinhGoc);
            picBoxHinhXamLuminance.Image = HinhMucXam;

            // TÍnh histogram
            double[] histogram = TinhHistogram(HinhMucXam);

            //Chuyển đổi kiểu dữ liệu.
            PointPairList points = ChuyenDoiHistogram(histogram);

            //Vẽ biểu đồ
            zGHistogram.GraphPane = BieuDoHistogram(points);
            zGHistogram.Refresh();

        }
        public Bitmap ChuyenHinhRGBSangXamLuminance(Bitmap hinhgoc)
        {
            Bitmap HinhMucXam = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            for (int x = 0; x < hinhgoc.Width; x++)
                for (int y = 0; y < hinhgoc.Height; y++)
                {

                    //Lấy điểm ảnh
                    Color pixel = hinhgoc.GetPixel(x, y);
                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;

                    //Tính giá trị mức xám cho điểm ảnh tại x,y
                    byte gray = (byte)((0.2126 * R + 0.0722 * B + 0.7152 * G));

                    //Gán giá trị mức xám vừa tính vào hình mức xám
                    HinhMucXam.SetPixel(x, y, Color.FromArgb(gray, gray, gray));


                }
            return HinhMucXam;
        }

        public double[] TinhHistogram(Bitmap HinhMucXam)
        {
            // Mỗi pixel mức xám có giá trị từ 0- 255, do vật ta khai báo một mảng
            // có 256 phần tử dùng để chứa số đếm của các pixels có cùng mức xám trong ảnh.
            // Chúng ta nên dùng kiểu double vì tổng số đếm có thể rất lớn, phụ thuộc kích thước của ảnh.
            double[] histogram = new double[256];

            for (int x = 0; x < HinhMucXam.Width; x++)
                for (int y = 0; y < HinhMucXam.Height; y++)
                {
                    Color color = HinhMucXam.GetPixel(x, y);
                    byte gray = color.R; // Trong hình mức xám giá trị kênh R cũng giống G hoặc B 

                    // Giá trị gray tính ra cũng chính là phần tử thứ gray trong mảng histogram
                    // đã khai báo. Sẽ tăng số đếm của phần tử thứ gray lên 1.
                    histogram[gray]++;
                }
            return histogram;
        }

        PointPairList ChuyenDoiHistogram(double[] histogram)
        {
            // PointPairList là kiểu dữ liệu của zedGraph để vẽ biểu đồ.
            PointPairList points = new PointPairList();
            for (int i = 0; i < histogram.Length; i++)
            {
                // i tương ứng trục nằm ngang, từ 0- 255
                // histogram[i] tương ứng trục đứng, là số pixels cùng mức xám
                points.Add(i, histogram[i]);
            }
            return points;

        }

        public GraphPane BieuDoHistogram(PointPairList histogram)
        {
            //GraphPane là đối tượng biểu đồ trong ZedGraph.
            GraphPane gp = new GraphPane();

            gp.Title.Text = @"BIểu đồ Histogram";//tên biểu đồ
            gp.Rect = new Rectangle(0, 0, 700, 500);

            //Thiết lập trục ngang
            gp.XAxis.Title.Text = @"Giá trị mức xám của các điểm ảnh";
            gp.XAxis.Scale.Min = 0; // Nhỏ nhất là 0
            gp.XAxis.Scale.Max = 255;
            gp.XAxis.Scale.MajorStep = 5; //  Mỗi bước chính là 5
            gp.XAxis.Scale.MinorStep = 1; //  Mỗi bước trong 1 bước chính là 1

            //Tương tự thiết lập cho trục đưgns
            gp.YAxis.Title.Text = @"Số điểm ảnh có cùng mức xám";
            gp.YAxis.Scale.Min = 0; // Nhỏ nhất là 0
            gp.YAxis.Scale.Max = 15000; // số này phải lớn hơn kích thước ảnh(W x h)
            gp.YAxis.Scale.MajorStep = 5; //  Mỗi bước chính là 5
            gp.YAxis.Scale.MinorStep = 1; // Mỗi bước trong 1 bước chính là 1

            // Dùng biểu đồ dạng bar để biểu diễn histogram.
            gp.AddBar("Histogram", histogram, Color.OrangeRed);
            return gp;

        }

    }
}

