# GW_FSW_Training
Treinamento .NET Core GlobalWeb
Migration example =>
$env:DBCONN="Host=localhost;Port=5432;Database=postgres;User Id=postgres;Password=postgres;"
Add-Migration GenerateTables -OutputDir Database/Migrations -Context Context
update-database
