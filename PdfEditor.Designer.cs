﻿namespace PdfFormEditor
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
        //private void InitializeComponent()
        //{
        //    this.button1 = new System.Windows.Forms.Button();
        //    this.SuspendLayout();
        //    // 
        //    // button1
        //    // 
        //    this.button1.Location = new System.Drawing.Point(369, 278);
        //    this.button1.Name = "button1";
        //    this.button1.Size = new System.Drawing.Size(112, 34);
        //    this.button1.TabIndex = 0;
        //    this.button1.Text = "button1";
        //    this.button1.UseVisualStyleBackColor = true;
        //    // 
        //    // Form1
        //    // 
        //    this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.ClientSize = new System.Drawing.Size(800, 450);
        //    this.Controls.Add(this.button1);
        //    this.Name = "Form1";
        //    this.Text = "Form1";
        //    this.ResumeLayout(false);

        //}

        //#endregion

        //private Button button1;

        private void InitializeComponent()
        {
            this.AddPage = new System.Windows.Forms.Button();
            this.documentImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.documentImage)).BeginInit();
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
            // documentImage
            // 
            this.documentImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentImage.Location = new System.Drawing.Point(251, 45);
            this.documentImage.Name = "documentImage";
            this.documentImage.Size = new System.Drawing.Size(769, 619);
            this.documentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.documentImage.TabIndex = 2;
            this.documentImage.TabStop = false;
            // 
            // PdfEditor
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1214, 796);
            this.Controls.Add(this.AddPage);
            this.Controls.Add(this.documentImage);
            this.Name = "PdfEditor";
            ((System.ComponentModel.ISupportInitialize)(this.documentImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button AddPage;
        private PictureBox documentImage;
    }
}