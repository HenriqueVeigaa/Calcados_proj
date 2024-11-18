create database if not exists asaP;
use asaP;


create table if not exists cliente(
id_cliente int primary key,
nome_cliente varchar(45) not null,
data_nasc_cliente date not null,
cpf char(15) unique not null,
email_pessoal varchar(45) not null,
senha_cliente varchar(25) not null,
cidade_cliente varchar(45) not null,
bairro_cliente varchar(45) not null,
logadouro_cliente varchar(45) not null,
numero int not null,
complemento_cliente varchar(15) null);

create table if not exists funcionario(
id_funcionario int auto_increment primary key,
nome_funcionario varchar(45) not null,
data_nasc_funcionario date not null,
cpf char(15) unique not null,
cargo_funcionario varchar(30) not null,
email_comercial varchar(45) not null,
senha_funcionario varchar(25) not null,
cidade_funcionario varchar(45) not null,
bairro_funcionario varchar(45) not null,
logadouro_funcionario varchar(45) not null,
complemento_cliente varchar(15) null);

create table if not exists fornecedor(
id_fornecedor int primary key auto_increment,
nome_fornecedor varchar(45) not null,
telefone_comercial varchar(15) not null,
email_suporte varchar(45) not null,
cnpj char(15) unique not null,
cidade_fornecedor varchar(45) not null,
 bairro_fornecedor varchar(45) not null,
 logadouro_fornecedor varchar(45) not null,
 numero_fornecedor int not null);

create table if not exists estoque(
id_estoque int primary key auto_increment,
fornecedor_id int default null,
qntd_estoque int not null,
preço_custo decimal(10,2) null,
preço_venda decimal(10,2) null,
constraint fk_estoque_fornecedor foreign key (fornecedor_id) references fornecedor(id_fornecedor));

create table if not exists produto(
id_prod int primary key,
estoque_id int default null,
nome_prod varchar(40) not null,
tamanho_prod int not null,
class_prod char(9) not null,
modelo_prod varchar(40) not null,
solado_prod varchar(40) not null,
adicionais_prod varchar(100) not null,
preco_prod decimal(10,2) not null,
constraint fk_prod_estoque foreign key (estoque_id) references estoque(id_estoque));

create table if not exists pedido(
id_pedido int primary key auto_increment,
cliente_id int default null,
data_pedido datetime not null,
status_pedido varchar(15) not null,
total_pedido decimal(10,2) not null,
prazo_finalizar varchar(30) null,
prazo_entrega date null,
metodo_pagamento varchar(25) not null,
constraint fk_pedido_cliente foreign key (cliente_id) references cliente (id_cliente));

create table if not exists pedido_prod(
id_pedido_prod int primary key,
produto_id int default null,
pedido_id int default null,
qtd_produto_ped int not null,
constraint fk_pedido_prod_produto foreign key (produto_id) references produto (id_prod),
constraint fk_pedido_prod_pedido foreign key (pedido_id) references pedido (id_pedido));



