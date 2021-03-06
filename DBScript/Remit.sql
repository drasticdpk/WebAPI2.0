-- Note
-- Create Database as Remit

USE [Remit]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2/8/17 11:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[PhoneNo] [varchar](15) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 2/8/17 11:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CID] [int] NULL,
	[Amount] [int] NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

GO
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo]) VALUES (3, N'Ram Update', N'9847092495')
GO
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo]) VALUES (4, NULL, NULL)
GO
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo]) VALUES (5, NULL, NULL)
GO
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo]) VALUES (6, N'Ram Kalu5', N'9847092495')
GO
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo]) VALUES (7, N'Ram Kalu100', N'9847092495')
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
