const pageUrl = document.URL;
const queryString = pageUrl.split('=')[2];

const specsTable = document.getElementById('specs-data');
const wantedQTY = document.getElementById('wanted-qty');
const form = document.forms[0];

const productImage = document.getElementById('product_image');
const productDesc = document.getElementById('product_desc');
const artnr = document.getElementById('artnr');
const brand = document.getElementById('brand');
const price = document.getElementById('price');
const model = document.getElementById('model');
const stock = document.getElementById('inStock');

const countItems = (myGuid) => {
    fetch('http://localhost:63492/api/CartItems/' + myGuid)
        .then(response => response.json())
        .then(json => {
            cartItems.textContent = json.items;
            cartItems.parentElement.href = 'cart.html?guid=' + json.cart_guid;
        });
}

fetch('http://localhost:63492/api/products/'+queryString)
    .then(response => response.json())
    .then(json => {
        console.log(json)
        productImage.attributes.src.value='./assets/images/'+json[0].img
        productDesc.textContent = json[0].desc
        model.textContent = json[0].model

        artnr.textContent = json[0].pn
        brand.textContent = json[0].brand
        price.textContent = json[0].price

        price.textContent = json[0].price
        stock.textContent = json[0].qty

        wantedQTY.attributes.max.value = json[0].qty
        wantedQTY.nextElementSibling.attributes.value.value = json[0].id

        const specs = json[0].specs.split(",");
        specs.forEach(spec => {
    
        let output = `
            <tr>
                <td>${spec.trim()}</td>
            </tr>
            `
            specsTable.innerHTML += output;
        });
    });
    
form.addEventListener('submit', (event) => {
event.preventDefault();
    
const wantedQTY = document.getElementById('wanted-qty');
const productId = document.getElementById('product_id');
    
    (async () => {
        await fetch('http://localhost:63492/api/myGuid')
        .then(response => response.json())
        .then(json => {
        let myGuid = json;
        let hasGuid = localStorage.getItem("freshop-guid");
            
        if (hasGuid == null) {
            localStorage.setItem("freshop-guid", myGuid);
        }

        const productGuid = myGuid;
        myGuid = localStorage.getItem("freshop-guid");

        const buyQTY = wantedQTY.value;
        const prodID = productId.value;
            const obj = { cart_guid: myGuid, product_id: prodID, product_guid: productGuid, quantity: buyQTY };
            
        fetch('http://localhost:63492/api/CartItems', {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: 'POST',
            body: JSON.stringify(obj)
        }) 
        .then(response => countItems(myGuid));
        });
    })();
});