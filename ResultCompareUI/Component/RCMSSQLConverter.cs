using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultCompareUI
{
    class RCMSSQLConverter
    {
        

        // 
        // sqlcmd -S PVGD50934627A\MSSQLSERVER2016 -U sa -P SAPB1Admin -d 121397 -i C:\.. -o C:\... -k1
        // second line for separate
        // number -> original  alpha -> ""
        // ,,,
        // 
        public static bool Convert(string filePath)
        {
            string newContent = "";
            using (StreamReader sr = new StreamReader(filePath))
            {
                string fileContent = sr.ReadToEnd();
                List<String> fileLines = fileContent.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                int recSize = 0;
                for (int i = 0; i < fileLines.Count; ++ i )
                {
                    if (fileLines[i].Contains("rows affected"))
                    {
                        int posOfBlank = fileLines[i].IndexOf(" ");
                        recSize = int.Parse(fileLines[i].Substring(1, posOfBlank));
                        if (recSize != i - 2)
                        {
                            return false;
                        }
                    }
                }

                if (fileLines.Count >= 2)
                {
                    List<string> sepStrList = fileLines[1].Split(" ".ToCharArray()).ToList();
                    List<int> lengthArr = new List<int>();
                    for (int i = 0; i < sepStrList.Count; ++i)
                    {
                        lengthArr.Add(sepStrList[i].Length);
                    }

                    newContent = SeparateByLengthArray(fileLines[0], lengthArr, true);
                    for (int i = 0; i < recSize; ++i)
                    {
                        newContent += "\r\n";
                        newContent += SeparateByLengthArray(fileLines[i + 2], lengthArr) + "\r\n";
                    }
                }
            }

            File.WriteAllText(filePath, newContent);

            return true;
        }

        private static string SeparateByLengthArray(string strLines, List<int> lengthArr, bool header = false)
        {
            List<string> outStrList = new List<string>();
            int start = 0;
            for (int i = 0; i< lengthArr.Count ; ++i)
            {
                if (header)
                {
                    outStrList.Add(strLines.Substring(start, lengthArr[i]).Trim());
                }
                else
                {
                    outStrList.Add(SetQuotoIfString(strLines.Substring(start, lengthArr[i]).Trim()));
                }
                
                start += lengthArr[i] + 1; // blank .
            }
            string outStr = "";
            for (int i = 0; i < outStrList.Count; ++i)
            {
                outStr += outStrList[i] + ",";
            }
            outStr = outStr.Substring(0, outStr.Length - 1);
            return outStr;
        }

        // set quoto {Except Number NULL ..}
        // add 0 in front of .x(number with dot)
        private static string SetQuotoIfString(string sample)
        {
            System.Text.RegularExpressions.Regex rex = new System.Text.RegularExpressions.Regex(@"^[+-]?\d*[.]?\d*$");
            if (sample != "" && rex.IsMatch(sample))
            {
                if (sample.StartsWith("."))
                {
                    return "0" + sample;
                }
                else
                {
                    return sample;
                }
            }
            else if (sample == "NULL")
            {
                return sample;
            }
            else
            {
                return "\"" + sample + "\"";
            }
        }
    }
}
