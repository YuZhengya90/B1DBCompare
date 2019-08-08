#include <vector>
#include <map>
#include <iostream>
#include <Windows.h>

#pragma warning (disable :4267)

using namespace std;

struct ResGroup {
	vector<string> columns;
	vector <vector<string>> colValues;
	bool isValid()const { 
		if (colValues.size() != 0)
			return colValues[0].size() == columns.size();
		return columns.size() != 0; 
	}
	void clear() { columns.clear(); colValues.clear(); }
	size_t size() const { return isValid() ? columns.size() : 0; }
};

struct IgnoreList {
	vector<string> igColumns;
	bool HasValue(const string& s) const{
		for (auto it = igColumns.begin(); it != igColumns.end(); ++it){
			if (*it == s) { return true; }
		}
		return false;
	}
};

struct CompareUnit {
	string col;
	map<int, string> vecStr1;
	map<int, string> vecStr2;
	CompareUnit(const string& c) :col(c){ }
	size_t length(){
		size_t maxLen = col.length();
		for (size_t i = 0; i < vecStr1.size(); ++i){
			if (vecStr1[i].length() > maxLen) maxLen = vecStr1[i].length();
			if (vecStr2[i].length() > maxLen) maxLen = vecStr2[i].length();
		}

		return maxLen;
	}

	size_t thick() {
		return vecStr1.size();
	}
};

struct CompareGourp {
	vector<CompareUnit*> comKeys;
	vector<CompareUnit*> comUnits;
	size_t thick() const { 
		size_t maxThick = 0;
		for (size_t i = 0; i < comUnits.size(); ++i){
			if (maxThick < comUnits[i]->thick()) maxThick = comUnits[i]->thick();
		}
		return maxThick;
	}

	CompareUnit* getColUnit(const string& c){
		for (size_t i = 0; i < comUnits.size(); ++i){
			if (comUnits[i]->col == c) return comUnits[i];
		}
		return nullptr;
	}

	CompareUnit* getColKey(const string& c){
		for (size_t i = 0; i < comKeys.size(); ++i){
			if (comKeys[i]->col == c) return comKeys[i];
		}
		return nullptr;
	}

	~CompareGourp(){
		for (size_t i = 0; i < comUnits.size(); ++i){
			delete comUnits[i];
		}
		comUnits.clear();
		for (size_t i = 0; i < comUnits.size(); ++i){
			delete comKeys[i];
		}
		comKeys.clear();
	}
};

struct HParams {
	// sql
	// -n 10.59.62.103:30013
	// -u SYSTEM
	// -p Initial0
	// -d DBA
	// -I InputFile
	// -o OutputFile
	string ip;
	string username;
	string password;
	string dba;
	string inputfile;
	string outputfile;
	string timeout;

	// compare
	// -l file1
	// -r file2
	// -o output
	// -i ignore
	string compfile1;
	string compfile2;
	string ignorefile;
	string ignorecolumns;
	string comoutfile;
	string comparekey;

	// configure
	string configurefile;

	string typeOfParams;

	HParams() : timeout("2000"){}

	bool isValid() const {
		return (!ip.empty() && !username.empty() && !password.empty()
			&& !dba.empty() && !inputfile.empty() && !outputfile.empty())
			|| (!compfile1.empty() && !compfile2.empty() && !comoutfile.empty())
			|| (!configurefile.empty());
	}
};

// with quota
static const string strHdbsql = "\"C:\\Program Files (x86)\\SAP\\hdbclient\\hdbsql.exe\"";

string trim(const string& str);
string fill(const string& str, size_t sz);
vector<string> split(const string& str, char sep);

int ParseParams();
int ReadFile(const string& fileName, unsigned char** fileContent, long * fileSize);
int WriteFile(const string& fileName, unsigned char* fileContent, long fileSize);
int ParseCommandFile(const char* fileContent, long fileSize);
ResGroup GenerateResGroup(const char* fileContent, long fileSize);
IgnoreList GenerateIgnoreList(const char* fileContent, long fileSize);
int ConvertSQLResult(const ResGroup& rsGroup);
int CompareResult(const ResGroup& rsGroup1, const ResGroup& rsGroup, const IgnoreList& igList, const string& comKeys,
	CompareGourp& comGroup2);
string ConvertCompareGroup(const CompareGourp& comGroup);


