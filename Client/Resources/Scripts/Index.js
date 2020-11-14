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
        html += "<div><p><b>ID: </b></p><p>" + json.productID+ "</p>";
        html += "<p><b>Name: </b></p><p id = \"ProductName\">" + json.productName + "</p>";
        html += "<p><b>Price: </b></p><p>" +  json.productPrice + "</p>";
        html += " <var id = \"ProductType\" style = \"display: none;\">" + json.productType + "</var>";
        html += " <var id = \"ProductDiscount\" style = \"display: none;\">" + json.productDiscount + "</var>";
        html += "<input type=\"submit\" value = \"Add to Cart\" onclick = \"addTLI(" + json.productID + ", " + json.productPrice + ", " + json.productDiscount + ")\"/>";
        html += "</div>";
        document.getElementById("product").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
}

function getMember(memberPhone){
    const getMemberApiUrl = "https://localhost:5001/API/Members";

    fetch(getMemberApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        json.forEach((member)=>{
            console.log(member.memberPhone);
            console.log(memberPhone);
            if(memberPhone == member.memberPhone)
            {
                console.log("went through");
                window.location.href = "MemberPOS.html";
                addMemberTransaction(member.memberID);
            }
            else
            {
                console.log("didn't go through");
            }
        });
    }).catch(function(error){
        console.log(error);
    });
}

function getManager(ID){
    const getManagerApiUrl = "https://localhost:5001/API/Managers/" + ID;
    fetch(getManagerApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        if(ID == json.managerID)
        {
            console.log("went through");
            var html = " <var id = \"ManagerName\" style = \"display: none;\">" + json.managerName + "</var>";
            document.getElementById("karen").innerHTML = html;
        }
        else
        {
            console.log("didn't go through");
        }
    }).catch(function(error){
        console.log(error);
    });
}

function getEmployee(ID){
    const getEmployeeApiUrl = "https://localhost:5001/API/Employees/" + ID;
    fetch(getEmployeeApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        if(ID == json.employeeID)
        {
            console.log("went through");
            var html = " <var id = \"EmployeeName\" style = \"display: none;\">" + json.employeeName + "</var>";
            document.getElementById("emp").innerHTML = html;
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
    const addMTransactionApiUrl = "https://localhost:5001/API/Transactions";

    fetch(addMTransactionApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            member
        })
    })
}


function addTLI(productID, productPrice, productDiscount){
    const addTLIApiUrl = "https://localhost:5001/API/TransactionLineItems";
    const ID = productID;
    const Name = document.getElementById("ProductName").innerHTML;
    const Price = productPrice;
    const Type = document.getElementById("ProductType").innerHTML;
    const Discount = productDiscount;
    console.log(Type);  
    
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
    }).then((response)=>{
        console.log(response);
    })
}

function addProduct(price, mgrID, manager, empID, employee){
    const addProductApiUrl = "https://localhost:5001/API/Products";
    const Name = document.getElementById("name").value;
    const Price = price;
    const Type = document.getElementById("type").value;
    const DateOrdered = document.getElementById("ordered").value;
    const managerId = mgrID;
    const mName = manager;
    const employeeId = empID;
    const eName = employee;

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
            managerID: managerId,
            managerName: mName,
            employeeID: employeeId,
            employeeName: eName
        })
    })
    .then((response)=>{
        console.log(response);
    })
}


