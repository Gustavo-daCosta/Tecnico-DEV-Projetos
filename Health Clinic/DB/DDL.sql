-- DML - Data Manipulation Language

USE HealthClinic

-- Inserir os valores
INSERT INTO TipoDeUsuario(TituloTipoUsuario)
VALUES ('Paciente'), ('Médico'), ('Administrador')

INSERT INTO Usuario(IdTipoUsuario, Nome, Email, Senha, Telefone, CPF, DataNascimento)
VALUES (1, 'Eduardo', 'eduardo@email.com', 'Eduardo123', '11546842304', '30145201975', '1992-04-12'),
(1, 'Beatriz', 'beatriz@email.com', 'Beatriz123', '11345621864', '84882463179', '1998-07-10'),
(2, 'Carlos', 'carlos@email.com', 'Carlos123', '11965428723', '21678432094', '1988-10-24'),
(2, 'Maria', 'maria@email.com', 'Maria123', '11235498575', '63521478592', '2000-05-01'),
(3, 'Gustavo', 'gustavo@email.com', 'Gustao123', '11942315697', '95713456025', '2006-09-15')

INSERT INTO Clinica(RazaoSocial, Endereco, CNPJ)
VALUES ('Health Clinic', 'Rua Niterói, 180', '324568')

INSERT INTO Especialidade(TituloEspecialidade, OrgaoDaEspecialidade)
VALUES ('Oftalmologista', 'Olhos'),
('Dermatologista', 'Pele'),
('Cardiologista', 'Coração')

INSERT INTO Medico(IdUsuario, IdEspecialidade, IdClinica, CRM)
VALUES (3, 1, 1, '36512'), (4, 2, 1, '79546')

INSERT INTO Paciente(IdUsuario)
VALUES (1), (2)

INSERT INTO Consulta(IdClinica, IdMedico, IdPaciente, Prontuario, [Data], Situacao)
VALUES (1, 1, 2, 'Paciente diagnosticado com Tersol no olho esquerdo', CONVERT(DATETIME, '2022-09-25 10:45:00', 121), 1),
(1, 2, 1, 'Paciente diagnosticado com Dermatite', CONVERT(DATETIME, '2022-10-12 11:30:00', 121), 1)

INSERT INTO Comentario(IdConsulta, Descricao, Exibe)
VALUES (1, 'Ótima consulta e médico atencioso', 1),
(2, 'Consulta boa, porém o médico aparentava estar sem vontade', 1)
