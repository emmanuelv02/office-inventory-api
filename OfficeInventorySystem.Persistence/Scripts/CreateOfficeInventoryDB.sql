CREATE DATABASE OfficeInventoryDB;
GO

USE [OfficeInventoryDB]
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 5/9/2025 1:30:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Brand] [nvarchar](100) NOT NULL,
	[Model] [nvarchar](100) NOT NULL,
	[EquipmentTypeId] [int] NOT NULL,
	[PurchaseDate] [date] NOT NULL,
	[SerialNumber] [nvarchar](100) NULL,
 CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentMaintenance]    Script Date: 5/9/2025 1:30:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentMaintenance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentId] [int] NOT NULL,
	[MaintenanceTaskId] [int] NOT NULL,
 CONSTRAINT UQ_EquipmentMaintenance_EquipmentId_MaintenanceTaskId UNIQUE (EquipmentId, MaintenanceTaskId),
 CONSTRAINT [PK_EquipmentMaintenance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquipmentType]    Script Date: 5/9/2025 1:30:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquipmentType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_EquipmentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaintenanceTask]    Script Date: 5/9/2025 1:30:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaintenanceTask](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_MaintenanceTask] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EquipmentType] ON 

INSERT [dbo].[EquipmentType] ([Id], [Description]) VALUES (1, N'Laptop')
INSERT [dbo].[EquipmentType] ([Id], [Description]) VALUES (2, N'Desktop')
INSERT [dbo].[EquipmentType] ([Id], [Description]) VALUES (3, N'Printer')
INSERT [dbo].[EquipmentType] ([Id], [Description]) VALUES (4, N'Monitor')
SET IDENTITY_INSERT [dbo].[EquipmentType] OFF
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_EquipmentType] FOREIGN KEY([EquipmentTypeId])
REFERENCES [dbo].[EquipmentType] ([Id])
GO
ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK_Equipment_EquipmentType]
GO
ALTER TABLE [dbo].[EquipmentMaintenance]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentMaintenance_Equipment] FOREIGN KEY([EquipmentId])
REFERENCES [dbo].[Equipment] ([Id])
GO
ALTER TABLE [dbo].[EquipmentMaintenance] CHECK CONSTRAINT [FK_EquipmentMaintenance_Equipment]
GO
ALTER TABLE [dbo].[EquipmentMaintenance]  WITH CHECK ADD  CONSTRAINT [FK_EquipmentMaintenance_MaintenanceTask] FOREIGN KEY([MaintenanceTaskId])
REFERENCES [dbo].[MaintenanceTask] ([Id])
GO
ALTER TABLE [dbo].[EquipmentMaintenance] CHECK CONSTRAINT [FK_EquipmentMaintenance_MaintenanceTask]
GO
