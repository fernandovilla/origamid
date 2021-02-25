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

<h4>Arquivos, pastas e programas necessários:</h4>
  
  - Visual c++;
  - bin\mysqld.exe (server);
  - bin\mysql.exe (cliente);
  - bin\libcrypto-1_1-x64.dll;
  - bin\libprotobuf-lite.dll;
  - bin\libssl-1_1-x64.dll;

<h4>Comandos de inicialização</h4>

1. bin\mysqld.exe --initialize-insecure => <i>Cria o usuário root sem senha</i>;
   - Comando acima vai criar a pasta \data com seu devido conteúdo;
2. bin\mysqld.exe:
   - Carrega o servidor MySQL;
3. bin\mysql.exe -u root
   - <i>Conecta no server com o client</i>

## SEÇÃO 2 - INSTALAÇÃO EM DETALHES

### Aula 5 - Conhecendo o server e sua árvore de arquivos:

- \bin:
  - exe: programas;
  - lib e dll: bibliotecas;
  - pdb: program database - necessários para depuração
- \doc: documentação do MySQL;
- \etc:
- \include: possui arquivos de cabeçalhos de compilação,
- \lib: plugins e outras bibliotecas. Se eu fizer um plugin, é aqui que ele ficará;
- \run: utilizada na compilação e geração de binários;
- \share: miscelânia de arquivos, ex.: mensagens, idiomas, conjunto de caracteres, exemplo de configuração, etc;
- \var: utilizada na compilação e geração de binários;

### Aula 6 - Conhecendo os arquivos do diretório data:

- \auto.cnf:
  - Gerado quando o servidor é inicializado caso ele não exista, se existe ele é lido, contem o UUID do server;
- \binlog.0000N:
  - Contém todos os comandos SQL disparados contra o servidor e que alteram dados; Show, Select, etc., não estarão neste arquivo;
  - Usado para replicação, recuperação de crash;
  - mysqlbinlog.exe é o programa que pode lê-lo;
  - É possível desliga-lo ou alterar o caminho;
  - row: linha que foi alterada;
  - statement: comando executado;
  - mixed: mistura entre os dois;
- \binlog.index: É o indice dos arquivos binlog.0000X;
- \ca.pem: Usados para conexão segura;
- \*.err:
  - Geralmente nome-da-maquina.ERR;
  - Warnings e erros que o MySQL vai gravando;
- \*.PID: Número do processo no windows;
- \ib_buffer_pool:
  - Grava o mapeamento do Buffer Pool;
- \ib_logfile0, ib_logfile1:
  - ReDo log - log de refazimento;
  - Contém instruções que alteraram o BD, assim como o log binário;
  - É de uso esclusivo do MySQL para recuperação de crash;
- \ibdata1:
  - System Table Space;
  - Áreas onde são armazenadas tudo o que o mysql precisa para funcionar plenamente: tabelas, indices, views, procedures, etc.;
  - É onde os dados são gravados propriamente ditos;
- \ibdtmp1: Semelhante ao ibdata1, porém seu funcionamento é para tabelas temporárias;
- \mysql.ibd: Também é um table space, novo na versão 8.0;
- \undo_001 e undo_002:
  - Responsáveis pelo controle transacional: begin, commit e rollback;
  - Pode ser criado em outro disco;
- \\#innodb_temp\:
  - Diretório que em parceria com o arquivo ibtemp1 para gravação de tabelas temporárias;
  - Também pode ser criado em outro local ou disco;
- \\mysql\:
  - Diretório do servidor;
  - Contém logs geral de tudo que entra e sai no MySQL;
- \\performance_schema\:
  - É uma Store Engine do MySQL;
- \\sys\:
  - Conjunto de objetos que auxiliam os DBA a extrair informações do performance_schema;

### Aula 7 - Os programas que compoem o server:

<h4>Programas do Server:</h4>

- mysqld.exe: o serviço do servidor propriamente dito;

<h4>Programas para instalação e upgrade:</h4>

