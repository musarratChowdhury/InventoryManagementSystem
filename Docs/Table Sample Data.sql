use MyInventoryDb;
INSERT INTO PaymentType ( Name, Description, CreatedBy, CreationDate, ModifiedBy, ModificationDate, Rank, BusinessId, Version)
VALUES
    ('Credit Card', 'Payment via Credit Card', 101, '2023-07-31 09:00:00', NULL, NULL, 1, 'Business123', 1),
    ('Cash', 'Payment in Cash', 101, '2023-07-31 10:30:00', NULL, NULL, 2, 'Business456', 1),
    ( 'Bank Transfer', 'Payment via Bank Transfer', 101, '2023-07-31 11:45:00', NULL, NULL, 3, 'Business789', 1);
select * from PaymentType

--CUSTOMER TYPES

INSERT INTO CustomerType (Name, Description, CreatedBy, CreationDate, ModifiedBy, ModificationDate, Rank, BusinessId, Version)
VALUES
    ('Regular', 'Regular Customer', 101, '2023-07-31 09:00:00', NULL, NULL, 1, 'Business123', 1),
    ('Premium', 'Premium Customer', 101, '2023-07-31 10:30:00', NULL, NULL, 2, 'Business456', 1),
    ('VIP', 'VIP Customer', 101, '2023-07-31 11:45:00', NULL, NULL, 3, 'Business789', 1);
select * from CustomerType;

--Bill TYPES
INSERT INTO BillType (Name, Description, CreatedBy, CreationDate, ModifiedBy, ModificationDate, Rank, BusinessId, Version)
VALUES
    ('Product Bill', 'Bill for Product Order', 101, '2023-07-31 09:00:00', NULL, NULL, 1, 'Business123', 1),
    ('Service Bill', 'Bill for Service Order', 101, '2023-07-31 10:30:00', NULL, NULL, 2, 'Business456', 1);

select * from BillType;

--INVOICE TYPE
INSERT INTO InvoiceType (Name, Description, CreatedBy, CreationDate, ModifiedBy, ModificationDate, Rank, BusinessId, Version)
VALUES
    ('Refund', 'Refund Invoice', 102, '2023-08-01 14:15:00', NULL, NULL, 1, 'Business789', 1),
    ('Service', 'Service Invoice', 103, '2023-08-02 11:30:00', NULL, NULL, 2, 'BusinessXYZ', 1),
    ('Product', 'Product Invoice', 103, '2023-08-02 11:30:00', NULL, NULL, 3, 'BusinessXYZ', 1);

select * from InvoiceType

--SHIPMENT TYPES

INSERT INTO ShipmentType (Name, Description, Rank, Status, CreatedBy, CreationDate, ModifiedBy, ModificationDate, BusinessId, Version)
VALUES
    ('Standard', 'Standard Shipment', 1, 1, 101, '2023-07-31 09:00:00', NULL, NULL, 'Business123', 1),
    ('Express', 'Express Shipment', 2, 1, 101, '2023-07-31 10:30:00', NULL, NULL, 'Business456', 1);
select * from ShipmentType;

--INVOICE TYPES
INSERT INTO InvoiceType (Name, Description, CreatedBy, CreationDate, ModifiedBy, ModificationDate, Rank, BusinessId, Version)
VALUES
    ('Sales', 'Sales Invoice', 101, '2023-07-31 09:00:00', NULL, NULL, 1, 'Business123', 1),
    ('Purchase', 'Purchase Invoice', 101, '2023-07-31 10:30:00', NULL, NULL, 2, 'Business456', 1);
select * from InvoiceType;

--VENDOR TYPES
INSERT INTO VendorType (Name, Description, CreatedBy, CreationDate, ModifiedBy, ModificationDate, Rank, BusinessId, Version)
VALUES
    ('Supplier', 'Regular Supplier', 101, '2023-07-31 09:00:00', NULL, NULL, 1, 'Business123', 1),
    ('Manufacturer', 'Manufacturer Vendor', 101, '2023-07-31 10:30:00', NULL, NULL, 2, 'Business456', 1);
