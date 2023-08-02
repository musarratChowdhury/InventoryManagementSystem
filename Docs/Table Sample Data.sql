use MyInventoryDb;
INSERT INTO PaymentType ( Name, Description, CreatedBy, CreationDate, ModifiedBy, ModificationDate, Rank, BusinessId, Version)
VALUES
    ('Credit Card', 'Payment via Credit Card', 101, '2023-07-31 09:00:00', NULL, NULL, 1, 'Business123', 1),
    ('Cash', 'Payment in Cash', 101, '2023-07-31 10:30:00', NULL, NULL, 2, 'Business456', 1),
    ( 'Bank Transfer', 'Payment via Bank Transfer', 101, '2023-07-31 11:45:00', NULL, NULL, 3, 'Business789', 1);
select * from AspNetUsers
select * from PaymentType