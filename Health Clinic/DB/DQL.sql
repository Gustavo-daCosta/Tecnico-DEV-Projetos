-- DQL - Data Query Language

USE HealthClinic

/*
- Id Consulta
- Data da Consulta
- Horario da Consulta
- Nome da Clinica
- Nome do Paciente
- Nome do Medico
- Especialidade do Medico
- CRM
- Prontuário ou Descricao
- FeedBack(Comentario da consulta)
*/

SELECT
	Consulta.IdConsulta AS 'Id da Consulta',
	CONVERT(DATE, Consulta.[Data]) AS 'Data da Consulta',
	CAST(Consulta.[Data] AS TIME(0)) AS 'Horário da Consulta',
	Clinica.RazaoSocial AS 'Nome da Clínica',
	Med.Nome AS 'Nome do Médico',
	Pac.Nome AS 'Nome do Paciente',
	Especialidade.TituloEspecialidade AS 'Especialidade',
	Medico.CRM,
	Consulta.Prontuario,
	Comentario.Descricao
FROM 
	Consulta
	INNER JOIN Paciente ON Paciente.IdPaciente LIKE Consulta.IdPaciente
	INNER JOIN Medico ON Medico.IdMedico LIKE Consulta.IdMedico
	INNER JOIN Usuario AS Med ON Med.IdUsuario LIKE Medico.IdUsuario
	INNER JOIN Usuario AS Pac ON Pac.IdUsuario LIKE Paciente.IdUsuario
	INNER JOIN Clinica ON Clinica.IdClinica LIKE Consulta.IdClinica
	INNER JOIN Especialidade ON Especialidade.IdEspecialidade LIKE Medico.IdEspecialidade
	LEFT JOIN Comentario ON Comentario.IdConsulta LIKE Consulta.IdConsulta

--Criar função para retornar os médicos de uma determinada especialidade
GO
CREATE FUNCTION DoctorsFromEspeciality(@IdEspecialidade INT)
RETURNS TABLE
AS
RETURN (
SELECT
	Med.Nome AS 'Nome do Médico',
	Especialidade.TituloEspecialidade AS 'Especialidade'
FROM
	Usuario AS Med
	INNER JOIN Medico ON Medico.IdUsuario LIKE Med.IdUsuario
	INNER JOIN Especialidade ON Especialidade.IdEspecialidade LIKE Medico.IdEspecialidade
WHERE
	Especialidade.IdEspecialidade LIKE @IdEspecialidade
)
GO

SELECT * FROM DoctorsFromEspeciality(1)

--Criar procedure para retornar a idade de um determinado usuário específico