select * from VendorType;
--UNIT OF MEASUREMENT
INSERT INTO UnitOfMeasurement (Name, Description, CreatedBy, CreationDate, ModifiedBy, ModificationDate, Rank, BusinessId, Version)
VALUES
    ('Piece', 'Piece', 101, '2023-07-31 09:00:00', NULL, NULL, 1, 'Business123', 1),
    ('Pound', 'Pound', 101, '2023-07-31 10:30:00', NULL, NULL, 2, 'Business456', 1),
    ('Liter', 'Liter', 101, '2023-07-31 11:45:00', NULL, NULL, 3, 'Business789', 1),
    ('Kilogram', 'Kilogram', 101, '2023-07-31 12:30:00', NULL, NULL, 4, 'BusinessXYZ', 1);
select * from UnitOfMeasurement;
--PRODUCT CATEGORY
INSERT INTO ProductCategory (Name, Description, CreatedBy, CreationDate, ModifiedBy, ModificationDate, Rank, BusinessId, Version)
VALUES
    ('Electronics', 'Electronics Products', 101, '2023-07-31 09:00:00', NULL, NULL, 1, 'Business123', 1),
    ('Apparel', 'Apparel Products', 101, '2023-07-31 10:30:00', NULL, NULL, 2, 'Business456', 1),
    ('Home & Garden', 'Home and Garden Products', 101, '2023-07-31 11:45:00', NULL, NULL, 3, 'Business789', 1),
    ('Beauty & Personal Care', 'Beauty and Personal Care Products', 101, '2023-07-31 12:30:00', NULL, NULL, 4, 'BusinessXYZ', 1);
	INSERT INTO [dbo].[ProductCategory]
    ([Name]
    ,[Description]
    ,[Rank]
    ,[Status]
    ,[CreatedBy]
    ,[CreationDate]
    ,[ModifiedBy]
    ,[ModificationDate]
    ,[Version]
    ,[BusinessId])
VALUES
    ('Electronics', -- Name (nvarchar(25))
    'Electronics and devices category', -- Description (nvarchar(255))
    1, -- Rank (int)
    1, -- Status (int)
    12345, -- CreatedBy (bigint)
    GETDATE(), -- CreationDate (datetime)
    12345, -- ModifiedBy (bigint)
    GETDATE(), -- ModificationDate (datetime)
    1, -- Version (int)
    'Business123' -- BusinessId (nvarchar(max))
);
-- Category 2
INSERT INTO [dbo].[ProductCategory]
    ([Name]
    ,[Description]
    ,[Rank]
    ,[Status]
    ,[CreatedBy]
    ,[CreationDate]
    ,[ModifiedBy]
    ,[ModificationDate]
    ,[Version]
    ,[BusinessId])
VALUES
    ('Mobile Devices',
    'Smartphones, tablets, and wearable devices',
    2,
    1,
    12345,
    GETDATE(),
    12345,
    GETDATE(),
    1,
    'Business123');

-- Category 3
INSERT INTO [dbo].[ProductCategory]
    ([Name]
    ,[Description]
    ,[Rank]
    ,[Status]
    ,[CreatedBy]
    ,[CreationDate]
    ,[ModifiedBy]
    ,[ModificationDate]
    ,[Version]
    ,[BusinessId])
VALUES
    ('Computer Accessories',
    'Keyboards, mice, monitors, and cables',
    3,
    1,
    12345,
    GETDATE(),
    12345,
    GETDATE(),
    1,
    'Business123');

-- Category 4
INSERT INTO [dbo].[ProductCategory]
    ([Name]
    ,[Description]
    ,[Rank]
    ,[Status]
    ,[CreatedBy]
    ,[CreationDate]
    ,[ModifiedBy]
    ,[ModificationDate]
    ,[Version]
    ,[BusinessId])
