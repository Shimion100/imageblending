using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;
using netPossionLib;
using System.IO;

namespace ImageBlending
{
    public partial class FrmMain : Form
    {
        const int CMD_INIT = 0;
        const int CMD_START_BLEND = 1;
        class WorkerCmd
        {
            public int cmd;

            public MWNumericArray boxArr;
            public MWNumericArray posArr;
            public MWCharArray ImageSrc;
            public MWCharArray ImageDst;
            public MWCharArray ImageMask;
            public MWCharArray ImageSave;
        }
        public FrmMain()
        {
            InitializeComponent();
            this.threadWorker.RunWorkerAsync();
            strMaskTmpPath = Path.Combine(Application.StartupPath, "imageMask.jpg");
        }
        netPossionLib.PossionBlending blend;
        private WorkerCmd cmd;
        public readonly static string strSrcImagePath = Path.Combine(Application.StartupPath, "imageSrc.jpg");
        public static string strMaskTmpPath;
        frmSource src;
        frmDest dst;
        static public string srcImage;
        string dstImage;
        private void btnSrc_Click(object sender, EventArgs e)
        {
            if (dlgSelFile.ShowDialog() == DialogResult.OK)
            {
                srcImage = dlgSelFile.FileName;
                src = new frmSource();
                src.Show();
                src.LoadImage(srcImage);
            }
        }

        private void btnDst_Click(object sender, EventArgs e)
        {
            if (dlgSelFile.ShowDialog() == DialogResult.OK)
            {
                dstImage = dlgSelFile.FileName;
                dst = new frmDest();
                dst.Show();
                dst.SetImage(dstImage, src.imageRegionSel);
            }
        }

        public void Zoom()
        {
            //生成控制命令
            double []BoxSrc=src.BoxSrc;
            
            cmd.posArr = dst.posDest;
            cmd.ImageDst = dstImage;
            cmd.ImageSave = dlgSaveFile.FileName;
            cmd.cmd = CMD_START_BLEND;


            //对Mask Zoom
            Image img = Image.FromFile(FrmMain.strMaskTmpPath);
            Size szOrg = img.Size;

            double ZoomRate = dst.ZoomRate;
            Size szNew = new Size(
                Convert.ToInt32(szOrg.Width * ZoomRate),
                Convert.ToInt32(szOrg.Height * ZoomRate));
            Bitmap bmp = new Bitmap(img, szNew);
            img.Dispose();
            bmp.Save(FrmMain.strMaskTmpPath);
            cmd.ImageMask = strMaskTmpPath;

            //对Source Zoom
            //由于.net bug 一定要先将文件拷贝到别处，然后再处理resize
            //否则image会锁住这个文件，保存时会报GNENEC ERROR
            Image img2 = Image.FromFile(FrmMain.srcImage);
            szOrg = img2.Size;

            szNew = new Size(
                Convert.ToInt32(szOrg.Width * ZoomRate),
                Convert.ToInt32(szOrg.Height * ZoomRate));
            Bitmap bmp2 = new Bitmap(img2, szNew);
            img2.Dispose();
            bmp2.Save(FrmMain.strSrcImagePath);
            FrmMain.srcImage = FrmMain.strSrcImagePath;
            cmd.ImageSrc = srcImage;
            
            //还得对source的起始点做Zoom
            for (int i = 0; i < BoxSrc.Length; i++)
            {
                BoxSrc[i] = Math.Floor(BoxSrc[i]*ZoomRate);
            }
            cmd.boxArr = BoxSrc;


        }
        private void btnBlend_Click(object sender, EventArgs e)
        {
            if (dlgSaveFile.ShowDialog() == DialogResult.OK)
            {
                Zoom();
                this.threadWorker.RunWorkerAsync(cmd);
            }
        }

        private void threadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null)
            {
                blend = new PossionBlending();
                cmd = new WorkerCmd();
            }
            WorkerCmd arg = e.Argument as WorkerCmd;
            if (arg != null)
            {
                if (arg.cmd == CMD_START_BLEND)
                {
                    blend.BlendImage(
                        arg.ImageSrc, arg.ImageDst, arg.ImageMask,
                        arg.ImageSave, arg.boxArr, arg.posArr);
                }
            }
        }

        private void threadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
