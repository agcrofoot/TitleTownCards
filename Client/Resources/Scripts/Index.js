function getProducts(){
    const getAllProductsApiUrl = "https://localhost:5001/API/Products";
    fetch(getAllProductsApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html = "<div class = \"table-responsive\">";
        html += "<table class = \"table table-striped table width: \">";
        html += "<thead><tr><th>ProductID</th><th>Name</th><th>Price</th><th>Type</th><th>Status</th><th>Discount</th><th>Date Ordered</th><th>Date Added</th><th>Manager</th><th>Employee</th></tr></thead>";
        json.forEach((product)=>{
            html += "<tbody><tr key = "+ product.productID + "><td>" + product.productID + 
            "</td><td>" + product.productName + "</td><td>" + product.productPrice + "</td><td>" + product.productType + 
            "</td><td>" + product.productStatus + "</td><td>" + product.productDiscount + "</td><td>" + product.dateOrdered + 
            "</td><td>" + product.dateAddedToInv + "</td><td>" + product.managerName + "</td><td>" + product.employeeName + "</tr>";
        });
        html += "</tbody></table>";
        document.getElementById("allProducts").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
}

function showSearch()
{
    const showProductApiUrl = "https://localhost:5001/API/Products";
    fetch(showProductApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        console.log(json.productID);

        var html = "<form onsubmit=\"return false\" method = \"GET\">" + 
        " <input type=\"text\" name = \"searchID\" id = \"productSearch\" placeholder = \"Enter Product ID\"/>" +
        " <input type=\"submit\" value = \"Search\" onclick = \"getProduct(" + json.productID + ")\"/></form>";

        document.getElementById("search").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
   
}

function getProduct(productID){
    const getProductApiUrl = "https://localhost:5001/API/Products/" + productID;


    fetch(getProductApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html = "<div class = \"container\">";
        html += "<div><p><b>ID: </b>" + json.productID + "</p><p><b>Name: </b>" + json.productName + "</p><p><b>Price: </b>" + json.productPrice + "</p>";
        html += "</div";
        document.getElementById("products").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
}

function addProduct(){
    const addProductApiUrl = "https://localhost:5001/API/Products";
    const productName = document.getElementById("name").value;
    const productPrice = document.getElementById("price").value;
    const productType = document.getElementById("type").value;
    const dateOrdered = document.getElementById("ordered").value;
    const managerID = document.getElementById("mgrID").value;
    const employeeID = document.getElementById("empID").value;

    fetch(addProductApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            name: productName,
            price: productPrice,
            type: productType,
            ordered: dateOrdered,
            mgrID: managerID,
            empID: employeeID
        })
    })
    .then((response)=>{
        console.log(response);
        getProducts();
    })
}


