using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultCompareUI
{
    public class ConfigurationList
    {
        private static List<ConfigurationStruct> confList;
        public static bool mListChanged = false;
        public static void ReSync()
        {
            confList.Clear();
            confList = null;
            mListChanged = false;
            GetList();

        }

        public static List<ConfigurationStruct> GetList()
        {
            if (confList == null)
            {
                ReadFromFile();
            }

            return confList;
        }

        public static ConfigurationStruct GetByName(string confName)
        {
            foreach (var ci in confList)
            {
                if (ci.getName().Trim() == confName.Trim())
                {
                    return ci;
                }
            }

            return null;
        }

        public static ConfigurationStruct GetCurrent()
        {
            return confList.Last();
        }

        public static string[] GetNameList()
        {
            List<string> nameList = new List<string>();
            foreach (var ci in confList)
            {
                nameList.Add(ci.getName());
            }
            return nameList.ToArray();
        }

        public static void SetCurrent(string confName)
        {
            int found = -1;
            for (int index = 0; index < confList.Count; ++index )
            {
                var cs = confList[index];
                if (cs.getName() == confName)
                {
                    found = index;
                    break;
                }
            }

            if (found >= 0)
            {
                ConfigurationStruct newCS = GetByName(confName).copy();
                confList.RemoveAt(found);
                confList.Add(newCS);
            }
        }

        public static void RemoveCurrent()
        {
            if (confList.Count > 0)
            {
                confList.RemoveAt(confList.Count - 1);
                mListChanged = true;
            }            
        }

        public static bool NewAdd(string confName)
        {
            foreach(var ci in confList)
            {
                if (ci.getName().Trim() == confName.Trim())
                {
                    return false;
                }
            }

            ConfigurationStruct cs = new ConfigurationStruct();
            cs.configurationName = confName.Trim();
            confList.Add(cs);
            mListChanged = true;

            return true;
        }

        public static void ReadFromFile()
        {
            confList = new List<ConfigurationStruct>();
            using (StreamReader sr = new StreamReader(".\\config\\database.ini", Encoding.Default))
            {
                string content = sr.ReadToEnd();
                List<string> eachConfig = content.Split(new String[]{"\n\n"}, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (string strConfig in eachConfig)
                {
                    ConfigurationStruct cs = new ConfigurationStruct();
                    cs.ReadFromConfigFileString(strConfig);
                    confList.Add(cs);
                }
            }
        }

        public static void WriteToFile()
        {
            string allContent = "";
            foreach(var confI in confList)
            {
                string strConfI = confI.WriteToConfigFileString();
                allContent += strConfI + "\n";
            }

            File.WriteAllText(".\\config\\database.ini", allContent);
        }

    }

    public enum ConfigurationDBType
    {
        C_HANA = 0,
        C_MSSQL = 1
    }

    public class ConfigurationStruct
    {
        public string configurationName {get;set;}
        public string configurationDescription { get; set; }
        public ConfigurationDBType configurationDBType { get; set; }
        public string configurationIPPort {get;set;}
        public string configurationSchema { get; set; }
        public string configurationUsername { get; set; }
        public string configurationPassword { get; set; }
        public int configurationConnectionTimeout { get; set; }
        public string configurationExePath { get; set; }

        private string Name = "Name";
        private string Description = "Description";
        private string IPPort = "IPPort";
        private string Schema = "Schema";
        private string Username = "Username";
        private string Password = "Password";
        private string DBType = "DBType";
        private string ConnectionTimeout = "ConnectionTimeout";
        private string ExePath = "DBExePath";

        public ConfigurationStruct()
        {
            // currectly from static string;
            //configurationName = "Configuration-1";
            //configurationDescription = "Configuration Description";
            //configurationIPPort = "10.58.114.50:30013";
            //configurationSchema = "US";
            //configurationUsername = "SYSTEM";
            //configurationPassword = "Initial0";
            configurationDBType = ConfigurationDBType.C_HANA;
            configurationConnectionTimeout = 2000;
            configurationExePath = @"C:\Program Files (x86)\SAP\hdbclient\hdbsql.exe";
            //ReadFromConfigFile();
            
        }

        public ConfigurationStruct copy()
        {
            ConfigurationStruct newCs = new ConfigurationStruct();
            newCs.configurationName = this.configurationName;
            newCs.configurationDescription = this.configurationDescription;
            newCs.configurationIPPort = this.configurationIPPort;
            newCs.configurationSchema = this.configurationSchema;
            newCs.configurationUsername = this.configurationUsername;
            newCs.configurationPassword = this.configurationPassword;
            newCs.configurationDBType = this.configurationDBType;
            newCs.configurationConnectionTimeout = this.configurationConnectionTimeout;
            newCs.configurationExePath = this.configurationExePath;
            return newCs;
        }

        public string getName()
        {
            return configurationName;
        }

        public string GetIPPort()
        {
            return configurationIPPort;
        }

        public string GetSchema()
        {
            return configurationSchema;
        }

        public string GetUserName()
        {
            return configurationUsername;
        }

        public string GetPassword()
        {
            return configurationPassword;
        }

        public string GetConnectionTimout()
        {
            return configurationConnectionTimeout.ToString();
        }

        public void ReadFromConfigFileString(string content)
        {
            List<string> lines = content.Split(';').ToList();
            foreach(var li in lines)
            {
                List<string> parts = li.Split('=').ToList();
                if (parts.Count > 1)
                {
                    if (parts[0].Trim() == Name) configurationName = parts[1].Trim();
                    if (parts[0].Trim() == Description) configurationDescription = parts[1].Trim();
                    if (parts[0].Trim() == IPPort) configurationIPPort = parts[1].Trim();
                    if (parts[0].Trim() == Schema) configurationSchema = parts[1].Trim();
                    if (parts[0].Trim() == Username) configurationUsername = parts[1].Trim();
                    if (parts[0].Trim() == Password) configurationPassword = parts[1].Trim();
                    if (parts[0].Trim() == DBType) configurationDBType = (ConfigurationDBType)int.Parse((parts[1].Trim()));
                    if (parts[0].Trim() == ConnectionTimeout) configurationConnectionTimeout = int.Parse(parts[1].Trim());
                    if (parts[0].Trim() == ExePath) configurationExePath = parts[1].Trim();
                }
            }

        }

        public string WriteToConfigFileString()
        {
            string content = "";
            content += Name + "=" + configurationName + ";\n";
            content += Description + "=" + configurationDescription + ";\n";
            content += IPPort + "=" + configurationIPPort + ";\n";
            content += Schema + "=" + configurationSchema + ";\n";
            content += Username + "=" + configurationUsername + ";\n";
            content += Password + "=" + configurationPassword + ";\n";
            content += DBType + "=" + (int)configurationDBType + ";\n";
            content += ConnectionTimeout + "=" + configurationConnectionTimeout + ";\n";
            content += ExePath + "=" + configurationExePath + ";\n";
            return content;
        }
    }

}
