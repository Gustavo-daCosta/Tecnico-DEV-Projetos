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
	[Action]
	[Data] DATETIME NOT NULL,
);

INSERT INTO Genero(Nome)
VALUES ('Terror')

UPDATE Genero
SET Nome = 'Suspense'
WHERE Genero.Nome = 'Terror'

DELETE FROM Genero WHERE Genero.Nome = 'Suspense'

SELECT * FROM Historico
/*
GO
CREATE TRIGGER SalvarHistorico
ON Genero
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE
	@DESCRICAO VARCHAR(60)

	SELECT @DESCRICAO = Nome FROM update

	INSERT INTO Historico(Tabela, Descricao, [Data])
	VALUES ('Genero', @DESCRICAO, GETDATE())
END*/

GO
CREATE TRIGGER SalvaHistorico
ON Genero
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	DECLARE 
		@Verificacao VARCHAR(6),
		@NomeAntigo VARCHAR (50),
		@NomeNovo VARCHAR (50),
		@Descricao VARCHAR(60)

	SET @Verificacao = (
		CASE WHEN
		-- Quando um valor é atualizado, por baixo dos panos o SQL deleta o valor antigo e adiciona o novo
		EXISTS (SELECT * FROM INSERTED) AND EXISTS (SELECT * FROM DELETED)
			THEN 'Update'
		WHEN EXISTS (SELECT * FROM INSERTED)
			THEN 'Insert'
		WHEN EXISTS (SELECT * FROM DELETED)
			THEN 'Delete'
		END
	)

	SELECT @NomeNovo = Nome FROM INSERTED
	SELECT @NomeAntigo = Nome FROM DELETED

	IF @Verificacao = 'Update'
		SELECT @Descricao = ('O gênero ' + @NomeAntigo + ' foi renomeado para ' + @NomeNovo)
	ELSE IF @Verificacao = 'Insert'
		SELECT @Descricao = ('O gênero ' + @NomeNovo + ' foi inserido')
	ELSE
		SELECT @Descricao = ('O gênero ' + @NomeAntigo + ' foi deletado')

	INSERT INTO Historico(Tabela, Descricao, [Data])
	VALUES ('Genero', @Descricao, GETDATE())
END