int ParseParams(int argc, char** argv, HParams& params)
{
	if (argc <= 1) return -1;
	if (string(argv[1]) == "sql")
	{
		if (argc < 14) return -1;

		for (int i = 0; i < argc; ++i){

			if (i < argc - 1)
			{
				if (string(argv[i]) == "-n") params.ip = string(argv[i + 1]);
				else if (string(argv[i]) == "-u") params.username = string(argv[i + 1]);
				else if (string(argv[i]) == "-p") params.password = string(argv[i + 1]);
				else if (string(argv[i]) == "-d") params.dba = string(argv[i + 1]);
				else if (string(argv[i]) == "-I") params.inputfile = string(argv[i + 1]);
				else if (string(argv[i]) == "-o") params.outputfile = string(argv[i + 1]);
				else if (string(argv[i]) == "-t") params.timeout = string(argv[i + 1]);
			}
		}

		params.typeOfParams = "sql";
	}
	else if (string(argv[1]) == "compare")
	{
		if (argc < 5) return -1;

		for (int i = 0; i < argc; ++i){

			if (i < argc - 1)
			{
				if (string(argv[i]) == "-l") params.compfile1 = string(argv[i + 1]);
				else if (string(argv[i]) == "-r") params.compfile2 = string(argv[i + 1]);
				else if (string(argv[i]) == "-i") params.ignorefile = string(argv[i + 1]);
				else if (string(argv[i]) == "-I") params.ignorecolumns = string(argv[i + 1]);
				else if (string(argv[i]) == "-o") params.comoutfile = string(argv[i + 1]);
				else if (string(argv[i]) == "-k") params.comparekey = string(argv[i + 1]);
			}
		}

		params.typeOfParams = "compare";
	}

	if (!params.isValid())
		return -1;

	return 0;
}

int main(int argc, char **argv)
{
#if _DEBUG
	//system("pause");
#endif
	HParams hParams;
	if (ParseParams(argc, argv, hParams))
	{
		return -1;
	}

	if (hParams.typeOfParams == "sql")
	{
		string commandLine = strHdbsql + " -n " + hParams.ip + " -u " + hParams.username + " -p " + hParams.password
			+ " -d " + hParams.dba + " -I " + hParams.inputfile + " -o " + hParams.outputfile + " -connecttimeout " + hParams.timeout;
		system(commandLine.c_str());
	}
	else if (hParams.typeOfParams == "compare")
	{
		unsigned char* buf1 = nullptr;
		unsigned char* buf2 = nullptr;
		unsigned char* buf3 = nullptr;
		long size1 = 0, size2 = 0, size3 = 0;

		if (ReadFile(hParams.compfile1, &buf1, &size1))
			return -1;
		ResGroup resGroup1 = GenerateResGroup((const char*)buf1, size1);
		free(buf1);
		if (!resGroup1.isValid())
		{
			std::cerr << hParams.compfile1.c_str() << " is not valid, please check related SQL file" << std::endl;
			return -1;
		}

		if (ReadFile(hParams.compfile2, &buf2, &size2))
			return -1;
		ResGroup resGroup2 = GenerateResGroup((const char*)buf2, size2);
		free(buf2);
		if (!resGroup2.isValid())
		{
			std::cerr << hParams.compfile2.c_str() << " is not valid, please check related SQL file" << std::endl;
			return -1;
		}

		IgnoreList igList;
		if (!hParams.ignorefile.empty()) {
			if (ReadFile(hParams.ignorefile, &buf3, &size3))
				return -1;
			igList = GenerateIgnoreList((const char*)buf3, size3);
			free(buf3);
		}
		else if (!hParams.ignorecolumns.empty()) {
			igList = GenerateIgnoreList(hParams.ignorecolumns.c_str(), hParams.ignorecolumns.length());
		}

		CompareGourp comGroup;
		CompareResult(resGroup1, resGroup2, igList, hParams.comparekey, comGroup);
		string outStr = ConvertCompareGroup(comGroup);
		WriteFile(hParams.comoutfile, (unsigned char*)outStr.c_str(), outStr.length());
	}

	return 0;
}

