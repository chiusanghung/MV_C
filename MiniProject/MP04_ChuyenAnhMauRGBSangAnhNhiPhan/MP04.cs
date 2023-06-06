using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP04_ChuyenAnhMauRGBSangAnhNhiPhan
{
    public partial class MP04 : Form
    {
        Bitmap HinhGoc;
        public MP04()
        {
            InitializeComponent();

            // Load hình .jpg từ file
            HinhGoc = new Bitmap(@"D:\Tai Lieu\Machine Vision\bird_small.jpg");

            // Cho hiện thị lên pictureBox
            picBoxHinhGoc.Image = HinhGoc;

            // Tính hình nhị phân và cho hiện thị
            // Giả sử cho ngưỡng là 100
            picBoxHinhNhiPhan.Image = ChuyenHinhRGBSangHinhNhiPhan(HinhGoc, 100);
        }

        public Bitmap ChuyenHinhRGBSangHinhNhiPhan(Bitmap hinhgoc, byte nguong)
        {
            Bitmap HinhNhiPhan = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            // Điểm tọa độ góc (0,0) của hình là điểm góc trái trên cùng của hình
            // Chiều X sẽ từ gốc tính về phải, chiều Y từ gốc tính xuống dưới
            for (int x = 0; x < hinhgoc.Width; x++)
                for (int y = 0; y < hinhgoc.Height; y++)
                {
                    // Lấy điểm ảnh
                    Color pixel = hinhgoc.GetPixel(x, y);
                    byte R = pixel.R; // Giá trị kênh red
                    byte G = pixel.G;
                    byte B = pixel.B;

                    // Tính giá trị mức xám cho điểm ảnh tại (x,y)
                    byte nhiphan = (byte)(0.2126 * R + 0.7152 * G + 0.0722 * B);

                    // Phân loại điểm ảnh sang nhị phân dựa vào giá trị ngưỡng
                    if (nhiphan < nguong)
                        nhiphan = 0;
                    else
                        nhiphan = 255;

                    // Gán giá trị nhị phân vừa tính vào hình nhị phân
                    HinhNhiPhan.SetPixel(x, y, Color.FromArgb(nhiphan, nhiphan, nhiphan));

                }
            return HinhNhiPhan;
        }

        // Hàm sự kiện vScrollbar
        private void vScrollBarHinhNhiPhan_ValueChanged(object sender, EventArgs e)
        {
            // Lấy giá trị ngưỡng từ giá trị thanh cuộn
            // Value của thanh cuộn trả về là int, ngưỡng là kiểu byte => ép kiểu int về byte
            byte nguong = (byte)vScrollBarHinhNhiPhan.Value;

            // Cho hiện thị giá trị ngưỡng
            lblNguong.Text = nguong.ToString();

            // Gọi hàm tính ảnh nhị phân và cho hiện thị
            picBoxHinhNhiPhan.Image = ChuyenHinhRGBSangHinhNhiPhan(HinhGoc, nguong);
        }

        private void MP04_Load(object sender, EventArgs e)
        {

        }

        private void vScrollBarHinhNhiPhan_Scroll(object sender, ScrollEventArgs e)
        {

        }

        
    }
}
