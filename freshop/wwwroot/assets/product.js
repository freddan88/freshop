const pageUrl = document.URL;
const queryString = pageUrl.split('=')[1].toUpperCase();

const productImage = document.getElementById('product_image');

fetch('http://localhost:63492/api/products/'+queryString)
    .then(response => response.json())
    .then(json => {
        productImage.attributes.src.value='./assets/images/'+json[0].img
    });