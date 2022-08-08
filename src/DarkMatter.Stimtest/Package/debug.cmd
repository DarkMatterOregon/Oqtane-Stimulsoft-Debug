XCOPY "..\Client\bin\Debug\net6.0\DarkMatter.Stimtest.Client.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net6.0\" /Y
XCOPY "..\Client\bin\Debug\net6.0\DarkMatter.Stimtest.Client.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net6.0\" /Y
XCOPY "..\Server\bin\Debug\net6.0\DarkMatter.Stimtest.Server.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net6.0\" /Y
XCOPY "..\Server\bin\Debug\net6.0\DarkMatter.Stimtest.Server.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net6.0\" /Y
XCOPY "..\Shared\bin\Debug\net6.0\DarkMatter.Stimtest.Shared.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net6.0\" /Y
XCOPY "..\Shared\bin\Debug\net6.0\DarkMatter.Stimtest.Shared.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net6.0\" /Y
XCOPY "..\Server\wwwroot\*" "..\..\oqtane.framework\Oqtane.Server\wwwroot\" /Y /S /I
XCOPY "..\Server\wwwroot\reports\*" "..\..\oqtane.framework\Oqtane.Server\reports\" /Y /S /I
XCOPY "..\Server\data\*" "..\..\oqtane.framework\Oqtane.Server\data" /Y /S /I
