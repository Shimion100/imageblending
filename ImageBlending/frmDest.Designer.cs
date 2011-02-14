namespace ImageBlending
{
    partial class frmDest
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.imageRegional = new System.Windows.Forms.PictureBox();
            this.imageDst = new System.Windows.Forms.PictureBox();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageRegional)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageDst)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.imageRegional);
            this.splitContainer1.Panel1.Controls.Add(this.imageDst);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnOk);
            this.splitContainer1.Panel2.Controls.Add(this.btnZoomIn);
            this.splitContainer1.Panel2.Controls.Add(this.btnZoomOut);
            this.splitContainer1.Size = new System.Drawing.Size(443, 426);
            this.splitContainer1.SplitterDistance = 316;
            this.splitContainer1.TabIndex = 0;
            // 
            // imageRegional
            // 
            this.imageRegional.BackColor = System.Drawing.Color.Transparent;
            this.imageRegional.Location = new System.Drawing.Point(12, 12);
            this.imageRegional.Name = "imageRegional";
            this.imageRegional.Size = new System.Drawing.Size(132, 106);
            this.imageRegional.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageRegional.TabIndex = 1;
            this.imageRegional.TabStop = false;
            this.imageRegional.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageRegional_MouseDown);
            this.imageRegional.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageRegional_MouseMove);
            this.imageRegional.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageRegional_MouseUp);
            // 
            // imageDst
            // 
            this.imageDst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageDst.Location = new System.Drawing.Point(0, 0);
            this.imageDst.Name = "imageDst";
            this.imageDst.Size = new System.Drawing.Size(316, 426);
            this.imageDst.TabIndex = 0;
            this.imageDst.TabStop = false;
            this.imageDst.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageDst_MouseMove);
            this.imageDst.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageDst_MouseUp);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Location = new System.Drawing.Point(12, 12);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(75, 23);
            this.btnZoomOut.TabIndex = 0;
            this.btnZoomOut.Text = "Zoom Out";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Location = new System.Drawing.Point(12, 41);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(75, 23);
            this.btnZoomIn.TabIndex = 0;
            this.btnZoomIn.Text = "Zoom In";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(12, 70);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmDest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 426);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmDest";
            this.Text = "frmDest";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageRegional)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageDst)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox imageRegional;
        private System.Windows.Forms.PictureBox imageDst;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnOk;
    }
}