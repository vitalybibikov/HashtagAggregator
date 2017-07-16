@echo off

echo Started

SET currentPath=%~dp0
SET apiPath=%~dp0\..\..\..\HashtagAggregator\WebAPI\src\HashtagAggregator

SET ASPNETCORE_ENVIRONMENT=dev

cd %apiPath%

echo %apiPath%

dotnet run 

cd %currentPath%

echo Finished