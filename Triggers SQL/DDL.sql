-- DDL - Data Definition Language

-- Criar e usar banco de dados
CREATE DATABASE TriggersSQL
USE TriggersSQL;

-- Criar tabelas do banco
CREATE TABLE Genero(
	IdGenero INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(25) NOT NULL UNIQUE,
);

CREATE TABLE Filme(
	IdFilme INT PRIMARY KEY IDENTITY,
	IdGenero INT FOREIGN KEY REFERENCES Genero(IdGenero) NOT NULL,
	Nome VARCHAR(50) NOT NULL UNIQUE,
	DataLancamento DATE NOT NULL,
);

CREATE TABLE Historico (
	IdHistorico INT PRIMARY KEY IDENTITY,
	Tabela VARCHAR(30) NOT NULL,
	Descricao VARCHAR(60) NOT NULL,
	[Action] VARCHAR(60) NOT NULL,
	[Data] DATETIME NOT NULL,
);
