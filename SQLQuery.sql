USE [BadmintonCourtDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/9/2025 10:38:26 PM ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 7/9/2025 10:38:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserID] [int] NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[CreateAt] [datetime2](7) NOT NULL,
	[Email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 7/9/2025 10:38:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[BookingID] [int] IDENTITY(1,1) NOT NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[EndTime] [datetime2](7) NOT NULL,
	[TotalHourBooked] [float] NOT NULL,
	[ReportID] [int] NULL,
	[UserID] [int] NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[BookingDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourtBookings]    Script Date: 7/9/2025 10:38:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourtBookings](
	[BookingId] [int] NOT NULL,
	[CourtId] [int] NOT NULL,
 CONSTRAINT [PK_CourtBookings] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC,
	[CourtId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courts]    Script Date: 7/9/2025 10:38:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courts](
	[CourtID] [int] IDENTITY(1,1) NOT NULL,
	[CourtName] [nvarchar](max) NOT NULL,
	[CourtStatus] [nvarchar](max) NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_Courts] PRIMARY KEY CLUSTERED 
(
	[CourtID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 7/9/2025 10:38:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[FeedbackID] [int] IDENTITY(1,1) NOT NULL,
	[Comments] [nvarchar](max) NOT NULL,
	[CreateAt] [datetime2](7) NOT NULL,
	[Rating] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[FeedbackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 7/9/2025 10:38:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[NotificationID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
	[Message] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED 
(
	[NotificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 7/9/2025 10:38:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[BookingID] [int] NOT NULL,
	[PaidAt] [datetime2](7) NULL,
	[Status] [nvarchar](max) NOT NULL,
	[Amount] [float] NOT NULL,
	[Method] [nvarchar](max) NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Points]    Script Date: 7/9/2025 10:38:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Points](
	[UserID] [int] NOT NULL,
	[Point] [int] NOT NULL,
	[ClaimDate] [datetime2](7) NULL,
	[TotalRedeem] [int] NOT NULL,
	[Status] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Points] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 7/9/2025 10:38:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reports](
	[ReportID] [int] IDENTITY(1,1) NOT NULL,
	[CreateAt] [datetime2](7) NOT NULL,
	[TotalFreeHour] [int] NOT NULL,
 CONSTRAINT [PK_Reports] PRIMARY KEY CLUSTERED 
(
	[ReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 7/9/2025 10:38:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Role] [nvarchar](max) NOT NULL,
	[Dob] [date] NULL,
	[Phone] [varchar](50) NOT NULL,
	[NotificationID] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250625032623_FirstMigration', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250625041838_AddBooking', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250625042933_AddCourt', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250625044552_AddCourtBooking', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250625051050_AddReportAndPayment', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250627162918_AddEntity', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250627165238_UpdateDatabase', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250627171325_UpdateMigration', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250627171533_UpdateMigraton', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250629031412_UpdateBookingEntity', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250630030208_AddBookingDate', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250705191816_UpdateDB', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250705192216_UpdateDatabasev2', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250705194356_MarkNullable', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250705194742_MarkNotiNullable', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250705195606_MarkPointClaimDateNullable', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250710031950_AddEmailIndex', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250710035421_NullableDobUser', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250710041446_updateDobDateOnly', N'8.0.0')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250710045255_EmailToAccountEntity', N'8.0.0')
GO
INSERT [dbo].[Account] ([UserID], [Password], [CreateAt], [Email]) VALUES (1, N'password123', CAST(N'2024-01-01T00:00:00.0000000' AS DateTime2), N'hahahha@gmail.com')
INSERT [dbo].[Account] ([UserID], [Password], [CreateAt], [Email]) VALUES (2, N'adminpass', CAST(N'2024-02-01T00:00:00.0000000' AS DateTime2), N'huhu@gmail.com')
INSERT [dbo].[Account] ([UserID], [Password], [CreateAt], [Email]) VALUES (10, N'fwfews', CAST(N'2025-07-10T04:10:49.2842103' AS DateTime2), N'hello@gmail.com')
INSERT [dbo].[Account] ([UserID], [Password], [CreateAt], [Email]) VALUES (19, N'AQAAAAIAAYagAAAAEIHVUjqXepw3my0rD7ZHl6wv3QTFaD7hZoUjw+YK8gm+dxKFmNz7C1KFS9OYwHzslw==', CAST(N'2025-07-10T04:10:49.2842103' AS DateTime2), N'thanhphongchupanh@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Bookings] ON 

INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (1, CAST(N'2025-06-25T09:00:00.0000000' AS DateTime2), CAST(N'2025-06-25T11:00:00.0000000' AS DateTime2), 2, 1, 6, N'Booked', CAST(N'2025-06-25T08:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (2, CAST(N'2025-06-26T14:00:00.0000000' AS DateTime2), CAST(N'2025-06-26T16:00:00.0000000' AS DateTime2), 2, 2, 6, N'Booked', CAST(N'2025-06-26T13:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (3, CAST(N'2025-06-27T15:00:00.0000000' AS DateTime2), CAST(N'2025-06-27T16:00:00.0000000' AS DateTime2), 1, 1, 3, N'Booked', CAST(N'2025-06-27T14:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (4, CAST(N'2025-06-29T15:00:00.0000000' AS DateTime2), CAST(N'2025-06-29T16:00:00.0000000' AS DateTime2), 1, 1, 3, N'Booked', CAST(N'2025-06-29T14:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (6, CAST(N'2025-06-29T08:00:00.0000000' AS DateTime2), CAST(N'2025-06-29T10:00:00.0000000' AS DateTime2), 2, 1, 6, N'Booked', CAST(N'2025-06-29T07:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (7, CAST(N'2025-06-30T08:00:00.0000000' AS DateTime2), CAST(N'2025-06-30T10:00:00.0000000' AS DateTime2), 2, 1, 7, N'Booked', CAST(N'2025-06-30T07:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (8, CAST(N'2025-06-30T10:00:00.0000000' AS DateTime2), CAST(N'2025-06-30T11:00:00.0000000' AS DateTime2), 1, 2, 8, N'Booked', CAST(N'2025-06-30T09:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (9, CAST(N'2025-06-30T12:00:00.0000000' AS DateTime2), CAST(N'2025-06-30T14:00:00.0000000' AS DateTime2), 2, 2, 9, N'Booked', CAST(N'2025-06-30T11:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (10, CAST(N'2025-06-30T14:00:00.0000000' AS DateTime2), CAST(N'2025-06-30T15:00:00.0000000' AS DateTime2), 1, 2, 10, N'Booked', CAST(N'2025-06-30T13:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (11, CAST(N'2025-06-30T15:00:00.0000000' AS DateTime2), CAST(N'2025-06-30T16:00:00.0000000' AS DateTime2), 1, 1, 11, N'Booked', CAST(N'2025-06-30T14:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (12, CAST(N'2025-06-30T16:00:00.0000000' AS DateTime2), CAST(N'2025-06-30T18:00:00.0000000' AS DateTime2), 2, 1, 12, N'Booked', CAST(N'2025-06-30T15:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (13, CAST(N'2025-07-01T08:00:00.0000000' AS DateTime2), CAST(N'2025-07-01T10:00:00.0000000' AS DateTime2), 2, 1, 13, N'Booked', CAST(N'2025-07-01T07:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (14, CAST(N'2025-07-01T10:00:00.0000000' AS DateTime2), CAST(N'2025-07-01T11:00:00.0000000' AS DateTime2), 1, 2, 14, N'Booked', CAST(N'2025-07-01T09:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (15, CAST(N'2025-07-01T12:00:00.0000000' AS DateTime2), CAST(N'2025-07-01T14:00:00.0000000' AS DateTime2), 2, 2, 15, N'Booked', CAST(N'2025-07-01T11:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (16, CAST(N'2025-07-01T15:00:00.0000000' AS DateTime2), CAST(N'2025-07-01T17:00:00.0000000' AS DateTime2), 2, 2, 16, N'Booked', CAST(N'2025-07-01T14:00:00.0000000' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (18, CAST(N'2025-07-06T09:00:00.0000000' AS DateTime2), CAST(N'2025-07-06T11:00:00.0000000' AS DateTime2), 2, NULL, 3, N'Booked', CAST(N'2025-07-05T22:55:26.1793912' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (21, CAST(N'2025-07-06T12:00:00.0000000' AS DateTime2), CAST(N'2025-07-06T13:00:00.0000000' AS DateTime2), 1, NULL, 6, N'Canceled', CAST(N'2025-07-06T11:28:40.3851040' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (23, CAST(N'2025-07-06T13:00:00.0000000' AS DateTime2), CAST(N'2025-07-06T14:00:00.0000000' AS DateTime2), 1, NULL, 3, N'Booked', CAST(N'2025-07-06T11:59:55.4234927' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (24, CAST(N'2025-07-06T14:00:00.0000000' AS DateTime2), CAST(N'2025-07-06T15:00:00.0000000' AS DateTime2), 1, NULL, 3, N'Booked', CAST(N'2025-07-06T12:05:15.7219768' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (25, CAST(N'2025-07-06T13:00:00.0000000' AS DateTime2), CAST(N'2025-07-06T15:00:00.0000000' AS DateTime2), 2, NULL, 3, N'Booked', CAST(N'2025-07-06T12:07:33.4261176' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (26, CAST(N'2025-07-06T14:00:00.0000000' AS DateTime2), CAST(N'2025-07-06T15:00:00.0000000' AS DateTime2), 1, NULL, 5, N'Canceled', CAST(N'2025-07-06T13:33:10.9181050' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (27, CAST(N'2025-07-06T14:00:00.0000000' AS DateTime2), CAST(N'2025-07-06T15:00:00.0000000' AS DateTime2), 1, NULL, 6, N'Booked', CAST(N'2025-07-06T13:33:54.5559031' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (28, CAST(N'2025-07-06T23:00:00.0000000' AS DateTime2), CAST(N'2025-07-06T23:30:00.0000000' AS DateTime2), 1, NULL, 6, N'Booked', CAST(N'2025-07-06T21:23:40.3472282' AS DateTime2))
INSERT [dbo].[Bookings] ([BookingID], [StartTime], [EndTime], [TotalHourBooked], [ReportID], [UserID], [Status], [BookingDate]) VALUES (29, CAST(N'2025-07-10T08:00:00.0000000' AS DateTime2), CAST(N'2025-07-10T09:00:00.0000000' AS DateTime2), 1, NULL, 19, N'Booked', CAST(N'2025-07-09T22:35:14.5635601' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Bookings] OFF
GO
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (1, 1)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (12, 1)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (18, 1)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (21, 1)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (23, 1)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (24, 1)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (28, 1)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (29, 1)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (2, 2)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (8, 2)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (14, 2)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (15, 2)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (25, 2)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (3, 3)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (4, 3)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (7, 3)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (11, 4)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (26, 4)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (27, 4)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (6, 5)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (16, 6)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (13, 8)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (9, 9)
INSERT [dbo].[CourtBookings] ([BookingId], [CourtId]) VALUES (10, 10)
GO
SET IDENTITY_INSERT [dbo].[Courts] ON 

INSERT [dbo].[Courts] ([CourtID], [CourtName], [CourtStatus], [Price]) VALUES (1, N'Court1', N'Maintanence', 40)
INSERT [dbo].[Courts] ([CourtID], [CourtName], [CourtStatus], [Price]) VALUES (2, N'Court2', N'Available', 40)
INSERT [dbo].[Courts] ([CourtID], [CourtName], [CourtStatus], [Price]) VALUES (3, N'Court3', N'Available', 40)
INSERT [dbo].[Courts] ([CourtID], [CourtName], [CourtStatus], [Price]) VALUES (4, N'Court4', N'Available', 40)
INSERT [dbo].[Courts] ([CourtID], [CourtName], [CourtStatus], [Price]) VALUES (5, N'Court5', N'Available', 40)
INSERT [dbo].[Courts] ([CourtID], [CourtName], [CourtStatus], [Price]) VALUES (6, N'Court6', N'Available', 40)
INSERT [dbo].[Courts] ([CourtID], [CourtName], [CourtStatus], [Price]) VALUES (7, N'Court7', N'Available', 40)
INSERT [dbo].[Courts] ([CourtID], [CourtName], [CourtStatus], [Price]) VALUES (8, N'Court8', N'Available', 40)
INSERT [dbo].[Courts] ([CourtID], [CourtName], [CourtStatus], [Price]) VALUES (9, N'Court9', N'Available', 40)
INSERT [dbo].[Courts] ([CourtID], [CourtName], [CourtStatus], [Price]) VALUES (10, N'Court10', N'Available', 40)
SET IDENTITY_INSERT [dbo].[Courts] OFF
GO
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([FeedbackID], [Comments], [CreateAt], [Rating], [UserID]) VALUES (1, N'Great experience!', CAST(N'2025-06-25T12:00:00.0000000' AS DateTime2), 5, 1)
INSERT [dbo].[Feedback] ([FeedbackID], [Comments], [CreateAt], [Rating], [UserID]) VALUES (2, N'Court could be cleaner.', CAST(N'2025-06-26T17:00:00.0000000' AS DateTime2), 3, 2)
INSERT [dbo].[Feedback] ([FeedbackID], [Comments], [CreateAt], [Rating], [UserID]) VALUES (3, N'Great experience!', CAST(N'2025-06-25T12:00:00.0000000' AS DateTime2), 5, 1)
INSERT [dbo].[Feedback] ([FeedbackID], [Comments], [CreateAt], [Rating], [UserID]) VALUES (4, N'Court could be cleaner.', CAST(N'2025-06-26T17:00:00.0000000' AS DateTime2), 3, 2)
SET IDENTITY_INSERT [dbo].[Feedback] OFF
GO
SET IDENTITY_INSERT [dbo].[Notifications] ON 

INSERT [dbo].[Notifications] ([NotificationID], [Type], [Message]) VALUES (1, N'Reminder', N'Your court will begin in 30 minutes')
SET IDENTITY_INSERT [dbo].[Notifications] OFF
GO
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (1, CAST(N'2025-06-25T09:00:00.0000000' AS DateTime2), N'Complete', 40, N'Cash')
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (2, CAST(N'2025-06-27T09:00:00.0000000' AS DateTime2), N'Complete', 80, N'Card')
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (3, CAST(N'2025-06-27T09:00:00.0000000' AS DateTime2), N'Complete', 40, N'Cash')
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (4, CAST(N'2025-06-29T16:00:00.0000000' AS DateTime2), N'Complete', 40, N'Cash')
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (6, CAST(N'2025-06-29T08:00:00.0000000' AS DateTime2), N'Complete', 80, N'Card')
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (7, CAST(N'2025-06-30T10:00:00.0000000' AS DateTime2), N'Complete', 80, N'Card')
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (8, CAST(N'2025-06-30T12:00:00.0000000' AS DateTime2), N'Complete', 40, N'Cash')
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (9, CAST(N'2025-06-30T14:00:00.0000000' AS DateTime2), N'Complete', 80, N'Cash')
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (10, CAST(N'2025-06-30T16:00:00.0000000' AS DateTime2), N'Complete', 40, N'Cash')
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (11, CAST(N'2025-06-30T18:00:00.0000000' AS DateTime2), N'Complete', 40, N'Card')
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (12, CAST(N'2025-07-01T08:00:00.0000000' AS DateTime2), N'Complete', 80, N'Card')
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (13, CAST(N'2025-07-01T10:00:00.0000000' AS DateTime2), N'Complete', 80, N'Cash')
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (14, CAST(N'2025-07-01T12:00:00.0000000' AS DateTime2), N'Complete', 40, N'Cash')
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (15, CAST(N'2025-07-01T15:00:00.0000000' AS DateTime2), N'Complete', 80, N'Cash')
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (16, CAST(N'2025-07-01T17:00:00.0000000' AS DateTime2), N'Complete', 80, N'Card')
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (21, NULL, N'Uncomplete', 0, NULL)
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (23, NULL, N'Uncomplete', 0, NULL)
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (24, NULL, N'Uncomplete', 0, NULL)
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (25, NULL, N'Uncomplete', 0, NULL)
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (26, NULL, N'Uncomplete', 0, NULL)
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (27, NULL, N'Uncomplete', 0, NULL)
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (28, NULL, N'Uncomplete', 0, NULL)
INSERT [dbo].[Payments] ([BookingID], [PaidAt], [Status], [Amount], [Method]) VALUES (29, NULL, N'Uncomplete', 0, NULL)
GO
INSERT [dbo].[Points] ([UserID], [Point], [ClaimDate], [TotalRedeem], [Status]) VALUES (3, 50, CAST(N'2025-06-01T00:00:00.0000000' AS DateTime2), 10, N'Pending')
INSERT [dbo].[Points] ([UserID], [Point], [ClaimDate], [TotalRedeem], [Status]) VALUES (6, 70, CAST(N'2025-06-15T00:00:00.0000000' AS DateTime2), 20, N'Pending')
INSERT [dbo].[Points] ([UserID], [Point], [ClaimDate], [TotalRedeem], [Status]) VALUES (7, 0, NULL, 0, N'Pending')
INSERT [dbo].[Points] ([UserID], [Point], [ClaimDate], [TotalRedeem], [Status]) VALUES (8, 0, NULL, 0, N'Pending')
INSERT [dbo].[Points] ([UserID], [Point], [ClaimDate], [TotalRedeem], [Status]) VALUES (9, 0, NULL, 0, N'Pending')
INSERT [dbo].[Points] ([UserID], [Point], [ClaimDate], [TotalRedeem], [Status]) VALUES (10, 0, NULL, 0, N'Pending')
INSERT [dbo].[Points] ([UserID], [Point], [ClaimDate], [TotalRedeem], [Status]) VALUES (11, 0, NULL, 0, N'Pending')
INSERT [dbo].[Points] ([UserID], [Point], [ClaimDate], [TotalRedeem], [Status]) VALUES (12, 0, NULL, 0, N'Pending')
INSERT [dbo].[Points] ([UserID], [Point], [ClaimDate], [TotalRedeem], [Status]) VALUES (13, 0, NULL, 0, N'Pending')
INSERT [dbo].[Points] ([UserID], [Point], [ClaimDate], [TotalRedeem], [Status]) VALUES (14, 0, NULL, 0, N'Pending')
INSERT [dbo].[Points] ([UserID], [Point], [ClaimDate], [TotalRedeem], [Status]) VALUES (15, 0, NULL, 0, N'Pending')
INSERT [dbo].[Points] ([UserID], [Point], [ClaimDate], [TotalRedeem], [Status]) VALUES (16, 0, NULL, 0, N'Pending')
GO
SET IDENTITY_INSERT [dbo].[Reports] ON 

INSERT [dbo].[Reports] ([ReportID], [CreateAt], [TotalFreeHour]) VALUES (1, CAST(N'2025-06-01T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Reports] ([ReportID], [CreateAt], [TotalFreeHour]) VALUES (2, CAST(N'2025-06-01T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Reports] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Role], [Dob], [Phone], [NotificationID]) VALUES (1, N'Alice', N'Nguyen', N'Staff', CAST(N'1995-06-15' AS Date), N'0123456789', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Role], [Dob], [Phone], [NotificationID]) VALUES (2, N'Phong', N'Ngo', N'Owner', CAST(N'1990-01-20' AS Date), N'0987654321', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Role], [Dob], [Phone], [NotificationID]) VALUES (3, N'Tuan', N'Ngo', N'Member', CAST(N'1990-01-20' AS Date), N'0987654321', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Role], [Dob], [Phone], [NotificationID]) VALUES (4, N'Thao', N'Ngo', N'Staff', CAST(N'1995-06-15' AS Date), N'0123456789', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Role], [Dob], [Phone], [NotificationID]) VALUES (5, N'Huy', N'Nguyen', N'Owner', CAST(N'1990-01-20' AS Date), N'0987654321', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Role], [Dob], [Phone], [NotificationID]) VALUES (6, N'Quan', N'Ngo', N'Member', CAST(N'1990-01-20' AS Date), N'0987654321', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Role], [Dob], [Phone], [NotificationID]) VALUES (7, N'Nam', N'Tran', N'Member', CAST(N'1992-03-01' AS Date), N'0912345671', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Role], [Dob], [Phone], [NotificationID]) VALUES (8, N'Linh', N'Le', N'Member', CAST(N'1994-07-12' AS Date), N'0912345672', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Role], [Dob], [Phone], [NotificationID]) VALUES (9, N'Khoa', N'Pham', N'Member', CAST(N'1990-11-23' AS Date), N'0912345673', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Role], [Dob], [Phone], [NotificationID]) VALUES (10, N'Mai', N'Phuong', N'Member', CAST(N'2025-06-30' AS Date), N'0912345674', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Role], [Dob], [Phone], [NotificationID]) VALUES (11, N'Son', N'Hoang', N'Member', CAST(N'1993-04-05' AS Date), N'0912345675', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Role], [Dob], [Phone], [NotificationID]) VALUES (12, N'Lan', N'Doan', N'Member', CAST(N'1991-08-25' AS Date), N'0912345676', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Role], [Dob], [Phone], [NotificationID]) VALUES (13, N'Duy', N'Dang', N'Member', CAST(N'1995-02-10' AS Date), N'0912345677', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Role], [Dob], [Phone], [NotificationID]) VALUES (14, N'Ha', N'Nguyen', N'Member', CAST(N'1989-12-30' AS Date), N'0912345678', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Role], [Dob], [Phone], [NotificationID]) VALUES (15, N'Trang', N'Phan', N'Member', CAST(N'1997-01-09' AS Date), N'0912345679', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Role], [Dob], [Phone], [NotificationID]) VALUES (16, N'Minh', N'Vo', N'Member', CAST(N'1998-05-14' AS Date), N'0912345680', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [Role], [Dob], [Phone], [NotificationID]) VALUES (19, N'Phong', N'Ngo', N'Member', CAST(N'1998-05-14' AS Date), N'6572713454', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Bookings] ADD  CONSTRAINT [DF__Bookings__UserID__47DBAE45]  DEFAULT ((0)) FOR [UserID]
GO
ALTER TABLE [dbo].[Bookings] ADD  CONSTRAINT [DF__Bookings__Bookin__2739D489]  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [BookingDate]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF__User__Notificati__078C1F06]  DEFAULT ((0)) FOR [NotificationID]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_User_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_User_UserID]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Reports_ReportID] FOREIGN KEY([ReportID])
REFERENCES [dbo].[Reports] ([ReportID])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Reports_ReportID]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_User_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_User_UserID]
GO
ALTER TABLE [dbo].[CourtBookings]  WITH CHECK ADD  CONSTRAINT [FK_CourtBookings_Bookings_BookingId] FOREIGN KEY([BookingId])
REFERENCES [dbo].[Bookings] ([BookingID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CourtBookings] CHECK CONSTRAINT [FK_CourtBookings_Bookings_BookingId]
GO
ALTER TABLE [dbo].[CourtBookings]  WITH CHECK ADD  CONSTRAINT [FK_CourtBookings_Courts_CourtId] FOREIGN KEY([CourtId])
REFERENCES [dbo].[Courts] ([CourtID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CourtBookings] CHECK CONSTRAINT [FK_CourtBookings_Courts_CourtId]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_User_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_User_UserID]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Bookings_BookingID] FOREIGN KEY([BookingID])
REFERENCES [dbo].[Bookings] ([BookingID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Bookings_BookingID]
GO
ALTER TABLE [dbo].[Points]  WITH CHECK ADD  CONSTRAINT [FK_Points_User_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Points] CHECK CONSTRAINT [FK_Points_User_UserID]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Notifications_NotificationID] FOREIGN KEY([NotificationID])
REFERENCES [dbo].[Notifications] ([NotificationID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Notifications_NotificationID]
GO
