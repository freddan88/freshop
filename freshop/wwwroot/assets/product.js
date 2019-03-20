const pageUrl = document.URL;
const queryString = pageUrl.split('=')[1].toUpperCase();

const productImage = document.getElementById('product_image');
const productDesc = document.getElementById('product_desc');
const artnr = document.getElementById('artnr');
const brand = document.getElementById('brand');
const price = document.getElementById('price');
const model = document.getElementById('model');

fetch('http://localhost:63492/api/products/'+queryString)
    .then(response => response.json())
    .then(json => {
        console.log(json);
        productImage.attributes.src.value='./assets/images/'+json[0].img
        productDesc.textContent = json[0].desc
        model.textContent = json[0].model

        artnr.textContent = json[0].pn
        brand.textContent = json[0].brand
        price.textContent = json[0].price
    });