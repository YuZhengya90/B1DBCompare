
This tool was build by BinGO team for SAP Business One table Compare.
you can use 2 key for Business Object compare their different columns' values.

[SAVE AS]:
You can save result with .csv format so that Excel and other tools can read it.
The default save path is your document path.

[CONFIGURATION]:
Now it only supports HANA 2.0 Database. 
You can input your HANA 2.0 server information. It will automatically saved and 
when you next time log in, it still used the last connection configuration.
Connection Timeout field is one query or database's operation time out limitation.
You'd better type in bigger than 2 seconds for database's latency.

[Compare List]:
You can right click one the column of the database fields to ignore it manually.
It will save the result to your ignore.txt file.
Default Ignore.txt file was created in your local path of this tools.

[Ignore List]:
You can also remove the ignore list file's column to restore the result.
Any columns restored, the result will display again with new values.
Default Ignore.txt is placed in config\ignore.txt.
Any modification or changed manually will record inside for the furthuer use.
the format of Ignore.txt should be like this: 
	OCRD:CardCode,CardName
	ORDR:DocEntry,DocNum
Start with new line and split with comma(,). Table Name and Table columns divide 
with colon(：).

[Working directory And Working flow]:
This software was working with "hdbsql.exe" and "DBCompare.exe". 
hdbsql.exe you can need to install before in your local machine, default path should
be : C:\Program Files (x86)\SAP\hdbclient\hdbsql.exe. And DBCompare is in the local 
directory.
If it works correctly, it always generated some types of files for you to debug:
.\working\<datetime of you click compare>\L_Key_Table.SQL -> Left  Key SQL
.\working\<datetime of you click compare>\R_Key_Table.SQL -> Right Key SQL
.\working\<datetime of you click compare>\L_Key_Table.RST -> Left  SQL Result
.\working\<datetime of you click compare>\R_Key_Table.RST -> Right SQL Result
.\working\<datetime of you click compare>\O_Table_LKey_RKey.TXT -> End Result

If none result of the Business Objects sub tables or all the table columns are 
the same, it will not display on the result list.

Any suggestion and devices, please contact zhengya.yu01@sap.com.


