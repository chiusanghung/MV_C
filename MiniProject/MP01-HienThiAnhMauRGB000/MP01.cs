using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;


namespace MiniProject1
{
    public partial class MP01 : Form
    {
        public MP01()
        {
            InitializeComponent();
            Image<Bgr, byte> hinhhienthi = new Image<Bgr, byte>(@"D:\Tai Lieu\Thi giac may\bird_small.jpg");
            imageBox1.Image = hinhhienthi; 
        }

        private void imageBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
