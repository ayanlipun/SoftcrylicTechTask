USE [Softcrylic]
GO

/****** Object:  Table [dbo].[tblEvent]    Script Date: 4/12/2023 10:00:23 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblEvent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Description] [varchar](100) NULL,
	[Date] [datetime] NULL,
	[ModeOfEvent] [varchar](100) NULL,
	[Venue] [varchar](100) NULL,
	[Website] [varchar](100) NULL,
	[LinkForDetails] [varchar](100) NULL,
	[SpeakerId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblEvent]  WITH CHECK ADD FOREIGN KEY([SpeakerId])
REFERENCES [dbo].[tblSpeaker] ([Id])
GO



USE [Softcrylic]
GO

/****** Object:  Table [dbo].[tblSpeaker]    Script Date: 4/12/2023 10:00:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblSpeaker](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Bio] [varchar](100) NOT NULL,
	[SocialLinks] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
