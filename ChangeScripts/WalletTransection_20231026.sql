USE [CarbonCredit]
GO

/****** Object:  Table [dbo].[WalletTransaction]    Script Date: 10/26/2023 6:08:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
drop table [dbo].[WalletTransaction]
CREATE TABLE [dbo].[WalletTransaction](
	[WalletTransactionId] [int] NOT NULL,
	[WalletId] [int] NOT NULL,
	[WalletMoney_TopUp] [decimal](18, 2) NULL,
	[WalletMoney_Receive] [decimal](18, 2) NULL,
	[WalletCarbon_Transfer] [decimal](18, 2) NULL,
	[WalletCarbon_Recevice] [decimal](18, 2) NULL,
	[WalletCarbon] [decimal](18, 2) NULL,
	[Image] [binary](50) NULL,
	[Massage] [nvarchar](100) NULL,
	[StatusTransaction] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[UpdatedByUserId] [int] NOT NULL,
 CONSTRAINT [PK_WalletTransaction] PRIMARY KEY CLUSTERED 
(
	[WalletTransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[WalletTransaction]  WITH CHECK ADD  CONSTRAINT [FK_WalletTransaction_Wallet] FOREIGN KEY([WalletId])
REFERENCES [dbo].[Wallet] ([WalletId])
GO

ALTER TABLE [dbo].[WalletTransaction] CHECK CONSTRAINT [FK_WalletTransaction_Wallet]
GO


