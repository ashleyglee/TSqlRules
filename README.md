# TSqlRules
TSQL Static Code Analysis Rules for SQL Server

## Project Description
This library extends the SSDT (SQL Server Data Tools) functionality for creating static code analysis rules for Database Projects.  The TSqlRules DLL can be added to Visual Studio to display errors and warnings inside the "Error List" window and can also be used with MSBuild.

Based on functionality described here:
* [Overview of Extensibility for Database Code Analysis Rules](https://msdn.microsoft.com/en-us/library/dn632173(v=vs.103).aspx)
* [DACFx Reference](https://msdn.microsoft.com/en-us/library/dn645454.aspx)
* [ScriptDom Namespace](https://technet.microsoft.com/en-us/library/microsoft.sqlserver.transactsql.scriptdom(v=sql.110).aspx)

## Usage Notes
The following references need to be updated if you are running different verions of Visual Studio.  Currently they are configured to reference Visual Studio 2015 installation path.
* Microsoft.Data.Tools.Schema.Sql.dll
* Microsoft.Data.Tools.Utilities.dll
* Microsoft.SqlServer.Dac.dll
* Microsoft.SqlServer.Dac.Extensions.dll
* Microsoft.SqlServer.TransactSql.ScriptDom.dll

Visual Studio 2013: 
* C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\Extensions\Microsoft\SQLDB\DAC\120\

Visual Studio 2015:
* C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\Extensions\Microsoft\SQLDB\DAC\130\

Note: the path you copy the new rules DLL and PDB file to need to match the directory above for your VS version.

If you are adding as an extension to Visual Studio, the assembly needs to be signed.  Please sign the key with a different value than the one included in the Notes.txt file.
* Right-click the TSqlRules project and select Properties.
* Click the Signing menu.
* Ensure the "Sign the Assembly" box is checked.
* Click "Change password" and use a new password.
* On the File menu, click Save All.
* On the Build menu, click Build Solution.
