
const mainNavigation = document.querySelectorAll('.main-header nav ul li');
const allProducts = document.getElementById('products');

fetch('http://localhost:63492/api/products')
    .then(response => response.json())
    .then(json => {
    
        const data = json;
        data.forEach(item => {

            let output = `<a href="product.html?pn=${item.pn.toLowerCase()}&id=${item.id}" class="product-module">
                <img src="./assets/images/${item.img}" alt="${item.model}">
                <small>${item.pn}</small>
                <hr width="120"/>
                <small>${item.qty} left in stock</small>
                <small class="product-module__price">$${item.price}</small>
            </a>`

            allProducts.innerHTML += output;
        });
    });

mainNavigation.forEach(item => {
    item.addEventListener('click', (e) => {
        const category = e.currentTarget.dataset.category;
        filterByCategory(category);
    })
});

const filterByCategory = (category) => {

    fetch('http://localhost:63492/api/products/'+category)
        .then(response => response.json())
        .then(json => {
            const data = json;
            allProducts.innerHTML = '';
            data.forEach(item => {
                
let output = `<a href="product.html?pn=${item.pn.toLowerCase()}" class="product-module">
                <img src="./assets/images/${item.img}" alt="${item.model}">
                <small>${item.pn}</small>
                <hr width="120"/>
                <small>${item.qty} left in stock</small>
                <small class="product-module__price">$${item.price}</small>
            </a>`

        allProducts.innerHTML += output;
        
        });
    });
}