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

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'DATES'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��־�ȼ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'LEVELS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��־����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'LOGGER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ʹ���û�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'CLIENTUSER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'CLIENTIP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������Դ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'REQUESTURL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'ACTION'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Ϣ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'MESSAGE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�쳣��Ϣ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SYS_LOG', @level2type=N'COLUMN',@level2name=N'EXCEPTION'
GO


