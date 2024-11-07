 if(document.readyState == "loading"){
    document.addEventListener("DOMContentLoaded", ready)
 }else{
    ready()
 }

 function ready() {
    const Remove_btns = document.getElementsByClassName("remove-btn")

    for(var i=0;i< Remove_btns.length;i++){
       Remove_btns[i].addEventListener("click", removeProd)
          
       }

const qtdInput = document.getElementsByClassName("qtd-prod")
for (var i =0; i< qtdInput.length;i++){
qtdInput[i].addEventListener("change",updateTotal)

}

const addToCart =document.getElementsByClassName("btn")
for(var i=0; i< addToCart.length;i++) {
    addToCart[i].addEventListener("click", addProdToCart)
}
 }

 function checkIfInputNull(event){
if(event.target.value =="0"){
    event.target.parentElement.parentElement.remove()
}
 }

function addProdToCart(event) {
    const button = event.target
    const prodInfo = button.parentElement.parentElement
    const prodImg = prodInfo.getElementsByClassName("prod-img")[0].src
    const prodTitle = prodInfo.getElementsByClassName("shoe-title")
    const prodPrice = prodInfo.getElementsByClassName("shoe-price")[0].innerText


const prodCartName = document.getElementsByClassName("shoe-title")
for(var i =0; i< prodCartName.length;i++){
    if(prodCartName[i].innerText == prodTitle){
        prodCartName[i].parentElement.parentElement.getElementsByClassName("qtd-prod")[0].value++
        return
    }
}


     let newCartProd = document.createElement("tr")
     newCartProd.classList.add("cart-prod")

     newCartProd.innerHTML = `
      <td class="prod-id">
                        <img src="${prodImg}" class="cart-img" alt="${prodTitle}">
                        <strong class="cart-title">${prodTitle}</strong>
                    </td>
                    <td class="cart-price">
                        <span>${prodPrice}</span>
                    </td>

                    <td>
                        <input type="number" value="1" min="0" class="qtd-prod">
                        <button class="remove-btn" type="button">Remover</button>

                    </td>
     `
   const tableBody =  document.querySelector("cart-table tbody")
   tableBody.append(newCartProd)
   updateTotal()
   newCartProd.getElementsByClassName("qtd-prod")[0].addEventListener("change", checkIfInputNull)
   newCartProd.getElementsByClassName("remove-btn")[0].addEventListener("click",removeProd)
}




 function removeProd(event) {
    event.target.parentElement.parentElement.remove()
    updateTotal()

 }

 function updateTotal(){
    let Total = 0

    const cartProd = document.getElementsByClassName("cart-prod")
    for(var i = 0; i< cartProd.length;i++){
       const prodPrice = cartProd[i].getElementsByClassName("cart-prod")[0].innerHTML.Text.replace("R$", "").replace(",", ".")
       const prodQtd = cartProd[i].getElementsByClassName("qtd-prod")[0].value
       Total +=  prodPrice * prodQtd
   }
       Total= Total.toFixed(2)
       Total = Total.replace(".", ",")
       document.querySelector(".cart-total span").innerText = "R$"+ Total  
 }

