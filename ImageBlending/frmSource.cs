using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace ImageBlending
{
    public partial class frmSource : Form
    {
        public frmSource()
        {
            InitializeComponent();
        }
        public Bitmap imageRegionSel;
        Image imageSrc;
        Image imageMask;
        Point ptBox1;//外接矩形的左上角点
        Point ptBox2;//外接矩形的右下角点

        public double[] BoxSrc
        {
            get
            {
                double[] boxSrc = new double[4];
                boxSrc[0] = ptBox1.X;
                boxSrc[1] = ptBox2.X;
                boxSrc[2] = ptBox1.Y;
                boxSrc[3] = ptBox2.Y;
                return boxSrc;
            }
        }
        
        public frmSource(string imagePath)
            : this()
        {
            LoadImage(imagePath);
        }

        public void LoadImage(string imagePath)
        {

            imageSrc = Bitmap.FromFile(imagePath);
            
            this.imgSrc.Image = imageSrc;
            this.Width = imageSrc.Width + 5;
            this.Height = imageSrc.Height + 5;

            imageMask = Bitmap.FromFile(imagePath);
            //将Mask清零
            Graphics g = Graphics.FromImage(imageMask);
            g.FillRectangle(Brushes.Black,new Rectangle(0,0,imageMask.Width,imageMask.Height));
            g.Dispose();
        }

        List<Point> lstPt=new List<Point>(16);
        bool bFinishedSelect=false;

        private void imgSrc_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //左键单击，画点
            {
                lstPt.Add(e.Location);
                if (bFinishedSelect)//不当心双击了
                {
                    lstPt.RemoveAt(lstPt.Count-1);
                    lstPt.RemoveAt(lstPt.Count - 1);
                    bFinishedSelect = false;
                }
                imgSrc.Invalidate();
            }
            else if (e.Button == MouseButtons.Right) //右击可以移除最后一个点（误双击）
            {
                this.Close();
            }
        }

        private void imgSrc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //左键双击，把所有点连起来画点
            {
                bFinishedSelect = true;
                lstPt.Add(e.Location);
                lstPt.Add(lstPt[0]);
            }
            
            imgSrc.Invalidate();
        }

        private void imgSrc_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //说明：1-（128/255）=1-0.5=0.5 透明度为0.5，即50%
            System.Drawing.Color Mycolor = System.Drawing.Color.FromArgb(128, Color.Red);
            System.Drawing.SolidBrush sb1 = new System.Drawing.SolidBrush(Mycolor);
            if (bFinishedSelect) //完成选择则画多边形
            {
                if (lstPt.Count > 2) //还得判断3点是否一直线
                {
                    g.FillPolygon(sb1, lstPt.ToArray(),System.Drawing.Drawing2D.FillMode.Winding);
                }
            }
            else //还没完成选择，则只连接这些线
            {
                if (lstPt.Count > 1) 
                   g.DrawLines(Pens.Red, lstPt.ToArray()); 
            }
        }

        private void frmSource_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void frmSource_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lstPt.Count <= 2)
            {
                if (DialogResult.Cancel == MessageBox.Show("Source region has not been selected, really wanna close?", "Question", MessageBoxButtons.OKCancel))
                {
                    e.Cancel = true;
                }
            }
            else
            {
                //保存Mask
                Graphics g = Graphics.FromImage(imageMask);
                g.FillPolygon(Brushes.White, lstPt.ToArray(), System.Drawing.Drawing2D.FillMode.Winding);
                //计算Mask的最小外接矩形
                int x0 = 99999, y0 = 99999, x1 = 0, y1 = 0;
                foreach (Point pt in lstPt)
                {
                    if (x0 > pt.X)
                    {
                        x0 = pt.X;
                    }
                    if (y0 > pt.Y)
                    {
                        y0 = pt.Y;
                    }
                    if (x1 < pt.X)
                    {
                        x1 = pt.X;
                    }
                    if (y1 < pt.Y)
                    {
                        y1 = pt.Y;
                    }
                }
                ptBox1.X = x0;
                ptBox1.Y = y0;
                ptBox2.X = x1;
                ptBox2.Y = y1;
                //g.DrawRectangle(Pens.Red,new Rectangle(x0,y0,x1-x0,y1-y0));
                string savepath = FrmMain.strMaskTmpPath;
                imageMask.Save(savepath);
                Bitmap bmpSrc = imageSrc as Bitmap;
                Bitmap bmpMask = imageMask as Bitmap;
                Rectangle rect = new Rectangle(x0, y0, x1 - x0, y1 - y0);

                this.imageRegionSel = bmpSrc.Clone(rect, PixelFormat.Format32bppArgb);
                Color color;

                for (int i = 0; i < rect.Height; i++)
                    for (int j = 0; j < rect.Width; j++)
                    {
                        color = bmpMask.GetPixel(rect.X + j, rect.Y + i);
                        if (color.ToArgb() == Color.Black.ToArgb())
                        {
                            imageRegionSel.SetPixel(j, i, Color.Transparent);
                        }
                    }
                /*
                Bitmap bmp = bmpSrc.Clone(rect,PixelFormat.Format24bppRgb);
                bmp.Save("tmpMask2.jpg");
                */
                g.Dispose();
            }
        }

        private void frmSource_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }
    }
}
