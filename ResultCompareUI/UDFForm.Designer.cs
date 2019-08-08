namespace ResultCompareUI
{
    partial class UDFForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UDFForm));
            this.mTBQuery1 = new System.Windows.Forms.TextBox();
            this.mTBQuery2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mBtnClr1 = new System.Windows.Forms.Button();
            this.mBtnClr2 = new System.Windows.Forms.Button();
            this.mBtnCompare = new System.Windows.Forms.Button();
            this.mBtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mTBQuery1
            // 
            this.mTBQuery1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTBQuery1.Location = new System.Drawing.Point(12, 69);
            this.mTBQuery1.Multiline = true;
            this.mTBQuery1.Name = "mTBQuery1";
            this.mTBQuery1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mTBQuery1.Size = new System.Drawing.Size(984, 229);
            this.mTBQuery1.TabIndex = 0;
            // 
            // mTBQuery2
            // 
            this.mTBQuery2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTBQuery2.Location = new System.Drawing.Point(12, 373);
            this.mTBQuery2.Multiline = true;
            this.mTBQuery2.Name = "mTBQuery2";
            this.mTBQuery2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mTBQuery2.Size = new System.Drawing.Size(984, 229);
            this.mTBQuery2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Query 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 354);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Query 2";
            // 
            // mBtnClr1
            // 
            this.mBtnClr1.Location = new System.Drawing.Point(12, 304);
            this.mBtnClr1.Name = "mBtnClr1";
            this.mBtnClr1.Size = new System.Drawing.Size(90, 23);
            this.mBtnClr1.TabIndex = 4;
            this.mBtnClr1.Text = "Clear";
            this.mBtnClr1.UseVisualStyleBackColor = true;
            this.mBtnClr1.Click += new System.EventHandler(this.mBtnClr1_Click);
            // 
            // mBtnClr2
            // 
            this.mBtnClr2.Location = new System.Drawing.Point(12, 608);
            this.mBtnClr2.Name = "mBtnClr2";
            this.mBtnClr2.Size = new System.Drawing.Size(90, 23);
            this.mBtnClr2.TabIndex = 6;
            this.mBtnClr2.Text = "Clear";
            this.mBtnClr2.UseVisualStyleBackColor = true;
            this.mBtnClr2.Click += new System.EventHandler(this.mBtnClr2_Click);
            // 
            // mBtnCompare
            // 
            this.mBtnCompare.Location = new System.Drawing.Point(12, 694);
            this.mBtnCompare.Name = "mBtnCompare";
            this.mBtnCompare.Size = new System.Drawing.Size(90, 23);
            this.mBtnCompare.TabIndex = 8;
            this.mBtnCompare.Text = "Compare";
            this.mBtnCompare.UseVisualStyleBackColor = true;
            this.mBtnCompare.Click += new System.EventHandler(this.mBtnCompare_Click);
            // 
            // mBtnCancel
            // 
            this.mBtnCancel.Location = new System.Drawing.Point(108, 694);
            this.mBtnCancel.Name = "mBtnCancel";
            this.mBtnCancel.Size = new System.Drawing.Size(90, 23);
            this.mBtnCancel.TabIndex = 9;
            this.mBtnCancel.Text = "Cancel";
            this.mBtnCancel.UseVisualStyleBackColor = true;
            this.mBtnCancel.Click += new System.EventHandler(this.mBtnCancel_Click);
            // 
            // UDFForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.mBtnCancel);
            this.Controls.Add(this.mBtnCompare);
            this.Controls.Add(this.mBtnClr2);
            this.Controls.Add(this.mBtnClr1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mTBQuery2);
            this.Controls.Add(this.mTBQuery1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UDFForm";
            this.Text = "Advanced Compare";
            this.Load += new System.EventHandler(this.UDFForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mTBQuery1;
        private System.Windows.Forms.TextBox mTBQuery2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button mBtnClr1;
        private System.Windows.Forms.Button mBtnClr2;
        private System.Windows.Forms.Button mBtnCompare;
        private System.Windows.Forms.Button mBtnCancel;
    }
}