cd ..\..\packages
nuget.exe install Microsoft.Data.Tools.Msbuild -ExcludeVersion -Source https://api.nuget.org/v3/index.json
cd Microsoft.Data.Tools.Msbuild*\lib\net46
sqlpackage.exe /a:publish /Profile:..\..\..\..\tests\DatabaseViewer.TestDatabase\TestDatabase.publish.xml /TargetDatabaseName:unittest /Sourcefile:..\..\..\..\tests\bin\debug\DatabaseViewer.TestDatabase.dacpac