USE [hotelreservation]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 09.06.2023 17:03:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 09.06.2023 17:03:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [uniqueidentifier] NOT NULL,
	[Country] [nvarchar](max) NOT NULL,
	[Street] [nvarchar](max) NOT NULL,
	[StreetNumber] [nvarchar](max) NOT NULL,
	[ZipCode] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guest]    Script Date: 09.06.2023 17:03:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guest](
	[Id] [uniqueidentifier] NOT NULL,
	[First_Name] [nvarchar](max) NOT NULL,
	[Last_Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[ReservationId] [uniqueidentifier] NOT NULL,
	[AddresId] [uniqueidentifier] NOT NULL,
	[IsPrivate] [bit] NOT NULL,
 CONSTRAINT [PK_Guest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 09.06.2023 17:03:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](70) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
	[HoursCheckInFrom] [int] NOT NULL,
	[HoursCheckInTo] [int] NOT NULL,
	[HoursCheckOutFrom] [int] NOT NULL,
	[HoursCheckOutTo] [int] NOT NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HotelCategorys]    Script Date: 09.06.2023 17:03:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelCategorys](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](70) NOT NULL,
 CONSTRAINT [PK_HotelCategorys] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HotelImages]    Script Date: 09.06.2023 17:03:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelImages](
	[Id] [uniqueidentifier] NOT NULL,
	[Extension] [nvarchar](max) NOT NULL,
	[Upload_time] [datetime2](7) NOT NULL,
	[Path] [nvarchar](max) NOT NULL,
	[HotelId] [uniqueidentifier] NOT NULL,
	[IsMain] [bit] NOT NULL,
 CONSTRAINT [PK_HotelImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 09.06.2023 17:03:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[Id] [uniqueidentifier] NOT NULL,
	[Start_Date] [datetime2](7) NOT NULL,
	[End_Date] [datetime2](7) NOT NULL,
	[Total_Price] [float] NOT NULL,
	[Discount] [float] NOT NULL,
	[CountOfRoom] [int] NOT NULL,
	[CountOfAdults] [int] NOT NULL,
	[CountOfChildren] [int] NOT NULL,
	[Details] [nvarchar](max) NULL,
	[Numer] [nvarchar](max) NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservationRoom]    Script Date: 09.06.2023 17:03:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservationRoom](
	[ReservationsId] [uniqueidentifier] NOT NULL,
	[RoomsId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ReservationRoom] PRIMARY KEY CLUSTERED 
(
	[ReservationsId] ASC,
	[RoomsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 09.06.2023 17:03:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](70) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [float] NOT NULL,
	[TypeId] [uniqueidentifier] NOT NULL,
	[HotlelId] [uniqueidentifier] NOT NULL,
	[MaxQuantityOfPeople] [int] NOT NULL,
	[Discount] [float] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomImages]    Script Date: 09.06.2023 17:03:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomImages](
	[Id] [uniqueidentifier] NOT NULL,
	[Extension] [nvarchar](max) NOT NULL,
	[Upload_time] [datetime2](7) NOT NULL,
	[Path] [nvarchar](max) NOT NULL,
	[RoomId] [uniqueidentifier] NOT NULL,
	[IsMain] [bit] NOT NULL,
 CONSTRAINT [PK_RoomImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomTypes]    Script Date: 09.06.2023 17:03:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RoomTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221119185117_Initial', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221119190231_Add_Guest', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221119235417_Add_Images', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221120010154_Rename_table_Hotel', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221120013502_Add_many_images_to_hotel', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221120014422_Add_many_images_to_rooms', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221120112112_add_main_images', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221120141037_rename_table_hotel_image', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221123213440_add-addres-and-reservation-info', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221123225106_add_hoursofhotel', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221125181750_additional-informations', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230603190752_Added numer to Reservation', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230603193154_Field is private to Guest table', N'5.0.17')
GO
INSERT [dbo].[Address] ([Id], [Country], [Street], [StreetNumber], [ZipCode], [City]) VALUES (N'c373c28a-275c-4f04-8ab0-72ef5b61a30e', N'POLAD', N'Góno', N'47', N'64-120', N'Krzemieniewo')
INSERT [dbo].[Address] ([Id], [Country], [Street], [StreetNumber], [ZipCode], [City]) VALUES (N'c6ddb89d-817b-47c8-8adc-7584c87b0b76', N'Polska', N'Górzno', N'47', N'64123', N'Krzemieniewo')
INSERT [dbo].[Address] ([Id], [Country], [Street], [StreetNumber], [ZipCode], [City]) VALUES (N'34197d6f-c1fb-4dbd-9389-91bd7541a43b', N'POLAND', N'Góno', N'47', N'64-120', N'Krzemieniewo')
INSERT [dbo].[Address] ([Id], [Country], [Street], [StreetNumber], [ZipCode], [City]) VALUES (N'e767af34-70df-4735-8dea-f9b2d40866d1', N'POLAND', N'Klonówiec', N'23', N'64-523', N'Liono')
GO
INSERT [dbo].[Guest] ([Id], [First_Name], [Last_Name], [Email], [Phone], [ReservationId], [AddresId], [IsPrivate]) VALUES (N'0dbb7b9c-8f9b-473e-8281-966ee3a63727', N'Ewa', N'Szulc', N'szulc.ewa@poczta.pl', N'854698123', N'4be08a7d-3a52-4da5-a644-c9f4bce89d16', N'e767af34-70df-4735-8dea-f9b2d40866d1', 1)
INSERT [dbo].[Guest] ([Id], [First_Name], [Last_Name], [Email], [Phone], [ReservationId], [AddresId], [IsPrivate]) VALUES (N'93602b7b-b8b9-4cc3-88ac-cbfcadb01fe8', N'Jakub', N'Szulc', N'szulc@wp.pl', N'789456123', N'2cbf4ce1-29db-468c-ace3-378ba2ceed2c', N'c6ddb89d-817b-47c8-8adc-7584c87b0b76', 1)
INSERT [dbo].[Guest] ([Id], [First_Name], [Last_Name], [Email], [Phone], [ReservationId], [AddresId], [IsPrivate]) VALUES (N'2ca2f5ac-a687-4f09-a2f2-fad0b3ece80a', N'Jakub', N'Szulc', N'szul@wps.pl', N'541985632', N'5a97db85-17bf-427b-870e-3cf1f2dce790', N'34197d6f-c1fb-4dbd-9389-91bd7541a43b', 1)
GO
INSERT [dbo].[Hotel] ([Id], [Name], [Description], [City], [IsActive], [CategoryId], [HoursCheckInFrom], [HoursCheckInTo], [HoursCheckOutFrom], [HoursCheckOutTo]) VALUES (N'9bda0c14-0f79-4ea5-acb8-5cece2fe074a', N'Hotel #1', N'Hotel #1', N'Warszawa', 1, N'79e642ee-ba36-4d89-bebc-bbb149533ed6', 2, 22, 8, 12)
INSERT [dbo].[Hotel] ([Id], [Name], [Description], [City], [IsActive], [CategoryId], [HoursCheckInFrom], [HoursCheckInTo], [HoursCheckOutFrom], [HoursCheckOutTo]) VALUES (N'2554678e-1413-434a-8fa5-8de97b6ba729', N'Hotel 2#', N'Hotel 2#', N'Lesznolll', 0, N'79e642ee-ba36-4d89-bebc-bbb149533ed6', 8, 17, 7, 14)
GO
INSERT [dbo].[HotelCategorys] ([Id], [Name]) VALUES (N'79e642ee-ba36-4d89-bebc-bbb149533ed6', N'Główny')
GO
INSERT [dbo].[HotelImages] ([Id], [Extension], [Upload_time], [Path], [HotelId], [IsMain]) VALUES (N'f7b2fc74-826a-4f1f-916d-d53b767b7004', N'.jpg', CAST(N'2023-06-08T10:58:42.0634496' AS DateTime2), N'Images\Hotel\f7b2fc74-826a-4f1f-916d-d53b767b7004.jpg', N'2554678e-1413-434a-8fa5-8de97b6ba729', 1)
GO
INSERT [dbo].[Reservation] ([Id], [Start_Date], [End_Date], [Total_Price], [Discount], [CountOfRoom], [CountOfAdults], [CountOfChildren], [Details], [Numer]) VALUES (N'2cbf4ce1-29db-468c-ace3-378ba2ceed2c', CAST(N'2022-12-05T08:46:00.0000000' AS DateTime2), CAST(N'2022-12-08T09:46:00.0000000' AS DateTime2), 1815, 0, 1, 1, 0, NULL, N'P/1/03/06/2023')
INSERT [dbo].[Reservation] ([Id], [Start_Date], [End_Date], [Total_Price], [Discount], [CountOfRoom], [CountOfAdults], [CountOfChildren], [Details], [Numer]) VALUES (N'5a97db85-17bf-427b-870e-3cf1f2dce790', CAST(N'2023-06-04T19:00:00.0000000' AS DateTime2), CAST(N'2023-06-05T10:00:00.0000000' AS DateTime2), 0, 0, 1, 1, 0, N'Brak ', N'P/2/4/6/2023')
INSERT [dbo].[Reservation] ([Id], [Start_Date], [End_Date], [Total_Price], [Discount], [CountOfRoom], [CountOfAdults], [CountOfChildren], [Details], [Numer]) VALUES (N'4be08a7d-3a52-4da5-a644-c9f4bce89d16', CAST(N'2023-06-04T10:00:00.0000000' AS DateTime2), CAST(N'2023-06-07T08:00:00.0000000' AS DateTime2), 246, 0, 1, 1, 0, N'Pierdzi', N'P/1/4/6/2023')
GO
INSERT [dbo].[ReservationRoom] ([ReservationsId], [RoomsId]) VALUES (N'2cbf4ce1-29db-468c-ace3-378ba2ceed2c', N'75addc2b-1f83-48dd-9ec4-18b91e06b2c4')
INSERT [dbo].[ReservationRoom] ([ReservationsId], [RoomsId]) VALUES (N'5a97db85-17bf-427b-870e-3cf1f2dce790', N'75addc2b-1f83-48dd-9ec4-18b91e06b2c4')
INSERT [dbo].[ReservationRoom] ([ReservationsId], [RoomsId]) VALUES (N'2cbf4ce1-29db-468c-ace3-378ba2ceed2c', N'dc78abcf-999d-4ffa-b68b-26be59911cc5')
INSERT [dbo].[ReservationRoom] ([ReservationsId], [RoomsId]) VALUES (N'4be08a7d-3a52-4da5-a644-c9f4bce89d16', N'dc78abcf-999d-4ffa-b68b-26be59911cc5')
GO
INSERT [dbo].[Room] ([Id], [Name], [Description], [Price], [TypeId], [HotlelId], [MaxQuantityOfPeople], [Discount]) VALUES (N'75addc2b-1f83-48dd-9ec4-18b91e06b2c4', N'Pokój #2', N'Pokój #2', 200, N'b97444c1-bd71-40f3-9bdd-3f7bdf648cb8', N'9bda0c14-0f79-4ea5-acb8-5cece2fe074a', 4, 1)
INSERT [dbo].[Room] ([Id], [Name], [Description], [Price], [TypeId], [HotlelId], [MaxQuantityOfPeople], [Discount]) VALUES (N'dc78abcf-999d-4ffa-b68b-26be59911cc5', N'Pokój #3', N'Pokój #3', 123, N'67acfeeb-4254-4721-8574-ab6c68e2f71c', N'9bda0c14-0f79-4ea5-acb8-5cece2fe074a', 13, 1)
INSERT [dbo].[Room] ([Id], [Name], [Description], [Price], [TypeId], [HotlelId], [MaxQuantityOfPeople], [Discount]) VALUES (N'0ffa6fee-252a-4342-8485-955e4696d517', N'Nazwa', N'OPis', 50, N'b97444c1-bd71-40f3-9bdd-3f7bdf648cb8', N'9bda0c14-0f79-4ea5-acb8-5cece2fe074a', 0, 1)
GO
INSERT [dbo].[RoomImages] ([Id], [Extension], [Upload_time], [Path], [RoomId], [IsMain]) VALUES (N'5de8eced-c1c4-459c-849c-b3b3dd115e24', N'.jpg', CAST(N'2023-06-03T11:37:47.6835778' AS DateTime2), N'Images\Room\5de8eced-c1c4-459c-849c-b3b3dd115e24.jpg', N'dc78abcf-999d-4ffa-b68b-26be59911cc5', 1)
GO
INSERT [dbo].[RoomTypes] ([Id], [Name]) VALUES (N'b97444c1-bd71-40f3-9bdd-3f7bdf648cb8', N'Apartament')
INSERT [dbo].[RoomTypes] ([Id], [Name]) VALUES (N'67acfeeb-4254-4721-8574-ab6c68e2f71c', N'Standard')
GO
ALTER TABLE [dbo].[Guest] ADD  DEFAULT (N'') FOR [First_Name]
GO
ALTER TABLE [dbo].[Guest] ADD  DEFAULT (N'') FOR [Last_Name]
GO
ALTER TABLE [dbo].[Guest] ADD  DEFAULT (N'') FOR [Email]
GO
ALTER TABLE [dbo].[Guest] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [AddresId]
GO
ALTER TABLE [dbo].[Guest] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsPrivate]
GO
ALTER TABLE [dbo].[Hotel] ADD  DEFAULT ((0)) FOR [HoursCheckInFrom]
GO
ALTER TABLE [dbo].[Hotel] ADD  DEFAULT ((0)) FOR [HoursCheckInTo]
GO
ALTER TABLE [dbo].[Hotel] ADD  DEFAULT ((0)) FOR [HoursCheckOutFrom]
GO
ALTER TABLE [dbo].[Hotel] ADD  DEFAULT ((0)) FOR [HoursCheckOutTo]
GO
ALTER TABLE [dbo].[HotelImages] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [HotelId]
GO
ALTER TABLE [dbo].[HotelImages] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsMain]
GO
ALTER TABLE [dbo].[Reservation] ADD  DEFAULT ((0)) FOR [CountOfRoom]
GO
ALTER TABLE [dbo].[Reservation] ADD  DEFAULT ((0)) FOR [CountOfAdults]
GO
ALTER TABLE [dbo].[Reservation] ADD  DEFAULT ((0)) FOR [CountOfChildren]
GO
ALTER TABLE [dbo].[Room] ADD  DEFAULT ((0)) FOR [MaxQuantityOfPeople]
GO
ALTER TABLE [dbo].[Room] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Discount]
GO
ALTER TABLE [dbo].[RoomImages] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsMain]
GO
ALTER TABLE [dbo].[Guest]  WITH CHECK ADD  CONSTRAINT [FK_Guest_Address_AddresId] FOREIGN KEY([AddresId])
REFERENCES [dbo].[Address] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Guest] CHECK CONSTRAINT [FK_Guest_Address_AddresId]
GO
ALTER TABLE [dbo].[Guest]  WITH CHECK ADD  CONSTRAINT [FK_Guest_Reservation_ReservationId] FOREIGN KEY([ReservationId])
REFERENCES [dbo].[Reservation] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Guest] CHECK CONSTRAINT [FK_Guest_Reservation_ReservationId]
GO
ALTER TABLE [dbo].[Hotel]  WITH CHECK ADD  CONSTRAINT [FK_Hotel_HotelCategorys_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[HotelCategorys] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Hotel] CHECK CONSTRAINT [FK_Hotel_HotelCategorys_CategoryId]
GO
ALTER TABLE [dbo].[HotelImages]  WITH CHECK ADD  CONSTRAINT [FK_HotelImages_Hotel_HotelId] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotel] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HotelImages] CHECK CONSTRAINT [FK_HotelImages_Hotel_HotelId]
GO
ALTER TABLE [dbo].[ReservationRoom]  WITH CHECK ADD  CONSTRAINT [FK_ReservationRoom_Reservation_ReservationsId] FOREIGN KEY([ReservationsId])
REFERENCES [dbo].[Reservation] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReservationRoom] CHECK CONSTRAINT [FK_ReservationRoom_Reservation_ReservationsId]
GO
ALTER TABLE [dbo].[ReservationRoom]  WITH CHECK ADD  CONSTRAINT [FK_ReservationRoom_Room_RoomsId] FOREIGN KEY([RoomsId])
REFERENCES [dbo].[Room] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReservationRoom] CHECK CONSTRAINT [FK_ReservationRoom_Room_RoomsId]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Hotel_HotlelId] FOREIGN KEY([HotlelId])
REFERENCES [dbo].[Hotel] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Hotel_HotlelId]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomTypes_TypeId] FOREIGN KEY([TypeId])
REFERENCES [dbo].[RoomTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_RoomTypes_TypeId]
GO
ALTER TABLE [dbo].[RoomImages]  WITH CHECK ADD  CONSTRAINT [FK_RoomImages_Room_RoomId] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoomImages] CHECK CONSTRAINT [FK_RoomImages_Room_RoomId]
GO
