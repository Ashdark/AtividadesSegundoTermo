Use M_Peoples;

Create Database M_Peoples;

Create table Funcionarios(
	IdFuncionario INT PRIMARY KEY IDENTITY
	,Nome varchar(255) not null
	,Sobrenome varchar(255) not null
);
Alter table Funcionarios
add DataNascimento Datetime;

Insert Funcionarios(Nome,Sobrenome,DataNascimento)
	VALUES ('Catherine','Strada','2019-08-21T12:00:00'),('Tadeu','Vitelli','2019-08-21T12:00:00');

Select *	
	From Funcionarios;





