set /p version=please set versionNum:
echo %version% > version.txt

C:
cd C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE
devenv D:\B1DBCompare\B1DBCompare.sln /Build "Release|X64"
devenv D:\B1DBCompare\B1DBCompare.sln /Build "Release|X86"
D:
cd ..\Output.64

rar a -r B1_DB_Compare_V%version%_X64.zip Release
cd ..\Output.86
rar a -r B1_DB_Compare_V%version%_X86.zip Release

cd ..\B1DBCompare Versions
mkdir V%version%
copy ..\Output.64\B1_DB_Compare_V%version%_X64.zip V%version%
copy ..\Output.86\B1_DB_Compare_V%version%_X86.zip V%version%
cd V%version%
echo nul > "whats new.txt"
pause