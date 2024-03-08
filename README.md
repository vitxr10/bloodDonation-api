# API para sistema de gerenciamento de doação de sangue

Regras de negócio:
- Não é permitido cadastrar doadores com o mesmo e-mail 
- Menor de idade não pode doar, mas pode ter cadastro 
- Pesar no mínimo 50KG 
- Mulheres só podem doar de 90 em 90 dias 
- Homens só podem doar de 60 em 60 dias 
- Quantidade de mililitros de sangue doados deve ser entre 420ml e 470ml 
- Atualizar o estoque de sangue sempre que registrar uma doação

Funcionalidades: 
- Cadastrar doadores, doações e estoques 
- Validar dados de entrada 
- Consultar doadores, doações e estoques 
- Gerar relatório sobre a quantidade total de sangue por tipo disponível 
- Gerar relatório de doações nos últimos 30 dias com informações dos doadores 
- Gerar histórico de doações de um doador 

Tecnologias e padrões utilizados: 
- Arquitetura limpa 
- CQRS 
- Padrão Repository 
- FluentValidation 
- C#
- .NET 8 
- ASP.NET CORE 
- Entity Framework 
- SQL Server 
