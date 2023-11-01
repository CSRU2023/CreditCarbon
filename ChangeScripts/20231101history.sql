USE [CarbonCredit]
GO

/****** Object:  Table [dbo].[ProjectCarbonMarkets_History]    Script Date: 11/1/2023 3:05:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProjectCarbonMarkets_History](
	[HistoryId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectCarbonMarketsId] [int] NOT NULL,
	[ProjectCarbonId] [int] NOT NULL,
	[AmountGreenhouseGases_Buy] [int] NULL,
	[AmountGreenhouseGases_Remaining] [int] NULL,
	[Price] [int] NULL,
	[UnitPrice] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
 CONSTRAINT [PK_ProjectCarbonMarkets_History] PRIMARY KEY CLUSTERED 
(
	[HistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProjectCarbonMarkets_History]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCarbonMarkets_History_ProjectCarbon] FOREIGN KEY([ProjectCarbonId])
REFERENCES [dbo].[ProjectCarbon] ([ProjectCarbonId])
GO

ALTER TABLE [dbo].[ProjectCarbonMarkets_History] CHECK CONSTRAINT [FK_ProjectCarbonMarkets_History_ProjectCarbon]
GO

ALTER TABLE [dbo].[ProjectCarbonMarkets_History]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCarbonMarkets_History_ProjectCarbonMarkets] FOREIGN KEY([ProjectCarbonMarketsId])
REFERENCES [dbo].[ProjectCarbonMarkets] ([ProjectCarbonMarketsId])
GO

ALTER TABLE [dbo].[ProjectCarbonMarkets_History] CHECK CONSTRAINT [FK_ProjectCarbonMarkets_History_ProjectCarbonMarkets]
GO


