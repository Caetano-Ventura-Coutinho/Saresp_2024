create database Saresp_2024;
use Saresp_2024;

create table ProfessorAplicador(
Idprofessor int auto_increment primary key,
Nome varchar(200) not null,
CPF decimal(11,0) not null,
RG varchar(9) not null,
Telefone decimal(11,0) not null,
DataNascimento datetime not null
);

create table Aluno(
IdAluno int auto_increment primary key,
Nome varchar(200) not null,
Email varchar(200) not null,
Serie int not null, 
Turma char(1),
Telefone decimal(11,0) not null,
DataNascimento datetime not null
)
