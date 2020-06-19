CREATE DATABASE ApiDotNetDapperDb;
GO

USE ApiDotNetDapperDb;
GO

CREATE TABLE [dbo].[Hero] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Publisher] [int] NOT NULL,	
	[AlterEgo] [nvarchar](50) NOT NULL,
	[HasSuperPower] [bit] NOT NULL,
	[Abilities] [nvarchar](200) NULL
);
GO

INSERT INTO Hero(Name, Publisher, AlterEgo, HasSuperPower, Abilities) Values 
('Homem-Aranha', 1, 'Peter Park', 1, 'Sentido aranha, super força, agilidade e grudar em superfícies.'),
('Batman', 2, 'Bruce Wayne', 0, 'Inteligência, agilidade, técnicas ninjutsu, dezenas de artes-marciais, mestrado em diversas máterias, senso de justiça.'),
('Mulher-Maravilha', 2, 'Princesa Diana', 1, 'Super força, super resistência, poder de cura, agilidade, artes-marciais.'),
('Viúva Negra', 1, 'Yelena Belova', 0, 'Agilidade, artes-marciais, treinamento em espionagem.'),
('Spawn', 4, 'Albert Francis "Al" Simmons', 1, 'Super força, agilidade, super resistência, fator de cura, artes-marciais, teletransporte, telepatia, capa demoniaca.');

