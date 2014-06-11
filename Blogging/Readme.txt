Использование Code First для создания базы данных
http://msdn.microsoft.com/ru-RU/data/jj193542

Error: Unable to determine the DbProviderFactory type for connection of type 'System.Data.SqlClient.SqlConnection'.
Reason: In machine.config file there are a duplicate <DbProviderFactories> element.
Resolve: Remove the extra "DbProviderFactories" section in the machine.Config file in the appropriate Framework version folder. 
	(On the 64bit client this situation existed in both 64 and 32bit configurations.)
	C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\machine.config 
	C:\Windows\Microsoft.NET\Framework64\v4.0.30319\Config\machine.config
Source: http://social.msdn.microsoft.com/Forums/en-US/f2a19487-6d38-4a79-a809-d3efe4c9d9fe/unable-to-determine-the-provider-name-for-connection-of-type-systemdatasqlclientsqlconnection?forum=adodotnetentityframework
