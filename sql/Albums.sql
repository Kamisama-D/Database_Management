USE [musicstore]
GO

/****** Object:  Table [dbo].[Albums]    Script Date: 2022/11/13 16:27:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Albums](
	[AlbumId] [int] IDENTITY(1,1) NOT NULL,
	[GenreId] [int] NOT NULL,
	[ArtistId] [int] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[AlbumArtUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Albums] PRIMARY KEY CLUSTERED 
(
	[AlbumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Albums]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Albums_dbo.Artists_ArtistId] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artists] ([ArtistId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Albums] CHECK CONSTRAINT [FK_dbo.Albums_dbo.Artists_ArtistId]
GO

ALTER TABLE [dbo].[Albums]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Albums_dbo.Genres_GenreId] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([GenreId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Albums] CHECK CONSTRAINT [FK_dbo.Albums_dbo.Genres_GenreId]
GO

