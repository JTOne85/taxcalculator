use [Taxman] 
go

IF OBJECT_ID (N'dbo.TaxType', N'U') IS NOT NULL  
insert TaxType
     ( Id, TaxTypeDescription)
values
     ( 1, 'Flat value'),
	 ( 2, 'Flat rate'),
	 ( 3, 'Progressive rate')
go

IF OBJECT_ID (N'dbo.PostalCode', N'U') IS NOT NULL  
insert PostalCode
     ( Id, PostalCode, TaxTypeId)
values
     ( 1, '7441', 3),
	 ( 2, 'A100', 1),
	 ( 3, '7000', 2),
	 ( 4, '1000', 3)
go

IF OBJECT_ID (N'dbo.TaxBands', N'U') IS NOT NULL  
insert TaxBands
     ( Id, 
	   TaxRateCode, 
	   LowerLimit, 
	   UpperLimit, 
	   IsActive, 
	   IsDeleted, 
	   CreatedDate)
values (1, 'FV0', 0, 199999.99, 1, 0, getDate()),
       (2, 'FV1', 200000, null, 1, 0, getDate()),
	   (3, 'FR', null, null, 1, 0, getDate()),
	   (4, 'P0', 0, 8350.99, 1, 0, getDate()),
	   (5, 'P1', 8351.00, 33950.99, 1, 0, getDate()),
	   (6, 'P2', 33951.00, 82250.99, 1, 0, getDate()),
	   (7, 'P3', 82251.00, 171550.99, 1, 0, getDate()),
	   (8, 'P4', 171551.00, 372950.99, 1, 0, getDate()),
	   (9, 'P5', 372951.00, null, 1, 0, getDate())
go

IF OBJECT_ID (N'dbo.TaxRates', N'U') IS NOT NULL
insert TaxRates
     ( Id, TaxBandId, TaxTypeId, RateValue)
values
     ( 1, 1, 1, 0.05, 1, 0, getDate()),
	 ( 2, 2, 1, 10000, 1, 0, getDate()),
	 ( 3, 3, 2, 0.175, 1, 0, getDate()),
	 ( 4, 4, 3, 0.1, 1, 0, getDate()),
	 ( 5, 5, 3, 0.15, 1, 0, getDate()),
	 ( 6, 6, 3, 0.25, 1, 0, getDate()),
	 ( 7, 7, 3, 0.28, 1, 0, getDate()),
	 ( 8, 8, 3, 0.33, 1, 0, getDate()),
	 ( 9, 9, 3, 0.35, 1, 0, getDate()),


