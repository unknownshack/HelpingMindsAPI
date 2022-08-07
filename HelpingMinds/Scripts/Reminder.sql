USE [HelpingMinds]
GO

/****** Object:  Table [dbo].[Reminder]    Script Date: 8/1/2022 8:37:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Reminder](
	[reminderId] [int] IDENTITY(1,1) NOT NULL,
	[eventId] [int] NULL,
	[priority] [int] NULL,
	[repeat] [int] NULL,
	[numOfTimeRepeat] [int] NULL,
	[uuid] [varchar](200) NULL,
	[completed] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[reminderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Reminder]  WITH CHECK ADD FOREIGN KEY([eventId])
REFERENCES [dbo].[Events] ([eventId])
GO