- mysql_secure_installation.exe: melhora a segurança da sua instalação;
- mysql_ssl_rsa_setup.exe: gerador de arquivos para conexão segura SSL e RSA;
- mysql_tzinfo_to_sql.exe: responsável por carregar a tabela de timezone;
- mysql_upgrade: atualiza o diretório DATA após uma atualização de versão;

<h4>Programas clientes:</h4>

- mysql.exe: executa linha de comando para interação com o servidor;
- mysqladmin.exe: programa para operações administrativas;
- mysqlcheck.exe: manutenção de tabelas, verificações, reparações e otimizações;
- mysqldump.exe: utilizado para geração de backup lógico;
- mysqlpump.exe: utilizado para geração de backup lógico (evolução do dump);
- mysqlshow.exe: informações sobre base de dados, tabelas, colunas, indices, etc.;
- mysqlslap.exe: emulador de carga para testes no servidor;

<h4>Programas administrativos e utilitários:</h4>

- innochecksum.exe: verificador de checksum offline de base de dados (checksum = rotinas de verificação da integridade dos dados);
- mysql_config_editor.exe: utilitário para ofuscação de senhas de clientes em arquivos de configuração;
- mysqlbinlog.exe: utilitário para leitura dos arquivos de log binários;
- my_print_defaults.exe exibe as opções presentes nos grupos de opções de arquivos de config (my.ini, my.cnf, etc);
- ibd2sdi.exe: gerador de SDI a partir de um tablespace ibd ou ibdata;

<h4>Miscelânia de utilitários:</h4>

- lz4_decompress.exe: descompactador de arquivos gerados por mysqlpump.exe gerados com LZ4;
- zlib_decompress.exe: descompactador de arquivos gerados por mysqlpump.exe gerados com ZLIB;
- perror.exe: exibe o que significa os erros gerados pelo MySQL;

<h4>MySQL Router:</h4>

- Os binários já acompanham o servidor;

### Aula 8, 9 - Inicialização do Server:

- Encerramento de forma correta com mysqladmin.exe:
  - mysqladmin shutdown -u root;
  - mysqladmin shutdown -u root -P 9101;
- Inicialização do sistema - _\bin\mysqld.exe_:
  - _bin\mysqld_: apenas executar o programa é a inicialização mais básica, carrega com as configurações default;
  - _--console_: carrega o server, listando os processos;
  - _--port=9101_: carrega o server na porta 9101;
  - _--lc-messages=pt_BR_: adiciona mensagens em português;
- Inicialização do sistema com arquivo de configuração - _my.ini_ ou _my.cnf_:
  - Criar o arquivo _my.ini_ no diretório que está instalado o MySQL;
- **Observações**:
  - Adicionar no antivirus uma exclusão para a pasta \DATA;
  - Liberar a porta 9101 (default é 3306) no Firewall;

