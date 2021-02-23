<h1 class="center">Curso de MySQL 8.0</h1>

[Curso na Udemy](https://www.udemy.com/course/mysql_8_0/learn/lecture/18325436?start=0#overview)

## SEÇÃO 1 - CONTEÚDO DO CURSO

### Aula 2 - Novidades do MySQL 8.0:

- 2x mais rápida que a versão 5;
- Document Store Evoluido (NoSQL);
- Data Dictionary Transacional;
- Performance Schema 30x mais rápido;
- Information Schema 100x mais rápido;
- DDL Atômico: se houver erro em algum comando ddl ele aborta todo o script;
- Upgrade Automático: teoricamente, migrar do MySQL 5.7 => 8.0 bastar iniciar o BD na nova versão;
- Roles; - Novo mecanismos de senhas: melhorada criptografia;
- Histórico de senhas; - Resource Groups: a cada thread que o server for iniciar, poder informar a quantidade de recursos que ele vai usar;
- Indices invisíveis e descendentes;
- UTF8MB4 -> UTF-8 verdadeiro;
- Melhora significativa na InnoDB Cluster e Replicação;
- OpenSSL com suporte a TLS 1.3;

[Link do site oficial](https://dev.mysql.com/doc/refman/8.0/en/mysql-nutshell.html) |
[Medium - UTF-8 no MySQL](https://medium.com/@adamhooper/in-mysql-never-use-utf8-use-utf8mb4-11761243e434)

### Aula 3 - Documentação, download e ambiente:

### Aula 4 - Instalação Básica - 4 arquivos:

<h6>Arquivos, pastas e programas necessários:</h6>
  
  - Visual c++;
  - bin\mysqld.exe (server);
  - bin\mysql.exe (cliente);
  - bin\libcrypto-1_1-x64.dll;
  - bin\libprotobuf-lite.dll;
  - bin\libssl-1_1-x64.dll;

<h6>Comandos de inicialização</h6>
  
  '''
  bin\mysqld.exe --initialize-insecure
  '''

- <i>'Cria o usuário \'root\' sem senha'</i>;

- Comando acima vai criar a pasta \data com seu devido conteúdo;
- No bin\mysql.exe, mysql.exe -u root;

## SEÇÃO 2 - INSTALAÇÃO EM DETALHES

### Aula 5 - Conhecendo o server e sua árvore de arquivos:

## SEÇÃO 3 - MY.INI - A ALMA DO SERVER

## SEÇÃO 4 - O SERVER EM FUNCIONAMENTO

## SEÇÃO 5 - TABLESPACE

## SEÇÃO 6 - PARTITIONING

## SEÇÃO 7 - RELICAÇÃO

## SEÇÃO 8 - GRUPO DE REPLICAÇÃO

## SEÇÃO 9 - INNODB CLUSTER

## SEÇÃO 10 - BACKUP - PLUGIN CLONE
