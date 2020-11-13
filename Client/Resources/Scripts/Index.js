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

function getProduct(ID){
    const getProductApiUrl = "https://localhost:5001/API/Products/" + ID;
    fetch(getProductApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        var html = "<div class = \"container\">";
        html += "<div><p><b>ID: </b>" + json.productID+ "</p>";
        html += "<p><b>Name: </b>" + json.productName + "</p>";
        html += "<p><b>Price: </b>" + json.productPrice + "</p>";
        html += "<input type=\"submit\" value = \"Add to Cart\" onclick = \"addTLI(" + json.productID + json.productName + json.productPrice + ")\"/>";
        html += "</div>";
        document.getElementById("product").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
}

function getProductType(ID){
    const getProductApiUrl = "https://localhost:5001/API/Products/" + ID;
    fetch(getProductApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        const Type = json.productType;
        return Type;
    }).catch(function(error){
        console.log(error);
    });
}

function getProductDiscount(ID){
    const getProductApiUrl = "https://localhost:5001/API/Products/" + ID;
    fetch(getProductApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        const Discount = json.productDiscount;
        return Discount;
    }).catch(function(error){
        console.log(error);
    });
}

function getMember(ID){
    const getMemberApiUrl = "https://localhost:5001/API/Members/" + ID;

    fetch(getMemberApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        if(ID == json.memberID)
        {
            console.log("went through");
            window.location.href = "POS.html";
            addMemberTransaction(memberID);
        }
        else
        {
            console.log("didn't go through");
        }
    }).catch(function(error){
        console.log(error);
    });
}

function addMemberTransaction(memberID){
    const addMTransactionApiUrl = "https://localhost:5001/API/Transaction";

    fetch(addMTransactionApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({

        })
    })

}

function addTLI(productID, productName, productPrice){
    console.log(productID);
    const addTLIApiUrl = "https://localhost:5001/API/TransactionLineItems";
    const Name = productName;
    const Price = productPrice;
    const ID = productID;
    const Type = getProductType(productID);
    const Discount = getProductDiscount(productID);
    fetch(addTLIApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            productID: ID,
            productName: Name,
            productPrice: Price,
            productType: Type,
            productDiscount: Discount

        })
    })


}

function addProduct(){
    const addProductApiUrl = "https://localhost:5001/API/Products";
    const Name = document.getElementById("name").value;
    const Price = document.getElementById("price").value;
    const Type = document.getElementById("type").value;
    const DateOrdered = document.getElementById("ordered").value;
    const mgrID = document.getElementById("mgrID").value;
    const empID = document.getElementById("empID").value;

    fetch(addProductApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            productName: Name,
            productPrice: Price,
            productType: Type,
            dateOrdered: DateOrdered,
            managerID: mgrID,
            employeeID: empID
        })
    })
    .then((response)=>{
        console.log(response);
        getProducts();
    })
}


