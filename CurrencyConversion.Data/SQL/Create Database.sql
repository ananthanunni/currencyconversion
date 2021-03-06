USE [CurrencyConversionDb]
GO
/****** Object:  Table [dbo].[Currency]    Script Date: 2/12/2019 8:24:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currency](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](6) NULL,
	[Symbol] [nvarchar](6) NULL,
	[Name] [nvarchar](30) NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExchangeRate]    Script Date: 2/12/2019 8:24:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExchangeRate](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FromId] [bigint] NOT NULL,
	[ToId] [bigint] NOT NULL,
	[Rate] [numeric](18, 9) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ExchangeRate]  WITH CHECK ADD FOREIGN KEY([FromId])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[ExchangeRate]  WITH CHECK ADD FOREIGN KEY([ToId])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[ExchangeRate]  WITH CHECK ADD CHECK  (([RATE]>(0)))
GO
