USE [AgendaContatos]
GO

/****** Object:  Table [dbo].[ContactPhone]    Script Date: 07/02/2019 07:32:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ContactPhone](
	[ContactPhoneId] [int] IDENTITY(1,1) NOT NULL,
	[Number] [varchar](13) NOT NULL,
	[ContactTypeId] [int] NOT NULL,
	[ContactId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ContactPhoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ContactPhone] UNIQUE NONCLUSTERED 
(
	[ContactId] ASC,
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ContactPhone]  WITH CHECK ADD  CONSTRAINT [FK_ContactPhone_ContactTypeId] FOREIGN KEY([ContactTypeId])
REFERENCES [dbo].[ContactType] ([ContactTypeId])
GO

ALTER TABLE [dbo].[ContactPhone] CHECK CONSTRAINT [FK_ContactPhone_ContactTypeId]
GO


