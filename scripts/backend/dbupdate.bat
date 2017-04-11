@echo off

echo Started

SET currentPath=%~dp0
SET apiPath=%~dp0\..\..\..\MyStudyProject\WebAPI\MyStudyProject.Data.DataAccess
SET authPath=%~dp0\..\..\..\MyStudyProject\WebAPI\MyStudyProject.IdentityServer

cd %apiPath% 

dotnet ef database update -e dev

cd %authPath%

echo %authPath%

dotnet ef database update -e dev -c SqlIdentityDbContext
dotnet ef database update -e dev -c PersistedGrantDbContext
dotnet ef database update -e dev -c ConfigurationDbContext

cd %currentPath%

echo Finished