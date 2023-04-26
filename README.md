# CursoIdiomas

## Sobre

Essa api foi criada como um simples cadastro de aluno, turmas e a inscrição destes alunos na turma, com as seguintes regras:
- Aluno deve ser cadastrado com no mínimo 1 turma;
- O e-mail e CPF do aluno não pode ser inválido;
- Aluno pode se matricular em diversas turmas, mas não mais de 1x na mesma turma;
- Uma turma não pode ter mais de 5 alunos;
- Aluno não pode ser excluído se estiver associado em uma turma;
- Turma não pode ser excluída se possuir alunos;

## Estrutura do código

### Linguagem

C#(.NET)

### Arquitetura

Arquitetura DDD em conjunto com CleanCode, pois o DDD protege o conhecimento do domínio, traz mais flexibilidade e facil monitoramento e o CleanCode auxilia na leitura e manutenibilidade do código

No código temos as camadas:
- Domain, onde estão inseridos os modelos que norteiam as regras;
- Data, onde é feita a comunicação com o banco de dados
- Business, onde ficam as regras específicas de validação
- API, onde é feita a interface de comunicação do usuário
- CrossCutting, camada onde ficam itens que se comunicam com mais de uma camada

O código possui 3 entidades na camada Domain, sendo uma delas apenas relacional
- Aluno, que emula um aluno que será inscrito em uma turma
- Turma, que emula uma turma que poderá comportar alunos
- AlunoTurma, que é a entidade relacional, que representaria a inscrição do aluno na turma

Para proteger as entidades, utilizamos dtos(Data Transfer Object) na camada CrossCutting.
Cada entidade possui os dtos de leitura, criação e atualização.

### Acesso a dados

Entity Framework como abordagem code first via migrations

### Banco de dados
SQL Server

### Documentação
Foi utilizado Swagger para a documentação da API

## Sobre o uso da API

Seguindo as regras de uso da API que foram mencionadas anteriormente, primeiro é preciso criar uma nova turma, que precisa conter os seguintes dados:
- Número
- Ano Letivo
- Nível

Os níveis vão de 1 a 3, sendo eles respectivamente básico, intermediário e avançado.

Então já é possível cadastrar um novo aluno, pois pelas regras um aluno só pode ser cadastrado caso haja a inscrição do mesmo em uma turma.
O aluno precisa dos seguintes dados:
- Nome
- CPF
- Email
- Data de Nascimento (não obrigatório)
- Turma Inicial (definido pelo Id)

A Api já faz a automaticamente a verificação se o e-mail segue a estrutura pré definidas do emails e se o CPF é válido.
O método de validação do CPF segue as regras de verificação dos digitos verificadores.

Por último é possível inscrever alunos em turmas, através de AlunoTurma.
Somente é necessário o Id do Aluno e o Id da Turma para realizar esse processo.

É possível utilizar os métodos Criar, Atualizar, Atualizar Parcialmente, Buscar todos, Buscar por id e Deletar em todas as entidades.

O método Atualizar Parcialmente precisa de:
- id (inserido via URL, ou no Swagger no campo que será apresentado)
- path (nome do atributo a ser alterado, precedido pelo simbolo '/'. Ex: "/DataNascimento")
- op (nesse caso, "replace")
- from (nome da entidade que está sofrendo a alteração. "Aluno", "AlunoTurma" ou "Turma")
- value (novo valor que será inserido no atributo)

Obs: O OperationType que é requisitado não é necessário para realizar o procedimento.
