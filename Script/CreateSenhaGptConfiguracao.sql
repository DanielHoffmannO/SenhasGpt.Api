USE [Senha]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SenhaGptConfiguracao](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[EmailCadastro] [varchar](100) NOT NULL,
	[UrlBase] [varchar](100) NOT NULL,
	[ChaveAcesso] [varchar](60) NOT NULL,
	[DataCadastro] [datetime] NULL,
	[DataVigencia] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


