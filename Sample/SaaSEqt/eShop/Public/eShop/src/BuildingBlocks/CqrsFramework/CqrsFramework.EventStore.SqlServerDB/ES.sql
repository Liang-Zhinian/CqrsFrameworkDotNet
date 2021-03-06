/****** Object:  Table [dbo].[EventWrappers]    Script Date: 02/20/2012 23:55:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventWrappers]') AND type in (N'U'))
DROP TABLE [dbo].[EventWrappers]
GO
/****** Object:  Table [dbo].[Streams]    Script Date: 02/20/2012 23:55:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Streams]') AND type in (N'U'))
DROP TABLE [dbo].[Streams]
GO
/****** Object:  Table [dbo].[Streams]    Script Date: 02/20/2012 23:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Streams]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Streams](
	[StreamID] [nvarchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[CurrentSequence] [bigint] NOT NULL,
 CONSTRAINT [PK_Streams] PRIMARY KEY CLUSTERED 
(
	[StreamID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[EventWrappers]    Script Date: 02/20/2012 23:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventWrappers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EventWrappers](
	[EventId] [uniqueidentifier] NOT NULL,
	[StreamId] [nvarchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[Sequence] [bigint] NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[EventType] [nvarchar](250) COLLATE Latin1_General_CI_AS NOT NULL,
	[Body] [nvarchar](max) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_EventWrappers] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
