#choco install reportgenerator.portable -y
#choco install opencover.portable -y
OpenCover.Console.exe -register:user -target:"C:\Program Files\dotnet\dotnet.exe" -targetargs:"test --logger:trx;LogFileName=results.trx /p:DebugType=full test\UnitTest\SCIQuoting.Webapi.Test\SCIQuoting.Webapi.Test.csproj" -filter:"+[SCIQuoting*]* -[*.Test*]*" -oldStyle -output:"OpenCover.xml"
reportgenerator -reports:OpenCover.xml -targetdir:C:\report