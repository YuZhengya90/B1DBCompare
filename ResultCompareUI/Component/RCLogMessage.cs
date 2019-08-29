using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResultCompareUI.Component
{
    class RCLogMessage
    {
        private static RCLogMessage instance;
        private ListBox mLB;
        public static RCLogMessage Instance()
        {
            if (instance == null)
            {
                instance = new RCLogMessage();
            }
            return instance;
        }

        public void SetBox(ListBox lb)
        {
            mLB = lb;
        }

        public void Log(string msg)
        {
            mLB.Items.Add(msg);
        }

        private void BeautifyLog(string msg)
        {
        }
    }
}
