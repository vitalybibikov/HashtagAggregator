@echo off

echo Started

SET currentPath=%~dp0
SET apiPath=%~dp0\..\..\..\MyStudyProject\WebAPI\src\MyStudyProject

SET ASPNETCORE_ENVIRONMENT=dev

cd %apiPath%

echo %apiPath%

dotnet run 

cd %currentPath%

echo Finished