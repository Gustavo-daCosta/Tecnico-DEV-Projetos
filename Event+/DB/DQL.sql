-- DQL - Data Query Language

USE [Event+]

-- Criar script para consulta usando JOIN e exibindo os seguintes dados

-- Nome do usuário
-- Tipo do usuário			    - Data do evento
-- Local do evento (Instituição)	- Titulo do evento
-- Nome do evento					- Descrição do evento
-- Situação do evento				- Comentário do evento


SELECT
	Usuario.Nome AS 'Nome do usuário',
	TiposDeUsuario.TituloTiposUsuario AS 'Tipo de usuário',
	Evento.Nome AS 'Nome do evento',
	Evento.Descricao AS 'Descrição do evento',
	Evento.DataEvento AS 'Data do evento',
	CONCAT(Instituicao.NomeFantasia, ' - ', Instituicao.Endereco) AS 'Local do evento',
	CASE WHEN PresencasEvento.Situacao = 1 THEN 'Confirmado' ELSE 'Não Confirmado' END AS 'Situação do evento',
	ComentarioEvento.Descricao AS 'Comentários do evento'
FROM
	Evento
	INNER JOIN PresencasEvento ON PresencasEvento.IdEvento = Evento.IdEvento
	INNER JOIN Usuario ON PresencasEvento.IdUsuario = Usuario.IdUsuario
	INNER JOIN TiposDeUsuario ON Usuario.IdTipoDeUsuario = TiposDeUsuario.IdTiposDeUsuario
	INNER JOIN Instituicao ON Evento.IdInstituicao = Instituicao.IdInstituicao
	LEFT JOIN ComentarioEvento ON ComentarioEvento.IdUsuario = Usuario.IdUsuario
