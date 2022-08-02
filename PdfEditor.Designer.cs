namespace PdfFormEditor
{
    partial class PdfEditor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddPage = new System.Windows.Forms.Button();
            this.DocumentImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentImage)).BeginInit();
            this.SuspendLayout();
            // 
            // AddPage
            // 
            this.AddPage.Location = new System.Drawing.Point(555, 715);
            this.AddPage.Name = "AddPage";
            this.AddPage.Size = new System.Drawing.Size(112, 34);
            this.AddPage.TabIndex = 1;
            this.AddPage.Text = "Add Page";
            this.AddPage.UseVisualStyleBackColor = true;
            this.AddPage.Click += new System.EventHandler(this.AddPage_Click);
            // 
            // DocumentImage
            // 
            this.DocumentImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DocumentImage.Location = new System.Drawing.Point(251, 45);
            this.DocumentImage.Name = "DocumentImage";
            this.DocumentImage.Size = new System.Drawing.Size(769, 619);
            this.DocumentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.DocumentImage.TabIndex = 2;
            this.DocumentImage.TabStop = false;
            // 
            // PdfEditor
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1214, 796);
            this.Controls.Add(this.AddPage);
            this.Controls.Add(this.DocumentImage);
            this.Name = "PdfEditor";
            ((System.ComponentModel.ISupportInitialize)(this.DocumentImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button AddPage;
        private PictureBox DocumentImage;
    }
}