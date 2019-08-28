using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultCompareUI
{
    class ConstTableInfo
    {
        public const string sTypeOdd = "Odd";
        public const string sTypeArr = "Array";

        public string tableName {get; set;}
        public string tableKey { get; set; }
        public string tableType { get; set; }
        public int tableSeq { get; set; }
        public string tableOrder { get; set; }

        public ConstTableInfo(string name, string key, string type, int seq, string order)
        {
            tableName = name;
            tableKey = key;
            tableType = type;
            tableSeq = seq;
            tableOrder = order;
        }
    }

    class ConstTableRelation
    {
        private static Dictionary<string, List<ConstTableInfo>> tableRelations;
        private static Dictionary<string, string> tableQuery;
        public static void Init() 
        {
            tableRelations = new Dictionary<string, List<ConstTableInfo>>();
            tableQuery = new Dictionary<string, string>();
            List<ConstTableInfo> listORDR = new List<ConstTableInfo>();
            tableRelations.Add("ORDR", listORDR);
            tableQuery.Add("ORDR", "DocNum");
            listORDR.Add(new ConstTableInfo("ORDR", "DocEntry", ConstTableInfo.sTypeArr, 0, ""));
            listORDR.Add(new ConstTableInfo("RDR1", "DocEntry", ConstTableInfo.sTypeArr, 1, "LineNum"));
            listORDR.Add(new ConstTableInfo("RDR2", "DocEntry", ConstTableInfo.sTypeArr, 2, "LineNum,GroupNum"));
            listORDR.Add(new ConstTableInfo("RDR3", "DocEntry", ConstTableInfo.sTypeArr, 3, "LineNum"));
            listORDR.Add(new ConstTableInfo("RDR4", "DocEntry", ConstTableInfo.sTypeArr, 4, "LineSeq"));
            listORDR.Add(new ConstTableInfo("RDR5", "AbsEntry", ConstTableInfo.sTypeArr, 5, "LineNum"));
            listORDR.Add(new ConstTableInfo("RDR6", "DocEntry", ConstTableInfo.sTypeArr, 6, "InstlmntID"));
            listORDR.Add(new ConstTableInfo("RDR7", "DocEntry", ConstTableInfo.sTypeArr, 7, "PackageNum"));
            listORDR.Add(new ConstTableInfo("RDR8", "DocEntry", ConstTableInfo.sTypeArr, 8, "PackageNum,ItemCode,UomEntry,NumPerMsr"));
            listORDR.Add(new ConstTableInfo("RDR9", "DocEntry", ConstTableInfo.sTypeArr, 9, "LineNum"));
            listORDR.Add(new ConstTableInfo("RDR10", "DocEntry", ConstTableInfo.sTypeArr, 10, "LineSeq"));
            listORDR.Add(new ConstTableInfo("RDR11", "DocEntry", ConstTableInfo.sTypeArr, 11, "LineNum,LineSeq"));
            listORDR.Add(new ConstTableInfo("RDR12", "DocEntry", ConstTableInfo.sTypeArr, 12, ""));
            listORDR.Add(new ConstTableInfo("RDR13", "DocEntry", ConstTableInfo.sTypeArr, 13, "LineNum,GroupNum"));
            listORDR.Add(new ConstTableInfo("RDR14", "DocEntry", ConstTableInfo.sTypeArr, 14, "LineNum,ChildNum"));
            listORDR.Add(new ConstTableInfo("RDR15", "DocEntry", ConstTableInfo.sTypeArr, 15, "LineNum"));
            listORDR.Add(new ConstTableInfo("RDR16", "AbsEntry", ConstTableInfo.sTypeArr, 16, "LineNum"));
            listORDR.Add(new ConstTableInfo("RDR17", "DocEntry", ConstTableInfo.sTypeArr, 17, "LineNum"));
            listORDR.Add(new ConstTableInfo("RDR18", "DocEntry", ConstTableInfo.sTypeArr, 18, "LineNum"));
            listORDR.Add(new ConstTableInfo("RDR19", "DocEntry", ConstTableInfo.sTypeArr, 19, "BinAllocSe"));
            listORDR.Add(new ConstTableInfo("RDR20", "DocEntry", ConstTableInfo.sTypeArr, 20, "LineNum"));
            listORDR.Add(new ConstTableInfo("RDR21", "DocEntry", ConstTableInfo.sTypeArr, 21, "LineNum,RefType"));
            listORDR.Add(new ConstTableInfo("RDR22", "DocEntry", ConstTableInfo.sTypeArr, 22, "LineNum,StdCostNum"));
            listORDR.Add(new ConstTableInfo("RDR23", "DocEntry", ConstTableInfo.sTypeArr, 23, "LineNum,VisOrder"));
            listORDR.Add(new ConstTableInfo("RDR24", "DocEntry", ConstTableInfo.sTypeArr, 24, "LineNum,ChildNum"));
            listORDR.Add(new ConstTableInfo("RDR25", "DocEntry", ConstTableInfo.sTypeArr, 25, "VatGroup,Type"));
            listORDR.Add(new ConstTableInfo("RDR26", "DocEntry", ConstTableInfo.sTypeArr, 26, ""));
            

            List<ConstTableInfo> listOCRD = new List<ConstTableInfo>();
            tableRelations.Add("OCRD", listOCRD);
            tableQuery.Add("OCRD", "CardCode");
            listOCRD.Add(new ConstTableInfo("OCRD", "CardCode", ConstTableInfo.sTypeArr, 0, ""));
            listOCRD.Add(new ConstTableInfo("CRD1", "CardCode", ConstTableInfo.sTypeArr, 1, "Address,AdresType"));
            listOCRD.Add(new ConstTableInfo("CRD2", "CardCode", ConstTableInfo.sTypeArr, 2, "LineNum"));
            listOCRD.Add(new ConstTableInfo("CRD3", "CardCode", ConstTableInfo.sTypeArr, 3, "AcctType"));
            listOCRD.Add(new ConstTableInfo("CRD4", "CardCode", ConstTableInfo.sTypeArr, 4, "WTCode"));
            listOCRD.Add(new ConstTableInfo("CRD5", "CardCode", ConstTableInfo.sTypeArr, 5, "PmntDate"));
            listOCRD.Add(new ConstTableInfo("CRD6", "CardCode", ConstTableInfo.sTypeArr, 6, "CardPyName"));
            listOCRD.Add(new ConstTableInfo("CRD7", "CardCode", ConstTableInfo.sTypeArr, 7, "Address,AddrType"));
            listOCRD.Add(new ConstTableInfo("CRD8", "CardCode", ConstTableInfo.sTypeArr, 8, "BPLId"));
            listOCRD.Add(new ConstTableInfo("CRD9", "CardCode", ConstTableInfo.sTypeArr, 9, "CommMeanId"));
            listOCRD.Add(new ConstTableInfo("CRDC", "CardCode", ConstTableInfo.sTypeArr, 10, "Address"));
            listOCRD.Add(new ConstTableInfo("CRD11", "CardCode", ConstTableInfo.sTypeArr, 11, "TributID"));
            listOCRD.Add(new ConstTableInfo("CRD12", "CardCode", ConstTableInfo.sTypeArr, 12, "ProtCode"));
            listOCRD.Add(new ConstTableInfo("OCPR", "CardCode", ConstTableInfo.sTypeOdd, 1, ""));
            listOCRD.Add(new ConstTableInfo("OCRB", "CardCode", ConstTableInfo.sTypeOdd, 2, "Country,BankCode,Account"));
            listOCRD.Add(new ConstTableInfo("ODDT", "CardCode", ConstTableInfo.sTypeOdd, 3, ""));

            List<ConstTableInfo> listOITM = new List<ConstTableInfo>();
            tableRelations.Add("OITM", listOITM);
            tableQuery.Add("OITM", "ItemCode");
            listOITM.Add(new ConstTableInfo("OITM", "ItemCode", ConstTableInfo.sTypeArr, 0, ""));
            listOITM.Add(new ConstTableInfo("ITM1", "ItemCode", ConstTableInfo.sTypeArr, 1, "PriceList"));
            listOITM.Add(new ConstTableInfo("ITM2", "ItemCode", ConstTableInfo.sTypeArr, 2, "VendorCode"));
            listOITM.Add(new ConstTableInfo("ITM3", "ItemCode", ConstTableInfo.sTypeArr, 3, ""));
            listOITM.Add(new ConstTableInfo("ITM4", "ItemCode", ConstTableInfo.sTypeArr, 4, "UomType,UomEntry,PkgCode"));
            listOITM.Add(new ConstTableInfo("ITM5", "ItemCode", ConstTableInfo.sTypeArr, 5, "LineNum"));
            listOITM.Add(new ConstTableInfo("ITM6", "ItemCode", ConstTableInfo.sTypeArr, 6, "LineNum"));
            listOITM.Add(new ConstTableInfo("ITM7", "ItemCode", ConstTableInfo.sTypeArr, 7, "PeriodCat,DprArea"));
            listOITM.Add(new ConstTableInfo("ITM8", "ItemCode", ConstTableInfo.sTypeArr, 8, "PeriodCat,DprArea"));
            listOITM.Add(new ConstTableInfo("ITM9", "ItemCode", ConstTableInfo.sTypeArr, 9, "PriceList,UomEntry"));
            listOITM.Add(new ConstTableInfo("ITM10", "ItemCode", ConstTableInfo.sTypeArr, 10, ""));
            listOITM.Add(new ConstTableInfo("ITM11", "ItemCode", ConstTableInfo.sTypeArr, 11, "PeriodCat,DprArea,VisOrder"));
            listOITM.Add(new ConstTableInfo("ITM12", "ItemCode", ConstTableInfo.sTypeArr, 12, "UomType,UomEntry"));
            listOITM.Add(new ConstTableInfo("ITM13", "ItemCode", ConstTableInfo.sTypeArr, 13, ""));
            listOITM.Add(new ConstTableInfo("OITW", "ItemCode", ConstTableInfo.sTypeOdd, 1, "WhsCode"));
            listOITM.Add(new ConstTableInfo("OBCD", "ItemCode", ConstTableInfo.sTypeOdd, 2, "UomEntry,BcdCode"));

            List<ConstTableInfo> listOCLG = new List<ConstTableInfo>();
            tableRelations.Add("OCLG", listOCLG);
            tableQuery.Add("OCLG", "ClgCode");
            listOCLG.Add(new ConstTableInfo("OCLG", "ClgCode", ConstTableInfo.sTypeArr, 0, ""));
            listOCLG.Add(new ConstTableInfo("CLG1", "ClgCode", ConstTableInfo.sTypeArr, 1, "LineNum"));

            List<ConstTableInfo> listOUTX = new List<ConstTableInfo>();
            tableRelations.Add("OUTX", listOUTX);
            listOUTX.Add(new ConstTableInfo("OUTX", "AbsEntry", ConstTableInfo.sTypeArr, 0, ""));
            listOUTX.Add(new ConstTableInfo("UTX1", "AbsEntry", ConstTableInfo.sTypeArr, 1, "LineSeq"));
        }


        public static string[] GetAllBO()
        {
            return tableRelations.Keys.ToArray();
        }

        public static string[] GetTablesByBO(string bo)
        {
            List<string> lstOt = new List<string>();
            List<ConstTableInfo> tableInfos = tableRelations[bo];
            foreach (var st in tableInfos)
            {
                lstOt.Add(st.tableName);
            }

            return lstOt.ToArray();
        }

        public static string GetKeyByBOTable(string bo, string table)
        {
            List<ConstTableInfo> tableInfos = tableRelations[bo];
            foreach (var st in tableInfos)
            {
                if (st.tableName == table)
                {
                    return st.tableKey;
                }
            }

            return null;
        }

        public static string GetOrderByBOTable(string bo, string table)
        {
            List<ConstTableInfo> tableInfos = tableRelations[bo];
            foreach (var st in tableInfos)
            {
                if (st.tableName == table)
                {
                    string ot = "";
                    List<string> orders = st.tableOrder.Split(',').ToList();
                    foreach (var o in orders)
                    {
                        if (o.Trim().Length != 0)
                        {
                            if (ot.Length != 0)
                            {
                                ot += ",";
                            }
                            ot += "\"" + o + "\"";
                        }
                    }

                    if (ot.Length == 0)
                        return null;
                    return ot;
                }
            }

            return null;
        }

        public static string GetTableKeyOrderByBOTable(string bo, string table)
        {
            List<ConstTableInfo> tableInfos = tableRelations[bo];
            foreach (var st in tableInfos)
            {
                if (st.tableName == table)
                {
                    return st.tableKey + "," + st.tableOrder;
                }
            }

            return null;
        }
    }
}