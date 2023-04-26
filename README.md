# CursoIdiomas

## Sobre

Essa api foi criada como um simples cadastro de aluno, turmas e a inscrição destes alunos na turma, com as seguintes regras:
- Aluno deve ser cadastrado com no mínimo 1 turma;
- O e-mail e CPF do aluno não pode ser inválido;
- Aluno pode se matricular em diversas turmas, mas não mais de 1x na mesma turma;
- Uma turma não pode ter mais de 5 alunos;
- Aluno não pode ser excluído se estiver associado em uma turma;
- Turma não pode ser excluída se possuir alunos;

## O que foi utilizado

Linguagem: C# (.NET)
ORM: Entity Framework

Banco de dados: SQL Server

## Sobre o código

Foi utilizado DDD, com clean architecture, e o banco de dados foi criado pelo código, via migrations

No código temos as camadas:
- Domain, onde estão inseridos os modelos que norteiam as regras;
- Data, onde é feita a comunicação com o banco de dados
- Business, onde ficam as regras específicas de validação
- API, onde é feita a interface de comunicação do usuário
- CrossCutting, camada onde ficam itens que se comunicam com mais de uma camada

## Sobre as entidades

O código possui 3 entidades, sendo uma delas apenas relacional
- Aluno, que emula um aluno que será inscrito em uma turma
- Turma, que emula uma turma que poderá comportar alunos
- AlunoTurma, que é a entidade relacional, que representaria a inscrição do aluno na turma