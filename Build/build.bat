set /p version=please set versionNum (E.G majorVersion.minorVersion.FixVersion):
echo %version% > version.txt

set workingDir=%cd%

for /f "delims=[" %%i in (vspath.txt) do set vsPath=%%i

"%vsPath%\\devenv.exe" %workingDir%\..\B1DBCompare.sln /ReBuild "Release|X64"
"%vsPath%\\devenv.exe" %workingDir%\..\B1DBCompare.sln /ReBuild "Release|X86"

cd ..\Output.64
..\Tools\rar.exe a -r B1_DB_Compare_V%version%_X64.zip Release
cd ..\Output.86
..\Tools\rar.exe a -r B1_DB_Compare_V%version%_X86.zip Release

cd ..\B1DBCompare Versions
mkdir V%version%
copy ..\Output.64\B1_DB_Compare_V%version%_X64.zip V%version%
copy ..\Output.86\B1_DB_Compare_V%version%_X86.zip V%version%
cd V%version%
echo README (VERSION_%version%) > "whats new.txt"
echo Build Successfully....
pause