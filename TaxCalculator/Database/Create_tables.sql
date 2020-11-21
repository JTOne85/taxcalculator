use [Taxman] 
go
-- Create the tax type table
if not exists (select * from sysobjects where name = 'TaxType' and xtype='U')
begin
    create table TaxType
	     ( Id                 int           not null,
		   TaxTypeDescription nvarchar(255) not null )
	Print(N'Taxtype table created successfully')
end
else begin
    Print (N'The TaxType table already exists')
end

-- Create the PostalCode table
if not exists (select * from sysobjects where name = 'PostalCode' and xtype='U')
begin
    create table PostalCode
	     ( Id         int          not null,
		   PostalCode nvarchar(10) not null,
		   TaxTypeId  int          not null,
		   constraint PK_postcode primary key (PostalCode, TaxTypeId))
	Print(N'PostalCode table created successfully')
end
else begin
    Print (N'The PostalCode table already exists')
end

-- Create tax bands table
if not exists (select * from sysobjects where name = 'TaxBands' and xtype='U')
begin
    create table TaxBands
	     ( Id          int          not null,
		   TaxRateCode nvarchar(3)  not null primary key,
		   LowerLimit  decimal(9,3)     null,
		   UpperLimit  decimal(9,3)     null,
		   IsActive    bit          not null,
		   IsDeleted   bit          not null,
		   CreatedDate datetime         null,
		   UpdatedDate datetime         null)
	Print(N'TaxBands table created successfully')
end
else begin
    Print (N'The TaxBands table already exists')
end

-- Create tax rates table
if not exists (select * from sysobjects where name = 'TaxRates' and xtype='U')
begin
    create table TaxRates
	     ( Id          int          not null,
		   TaxBandId   int          not null,
		   TaxTypeId   int          not null,
		   RateValue   decimal(8,3) not null, 
		   IsActive    bit          not null,
		   IsDeleted   bit          not null,
		   CreatedDate datetime         null,
		   UpdatedDate datetime         null)
	Print(N'TaxRates table created successfully')
end
else begin
    Print (N'The TaxRates table already exists')
end

-- Create tax calculations table

if not exists (select * from sysobjects where name = 'TaxCalculations' and xtype='U')
begin
    create table TaxCalculations
	     ( Id                 int not null,
		   PostalCode         nvarchar(10) not null,
		   TaxTypeId          int not null,
		   TaxRateId          int not null,
		   TaxBandId          int not null,
		   IncomeValue        decimal(9,2) not null,
		   CalculatedTaxValue decimal (10,3) not null,
		   DateCreated        datetime not null
		)
	Print(N'TaxCalculations table created successfully')
end
else begin
    Print (N'The TaxCalculations table already exists')
end