# Curso de MySQL 8.0

- https://www.udemy.com/course/mysql_8_0/learn/lecture/18325436?start=0#overview

# SEÇÃO 1:

## AULA 2 - NOVIDADES DA VERSÃO 8.0:

https://dev.mysql.com/doc/refman/8.0/en/mysql-nutshell.html

- 2x mais rápida que a versão 5;
- Document Store Evoluido (NoSQL);
- Data Dictionary Transacional;
- Performance Schema 30x mais rápido
- Information Schema 100x mais rápido;
- DDL Atômico: se houver erro em algum comando ddl ele aborta todo o script;
- Upgrade Automático: teoricamente, migrar do MySQL 5.7 => 8.0 bastar iniciar o BD na nova versão;
- Roles; - Novo mecanismos de senhas: melhorada criptografia;
- Histórico de senhas; - Resource Groups: a cada thread que o server for iniciar, poder informar a quantidade de recursos que ele vai usar;
- Indices invisíveis e descendentes;
- UTF8MB4 -> UTF-8 verdadeiro;
- Melhora significativa na InnoDB Cluster e Replicação;
- OpenSSL com suporte a TLS 1.3;