int ReadFile(const string& fileName, unsigned char** fileContent, long * fileSize)
{
	HANDLE hf = CreateFile(fileName.c_str(),
		FILE_GENERIC_READ, FILE_SHARE_READ, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
	if (hf == INVALID_HANDLE_VALUE)
	{
		std::cerr << "Read file [" << fileName.c_str() << "] failed";
		return -1;
	}
	*fileSize= GetFileSize(hf, NULL);
	*fileContent = (PBYTE)malloc(*fileSize);
	ReadFile(hf, *fileContent, *fileSize, (LPDWORD)fileSize, NULL);
	CloseHandle(hf);
	return 0;
}

int WriteFile(const string& fileName, unsigned char* fileContent, long fileSize)
{
	HANDLE hf = CreateFile(fileName.c_str(),
		FILE_GENERIC_WRITE, FILE_SHARE_READ, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
	if (INVALID_HANDLE_VALUE == hf)
	{
		std::cerr << "Write file [" << fileName.c_str() << "] failed";
		return -1;
	}
	WriteFile(hf, fileContent, fileSize, NULL, NULL);
	CloseHandle(hf);
	return 0;
}

ResGroup GenerateResGroup(const char* fileContent, long fileSize)
{
	ResGroup resGroup;

	string baseStr = fileContent;
	string strColumns;
	vector<string> strColValues;

	size_t PEOL = 0;
	size_t EOL = baseStr.find("\r\n");
	while (EOL != string::npos)
	{
		if (strColumns.empty())
		{
			strColumns = baseStr.substr(0, EOL + 2);
		}
		else
		{
			strColValues.push_back(baseStr.substr(PEOL + 2, EOL - PEOL - 2));
		}

		PEOL = EOL;
		EOL = baseStr.find("\r\n", PEOL + 2);
	}

	resGroup.columns = split(strColumns, ',');
	// fix last \r\n
	if (resGroup.columns.size() > 0 && resGroup.columns.back().find("\r\n") == resGroup.columns.back().length() - 2)
	{
		resGroup.columns[resGroup.columns.size() - 1] = resGroup.columns.back().substr(0, resGroup.columns.back().length() - 2);
	}

	for (auto it = strColValues.begin(); it != strColValues.end(); ++it)
	{
		string str;
		vector<string> lineValues;
		bool openBracket = false;

		for (size_t i = 0; i < it->size(); ++i)
		{
			string st = *it;
			if (st[i] == '"') openBracket = !openBracket;

			if (st[i] == ',' && !openBracket)
			{
				lineValues.push_back(str);
				str = "";
			}
			else
			{
				str += st[i];
			}
		}
		if (!str.empty()) lineValues.push_back(str);
		resGroup.colValues.push_back(lineValues);
	}

	return resGroup;
}

IgnoreList GenerateIgnoreList(const char* fileContent, long fileSize)
{
	string baseStr = fileContent;
	IgnoreList igList;
	igList.igColumns = split(baseStr, ',');
	return igList;
}

int ConvertSQLResult(const ResGroup& resGroup)
{
	string outStr;
	outStr.append("{");
	outStr.append("\"").append("OCRD").append("\"").append(":").append("[");
	for (size_t i = 0; i < resGroup.colValues.size(); ++i)
	{
		if (i != 0)
		{
			outStr.append(",");
		}

		if (resGroup.columns.size() > 0)
		{
			outStr.append("{");
		}

		for (size_t j = 0; j < resGroup.columns.size(); ++j)
		{
			string colValueij = trim(resGroup.colValues[i][j]);
			if (colValueij == "?")
			{
				continue;
			}

			if (j != 0)
			{
				outStr.append(",");
			}

			outStr.append("\"").append(resGroup.columns[j]).append("\"");
			outStr.append(":");
			outStr.append(colValueij);
		}
		outStr.append("}");
	}

	outStr.append("]");
	outStr.append("}");

	return 0;
}

string trim(const string &s)
{
	string str = s;
	if (!str.empty())
	{
		str.erase(0, s.find_first_not_of(" "));
		str.erase(s.find_last_not_of(" ") + 1);
	}
	return str;
}

string fill(const string& s, size_t sz)
{
	string str;
	if (sz > s.length())
	{
		size_t dis = sz - s.length();
		for (size_t i = 0; i < dis; ++i)
		{
			str += " ";
		}
	}
	str += s;
	return str;
}

vector<string> split(const string& str, char sep)
{
	vector<string> outvec;
	string strcopy = str;
	while (true)
	{
		size_t n = strcopy.find(sep);
		if (n != string::npos)
		{
			string s = strcopy.substr(0, n);
			outvec.push_back(s);
			strcopy = strcopy.substr(n + 1);
		}
		else
		{
			outvec.push_back(strcopy);
			break;
		}
	}
	return outvec;
}

int CompareResult(const ResGroup& rsGroup1, const ResGroup& rsGroup2, const IgnoreList& igList, const string& comKeys,
	CompareGourp& comGroup)
{
	if (!rsGroup1.isValid() || !rsGroup2.isValid()){
		return -1;
	}

	if (rsGroup1.size() != rsGroup2.size()){
		return -1;
	}

	long szOfGroup = rsGroup1.size();
	for (long i = 0; i < szOfGroup; ++i)
	{
		if (rsGroup1.columns[i] != rsGroup2.columns[i])  {
			std::cerr << "column not matched in Result! [" << rsGroup1.columns[i].c_str() << "] <> [" << rsGroup2.columns[i].c_str() << "]" << std::endl;
			return -1;
		}
	}

	if (rsGroup1.colValues.size() != rsGroup2.colValues.size()) {
		std::cerr << "record size [" << rsGroup1.colValues.size() << "] <> [" << rsGroup2.colValues.size() << "]" << std::endl;
		return -1;
	}

	vector<string> keys = split(comKeys, ',');
	for (size_t i = 0; i < rsGroup1.colValues.size(); ++i)
	{
		for (long j = 0; j < szOfGroup; ++j)
		{
			if (!comKeys.empty())
			{
				for (auto it = keys.begin(); it != keys.end(); ++it){
					if (*it == rsGroup1.columns[j]) {

						CompareUnit *ck = comGroup.getColKey(*it);
						if (ck == nullptr)
						{
							ck = new CompareUnit(*it);
							comGroup.comKeys.push_back(ck);
						}
						ck->vecStr1[i] = (rsGroup1.colValues[i][j]);
						ck->vecStr2[i] = (rsGroup2.colValues[i][j]);
					}
				}
			}			

			if (rsGroup1.colValues[i][j] == rsGroup2.colValues[i][j]){
				continue;
			}

			if (igList.HasValue(rsGroup1.columns[j])
				&& !rsGroup1.colValues[i][j].empty()
				&& !rsGroup2.colValues[i][j].empty())
			{
				continue;
			}


			CompareUnit *cu = comGroup.getColUnit(rsGroup1.columns[j]);
			if (cu == nullptr)
			{
				cu = new CompareUnit(rsGroup1.columns[j]);
				comGroup.comUnits.push_back(cu);
			}
			cu->vecStr1[i] = (rsGroup1.colValues[i][j]);
			cu->vecStr2[i] = (rsGroup2.colValues[i][j]);			
		}
	}

	return 0;
}

string ConvertCompareGroup(const CompareGourp& comGroup)
{
	size_t thick = comGroup.thick();
	
	string colKeys;
	vector<string> vecKeyValue1;
	vector<string> vecKeyValue2;
	vecKeyValue1.resize(thick);
	vecKeyValue2.resize(thick);

	string columns;
	vector<string> vecValue1;
	vector<string> vecValue2;
	vecValue1.resize(thick);
	vecValue2.resize(thick);

	for (auto it = comGroup.comKeys.begin(); it != comGroup.comKeys.end(); ++it)
	{
		if (!colKeys.empty())
		{
			colKeys += ",";
		}
		colKeys += fill((*it)->col, (*it)->length());
		

		for (size_t i = 0; i < thick; ++i)
		{
			if (!vecKeyValue1[i].empty())
			{
				vecKeyValue1[i] += ",";
			}
			vecKeyValue1[i] += fill((*it)->vecStr1[i], (*it)->length());
			
			if (!vecKeyValue2[i].empty())
			{
				vecKeyValue2[i] += ",";
			}
			vecKeyValue2[i] += fill((*it)->vecStr2[i], (*it)->length());
		}
	}
	
	for (auto it = comGroup.comUnits.begin(); it != comGroup.comUnits.end(); ++it)
	{
		columns += fill((*it)->col, (*it)->length());
		columns += ",";

		
		for (size_t i = 0; i < thick; ++i)
		{
			vecValue1[i] += fill((*it)->vecStr1[i], (*it)->length());
			vecValue1[i] += ",";
			vecValue2[i] += fill((*it)->vecStr2[i], (*it)->length());
			vecValue2[i] += ",";
		}
	}

	if (columns.empty())
	{
		return "";
	}

	string str = colKeys.append(";").append(columns).append("\r\n");
	for (size_t i = 0; i < vecValue1.size(); ++i)
	{
		str.append(vecKeyValue1[i]).append(";").append(vecValue1[i]).append("\r\n");
		str.append(vecKeyValue2[i]).append(";").append(vecValue2[i]).append("\r\n");
	}

	return str;	
}