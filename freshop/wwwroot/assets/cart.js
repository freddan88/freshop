const pageUrl = document.URL;
const queryString = pageUrl.split('=')[1];
const cartItems = document.querySelector('.cart-items');


const deleteItem = (itemId) => {
    fetch('http://localhost:63492/api/CartItems/' + itemId, {
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        method: 'DELETE',
    })
    .then(setTimeout(() => location.reload(true), 300));
}


fetch('http://localhost:63492/api/cart/' + queryString)
    .then(response => response.json())
    .then(json => {
        
        const cart = json;

        if (typeof json[0] != 'object') {
            cartItems.innerHTML = `<h1 class="col2">You have no items in your shopping cart yet!</h1>`;
        } else {
            cartItems.innerHTML = `<h3 class="col2"><a href="./customer.html?guid=${queryString}">Review below and click here to continue</a></h3>`;

        cart.forEach(item => {
            
let output = `<div class="cart-item">
            <img src="./assets/images/${item.img}" alt="${item.model}">
            
            <ul>
                <li><small>Art.Nr: ${item.pn}</small></li>
                <li><small>Model: ${item.model}</small></li>
                <li><small>QTY: ${item.quantity}</small></li>
                <li><small>Price(each): $${item.price}</small></li>
            </ul>

            <button class="delete-cartItem" data-guid="${item.product_guid}" data-itemID="${item.id}">X</button>
        </div>`

                cartItems.innerHTML += output;
            });
            
            const CartItems = document.querySelectorAll('.delete-cartItem')
            CartItems.forEach(item => {

                item.addEventListener('click', () => {
                    const itemId = item.dataset.itemid;
                    deleteItem(itemId);
                });
            });
        }
        });