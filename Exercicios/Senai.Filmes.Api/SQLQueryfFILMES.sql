USE M_RoteiroFilmes

SELECT * FROM Generos ORDER BY IdGenero ASC;

SELECT * FROM Filmes;

INSERT INTO Generos (Nome)
VALUES ('Pop'),
	   ('Rock'),
	   ('Funk'),
	   ('Clássica'),
	   ('R&B'),
	   ('MPB');

INSERT INTO Filmes (Titulo,IdGenero)
VALUES ('Branca de Neve',2),
	   ('Peter Pan',4),
	   ('O Rei Leão',7),
	   ('Toy Story',6);

	   SELECT IdFilme, Titulo, IdGenero FROM Filmes WHERE IdFilme = 1