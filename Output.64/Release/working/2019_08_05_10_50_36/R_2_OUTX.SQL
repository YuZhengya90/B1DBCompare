set Schema "SBODEMOUS";select * from OUTX where "SrcObjAbs" = (select "DocEntry" from ORDR where "DocNum" = ('2')) And "SrcObjType" = 17 ; 
