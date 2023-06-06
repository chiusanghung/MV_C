using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGB2CMYK
{
    public partial class MP06 : Form
    {
        public MP06()
        {
            InitializeComponent();
            // Load hình .jpg từ file
            Bitmap HinhGoc = new Bitmap(@"D:\Tai Lieu\Machine Vision\lena_color.gif");

            // Cho hiện thị lên pictureBox
            picBoxHinhGoc.Image = HinhGoc;

            // Hiện thị các kênh màu CMYK được chuyển đổi từ RGB
            // Gọi hàm chuyển đổi RGB sang CMYK
            List<Bitmap> CMYK = ChuyenDoiRGBSangCMYK(HinhGoc);

            // Hàm trên trả về 4 màu tương ứng thứ tự từ 0-3 (C-M-Y-K)
            picBoxC.Image = CMYK[0];        // Kênh màu Cyan
            picBoxM.Image = CMYK[1];        // Kênh màu Magenta
            picBoxY.Image = CMYK[2];        // Kênh màu Yellow
            pictBoxK.Image = CMYK[3];       // Kênh màu Black
        }

        public List<Bitmap> ChuyenDoiRGBSangCMYK(Bitmap hinhgoc)
        {
            /*-----------------------------------------------------------------------------------------------------
            Lưu ý: Việc tính chuyển đổi hệ màu RGB sang CMYK và ngược lại đơn giản là sự pha trộn màu của các
            kênh tương ứng, không phải dùng công thức tính (nặng chương trình, làm suy giảm giá trị màu sau mỗi
            lần chuyển đổi)
            
            - Màu Cyan (xanh dương): kết hợp giữa Green và Blue, set kênh Red = 0
            - Màu Magenta (màu đỏ tươi): Red và Blue, set kênh Green = 0
            - Màu Yellow: Red và Green, set kênh Blue = 0
            - Màu Black: lấy MIN(R, G, B)
            --------------------------------------------------------------------------------------------------------*/

            // Tạo 1 List để chứa 4 kênh ảnh tương ứng C-M-Y-K
            // Trong C#.Net là 1 mảng nhưng không cần khai báo kích thước
            List<Bitmap> CMYK = new List<Bitmap>();

            // Tạo 4 hình bitmap, chưa chứa thông tin, kích thước mỗi hình phải bằng với kích thước hình gốc để việc
            // toán chuyển đổi kênh màu đc thực hiện đúng cho từng pixel
            // Mỗi kênh trong không gian màu CMYK được hiện thị bởi 1 hình bitmap
            Bitmap Cyan = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            Bitmap Magenta = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            Bitmap Yellow = new Bitmap(hinhgoc.Width, hinhgoc.Height);
            Bitmap Black = new Bitmap(hinhgoc.Width, hinhgoc.Height);

            for (int x = 0; x < hinhgoc.Width; x++)
                for (int y = 0; y < hinhgoc.Height; y++)
                {
                    // Lấy điểm ảnh
                    Color pixel = hinhgoc.GetPixel(x, y);
                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;

                    // Tiến hành trộn các kênh màu RGB
                    // Màu Cyan là kết hợp giữa G và B, set kênh R = 0
                    Cyan.SetPixel(x, y, Color.FromArgb(0, G, B));
                    Magenta.SetPixel(x, y, Color.FromArgb(R, 0, B));
                    Yellow.SetPixel(x, y, Color.FromArgb(R, G, 0));

                    // Do hàm Min chỉ có 2 đối số đầu vào nên phải thực hiện 2 lần
                    byte K = Math.Min(R, Math.Min(G, B));
                    Black.SetPixel(x, y, Color.FromArgb(K, K, K));
                }

            // Add các hình tương ứng các kênh màu C-M-Y-K vào list
            // List là kiểu dữ liệu mảng (Array) ko cần biết trước kích thước nên mình có thể Add các element của
            // list vào mà lo bị tràn kích thước 
            CMYK.Add(Cyan);
            CMYK.Add(Magenta);
            CMYK.Add(Yellow);
            CMYK.Add(Black);

            // Hàm trả về là 1 list 4 ảnh bitmap tương ứng vs 4 kênh C-M-Y-K
            return CMYK;
        }
    }
}
