USE [AgendaContatos]
GO

/****** Object:  Table [dbo].[Contact]    Script Date: 07/02/2019 07:31:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contact](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](25) NOT NULL,
	[Address] [varchar](50) NULL,
	[Company] [varchar](50) NULL,
 CONSTRAINT [pk_contact] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


