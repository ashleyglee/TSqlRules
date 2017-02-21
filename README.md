# TSqlRules
TSQL Static Code Analysis Rules for SQL Server

![alt text](https://ashleyglee.visualstudio.com/_apis/public/build/definitions/3885efb0-fffb-4099-a142-12834cd01ca9/1/badge "Build Info")

## Project Description
This library extends the SSDT (SQL Server Data Tools) functionality for creating static code analysis rules for Database Projects.  The TSqlRules DLL can be added to Visual Studio to display errors and warnings inside the "Error List" window and can also be used with MSBuild.

Based on functionality described here:
* [Overview of Extensibility for Database Code Analysis Rules](https://msdn.microsoft.com/en-us/library/dn632173(v=vs.103).aspx)
* [DACFx Reference](https://msdn.microsoft.com/en-us/library/dn645454.aspx)
* [ScriptDom Namespace](https://technet.microsoft.com/en-us/library/microsoft.sqlserver.transactsql.scriptdom(v=sql.110).aspx)

## Rule Overview

Design
* SRD0001 - Table missing Primary Key

Performance
* SRP0001 - Avoid using WAITFOR DELAY

Naming
* SRN0001 - Non-alphanumeric Table name
* SRN0002 - Column names should contain only alphanumeric characters.
* SRN0003 - View should start with v and contain only alphanumeric characters. (vGetPerson)
* SRN0004 - Trigger should start with tr and contain only alphanumeric characters. (trPerson)
* SRN0005 - Stored Procedure should start with st and contain only alphanumeric characters. (stUpdatePerson)
* SRN0006 - User Function should start with uf and contain only alphanumeric characters. (ufGetPersonInfo)
* SRN0007 - Avoid using view in table names.

## Usage Notes
The following references need to be updated if you are running different verions of Visual Studio.  Currently they are configured for Visual Studio 2015 and are included in a Library folder to allow this to build online at [Visual Studio Team Services](https://www.visualstudio.com/team-services/).  SSDT installs those DLL in the below referenced paths that you can use on your local.
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

## Microsoft Rules
[Microsoft Rules](https://msdn.microsoft.com/en-us/library/dd172133(v=vs.100).aspx) included in Code Analysis by default:

Design
* SR0001 - Avoid SELECT * in stored procedures, views, and table-valued functions.
* SR0008 - Consider using SCOPE_IDENTITY instead of @@IDENTITY.
* SR0009 - Avoid using types of variable length that are size 1 or 2.
* SR0010 - Avoid using deprecated syntax when you join tables or views.
* SR0013 - Specify values for output parameters in all code paths.
* SR0014 - Maintain compatability between data types.

Naming
* SR0011 - Avoid using special characters in object names.
* SR0012 - Avoid using reserved words for type names.
* SR0016 - Avoid using sp_ as a prefix for stored procedures.

Performance
* SR0004 - Avoid using columns that do not have an index as test expressions in IN predicates.
* SR0005 - Avoid using patterns that start with "%" in LIKE predicates.
* SR0006 - In the comparison, simplify the expression that includes indexed columns.
* SR0007 - Use ISNULL(column, default value) on nullable columns in expressions.
* SR0015 - Extract deterministic function calls from WHERE expressions.
