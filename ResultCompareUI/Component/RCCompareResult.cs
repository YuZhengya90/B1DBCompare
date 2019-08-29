using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultCompareUI
{
    class CompareTable
    {
        public string docName {get;set;}
        public string docCols {get; set;}
        public List<string> docValues {get;set;}

        public List<List<string>> formatedColsAndValues;
        public List<List<int>> formatedColsAndValuesType;

        public const int TableName = 0;
        public const int TableKey = 1;
        public const int TableHeader = 2;
        public const int TableEmpty = 3;
        public const int TableKeyValue = 4;
        public const int TableValue = 5;

        public CompareTable(string name)
        {
            docName = name;
            docValues = new List<string>();
            formatedColsAndValues = new List<List<string>>();
            formatedColsAndValuesType = new List<List<int>>();
            docCols = "";
        }

        public bool IsEmpty()
        {
            return docCols.Length == 0;
        }

        public List<string> GetDocKeys()
        {
            List<string> keys = new List<string>();
            List<string> parts = docCols.Split(';').ToList();
            if (parts.Count != 0)
            {
                keys = parts[0].Split(',').ToList();
            }

            return keys;
        }

        public List<string> GetDocColumns()
        {
            List<string> cols = new List<string>();
            List<string> parts = docCols.Split(';').ToList();
            if (parts.Count > 1)
            {
                cols = parts[1].Split(',').ToList();
            }

            return cols;
        }

        public List<string> GetDocKeysValue(int r)
        {
            List<string> keyValue = new List<string>();
            if (r < docValues.Count)
            {
                List<string> parts = docValues[r].Split(';').ToList();
                if (parts.Count != 0)
                {
                    keyValue = parts[0].Split(',').ToList();
                    keyValue = FormatAddrWithComma(keyValue);
                }
            }

            return keyValue;
        }

        public List<List<string>> GetDocKeysValues()
        {
            List<List<string>> keyValuesGroup = new List<List<string>>();
            foreach (var val in docValues)
            {
                List<string> keyValues = new List<string>();
                List<string> parts = val.Split(';').ToList();
                if (parts.Count != 0)
                {
                    keyValues = parts[0].Split(',').ToList();
                    keyValuesGroup.Add(FormatAddrWithComma(keyValues));
                }               
            }

            return keyValuesGroup;
        }

        public List<string> GetDocColumnsValue(int r)
        {
            List<string> colValue = new List<string>();
            if (r < docValues.Count)
            {
                List<string> parts = docValues[r].Split(';').ToList();
                if (parts.Count > 1)
                {
                    colValue = parts[1].Split(',').ToList();
                    colValue = FormatAddrWithComma(colValue);
                }
            }

            return colValue;
        }

        public List<List<string>> GetDocColumnsValues()
        {
            List<List<string>> colValuesGroup = new List<List<string>>();
            foreach( var val in docValues)
            {
                List<string> colValues = new List<string>();
                List<string> parts = val.Split(';').ToList();
                if (parts.Count > 1)
                {
                    colValues = parts[1].Split(',').ToList();
                    // check one case " A, B,C" (Address used)
                    
                    colValuesGroup.Add(FormatAddrWithComma(colValues));
                }
            }
            
            return colValuesGroup;
        }

        public static List<string> FormatAddrWithComma(List<string> colValues)
        {
            List<string> outStr = new List<string>();
            string sample = "";
            for (int i = 0 ; i < colValues.Count; ++i)
            {
                if (colValues[i].Trim().StartsWith("\"") && !colValues[i].Trim().EndsWith("\""))
                {
                    sample = colValues[i];
                    continue;
                }

                if (!colValues[i].Trim().StartsWith("\"") && colValues[i].Trim().EndsWith("\""))
                {
                    sample += "," + colValues[i];
                    outStr.Add(sample);
                    sample = "";
                    continue;
                }

                if (sample != "")
                {
                    sample += "," + colValues[i];
                    continue;
                }

                outStr.Add(colValues[i]);                
            }

            return outStr;
        }

        public List<List<string>> FormatTableContent()
        {
            List<string> header = new List<string>();
            List<List<string>> rows = new List<List<string>>();

            List<int> headerType = new List<int>();
            List<List<int>> rowType = new List<List<int>>();

            formatedColsAndValues.Clear();
            formatedColsAndValuesType.Clear();
            
            if (IsEmpty())
            {
                return formatedColsAndValues;
            }

            header.Add(docName);
            headerType.Add(TableName);
            header.AddRange(GetDocKeys());
            
            for (int i = 1; i < header.Count; ++i )
            {
                headerType.Add(TableKey);
            }

            header.AddRange(GetDocColumns());
            while(headerType.Count < header.Count)
            {
                headerType.Add(TableHeader);
            }


            for (int i = 0; i < docValues.Count; ++i)
            {
                List<string> singleRow = new List<string>();
                List<int> singleRowType = new List<int>();
                singleRow.Add(" ");
                singleRowType.Add(TableEmpty);
                singleRow.AddRange(GetDocKeysValue(i));
                while (singleRowType.Count < singleRow.Count)
                {
                    singleRowType.Add(TableKeyValue);
                }
                singleRow.AddRange(GetDocColumnsValue(i));
                while(singleRowType.Count < singleRow.Count)
                {
                    singleRowType.Add(TableValue);
                }
                rows.Add(singleRow);
                rowType.Add(singleRowType);               
            }

            formatedColsAndValues.Clear();
            formatedColsAndValues.Add(header);
            formatedColsAndValues.AddRange(rows);

            formatedColsAndValuesType.Clear();
            formatedColsAndValuesType.Add(headerType);
            formatedColsAndValuesType.AddRange(rowType);

            return formatedColsAndValues;
        }

        public static string TrimLine(string strBase)
        {
            string outStr = "";
            string[] strBaseParts = strBase.Split(';').ToArray();
            foreach(var str in strBaseParts)
            {
                List<string> strBaseArr = str.Split(',').ToList();
                strBaseArr = CompareTable.FormatAddrWithComma(strBaseArr);
                for (int i = 0; i < strBaseArr.Count; ++i)
                {
                    outStr += strBaseArr[i].Trim();
                    if (i < strBaseArr.Count - 1)
                    {
                        outStr += ",";
                    }
                }

                if (!outStr.Contains(";"))
                {
                    outStr += ";";
                }
            }

            // remove last ','
            if (outStr.EndsWith(","))
            {
                outStr = outStr.Substring(0, outStr.Length - 1);
            }

            return outStr;
        }
    }

    class RCCompareResult
    {
        public List<CompareTable> tableGroup { get; set; }
        public RCCompareResult()
        {
            tableGroup = new List<CompareTable>();
        }

        public CompareTable GetCompareTableByName(string name)
        {
            foreach(var tg in tableGroup)
            {
                if (tg.docName == name)
                {
                    return tg;
                }
            }

            return null;
        }

        public int GetMaxColumnCount()
        {
            int maxSize = 0;
            foreach (var ct in tableGroup)
            {
                int size = ct.GetDocKeys().Count + ct.GetDocColumns().Count + 1;
                if (size > maxSize)
                {
                    maxSize = size;
                }
            }

            return maxSize;
        }

        public int GetCellType(int x, int y)
        {
            try
            {
                int yCur = 0;
                for (int i = 0; i < tableGroup.Count; ++i)
                {
                    if (yCur <= y && yCur + tableGroup[i].formatedColsAndValuesType.Count > y)
                    {
                        return tableGroup[i].formatedColsAndValuesType[y - yCur][x];
                    }
                    else
                    {
                        yCur += tableGroup[i].formatedColsAndValuesType.Count;
                    }
                }
            }
            catch(Exception)
            {
                return -1;
            }

            return -1;            
        }

        public string GetCellTableName(int x, int y)
        {
            try
            {
                int yCur = 0;
                for (int i = 0; i < tableGroup.Count; ++i)
                {
                    if (yCur <= y && yCur + tableGroup[i].formatedColsAndValues.Count > y)
                    {
                        return tableGroup[i].docName;
                    }
                    else
                    {
                        yCur += tableGroup[i].formatedColsAndValues.Count;
                    }
                }
            }
            catch (Exception)
            {
            }

            return "";
        }

        public string GetCellColumnName(int x, int y)
        {
            try
            {
                int yCur = 0;
                for (int i = 0; i < tableGroup.Count; ++i)
                {
                    if (yCur <= y && yCur + tableGroup[i].formatedColsAndValues.Count > y)
                    {
                        return tableGroup[i].formatedColsAndValues[y - yCur][x];
                    }
                    else
                    {
                        yCur += tableGroup[i].formatedColsAndValues.Count;
                    }
                }
            }
            catch (Exception)
            {
            }

            return "";
        }
    }
}
