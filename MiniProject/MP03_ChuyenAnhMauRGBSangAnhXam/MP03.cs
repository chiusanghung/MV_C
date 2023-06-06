using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP03_ChuyenAnhMauRGBSangAnhXam
{
    public partial class MP03 : Form
    {
        public MP03()
        {
            InitializeComponent();

            // Load hình .jpg từ file
            Bitmap HinhGoc = new Bitmap(@"D:\Tai Lieu\Machine Vision\bird_small.jpg");

            // Cho hiện thị lên pictureBox
            picBoxHinhGoc.Image = HinhGoc;

            // Tính hình mức xám theo phương pháp Lightness và cho hiển thị
            picBoxHinhXamLightness.Image = ChuyenHinhRGBSangHinhXamLightness(HinhGoc);

            // Tính hình mức xám theo phương pháp Average và cho hiển thị
            picBoxHinhXamAverage.Image = ChuyenHinhRGBSangHinhXamAverage(HinhGoc);

            // Tính hình mức xám theo phương pháp Luminance và cho hiển thị
            picBoxHinhXamLuminance.Image = ChuyenHinhRGBSangHinhXamLuminance(HinhGoc);

        }
        // Khai báo hàm tính toán mức xám theo phương pháp Lighness
        public Bitmap ChuyenHinhRGBSangHinhXamLightness(Bitmap hinhgoc)
        {
            Bitmap HinhMucXam = new Bitmap(hinhgoc.Width, hinhgoc.Height);

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
                    byte max = Math.Max(R, Math.Max(G, B));
                    byte min = Math.Min(R, Math.Min(G, B));
                    byte gray = (byte)((max + min)/2);          // Khai báo kép, (max + min)/2 là kiểu số

                    // Gán giá trị mức xám vừa tính vào hình mức xám
                    HinhMucXam.SetPixel(x, y, Color.FromArgb(gray, gray, gray)); 

                } 
            return HinhMucXam;
        }

        // Khai báo hàm tính toán mức xám theo phương pháp Average
        public Bitmap ChuyenHinhRGBSangHinhXamAverage(Bitmap hinhgoc)
        {
            Bitmap HinhMucXam = new Bitmap(hinhgoc.Width, hinhgoc.Height);
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
                    byte gray = (byte)((R + G + B) / 3);          // Khai báo kép, (R+G+B)/3 là kiểu số

                    // Gán giá trị mức xám vừa tính vào hình mức xám
                    HinhMucXam.SetPixel(x, y, Color.FromArgb(gray, gray, gray));

                }
            return HinhMucXam;
        }

        // Khai báo hàm tính toán mức xám theo phương pháp Độ Sáng Tuyến Tính (Linear Luminance)
        public Bitmap ChuyenHinhRGBSangHinhXamLuminance(Bitmap hinhgoc)
        {
            Bitmap HinhMucXam = new Bitmap(hinhgoc.Width, hinhgoc.Height);
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
                    byte gray = (byte)(0.2126*R + 0.7152*G + 0.0722*B);

                    // Gán giá trị mức xám vừa tính vào hình mức xám
                    HinhMucXam.SetPixel(x, y, Color.FromArgb(gray, gray, gray));

                }
            return HinhMucXam;
        }
    }
}
