using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultCompareUI
{   
    class QueryBox
    {
        private const string mHANAQueryBoxPath = ".\\config\\querybox_hana.txt";
        private const string mMSSQLQueryBoxPath = ".\\config\\querybox_mssql.txt";
        

        private static Dictionary<string, Dictionary<string, string>> mAllQueries;

        public static void Init(ConfigurationDBType type)
        {
            StreamReader sr = null;

            try
            {
                sr = new StreamReader(type == ConfigurationDBType.C_HANA ? mHANAQueryBoxPath : mMSSQLQueryBoxPath);
                string content = sr.ReadToEnd();

                mAllQueries = new Dictionary<string, Dictionary<string, string>>();
                Dictionary<string, string> qs = new Dictionary<string, string>();
                List<string> boSections = content.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach(string sec in boSections)
                {
                    if (sec.StartsWith("BO:"))
                    {
                        qs = new Dictionary<string,string>();
                        int startPos = "BO:".Length;
                        string title = sec.Substring(startPos, sec.Length - startPos);
                        mAllQueries.Add(title, qs);
                    }

                    else
                    {
                        List<string> nameAndQuery = sec.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                        qs.Add(nameAndQuery[0], nameAndQuery[1]);
                    }                 
                }                
            }
            catch(Exception)
            {
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }

        public static string[] GetAllBO()
        {
            return mAllQueries.Keys.ToArray();
        }

        public static string[] GetTablesByBO(string bo)
        {
            return mAllQueries[bo].Keys.ToArray();
        }

        public static string GetTableKeyOrderByBOTable(string bo, string tableName)
        {
            // two parts DocNum and Order By.
            int selectCondPos = mAllQueries[bo][tableName].IndexOf("(?)");
            string sampleStr = mAllQueries[bo][tableName].Substring(0, selectCondPos);
            int lastColon = sampleStr.LastIndexOf("=");
            int firstColon = sampleStr.Substring(0, lastColon - 1).LastIndexOf("where");
            string selectCond = mAllQueries[bo][tableName].Substring(firstColon + 5, lastColon - firstColon - 5).Trim(new char[]{' ','\"'});

            int startPos = mAllQueries[bo][tableName].LastIndexOf("Order By");
            if (startPos < 0)
            {
                return selectCond;
            }
            string orderCond = mAllQueries[bo][tableName].Substring(startPos + 8);
            orderCond = orderCond.Trim("\"; ".ToCharArray());
            return selectCond + "," + orderCond;
        }

        public static string GetQueryByBOTable(string bo, string tableName, string input)
        {
            string rawQuery = mAllQueries[bo][tableName];
            return rawQuery.Replace("?", "\'" + input + "\'");
        }
    }
}
