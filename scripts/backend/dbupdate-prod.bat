@echo off

echo Started

SET currentPath=%~dp0
SET apiPath=%~dp0\..\..\..\HashtagAggregator\WebAPI\HashtagAggregator.Data.DataAccess
SET authPath=%~dp0\..\..\..\HashtagAggregator\WebAPI\HashtagAggregator.IdentityServer

cd %apiPath% 

dotnet ef database update -e prod -c SqlApplicationDbContext


