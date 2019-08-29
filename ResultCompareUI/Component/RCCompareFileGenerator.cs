using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultCompareUI.Component
{
    class ResGroup
    {
        public string name = "";
        public List<string> columns = new List<string>();
        public List<List<string>> colValues = new List<List<string>>();
        public bool isValid() {
            if (colValues.Count != 0)
                return colValues[0].Count == columns.Count;
            return columns.Count != 0;
        }

        public void clear()
        {
            columns.Clear(); colValues.Clear();
        }

        public int size()
        {
            return isValid() ? columns.Count : 0;
        }
    }

    class IgnoreList
    {
        public List<string> igColumns;
        public bool HasValue(string s)
        {
            foreach(var it in igColumns)
            {
                if (it == s)
                    return true;
            }
            return false;
        }
    }

    class CompareUnit
    {
        public string col;
        public Dictionary<int, string> vecStr1 = new Dictionary<int,string>();
        public Dictionary<int, string> vecStr2 = new Dictionary<int,string>();
        public CompareUnit(string c) { col = c; }
        public int length()
        {
            int maxLen = col.Length;
            for (int i = 0; i < vecStr1.Count; ++i)
            {
                if (vecStr1[i].Length > maxLen) maxLen = vecStr1[i].Length;
                if (vecStr2[i].Length > maxLen) maxLen = vecStr2[i].Length;
            }
            return maxLen;
        }

        public int thick()
        {
            return vecStr1.Count;
        }
    }

    class CompareGroup
    {
        public List<CompareUnit> comKeys = new List<CompareUnit>();
        public List<CompareUnit> comUnits = new List<CompareUnit>();
        public int thick()
        {
            int maxThick = 0;
            for (int i = 0; i < comUnits.Count; ++i)
            {
                if (maxThick < comUnits[i].thick())
                    maxThick = comUnits[i].thick();
            }
            return maxThick;
        }

        public CompareUnit getColUnit(string c)
        {
            for (int i = 0; i < comUnits.Count; ++i)
            {
                if (comUnits[i].col == c) return comUnits[i];
            }
            return null;
        }

        public CompareUnit getColKey(string c)
        {
            for (int i = 0; i < comUnits.Count; ++i)
            {
                if (comUnits[i].col == c) return comKeys[i];
            }
            return null;
        }
    }

    class RCCompareFileGenenrator
    {
        public void GenerateOFile(string leftFilePath, string rightFilePath, string ignoreCols, string keyCols, string outFilePath)
        {
            string leftFile = "";
            using (StreamReader sr = new StreamReader(leftFilePath, Encoding.UTF8))
            {
                leftFile = sr.ReadToEnd();
            }

            string rightFile = "";
            using (StreamReader sr = new StreamReader(rightFilePath, Encoding.UTF8))
            {
                rightFile = sr.ReadToEnd();
            }

            ResGroup resGroup1 = GenerateResGroup(leftFile);
            resGroup1.name = getNameAndKey(leftFilePath);
            ResGroup resGroup2 = GenerateResGroup(rightFile);
            resGroup2.name = getNameAndKey(rightFilePath);
            IgnoreList igList = GenerateIgnoreList(ignoreCols);

            // todo
            CompareGroup comGroup = CompareResult(resGroup1, resGroup2, igList, keyCols);
            string outStr = ConvertCompareGroup(comGroup);
            File.WriteAllText(outFilePath, outStr, Encoding.UTF8);
        }

        private ResGroup GenerateResGroup(string file)
        {
            ResGroup resGroup = new ResGroup();
            string strColumns = "";
            List<string> strColValues = new List<string>();

            int PEOL = 0;
            int EOL = file.IndexOf("\r\n");
            while (EOL != -1)
            {
                if (strColumns == "")
                {
                    strColumns = file.Substring(0, EOL + 2);
                }
                else
                {
                    strColValues.Add(file.Substring(PEOL + 2, EOL - PEOL - 2));
                }

                PEOL = EOL;
                EOL = file.IndexOf("\r\n", PEOL + 2);
            }

            resGroup.columns = strColumns.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var it in strColValues)
            {
                string str = "";
                List<string> lineValues = new List<string>();
                bool openBracket = false;
                for (int i = 0; i < it.Length; ++ i)
                {
                    string st = it;
                    if (st[i] == '"') openBracket = !openBracket;
                    if (st[i] == ',' && !openBracket)
                    {
                        lineValues.Add(str);
                        str = "";
                    }
                    else
                    {
                        str += st[i];
                    }
                }
                if (str != "")
                    lineValues.Add(str);
                resGroup.colValues.Add(lineValues);
            }

            return resGroup;
        }

        
        private IgnoreList GenerateIgnoreList(string fileContent)
        {
            IgnoreList igList = new IgnoreList();
            igList.igColumns = fileContent.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            return igList;
        }

        private CompareGroup CompareResult(ResGroup rsGroup1, ResGroup rsGroup2, IgnoreList igList, string comKeys)
        {
            CompareGroup comGroup = new CompareGroup();
            if (!rsGroup1.isValid() || !rsGroup2.isValid())
            {
                throw new Exception("resGroup Invalid");
            }

            if (rsGroup1.size() != rsGroup2.size())
            {
                throw new Exception("res1 && res2 size Invalid");
            }

            int szOfGroup = rsGroup1.size();
            for (int i = 0; i < szOfGroup; ++i )
            {
                if (rsGroup1.columns[i] != rsGroup1.columns[i])
                {
                    throw new Exception("columns not matched.");
                }
            }

            if (rsGroup1.colValues.Count != rsGroup2.colValues.Count)
            {
                string exMsg = "record size not match," + rsGroup1.name + "=" + rsGroup1.colValues.Count.ToString() + 
                    " is not equal to " + rsGroup2.name + "=" + rsGroup2.colValues.Count.ToString();
                throw new Exception(exMsg);
            }

            List<string> keys = comKeys.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < rsGroup1.colValues.Count; ++ i )
            {
                for (int j = 0; j < szOfGroup; ++j)
                {
                    if (comKeys != "")
                    {
                        foreach( var it in keys)
                        {
                            if (it == rsGroup1.columns[j])
                            {
                                CompareUnit ck = comGroup.getColKey(it);
                                if (ck == null)
                                {
                                    ck = new CompareUnit(it);
                                    comGroup.comKeys.Add(ck);
                                }

                                ck.vecStr1[i] = rsGroup1.colValues[i][j];
                                ck.vecStr2[i] = rsGroup2.colValues[i][j];
                            }
                        }
                    }

                    if (rsGroup1.colValues[i][j] == rsGroup2.colValues[i][j])
                    {
                        continue;
                    }

                    if (igList.HasValue(rsGroup1.columns[j]) &&
                        rsGroup1.colValues[i][j] != "" &&
                        rsGroup2.colValues[i][j] != "")
                    {
                        continue;
                    }

                    CompareUnit cu = comGroup.getColUnit(rsGroup1.columns[j]);
                    if (cu == null)
                    {
                        cu = new CompareUnit(rsGroup1.columns[j]);
                        comGroup.comUnits.Add(cu);
                    }

                    cu.vecStr1[i] = rsGroup1.colValues[i][j];
                    cu.vecStr2[i] = rsGroup2.colValues[i][j];

                }
            }

            return comGroup;
        }

        private string fill(string s, int sz)
        {
            string str = "";
            if (sz > s.Length)
            {
                int dis = sz - s.Length;
                for (int i = 0; i < dis; ++i)
                {
                    str += " ";
                }
            }
            str += s;
            return str;
        }

        private string getNameAndKey(string fileName)
        {
            try
            {
                if (!fileName.EndsWith("RST"))
                return "";
                else
                {
                    int le = fileName.LastIndexOf("\\");
                    int re = fileName.LastIndexOf("RST");
                    string simple = fileName.Substring(le + 1, re - le - 2);
                    List<string> infoList = simple.Split('_').ToList();
                    if (infoList.Count >= 3)
                    {
                        return infoList[2] + "[" + infoList[1] + "]";
                    }                
                }

            }
            catch(Exception)
            {

            }
            finally
            {
                
            }
            return "";
        }

        private string ConvertCompareGroup(CompareGroup comGroup)
        {
            int thick = comGroup.thick();

            string colKeys = "";
            List<string> vecKeyValue1 = new List<string>();
            List<string> vecKeyValue2 = new List<string>();

            string columns = "";
            List<string> vecValue1 = new List<string>();
            List<string> vecValue2 = new List<string>();

            for (int i = 0; i < thick; ++i)
            {
                vecKeyValue1.Add("");
                vecKeyValue2.Add("");
                vecValue1.Add("");
                vecValue2.Add("");
            }

            foreach (var it in comGroup.comKeys)
            {
                if (colKeys != "")
                {
                    colKeys += ",";
                }
                colKeys += fill(it.col, it.length());

                for (int i = 0; i < thick; ++i)
                {
                    if (vecKeyValue1[i] != "")
                    {
                        vecKeyValue1[i] += ",";
                    }
                    vecKeyValue1[i] += fill(it.vecStr1[i], it.length());

                    if (vecKeyValue2[i] != "")
                    {
                        vecKeyValue2[i] += ",";
                    }
                    vecKeyValue2[i] += fill(it.vecStr2[i], it.length());
                }
            }

            foreach ( var it in comGroup.comUnits)
            {
                columns += fill(it.col, it.length());
                columns += ",";

                for (int i = 0; i < thick; ++i)
                {
                    vecValue1[i] += fill(it.vecStr1[i], it.length());
                    vecValue1[i] += ",";
                    vecValue2[i] += fill(it.vecStr2[i], it.length());
                    vecValue2[i] += ",";
                }
            }

            if (columns == "")
            {
                return "";
            }

            string str = colKeys + ";" + columns + "\r\n";
            for (int i = 0; i < vecValue1.Count; ++i)
            {
                str += vecKeyValue1[i] + ";" + vecValue1[i] + "\r\n";
                str += vecKeyValue2[i] + ";" + vecValue2[i] + "\r\n";
            }

            return str;
        }
    }
}
