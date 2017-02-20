# TSqlRules
TSQL Static Code Analysis Rules for SQL Server

![alt text](https://ashleyglee.visualstudio.com/_apis/public/build/definitions/3885efb0-fffb-4099-a142-12834cd01ca9/1/badge "Build Info")

## Project Description
This library extends the SSDT (SQL Server Data Tools) functionality for creating static code analysis rules for Database Projects.  The TSqlRules DLL can be added to Visual Studio to display errors and warnings inside the "Error List" window and can also be used with MSBuild.

Based on functionality described here:
* [Overview of Extensibility for Database Code Analysis Rules](https://msdn.microsoft.com/en-us/library/dn632173(v=vs.103).aspx)
* [DACFx Reference](https://msdn.microsoft.com/en-us/library/dn645454.aspx)
* [ScriptDom Namespace](https://technet.microsoft.com/en-us/library/microsoft.sqlserver.transactsql.scriptdom(v=sql.110).aspx)

## Usage Notes
The following references need to be updated if you are running different verions of Visual Studio.  Currently they are configured for Visual Studio 2015 and are included in a Library folder to allow this to build.  SSDT installs those DLL in the below referenced paths.
* Microsoft.Data.Tools.Schema.Sql.dll
* Microsoft.Data.Tools.Utilities.dll
* Microsoft.SqlServer.Dac.dll
* Microsoft.SqlServer.Dac.Extensions.dll
* Microsoft.SqlServer.TransactSql.ScriptDom.dll

Visual Studio 2013:
* C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\Extensions\Microsoft\SQLDB\DAC\120\
* C:\Program Files (x86)\Microsoft SQL Server\120\SDK\Assemblies

Visual Studio 2015:
* C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\Extensions\Microsoft\SQLDB\DAC\130\

Note: the path you copy the new rules DLL and PDB file to need to match the directory above for your VS version.

If you are adding as an extension to Visual Studio, the assembly needs to be signed.
* Right-click the **TSqlRules** project and select Properties.
* Click the Signing menu.
* Check the "Sign the Assembly" box is checked.
* In the **Choose a strong name key file** box, choose **<New…>** and enter "MyKeyRef" in the **Create Strong Name Key** dialog box, then enter a password.
* On the File menu, click Save All.
* On the Build menu, click Build Solution.
