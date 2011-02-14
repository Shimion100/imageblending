namespace ImageBlending
{
    partial class frmSource
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
            this.imgSrc = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgSrc)).BeginInit();
            this.SuspendLayout();
            // 
            // imgSrc
            // 
            this.imgSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgSrc.Location = new System.Drawing.Point(0, 0);
            this.imgSrc.Name = "imgSrc";
            this.imgSrc.Size = new System.Drawing.Size(551, 347);
            this.imgSrc.TabIndex = 1;
            this.imgSrc.TabStop = false;
            this.imgSrc.Paint += new System.Windows.Forms.PaintEventHandler(this.imgSrc_Paint);
            this.imgSrc.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imgSrc_MouseClick);
            this.imgSrc.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.imgSrc_MouseDoubleClick);
            // 
            // frmSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 347);
            this.Controls.Add(this.imgSrc);
            this.Name = "frmSource";
            this.Text = "frmSource";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSource_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSource_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSource_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.imgSrc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgSrc;


    }
}