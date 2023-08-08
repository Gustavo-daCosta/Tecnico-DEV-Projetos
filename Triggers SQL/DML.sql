INSERT INTO Genero(Nome)
VALUES ('Terror')

UPDATE Genero
SET Nome = 'Suspense'
WHERE Genero.Nome = 'Terror'

DELETE FROM Genero WHERE Genero.Nome = 'Suspense'
