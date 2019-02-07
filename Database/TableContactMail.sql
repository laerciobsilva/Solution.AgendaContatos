USE [AgendaContatos]
GO

/****** Object:  Table [dbo].[ContactMail]    Script Date: 07/02/2019 07:32:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ContactMail](
	[ContactMailId] [int] IDENTITY(1,1) NOT NULL,
	[Address] [varchar](90) NOT NULL,
	[ContactTypeId] [int] NOT NULL,
	[ContactId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ContactMailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ContactMail] UNIQUE NONCLUSTERED 
(
	[ContactId] ASC,
	[Address] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ContactMail]  WITH CHECK ADD  CONSTRAINT [FK_ContactMail_ContactTypeId] FOREIGN KEY([ContactTypeId])
REFERENCES [dbo].[ContactType] ([ContactTypeId])
GO

ALTER TABLE [dbo].[ContactMail] CHECK CONSTRAINT [FK_ContactMail_ContactTypeId]
GO


