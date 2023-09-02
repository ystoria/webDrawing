/*
 * Mehdi Calanducci
 * 17.11.2021
 * Perso
 * Drawing Random Lines
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drawing_Test
{
    public partial class frmDraw : Form
    {
        Random rand = new Random();
        const int NB_LINES = 500;

        void Artist()
        {
            using (var bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height))
            using (var gfx = Graphics.FromImage(bmp))
            using (var draw = new Pen(Color.White))
            {
                //Draw the amount of lines specified in the const NB_LINES
                gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                gfx.Clear(Color.Navy);
                for (int i = 0; i < NB_LINES; i++)
                {
                    //Pick two random points inside the pictureBox Height and Width length
                    var pt1 = new Point(rand.Next(bmp.Width), rand.Next(bmp.Height));
                    var pt2 = new Point(rand.Next(bmp.Width), rand.Next(bmp.Height));
                    gfx.DrawLine(draw, pt1, pt2);
                }
                //Copy the bitmap to the pictureBox
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = (Bitmap)bmp.Clone();
            }
        }


        public frmDraw()
        {
            InitializeComponent();
        }

        private void frmDraw_Load(object sender, EventArgs e)
        {
            Artist();
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            Artist();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Artist();
        }
    }
}
