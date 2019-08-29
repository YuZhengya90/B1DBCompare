using ResultCompareUI.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResultCompareUI
{
    class RCComand
    {
        public static string[] Cmd(string exeQuery)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            p.StandardInput.WriteLine(exeQuery + "&exit");
            p.StandardInput.AutoFlush = true;
            
            string output = p.StandardOutput.ReadToEnd();

            var x = new List<string>();

            while (p.StandardOutput.Peek() > -1)
            {
                x.Add(p.StandardOutput.ReadLine());
            }

            while (p.StandardError.Peek() > -1)
            {
                x.Add(p.StandardError.ReadLine());
                
                string errMsg = MsgHandle(x.Last() + "    Internal Command = [" + exeQuery + "]", exeQuery);
                RCLogMessage.Instance().Log(errMsg);
            }

            p.WaitForExit();

            p.Close();

            //return output;
            return x.ToArray();
        }

        private static string MsgHandle(string errMsg, string exeQuery)
        {
            if (errMsg.Contains("record size ["))
            {
                string sampleSection = errMsg.Substring(0,errMsg.LastIndexOf(".RST"));
                string tableName = errMsg.Substring(sampleSection.LastIndexOf('_') + 1, sampleSection.Length - sampleSection.LastIndexOf('_') - 1);
                int x1 = sampleSection.IndexOf("L_") + 2;
                string leftNum = errMsg.Substring(x1, sampleSection.IndexOf("_", x1) - x1);
                int x2 = sampleSection.IndexOf("R_") + 2;
                string rightNum = errMsg.Substring(x2, sampleSection.IndexOf("_", x2) - x2);
                string leftRecNum = errMsg.Substring(13, errMsg.IndexOf(']') - 13);
                int startRightRecNum = errMsg.IndexOf("<> [") + 4;
                string rightRecNum = errMsg.Substring(startRightRecNum, errMsg.IndexOf("]", startRightRecNum) - startRightRecNum);

                string outStr = "TableName=[" + tableName + "] record count not matched; Left Key[" + leftNum + "] recNum=" + leftRecNum + "; Right Key[" + rightNum + "] recNum=" + rightRecNum;
                outStr += "    Internal Command = [" + exeQuery + "]";
                return outStr;
            }

            return errMsg;
        }
    }
}
