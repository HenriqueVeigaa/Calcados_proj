create database if not exists DB_site;
use DB_site;


create table if not exists user(
id_user int primary key not null auto_increment,
nome_user varchar(55) not null,
telefone_user varchar (15) not null,
email_user varchar(100) not null,
senha_user varchar(30) not null);

create table if not exists pedido(
id_pedido int primary key auto_increment not null,
forma_pagamento varchar(20) not null,
endereço varchar(200) not null,
tipo_entrega varchar(30));

select * from user;