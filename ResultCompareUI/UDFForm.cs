using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResultCompareUI
{
    public partial class UDFForm : Form
    {
        public UDFForm()
        {
            InitializeComponent();
        }

        private void mBtnCompare_Click(object sender, EventArgs e)
        {
            MainForm mf = this.Owner as MainForm;
            mf.SetUDFCompareQueries(mTBQuery1.Text, mTBQuery2.Text);
            this.Dispose();
        }

        private void mBtnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void UDFForm_Load(object sender, EventArgs e)
        {
            MainForm mf = this.Owner as MainForm;
            if (mf.udfCompareQuery1 != "")
            {
                mTBQuery1.Text = mf.udfCompareQuery1;
            }
            if (mf.udfCompareQuery2 != "")
            {
                mTBQuery2.Text = mf.udfCompareQuery2;
            }
        }

        private void mBtnClr1_Click(object sender, EventArgs e)
        {
            mTBQuery1.Text = "";
        }

        private void mBtnClr2_Click(object sender, EventArgs e)
        {
            mTBQuery2.Text = "";
        }
    }
}
