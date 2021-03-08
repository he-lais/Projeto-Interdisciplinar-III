# DOCJUR

Percebemos que no setor jurídico o trabalho manual é muito grande e que a automatização de geração de documentos que são realizado pelos clientes os poupariam tempo. 
Com isso faremos formulários que contenha os dados principais dos processos. 
Um sistema que vai automatizar os documentos padronizados de acordo com as informações informadas via formulário pelo usuário, que no fim do preenchimento vai gerar o documento.

## Instruções de execução

O sistema é dividido entre uma api em .net core e o frontend web em vuejs. 

Para executar a api:
* Ter postgresql e .netcore instalados
* Configurar a porta e conexão com o banco de dados em Codigo/DocJur.Api/DocJur.Api.App/App.config
* Executar o projeto DocJur.Api.App usando Visual Studio ou outra ferramente de preferência.

Para executar o frontend:
* Ter nodejs e npm instalados
* Rodar npm install na pasta Codigo/DocJur.Frontend
* Rodar npm run serve na pasta Codigo/DocJur.Frontend

Na pasta de documentação está disponível uma postman collection para testar a api diretamente.

## Alunos integrantes da equipe

* Laís Helena Oliveira de Paula
* Paulo Henrique Cota Starling
* Sarah Julia Campos de Freitas Lara


## Professores responsáveis

* Eveline
* Juliana Baroni

## Instruções de utilização

Assim que a primeira versão do sistema estiver disponível, deverá complementar com as instruções de utilização. Descreva como instalar eventuais dependências e como executar a aplicação.