VALUES
    ('Networking Equipment',
    'Routers, switches, and networking accessories',
    4,
    1,
    12345,
    GETDATE(),
    12345,
    GETDATE(),
    1,
    'Business123');

-- Category 5
INSERT INTO [dbo].[ProductCategory]
    ([Name]
    ,[Description]
    ,[Rank]
    ,[Status]
    ,[CreatedBy]
    ,[CreationDate]
    ,[ModifiedBy]
    ,[ModificationDate]
    ,[Version]
    ,[BusinessId])
VALUES
    ('Consumer Electronics',
    'Televisions, home audio systems, cameras',
    5,
    1,
    12345,
    GETDATE(),
    12345,
    GETDATE(),
    1,
    'Business123');

-- Category 6
INSERT INTO [dbo].[ProductCategory]
    ([Name]
    ,[Description]
    ,[Rank]
    ,[Status]
    ,[CreatedBy]
    ,[CreationDate]
    ,[ModifiedBy]
    ,[ModificationDate]
    ,[Version]
    ,[BusinessId])
VALUES
    ('Audio and Music Equipment',
    'Headphones, speakers, musical instruments',
    6,
    1,
    12345,
    GETDATE(),
    12345,
    GETDATE(),
    1,
    'Business123');

select * from ProductCategory;


INSERT INTO Customer ( CustomerTypeId, FirstName, LastName, Address, Email, Phone, Status, CreatedBy, CreationDate, ModifiedBy, ModificationDate, Rank, BusinessId, Version)
VALUES
    ( 1, 'John', 'Doe', '123 Main St', 'john@example.com', '123-456-7890', 1, 0, '2023-08-10', 0, '2023-08-10', 1, 'Business123', 1),
    ( 2, 'Jane', 'Smith', '456 Elm St', 'jane@example.com', '987-654-3210', 1, 0, '2023-08-10', 0, '2023-08-10', 2, 'Business456', 1),
    ( 3, 'Michael', 'Johnson', '789 Oak St', 'michael@example.com', '555-123-4567', 1, 0, '2023-08-10', 0, '2023-08-10', 3, 'Business789', 1);




use MyInventoryDb;
select * from SalesOrder;
select * from Invoice;
select * from Bill;
select * from SalesOrderLine;
select * from Customer;
select * from Product;
select * from AspNetUsers;
delete  from AspNetUsers;

select * from PurchaseOrder;
select * from PurchaseOrderLine;

delete from PurchaseOrderLine;
delete from PurchaseOrder;
delete from SalesOrderLine;
delete from SalesOrder;

delete from shipment;
delete from bill;
delete from invoice;
delete from PaymentReceived;
Update SalesOrder
	SET PaymentStatus = 1,
	ShipmentStatus = 1,
	InvoiceId = 4
WHERE Id =16; 
UPDATE SalesOrder
SET CreationDate = '2023-06-12'
WHERE Id = 49;
select * from SalesOrder;

ALTER TABLE SalesOrder

ADD DueAmount DECIMAL(10,2) NOT NULL DEFAULT(0);

use MyInventoryDb;
   SELECT
    MONTH(CreationDate) AS Month,
    SUM(TotalAmount) AS TotalSales
FROM
    SalesOrder
WHERE
    IsArchived = 0
GROUP BY
    MONTH(CreationDate)
ORDER BY
    Month;


Select * from Product;
Select * from ProductCategory;

SELECT ProductCategoryId, COUNT(*) AS NUMBEROFProducts
FROM Product 
GROUP BY ProductCategoryId;

use MyInventoryDb;
SELECT C.Name AS CategoryName, SUM(P.StockQuantity) AS TotalStockQuantity
FROM ProductCategory C
LEFT JOIN Product P ON C.Id = P.ProductCategoryId
GROUP BY C.Name;

select StockQuantity from Product;