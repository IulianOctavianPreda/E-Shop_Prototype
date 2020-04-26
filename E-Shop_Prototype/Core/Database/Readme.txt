Open Package Manager Console
Select Database.E-Shop_Mini

Run for initial migration
Add-Migration InitialCreate -Context SqlServerContext -Project E-Shop_Mini -StartUpProject E-Shop_Mini

For migrations
Add-Migration<name> -Context SqlServerContext -Project E-Shop_Mini -StartUpProject E-Shop_Mini
Remove-Migration -Context SqlServerContext -Project E-Shop_Mini -StartUpProject E-Shop_Mini

For updating database

Update-Database -Context SqlServerContext -Project E-Shop_Mini -StartUpProject E-Shop_Mini