set Schema "SBODEMOUS";select * from RDR1 where "DocEntry" = (select "DocEntry" from ORDR where "DocNum" = ('356')) Order By "LineNum"; 
