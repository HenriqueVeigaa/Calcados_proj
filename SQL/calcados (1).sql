create database if not exists asaP;
use asaP;


create table if not exists cliente(
id_cliente int primary key auto_increment,
nome_cliente varchar(45) not null,
cpf char(15) unique not null,
email_pessoal varchar(45) not null,
senha_cliente varchar(25) not null,
RG varchar(40) not null,
cidade_cliente varchar(45) null,
bairro_cliente varchar(45) null,
logadouro_cliente varchar(45) null,
complemento_cliente varchar(15) null);
select * from cliente;

create table if not exists funcionario(
id_funcionario int primary key,
nome_funcionario varchar(45) not null,
cpf char(15) unique not null,
cargo_funcionario varchar(30) not null,
email_comercial varchar(45) not null,
senha_funcionario varchar(25) not null,
cidade_funcionario varchar(45) null,
bairro_funcionario varchar(45) null,
logadouro_funcionario varchar(45) null,
complemento_cliente varchar(15) null);

create table if not exists fornecedor(
id_fornecedor int primary key,
nome_fornecedor varchar(45) not null,
telefone_comercial varchar(15) not null,
email_suporte varchar(45) not null,
cnpj char(15) unique not null,
cidade_fornecedor varchar(45) null,
 bairro_fornecedor varchar(45) null,
 logadouro_fornecedor varchar(45) null,
 numero_fornecedor int null);


create table if not exists produto(
id_prod int primary key,
nome_prod varchar(40) not null,
tamanho_prod int not null,
class_prod char(9) not null,
modelo_prod varchar(40) not null,
solado_prod varchar(40) not null,
adicionais_prod varchar(100) null,
qtd_prod int not null,
preco_prod decimal(10,2) not null);
select * from produto;

create table if not exists pedido(
id_pedido int primary key,
cliente_id int default null,
produto_id int default null,
metodo_pagamento varchar(25) not null,
constraint fk_pedido_prod_produto foreign key (produto_id) references produto (id_prod),
constraint fk_pedido_cliente foreign key (cliente_id) references cliente (id_cliente));
select * from pedido;


