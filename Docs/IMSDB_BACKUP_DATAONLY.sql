USE [MyInventoryDb]
GO
SET IDENTITY_INSERT [dbo].[CustomerType] ON 
GO
INSERT [dbo].[CustomerType] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (1, N'Regular', N'Regular Customer', 1, 1, 101, CAST(N'2023-07-31T09:00:00.000' AS DateTime), NULL, NULL, 1, N'Business123')
GO
INSERT [dbo].[CustomerType] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (2, N'Premium', N'Premium Customer', 2, 1, 101, CAST(N'2023-07-31T10:30:00.000' AS DateTime), NULL, NULL, 1, N'Business456')
GO
INSERT [dbo].[CustomerType] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (3, N'VIP', N'VIP Customer', 3, 1, 101, CAST(N'2023-07-31T11:45:00.000' AS DateTime), NULL, NULL, 1, N'Business789')
GO
SET IDENTITY_INSERT [dbo].[CustomerType] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (1, 1, N'John', N'Doe', N'123 Main St', N'john@example.com', N'+1 (315) 989-9279', 1, 0, CAST(N'2023-08-10T00:00:00.000' AS DateTime), 8, CAST(N'2023-08-22T17:26:04.337' AS DateTime), 1, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (3, 3, N'Michaela', N'Johnson', N'789 Oak St', N'michael@example.com', N'+1 (995) 227-1316', 1, 0, CAST(N'2023-08-10T00:00:00.000' AS DateTime), 8, CAST(N'2023-08-22T17:25:39.350' AS DateTime), 2, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (4, 2, N'Chase', N'Ball', N'Nostrum dolorem qui ', N'hyhova@mailinator.com', N'+1 (435) 236-6811', 1, 8, CAST(N'2023-08-13T14:59:14.603' AS DateTime), 8, CAST(N'2023-08-16T15:36:15.237' AS DateTime), 3, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (5, 3, N'Cheryl', N'Schmidt', N'Omnis quibusdam enim', N'birobirez@mailinator.com', N'+1 (105) 654-4846', 1, 8, CAST(N'2023-08-13T15:15:47.117' AS DateTime), 8, CAST(N'2023-08-16T15:31:36.180' AS DateTime), 8, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (6, 3, N'Noel', N'Clark', N'Dolor dicta tempor v', N'pidyr@mailinator.com', N'+1 (895) 952-8864', 1, 8, CAST(N'2023-08-13T15:39:03.567' AS DateTime), 8, CAST(N'2023-08-16T15:21:03.037' AS DateTime), 27, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (8, 1, N'Abbot', N'Michael', N'Obcaecati ut atque f', N'xugeliq@mailinator.com', N'+1 (351) 493-5393', 1, 8, CAST(N'2023-08-13T15:44:35.733' AS DateTime), 8, CAST(N'2023-08-16T15:37:11.293' AS DateTime), 11, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (9, 1, N'Nash', N'Humphrey', N'Eveniet beatae porr', N'muhogew@mailinator.com', N'+1 (197) 425-2185', 1, 8, CAST(N'2023-08-13T15:45:11.673' AS DateTime), 8, CAST(N'2023-08-16T15:37:57.453' AS DateTime), 7, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (10, 1, N'Abbot', N'Jacobson', N'Modi culpa enim ea ', N'poden@mailinator.com', N'+1 (659) 156-1585', 1, 8, CAST(N'2023-08-13T15:54:20.153' AS DateTime), 8, CAST(N'2023-08-16T17:32:48.743' AS DateTime), 4, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (11, 2, N'Holmes', N'Golden', N'Consequat Fuga Off', N'fajinah@mailinator.com', N'+1 (707) 767-8952', 0, 8, CAST(N'2023-08-13T15:54:41.530' AS DateTime), 8, CAST(N'2023-08-16T17:57:29.370' AS DateTime), 5, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (12, 3, N'Tyrone', N'Bruce', N'Esse exercitationem', N'revomydaxi@mailinator.com', N'+1 (817) 659-7636', 0, 8, CAST(N'2023-08-13T15:55:04.513' AS DateTime), 8, CAST(N'2023-08-16T16:36:26.827' AS DateTime), 6, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (13, 1, N'Kennan', N'Singleton', N'Rerum harum dolore d', N'xacegez@mailinator.com', N'+1 (773) 866-4693', 1, 8, CAST(N'2023-08-13T16:06:46.137' AS DateTime), 8, CAST(N'2023-08-14T16:37:04.143' AS DateTime), 12, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (14, 2, N'Kibo', N'Ross', N'Iusto ea in velit in', N'hogicu@mailinator.com', N'+1 (122) 656-8452', 1, 8, CAST(N'2023-08-13T16:06:54.273' AS DateTime), 8, CAST(N'2023-08-17T09:49:22.920' AS DateTime), 9, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (15, 1, N'Dustin', N'Carter', N'Exercitationem nobis', N'huse@mailinator.com', N'+1 (269) 744-7587', 1, 8, CAST(N'2023-08-13T16:07:12.377' AS DateTime), 8, CAST(N'2023-08-16T14:31:18.333' AS DateTime), 10, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (16, 1, N'Barrett', N'Robertson', N'Et doloribus magnam ', N'celat@mailinator.com', N'+1 (281) 688-6152', 0, 8, CAST(N'2023-08-13T16:17:45.367' AS DateTime), 8, CAST(N'2023-08-16T14:31:25.820' AS DateTime), 13, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (18, 1, N'Ina', N'Logan', N'Rem nihil magnam vel', N'myzusy@mailinator.com', N'+1 (939) 706-7592', 1, 8, CAST(N'2023-08-14T10:23:10.710' AS DateTime), 8, CAST(N'2023-08-14T10:29:47.993' AS DateTime), 14, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (19, 1, N'Gwendolyn', N'Mccarty', N'Tempore aspernatur ', N'dajene@mailinator.com', N'+1 (119) 615-4055', 1, 8, CAST(N'2023-08-14T11:20:17.173' AS DateTime), NULL, NULL, 15, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (20, 3, N'Roanna', N'Montoya', N'Adipisci non consequ', N'qivy@mailinator.com', N'+1 (969) 527-7659', 1, 8, CAST(N'2023-08-14T11:21:05.380' AS DateTime), NULL, NULL, 16, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (21, 1, N'Deanna', N'Alvarado', N'Dolor eos fugiat vo', N'mycil@mailinator.com', N'+1 (874) 622-7123', 1, 8, CAST(N'2023-08-14T11:24:08.213' AS DateTime), NULL, NULL, 17, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (22, 3, N'Melissa', N'Sweeney', N'Id provident vel ve', N'fohadeboju@mailinator.com', N'+1 (931) 508-6296', 1, 8, CAST(N'2023-08-14T14:34:07.697' AS DateTime), NULL, NULL, 18, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (23, 1, N'Victoria', N'Brady', N'Consequuntur qui eni', N'qivuzadyd@mailinator.com', N'+1 (551) 948-3381', 1, 8, CAST(N'2023-08-14T14:38:33.780' AS DateTime), NULL, NULL, 19, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (24, 1, N'Jeremy', N'Guzman', N'Do quidem qui eiusmo', N'levewyv@mailinator.com', N'+1 (648) 366-3332', 1, 8, CAST(N'2023-08-14T14:45:43.057' AS DateTime), NULL, NULL, 20, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (25, 3, N'Rachel', N'Woods', N'Laudantium voluptat', N'bytuzim@mailinator.com', N'+1 (343) 292-9342', 1, 8, CAST(N'2023-08-14T14:45:52.233' AS DateTime), NULL, NULL, 21, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (26, 3, N'Quinlan', N'Espinoza', N'Qui sit similique q', N'lorikipuz@mailinator.com', N'+1 (791) 674-1808', 1, 8, CAST(N'2023-08-14T14:46:11.300' AS DateTime), NULL, NULL, 22, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (27, 1, N'Marshall', N'Cochran', N'Odio irure in doloru', N'jojojeqyh@mailinator.com', N'+1 (503) 782-2852', 1, 8, CAST(N'2023-08-14T14:46:23.847' AS DateTime), NULL, NULL, 23, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (28, 3, N'Orla', N'Daniel', N'Aut et consectetur ', N'pywuwofufu@mailinator.com', N'+1 (282) 377-3341', 1, 8, CAST(N'2023-08-14T14:46:30.533' AS DateTime), NULL, NULL, 24, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (29, 2, N'Merrill', N'Sharp', N'Odio deleniti ullamc', N'javizuz@mailinator.com', N'+1 (721) 546-3858', 1, 8, CAST(N'2023-08-14T14:46:38.870' AS DateTime), NULL, NULL, 25, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (30, 3, N'Amal', N'Webb', N'Nulla voluptates rer', N'zolih@mailinator.com', N'+1 (281) 566-3351', 1, 8, CAST(N'2023-08-14T14:46:45.233' AS DateTime), NULL, NULL, 26, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (31, 1, N'Ebony', N'Ferrell', N'Fugiat non voluptat', N'jecetimol@mailinator.com', N'+1 (803) 325-1875', 1, 8, CAST(N'2023-08-14T15:15:48.567' AS DateTime), 8, CAST(N'2023-08-14T15:16:02.023' AS DateTime), 29, N'IMS-1', 1)
GO
INSERT [dbo].[Customer] ([Id], [CustomerTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (32, 2, N'Ila', N'Cooper', N'Ut qui voluptatem d', N'taxefaz@mailinator.com', N'+1 (299) 792-2066', 1, 8, CAST(N'2023-08-14T16:29:23.633' AS DateTime), NULL, NULL, 28, N'IMS-1', 1)
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[VendorType] ON 
GO
INSERT [dbo].[VendorType] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (1, N'Supplier', N'Regular Supplier', 1, 1, 101, CAST(N'2023-07-31T09:00:00.000' AS DateTime), NULL, NULL, 1, N'Business123')
GO
INSERT [dbo].[VendorType] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (2, N'Manufacturer', N'Manufacturer Vendor', 2, 1, 101, CAST(N'2023-07-31T10:30:00.000' AS DateTime), NULL, NULL, 1, N'Business456')
GO
INSERT [dbo].[VendorType] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (3, N'Exporter', N'exports foreign products', 3, 1, 8, CAST(N'2023-08-17T11:46:25.117' AS DateTime), 1, CAST(N'2023-08-17T11:46:25.117' AS DateTime), 1, N'IMS-1')
GO
SET IDENTITY_INSERT [dbo].[VendorType] OFF
GO
SET IDENTITY_INSERT [dbo].[Vendor] ON 
GO
INSERT [dbo].[Vendor] ([Id], [VendorTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (1, 2, N'Ahmed', N'Padilla', N'Minus tempor reprehe', N'tubalemo@mailinator.com', N'+1 (512) 828-8918', 1, 8, CAST(N'2023-08-17' AS Date), NULL, NULL, 1, N'IMS-1', 1)
GO
INSERT [dbo].[Vendor] ([Id], [VendorTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (2, 2, N'Buckminster', N'Hardin', N'Hic iusto nulla qui ', N'waruviha@mailinator.com', N'+1 (559) 195-7605', 1, 8, CAST(N'2023-08-17' AS Date), NULL, NULL, 2, N'IMS-1', 1)
GO
INSERT [dbo].[Vendor] ([Id], [VendorTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (3, 2, N'Zephania', N'Ray', N'Sint ipsa qui nost', N'kuhysyxohu@mailinator.com', N'+1 (227) 765-5451', 1, 8, CAST(N'2023-08-17' AS Date), NULL, NULL, 7, N'IMS-1', 1)
GO
INSERT [dbo].[Vendor] ([Id], [VendorTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (4, 2, N'Tara', N'Goodwin', N'Voluptates atque ame', N'weqasifu@mailinator.com', N'+1 (915) 662-2613', 1, 8, CAST(N'2023-08-17' AS Date), NULL, NULL, 3, N'IMS-1', 1)
GO
INSERT [dbo].[Vendor] ([Id], [VendorTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (5, 2, N'Hayfa', N'Luna', N'Nesciunt dolorem mo', N'qaly@mailinator.com', N'+1 (947) 853-4021', 1, 8, CAST(N'2023-08-17' AS Date), NULL, NULL, 4, N'IMS-1', 1)
GO
INSERT [dbo].[Vendor] ([Id], [VendorTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (6, 1, N'Rinau', N'Kirkland', N'Quo sunt dolor ad te', N'bejogume@mailinator.com', N'+1 (374) 998-4036', 1, 8, CAST(N'2023-08-17' AS Date), 8, CAST(N'2023-08-17' AS Date), 5, N'IMS-1', 1)
GO
INSERT [dbo].[Vendor] ([Id], [VendorTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (7, 1, N'Isabella', N'Evans', N'Elit ut dolor tempo', N'nurelo@mailinator.com', N'+1 (998) 338-9993', 1, 8, CAST(N'2023-08-17' AS Date), NULL, NULL, 14, N'IMS-1', 1)
GO
INSERT [dbo].[Vendor] ([Id], [VendorTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (8, 1, N'Xerxes', N'Jefferson', N'Maxime saepe quis ac', N'fifuzeku@mailinator.com', N'+1 (465) 444-8126', 1, 8, CAST(N'2023-08-17' AS Date), NULL, NULL, 6, N'IMS-1', 1)
GO
INSERT [dbo].[Vendor] ([Id], [VendorTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (9, 1, N'Salvador', N'Klein', N'Quis autem aut omnis', N'henyjocopa@mailinator.com', N'+1 (577) 555-4981', 1, 8, CAST(N'2023-08-17' AS Date), NULL, NULL, 8, N'IMS-1', 1)
GO
INSERT [dbo].[Vendor] ([Id], [VendorTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (10, 2, N'Jael', N'Bartlett', N'Assumenda quis non a', N'lysaqu@mailinator.com', N'+1 (338) 891-7629', 1, 8, CAST(N'2023-08-17' AS Date), NULL, NULL, 9, N'IMS-1', 1)
GO
INSERT [dbo].[Vendor] ([Id], [VendorTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (11, 2, N'Megan', N'Nielsen', N'Ad duis perspiciatis', N'loziq@mailinator.com', N'+1 (808) 424-4431', 1, 8, CAST(N'2023-08-17' AS Date), NULL, NULL, 10, N'IMS-1', 1)
GO
INSERT [dbo].[Vendor] ([Id], [VendorTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (12, 2, N'Iona', N'Galloway', N'Excepteur facere ut ', N'kahuv@mailinator.com', N'+1 (209) 665-1657', 1, 8, CAST(N'2023-08-17' AS Date), NULL, NULL, 11, N'IMS-1', 1)
GO
INSERT [dbo].[Vendor] ([Id], [VendorTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (13, 1, N'Herrod', N'Collier', N'Doloremque aspernatu', N'jatuwuno@mailinator.com', N'+1 (676) 726-7329', 1, 8, CAST(N'2023-08-17' AS Date), NULL, NULL, 12, N'IMS-1', 1)
GO
INSERT [dbo].[Vendor] ([Id], [VendorTypeId], [FirstName], [LastName], [Address], [Email], [Phone], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (15, 3, N'Driscoll', N'Sheppard', N'Voluptatum qui quo o', N'foqibyme@mailinator.com', N'+1 (729) 514-7554', 1, 8, CAST(N'2023-08-17' AS Date), NULL, NULL, 15, N'IMS-1', 1)
GO
SET IDENTITY_INSERT [dbo].[Vendor] OFF
GO
SET IDENTITY_INSERT [dbo].[UnitOfMeasurement] ON 
GO
INSERT [dbo].[UnitOfMeasurement] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (1, N'Piece', N'Piece', 1, 1, 101, CAST(N'2023-07-31T09:00:00.000' AS DateTime), NULL, NULL, 1, N'Business123')
GO
INSERT [dbo].[UnitOfMeasurement] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (2, N'Pound', N'Pound', 2, 1, 101, CAST(N'2023-07-31T10:30:00.000' AS DateTime), NULL, NULL, 1, N'Business456')
GO
INSERT [dbo].[UnitOfMeasurement] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (3, N'Liter', N'Liter', 3, 1, 101, CAST(N'2023-07-31T11:45:00.000' AS DateTime), NULL, NULL, 1, N'Business789')
GO
INSERT [dbo].[UnitOfMeasurement] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (4, N'Kilogram', N'Kilogram', 4, 1, 101, CAST(N'2023-07-31T12:30:00.000' AS DateTime), NULL, NULL, 1, N'BusinessXYZ')
GO
SET IDENTITY_INSERT [dbo].[UnitOfMeasurement] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 
GO
INSERT [dbo].[ProductCategory] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (1, N'Electronics', N'Electronics Products', 1, 1, 101, CAST(N'2023-07-31T09:00:00.000' AS DateTime), NULL, NULL, 1, N'Business123')
GO
INSERT [dbo].[ProductCategory] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (2, N'Apparel', N'Apparel Products', 2, 1, 101, CAST(N'2023-07-31T10:30:00.000' AS DateTime), NULL, NULL, 1, N'Business456')
GO
INSERT [dbo].[ProductCategory] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (3, N'Home & Garden', N'Home and Garden Products', 3, 1, 101, CAST(N'2023-07-31T11:45:00.000' AS DateTime), NULL, NULL, 1, N'Business789')
GO
INSERT [dbo].[ProductCategory] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (4, N'Beauty & Personal Care', N'Beauty and Personal Care Products', 4, 1, 101, CAST(N'2023-07-31T12:30:00.000' AS DateTime), NULL, NULL, 1, N'BusinessXYZ')
GO
INSERT [dbo].[ProductCategory] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (5, N'Grocery', N'daily needs', 5, 1, 8, CAST(N'2023-08-17T15:42:25.333' AS DateTime), 1, CAST(N'2023-08-17T15:42:25.333' AS DateTime), 1, N'IMS-1')
GO
INSERT [dbo].[ProductCategory] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (6, N'Computer and Laptops', N'Desktop computers Laptops Servers Workstations', 6, 1, 8, CAST(N'2023-08-23T14:29:10.330' AS DateTime), 1, CAST(N'2023-08-23T14:29:10.330' AS DateTime), 1, N'IMS-1')
GO
INSERT [dbo].[ProductCategory] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (7, N'Mobile Devices', N'Smartphones Tablets Wearable devices (smartwatches, fitness trackers)', 7, 1, 8, CAST(N'2023-08-23T14:29:43.273' AS DateTime), 1, CAST(N'2023-08-23T14:29:43.273' AS DateTime), 1, N'IMS-1')
GO
INSERT [dbo].[ProductCategory] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (8, N'Consumer Electronics', N'Televisions Home audio systems Cameras (digital cameras, action cameras, drones) Gaming consoles', 8, 1, 8, CAST(N'2023-08-23T14:30:47.140' AS DateTime), 1, CAST(N'2023-08-23T14:30:47.140' AS DateTime), 1, N'IMS-1')
GO
INSERT [dbo].[ProductCategory] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (11, N'Office Equipment', N'Printers, Scanners', 9, 1, 8, CAST(N'2023-08-23T15:05:53.673' AS DateTime), 1, CAST(N'2023-08-23T15:05:53.673' AS DateTime), 1, N'IMS-1')
GO
INSERT [dbo].[ProductCategory] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (12, N'Security and Surveillance', N'Securiy Cameras', 10, 1, 8, CAST(N'2023-08-23T15:06:19.570' AS DateTime), 1, CAST(N'2023-08-23T15:06:19.570' AS DateTime), 1, N'IMS-1')
GO
INSERT [dbo].[ProductCategory] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (13, N'Home Automation', N'Smart home devices (smart plugs, smart lighting, smart thermostats)', 11, 1, 8, CAST(N'2023-08-23T15:06:39.663' AS DateTime), 1, CAST(N'2023-08-23T15:06:39.663' AS DateTime), 1, N'IMS-1')
GO
INSERT [dbo].[ProductCategory] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (14, N'Robotics', N'Robotic kits and components', 12, 1, 8, CAST(N'2023-08-23T15:06:56.103' AS DateTime), 1, CAST(N'2023-08-23T15:06:56.103' AS DateTime), 1, N'IMS-1')
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([Id], [ProductName], [ProductImageUrl], [UnitOfMeasurementId], [ProductCategoryId], [BuyingUnitPrice], [SellingUnitPrice], [StockQuantity], [SKU], [ManufacturingDate], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (1, N'Drinko', NULL, 1, 2, CAST(10.00 AS Decimal(10, 2)), CAST(12.00 AS Decimal(10, 2)), 100, 1, CAST(N'2023-08-17' AS Date), 1, 8, CAST(N'2023-08-17' AS Date), NULL, NULL, 1, N'IMS-1', 1)
GO
INSERT [dbo].[Product] ([Id], [ProductName], [ProductImageUrl], [UnitOfMeasurementId], [ProductCategoryId], [BuyingUnitPrice], [SellingUnitPrice], [StockQuantity], [SKU], [ManufacturingDate], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (2, N'Electric Iron', NULL, 1, 1, CAST(1000.00 AS Decimal(10, 2)), CAST(2000.00 AS Decimal(10, 2)), 500, 1, CAST(N'2023-08-17' AS Date), 1, 8, CAST(N'2023-08-17' AS Date), 8, CAST(N'2023-08-17' AS Date), 4, N'IMS-1', 1)
GO
INSERT [dbo].[Product] ([Id], [ProductName], [ProductImageUrl], [UnitOfMeasurementId], [ProductCategoryId], [BuyingUnitPrice], [SellingUnitPrice], [StockQuantity], [SKU], [ManufacturingDate], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (3, N'RFL Chair', NULL, 3, 3, CAST(100.00 AS Decimal(10, 2)), CAST(110.00 AS Decimal(10, 2)), 100, 1, CAST(N'2023-08-17' AS Date), 1, 8, CAST(N'2023-08-17' AS Date), NULL, NULL, 3, N'IMS-1', 1)
GO
INSERT [dbo].[Product] ([Id], [ProductName], [ProductImageUrl], [UnitOfMeasurementId], [ProductCategoryId], [BuyingUnitPrice], [SellingUnitPrice], [StockQuantity], [SKU], [ManufacturingDate], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (4, N'Rice', NULL, 4, 5, CAST(50.00 AS Decimal(10, 2)), CAST(55.00 AS Decimal(10, 2)), 100, 266, CAST(N'2023-08-15' AS Date), 1, 8, CAST(N'2023-08-17' AS Date), NULL, NULL, 9, N'IMS-1', 1)
GO
INSERT [dbo].[Product] ([Id], [ProductName], [ProductImageUrl], [UnitOfMeasurementId], [ProductCategoryId], [BuyingUnitPrice], [SellingUnitPrice], [StockQuantity], [SKU], [ManufacturingDate], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (5, N'Milk', NULL, 3, 5, CAST(100.00 AS Decimal(10, 2)), CAST(110.00 AS Decimal(10, 2)), 500, 22, CAST(N'2023-08-17' AS Date), 1, 8, CAST(N'2023-08-17' AS Date), NULL, NULL, 2, N'IMS-1', 1)
GO
INSERT [dbo].[Product] ([Id], [ProductName], [ProductImageUrl], [UnitOfMeasurementId], [ProductCategoryId], [BuyingUnitPrice], [SellingUnitPrice], [StockQuantity], [SKU], [ManufacturingDate], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (8, N'Printer', NULL, 1, 11, CAST(10000.00 AS Decimal(10, 2)), CAST(12000.00 AS Decimal(10, 2)), 100, 1, CAST(N'2023-08-23' AS Date), 1, 8, CAST(N'2023-08-23' AS Date), NULL, NULL, 5, N'IMS-1', 1)
GO
INSERT [dbo].[Product] ([Id], [ProductName], [ProductImageUrl], [UnitOfMeasurementId], [ProductCategoryId], [BuyingUnitPrice], [SellingUnitPrice], [StockQuantity], [SKU], [ManufacturingDate], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (9, N'Router', NULL, 1, 13, CAST(4000.00 AS Decimal(10, 2)), CAST(4500.00 AS Decimal(10, 2)), 100, 1, CAST(N'2023-08-23' AS Date), 1, 8, CAST(N'2023-08-23' AS Date), NULL, NULL, 6, N'IMS-1', 1)
GO
INSERT [dbo].[Product] ([Id], [ProductName], [ProductImageUrl], [UnitOfMeasurementId], [ProductCategoryId], [BuyingUnitPrice], [SellingUnitPrice], [StockQuantity], [SKU], [ManufacturingDate], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (10, N'Keyboard', NULL, 1, 6, CAST(1000.00 AS Decimal(10, 2)), CAST(1200.00 AS Decimal(10, 2)), 100, 1, CAST(N'2023-08-02' AS Date), 1, 8, CAST(N'2023-08-23' AS Date), NULL, NULL, 7, N'IMS-1', 1)
GO
INSERT [dbo].[Product] ([Id], [ProductName], [ProductImageUrl], [UnitOfMeasurementId], [ProductCategoryId], [BuyingUnitPrice], [SellingUnitPrice], [StockQuantity], [SKU], [ManufacturingDate], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Rank], [BusinessId], [Version]) VALUES (11, N'Mouse', NULL, 1, 6, CAST(400.00 AS Decimal(10, 2)), CAST(500.00 AS Decimal(10, 2)), 100, 1, CAST(N'2023-08-17' AS Date), 1, 8, CAST(N'2023-08-23' AS Date), NULL, NULL, 8, N'IMS-1', 1)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[BillType] ON 
GO
INSERT [dbo].[BillType] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (1, N'Product Bill', N'Bill for Product Order', 1, 1, 101, CAST(N'2023-07-31T09:00:00.000' AS DateTime), NULL, NULL, 1, N'Business123')
GO
INSERT [dbo].[BillType] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (2, N'Service Bill', N'Bill for Service Order', 2, 1, 101, CAST(N'2023-07-31T10:30:00.000' AS DateTime), NULL, NULL, 1, N'Business456')
GO
SET IDENTITY_INSERT [dbo].[BillType] OFF
GO
SET IDENTITY_INSERT [dbo].[CashBank] ON 
GO
INSERT [dbo].[CashBank] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (1, N'Bank Asia', N'private bank', 1, 1, 8, CAST(N'2023-08-22T11:52:06.823' AS DateTime), 1, CAST(N'2023-08-22T11:52:06.823' AS DateTime), 1, N'IMS-1')
GO
INSERT [dbo].[CashBank] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (2, N'Sonali Bank', N'Govt bank', 2, 1, 8, CAST(N'2023-08-22T11:52:17.867' AS DateTime), 1, CAST(N'2023-08-22T11:52:17.867' AS DateTime), 1, N'IMS-1')
GO
SET IDENTITY_INSERT [dbo].[CashBank] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoiceType] ON 
GO
INSERT [dbo].[InvoiceType] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (1, N'Refund', N'Refund Invoice', 1, 1, 102, CAST(N'2023-08-01T14:15:00.000' AS DateTime), NULL, NULL, 1, N'Business789')
GO
INSERT [dbo].[InvoiceType] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (2, N'Service', N'Service Invoice', 2, 1, 103, CAST(N'2023-08-02T11:30:00.000' AS DateTime), NULL, NULL, 1, N'BusinessXYZ')
GO
INSERT [dbo].[InvoiceType] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (3, N'Product', N'Product Invoice', 3, 1, 103, CAST(N'2023-08-02T11:30:00.000' AS DateTime), NULL, NULL, 1, N'BusinessXYZ')
GO
INSERT [dbo].[InvoiceType] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (4, N'Sales', N'Sales Invoice', 1, 1, 101, CAST(N'2023-07-31T09:00:00.000' AS DateTime), NULL, NULL, 1, N'Business123')
GO
INSERT [dbo].[InvoiceType] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (5, N'Purchase', N'Purchase Invoice', 2, 1, 101, CAST(N'2023-07-31T10:30:00.000' AS DateTime), NULL, NULL, 1, N'Business456')
GO
SET IDENTITY_INSERT [dbo].[InvoiceType] OFF
GO
SET IDENTITY_INSERT [dbo].[PaymentType] ON 
GO
INSERT [dbo].[PaymentType] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (1, N'Credit Card', N'Payment via Credit Card', 1, 1, 101, CAST(N'2023-07-31T09:00:00.000' AS DateTime), NULL, NULL, 1, N'Business123')
GO
INSERT [dbo].[PaymentType] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (2, N'Cash', N'Payment in Cash', 2, 1, 101, CAST(N'2023-07-31T10:30:00.000' AS DateTime), NULL, NULL, 1, N'Business456')
GO
INSERT [dbo].[PaymentType] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (3, N'Bank Transfer', N'Payment via Bank Transfer', 3, 1, 101, CAST(N'2023-07-31T11:45:00.000' AS DateTime), NULL, NULL, 1, N'Business789')
GO
INSERT [dbo].[PaymentType] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (4, N'Bkash', N'online', 4, 1, 9, CAST(N'2023-08-12T11:37:49.637' AS DateTime), 1, CAST(N'2023-08-12T11:37:52.697' AS DateTime), 1, N'IMS-1')
GO
SET IDENTITY_INSERT [dbo].[PaymentType] OFF
GO
SET IDENTITY_INSERT [dbo].[ShipmentType] ON 
GO
INSERT [dbo].[ShipmentType] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (1, N'Standard', N'Standard Shipment', 1, 1, 101, CAST(N'2023-07-31T09:00:00.000' AS DateTime), NULL, NULL, 1, N'Business123')
GO
INSERT [dbo].[ShipmentType] ([Id], [Name], [Description], [Rank], [Status], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [Version], [BusinessId]) VALUES (2, N'Express', N'Express Shipment', 2, 1, 101, CAST(N'2023-07-31T10:30:00.000' AS DateTime), NULL, NULL, 1, N'Business456')
GO
SET IDENTITY_INSERT [dbo].[ShipmentType] OFF
GO
