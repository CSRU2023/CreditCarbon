USE [CarbonCredit]
GO
/****** Object:  Table [dbo].[ProjectCarbon]    Script Date: 10/23/2023 2:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
DROP TABLE [dbo].[ProjectCarbon]

CREATE TABLE [dbo].[ProjectCarbon](
	[ProjectCarbonId] [int] IDENTITY(1,1) NOT NULL,
	[TechnologyTypeId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ProjectName] [nvarchar](255) NULL,
	[ProjectDescription] [nvarchar](255) NULL,
	[Location] [nvarchar](255) NULL,
	[LocationCoordinates] [nvarchar](255) NULL,
	[Investment] [int] NULL,
	[AmountGreenhouseGases] [int] NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[ProjectOwner] [nvarchar](255) NULL,
	[Coordinator] [nvarchar](255) NULL,
	[Position] [nvarchar](255) NULL,
	[Address] [nvarchar](255) NULL,
	[Tel] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[UpdatedByUserId] [int] NOT NULL,
 CONSTRAINT [PK_ProjectCarbon] PRIMARY KEY CLUSTERED 
(
	[ProjectCarbonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectCarbon_Developer]    Script Date: 10/23/2023 2:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectCarbon_Developer](
	[ProjectCarbon_DeveloperId] [int] NOT NULL,
	[ProjectCarbonId] [int] IDENTITY(1,1) NOT NULL,
	[Developer] [nvarchar](100) NULL,
	[Coordinator] [nvarchar](100) NULL,
	[Position] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[Tel] [nvarchar](10) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProjectCarbon_Developer] PRIMARY KEY CLUSTERED 
(
	[ProjectCarbon_DeveloperId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectCarbon_Status]    Script Date: 10/23/2023 2:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectCarbon_Status](
	[ProjectCarbon_StatusId] [int] NOT NULL,
	[ProjectCarbonId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[Massage] [nvarchar](100) NULL,
	[IsApprove] [bit] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
 CONSTRAINT [PK_ProjectCarbon_Status] PRIMARY KEY CLUSTERED 
(
	[ProjectCarbon_StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectCarbon_Transaction]    Script Date: 10/23/2023 2:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectCarbon_Transaction](
	[ProjectCarbon_TransactionId] [int] NOT NULL,
	[TransactionTypeId] [int] NOT NULL,
	[ProjectCarbonId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[AmountGreenhouseGases] [int] NOT NULL,
	[Price] [decimal](18, 2) NULL,
	[Massage] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
 CONSTRAINT [PK_ProjectCarbon_Transaction] PRIMARY KEY CLUSTERED 
(
	[ProjectCarbon_TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[TransactionType]    Script Date: 10/23/2023 2:42:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionType](
	[TransactionTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TransactionTypeCode] [nvarchar](50) NULL,
	[TransactionTypeName] [nvarchar](100) NULL,
	[Description] [nvarchar](255) NULL,
 CONSTRAINT [PK_TransactionType] PRIMARY KEY CLUSTERED 
(
	[TransactionTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TransactionType] ON 

INSERT [dbo].[TransactionType] ([TransactionTypeId], [TransactionTypeCode], [TransactionTypeName], [Description]) VALUES (1, N'TransferCredit', N'Transfer Credit', N'ถ่ายโอนเครดิตไปยังบัญชีอื่น')
INSERT [dbo].[TransactionType] ([TransactionTypeId], [TransactionTypeCode], [TransactionTypeName], [Description]) VALUES (2, N'Sale', N'Sale', N'เสนอขายเครดิต')
SET IDENTITY_INSERT [dbo].[TransactionType] OFF
GO
ALTER TABLE [dbo].[ProjectCarbon]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCarbon_TechnologyType] FOREIGN KEY([TechnologyTypeId])
REFERENCES [dbo].[TechnologyType] ([TechnologyTypeId])
GO
ALTER TABLE [dbo].[ProjectCarbon] CHECK CONSTRAINT [FK_ProjectCarbon_TechnologyType]
GO
ALTER TABLE [dbo].[ProjectCarbon]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCarbon_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[ProjectCarbon] CHECK CONSTRAINT [FK_ProjectCarbon_User]
GO
ALTER TABLE [dbo].[ProjectCarbon_Developer]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCarbon_Developer_ProjectCarbon] FOREIGN KEY([ProjectCarbonId])
REFERENCES [dbo].[ProjectCarbon] ([ProjectCarbonId])
GO
ALTER TABLE [dbo].[ProjectCarbon_Developer] CHECK CONSTRAINT [FK_ProjectCarbon_Developer_ProjectCarbon]
GO
ALTER TABLE [dbo].[ProjectCarbon_Status]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCarbon_Status_ProjectCarbon] FOREIGN KEY([ProjectCarbonId])
REFERENCES [dbo].[ProjectCarbon] ([ProjectCarbonId])
GO
ALTER TABLE [dbo].[ProjectCarbon_Status] CHECK CONSTRAINT [FK_ProjectCarbon_Status_ProjectCarbon]
GO
ALTER TABLE [dbo].[ProjectCarbon_Status]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCarbon_Status_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[ProjectCarbon_Status] CHECK CONSTRAINT [FK_ProjectCarbon_Status_Status]
GO
ALTER TABLE [dbo].[ProjectCarbon_Transaction]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCarbon_Transaction_ProjectCarbon] FOREIGN KEY([ProjectCarbonId])
REFERENCES [dbo].[ProjectCarbon] ([ProjectCarbonId])
GO
ALTER TABLE [dbo].[ProjectCarbon_Transaction] CHECK CONSTRAINT [FK_ProjectCarbon_Transaction_ProjectCarbon]
GO
ALTER TABLE [dbo].[ProjectCarbon_Transaction]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCarbon_Transaction_TransactionType] FOREIGN KEY([TransactionTypeId])
REFERENCES [dbo].[TransactionType] ([TransactionTypeId])
GO
ALTER TABLE [dbo].[ProjectCarbon_Transaction] CHECK CONSTRAINT [FK_ProjectCarbon_Transaction_TransactionType]
GO