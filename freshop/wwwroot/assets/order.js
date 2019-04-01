const pageUrl = document.URL;
const queryString = pageUrl.split('=')[1];
const yourGuidInfo = document.getElementById('yourGuid');
const confirmSection = document.getElementById('confirmation-section');
const orderNR = document.getElementById('order-nr');
const orderDate = document.getElementById('order-date');
const nameField = document.getElementById('fullname');
const emailField = document.getElementById('email');
const yourCity = document.getElementById('city');
const yourZipm = document.getElementById('zip');
const orderValue = document.getElementById('order-value');
const tableData = document.getElementById('table-data');

yourGuidInfo.textContent = queryString;

const generateConfirmation = (data) => {
    
    const items = data.orderItems
    const orderNr = data.orders.order_nr;
    const orderdate = data.orders.placed_on;

    const fullName = data.customer.fname + ' ' + data.customer.lname;
    const city = data.customer.city;
    const email = data.customer.email;
    const mailzip = data.customer.zip;
    const totalValue = data.orderValue.order_value;

    orderNR.textContent = orderNr;
    orderDate.textContent = orderdate;
    nameField.textContent = fullName;
    emailField.textContent = email;
    yourCity.textContent = city;
    yourZipm.textContent = mailzip;
    orderValue.textContent = totalValue;

    items.forEach(item => {

        let tablerow =
            ` <tr>
            <td><img src="./assets/images/${item.img}" width="62" height="62" alt="${item.model}"/></td>
            <td><center>${item.total_qty}x</center></td>
            <td>${item.pn}</td>
            <td>${item.model}</td>
            <td><center>$${item.piece_price}</center></td>
            <td><center>$${item.total_price}</center></td>
        </tr>
        `
        tableData.innerHTML += tablerow;
    });
}

fetch('http://localhost:63492/api/order/' + queryString)
    .then(response => response.json())
    .then(json => generateConfirmation(json))