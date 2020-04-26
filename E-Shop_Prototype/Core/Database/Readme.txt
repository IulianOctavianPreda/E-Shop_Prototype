Open Package Manager Console
Select Core

Run for initial migration
Add-Migration InitialCreate -Context SqlServerContext -Project Core -StartUpProject Core

For migrations
Add-Migration<name> -Context SqlServerContext -Project Core -StartUpProject Core
Remove-Migration -Context SqlServerContext -Project Core -StartUpProject Core

For updating database

Update-Database -Context SqlServerContext -Project Core -StartUpProject Core