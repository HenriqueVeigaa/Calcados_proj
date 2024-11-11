<?php
$dbhost= 'localhost';
$dbusuario= 'root';
$dbsenha= '';
$dbnome= 'DB_site';

$conexao= new mysqli($dbhost,$dbusuario,$dbsenha,$dbnome);

//-if($conexao->connect_errno){
  //  echo "Erro";
//}else{
  //  echo "Conexao efetuada";
//}

?>