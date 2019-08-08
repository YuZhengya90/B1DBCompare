set Schema "SBODEMOUS";select * from RDR3 where "DocEntry" = (select "DocEntry" from ORDR where "DocNum" = ('1583')) Order By "LineNum"; 
