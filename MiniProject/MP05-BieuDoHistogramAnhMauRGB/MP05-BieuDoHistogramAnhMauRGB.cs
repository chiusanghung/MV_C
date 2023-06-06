using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Project05_VebieudoHistogramanhmauRGB
{
    public partial class MP05 : Form
    {
        public MP05()
        {
            InitializeComponent();
            //Load hình từ file
            Bitmap HinhGoc = new Bitmap(@"D:\Tai Lieu\Machine Vision\bird_small.jpg");

            //Cho hình hiển thị trên pictureBox
            picBoxHinhGoc.Image = HinhGoc;


            // Gọi hàm đã viết để vẽ biểu đồ Histogram
            // TÍnh histogram
            double[,] histogram = TinhHistogram(HinhGoc);

            //Chuyển đổi kiểu dữ liệu.
            List<PointPairList> points = ChuyenDoiHistogram(histogram);

            //Vẽ biểu đồ
            zGHistogram.GraphPane = BieuDoHistogram(points);
            zGHistogram.Refresh();

        }

        //Tính histogram của ảnh màu RGB
        public double[,] TinhHistogram(Bitmap bmp)
        {
            // Chúng ta dùng mảng 2 chiều để chứa thông tin histogram cho các kênh R G B
            // 3: là số kênh màu cần lưu
            // 256: là cần 256 vị trí tương ứng giá trị màu từ 0 đến 255
            double[,] histogram = new double[3,256];

            for (int x = 0; x < bmp.Width; x++)
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color color = bmp.GetPixel(x, y);
                    byte R = color.R;
                    byte G = color.G;
                    byte B = color.B;

                    histogram[0, R]++; // Histogram của kênh màu R
                    histogram[1, G]++; // Histogram của kênh màu R
                    histogram[2, B]++; // Histogram của kênh màu R
                }
            return histogram;
        }
        List<PointPairList> ChuyenDoiHistogram(double[,] histogram)
        {
            // Dùng một mảng không cần khai báo trước số lượng phần tử để chứa các chuyển đổi.
            List<PointPairList> points = new List<PointPairList>();

            PointPairList redPoints= new PointPairList();       // Chuyển đổi histogram kênh R 
            PointPairList greenPoints = new PointPairList();    // Chuyển đổi histogram kênh G
            PointPairList bluePoints = new PointPairList();     // Chuyển đổi histogram kênh B

            for (int i = 0; i < 256; i++)
            {
                // i tương ứng trục nằm ngang, từ 0 - 255
                // histogram[i] tương ứng trục đứng, là số pixels cùng mức xám
                redPoints.Add(i, histogram[0,i]);       // Chuyển đổi cho kênh R
                greenPoints.Add(i, histogram[1, i]);    // Chuyển đổi cho kênh G
                bluePoints.Add(i, histogram[2, i]);     // Chuyển đổi cho kênh B
            }
            // sau khi kết thúc vòng for thì thông tin histogram của các kênh RGB đá được chuyển đổi thành công 
            // già add các kênh vào mảng points để trả về cho hàm
            points.Add(redPoints);
            points.Add(greenPoints);
            points.Add(bluePoints);
            return points;

        }
        public GraphPane BieuDoHistogram(List<PointPairList> histogram)
        {
            //GraphPane là đối tượng biểu đồ trong ZedGraph.
            GraphPane gp = new GraphPane();

            gp.Title.Text = @"BIểu đồ Histogram";//tên biểu đồ
            gp.Rect = new Rectangle(0, 0, 700, 500);

            //Thiết lập trục ngang
            gp.XAxis.Title.Text = @"Giá trị màu của các điểm ảnh";
            gp.XAxis.Scale.Min = 0;         // Nhỏ nhất là 0
            gp.XAxis.Scale.Max = 255;
            gp.XAxis.Scale.MajorStep = 5;   //  Mỗi bước chính là 5
            gp.XAxis.Scale.MinorStep = 1;   // Mỗi bước trong 1 bước chính là 1

            //Tương tự thiết lập cho trục đứng
            gp.YAxis.Title.Text = @"Số điểm ảnh có cùng giá trị màu";
            gp.YAxis.Scale.Min = 0;         // Nhỏ nhất là 0
            gp.YAxis.Scale.Max = 15000;     // số này phải lớn hơn kích thước ảnh(W x h)
            gp.YAxis.Scale.MajorStep = 5;   //  Mỗi bước chính là 5
            gp.YAxis.Scale.MinorStep = 1;   // Mỗi bước trong 1 bước chính là 1

            // Dùng biểu đồ dạng bar để biểu diễn histogram.
            gp.AddBar("Histogram's Red", histogram[0], Color.Red);
            gp.AddBar("Histogram's Green", histogram[1], Color.Green);
            gp.AddBar("Histogram's Blue", histogram[2], Color.Blue);
            return gp;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
