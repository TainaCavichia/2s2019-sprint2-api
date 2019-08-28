create table Usuarios
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR (200) NOT NULL,
	Senha VARCHAR (200) NOT NULL,
	Permissao VARCHAR (200) NOT NULL
);
create table Departamentos
(
	IdDepartamento INT PRIMARY KEY IDENTITY,
	Nome VARCHAR (200) NOT NULL UNIQUE
);
create table Cargos
(
	IdCargo INT PRIMARY KEY IDENTITY,
	Nome VARCHAR (200) NOT NULL UNIQUE,
	Ativo BIT DEFAULT (1)
);
create table Funcionarios
(
    IdFuncionario INT PRIMARY KEY IDENTITY,
	Nome VARCHAR (200) NOT NULL, 
	CPF VARCHAR (200) NOT NULL UNIQUE, 
	DataNascimento DATE NOT NULL, 
	Salário SMALLMONEY NOT NULL, 
	IdDepartamento INT FOREIGN KEY REFERENCES Departamentos (IdDepartamento), 
	IdCargo INT FOREIGN KEY REFERENCES Cargos (IdCargo),
	IdUsuário INT FOREIGN KEY REFERENCES Usuarios (IdUsuario)
);
insert into Usuarios (Email,Senha,Permissao)
values ('pessoaA@gmail.com','123123','ADMINISTRADOR'),
('pessoaB@gmail.com','123123','COMUM'),
('pessoaC@gmail.com','123123','COMUM'),
('pessoaD@gmail.com','123123','COMUM');

insert into Departamentos (Nome)
values ('PessoaA'),
('PessoaB'),
('PessoaC'),
('PessoaD');

update Departamentos set Nome = 'Médico' where IdDepartamento = 4;

insert into Cargos (Nome)
values ('Advogado Trabalhista'),
('Product Owner'),
('Guarda noturno'),
('Enfermeiro');

select * from Usuarios;
select * from Departamentos;
select * from Cargos;
select * from Funcionarios;

insert into Funcionarios (Nome, CPF, DataNascimento, Salário, IdDepartamento, IdCargo, IdUsuário)
values ('PessoaA','123123123-12','1999-01-01',9000,1,1,1),
	   ('PessoaB','124123123-12','1999-02-01',5000,2,2,2),
	   ('PessoaC','127123123-12','1999-03-01',2000,3,3,3),
	   ('PessoaD','123125123-12','1999-04-01',5000,4,4,4);