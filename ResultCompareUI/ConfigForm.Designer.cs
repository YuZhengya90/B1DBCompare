namespace ResultCompareUI
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.label10 = new System.Windows.Forms.Label();
            this.mTBTimeout = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.mTBSchema = new System.Windows.Forms.TextBox();
            this.mTBPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mTBUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mTBIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mRBMSSQL = new System.Windows.Forms.RadioButton();
            this.mRBHANA = new System.Windows.Forms.RadioButton();
            this.mTBDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mBtnSave = new System.Windows.Forms.Button();
            this.mBtnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.mTBExePath = new System.Windows.Forms.TextBox();
            this.mBtnBrz = new System.Windows.Forms.Button();
            this.mCBConfigName = new System.Windows.Forms.ComboBox();
            this.mBtnNew = new System.Windows.Forms.Button();
            this.mBtnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(212, 223);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 50;
            this.label10.Text = "ms";
            // 
            // mTBTimeout
            // 
            this.mTBTimeout.Location = new System.Drawing.Point(164, 220);
            this.mTBTimeout.Name = "mTBTimeout";
            this.mTBTimeout.Size = new System.Drawing.Size(42, 20);
            this.mTBTimeout.TabIndex = 90;
            this.mTBTimeout.Text = "3000";
            this.mTBTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mTBTimeout.TextChanged += new System.EventHandler(this.mTBTimeout_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 223);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 13);
            this.label9.TabIndex = 48;
            this.label9.Text = "Database Connection Timeout";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Schema";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mTBSchema
            // 
            this.mTBSchema.Location = new System.Drawing.Point(63, 184);
            this.mTBSchema.Name = "mTBSchema";
            this.mTBSchema.Size = new System.Drawing.Size(169, 20);
            this.mTBSchema.TabIndex = 60;
            this.mTBSchema.TextChanged += new System.EventHandler(this.mTBSchema_TextChanged);
            // 
            // mTBPassword
            // 
            this.mTBPassword.Location = new System.Drawing.Point(302, 184);
            this.mTBPassword.Name = "mTBPassword";
            this.mTBPassword.Size = new System.Drawing.Size(169, 20);
            this.mTBPassword.TabIndex = 80;
            this.mTBPassword.TextChanged += new System.EventHandler(this.mTBPassword_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(247, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "Password";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mTBUserName
            // 
            this.mTBUserName.Location = new System.Drawing.Point(302, 155);
            this.mTBUserName.Name = "mTBUserName";
            this.mTBUserName.Size = new System.Drawing.Size(169, 20);
            this.mTBUserName.TabIndex = 70;
            this.mTBUserName.TextChanged += new System.EventHandler(this.mTBUserName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "User ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mTBIP
            // 
            this.mTBIP.Location = new System.Drawing.Point(63, 155);
            this.mTBIP.Name = "mTBIP";
            this.mTBIP.Size = new System.Drawing.Size(169, 20);
            this.mTBIP.TabIndex = 50;
            this.mTBIP.TextChanged += new System.EventHandler(this.mTBIP_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "IP:Port ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Configuration Name";
            // 
            // mRBMSSQL
            // 
            this.mRBMSSQL.AutoSize = true;
            this.mRBMSSQL.Enabled = false;
            this.mRBMSSQL.Location = new System.Drawing.Point(12, 116);
            this.mRBMSSQL.Name = "mRBMSSQL";
            this.mRBMSSQL.Size = new System.Drawing.Size(62, 17);
            this.mRBMSSQL.TabIndex = 30;
            this.mRBMSSQL.TabStop = true;
            this.mRBMSSQL.Text = "MSSQL";
            this.mRBMSSQL.UseVisualStyleBackColor = true;
            this.mRBMSSQL.Click += new System.EventHandler(this.mRadioMSSQL_Click);
            // 
            // mRBHANA
            // 
            this.mRBHANA.AutoSize = true;
            this.mRBHANA.Location = new System.Drawing.Point(80, 116);
            this.mRBHANA.Name = "mRBHANA";
            this.mRBHANA.Size = new System.Drawing.Size(55, 17);
            this.mRBHANA.TabIndex = 40;
            this.mRBHANA.TabStop = true;
            this.mRBHANA.Text = "HANA";
            this.mRBHANA.UseVisualStyleBackColor = true;
            this.mRBHANA.CheckedChanged += new System.EventHandler(this.mRBHANA_CheckedChanged);
            this.mRBHANA.Click += new System.EventHandler(this.mRadioHANA_Click);
            // 
            // mTBDesc
            // 
            this.mTBDesc.Location = new System.Drawing.Point(140, 38);
            this.mTBDesc.Multiline = true;
            this.mTBDesc.Name = "mTBDesc";
            this.mTBDesc.Size = new System.Drawing.Size(331, 59);
            this.mTBDesc.TabIndex = 20;
            this.mTBDesc.TextChanged += new System.EventHandler(this.mTBDesc_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 13);
            this.label4.TabIndex = 56;
            this.label4.Text = "Configuration Description";
            // 
            // mBtnSave
            // 
            this.mBtnSave.Location = new System.Drawing.Point(13, 304);
            this.mBtnSave.Name = "mBtnSave";
            this.mBtnSave.Size = new System.Drawing.Size(75, 23);
            this.mBtnSave.TabIndex = 200;
            this.mBtnSave.Text = "OK";
            this.mBtnSave.UseVisualStyleBackColor = true;
            this.mBtnSave.Click += new System.EventHandler(this.mButtonSave_Click);
            // 
            // mBtnCancel
            // 
            this.mBtnCancel.Location = new System.Drawing.Point(95, 304);
            this.mBtnCancel.Name = "mBtnCancel";
            this.mBtnCancel.Size = new System.Drawing.Size(75, 23);
            this.mBtnCancel.TabIndex = 201;
            this.mBtnCancel.Text = "CANCEL";
            this.mBtnCancel.UseVisualStyleBackColor = true;
            this.mBtnCancel.Click += new System.EventHandler(this.mButtonCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 202;
            this.label5.Text = "DB Client File";
            // 
            // mTBExePath
            // 
            this.mTBExePath.Location = new System.Drawing.Point(89, 253);
            this.mTBExePath.Name = "mTBExePath";
            this.mTBExePath.Size = new System.Drawing.Size(299, 20);
            this.mTBExePath.TabIndex = 203;
            this.mTBExePath.Text = "C:\\Program Files (x86)\\SAP\\hdbclient\\hdbsql.exe";
            this.mTBExePath.TextChanged += new System.EventHandler(this.mTBExePath_TextChanged);
            // 
            // mBtnBrz
            // 
            this.mBtnBrz.Location = new System.Drawing.Point(396, 252);
            this.mBtnBrz.Name = "mBtnBrz";
            this.mBtnBrz.Size = new System.Drawing.Size(75, 23);
            this.mBtnBrz.TabIndex = 204;
            this.mBtnBrz.Text = "Browse";
            this.mBtnBrz.UseVisualStyleBackColor = true;
            this.mBtnBrz.Click += new System.EventHandler(this.mBtnBrz_Click);
            // 
            // mCBConfigName
            // 
            this.mCBConfigName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mCBConfigName.FormattingEnabled = true;
            this.mCBConfigName.Location = new System.Drawing.Point(140, 11);
            this.mCBConfigName.Name = "mCBConfigName";
            this.mCBConfigName.Size = new System.Drawing.Size(331, 21);
            this.mCBConfigName.TabIndex = 205;
            this.mCBConfigName.SelectedIndexChanged += new System.EventHandler(this.mCBConfigName_SelectedIndexChanged);
            // 
            // mBtnNew
            // 
            this.mBtnNew.Location = new System.Drawing.Point(176, 304);
            this.mBtnNew.Name = "mBtnNew";
            this.mBtnNew.Size = new System.Drawing.Size(75, 23);
            this.mBtnNew.TabIndex = 206;
            this.mBtnNew.Text = "NEW";
            this.mBtnNew.UseVisualStyleBackColor = true;
            this.mBtnNew.Click += new System.EventHandler(this.mBtnNew_Click);
            // 
            // mBtnDelete
            // 
            this.mBtnDelete.Location = new System.Drawing.Point(257, 304);
            this.mBtnDelete.Name = "mBtnDelete";
            this.mBtnDelete.Size = new System.Drawing.Size(75, 23);
            this.mBtnDelete.TabIndex = 207;
            this.mBtnDelete.Text = "DELETE";
            this.mBtnDelete.UseVisualStyleBackColor = true;
            this.mBtnDelete.Click += new System.EventHandler(this.mBtnDelete_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(496, 345);
            this.Controls.Add(this.mBtnDelete);
            this.Controls.Add(this.mBtnNew);
            this.Controls.Add(this.mCBConfigName);
            this.Controls.Add(this.mBtnBrz);
            this.Controls.Add(this.mTBExePath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mBtnCancel);
            this.Controls.Add(this.mBtnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mTBDesc);
            this.Controls.Add(this.mRBHANA);
            this.Controls.Add(this.mRBMSSQL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.mTBTimeout);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.mTBSchema);
            this.Controls.Add(this.mTBPassword);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.mTBUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mTBIP);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ConfigForm";
            this.Text = "SAP Business One Table Compare - Configuration";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConfigForm_FormClosed);
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConfigForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox mTBTimeout;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox mTBSchema;
        private System.Windows.Forms.TextBox mTBPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox mTBUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mTBIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton mRBMSSQL;
        private System.Windows.Forms.RadioButton mRBHANA;
        private System.Windows.Forms.TextBox mTBDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button mBtnSave;
        private System.Windows.Forms.Button mBtnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox mTBExePath;
        private System.Windows.Forms.Button mBtnBrz;
        private System.Windows.Forms.ComboBox mCBConfigName;
        private System.Windows.Forms.Button mBtnNew;
        private System.Windows.Forms.Button mBtnDelete;
    }
}