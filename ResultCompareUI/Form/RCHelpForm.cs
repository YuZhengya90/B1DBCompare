using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResultCompareUI
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void mBtnOK_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            LoadReadme();
            LoadX64();
        }

        private void LoadX64()
        {
            mLBx64.Text = Environment.Is64BitProcess ? "(x64)" : "(x86)";
        }

        private void LoadReadme()
        {
            StreamReader sr = new StreamReader(".\\help\\readme.txt");
            try
            {
                //string content = sr.ReadToEnd();
                //mTextBox.Lines = content.Split("\r\n".ToCharArray()).ToArray();
                string line = "";
                List<string> content = new List<string>();
                while((line = sr.ReadLine()) != null)
                {
                    content.Add(line);
                }

                mTBReadMe.Lines = content.ToArray();
                mTBReadMe.Select(0,0);
            }
            catch(Exception)
            {
            }

            finally
            {
                sr.Close();
            }
        }

        private void HelpForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                mBtnOK_Click(null, null);
            }
        }
    }
}
