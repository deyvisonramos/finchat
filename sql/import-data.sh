#wait database for being ready
sleep 90s
#create database
/opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U SA -P "Yj819806Kd" -i create-database-script.sql