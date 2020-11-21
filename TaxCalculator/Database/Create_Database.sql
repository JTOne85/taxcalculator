-- Create the database
if not exists (select * from sys.databases where name = 'Taxman')
begin
    create database [Taxman]
	print(N'Database Taxman created successfully')
end
else
begin
    print (N'A database called Taxman already exists')
end
go