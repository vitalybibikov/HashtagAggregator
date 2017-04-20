@echo off

echo Started

SET currentPath=%~dp0
SET apiPath=%~dp0\..\..\..\HashtagAggregator\WebAPI\HashtagAggregator.Data.DataAccess

cd %apiPath% 

dotnet ef migrations add HashTagMultilple5 -e dev -c SqlApplicationDbContext

cd %currentPath%

echo Finished

