<?php
session_start()
?>
<!DOCTYPE html>
<html lang="pt-br" class="h-100">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Pagamento</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/css/style.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" integrity="sha512-DTOQO9RWCH3ppGqcWaEA1BIZOC6xxalwEsw9c2QQeAIftl+Vegovlnee1c9QX4TctnWMn13TZye+giMm8e2LwA==" crossorigin="anonymous" referrerpolicy="no-referrer" />  
    <style>
      body{
       background-color: #ffe8b4;
      }
    </style>
</head>
<body>


    <div class="px-4 py-5">
        <div class="d-block mx-auto mb-4 col-lg-2">

          
          

        </div>
        <div class="text-center">
            <h1 class="display-5 fw-bold text-body-emphasis font-circular-medium">Pagamento</h1>
                <div class="col-lg-6 mx-auto">
                <p class="lead mb-4">Escolha a forma de pagamento e junte-se a nós</p>
                <div class="d-grid gap-2 d-sm-flex justify-content-sm-center">
                    <button data-toggle="modal" data-target="#modal-donation" class="btn btn-warning btn-lg rounded-4">Pagar</button>
                </div>
            </div>
        </div>
    </div>
    
              
               
    <div class="modal fade" id="modal-donation" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content rounded-4 shadow">
            <div class="modal-header p-5 pb-4 border-bottom-0">
                <h1 class="fw-bold mb-0 fs-3" id="modal-title">
                <i class="fa-brands fa-cc-paypal"></i>
                <i class="fa-brands fa-google-pay"></i>
                <i class="fa-brands fa-amazon-pay"></i>
                <i class="fa-brands fa-apple-pay"></i>
                </h1>
                <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
            </div>

          
            <div id="modal-body-payer" class="modal-body p-5 pt-0">
                <form id="form-donation">
                    
                    <div id="alert-donation" class="alert alert-danger text-center d-none" role="alert"></div>
                    
                    <div class="form-floating mb-3">
                        <input type="text" class="form-control rounded-3" id="nickname" placeholder="Apelido" required autofocus>
                        <label for="nickname">Nome</label>
                    </div>


                    <div class="form-floating mb-3">
                        <input type="email" class="form-control rounded-3" id="email" placeholder="name@example.com" required>
                        <label for="email">Email</label>
                        
                        <small class="mt-2">Seu email não será compartilhado.</small>
                    </div>

                    <hr/>

                    <label for="value">Valor do Pagamento:</label>
                    <div class="input-group input-group-lg mt-1 mb-3">
                        <span class="input-group-text">R$</span>
                        <input type="text" class="form-control" id="value" placeholder="0,00" required>
                    </div>
                    
                    <button type="submit" class="w-100 border-none mb-2 btn btn-lg btn-warning text-white fw-bold rounded-3">Continuar</button>
                
                    <div class="text-center">
                        <p class="text-body-secondary small mt-2 mb-3">
                        <i class="fa-brands fa-pix"></i> Pagamento via PIX
                        </p>
                    </div>
                </form>
            </div>
           
            <div id="modal-body-payment" class="modal-body text-center d-none">
                
                <div id="loading" class="text-center mb-4 mt-4">
                    <div class="spinner-border text-warning" style="width: 5rem; height: 5rem;" role="status"></div>
                </div>

                <div class="row d-none" id="payment-content">
                    <div class="col-md-12">
                        <img src="" id="image-qrcode-pix" style="width: 100%;" />
                    </div>
                    <div class="col-md-12">
                        <textarea class="form-control" id="code-pix" rows="5" cols="80"></textarea>
                        <button class="w-90 mt-3 rounded-4 btn btn-warning text-white btn-clipboard btn-lg px-4 gap-3" id="copyButton">Copiar</button>
                    </div>
                </div>
            </div>
           
            <div id="modal-body-approved" class="modal-body text-center d-none">
              
            </div>
          
        </div>
    </div>
</div>

    <script src="https://cdn.jsdelivr.net/npm/canvas-confetti@1.9.0/dist/confetti.browser.min.js"></script>

    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>

   
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>

  
    <script src="js/app.js"></script>

    
<?php
 session_unset();    
 session_destroy();
  
 
?>
</body>
</html>