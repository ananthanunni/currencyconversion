USE [CurrencyConversionDb]
GO
/****** Object:  Table [dbo].[Currency]    Script Date: 2/12/2019 1:01:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currency](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](6) NULL,
	[Symbol] [nvarchar](6) NULL,
	[Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExchangeRate]    Script Date: 2/12/2019 1:01:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExchangeRate](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[From] [bigint] NOT NULL,
	[To] [bigint] NOT NULL,
	[Rate] [numeric](18, 9) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ExchangeRate]  WITH CHECK ADD FOREIGN KEY([From])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[ExchangeRate]  WITH CHECK ADD FOREIGN KEY([To])
REFERENCES [dbo].[Currency] ([Id])
GO
ALTER TABLE [dbo].[ExchangeRate]  WITH CHECK ADD CHECK  (([RATE]>(0)))
GO
