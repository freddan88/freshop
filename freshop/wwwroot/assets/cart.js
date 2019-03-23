const pageUrl = document.URL;
const queryString = pageUrl.split('=')[1];
const cartItems = document.querySelector('.cart-items');

fetch('http://localhost:63492/api/orders/' + queryString)
    .then(response => response.json())
    .then(json => console.dir(json));