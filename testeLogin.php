<?php
session_start();

if(isset($_POST['submit']) && !empty($_POST['email']) && !empty ($_POST['password'])){
include_once 'conexao.php';
$email=$_POST['email'];
$senha=$_POST['password'];


$sql= "SELECT * FROM USER WHERE email_user ='$email' and senha_user='$senha' ";
$enviar=$conexao->query($sql);
//print_r($enviar);
if(mysqli_num_rows($enviar) <1) {
    unset( $_SESSION['email']);
    unset($_SESSION['password']);
    header('Location: login.php');
}
else{
    $_SESSION['email']= $email;
    $_SESSION['password']= $senha;
    header('Location: pagamento.php');
}
}else{
    header('Location: login.php');
}
?>