[Outras opções de inicialização](https://dev.mysql.com/doc/refman/8.0/en/server-options.html)

## Aula 10 - Inicialização do Server como Serviço do Windows:

- Sempre acessar o prompt de comando como admin;
- É uma boa prática instalar o serviço com um nome diferente do padrão;
- Instalação do serviço: - _bin\mysqld_:
  - _--install_: registra um serviço chamado _"MySQL"_;
  - _--install [nome-serviço]_: registra um serviço com o nome indicado;
  - _--install --defaults-file=[arquivo-configiracao]_: registra o serviço indicando um arquivo de configuração. Informar o local e nome do arquivo;
- Iniciar/Parar do serviço:
  - _net start [nome-serviço]_: comando do windows para iniciar um serviço registrado;
  - _net stop [nome-serviço]_: comando do windows para parar um serviço registrado;
  - _sc start [nome-serviço]_: comando do windows para iniciar um serviço registrado;
  - _sc stop [nome-serviço]_: comando do windows para parar um serviço registrado;
- Desinstalação do serviço:
  - _sc delete [nome-serviço]_: comando do windows para deletar serviços;

## SEÇÃO 3 - MY.INI - A ALMA DO SERVER

### Aula 11 - my.ini em muitos lugares:

- Locais que o MySQL busca o my.ini ou my.cnf:
  - _%windir%\my.ini_: opções globais;
  - _c:\my.ini_: opções globais;
  - _BASEDIR\my.ini_: opções globais. Diretório de instalação do MySQL;
  - _defaults-extra-file_: lê o arquivo específicado e todos os demais encontrados;
  - _%APPDATA%\mysql\.mylogin.cnf_: login path;
  - _DATADIR\mysqld-auto.cnf_: variáveis de sistemas como SET, PERSIST ou SETPERSIST ONLY;
- A leitura dos arquivos não é excludente, o MySQL vai ler a configiração de todos os arquivos encontrados se nenhum for indicado;

### Aula 12 - Sintaxe dos arquivos de configuração:

- Comentários:
  - \# ou ;
- Grupos:
  - [group] => [mysqld]
  - [client] => grupo que é lido apenas pelos programas clientes, ignorado pelo server;
  - [mysqld-8.0] => grupo que apenas a versão 8.0 vai ler. Versão X.X.XXX;
  - [mysqld-5.7] => grupo que apenas a versão 5.7 vai ler;
  - [mysql80port9101] => grupo que apenas o serviço "mysql80port9101" vai ler;
- Opções:
  - somente a opção, ex: _console_;
  - opção e valor, ex: _console=true_;
- Caminhos de arquivos e diretórios:
  - Aspas dupla + barras duplas: _basedir="C:\\\Arquivos de Programas\\\MySQL\\\MySQL Server 8.0"_;
  - Aspas duplas + barra simples: _basedir="C:\\Arquivos de Programas\\MySQL\\MySQL Server 8.0"_;
  - Aspas dupla + barra normal (unix): _basedir="C:/Arquivos de Programas/MySQL/MySQL Server 8.0"_;
  - Sem aspas + barras duplas: _basedir=C:\\\Arquivos de Programas\\\MySQL\\\MySQL Server 8.0_;
- Medidas:
  - K, M , G, T, P, E (maiúsculas e minúsculas)
  - bytes: _max-allowed-packed=16777216_;
  - megabytes: _max-allowed-packed=16M_ ou _max-allowed-packed=16m_;
  - calculo: _max-allowed-packed=16*1024*1024_;
  - opção abreviada: _max-a=16M_;

### Aula 13 - Diretivas !include e !includedir:

- Opção útil quando é necessário trabalhar com mais de um server na mesma maquina;
- Na primeira linha do arquivo de configuração:
  - _!include c:\mysql\mygeneral.ini_ -> as configurações existentes no 'mygeneral.ini' passam a ser aceitas no arquivo que fez o !include;
  - _!includedir c:\mysql\optconfig_ -> todas os arquivos de configuração existentes no diretório passam a ser considerados;
- Outras opções de sintaxe:
  - barras simples: _!include c:\\mysql\\myconfig.ini_;
  - barras duplas: _!include c:\\\mysql\\\myconfig.ini_;
  - barras normal: _!include c:/mysql/myconfig.ini_;
  - Não utilizar aspas ou escapes, mesmo que o path tenha espaço;

## SEÇÃO 4 - O SERVER EM FUNCIONAMENTO

### Aula 14 - Criando o primeiro arquivo de opções de inicialização:

- _Arquivo ini com configurações básicas:_ [my.ini](my-14.ini)

### Aula 15 - O MySQL Schema e o Data Dict:

## SEÇÃO 5 - TABLESPACE

## SEÇÃO 6 - PARTITIONING

## SEÇÃO 7 - RELICAÇÃO

## SEÇÃO 8 - GRUPO DE REPLICAÇÃO

## SEÇÃO 9 - INNODB CLUSTER

## SEÇÃO 10 - BACKUP - PLUGIN CLONE
