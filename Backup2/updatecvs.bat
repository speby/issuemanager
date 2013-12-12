@echo off

set CVSSHARE=\\dotnet\wwwroot
set CVSPROJECT=issuemanager

if not exist z:\%CVSPROJECT%\updatecvs.bat net use z: /d 2> nul
if not exist z:\%CVSPROJECT%\updatecvs.bat net use z: %CVSSHARE%
if not exist z:\%CVSPROJECT%\updatecvs.bat echo ERROR: Could not mount [%CVSSHARE%] locally!
if not exist z:\%CVSPROJECT%\updatecvs.bat goto end
set HOME=z:\bin
rem *** set CVS_RSH=z:\bin\plink.exe -P 2222 -i z:\bin\id_rsa
rem *** set CVSROOT=:pserver:raptor@swingline.ameripay.com:/usr/local/cvsroot
cd /d z:\%CVSPROJECT%\
z:\bin\cvs.exe -d :pserver:raptor@swingline.ameripay.com:/usr/local/cvsroot update -d
:end
echo:
pause