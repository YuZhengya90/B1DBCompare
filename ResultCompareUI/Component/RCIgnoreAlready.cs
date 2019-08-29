using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultCompareUI
{
    // ignore the hard code columns inside.
    class RCIgnoreAlready
    {
        private static Dictionary<string, string> igA;
        private static void Init()
        {
            igA = new Dictionary<string, string>();
            igA["ORDR"] = ",DocEntry,DocNum,CreateTS,CreateDate";
            igA["RDR1"] = ",DocEntry,DistribExp,ReturnAct";
            igA["RDR2"] = ",DocEntry";
            igA["RDR3"] = ",DocEntry";
            igA["RDR4"] = ",DocEntry";
            igA["RDR5"] = ",AbsEntry";
            igA["RDR6"] = ",DocEntry";
            igA["RDR7"] = ",DocEntry";
            igA["RDR8"] = ",DocEntry";
            igA["RDR9"] = ",DocEntry";
            igA["RDR10"] = ",DocEntry";
            igA["RDR11"] = ",DocEntry";
            igA["RDR12"] = ",DocEntry";
            igA["RDR13"] = ",DocEntry";
            igA["RDR14"] = ",DocEntry";
            igA["RDR15"] = ",DocEntry";
            igA["RDR16"] = ",AbsEntry";
            igA["RDR18"] = ",DocEntry";
            igA["RDR19"] = ",DocEntry";
            igA["RDR20"] = ",DocEntry";
            igA["RDR21"] = ",DocEntry";
            igA["RDR22"] = ",DocEntry";
            igA["RDR23"] = ",DocEntry";
            igA["RDR24"] = ",DocEntry";
            igA["RDR25"] = ",DocEntry";
            igA["RDR26"] = ",DocEntry";
            igA["OUTX"] = ",AbsEntry";
            igA["UTX1"] = ",AbsEntry";
            igA["OCRD"] = ",CardCode,CreateDate,CreateTS";
            igA["CRD1"] = ",CardCode";
            igA["CRD2"] = ",CardCode";
            igA["CRD3"] = ",CardCode";
            igA["CRD4"] = ",CardCode";
            igA["CRD5"] = ",CardCode";
            igA["CRD6"] = ",CardCode";
            igA["CRD7"] = ",CardCode";
            igA["CRD8"] = ",CardCode";
            igA["CRD9"] = ",CardCode";
            igA["CRDC"] = ",CardCode";
            igA["CRD11"] = ",CardCode";
            igA["CRD12"] = ",CardCode";
            igA["OCPR"] = ",CardCode";
            igA["OCRB"] = ",CardCode";
            igA["ODDT"] = ",CardCode";
            igA["OITM"] = ",ItemCode,CreateDate,CreateTS";
            igA["ITM1"] = ",ItemCode";
            igA["ITM2"] = ",ItemCode";
            igA["ITM3"] = ",ItemCode";
            igA["ITM4"] = ",ItemCode";
            igA["ITM5"] = ",ItemCode";
            igA["ITM6"] = ",ItemCode";
            igA["ITM7"] = ",ItemCode";
            igA["ITM8"] = ",ItemCode";
            igA["ITM9"] = ",ItemCode";
            igA["ITM10"] = ",ItemCode";
            igA["ITM11"] = ",ItemCode";
            igA["ITM12"] = ",ItemCode";
            igA["ITM13"] = ",ItemCode";
            igA["OITW"] = ",ItemCode";
            igA["OBCD"] = ",ItemCode";
            igA["OCLG"] = ",ClgCode,CreateDate";
            igA["CLG1"] = ",ClgCode";
        }

        public static string GetByTable(string tableName)
        {
            if (igA == null)
            {
                Init();
            }

            if (igA.ContainsKey(tableName))
                return igA[tableName];
            else return "";
        }

    }
}
