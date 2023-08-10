-- DML - Data Manipulation Language

USE [Event+]

-- Inserir valores
INSERT INTO TiposDeUsuario(TituloTiposUsuario)
VALUES ('Administrador'), ('Comum')

INSERT INTO TiposDeEvento(TituloTiposEvento)
VALUES ('Back-End'), ('Front-End')

INSERT INTO Instituicao(NomeFantasia,CNPJ, Endereco)
VALUES ('DevSchool', '81538464352145', 'Rua Niteroi, 180 São Caetano do Sul')

INSERT INTO Usuario(IdTipoDeUsuario, Nome, Email, Senha)
VALUES (1, 'Gabriel', 'gabriel@email.com', 'gabriel123'), (2, 'Gustavo', 'gustavo@email.com', 'gustavo123')

INSERT INTO Evento(IdTipoDeEvento, IdInstituicao, Nome, Descricao, DataEvento)
VALUES (1, 1, 'Intensivão de SQL Server', 'Evento para aprender a administrar bancos de dados com SQL através do SQL Server', '2023-12-10 10:34:09 PM'),
(2, 1, 'Aulão de React.js', 'Evento para se introduzir ao universo do React.js', '2023-10-06 12:43:10 AM')

INSERT INTO PresencasEvento(IdUsuario, IdEvento, Situacao)
VALUES (1, 2, 1), (2, 1, 0)

INSERT INTO ComentarioEvento(IdUsuario, IdEvento, Descricao, Exibe)
VALUES (1, 2, 'Ótimo evento! Gostei do aprendizado que tive e das pesssoas que conheci', 0),
(2, 1, 'Sempre quis aprender React.js e esse evento me ajudou muito nesse objetivo', 1)
