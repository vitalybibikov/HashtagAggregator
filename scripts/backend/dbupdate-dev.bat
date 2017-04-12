@echo off

echo Started

SET currentPath=%~dp0
SET apiPath=%~dp0\..\..\..\HashtagAggregator\WebAPI\HashtagAggregator.Data.DataAccess
SET authPath=%~dp0\..\..\..\HashtagAggregator\WebAPI\HashtagAggregator.IdentityServer

cd %apiPath% 

dotnet ef database update -e dev -c SqlApplicationDbContext

cd %authPath%

echo %authPath%

dotnet ef database update -e dev -c SqlIdentityDbContext
dotnet ef database update -e dev -c PersistedGrantDbContext
dotnet ef database update -e dev -c ConfigurationDbContext

cd %currentPath%

echo Finished

