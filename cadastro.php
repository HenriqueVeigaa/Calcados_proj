<?php
if(isset($_POST['submit'])){

    include_once 'conexao.php';
  //  print_r($_POST['name']);
    //print_r($_POST['tel']);
   // print_r($_POST['email']);
   // print_r($_POST['password']);
   $nome= $_POST['name'];
   $telefone= $_POST['tel'];
   $email= $_POST['email'];
   $senha= $_POST['password'];

   $enviar= mysqli_query($conexao, "INSERT INTO USER(nome_user,telefone_user,email_user,senha_user) 
    VALUES ('$nome','$telefone','$email','$senha')");
}
?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="styles/cadastro.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" integrity="sha512-DTOQO9RWCH3ppGqcWaEA1BIZOC6xxalwEsw9c2QQeAIftl+Vegovlnee1c9QX4TctnWMn13TZye+giMm8e2LwA==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <title>Login</title>
</head>
<body>
    <main id="container">
        <form action="cadastro.php" method="POST" id="login-form">
            <div id="form-header">
                <h1>Cadastro</h1>
            </div>

            <div id="social-media">
                <a href="#">
                    <img src="images/icon-gmail.png" alt="Gamil Logo">
                </a>

                <a href="#">
                    <img src="images/icon-google.png" alt="Google Logo">
                </a>

                <a href="#">
                    <img src="images/icon-github.png" alt="Github Logo">
                </a>

            </div>

            <div id="inputs">
                <div class="input-box">
                    <label for="name">
                        Nome
                    
                    <div class="input-field">
                        <i class="fa-solid fa-user"></i>
                        <input type="text" id="name" name="name" required>
                    </div>
                </label>
                </div>

                <div class="input-box">
                    <label for="tel">
                     Telefone
                    
                    <div class="input-field">
                        <i class="fa-solid fa-phone"></i>
                        <input type="tel" id="tel" name="tel" required>
                    </div>
                </label>
                </div>
                
                

                <div class="input-box">
                    <label for="email">
                        Email
                    
                    <div class="input-field">
                        <i class="fa-solid fa-envelope"></i>
                        <input type="email" id="email" name="email" required>
                    </div>
                </label>
                </div>

                <div class="input-box">
                    <label for="password">
                        Senha
                    
                    <div class="input-field">
                        <i class="fa-solid fa-key"></i>
                        <input type="password" id="password" name="password">
                    </div>
                </label>
                        <div id="forgot-password">
                            <a href="#">
                                Esqueceu sua Senha?<br> <br>
                            </a>

                        </div>

                        <div id="login-a">
                            <a href="login.html">
                             Já possui conta? Faça Login
                            </a>

                        </div>

                </div>

            </div>
            <input type="submit" name="submit" id="login-btn">

        </form>
    </main>
</body>
</html>