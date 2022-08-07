
USE [HelpingMinds]
GO

/****** Object:  Table [dbo].[Events]    Script Date: 8/1/2022 8:37:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

alter table reminder
add numOfTimeRepeat int,
uuid varchar(200),
completed bit