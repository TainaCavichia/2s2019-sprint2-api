CREATE DATABASE M_Peoples;

USE M_Peoples;

CREATE TABLE Funcionarios
(
	IdFuncionario INT PRIMARY KEY IDENTITY
	,Nome VARCHAR (200) NOT NULL 
	,Sobrenome VARCHAR (200) NOT NULL
);

INSERT INTO Funcionarios (Nome, Sobrenome)
	VALUES ('Catarina','Strada'), 
		   ('Tadeu' ,'Vitelli');

SELECT * FROM Funcionarios;