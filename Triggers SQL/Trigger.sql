-- Trigger

-- Utiliza o banco de dados
USE TriggersSQL;

GO
-- Cria o Trigger
CREATE TRIGGER SalvarHistoricoGenero
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

-- Cria o Trigger
CREATE TRIGGER SalvarHistoricoFilme
ON Filme
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
		SELECT @Descricao = ('O filme ' + @NomeAntigo + ' foi renomeado para ' + @NomeNovo)
	ELSE IF @Verificacao = 'Insert'
		SELECT @Descricao = ('O filme ' + @NomeNovo + ' foi inserido')
	ELSE
		SELECT @Descricao = ('O filme ' + @NomeAntigo + ' foi deletado')

	INSERT INTO Historico(Tabela, Descricao, [Data])
	VALUES ('Filme', @Descricao, GETDATE())
END
