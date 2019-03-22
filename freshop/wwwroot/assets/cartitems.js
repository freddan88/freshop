const cartItems = document.getElementById('cart_items');

if (localStorage.getItem("freshop-guid")){
    const userGuid = localStorage.getItem("freshop-guid");
    fetch('http://localhost:63492/api/CartItems/'+userGuid)
    .then(response => response.json())
    .then(json => {
        cartItems.textContent = json.items;
        cartItems.parentElement.href = 'cart.html?guid='+json.cart_guid;
    });
}