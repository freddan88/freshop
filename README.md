## Simple webshop in - C#, html, css and javascript

> Assignment in C# for 04/04 2019 09:00 at Yrgo in Sweden Gothenburg. This is a small simple webshop that is rellying on an API written in C# (.net). Focus for this project were on backend but I have also built a simple frontend for this application.

_Languages Used:_ <br/>
_HTML CSS SQL Javascript C# (.net) Markdown <- Readme.md_

**( In this project we use an sqlite database to store information )**

[Code License: MIT](https://choosealicense.com/licenses/mit/)

---

#### Testers
- [Fredrik Leemann](https://github.com/freddan88)

#### Used during development

- MacOS High Sierra v10.13.6
- [Visiual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
- [Visiual Studio Code](https://code.visualstudio.com/)
- [DB Browser for SQLite](https://sqlitebrowser.org/)
- [MAMP (webserver)](https://www.mamp.info/en/)

#### Functionalities:

* [x] List all products
* [x] Filter products on categories
* [x] List single product
* [x] Buy product
* [x] Customer form
* [x] Order confirmation page

#### .NET Rest API - httpVerbs and endpoints

Controller|Description|HttpVerb|Endpoint|
-|-|-|-
Cart|Display cartitems + products from your cart|Get|'host'/api/cart/'guid'
CartItems|Display cartitems from all carts|Get|'host'/api/CartItems
CartItems|Count cartitems from your cart|Get|'host'/api/CartItems/'guid'
CartItems|Insert/Add products to your cart|Post|'host'/api/CartItems
CartItems|Delete products from your cart|Delete|'host'/api/CartItems/'product_id'
Customer|Display all customers|Get|'host'/api/Customer
Customer|Display single customer|Get|'host'/api/Customer/'guid'
Customer|Insert more customers|Post|'host'/api/Customer
Order|Display your complete order|Get|'host'/api/order/'guid'
OrderItems|Display products and total price for each PN|Get|'host'/api/orderitems/'guid'
OrderValue|Display total value of your order|Get|'host'/api/ordervalue/'guid'
Orders|Display all placed orders|Get|'host'/api/orders
Orders|Display single order|Get|'host'/api/orders/'guid'
Orders|Place new orders|Post|'host'/api/orders
Products|Display all products|Get|'host'/api/products
Products|Filter products|Get|'host'/api/products/'id/pn/category'
Values|This endpoint is not used|?|'host'/api/values
guid|Generate a random guid|Get|'host'/api/myGuid

#### Example JSON to use for post

> CartItems:<br/>
{cart_guid: "0f8c2f2e-6909-4ee6-b28c-3ed826f39c91", product_id: "2", product_guid: "0f8c2f2e", quantity: "1"}

> Customer:<br/>
{"id": 23, "fname": "Fredrik", "lname": "Leemann", "adress": "Example", "zip": "Example", "city": "Gothenburg", "cart_guid": "0f8c2f2e-6909-4ee6-b28c-3ed826f39c91", "email": "fredrik@leemann.se"}

> Orders:<br/>
{"cart_guid": "0f8c2f2e-6909-4ee6-b28c-3ed826f39c91"}

---
YRGO - Assignment 2019 ( C# ) - 2019-04-04 09:00 URL www.leemann.se/fredrik
