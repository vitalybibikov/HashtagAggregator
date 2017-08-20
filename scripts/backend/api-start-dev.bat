@echo off

echo Started

SET currentPath=%~dp0
SET apiPath=%~dp0\..\..\..\HashtagAggregator\WebAPI\src\HashtagAggregator

setx ASPNETCORE_ENVIRONMENT dev

cd %apiPath%

echo %apiPath%

dotnet run --no-launch-profile

cd %currentPath%

echo Finished