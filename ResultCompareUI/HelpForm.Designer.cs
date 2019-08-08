using System.IO;
namespace ResultCompareUI
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mTBReadMe = new System.Windows.Forms.TextBox();
            this.mBtnOK = new System.Windows.Forms.Button();
            this.mPBLogo = new System.Windows.Forms.PictureBox();
            this.mLBx64 = new System.Windows.Forms.Label();
            this.mLBVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mPBLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "SAP Business One Table Compare Tools";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "2019/07/03";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(296, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "This tool was build by B1 Development Team - BinGo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "All right reserved.";
            // 
            // mTBReadMe
            // 
            this.mTBReadMe.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mTBReadMe.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTBReadMe.Location = new System.Drawing.Point(31, 118);
            this.mTBReadMe.Multiline = true;
            this.mTBReadMe.Name = "mTBReadMe";
            this.mTBReadMe.ReadOnly = true;
            this.mTBReadMe.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mTBReadMe.Size = new System.Drawing.Size(717, 381);
            this.mTBReadMe.TabIndex = 4;
            // 
            // mBtnOK
            // 
            this.mBtnOK.Location = new System.Drawing.Point(31, 522);
            this.mBtnOK.Name = "mBtnOK";
            this.mBtnOK.Size = new System.Drawing.Size(75, 23);
            this.mBtnOK.TabIndex = 5;
            this.mBtnOK.Text = "OK";
            this.mBtnOK.UseVisualStyleBackColor = true;
            this.mBtnOK.Click += new System.EventHandler(this.mBtnOK_Click);
            // 
            // mPBLogo
            // 
            this.mPBLogo.Image = ((System.Drawing.Image)(resources.GetObject("mPBLogo.Image")));
            this.mPBLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("mPBLogo.InitialImage")));
            this.mPBLogo.Location = new System.Drawing.Point(523, 37);
            this.mPBLogo.Name = "mPBLogo";
            this.mPBLogo.Size = new System.Drawing.Size(225, 50);
            this.mPBLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mPBLogo.TabIndex = 6;
            this.mPBLogo.TabStop = false;
            // 
            // mLBx64
            // 
            this.mLBx64.AutoSize = true;
            this.mLBx64.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mLBx64.Location = new System.Drawing.Point(180, 57);
            this.mLBx64.Name = "mLBx64";
            this.mLBx64.Size = new System.Drawing.Size(0, 15);
            this.mLBx64.TabIndex = 7;
            // 
            // mLBVersion
            // 
            this.mLBVersion.AutoSize = true;
            this.mLBVersion.Location = new System.Drawing.Point(107, 59);
            this.mLBVersion.Name = "mLBVersion";
            this.mLBVersion.Size = new System.Drawing.Size(0, 13);
            this.mLBVersion.TabIndex = 8;

            {
                this.mLBVersion.Text = "V" + File.ReadAllText(@"version.txt");
            }
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.mLBVersion);
            this.Controls.Add(this.mLBx64);
            this.Controls.Add(this.mPBLogo);
            this.Controls.Add(this.mBtnOK);
            this.Controls.Add(this.mTBReadMe);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "HelpForm";
            this.Text = "Help";
            this.Load += new System.EventHandler(this.HelpForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HelpForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.mPBLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mTBReadMe;
        private System.Windows.Forms.Button mBtnOK;
        private System.Windows.Forms.PictureBox mPBLogo;
        private System.Windows.Forms.Label mLBx64;
        private System.Windows.Forms.Label mLBVersion;
    }
}