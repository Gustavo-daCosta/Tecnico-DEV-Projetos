-- DDL - Data Definition Language

-- Criar o banco de dados
CREATE DATABASE [Event+]

USE [Event+]

-- Criar as tabelas
CREATE TABLE TiposDeUsuario(
	IdTiposDeUsuario INT PRIMARY KEY IDENTITY,
	TituloTiposUsuario VARCHAR(50) NOT NULL UNIQUE,
);

CREATE TABLE TipoDeEvento(
	IdTipoDeEvento INT PRIMARY KEY IDENTITY,
	TituloTiposEvento VARCHAR(50) NOT NULL UNIQUE,
);

CREATE TABLE Instituicao(
	IdInstituicao INT PRIMARY KEY IDENTITY,
	NomeFantasia VARCHAR(80) NOT NULL,
	CNPJ CHAR(14) NOT NULL UNIQUE,
	Endereço VARCHAR(60) NOT NULL,
);

CREATE TABLE Usuario(
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoDeUsuario INT FOREIGN KEY REFERENCES TiposDeUsuario(IdTiposDeUsuario) NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	Email VARCHAR(64) NOT NULL UNIQUE,
	Senha VARCHAR(32) NOT NULL,
);

CREATE TABLE Evento(
	IdEvento INT PRIMARY KEY IDENTITY,
	IdTipoDeEvento INT FOREIGN KEY REFERENCES TipoDeEvento(IdTipoDeEvento) NOT NULL,
	IdInstituicao INT FOREIGN KEY REFERENCES Instituicao(IdInstituicao) NOT NULL,
	Nome VARCHAR(80) NOT NULL,
	Descricao VARCHAR(200) NOT NULL,
	DataEvento DATE NOT NULL,
	HoraEvento TIME NOT NULL,
);

CREATE TABLE PresencasEvento(
	IdPresencaEvento INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento) NOT NULL,
	Situacao BIT DEFAULT(0),
);

CREATE TABLE ComentarioEvento(
	IdComentarioEvento INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento) NOT NULL,
	Descricao VARCHAR(300) NOT NULL,
	DataComentario DATETIME DEFAULT GETDATE(),
	Exibe BIT NOT NULL,
);
