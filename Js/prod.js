if(document.readyState == "loading"){                          //verifica se a página html está carregando ou está totalmente carregada
document.addEventListener("DOMContentLoaded",ready)           //DOMContentLoaded indica quando os elementos html foram carregados; 
}else{
    ready()
}
                               
function ready(){

    const removeProdBtn =document.getElementsByClassName("remove-btn")      //pegando elementos q possuem a classe remove-btn
    for(var i=0;i<removeProdBtn.length;i++){
    removeProdBtn[i].addEventListener("click",removeProd)                   //pegando a quantidade de botoes da classe com o for, atribuindo um ouvidor de eventos ao clicar capturando a ação do botao                                                    
}

const QtdInput = document.getElementsByClassName("qtd-prod")
for( var i = 0; i< QtdInput.length; i++){
QtdInput[i].addEventListener("change",CheckInptNull) //o addEventListener "olha" mudanças nos botões de input e com o change verifica a qtd dos produtos e atualiza o valor com a função 
}

const AddCartBtn = document.getElementsByClassName("input-btn")
for(var i = 0; i< AddCartBtn.length; i++){
AddCartBtn[i].addEventListener("click",AddProdCart)
}

}

function CheckInptNull(event){       //checando se o input é zero para removê-lo do carrinho; //capturar o input que sofreu alteração
  if(event.target.value== "0"){         //condição pra checar se o valor do input é zero

    event.target.parentElement.parentElement.remove()
  }                                

    updateValor();
}


function AddProdCart(event){    //função criada para pegar os 3 elementos necessários para adicionar-los no carrinho
    const btn = event.target //é retornado o btn clicado
    const ProdInfo= btn.parentElement //Criado a variavel ProdInfo onde é retornado a classe pai do btn(que no código é a div shoes)
    const ProdImg = ProdInfo.getElementsByClassName("shoe-image")[0].src //variavel que quando o botão é clicado retorna a imagem e o src, que irá aparecer no carrinho
    const ProdNome = ProdInfo.getElementsByClassName("shoe-title")[0].innerText //variavel retorna a tag html da classe shoe-title, mas com o InnerText se busca o nome do produto
    const ProdPrice = ProdInfo.getElementsByClassName("shoe-price")[0].innerText 

    const ProdCartName = document.getElementsByClassName("cart-title") //verificando se o produto que vamos colocar no carrinho já está nele, para apenas aumentar a qtd de inputs
    for(var i =0; i < ProdCartName.length;i++){                        //verificando se o produto que vamos colocar no carrinho já está nele, para apenas aumentar a qtd de inputs
      if( ProdCartName[i].innerText === ProdNome){
       ProdCartName[i].parentElement.parentElement.getElementsByClassName("qtd-prod")[0].value++ //pegando o elemento pai do prodcartname e atribuindo mais um ao input
    return //o return faz com que não execute o NewCartProd evitando que o produto seja adicionado novamente, aumentando somente a qtd de inputs
    }                           
   
}

   let NewCartProd = document.createElement("tr")        //criando um elemento tr js
    NewCartProd.classList.add("cart-prod")                        //Acessando as classes dos elementos com o classlist e adicionando a classe do tr com o add
    
    NewCartProd.innerHTML =                                        //informando o que vai ter dentro do tr com o innerhtml

    `
          <td class="prod-id">
                        <img src="${ProdImg}" class="cart-img" alt="${ProdNome}">
                        <strong class="cart-title">${ProdNome}</strong>
                    </td>
                    <td class="cart-price">
                        <span>${ProdPrice}</span>
                    </td>

                    <td>
                        <input type="number" value="1" min="0" class="qtd-prod">
                        <button class="remove-btn" type="button">Remover</button>

                    </td>
    
    `
                


   const Table= document.querySelector(".cart-table tbody")              //criando a váriavel Table pra pegar o tbody
   Table.append(NewCartProd)                                           //append é responsável por adicionar o elemento tr criado no tbody
    updateValor()
   NewCartProd.getElementsByClassName("qtd-prod")[0].addEventListener("change",CheckInptNull)                 //pegando o input para atualizar o valor depois de um produto ser acrescentado no carrinho
    NewCartProd.getElementsByClassName("remove-btn")[0].addEventListener("click",removeProd)                //pegando o input para remove-lo  depois de um produto ser acrescentado no carrinho
}


function removeProd(event){
    event.target.parentElement.parentElement.remove() //acessando o elemento pai e removendo a tag tr para o produto desaparecer do carrinho
    updateValor() //após remover os produtos, a função altera o valor
}




function updateValor(){

    let TotalCart = 0; //variavel responsavel pra armazenar o valor total do carrinho

const cartProd = document.getElementsByClassName("cart-prod")     //pegando os itens do carrinho com a classe cart-prod
for( var i = 0; i< cartProd.length; i++){
    const prodPrice = cartProd[i].getElementsByClassName("cart-price")[0].innerText.replace("R$", "").replace(",", ".")    //replace substitui o valor do primeiro parametro pelo segundo pra fazer a multiplicação           //innertext pega o texto da tag html, e nao a tag em si;          //pegando o preço do produto dos itens do carrinho
    const prodQtd = cartProd[i].getElementsByClassName("qtd-prod")[0].value             //Procura a classe qtd-prod no cartprod(item do carrinho) e acessa a posição zero para retornar o valor dos inputs com o value

TotalCart +=  prodPrice * prodQtd //+= significa que recebe ele mesmo mais a condição imposta

}    
TotalCart = TotalCart.toFixed(2)
TotalCart = TotalCart.replace(".", ",")
document.querySelector(".cart-total span").innerText = "R$"+ TotalCart  
 //outra forma de pegar elementos em js, elemento span da classe cart-total    
    
}



