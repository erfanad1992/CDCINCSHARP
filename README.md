# CDCINCSHARP
detect any change on sql server db and specific table in c#

hi guys today i want to provide a c# console app that detect any changes on specific sql server table 
in future i will connect this code to efcore models and so on ...
i will explain step by step 

STEP_1
enable CDC in sql server 

USE {dbName};

-- Enable CDC for the table
EXEC sys.sp_cdc_enable_table
    @source_schema = N'dbo',
    @source_name = N'TableName',
    @role_name = NULL,
    @supports_net_changes = 1;

STEP_2
enable broker for a database 
ALTER DATABASE {dbName} SET ENABLE_BROKER WITH ROLLBACK IMMEDIATE

STEP_3
install package SqlTableDependency latest version and System.Data.SqlClient

