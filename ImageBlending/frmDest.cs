using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageBlending
{
    public partial class frmDest : Form
    {
        public frmDest()
        {
            InitializeComponent();
        }
        Bitmap bmpRegion;
        Image dstImage;
        bool fDrag=false;
        Point ptLastLoc;

        public double ZoomRate
        {
            get
            {
                return Convert.ToDouble(this.imageRegional.Size.Width) / bmpRegion.Size.Width;
            }
        }
        public double[] posDest
        {
            get
            {
                double[] posDest = new double[2];
                posDest[0] = this.imageRegional.Location.X;
                posDest[1] = this.imageRegional.Location.Y;
                return posDest;
            }
        }
        public void SetImage(string dstImage, Image RegionImage)
        {
            this.dstImage = Image.FromFile(dstImage);
            bmpRegion = RegionImage as Bitmap;
            imageDst.Image = this.dstImage;
            imageRegional.Image = bmpRegion;

            this.imageDst.Width = this.dstImage.Width;
            this.imageDst.Height = this.dstImage.Height;

            this.imageRegional.Width = this.bmpRegion.Width;
            this.imageRegional.Height = this.bmpRegion.Height;

            this.Width = this.dstImage.Width + 50;
            this.Height = this.dstImage.Height + 50;
            imageRegional.BackColor = Color.Transparent;
            imageRegional.Parent = imageDst;
            
        }

        public void MoveImageToPosition(Point pt)
        {
            if (fDrag)
            {
                Point ptNow = pt;
                int x = ptNow.X - ptLastLoc.X;
                int y = ptNow.Y - ptLastLoc.Y;

                this.imageRegional.Location = new Point(
                    this.imageRegional.Location.X + x,
                    this.imageRegional.Location.Y + y);
                this.imageRegional.SendToBack();
            }
            ptLastLoc = pt;
        }
        private void imageRegional_MouseDown(object sender, MouseEventArgs e)
        {
            fDrag = true;
        }

        private void imageRegional_MouseUp(object sender, MouseEventArgs e)
        {
            MoveImageToPosition(e.Location);
            fDrag = false;
        }

        private void imageRegional_MouseMove(object sender, MouseEventArgs e)
        {
            MoveImageToPosition(e.Location);
        }

        private void imageDst_MouseUp(object sender, MouseEventArgs e)
        {
            imageRegional_MouseUp(sender, e);
        }

        private void imageDst_MouseMove(object sender, MouseEventArgs e)
        {
            imageRegional_MouseMove(sender, e);
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            Size sz=new Size(Convert.ToInt32(this.imageRegional.Size.Width*1.2),
                Convert.ToInt32(this.imageRegional.Size.Height*1.2));
            this.imageRegional.Size = sz;
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            Size sz = new Size(Convert.ToInt32(this.imageRegional.Size.Width / 1.2),
                Convert.ToInt32(this.imageRegional.Size.Height / 1.2));
            this.imageRegional.Size = sz;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
