USE [NewDB]
GO

/****** Object:  Table [dbo].[SYS_LOG]    Script Date: 2016/12/2 10:48:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SYS_LOG](
	[ID] [INT] IDENTITY(1,1) NOT NULL,
	[DATES] [DATETIME] NULL,
	[LEVELS] [NVARCHAR](20) NULL,
	[LOGGER] [NVARCHAR](200) NULL,
	[CLIENTUSER] [NVARCHAR](100) NULL,
	[CLIENTIP] [NVARCHAR](20) NULL,
	[REQUESTURL] [NVARCHAR](500) NULL,
	[ACTION] [NVARCHAR](20) NULL,
	[MESSAGE] [NVARCHAR](4000) NULL,
	[EXCEPTION] [NVARCHAR](4000) NULL,
 CONSTRAINT [PK_SYS_LOG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'DATES'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'LEVELS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志调用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'LOGGER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'CLIENTUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'访问IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'CLIENTIP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'访问来源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'REQUESTURL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作动作' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'ACTION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'MESSAGE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'异常消息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'EXCEPTION'
GO


