namespace MP04_ChuyenAnhMauRGBSangAnhNhiPhan
{
    partial class MP04
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBoxHinhGoc = new System.Windows.Forms.PictureBox();
            this.lblHinhGoc = new System.Windows.Forms.Label();
            this.lblHinhNhiPhan = new System.Windows.Forms.Label();
            this.picBoxHinhNhiPhan = new System.Windows.Forms.PictureBox();
            this.vScrollBarHinhNhiPhan = new System.Windows.Forms.VScrollBar();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.lblNguong = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhGoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhNhiPhan)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxHinhGoc
            // 
            this.picBoxHinhGoc.Location = new System.Drawing.Point(21, 38);
            this.picBoxHinhGoc.Name = "picBoxHinhGoc";
            this.picBoxHinhGoc.Size = new System.Drawing.Size(500, 381);
            this.picBoxHinhGoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxHinhGoc.TabIndex = 0;
            this.picBoxHinhGoc.TabStop = false;
            // 
            // lblHinhGoc
            // 
            this.lblHinhGoc.AutoSize = true;
            this.lblHinhGoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblHinhGoc.Location = new System.Drawing.Point(16, 9);
            this.lblHinhGoc.Name = "lblHinhGoc";
            this.lblHinhGoc.Size = new System.Drawing.Size(103, 26);
            this.lblHinhGoc.TabIndex = 1;
            this.lblHinhGoc.Text = "Hình Gốc";
            // 
            // lblHinhNhiPhan
            // 
            this.lblHinhNhiPhan.AutoSize = true;
            this.lblHinhNhiPhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblHinhNhiPhan.Location = new System.Drawing.Point(592, 9);
            this.lblHinhNhiPhan.Name = "lblHinhNhiPhan";
            this.lblHinhNhiPhan.Size = new System.Drawing.Size(153, 26);
            this.lblHinhNhiPhan.TabIndex = 3;
            this.lblHinhNhiPhan.Text = "Hình Nhị Phân";
            // 
            // picBoxHinhNhiPhan
            // 
            this.picBoxHinhNhiPhan.Location = new System.Drawing.Point(597, 38);
            this.picBoxHinhNhiPhan.Name = "picBoxHinhNhiPhan";
            this.picBoxHinhNhiPhan.Size = new System.Drawing.Size(500, 381);
            this.picBoxHinhNhiPhan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxHinhNhiPhan.TabIndex = 2;
            this.picBoxHinhNhiPhan.TabStop = false;
            // 
            // vScrollBarHinhNhiPhan
            // 
            this.vScrollBarHinhNhiPhan.Location = new System.Drawing.Point(1124, 38);
            this.vScrollBarHinhNhiPhan.Maximum = 255;
            this.vScrollBarHinhNhiPhan.Name = "vScrollBarHinhNhiPhan";
            this.vScrollBarHinhNhiPhan.Size = new System.Drawing.Size(45, 381);
            this.vScrollBarHinhNhiPhan.TabIndex = 4;
            this.vScrollBarHinhNhiPhan.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBarHinhNhiPhan_Scroll);
            this.vScrollBarHinhNhiPhan.ValueChanged += new System.EventHandler(this.vScrollBarHinhNhiPhan_ValueChanged);
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblThreshold.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblThreshold.Location = new System.Drawing.Point(1103, 9);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(94, 26);
            this.lblThreshold.TabIndex = 5;
            this.lblThreshold.Text = "Ngưỡng:";
            // 
            // lblNguong
            // 
            this.lblNguong.AutoSize = true;
            this.lblNguong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNguong.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNguong.Location = new System.Drawing.Point(1168, 38);
            this.lblNguong.Name = "lblNguong";
            this.lblNguong.Size = new System.Drawing.Size(0, 26);
            this.lblNguong.TabIndex = 7;
            // 
            // MP04
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 1055);
            this.Controls.Add(this.lblNguong);
            this.Controls.Add(this.lblThreshold);
            this.Controls.Add(this.vScrollBarHinhNhiPhan);
            this.Controls.Add(this.lblHinhNhiPhan);
            this.Controls.Add(this.picBoxHinhNhiPhan);
            this.Controls.Add(this.lblHinhGoc);
            this.Controls.Add(this.picBoxHinhGoc);
            this.Name = "MP04";
            this.Text = "Chuyển Ảnh Màu RGB Sang Ảnh Nhị Phân";
            this.Load += new System.EventHandler(this.MP04_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhGoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxHinhNhiPhan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxHinhGoc;
        private System.Windows.Forms.Label lblHinhGoc;
        private System.Windows.Forms.Label lblHinhNhiPhan;
        private System.Windows.Forms.PictureBox picBoxHinhNhiPhan;
        private System.Windows.Forms.VScrollBar vScrollBarHinhNhiPhan;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.Label lblNguong;
    }
}

