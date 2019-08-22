USE M_SStop

SELECT * FROM Artistas

SELECT A.IdArtista, A.Nome, A.IdEstiloMusical, E.Nome AS NomeEstilo FROM Artistas A INNER JOIN EstilosMusicas E ON A.IdEstiloMusical = E.IdEstiloMusical