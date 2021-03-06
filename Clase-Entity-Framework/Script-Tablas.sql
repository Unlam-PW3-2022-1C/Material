USE [master]
GO
/****** Object:  Database [PracticaWebServices]    Script Date: 6/17/2020 8:08:20 PM ******/
CREATE DATABASE [2022-1C-Practica-EF]
GO
 
USE [2022-1C-Practica-EF]
GO
/****** Object:  Table [dbo].[Animal]    Script Date: 6/17/2020 8:08:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Animal](
	[IdAnimal] [int] IDENTITY(1,1) NOT NULL,
	[NombreEspecie] [nvarchar](200) NOT NULL,
	[PesoPromedio] [float] NOT NULL,
	[EdadPromedio] [int] NOT NULL,
	[IdTipoAnimal] [int] NOT NULL,
 CONSTRAINT [PK_Animal] PRIMARY KEY CLUSTERED 
(
	[IdAnimal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TipoAnimal]    Script Date: 6/17/2020 8:08:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoAnimal](
	[IdTipoAnimal] [int] NOT NULL,
	[Nombre] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_TipoAnimal] PRIMARY KEY CLUSTERED 
(
	[IdTipoAnimal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Animal]  WITH CHECK ADD  CONSTRAINT [FK_Animal_TipoAnimal] FOREIGN KEY([IdTipoAnimal])
REFERENCES [dbo].[TipoAnimal] ([IdTipoAnimal])
GO
ALTER TABLE [dbo].[Animal] CHECK CONSTRAINT [FK_Animal_TipoAnimal]
GO

INSERT INTO TipoAnimal VALUES (1, 'Herbivoro')
INSERT INTO TipoAnimal VALUES (2, 'Carnivoro')